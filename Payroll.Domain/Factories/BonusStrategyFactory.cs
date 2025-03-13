using Payroll.Domain.Enums;
using Payroll.Domain.Interfaces;
using Payroll.Domain.Strategies;

namespace Payroll.Domain.Factories;

public static class BonusStrategyFactory
{
    public static IBonusStrategy Create(EmployeeType employeeType)
    {
        return employeeType switch
        {
            EmployeeType.Permanent => new AnnualBonusPermanentStrategy(),
            EmployeeType.Contractor => new AnnualBonusContractorStrategy(),
            _ => throw new ArgumentException($"No bonus strategy found for employee type: {employeeType}")
        };
    }
}