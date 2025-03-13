using Payroll.Domain.Enums;
using Payroll.Domain.Interfaces;

namespace Payroll.Domain.Entities;

public abstract class Employee(
    string name,
    EmployeeType type,
    double baseSalary,
    ISalaryStrategy salaryStrategy,
    IBonusStrategy bonusStrategy)
    : IEmployee
{
    public string Name { get; } = name;
    public double BaseSalary { get; } = baseSalary;
    
    public EmployeeType Type { get; } = type;
    public abstract int AllowedLeavesPerMonth { get; }

    private readonly List<Leave> _leaves = [];
    public IReadOnlyCollection<Leave> Leaves => _leaves.AsReadOnly();

    private readonly List<PaymentHistory> _paymentHistories = [];
    public IReadOnlyCollection<PaymentHistory> PaymentHistories => _paymentHistories.AsReadOnly();

    private ISalaryStrategy SalaryStrategy { get; } = salaryStrategy;
    private IBonusStrategy BonusStrategy { get; } = bonusStrategy;

    public void AddLeave(Leave leave)
    {
        _leaves.Add(leave);
    }

    public void RecordPayment(PaymentHistory history)
    {
        _paymentHistories.Add(history);
    }

    public double CalculateSalary(DateOnly paymentDate)
    {
        return SalaryStrategy.CalculateSalary(this, paymentDate);
    }

    public double CalculateAnnualBonus(DateOnly bonusReferenceDate)
    {
        return BonusStrategy.CalculateBonus(this, bonusReferenceDate);
    }

    public int GetLeavesForMonth(int year, int month)
    {
        return Leaves
            .SelectMany(l => l.RequestedDays)
            .Count(date => date.Year == year && date.Month == month);
    }
}