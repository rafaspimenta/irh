using Payroll.Domain.Interfaces;

namespace Payroll.Domain.Strategies;

public class SalaryStrategy : ISalaryStrategy
{
    public double CalculateSalary(IEmployee employee, DateOnly referenceDate)
    {
        var daysInMonth = DateTime.DaysInMonth(referenceDate.Year, referenceDate.Month);
        var leavesThisMonth = employee.GetLeavesForMonth(referenceDate.Year, referenceDate.Month);
        var extraLeaves = Math.Max(0, leavesThisMonth - employee.AllowedLeavesPerMonth);
        var deduction = (employee.BaseSalary / daysInMonth) * extraLeaves;
        return employee.BaseSalary - deduction;
    }
}