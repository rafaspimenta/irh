namespace Payroll.Domain.Entities;

public class Leave(IEnumerable<DateOnly> requestedDays)
{
    public IReadOnlyCollection<DateOnly> RequestedDays { get; } = new List<DateOnly>(requestedDays).AsReadOnly();
}