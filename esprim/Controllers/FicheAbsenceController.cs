using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mini.project.Models;

public class FicheAbsenceController : Controller
{
    private readonly MyDbContext _context;

    public FicheAbsenceController(MyDbContext context)
    {
        _context = context;
    }

    // GET: FicheAbsence/Index
    public async Task<IActionResult> Index()
    {
        var fichesAbsence = await _context.FichesAbsence
            .AsNoTracking()
            .Include(f => f.Matiere)
            .Include(f => f.Enseignant)
            .Include(f => f.Classe)
            .Include(f => f.FichesAbsenceSeances)
                .ThenInclude(fs => fs.Seance)
            .Include(f => f.FichesAbsenceSeances)
                .ThenInclude(fs => fs.LignesFicheAbsence)
                    .ThenInclude(lfa => lfa.Etudiant)
            .ToListAsync();

        ViewData["MatiereList"] = new SelectList(await _context.Matieres.ToListAsync(), "CodeMatiere", "NomMatiere");
        ViewData["EnseignantList"] = new SelectList(await _context.Enseignants.ToListAsync(), "CodeEnseignant", "Nom");
        ViewData["ClasseList"] = new SelectList(await _context.Classes.ToListAsync(), "CodeClasse", "NomClasse");
        ViewData["SeanceList"] = new SelectList(await _context.Seances.ToListAsync(), "CodeSeance", "NomSeance");
        ViewData["StudentList"] = new SelectList(await _context.Etudiants.ToListAsync(), "CodeEtudiant", "Nom");

        return View(fichesAbsence);
    }

    // POST: FicheAbsence/Create
    [HttpPost]
    public async Task<IActionResult> Create(FicheAbsence ficheAbsence)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Add(ficheAbsence);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "FicheAbsence created successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                TempData["ErrorMessage"] = $"Error creating FicheAbsence: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
        TempData["ErrorMessage"] = "Invalid data. Please try again.";
        return RedirectToAction(nameof(Index));
    }

    // POST: FicheAbsence/AddSeance
    [HttpPost]
    public async Task<IActionResult> AddSeance(int CodeFicheAbsence, int CodeSeance)
    {
        try
        {
            var ficheAbsence = await _context.FichesAbsence.FindAsync(CodeFicheAbsence);
            if (ficheAbsence == null)
            {
                TempData["ErrorMessage"] = "FicheAbsence not found.";
                return RedirectToAction(nameof(Index));
            }

            var ficheAbsenceSeance = new FicheAbsenceSeance
            {
                CodeFicheAbsence = CodeFicheAbsence,
                CodeSeance = CodeSeance
            };

            _context.FichesAbsenceSeances.Add(ficheAbsenceSeance);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Seance added successfully!";
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error adding Seance: {ex.Message}";
            return RedirectToAction(nameof(Index));
        }
    }

    // POST: FicheAbsence/AssignStudents
    [HttpPost]
    public async Task<IActionResult> AssignStudents(int CodeFicheAbsenceSeance, List<int> CodeEtudiants)
    {
        if (CodeEtudiants == null || CodeEtudiants.Count == 0)
        {
            TempData["ErrorMessage"] = "No students selected.";
            return RedirectToAction(nameof(Index));
        }

        var ficheAbsenceSeance = await _context.FichesAbsenceSeances
        .FirstOrDefaultAsync(fas => fas.CodeFicheAbsenceSeance == CodeFicheAbsenceSeance);

        if (ficheAbsenceSeance == null)
        {
            TempData["ErrorMessage"] = "The session does not exist.";
            return RedirectToAction(nameof(Index));
        }


        try
        {
            foreach (var codeEtudiant in CodeEtudiants)
            {
                var ligneFicheAbsence = new LigneFicheAbsence
                {
                    CodeFicheAbsenceSeance = CodeFicheAbsenceSeance,
                    CodeEtudiant = codeEtudiant,
                    IsAbsent = true // Mark as absent
                };

                _context.LignesFicheAbsence.Add(ligneFicheAbsence);
            }

            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Students marked as absent successfully!";
        }
        catch (Exception ex)
        {
            TempData["ErrorMessage"] = $"Error assigning students: {ex.Message}";
        }

        return RedirectToAction(nameof(Index));
    }

    // POST: FicheAbsence/Delete
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var ficheAbsence = await _context.FichesAbsence.FindAsync(id);
            if (ficheAbsence == null)
            {
                TempData["ErrorMessage"] = "FicheAbsence not found.";
                return RedirectToAction(nameof(Index));
            }

            _context.FichesAbsence.Remove(ficheAbsence);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "FicheAbsence deleted successfully!";
        }
        catch (DbUpdateException ex)
        {
            TempData["ErrorMessage"] = $"Error deleting FicheAbsence: {ex.Message}";
        }

        return RedirectToAction(nameof(Index));
    }
}