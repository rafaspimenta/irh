using Payroll.Domain.Entities;
using Payroll.Domain.Enums;
using Payroll.Domain.Interfaces;
using Payroll.Domain.Strategies;

namespace Payroll.Domain.Factories;

public static class EmployeeFactory
{
    public static IEmployee Create(
        EmployeeType type,
        string name,
        double baseSalary)
    {
        var salaryStrategy = new SalaryStrategy();
        var bonusStrategy = BonusStrategyFactory.Create(type);
        
        return type switch
        {
            EmployeeType.Permanent => new PermanentEmployee(name, type, baseSalary, salaryStrategy, bonusStrategy),
            EmployeeType.Contractor => new ContractorEmployee(name, type, baseSalary, salaryStrategy, bonusStrategy),
            _ => throw new ArgumentException("Invalid employee type")
        };
    }
}