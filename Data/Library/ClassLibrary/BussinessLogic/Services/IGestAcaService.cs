using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestAca.Entities;


namespace GestAca.Services
{
    public interface IGestAcaService
    {
        void RemoveAllData();
        void Commit();

        // Necesario para la inicialización de la BD
        void DBInitialization();
        void AddTeacher(Teacher teacher);
        void AddStudent(Student student);

        void AddClassroom(Classroom classroom);
        void AddCourse(Course course);
        void AddTaughtCourse(TaughtCourse tcourse);


        //
        // A partir de aquí los necesarios para los CU solicitados
        //

        List<TaughtCourse> GetTaughtCourses();

        List<Teacher> GetTeachers();

        List<Classroom> GetClassrooms();
        List<Student> GetStudents();
        List<TaughtCourse> GetTaughtCoursesNotStarted();
        List<Teacher> GetAvailableTeachers(TaughtCourse taughtCourse);
        List<Classroom> GetAvailableClassrooms(TaughtCourse taughtCourse);

        void AssingTeacherToCourse(Teacher teacher, TaughtCourse taughtCourse);
        void AssingClassroomToCourse(TaughtCourse taughtCourse, Classroom classroom);
        void AddStudentToCourse(TaughtCourse taughtCourseChosen, Student student);
        List<Student> GetStudentsEnrolledInACourse(TaughtCourse taughtCourse);
        TaughtCourse GetTaughtCourseFromName(string name);
        Student GetStudentFromDni(string dni);
        Teacher GetTeacherFromName(string name);
        Classroom GetClassroomFromName(string name);
        bool IsAlreadyEnrolled(Student student, TaughtCourse taughtCourse);
        bool ClassroomFull(TaughtCourse taughtCourse);
    }
}
