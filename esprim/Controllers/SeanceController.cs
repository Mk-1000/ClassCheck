using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mini.project.Models;

public class SeanceController : Controller
{
    private readonly MyDbContext _context;

    public SeanceController(MyDbContext context)
    {
        _context = context;
    }

    // GET: Seance/Index
    public async Task<IActionResult> Index()
    {
        var seances = await _context.Seances.ToListAsync();
        return View(seances);
    }

    // POST: Seance/Create
    [HttpPost]
    public async Task<IActionResult> Create(Seance seance)
    {
        if (ModelState.IsValid)
        {
            _context.Add(seance);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Seance created successfully!";
            return RedirectToAction(nameof(Index));
        }
        TempData["ErrorMessage"] = "Error creating Seance.";
        return View(seance);
    }

    // POST: Seance/Edit
    [HttpPost]
    public async Task<IActionResult> Edit(Seance seance)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(seance);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Seance updated successfully!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Seances.Any(e => e.CodeSeance == seance.CodeSeance))
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
        TempData["ErrorMessage"] = "Error updating Seance.";
        return View(seance);
    }

    // POST: Seance/Delete
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var seance = await _context.Seances.FindAsync(id);
        if (seance != null)
        {
            _context.Seances.Remove(seance);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Seance deleted successfully!";
        }
        else
        {
            TempData["ErrorMessage"] = "Seance not found.";
        }
        return RedirectToAction(nameof(Index));
    }
}
