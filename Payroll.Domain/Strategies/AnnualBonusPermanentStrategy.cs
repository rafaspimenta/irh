using Payroll.Domain.Helpers;
using Payroll.Domain.Interfaces;

namespace Payroll.Domain.Strategies;

public class AnnualBonusPermanentStrategy : IBonusStrategy
{
    private const double BonusIncreaseFactor = 1.5;
    private const double ExtraLeaveDiscountRate = 0.05;

    public double CalculateBonus(IEmployee employee, DateOnly bonusReferenceDate)
    {
        var extraLeaves = BonusHelper.CalculateExtraLeavesLast12Months(employee, bonusReferenceDate);
        var bonus = employee.BaseSalary * BonusIncreaseFactor;
        bonus -= bonus * ExtraLeaveDiscountRate * extraLeaves;
        return bonus;
    }
}