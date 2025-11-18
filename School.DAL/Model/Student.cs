namespace School.DAL.Model;

public class Student
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string StudentIdentifier { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }

    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }

    public Guid? ClassroomId { get; set; }
    public Classroom? Classroom { get; set; }

    public Student() { }

    public Student(
        string studentIdentifier,
        string firstName,
        string lastName,
        DateTime dob,
        string? city = null,
        string? street = null,
        string? postalCode = null)
    {
        if (string.IsNullOrWhiteSpace(studentIdentifier))
            throw new ArgumentException("StudentIdentifier required");

        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("FirstName required");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("LastName required");

        StudentIdentifier = studentIdentifier;
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dob;
        City = city;
        Street = street;
        PostalCode = postalCode;
    }

    public void Update(
        string firstName,
        string lastName,
        DateTime dob,
        string? city = null,
        string? street = null,
        string? postalCode = null)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("FirstName required");

        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("LastName required");

        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dob;
        City = city;
        Street = street;
        PostalCode = postalCode;
    }

    internal void AssignToClass(Classroom cls)
    {
        Classroom = cls;
        ClassroomId = cls.Id;
    }

    internal void RemoveFromClass()
    {
        Classroom = null;
        ClassroomId = null;
    }
}
