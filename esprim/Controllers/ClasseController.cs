using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mini.project.Models;

public class ClasseController : Controller
{
    private readonly MyDbContext _context;

    public ClasseController(MyDbContext context)
    {
        _context = context;
    }

    // GET: Classe/Index
    public async Task<IActionResult> Index()
    {
        var classes = await _context.Classes
                                    .Include(c => c.Groupe)
                                    .Include(c => c.Departement)
                                    .ToListAsync();

        // Ensure ViewData is populated before returning the view
        ViewData["GroupeList"] = new SelectList(_context.Groupes, "CodeGroupe", "NomGroupe");
        ViewData["DepartementList"] = new SelectList(_context.Departements, "CodeDepartement", "NomDepartement");

        return View(classes);
    }

    // GET: Classe/Create
    public IActionResult Create()
    {
        // Populate Groupe and Departement lists
        ViewData["GroupeList"] = new SelectList(_context.Groupes, "CodeGroupe", "NomGroupe");
        ViewData["DepartementList"] = new SelectList(_context.Departements, "CodeDepartement", "NomDepartement");
        return View();
    }

    // POST: Classe/Create
    [HttpPost]
    public async Task<IActionResult> Create(Classe classe)
    {
        if (ModelState.IsValid)
        {
            _context.Add(classe);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Classe created successfully!";
            return RedirectToAction(nameof(Index));
        }
        TempData["ErrorMessage"] = "Error creating Classe.";

        // Re-populate the lists if there's an error
        ViewData["GroupeList"] = new SelectList(_context.Groupes, "CodeGroupe", "NomGroupe", classe.CodeGroupe);
        ViewData["DepartementList"] = new SelectList(_context.Departements, "CodeDepartement", "NomDepartement", classe.CodeDepartement);
        return View(classe);
    }

    // POST: Classe/Edit
    [HttpPost]
    public async Task<IActionResult> Edit(Classe classe)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(classe);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Classe updated successfully!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Classes.Any(e => e.CodeClasse == classe.CodeClasse))
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
        TempData["ErrorMessage"] = "Error updating Classe.";

        // Re-populate the lists if there's an error
        ViewData["GroupeList"] = new SelectList(_context.Groupes, "CodeGroupe", "NomGroupe", classe.CodeGroupe);
        ViewData["DepartementList"] = new SelectList(_context.Departements, "CodeDepartement", "NomDepartement", classe.CodeDepartement);
        return View(classe);
    }

    // POST: Classe/Delete
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var classe = await _context.Classes.FindAsync(id);
        if (classe != null)
        {
            _context.Classes.Remove(classe);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Classe deleted successfully!";
        }
        else
        {
            TempData["ErrorMessage"] = "Classe not found.";
        }
        return RedirectToAction(nameof(Index));
    }
}
