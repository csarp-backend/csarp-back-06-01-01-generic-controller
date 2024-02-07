using Kreta.Shared.Models.SchoolCitizens;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

namespace Kreta.Backend.Context
{
    public static class ModelBuilderExtension
    {
        // Students
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //Students
            List<Student> students = new List<Student>
            {
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="János",
                    LastName="Jegy",
                    SchoolYear=9,
                    SchoolClass = SchoolClassType.ClassA,
                },
                new Student
                {
                    Id=Guid.NewGuid(),
                    FirstName="Szonja",
                    LastName="Stréber",
                    SchoolYear=10,
                    SchoolClass = SchoolClassType.ClassB,
                }
            };            
            modelBuilder.Entity<Student>().HasData(students);
            //Grades
            List<Grade> grades = new List<Grade>
            {
                new Grade
                {
                    Id=Guid.NewGuid(),
                    GradeText="jeles",
                    GradeValue=5,
                    TimeOfGrade=DateTime.Now,
                    TypeOfGrade="röpdolgozat",
                },
                new Grade
                {
                    Id=Guid.NewGuid(),
                    GradeText="elégséges",
                    GradeValue=2,
                    TimeOfGrade=DateTime.Now,
                    TypeOfGrade="felmérő",
                }
            };
            modelBuilder.Entity<Grade>().HasData(grades);
            // Parent
            List<Parent> parents = new List<Parent> 
            {
                new Parent
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Attila",
                    LastName="Fejes",
                    IsWoman=false,
                    Address="6726 Szeged, Fő fasor 16-20"
                },
                new Parent{
                    Id = Guid.NewGuid(),
                    FirstName = "Éva",
                    LastName="Kis",
                    IsWoman=true,
                    Address="6720 Szeged, Zrínyi u. 4-8"
                },

            };
            modelBuilder.Entity<Parent>().HasData(parents);
            //Subjects
            List<Subject> subjects = new List<Subject>
            {
                new Subject
                {
                    Id=Guid.NewGuid(),
                    SubjectName="Történelem",
                    OptionalExaminationSubject=false,
                    CompulsoryExaminationSubject=true

                },
                new Subject
                {
                    Id=Guid.NewGuid(),
                    SubjectName="Földrajz",
                    OptionalExaminationSubject=true,
                    CompulsoryExaminationSubject=false
                },
            };
            modelBuilder.Entity<Subject>().HasData(subjects);
            // Teacher
            List<Teacher> teachers = new List<Teacher>
            {
                new Teacher
                {
                    Id=Guid.NewGuid(),
                    FirstName="Angyal",
                    LastName="Andalgó",
                    IsWoman=true,
                    IsHeadTeacher=true,                    
                },
                new Teacher
                {
                    Id=Guid.NewGuid(),
                    FirstName="Marcel",
                    LastName="Matek",
                    IsWoman=false,
                    IsHeadTeacher=false,
                },
            };
            modelBuilder.Entity<Teacher>().HasData(teachers);

        }
    }
}
