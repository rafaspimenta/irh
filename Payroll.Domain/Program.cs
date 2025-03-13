using Payroll.Domain.Entities;
using Payroll.Domain.Enums;
using Payroll.Domain.Factories;
using Payroll.Domain.Services;

namespace Payroll.Domain;

class Program
{
    static void Main()
    {
        var company = new Company("Payroll SA");
        
        var contractor = EmployeeFactory.Create(EmployeeType.Contractor, "Alice", 3000);
        var permanent = EmployeeFactory.Create(EmployeeType.Permanent, "Rafael", 2000);        
        
        company.AddEmployee(contractor);
        company.AddEmployee(permanent);

        foreach (var employee in company.Employees)
        {
            Console.WriteLine(
                $"Employee: {employee.Name}, " +
                $"Type: {employee.Type}, " +
                $"Base Salary: {employee.BaseSalary:C}," + 
                $" Allowed Leaves Per Month: {employee.AllowedLeavesPerMonth}");
        }
        
        contractor.AddLeave(new Leave([
            new DateOnly(2023, 1, 10), 
            new DateOnly(2023, 1, 11)
        ]));
        
        permanent.AddLeave(new Leave([
            new DateOnly(2023, 3, 12),
            new DateOnly(2023, 3, 13)
        ]));
        
        // Process monthly salary payment
        PaymentProcessor.ProcessMonthlyPayment(contractor, new DateOnly(2023, 1, 1));
        
        // Process annual bonus payment
        PaymentProcessor.ProcessAnnualBonus(contractor, new DateOnly(2023, 12, 1));
        
        PaymentProcessor.ProcessMonthlyPayment(permanent, new DateOnly(2023, 3, 1));
        PaymentProcessor.ProcessAnnualBonus(permanent, new DateOnly(2023, 12, 1));
        
        // Retrieve payment history if needed.
        foreach (var employee in company.Employees)
        {
            foreach (var payment in employee.PaymentHistories)
            {
                Console.WriteLine($"Payment for {employee.Name} " +
                                  $"at {payment.PaymentDate}, " +
                                  $"Type {payment.Type}, " +
                                  $"Amount {payment.Amount:C}");
            }
        }
        
    }
}