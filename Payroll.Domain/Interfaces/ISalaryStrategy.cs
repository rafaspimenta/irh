namespace Payroll.Domain.Interfaces;

public interface ISalaryStrategy
{
    double CalculateSalary(IEmployee employee, DateOnly referenceDate);
}