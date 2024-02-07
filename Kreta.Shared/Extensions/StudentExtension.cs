using Kreta.Shared.Dtos;
using Kreta.Shared.Models.SchoolCitizens;

namespace Kreta.Shared.Extensions
{
    public static class StudentExtension
    {
        public static StudentDto ToDto(this Student student)
        {
            return new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                SchoolYear = student.SchoolYear,
                SchoolClass = student.SchoolClass,
                IsWoomen = student.IsWoomen,
            };
        }

        public static Student ToModel(this StudentDto studentDto)
        {
            return new Student
            {
                Id = studentDto.Id,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                SchoolYear = studentDto.SchoolYear,
                SchoolClass = studentDto.SchoolClass,
                IsWoomen = studentDto.IsWoomen,
            };
        }
    }
}
