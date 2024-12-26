using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mini.project.Models;

public class EtudiantController : Controller
{
    private readonly MyDbContext _context;

    public EtudiantController(MyDbContext context)
    {
        _context = context;
    }

    // GET: Etudiant/Index
    public async Task<IActionResult> Index()
    {
        var etudiants = await _context.Etudiants
                                      .Include(e => e.Classe)
                                      .ToListAsync();

        ViewData["ClasseList"] = new SelectList(_context.Classes, "CodeClasse", "NomClasse");
        return View(etudiants);
    }

    // GET: Etudiant/Create
    public IActionResult Create()
    {
        ViewData["ClasseList"] = new SelectList(_context.Classes, "CodeClasse", "NomClasse");
        return View();
    }

    // POST: Etudiant/Create
    [HttpPost]
    public async Task<IActionResult> Create(Etudiant etudiant)
    {
        if (ModelState.IsValid)
        {
            _context.Add(etudiant);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Etudiant created successfully!";
            return RedirectToAction(nameof(Index));
        }

        TempData["ErrorMessage"] = "Error creating Etudiant.";
        ViewData["ClasseList"] = new SelectList(_context.Classes, "CodeClasse", "NomClasse", etudiant.CodeClasse);
        return View(etudiant);
    }

    // POST: Etudiant/Edit
    [HttpPost]
    public async Task<IActionResult> Edit(Etudiant etudiant)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(etudiant);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Etudiant updated successfully!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Etudiants.Any(e => e.CodeEtudiant == etudiant.CodeEtudiant))
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

        TempData["ErrorMessage"] = "Error updating Etudiant.";
        ViewData["ClasseList"] = new SelectList(_context.Classes, "CodeClasse", "NomClasse", etudiant.CodeClasse);
        return View(etudiant);
    }

    // POST: Etudiant/Delete
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var etudiant = await _context.Etudiants.FindAsync(id);
        if (etudiant != null)
        {
            _context.Etudiants.Remove(etudiant);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Etudiant deleted successfully!";
        }
        else
        {
            TempData["ErrorMessage"] = "Etudiant not found.";
        }
        return RedirectToAction(nameof(Index));
    }
}
