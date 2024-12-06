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
                botonResetDB.Enabled = false;
                _DBChanged = false;
            }
        }


        private void botonAsignarAulaACurso_Click(object sender, EventArgs e)
        {
            ResetAdminGUI();
            _aSelectedFunction = "AsignarAulaACurso";
            Utils.ShowThroughtComboBox(comboBoxA1, Utils.ElementToNameList(_service.GetTaughtCourses().Cast<IGestAcaEntity>().ToList(), Utils.TabZero),
                                       labelA1, "Asignar aula a un curso a impartir");
        }

        private void botonAsignarProfesorACurso_Click(object sender, EventArgs e)
        {
            ResetAdminGUI();
            _aSelectedFunction = "AsignarProfesorACurso";
            Utils.ShowThroughtComboBox(comboBoxA1, Utils.ElementToNameList(_service.GetTaughtCourses().Cast<IGestAcaEntity>().ToList(), Utils.TabZero),
                                       labelA1, "Asignar profesor a un curso a impartir");
        }

        private void botonInscribirAlumnoEnCurso_Click(object sender, EventArgs e)
        {
            ResetEmpleadoGUI();
            _eSelectedFunction = "InscribirAlumnoEnCurso";
            Utils.ShowThroughtComboBox(comboBoxE1, Utils.ElementToNameList(_service.GetTaughtCoursesNotStarted().Cast<IGestAcaEntity>().ToList(), Utils.TabZero),
                                       labelE1, "Inscribir alumno en un curso a impartir");
        }

        private void botonMostrarAlumnosDeUnCurso_Click(object sender, EventArgs e)
        {
            ResetEmpleadoGUI();
            _eSelectedFunction = "MostrarAlumnosDeUnCurso";
            Utils.ShowThroughtComboBox(comboBoxE1, Utils.ElementToNameList(_service.GetTaughtCourses().Cast<IGestAcaEntity>().ToList(), Utils.TabZero),
                                       labelE1, "Mostrar alumnos de un curso a impartir");
        }


        private void comboBoxE1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Utils.CorrectSelections(comboBoxE1))
            {
                if (_eSelectedFunction == "MostrarAlumnosDeUnCurso")
                {
                    TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxE1.SelectedItem.ToString());
                    List<Student> studentsEnrolled = _service.GetStudentsEnrolledInACourse(taughtCourseChosen);
                    Utils.ShowThroughtTextBox(textBoxE1, Utils.PrintTaughtCourseInfo(taughtCourseChosen),
                                              labelE2, "Informaciones sobre el curso a impartir seleccionado");
                    Utils.ShowThroughtdataGridView(dataGridViewE1, studentsEnrolled, taughtCourseChosen,
                                              labelE3, "Enstudiantes del curso " + comboBoxE1.SelectedItem.ToString() + ":");
                }

                else if (_eSelectedFunction == "InscribirAlumnoEnCurso")
                {
                    TextBoxE3InfoNotVisible();
                    TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxE1.SelectedItem.ToString());
                    Utils.ShowThroughtTextBox(textBoxE1, Utils.PrintTaughtCourseInfo(taughtCourseChosen),
                                              labelE2, "Informaciones sobre el curso a impartir seleccionado");

                    labelE3.Text = "dni estudiante que quieres inscribir:";
                    labelE3.Visible = true;
                    textBoxE3.Visible = true;
                    buttonE2.Visible = true;
                    buttonE1.Enabled = false;
                    buttonE1.Visible = true;
                }
            }

            else
            {
                ResetEmpleadoGUI();
            }
        }



        private void buttonE2_Click(object sender, EventArgs e)
        {
            if (Utils.CorrectSelections(comboBoxE1))
            {
                try
                {
                    Student student = _service.GetStudentFromDni(textBoxE3.Text);
                    Utils.ShowThroughtTextBox(textBoxE2, student.ToString(),
                                              labelE4, "Informaciones sobre el estudiante seleccionado");
                    buttonE1.Enabled = true;
                }
                catch (Exception dniNoEncontradoEnElDB)
                {
                    buttonE1.Enabled = false;
                    textBoxE2.Text = "";
                    Utils.Message("ERRORE: el dni inserito no se encontrò en el database", "dni estudiante non valido");
                }
            }
            else
            {
                Utils.Message("ERRORE: selecciona un curso valido", "scelta curso non valida");
            }
        }

        private void buttonE1_Click(object sender, EventArgs e)
        {
            if (Utils.CorrectSelections(comboBoxE1))
            {
                if (_eSelectedFunction == "InscribirAlumnoEnCurso")
                {
                    TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxE1.SelectedItem.ToString());
                    Student studentChosen = _service.GetStudentFromDni(textBoxE3.Text);

                    if(_service.IsAlreadyEnrolled(studentChosen, taughtCourseChosen) == false)
                    {
                        if (Utils.Confirmacion("¿Quieres realizar los cambios? No es una operación reversible", "Confirmación de cambios"))
                        {
                            _service.AddStudentToCourse(taughtCourseChosen, studentChosen);
                            _DBChanged = true;
                            botonResetDB.Enabled = true;
                            ResetGUI();
                        }
                    }
                    else
                    {
                        Utils.Message("El estudiante ya es inscrito en este curso", "estudiante ya enscrito");
                    }
                }
            }
        }

        private void comboBoxA1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Utils.CorrectSelections(comboBoxA1))
            {
                ComboBoxA2InfoNotVisible();
                buttonA1.Enabled = false;
                buttonA1.Visible = true;

                if (_aSelectedFunction == "AsignarAulaACurso")
                {
                    TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxA1.SelectedItem.ToString());
                    if (taughtCourseChosen.Classroom != null)
                    {
                        Utils.Message("El curso ya tiene un aula asignada. Este proceso lo sobrescribirá", "Aviso de sustitución");
                    }
                    Utils.ShowThroughtTextBox(textBoxA1, Utils.PrintTaughtCourseInfo(taughtCourseChosen),
                                              labelA2, "Informaciones sobre el curso a impartir seleccionado");
                    Utils.ShowThroughtComboBox(comboBoxA2, Utils.ElementToNameList(_service.GetAvailableClassrooms(taughtCourseChosen).Cast<IGestAcaEntity>().ToList(), Utils.TabZero),
                                               labelA3, "Selecciona aula que quieres asignar:");
                }

                else if (_aSelectedFunction == "AsignarProfesorACurso")
                {
                    TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxA1.SelectedItem.ToString());
                    Utils.ShowThroughtTextBox(textBoxA1, Utils.PrintTaughtCourseInfo(taughtCourseChosen),
                                              labelA2, "Informaciones sobre el curso a impartir seleccionado");
                    Utils.ShowThroughtComboBox(comboBoxA2, Utils.ElementToNameList(_service.GetAvailableTeachers(taughtCourseChosen).Cast<IGestAcaEntity>().ToList(), Utils.TabZero),
                                               labelA3, "Selecciona profesor que quieres asignar:");
                }
            }

            else
            {
                ResetAdminGUI();
            }
        }

        private void buttonA1_Click(object sender, EventArgs e)
        {
            if (Utils.CorrectSelections(comboBoxA1, comboBoxA2))
            {
                if (_aSelectedFunction == "AsignarAulaACurso")
                {
                    if (Utils.Confirmacion("¿Quieres realizar los cambios? No es una operación reversible", "Confirmación de cambios"))
                    {
                        TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxA1.SelectedItem.ToString());
                        Classroom classroomChosen = _service.GetClassroomFromName(comboBoxA2.SelectedItem.ToString());
                        _service.AssingClassroomToCourse(taughtCourseChosen, classroomChosen);
                        _DBChanged = true;
                        botonResetDB.Enabled = true;
                        ResetGUI();
                    }
                }
                else if (_aSelectedFunction == "AsignarProfesorACurso")
                {

                    if (Utils.Confirmacion("¿Quieres realizar los cambios? No es una operación reversible", "Confirmación de cambios"))
                    {
                        TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxA1.SelectedItem.ToString());
                        Teacher teacherChosen = _service.GetTeacherFromName(comboBoxA2.SelectedItem.ToString());
                        _service.AssingTeacherToCourse(teacherChosen, taughtCourseChosen);
                        _DBChanged = true;
                        botonResetDB.Enabled = true;
                        ResetGUI();
                    }
                }
            }
        }

        private void comboBoxA2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Utils.CorrectSelections(comboBoxA1, comboBoxA2))
            {
                buttonA1.Enabled = true;

                if (_aSelectedFunction == "AsignarAulaACurso")
                {
                    Classroom classroomChosen = _service.GetClassroomFromName(comboBoxA2.SelectedItem.ToString());
                    Utils.ShowThroughtTextBox(textBoxA2, classroomChosen.ToString(),
                                              labelA4, "Informaciones sobre aula seleccionada");
                }
                else if (_aSelectedFunction == "AsignarProfesorACurso")
                {
                    Teacher teacherChosen = _service.GetTeacherFromName(comboBoxA2.SelectedItem.ToString());
                    Utils.ShowThroughtTextBox(textBoxA2, teacherChosen.ToString(),
                                              labelA4, "Informaciones sobre el profesor seleccionado");
                }
            }
            else
            {
                buttonA1.Enabled = false;
                ComboBoxA2InfoNotVisible();
            }
        }
    }
}
