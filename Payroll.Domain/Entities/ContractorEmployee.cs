using Payroll.Domain.Enums;
using Payroll.Domain.Interfaces;

namespace Payroll.Domain.Entities;

public class ContractorEmployee(
    string name,
    EmployeeType type,
    double baseSalary,
    ISalaryStrategy salaryStrategy,
    IBonusStrategy bonusStrategy)
    : Employee(name, type, baseSalary, salaryStrategy, bonusStrategy)
{
    public override int AllowedLeavesPerMonth => 1;
}