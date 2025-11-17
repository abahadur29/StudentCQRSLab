using StudentCQRSLab.Models;

namespace StudentCQRSLab.Data
{
    public class StudentStore
    {
        private static readonly List<Student> _students = new()
        {
            new Student { Id = 1, Name = "Aditya Bahadur", Email = "adityabahadur294@gmail.com", Age = 21 },
            new Student { Id = 2, Name = "Aditi Bahadur", Email = "aditibahadur09@gmail.com", Age = 22 },
            new Student { Id = 3, Name = "Priya Sharma", Email = "priya.sharma@example.com", Age = 25 },
            new Student { Id = 4, Name = "Vikram Singh", Email = "vikram.s@example.com", Age = 30 }
        };

        public List<Student> GetAll() => _students;

        public Student? GetById(int id) => _students.FirstOrDefault(s => s.Id == id);

        public void Add(Student student)
        {
            student.Id = _students.Max(s => s.Id) + 1;
            _students.Add(student);
        }

        public void Update(Student updatedStudent)
        {
            var existing = GetById(updatedStudent.Id);
            if (existing != null)
            {
                existing.Name = updatedStudent.Name;
                existing.Email = updatedStudent.Email;
                existing.Age = updatedStudent.Age;
            }
        }

        public bool Delete(int id)
        {
            var student = GetById(id);
            if (student != null)
            {
                _students.Remove(student);
                return true;
            }
            return false;
        }
    }
}