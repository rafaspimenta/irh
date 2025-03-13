using Payroll.Domain.Helpers;
using Payroll.Domain.Interfaces;

namespace Payroll.Domain.Strategies;

public class AnnualBonusContractorStrategy : IBonusStrategy
{
    private const double ExtraLeaveDiscountRate = 0.1;

    public double CalculateBonus(IEmployee employee, DateOnly bonusReferenceDate)
    {
        var extraLeaves = BonusHelper.CalculateExtraLeavesLast12Months(employee, bonusReferenceDate);
        var bonus = employee.BaseSalary;
        bonus -= bonus * ExtraLeaveDiscountRate * extraLeaves;
        return bonus;
    }
}