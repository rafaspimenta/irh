using Payroll.Domain.Entities;
using Payroll.Domain.Enums;
using Payroll.Domain.Interfaces;

namespace Payroll.Domain.Services;

public class PaymentProcessor
{
    private const int FinalMonth = 12;
    public static void ProcessMonthlyPayment(IEmployee employee, DateOnly paymentDate)
    {
        var salary = employee.CalculateSalary(paymentDate);
        var history = new PaymentHistory(PaymentType.Salary, paymentDate, salary);
        employee.RecordPayment(history);
    }

    public static void ProcessAnnualBonus(IEmployee employee, DateOnly paymentDate)
    {
        var bonus = employee.CalculateAnnualBonus(paymentDate);
        var history = new PaymentHistory(PaymentType.Bonus, paymentDate, bonus);
        employee.RecordPayment(history);
    }
}