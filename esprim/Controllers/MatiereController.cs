using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mini.project.Models;

public class MatiereController : Controller
{
    private readonly MyDbContext _context;

    public MatiereController(MyDbContext context)
    {
        _context = context;
    }

    // GET: Matiere/Index
    public async Task<IActionResult> Index()
    {
        var matieres = await _context.Matieres.ToListAsync();
        return View(matieres);
    }

    // POST: Matiere/Create
    [HttpPost]
    public async Task<IActionResult> Create(Matiere matiere)
    {
        if (ModelState.IsValid)
        {
            _context.Add(matiere);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Matiere created successfully!";
            return RedirectToAction(nameof(Index));
        }
        TempData["ErrorMessage"] = "Error creating Matiere.";
        return View(matiere);
    }

    // POST: Matiere/Edit
    [HttpPost]
    public async Task<IActionResult> Edit(Matiere matiere)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(matiere);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Matiere updated successfully!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Matieres.Any(e => e.CodeMatiere == matiere.CodeMatiere))
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
        TempData["ErrorMessage"] = "Error updating Matiere.";
        return View(matiere);
    }

    // POST: Matiere/Delete
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var matiere = await _context.Matieres.FindAsync(id);
        if (matiere != null)
        {
            _context.Matieres.Remove(matiere);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Matiere deleted successfully!";
        }
        else
        {
            TempData["ErrorMessage"] = "Matiere not found.";
        }
        return RedirectToAction(nameof(Index));
    }
}
