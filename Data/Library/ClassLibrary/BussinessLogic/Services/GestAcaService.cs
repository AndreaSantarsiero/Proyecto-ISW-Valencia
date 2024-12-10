using System;
using System.Collections.Generic;
using System.Linq;

using GestAca.Entities;
using GestAca.Persistence;

namespace GestAca.Services
{
    public class GestAcaService : IGestAcaService
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
            AddTeacher(new Teacher("Av. La Informatica 20", "22222222B", "Prof2", 46023, "SSN22222222B"));
            AddTeacher(new Teacher("C/Sulfurosa 30", "33333333C", "Prof3", 46024, "SSN33333333B"));

            // Dar de alta unos estudiantes para poder usarlos luego
            AddStudent(new Student("C/Roma 10", "44444444D", "Estudiante1", 46011, "ES91 1111 2222 3333 4444 5555 66"));
            AddStudent(new Student("C/Milano 20", "55555555E", "Estudiante2", 46012, "ES91 2222 3333 4444 5555 6666 77"));
            AddStudent(new Student("C/Firenze 30", "66666666F", "Estudiante3", 46013, "ES91 3333 4444 5555 6666 7777 88"));

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
        /// Persiste un estudiante
        /// </summary>
        /// <param name="student"></param>
        /// <exception cref="ServiceException"></exception>
        public void AddStudent(Student student)
        {
            // Restricción: No puede haber dos personas con el mismo Id (dni)
            if (dal.GetById<Student>(student.Id) == null)
            {
                dal.Insert<Student>(student);
                dal.Commit();
            }
            else
                throw new ServiceException("There is another person with Id " + student.Id);
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

        //TODO: Aquí se comprimirá código

        public List<TaughtCourse> GetTaughtCourses() {
            return dal.GetAll<TaughtCourse>().ToList<TaughtCourse>();
        }

        public List<Teacher> GetTeachers() {
            return dal.GetAll<Teacher>().ToList<Teacher>();
        }
        public List<Classroom> GetClassrooms()
        {
            return dal.GetAll<Classroom>().ToList<Classroom>();
        }
        public List<Student> GetStudents()
        {
            return dal.GetAll<Student>().ToList<Student>();
        }
        
        public List<Teacher> GetAvailableTeachers(TaughtCourse taughtCourse)
        {
            List<Teacher> teachersAvailable = new List<Teacher>();
            foreach (var teacher in GetTeachers())
            {
                if (teacher.IsAvailableForNewTaughtCouse(taughtCourse))
                {
                    teachersAvailable.Add(teacher);
                }
            }

            return teachersAvailable;
        }


        public List<Classroom> GetAvailableClassrooms(TaughtCourse taughtCourse)
        {
            List<Classroom> classroomsAvailables = new List<Classroom>();
            foreach (var classroom in GetClassrooms())
            {                
                if (classroom.MaxCapacity >= taughtCourse.Enrollments.Count && classroom.IsAvailableForNewTaughtCouse(taughtCourse)) //en el if falta la condicion: No se puede impartir un curso en un aula si en el lapso de tiempo que dura está ya ocupada
                {
                    classroomsAvailables.Add(classroom);
                }
            }

            return classroomsAvailables;
        }

        public List<TaughtCourse> GetTaughtCoursesNotStarted()
        {
            List<TaughtCourse> taughtCoursesAfterToday = new List<TaughtCourse>();
            foreach (var taughtCourse in GetTaughtCourses())
            {
                if (taughtCourse.StartDateTime > DateTime.Now)
                {
                    taughtCoursesAfterToday.Add(taughtCourse);
                }
            }

            return taughtCoursesAfterToday;
        }

        public void AssingTeacherToCourse(Teacher teacher, TaughtCourse taughtCourse)
        {
            teacher.TaughtCourses.Add(taughtCourse);
            taughtCourse.AddTeacher(teacher);
            Commit();
        }

        public void AssingClassroomToCourse(TaughtCourse taughtCourse, Classroom classroom)
        {
            classroom.TaughtCourses.Add(taughtCourse);
            taughtCourse.SetClassroom(classroom);
            Commit();
        }

        public void AddStudentToCourse(TaughtCourse taughtCourseChosen, Student student, bool uniquePayment)
        {
            Enrollment enrollment = new Enrollment(DateTime.Now, uniquePayment, student, taughtCourseChosen);
            student.AddEnrollment(enrollment);
            taughtCourseChosen.AddEnrollment(enrollment);
            Commit();
        }

        public List<Student> GetStudentsEnrolledInACourse(TaughtCourse taughtCourse)
        {
            List<Student> students = new List<Student>();
            foreach (var student in GetStudents())
            {
                foreach (var enrollment in student.Enrollments)
                {
                    if (enrollment.TaughtCourse == taughtCourse)
                    {
                        students.Add(student);
                    }
                }
            }
            return students;
        }

        public TaughtCourse GetTaughtCourseFromName(string name)
        {
            List<TaughtCourse> taughtCourses = GetTaughtCourses();
            return taughtCourses.Count > 0 ? taughtCourses.Single(s => s.Course.Name == name) : null;
        }

        public Student GetStudentFromDni (string dni)
        {
            List<Student> students = GetStudents();
            return students.Count > 0 ? students.Single(s => s.Id == dni) : null;
        }

        public Teacher GetTeacherFromName(string name)
        {
            List<Teacher> teachers = GetTeachers();
            return teachers.Count > 0 ? teachers.Single(s => s.Name == name) : null;
        }
        public Classroom GetClassroomFromName(string name)
        {
            List<Classroom> classrooms = GetClassrooms();
            return classrooms.Count > 0 ? classrooms.Single(s => s.Name == name) : null;
        }

        public bool IsAlreadyEnrolled(Student student, TaughtCourse taughtCourse)
        {
            return student.IsAlreadyEnrolledToTaughtCourse(taughtCourse);
        }

        public bool ClassroomFull(TaughtCourse taughtCourse)
        {
            return taughtCourse.ClassroomFull();
        }
    } 
}
