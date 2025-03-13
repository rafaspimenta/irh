using Payroll.Domain.Interfaces;

namespace Payroll.Domain.Entities;

public class Company(string name)
{
    public string Name { get; } = name;
    private readonly List<IEmployee> _employees = [];
    public IReadOnlyCollection<IEmployee> Employees => _employees.AsReadOnly();

    public void AddEmployee(IEmployee employee)
    {
        _employees.Add(employee);
    }
}