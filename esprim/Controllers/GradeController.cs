using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mini.project.Models;

public class GradeController : Controller
{
    private readonly MyDbContext _context;

    public GradeController(MyDbContext context)
    {
        _context = context;
    }

    // GET: Grade/Index
    public async Task<IActionResult> Index()
    {
        var grades = await _context.Grades.ToListAsync();
        return View(grades);
    }

    // POST: Grade/Create
    [HttpPost]
    public async Task<IActionResult> Create(Grade grade)
    {
        if (ModelState.IsValid)
        {
            _context.Add(grade);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Grade created successfully!";
            return RedirectToAction(nameof(Index));
        }
        TempData["ErrorMessage"] = "Error creating Grade.";
        return View(grade);
    }

    // POST: Grade/Edit
    [HttpPost]
    public async Task<IActionResult> Edit(Grade grade)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(grade);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Grade updated successfully!";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Grades.Any(e => e.CodeGrade == grade.CodeGrade))
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
        TempData["ErrorMessage"] = "Error updating Grade.";
        return View(grade);
    }

    // POST: Grade/Delete
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var grade = await _context.Grades.FindAsync(id);
        if (grade != null)
        {
            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Grade deleted successfully!";
        }
        else
        {
            TempData["ErrorMessage"] = "Grade not found.";
        }
        return RedirectToAction(nameof(Index));
    }
}
