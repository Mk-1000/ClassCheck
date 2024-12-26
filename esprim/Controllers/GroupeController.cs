using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mini.project.Models;

public class GroupeController : Controller
{
    private readonly MyDbContext _context;

    public GroupeController(MyDbContext context)
    {
        _context = context;
    }

    // GET: Groupe/Index
    public async Task<IActionResult> Index()
    {
        var groupes = await _context.Groupes.ToListAsync();
        return View(groupes);
    }

    // POST: Groupe/Create
    [HttpPost]
    public async Task<IActionResult> Create(Groupe groupe)
    {
        if (ModelState.IsValid)
        {
            _context.Add(groupe);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Groupe created successfully!";
            return RedirectToAction(nameof(Index));
        }
        TempData["ErrorMessage"] = "Error creating Groupe.";
        return View(groupe);
    }

    // POST: Groupe/Edit
    [HttpPost]
    public async Task<IActionResult> Edit(Groupe groupe)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(groupe);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Groupe updated successfully!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Groupes.Any(e => e.CodeGroupe == groupe.CodeGroupe))
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
        TempData["ErrorMessage"] = "Error updating Groupe.";
        return View(groupe);
    }

    // POST: Groupe/Delete
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var groupe = await _context.Groupes.FindAsync(id);
        if (groupe != null)
        {
            _context.Groupes.Remove(groupe);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Groupe deleted successfully!";
        }
        else
        {
            TempData["ErrorMessage"] = "Groupe not found.";
        }
        return RedirectToAction(nameof(Index));
    }
}
