using Microsoft.AspNetCore.Mvc;
using MyApp.Models;
using System.Linq;

public class SearchController : Controller
{
    private readonly ApplicationDbContext _context;

    public SearchController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(string searchTerm, DateTime? startDate, DateTime? endDate, string[] selectedItems)
    {
        var query = _context.Customers.AsQueryable();

        if (startDate.HasValue)
        {
            query = query.Where(c => c.CreatedDate >= startDate);
        }
        if (endDate.HasValue)
        {
            query = query.Where(c => c.CreatedDate <= endDate);
        }

        if (selectedItems != null && selectedItems.Any())
        {
            query = query.Where(c => selectedItems.Contains(c.RefCustomerType.Name));
        }

        var result = query.ToList();
        return View(result);
    }
}
