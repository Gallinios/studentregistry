using studentregistry.Models;

namespace studentregistry.Services;

/// <summary>
/// Απλή αποθήκευση μαθητών στη μνήμη.
/// Τα δεδομένα χάνονται όταν σταματήσει η εφαρμογή.
/// </summary>
public static class StudentStore
{
    private static readonly object _lock = new();

    private static readonly List<Student> _students = new()
    {
        new Student { Id = 1, Name = "Nikos", Age = 22, Email = "nikos@test.gr" },
        new Student { Id = 2, Name = "Maria", Age = 24, Email = "maria@test.gr" }
    };

    private static int _nextId = 3;

    public static List<Student> GetAll()
    {
        lock (_lock)
        {
            return _students.OrderBy(s => s.Id).ToList();
        }
    }

    public static Student? GetById(int id)
    {
        lock (_lock)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }
    }

    public static bool EmailExists(string email, int? exceptId = null)
    {
        lock (_lock)
        {
            return _students.Any(s =>
                s.Id != exceptId &&
                string.Equals(s.Email, email, StringComparison.OrdinalIgnoreCase));
        }
    }

    public static void Add(Student student)
    {
        lock (_lock)
        {
            student.Id = _nextId++;
            student.Name = student.Name.Trim();
            student.Email = student.Email.Trim();
            _students.Add(student);
        }
    }

    public static bool Update(Student student)
    {
        lock (_lock)
        {
            var existing = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existing is null) return false;

            existing.Name = student.Name.Trim();
            existing.Age = student.Age;
            existing.Email = student.Email.Trim();
            return true;
        }
    }

    public static bool Delete(int id)
    {
        lock (_lock)
        {
            return _students.RemoveAll(s => s.Id == id) > 0;
        }
    }
}
