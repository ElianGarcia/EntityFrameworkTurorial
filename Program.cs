using EntityFrameworkExamples.DAL;
using EntityFrameworkExamples.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFrameworkExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context  = new SchoolContext())
            {
                //Ejercicio 1
                var std = new Student()
                {
                    Name = "Elian Garcia"
                };

                context.Students.Add(std);
                if (context.SaveChanges() > 0)
                    Console.WriteLine("Guardado");

                //Ejercicio 2
                var studentsWithSameName = context.Students
                                      .Where(s => s.Name == "Elian Garcia")
                                      .ToList();
                Console.WriteLine("Estudiantes con el mismo nombre: " + studentsWithSameName.Count);

                var studentWithGrade = context.Students
                        .Where(s => s.Name == "Elian Garcia")
                        .Include("Grade")
                        .FirstOrDefault();

                var std1 = new Student() { Name = "Bill" };

                var std2 = new Student() { Name = "Steve" };

                var computer = new Course() { CourseName = "Computer Science" };

                var entityList = new List<Object>() {
                    std1,
                    std2,
                    computer
                };

                using (var context = new SchoolContext())
                {
                    context.AddRange(entityList);

                    // or 
                    // context.AddRange(std1, std2, computer);

                    context.SaveChanges();
                }

                // Disconnected Student entity
                var stud = new Student() { StudentId = 1, Name = "Bill" };

                stud.Name = "Steve";

                using (var context = new SchoolContext())
                {
                    context.Update<Student>(stud);

                    // or the followings are also valid
                    // context.Students.Update(stud);
                    // context.Attach<Student>(stud).State = EntityState.Modified;
                    // context.Entry<Student>(stud).State = EntityState.Modified; 

                    context.SaveChanges();
                }
            }

            public static void Main()
            {
                var newStudent = new Student()
                {
                    Name = "Bill"
                };

                var modifiedStudent = new Student()
                {
                    StudentId = 1,
                    Name = "Steve"
                };

                using (var context = new SchoolContext())
                {
                    context.Update<Student>(newStudent);
                    context.Update<Student>(modifiedStudent);

                    DisplayStates(context.ChangeTracker.Entries());
                }
            }
            private static void DisplayStates(IEnumerable<EntityEntry> entries)
            {
                foreach (var entry in entries)
                {
                    Console.WriteLine($"Entity: {entry.Entity.GetType().Name},
            
                             State: { entry.State.ToString()}
                    ");
                }
            }
        }
    }
}
