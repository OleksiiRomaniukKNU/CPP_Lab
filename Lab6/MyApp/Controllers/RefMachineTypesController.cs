using Microsoft.AspNetCore.Mvc;
using MyApp.Models;

public class RefMachineTypesController : Controller
{
    private readonly ApplicationDbContext _context;

    public RefMachineTypesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var machineTypes = _context.RefMachineTypes.ToList();
        return View(machineTypes);
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(RefMachineType machineType)
    {
        if (ModelState.IsValid)
        {
            _context.Add(machineType);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(machineType);
    }

    public IActionResult Details(int id)
    {
        var machineType = _context.RefMachineTypes.FirstOrDefault(mt => mt.Id == id);
        if (machineType == null)
        {
            return NotFound();
        }
        return View(machineType);
    }
    public IActionResult Edit(int id)
    {
        var machineType = _context.RefMachineTypes.FirstOrDefault(mt => mt.Id == id);
        if (machineType == null)
        {
            return NotFound();
        }
        return View(machineType);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, RefMachineType machineType)
    {
        if (id != machineType.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(machineType);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.RefMachineTypes.Any(mt => mt.Id == id))
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
        return View(machineType);
    }
}
