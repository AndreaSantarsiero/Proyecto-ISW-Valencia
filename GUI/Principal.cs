using GestAca.Entities;
using GestAca.Persistence;
using GestAca.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.EntitySql;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GestAca.GUI
{
    public partial class Principal : Form
    {
        private bool _DBChanged = false;
        private IGestAcaService _service;
        private string _eSelectedFunction;
        private string _aSelectedFunction;


        public Principal()
        {
            InitializeComponent();
            _service = new GestAcaService(new EntityFrameworkDAL(new GestAcaDbContext()));
            _service.DBInitialization();
        }

        private void botonBasesDeDatos_Click(object sender, EventArgs e)
        {
            if (_DBChanged && Utils.Confirmacion("La base de datos fue cambiada, ¿quieres reiniciarla?",
                                                 "Reinicio base de datos"))
            {
                _service.DBInitialization();
                ResetGUI();
                _DBChanged = false;
            }
        }


        private void botonAsignarAulaACurso_Click(object sender, EventArgs e)
        {
            ResetAdminGUI();
            _aSelectedFunction = "AsignarAulaACurso";
            Utils.ShowThroughtComboBox(comboBoxA1, Utils.TaughtCoursesToStringList(_service.GetTaughtCourses()),
                                       labelA1, "Asignar aula a un curso a impartir");
        }

        private void botonAsignarProfesorACurso_Click(object sender, EventArgs e)
        {
            ResetAdminGUI();
            _aSelectedFunction = "AsignarProfesorACurso";
            Utils.ShowThroughtComboBox(comboBoxA1, Utils.TaughtCoursesToStringList(_service.GetTaughtCourses()),
                                       labelA1, "Asignar profesor a un curso a impartir");
        }

        private void botonInscribirAlumnoEnCurso_Click(object sender, EventArgs e)
        {

            ResetEGUIShowStudentEnrolledToCourse();
            ResetEGUIAddStudentToCourse();
            _eSelectedFunction = "InscribirAlumnoEnCurso";
            Utils.ShowThroughtComboBox(comboBoxE1, Utils.TaughtCoursesToStringList(_service.GetTaughtCoursesNotStarted()),
                                       labelE1, "Inscribir alumno en un curso a impartir");
        }

        private void botonMostrarAlumnosDeUnCurso_Click(object sender, EventArgs e)
        {
            ResetEGUIAddStudentToCourse();
            ResetEGUIShowStudentEnrolledToCourse();
            _eSelectedFunction = "MostrarAlumnosDeUnCurso";
            Utils.ShowThroughtComboBox(comboBoxE1, Utils.TaughtCoursesToStringList(_service.GetTaughtCourses()),
                                       labelE1, "Mostrar alumnos de un curso a impartir");
        }


        private void comboBoxE1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxE1.SelectedItem != null &&
                comboBoxE1.SelectedItem.ToString() != " - selecciona un curso a impartir - " &&
                _eSelectedFunction == "MostrarAlumnosDeUnCurso")
            {
                TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxE1.SelectedItem.ToString());
                List<Student> studentsEnrolled = _service.GetStudentsEnrolledInACourse(taughtCourseChosen);
                Utils.ShowThroughtTextBox(textBoxE1, Utils.PrintTaughtCourseInfo(taughtCourseChosen),
                                          labelE2, "Informaciones sobre el curso a impartir seleccionado");
                Utils.ShowThroughtTextBox(textBoxE3, Utils.PrintStudents(studentsEnrolled),
                                          labelE3, "Enstudiantes del curso:" + comboBoxE1.SelectedItem.ToString() + ":");
            }

            else if (comboBoxE1.SelectedItem != null &&
                comboBoxE1.SelectedItem.ToString() != " - selecciona un curso a impartir - " &&
                _eSelectedFunction == "InscribirAlumnoEnCurso")
            {
                ComboBoxE2InfoNotVisible();
                TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxE1.SelectedItem.ToString());
                Utils.ShowThroughtTextBox(textBoxE1, Utils.PrintTaughtCourseInfo(taughtCourseChosen),
                                          labelE2, "Informaciones sobre el curso a impartir seleccionado");
                Utils.ShowThroughtComboBox(comboBoxE2, Utils.StudentsToStringList(_service.GetStudentsNotEnrolledInACourse(taughtCourseChosen)),
                                           labelE3, "Selecciona estudiante que quieres incribir");
                    
                buttonE1.Enabled = true;
                buttonE1.Visible = true;
            }

            else
            {
                TextBoxE3NotVisible();
                ComboBoxE1InfoNotVisible();
                ComboBoxE1ToDefaultResetGUI();
            }
        }

        private void buttonE1_Click(object sender, EventArgs e)
        {
            if (comboBoxE1.SelectedItem != null && 
                comboBoxE1.SelectedItem.ToString() != " - selecciona un curso a impartir - " &&
                comboBoxE2.SelectedItem != null &&
                _eSelectedFunction == "InscribirAlumnoEnCurso")
            {
                TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxE1.SelectedItem.ToString());
                Student studentChosen = _service.GetStudentFromName(comboBoxE2.SelectedItem.ToString());
                if (Utils.Confirmacion("¿Quieres realizar los cambios? No es una operación reversible", "Confirmación de cambios"))
                {
                    _service.AddStudentToCourse(taughtCourseChosen, studentChosen);
                    _DBChanged = true;
                    botonResetDB.Enabled = true;
                    ResetEGUIAddStudentToCourse();
                }
            }
        }

        private void comboBoxE2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxE1.SelectedItem != null &&
                comboBoxE1.SelectedItem.ToString() != " - selecciona un curso a impartir - " &&
                comboBoxE2.SelectedItem != null &&
                _eSelectedFunction == "InscribirAlumnoEnCurso")
            {
                Student studentChosen = _service.GetStudentFromName(comboBoxE2.SelectedItem.ToString());
                Utils.ShowThroughtTextBox(textBoxE2, Utils.PrintStudentInfo(studentChosen),
                                          labelE4, "Informaciones sobre el estudiante seleccionado");
            }
            else
            {
                buttonE1.Enabled = false;
                ComboBoxE2InfoNotVisible();
            }
        }

        private void comboBoxA1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBoxA1.SelectedItem != null &&
               comboBoxA1.SelectedItem.ToString() != " - selecciona un curso a impartir - ")
            {
                ComboBoxA2InfoNotVisible();
                buttonA1.Enabled = true;

                if (_aSelectedFunction == "AsignarAulaACurso")
                {
                    TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxA1.SelectedItem.ToString());
                    if (taughtCourseChosen.Classroom != null)
                    {
                        Utils.Message("El curso ya tiene un aula asignada. Este proceso lo sobrescribirá", "Aviso de sustitución");
                    }
                    Utils.ShowThroughtTextBox(textBoxA1, Utils.PrintTaughtCourseInfo(taughtCourseChosen),
                                              labelA2, "Informaciones sobre el curso a impartir seleccionado");
                    Utils.ShowThroughtComboBox(comboBoxA2, Utils.ClassroomsToStringList(_service.GetAvailableClassrooms(taughtCourseChosen)),
                                               labelA3, "Selecciona aula que quieres asignar:");

                    buttonA1.Enabled = true;
                    buttonA1.Visible = true;
                }

                else if (_aSelectedFunction == "AsignarProfesorACurso")
                {
                    TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxA1.SelectedItem.ToString());
                    Utils.ShowThroughtTextBox(textBoxA1, Utils.PrintTaughtCourseInfo(taughtCourseChosen),
                                              labelA2, "Informaciones sobre el curso a impartir seleccionado");
                    Utils.ShowThroughtComboBox(comboBoxA2, Utils.TeachersToStringList(_service.GetAvailableTeachers(taughtCourseChosen)),
                                               labelA3, "Selecciona profesor que quieres asignar:");

                    buttonA1.Enabled = false;
                    buttonA1.Visible = true;
                }
            }

            else
            {
                ResetAdminGUI();
            }
        }

        private void buttonA1_Click(object sender, EventArgs e)
        {
            if (comboBoxA1.SelectedItem != null &&
                comboBoxA1.SelectedItem.ToString() != " - selecciona un curso a impartir - " &&
                comboBoxA2.SelectedItem != null && 
                _aSelectedFunction == "AsignarAulaACurso")
            {
                if (Utils.Confirmacion("¿Quieres realizar los cambios? No es una operación reversible", "Confirmación de cambios"))
                {
                    TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxA1.SelectedItem.ToString());
                    Classroom classroomChosen = _service.GetClassroomFromName(comboBoxA2.SelectedItem.ToString());
                    _service.AssingClassroomToCourse(taughtCourseChosen, classroomChosen);
                    _DBChanged = true;
                    botonResetDB.Enabled = true;
                    ResetAdminGUI();
                }
            }
            else if (comboBoxA1.SelectedItem != null &&
                     comboBoxA1.SelectedItem.ToString() != " - selecciona un curso a impartir - " &&
                     comboBoxA2.SelectedItem != null &&
                     _aSelectedFunction == "AsignarProfesorACurso")
            {
                if (Utils.Confirmacion("¿Quieres realizar los cambios? No es una operación reversible", "Confirmación de cambios"))
                {
                    TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxA1.SelectedItem.ToString());
                    Teacher teacherChosen = _service.GetTeacherFromName(comboBoxA2.SelectedItem.ToString());
                    _service.AssingTeacherToCourse(teacherChosen, taughtCourseChosen);
                    _DBChanged = true;
                    botonResetDB.Enabled = true;
                    ResetAdminGUI();
                }
            }
        }

        private void comboBoxA2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxA1.SelectedItem != null && 
                comboBoxA1.SelectedItem.ToString() != " - selecciona un curso a impartir - " &&
                comboBoxA2.SelectedItem != null &&
                _aSelectedFunction == "AsignarAulaACurso")
            {
                Classroom classroomChosen = _service.GetClassroomFromName(comboBoxA2.SelectedItem.ToString());
                Utils.ShowThroughtTextBox(textBoxA2, Utils.PrintClassroomInfo(classroomChosen),
                                          labelA4, "Informaciones sobre aula seleccionada");
            }
            else if (comboBoxA1.SelectedItem != null &&
                     comboBoxA1.SelectedItem.ToString() != " - selecciona un curso a impartir - " &&
                     comboBoxA2.SelectedItem != null &&
                     _aSelectedFunction == "AsignarProfesorACurso")
            {
                Teacher teacherChosen = _service.GetTeacherFromName(comboBoxA2.SelectedItem.ToString());
                Utils.ShowThroughtTextBox(textBoxA2, Utils.PrintTeacherInfo(teacherChosen),
                                          labelA4, "Informaciones sobre el profesor seleccionado");
            }
            else
            {
                buttonA1.Enabled = false;
                ComboBoxA2InfoNotVisible();
            }
        }
    }
}
