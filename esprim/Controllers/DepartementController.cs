using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mini.project.Models;

public class DepartementController : Controller
{
    private readonly MyDbContext _context;

    public DepartementController(MyDbContext context)
    {
        _context = context;
    }

    // GET: Departement/Index
    public async Task<IActionResult> Index()
    {
        var departements = await _context.Departements.ToListAsync();
        return View(departements);
    }

    // POST: Departement/Create
    [HttpPost]
    public async Task<IActionResult> Create(Departement departement)
    {
        if (ModelState.IsValid)
        {
            _context.Add(departement);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Departement created successfully!";
            return RedirectToAction(nameof(Index));
        }
        TempData["ErrorMessage"] = "Error creating Departement.";
        return View(departement);
    }

    // POST: Departement/Edit
    [HttpPost]
    public async Task<IActionResult> Edit(Departement departement)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(departement);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Departement updated successfully!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Departements.Any(e => e.CodeDepartement == departement.CodeDepartement))
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
        TempData["ErrorMessage"] = "Error updating Departement.";
        return View(departement);
    }

    // POST: Departement/Delete
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var departement = await _context.Departements.FindAsync(id);
        if (departement != null)
        {
            _context.Departements.Remove(departement);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Departement deleted successfully!";
        }
        else
        {
            TempData["ErrorMessage"] = "Departement not found.";
        }
        return RedirectToAction(nameof(Index));
    }
}
