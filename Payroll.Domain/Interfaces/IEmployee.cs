using Payroll.Domain.Entities;
using Payroll.Domain.Enums;

namespace Payroll.Domain.Interfaces;

public interface IEmployee
{
    string Name { get; }
    EmployeeType Type { get; } 
    double BaseSalary { get; }
    int AllowedLeavesPerMonth { get; }
    IReadOnlyCollection<Leave> Leaves { get; }
    IReadOnlyCollection<PaymentHistory> PaymentHistories { get; }
    double CalculateSalary(DateOnly paymentDate);
    double CalculateAnnualBonus(DateOnly bonusReferenceDate);
    void AddLeave(Leave leave);
    void RecordPayment(PaymentHistory history);
    int GetLeavesForMonth(int year, int month);
}