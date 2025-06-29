using DataBaseFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseFirst;

internal class Program
{
    static void Main(string[] args)
    {
        using SessionContext context = new SessionContext();
        context.Employees
            .Include(e => e.Department)
            .Include(e => e.Manager)
            .ToList()
            .ForEach(e =>
            {
                Console.WriteLine($"Employee: {e.Name}, Department: {e.Department?.Name}, Manager: {e.Manager?.Name}");
            });
    }
}
