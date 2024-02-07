namespace Kreta.Shared.Models.SchoolCitizens
{
    public class Student : IDbEntity<Student>
    {

        public Student()
        {
            Id = Guid.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            SchoolYear = 9;
            SchoolClass = SchoolClassType.ClassA;
            IsWoomen = false;
        }

        public Student(Guid id, string firstName, string lastName, int schoolYear, SchoolClassType schoolClass, bool isWoomen)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            SchoolYear = schoolYear;
            SchoolClass = schoolClass;
            IsWoomen = isWoomen;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SchoolYear { get; set; }
        public SchoolClassType SchoolClass { get; set; }
        public bool IsWoomen { get; set; }

        public bool HasId => Id != Guid.Empty;

        public override string ToString()
        {
            return $"{LastName} {FirstName} ({SchoolYear}.{SchoolClass}";
        }
    }
}
