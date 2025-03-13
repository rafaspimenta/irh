using Payroll.Domain.Enums;

namespace Payroll.Domain.Entities;

public class PaymentHistory(PaymentType type, DateOnly paymentDate, double amount)
{
    public DateOnly PaymentDate { get; } = paymentDate;
    public PaymentType Type { get; } = type;
    public double Amount { get; } = amount;
}