using Microsoft.AspNetCore.Mvc;
using studentregistry.Models;
using studentregistry.Services;

namespace studentregistry.Controllers;

public class StudentsController : Controller
{
    // GET: /Students
    public IActionResult Index(string? search)
    {
        var students = StudentStore.GetAll();

        if (!string.IsNullOrWhiteSpace(search))
        {
            var term = search.Trim();
            students = students
                .Where(s => s.Name.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                            s.Email.Contains(term, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        ViewData["Search"] = search;
        return View(students);
    }

    // GET: /Students/Create
    public IActionResult Create()
    {
        return View(new Student());
    }

    // POST: /Students/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student student)
    {
        if (!string.IsNullOrWhiteSpace(student.Email) && StudentStore.EmailExists(student.Email.Trim()))
        {
            ModelState.AddModelError(nameof(Student.Email), "Υπάρχει ήδη μαθητής με αυτό το email.");
        }

        if (!ModelState.IsValid)
        {
            return View(student);
        }

        StudentStore.Add(student);
        TempData["Message"] = $"Ο μαθητής «{student.Name}» προστέθηκε.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Students/Edit/5
    public IActionResult Edit(int id)
    {
        var student = StudentStore.GetById(id);
        if (student is null) return NotFound();

        var copy = new Student { Id = student.Id, Name = student.Name, Age = student.Age, Email = student.Email };
        return View(copy);
    }

    // POST: /Students/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Student student)
    {
        if (id != student.Id) return BadRequest();

        if (!string.IsNullOrWhiteSpace(student.Email) && StudentStore.EmailExists(student.Email.Trim(), student.Id))
        {
            ModelState.AddModelError(nameof(Student.Email), "Υπάρχει ήδη μαθητής με αυτό το email.");
        }

        if (!ModelState.IsValid)
        {
            return View(student);
        }

        if (!StudentStore.Update(student)) return NotFound();

        TempData["Message"] = $"Τα στοιχεία του μαθητή «{student.Name}» αποθηκεύτηκαν.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Students/Delete/5
    public IActionResult Delete(int id)
    {
        var student = StudentStore.GetById(id);
        if (student is null) return NotFound();
        return View(student);
    }

    // POST: /Students/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var student = StudentStore.GetById(id);
        if (student is null) return NotFound();

        StudentStore.Delete(id);
        TempData["Message"] = $"Ο μαθητής «{student.Name}» διαγράφηκε.";
        return RedirectToAction(nameof(Index));
    }
}
