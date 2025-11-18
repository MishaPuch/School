namespace School.DAL.Model;

public class Classroom
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public string Teacher { get; set; } = null!;
    public List<Student> Students { get; set; } = new();
    public Classroom() { }

    public Classroom(string name, string teacher)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required");
        if (string.IsNullOrWhiteSpace(teacher)) throw new ArgumentException("Teacher required");
        Name = name;
        Teacher = teacher;
    }

    public void AddStudent(Student student)
    {
        if (student == null) throw new ArgumentNullException(nameof(student));
        if (Students.Contains(student)) return;
        Students.Add(student);
        student.AssignToClass(this);
    }

    public void RemoveStudent(Student student)
    {
        if (student == null) throw new ArgumentNullException(nameof(student));
        if (Students.Remove(student))
        {
            student.RemoveFromClass();
        }
    }
}
