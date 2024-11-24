using Microsoft.AspNetCore.Mvc;
using MyApp.Data;
using MyApp.Models;


public class AddCustomerController : Controller
{
    private readonly ApplicationDbContext _context;

    public AddCustomerController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Address,PhoneNumber")] Customer customer)
    {
        if (ModelState.IsValid)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(customer);
    }
}
