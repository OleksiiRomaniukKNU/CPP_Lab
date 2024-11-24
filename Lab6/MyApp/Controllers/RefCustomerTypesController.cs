using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

public class RefCustomerTypesController : Controller
{
    private readonly ApplicationDbContext _context;

    public RefCustomerTypesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var customerTypes = _context.RefCustomerTypes.ToList();
        return View(customerTypes);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(RefCustomerType type)
    {
        if (ModelState.IsValid)
        {
            _context.Add(type);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(type);
    }

    public IActionResult Details(int id)
    {
        var customerType = _context.RefCustomerTypes.FirstOrDefault(ct => ct.Id == id);
        if (customerType == null)
        {
            return NotFound();
        }
        return View(customerType);
    }

    public IActionResult Edit(int id)
    {
        var customerType = _context.RefCustomerTypes.FirstOrDefault(ct => ct.Id == id);
        if (customerType == null)
        {
            return NotFound();
        }
        return View(customerType);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, RefCustomerType customerType)
    {
        if (id != customerType.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(customerType);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.RefCustomerTypes.Any(ct => ct.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(customerType);
    }
}
