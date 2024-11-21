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
		void AddClassroom(Classroom classroom);
        void AddCourse(Course course);
        void AddTaughtCourse(TaughtCourse tcourse);


        //
        // A partir de aquí los necesarios para los CU solicitados
        //

    }
}
