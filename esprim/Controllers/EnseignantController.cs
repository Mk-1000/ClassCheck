using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mini.project.Models;

public class EnseignantController : Controller
{
    private readonly MyDbContext _context;

    public EnseignantController(MyDbContext context)
    {
        _context = context;
    }

    // GET: Enseignant/Index
    public async Task<IActionResult> Index()
    {
        var enseignants = await _context.Enseignants
                                        .Include(e => e.Departement)
                                        .Include(e => e.Grade)
                                        .ToListAsync();

        ViewData["DepartementList"] = new SelectList(_context.Departements, "CodeDepartement", "NomDepartement");
        ViewData["GradeList"] = new SelectList(_context.Grades, "CodeGrade", "NomGrade");
        return View(enseignants);
    }

    // GET: Enseignant/Create
    public IActionResult Create()
    {
        ViewData["DepartementList"] = new SelectList(_context.Departements, "CodeDepartement", "NomDepartement");
        ViewData["GradeList"] = new SelectList(_context.Grades, "CodeGrade", "NomGrade");
        return View();
    }

    // POST: Enseignant/Create
    [HttpPost]
    public async Task<IActionResult> Create(Enseignant enseignant)
    {
        if (ModelState.IsValid)
        {
            _context.Add(enseignant);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Enseignant created successfully!";
            return RedirectToAction(nameof(Index));
        }

        TempData["ErrorMessage"] = "Error creating Enseignant.";
        ViewData["DepartementList"] = new SelectList(_context.Departements, "CodeDepartement", "NomDepartement", enseignant.CodeDepartement);
        ViewData["GradeList"] = new SelectList(_context.Grades, "CodeGrade", "NomGrade", enseignant.CodeGrade);
        return View(enseignant);
    }

    // POST: Enseignant/Edit
    [HttpPost]
    public async Task<IActionResult> Edit(Enseignant enseignant)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(enseignant);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Enseignant updated successfully!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Enseignants.Any(e => e.CodeEnseignant == enseignant.CodeEnseignant))
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

        TempData["ErrorMessage"] = "Error updating Enseignant.";
        ViewData["DepartementList"] = new SelectList(_context.Departements, "CodeDepartement", "NomDepartement", enseignant.CodeDepartement);
        ViewData["GradeList"] = new SelectList(_context.Grades, "CodeGrade", "NomGrade", enseignant.CodeGrade);
        return View(enseignant);
    }

    // POST: Enseignant/Delete
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var enseignant = await _context.Enseignants.FindAsync(id);
        if (enseignant != null)
        {
            _context.Enseignants.Remove(enseignant);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Enseignant deleted successfully!";
        }
        else
        {
            TempData["ErrorMessage"] = "Enseignant not found.";
        }
        return RedirectToAction(nameof(Index));
    }
}
