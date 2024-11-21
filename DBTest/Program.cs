using System;
using System.Data.Entity.Validation;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GestAca.Entities;
using GestAca.Persistence;
using System.Net;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace DBTest
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                new Program();
            }
            catch (Exception e)
            {
                printError(e);
            }
            Console.WriteLine("\nPulse una tecla para salir");
            Console.ReadLine();
        }

        static void printError(Exception e)
        {
            while (e != null)
            {
                if (e is DbEntityValidationException)
                {
                    DbEntityValidationException dbe = (DbEntityValidationException)e;

                    foreach (var eve in dbe.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
                e = e.InnerException;
            }
        }


        Program()
        {
            IDAL dal = new EntityFrameworkDAL(new GestAcaDbContext());

            CreateSampleDB(dal);
            PrintSampleDB(dal);
        }


        private void CreateSampleDB(IDAL dal)
        {
            dal.RemoveAllData();

            Console.WriteLine("CREANDO LOS DATOS Y ALMACENANDOLOS EN LA BD");
            Console.WriteLine("===========================================");

            Console.WriteLine("\n// CREACIÓN DE CURSOS");
            //public Course(string descr, string name)
            Course aCourse1 = new Course("Curso Introductorio Ingenieria Software", "Software Engineering");
            dal.Insert<Course>(aCourse1);
            dal.Commit();
            Course aCourse2 = new Course("Curso Introductorio de Estructuras de datos", "Data Structures");
            dal.Insert<Course>(aCourse2);
            dal.Commit();

            // Populate here the rest of the database
            // Add missing code here

            Teacher aTeacher1 = new Teacher("C/ Alboraya, 3", "JM", "Juan Miguel", 46010, "111");
            dal.Insert<Teacher>(aTeacher1);
            dal.Commit();

            Teacher aTeacher2 = new Teacher("Pl. de les escoles pies, 3 baix esquerre", "SR", "Salki", 46019, "112");
            dal.Insert<Teacher>(aTeacher2);
            dal.Commit();

            TaughtCourse aTaughtCourse1 = new TaughtCourse(new DateTime(2024, 1, 1), 12, 7, 1, new DateTime(2025, 1, 1), "Lunes", 100, aCourse1);
            aTaughtCourse1.Teachers.Add(aTeacher1);
            dal.Insert<TaughtCourse>(aTaughtCourse1);
            dal.Commit();

            TaughtCourse aTaughtCourse2 = new TaughtCourse(new DateTime(2024, 1, 1), 13, 7, 1, new DateTime(2025, 1, 1), "Martes", 100, aCourse2);
            aTaughtCourse2.Teachers.Add(aTeacher2);
            dal.Insert<TaughtCourse>(aTaughtCourse2);
            dal.Commit();

            Student[] students = new Student[10];
            Enrollment[] enrollments = new Enrollment[10];
            for (int i = 0; i < 10; i++)
            {
                students[i] = new Student("Sin dirección","000"+i, "Nombre"+i,46000+i, "IBAN"+i);
                enrollments[i] = new Enrollment(new DateTime(2024, 1, 6), true, students[i],aTaughtCourse1);
                students[i].Enrollments.Add(enrollments[i]);
                dal.Insert<Student>(students[i]);
                dal.Insert<Enrollment>(enrollments[i]);
                dal.Commit();
            }

            Classroom aClassroom1 = new Classroom(10, "Clase de ISW");
            aClassroom1.TaughtCourses.Add(aTaughtCourse1);
            dal.Insert<Classroom>(aClassroom1);
            dal.Commit();

            Classroom aClassroom2 = new Classroom(10, "Clase de EDA");
            aClassroom2.TaughtCourses.Add(aTaughtCourse2);
            dal.Insert<Classroom>(aClassroom2);
            dal.Commit();

            Absence a1 = new Absence(new DateTime(2024,5,5));
            enrollments[1].Absences.Add(a1);
            dal.Insert(a1);
            dal.Commit();

            Absence a2 = new Absence(new DateTime(2024,6,6));
            enrollments[2].Absences.Add(a2);
            dal.Insert(a2);
            dal.Commit();
        }


        private void PrintSampleDB(IDAL dal)
        {
            Console.WriteLine("\n\nMOSTRANDO LOS DATOS DE LA BD");
            Console.WriteLine("============================\n");

            Console.WriteLine("\nCursos creados:");
            foreach (Course c in dal.GetAll<Course>())
                Console.WriteLine("   Name: " + c.Name + " Description: " + c.Description);

            // Show the rest of the database
            Console.WriteLine("\nProfesores creados:");
            foreach (Teacher t in dal.GetAll<Teacher>())
                Console.WriteLine("   ID: " + t.Id + " Name: " + t.Name);

            Console.WriteLine("\nImparticiones de cursos creados:");
            foreach (Course c in dal.GetAll<Course>())
            {
                Console.WriteLine("   Name: " + c.Name + " Description: " + c.Description);
                foreach (TaughtCourse tc in c.TaughtCourses)
                    Console.WriteLine("      ID: " + tc.Id + " START: " + tc.StartDateTime + " END: " + tc.EndDate);
            }

            Console.WriteLine("\nInscripciones por curso a impartir:");
            foreach (Course c in dal.GetAll<Course>())
            {
                Console.WriteLine("   Name: " + c.Name + " Description: " + c.Description);
                foreach (TaughtCourse tc in c.TaughtCourses)
                {
                    Console.WriteLine("      ID: " + tc.Id + " START: " + tc.StartDateTime + " END: " + tc.EndDate);
                    foreach (Enrollment en in tc.Enrollments)
                        Console.WriteLine("      ---> Student: " + en.Student.Name + " Enrollment Date: " + en.EnrollmentDate);
                }

            }

            Console.WriteLine("\nAulas creadas y sus asignaciones");
            foreach (Classroom o in dal.GetAll<Classroom>())
            {
                Console.WriteLine("   Name: " + o.Name + " Capacity: " + o.MaxCapacity);
                foreach (TaughtCourse tc in o.TaughtCourses)
                    Console.WriteLine("      CourseID: " + tc.Id + " START: " + tc.StartDateTime + " END: " + tc.EndDate + " People: " + tc.Enrollments.Count);
            }

            Console.WriteLine("\nFaltas de asistencia por alumno");
            foreach (Student s in dal.GetAll<Student>())
            {
                Console.WriteLine("   Student Name: " + s.Name);
                foreach (Enrollment en in s.Enrollments)
                {
                    Console.WriteLine("      Enrollment in: " + en.TaughtCourse.Id + " Course name: " + en.TaughtCourse.Course.Name + " Absences: " + en.Absences.Count);
                    foreach (Absence ab in en.Absences)
                        Console.WriteLine("         Date: " + ab.Date);
                }

            }
        }

    }

}
