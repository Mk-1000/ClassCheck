using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mini.project.Models;

public class DashboardController : Controller
{
    private readonly MyDbContext _context;

    public DashboardController(MyDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10, string studentName = "", string className = "", DateTime? startDate = null, DateTime? endDate = null)
    {
        var totalStudents = await _context.Etudiants.CountAsync();
        var totalProfessors = await _context.Enseignants.CountAsync();
        var totalClasses = await _context.Classes.CountAsync();
        var totalDepartments = await _context.Departements.CountAsync();

        var absenceQuery = _context.FichesAbsence.AsQueryable();

        if (!string.IsNullOrEmpty(studentName))
        {
            var trimmedStudentName = studentName.Trim().ToLower();

            var absenceRecordsWithStudentName = await _context.LignesFicheAbsence
                .Where(l => (l.Etudiant.Nom + " " + l.Etudiant.Prenom).ToLower().Contains(trimmedStudentName))
                .Select(l => l.CodeFicheAbsenceSeance)
                .Distinct()
                .ToListAsync();
            absenceQuery = absenceQuery.Where(a => absenceRecordsWithStudentName.Contains(a.CodeFicheAbsence));
        }

        if (!string.IsNullOrEmpty(className))
        {
            absenceQuery = absenceQuery.Where(a => a.Classe.NomClasse.Contains(className));
        }

        // Apply date filtering if provided
        if (startDate.HasValue)
        {
            absenceQuery = absenceQuery.Where(a => a.DateJour >= startDate.Value);
        }

        if (endDate.HasValue)
        {
            absenceQuery = absenceQuery.Where(a => a.DateJour <= endDate.Value);
        }

        var totalAbsenceRecords = await absenceQuery.CountAsync();

        var absenceRecords = await absenceQuery
            .OrderByDescending(a => a.DateJour)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .Select(a => new AbsenceRecordViewModel
            {
                StudentNames = _context.LignesFicheAbsence
                    .Where(l => l.CodeFicheAbsenceSeance == a.CodeFicheAbsence && l.IsAbsent &&
                               (l.Etudiant.Nom + " " + l.Etudiant.Prenom).ToLower().Contains(studentName.Trim().ToLower()))
                    .Select(l => $"{l.Etudiant.Nom} {l.Etudiant.Prenom}")
                    .ToList(),
                ClassName = a.Classe.NomClasse,
                Date = a.DateJour,
                Seance = _context.FichesAbsenceSeances
                    .Where(f => f.CodeFicheAbsence == a.CodeFicheAbsence)
                    .Select(f => f.Seance.NomSeance)
                    .FirstOrDefault(),
                IsExcused = a.FichesAbsenceSeances.Any() ? a.FichesAbsenceSeances.First().LignesFicheAbsence.Any(l => l.IsAbsent) : false
            }).ToListAsync();

        var model = new Dashboard
        {
            TotalStudents = totalStudents,
            TotalProfessors = totalProfessors,
            TotalClasses = totalClasses,
            TotalDepartments = totalDepartments,
            RecentAbsenceRecords = absenceRecords,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalPages = (int)Math.Ceiling(totalAbsenceRecords / (double)pageSize)
        };

        ViewData["ActivePage"] = "Dashboard";
        return View(model);
    }



}
