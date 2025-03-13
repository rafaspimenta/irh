namespace Payroll.Domain.Interfaces;

public interface IBonusStrategy
{
    double CalculateBonus(IEmployee employee, DateOnly bonusReferenceDate);
}