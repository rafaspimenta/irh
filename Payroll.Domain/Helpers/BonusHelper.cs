using Payroll.Domain.Interfaces;

namespace Payroll.Domain.Helpers;

public static class BonusHelper
{
    public static int CalculateExtraLeavesLast12Months(IEmployee employee, DateOnly bonusReferenceDate)
    {
        var startDate = bonusReferenceDate.AddMonths(-11);
        var startMonth = new DateOnly(startDate.Year, startDate.Month, 1);
        var endMonth = new DateOnly(bonusReferenceDate.Year, bonusReferenceDate.Month, 1);

        var leaveDaysByMonth = employee.Leaves
            .SelectMany(leave => leave.RequestedDays)
            .Where(date => date >= startMonth && date <= endMonth)
            .GroupBy(date => new { date.Year, date.Month })
            .ToDictionary(
                g => g.Key,
                g => g.Count()
            );

        return leaveDaysByMonth
            .Sum(month => Math.Max(0, month.Value - employee.AllowedLeavesPerMonth));
    }
}