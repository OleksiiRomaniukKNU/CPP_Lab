using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

public class CustomersController : Controller
{
    private readonly ApplicationDbContext _context;

    public CustomersController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var customers = _context.Customers.ToList();
        return View(customers);
    }

    public IActionResult Create()
    {
        ViewBag.CustomerTypes = _context.RefCustomerTypes.ToList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Customer customer)
    {
        if (ModelState.IsValid)
        {
            _context.Add(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.CustomerTypes = _context.RefCustomerTypes.ToList();
        return View(customer);
    }

    public IActionResult Details(int id)
    {
        var customer = _context.Customers.Include(c => c.RefCustomerType)
                                          .FirstOrDefault(c => c.Id == id);
        if (customer == null)
        {
            return NotFound();
        }
        return View(customer);
    }

    public IActionResult Edit(int id)
    {
        var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
        if (customer == null)
        {
            return NotFound();
        }
        ViewBag.CustomerTypes = _context.RefCustomerTypes.ToList();
        return View(customer);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Customer customer)
    {
        if (id != customer.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(customer);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Customers.Any(c => c.Id == id))
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
        ViewBag.CustomerTypes = _context.RefCustomerTypes.ToList();
        return View(customer);
    }
}
