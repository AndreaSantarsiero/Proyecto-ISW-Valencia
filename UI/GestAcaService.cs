using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using GestAca.Entities;
using GestAca.Persistence;


namespace GestAca.Services
{
    public class GestAcaService: IGestAcaService
    {
        private readonly IDAL dal;

        public GestAcaService(IDAL dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Borra todos los datos de la BD
        /// </summary>
        public void RemoveAllData()
        {
            dal.RemoveAllData();
        }

        /// <summary>
        /// Salva todos los cambios que haya habido en el contexto de la aplicación desde la última vez que se hizo Commit
        /// </summary>
        public void Commit()
        {
            dal.Commit();
        }

        public void DBInitialization()
        {
            RemoveAllData();

            // Dar de alta unos profesores para poder usarlos luego
            AddTeacher(new Teacher("C/San Cristobal 10", "11111111A", "Prof1", 46022, "SSN11111111A"));
            AddTeacher(new Teacher("Av. La Informatica 20", "22222222B", "Prof2", 46022, "SSN22222222B"));
            AddTeacher(new Teacher("C/Sulfurosa 30", "33333333C", "Prof3", 46022, "SSN33333333B"));

            // Dar de alta unas aulas para poder usarlas luego
            AddClassroom(new Classroom(2, "1P"));
            AddClassroom(new Classroom(10, "1A"));
            AddClassroom(new Classroom(5, "1G"));

            // Dar de alta unos cursos para poder usarlos luego
            Course aCourse1 = new Course("Curso Introductorio Ingenieria Software", "Software Engineering");
            AddCourse(aCourse1);
            Course aCourse2 = new Course("Curso Introductorio de Estructuras de datos", "Data Structures");
            AddCourse(aCourse2);
            AddCourse(new Course("Curso avanzado de Aerodinámica", "Advance aerodynamics"));

            //Curso empezado en 03/25 Válido para prácticas y recuperación. Se podrán apuntar nuevos estudiantes
            DateTime startDateTime = new DateTime(2025, 3, 24, 9, 30, 0);
            DateTime endDate = new DateTime(2025, 5, 19);
            TaughtCourse aTaughtCourse1 = new TaughtCourse(endDate, 1, 3, 120, startDateTime, "Monday", 1500, aCourse1);
            AddTaughtCourse(aTaughtCourse1);

            // Curso empezado en 04/24
            startDateTime = new DateTime(2024, 4, 15, 12, 0, 0);
            endDate = new DateTime(2024, 11, 30);
            TaughtCourse aTaughtCourse2 = new TaughtCourse(endDate, 2, 2, 120, startDateTime, "Wednesday", 1000, aCourse2);
            AddTaughtCourse(aTaughtCourse2);


        }

        /// <summary>
        /// Persiste un profesor
        /// </summary>
        /// <param name="teacher"></param>
        /// <exception cref="ServiceException"></exception>
        public void AddTeacher(Teacher teacher)
        {
            // Restricción: No puede haber dos personas con el mismo Id (dni)
            if (dal.GetById<Teacher>(teacher.Id) == null)
            {
                dal.Insert<Teacher>(teacher);
                dal.Commit();
            }
            else
                throw new ServiceException("There is another person with Id " + teacher.Id);
        }

        /// <summary>
        /// Persiste un aula
        /// </summary>
        /// <param name="Classroom"></param>
        /// <exception cref="ServiceException"></exception>
        public void AddClassroom(Classroom classroom)
        {
            // Restricción: No puede haber dos aulas con el mismo nombre
            if (!dal.GetWhere<Classroom>(x => x.Name == classroom.Name).Any())
            {
                dal.Insert<Classroom>(classroom);
                dal.Commit();
            }
            else
                throw new ServiceException("There is another classroom with Name " + classroom.Name);
        }

        /// <summary>
        /// Salva en la BD un curso
        /// </summary>
        /// <param name="course"></param>
        /// <exception cref="ServiceException"></exception>
        public void AddCourse(Course course)
        {
            // Restricción: No puede haber dos cursos con el mismo Name
            if (!dal.GetWhere<Course>(x => x.Name == course.Name).Any())
            {
                // Sólo se salva si no hay Name
                dal.Insert<Course>(course);
                dal.Commit();
            }
            else
                throw new ServiceException("Course with name " + course.Name + " already exists.");
        }

        /// <summary>
        /// Persiste el curso a impartir
        /// </summary>
        /// <param name="tcourse"></param>
        /// <exception cref="ServiceException"></exception>
        public void AddTaughtCourse(TaughtCourse tcourse)
        {
            // Restricción: No puede haber dos TaughtCourses con el mismo Id
            if (dal.GetById<TaughtCourse>(tcourse.Id) == null)
            {
                dal.Insert<TaughtCourse>(tcourse);
                dal.Commit();
            }
            else
                throw new ServiceException("Taught Course with Id " + tcourse.Id + " already exists.");
        }

        //
        // A partir de aquí vuestros métodos
        //


    }
}
