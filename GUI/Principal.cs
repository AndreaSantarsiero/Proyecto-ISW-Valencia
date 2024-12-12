using GestAca.Entities;
using GestAca.Persistence;
using GestAca.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.EntitySql;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GestAca.GUI
{
    public partial class Principal : Form
    {
        private readonly IGestAcaService _service;
        private Function _eSelectedFunction;
        private Function _aSelectedFunction;


        public Principal()
        {
            InitializeComponent();
            _service = new GestAcaService(new EntityFrameworkDAL(new GestAcaDbContext()));
        }

        private void botonBasesDeDatos_Click(object sender, EventArgs e)
        {
            if (Utils.Confirmacion("La base de datos fue modificada, ¿quiere reiniciarla?",
                                                 "Reinicio base de datos"))
            {
                _service.DBInitialization();
                ResetGUI();
            }
        }


        private void botonAsignarAulaACurso_Click(object sender, EventArgs e)
        {
            ResetAdminGUI();
            _aSelectedFunction = Function.AsignarAulaACurso;
            Utils.ShowThroughtComboBox(comboBoxA1, Utils.ElementToNameList(_service.GetTaughtCourses().Cast<IGestAcaEntity>().ToList(), Utils.TabZero),
                                       labelA1, "Asignar aula a un curso a impartir");
        }

        private void botonAsignarProfesorACurso_Click(object sender, EventArgs e)
        {
            ResetAdminGUI();
            _aSelectedFunction = Function.AsignarProfesorACurso;
            Utils.ShowThroughtComboBox(comboBoxA1, Utils.ElementToNameList(_service.GetTaughtCourses().Cast<IGestAcaEntity>().ToList(), Utils.TabZero),
                                       labelA1, "Asignar profesor a un curso a impartir");
        }

        private void botonInscribirAlumnoEnCurso_Click(object sender, EventArgs e)
        {
            ResetEmpleadoGUI();
            _eSelectedFunction = Function.InscribirAlumnoEnCurso;
            Utils.ShowThroughtComboBox(comboBoxE1, Utils.ElementToNameList(_service.GetTaughtCoursesNotStarted().Cast<IGestAcaEntity>().ToList(), Utils.TabZero),
                                       labelE1, "Inscribir alumno en un curso a impartir");
        }

        private void botonMostrarAlumnosDeUnCurso_Click(object sender, EventArgs e)
        {
            ResetEmpleadoGUI();
            _eSelectedFunction = Function.MostrarAlumosDeUnCurso;
            Utils.ShowThroughtComboBox(comboBoxE1, Utils.ElementToNameList(_service.GetTaughtCourses().Cast<IGestAcaEntity>().ToList(), Utils.TabZero),
                                       labelE1, "Mostrar alumnos de un curso a impartir");
        }


        private void comboBoxE1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Utils.CorrectSelections(comboBoxE1))
            {
                try
                {
                    if (_eSelectedFunction == Function.MostrarAlumosDeUnCurso)
                    {
                        TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxE1.SelectedItem.ToString());
                        List<Student> studentsEnrolled = _service.GetStudentsEnrolledInACourse(taughtCourseChosen);
                        Utils.ShowThroughtTextBox(textBoxE1, Utils.PrintTaughtCourseInfo(taughtCourseChosen),
                                                  labelE2, "Informaciones sobre el curso a impartir seleccionado");
                        Utils.ShowThroughtdataGridView(dataGridViewE1, studentsEnrolled, taughtCourseChosen,
                                                  labelE3, "Estudiantes del curso " + comboBoxE1.SelectedItem.ToString() + ":");
                    }

                    else if (_eSelectedFunction == Function.InscribirAlumnoEnCurso || _eSelectedFunction == Function.RegistrarAlumno)
                    {
                        _eSelectedFunction = Function.InscribirAlumnoEnCurso;
                        DisableStudentRegistration();
                        TextBoxE3InfoNotVisible();
                        TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxE1.SelectedItem.ToString());
                        Utils.ShowThroughtTextBox(textBoxE1, Utils.PrintTaughtCourseInfo(taughtCourseChosen),
                                                  labelE2, "Informaciones sobre el curso a impartir seleccionado");

                        labelE3.Text = "DNI del estudiante que quieres inscribir:";
                        labelE3.Visible = true;
                        textBoxE3.Visible = true;
                        buttonE2.Visible = true;
                        buttonE1.Enabled = false;
                        buttonE1.Visible = true;
                        checkBox1.Enabled = true;
                        checkBox1.Visible = true;
                    }
                }
                catch (ServiceException _exception)
                {
                    Console.WriteLine("EXCEPCIÓN: " + _exception.Message);
                    Utils.Message("ERROR: Has seleccionado un curso inexistente. Por favor, vuelve a intentarlo", "Error");
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
                    DisableStudentRegistration();
                    _eSelectedFunction = Function.InscribirAlumnoEnCurso;
                    buttonE1.Enabled = true;
                }
                catch (ServiceException _exception)
                {
                    Console.WriteLine("EXCEPCIÓN: " + _exception.Message);
                    buttonE1.Enabled = false;
                    textBoxE2.Text = "";
                    if(Utils.Confirmacion("ERROR: El DNI escrito no se encontró en la base de datos.\r\n¿Quieres inscribir un nuevo estudiante?", "DNI del estudiante no valido"))
                    {
                        EnableStudentRegistration();
                        _eSelectedFunction = Function.RegistrarAlumno;
                    }
                    else
                    {
                        textBoxE2.Text = "";
                    }
                }
            }
            else
            {
                Utils.Message("ERROR: Selecciona un curso valido", "Seleccion del curso no valida");
            }
        }

        private void buttonE1_Click(object sender, EventArgs e)
        {
            if (Utils.CorrectSelections(comboBoxE1))
            {
                if (_eSelectedFunction == Function.InscribirAlumnoEnCurso)
                {
                    try
                    {
                        TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxE1.SelectedItem.ToString());
                        Student studentChosen = _service.GetStudentFromDni(textBoxE3.Text);

                        if (taughtCourseChosen.IsClassroomFull() == true)
                        {
                            Utils.Message("El aula del curso seleccionado no tiene mas capacidad.\r\nSi queres, puedes seleccionar un otro curso", "aula sin puestos disponibles");
                            ResetEmpleadoGUI();
                            _eSelectedFunction = Function.InscribirAlumnoEnCurso;
                            Utils.ShowThroughtComboBox(comboBoxE1, Utils.ElementToNameList(_service.GetTaughtCoursesNotStarted().Cast<IGestAcaEntity>().ToList(), Utils.TabZero),
                                                       labelE1, "Inscribir alumno en un curso a impartir");
                        }
                        else if (_service.IsAlreadyEnrolled(studentChosen, taughtCourseChosen) == false)
                        {
                            if (Utils.Confirmacion("¿Quieres realizar los cambios? No es una operación reversible", "Confirmación de cambios"))
                            {
                                _service.AddStudentToCourse(taughtCourseChosen, studentChosen, checkBox1.Checked);
                                botonResetDB.Enabled = true;
                                ResetGUI();
                            }
                        }
                        else
                        {
                            Utils.Message("El estudiante ya es inscrito en este curso", "estudiante ya enscrito");
                        }
                    }
                    catch(ServiceException _excepcion)
                    {
                        // Teoricamente esto es imposible
                        Console.WriteLine("EXCEPCIÓN: " + _excepcion.Message);
                        Utils.Message("ERROR: Has seleccionado un curso o estudiante inexistente. Por favor, vuelve a intentarlo", "Error");
                    }
                }
                else if (_eSelectedFunction == Function.RegistrarAlumno)
                {
                    if (_service.GetTeachers().Any(x => x.Id.Equals(textBoxE5.Text)))
                    {
                        Utils.Message("No puede haber un alumno con este DNI, pertenece a un profesor", "Datos incompletos o incorrectos");
                    }
                    else if(Utils.CheckNewStudentData(textBoxE4, textBoxE5, textBoxE6, textBoxE7, textBoxE8))
                    {
                        _service.AddStudent(new Student(textBoxE6.Text, textBoxE5.Text, textBoxE4.Text, int.Parse(textBoxE7.Text), textBoxE8.Text));
                        textBoxE3.Text = textBoxE5.Text;
                        DisableStudentRegistration();
                        _eSelectedFunction = Function.InscribirAlumnoEnCurso;
                    }
                    else
                    {
                        Utils.Message("Los datos del estudiante son incompletos o incorrectos", "Datos incompletos o incorrectos");
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

                try
                {
                    if (_aSelectedFunction == Function.AsignarAulaACurso)
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

                    else if (_aSelectedFunction == Function.AsignarProfesorACurso)
                    {
                        TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxA1.SelectedItem.ToString());
                        Utils.ShowThroughtTextBox(textBoxA1, Utils.PrintTaughtCourseInfo(taughtCourseChosen),
                                                  labelA2, "Informaciones sobre el curso a impartir seleccionado");
                        Utils.ShowThroughtComboBox(comboBoxA2, Utils.ElementToNameList(_service.GetAvailableTeachers(taughtCourseChosen).Cast<IGestAcaEntity>().ToList(), Utils.TabZero),
                                                   labelA3, "Selecciona profesor que quieres asignar:");
                    }
                }

                catch (ServiceException _exception)
                {
                    Console.WriteLine("EXCEPCIÓN: " + _exception.Message);
                    Utils.Message("ERROR: Has seleccionado un curso inexistente. Por favor, vuelve a intentarlo", "Error");
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
                try
                {
                    if (_aSelectedFunction == Function.AsignarAulaACurso)
                    {
                        if (Utils.Confirmacion("¿Quieres realizar los cambios? No es una operación reversible", "Confirmación de cambios"))
                        {
                            try
                            {
                                TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxA1.SelectedItem.ToString());
                                Classroom classroomChosen = _service.GetClassroomFromName(comboBoxA2.SelectedItem.ToString());
                                _service.AssingClassroomToCourse(taughtCourseChosen, classroomChosen);
                                botonResetDB.Enabled = true;
                                ResetGUI();
                            }
                            catch (ServiceException _exception)
                            {
                                Console.WriteLine("EXCEPCIÓN: " + _exception.Message);
                                Utils.Message("ERROR, el aula o el curso no existen. Revisa la consola para más detalles", "Error");
                            }
                        }
                    }
                    else if (_aSelectedFunction == Function.AsignarProfesorACurso)
                    {

                        if (Utils.Confirmacion("¿Quieres realizar los cambios? No es una operación reversible", "Confirmación de cambios"))
                        {
                            TaughtCourse taughtCourseChosen = _service.GetTaughtCourseFromName(comboBoxA1.SelectedItem.ToString());
                            Teacher teacherChosen = _service.GetTeacherFromName(comboBoxA2.SelectedItem.ToString());
                            _service.AssingTeacherToCourse(teacherChosen, taughtCourseChosen);
                            botonResetDB.Enabled = true;
                            ResetGUI();
                        }
                    }
                }

                catch (ServiceException _exception)
                {
                    Console.WriteLine("EXCEPCIÓN: " + _exception.Message);
                    Utils.Message("ERROR: Has seleccionado un curso inexistente. Por favor, vuelve a intentarlo", "Error");
                }
            }
        }

        private void comboBoxA2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Utils.CorrectSelections(comboBoxA1, comboBoxA2))
            {
                buttonA1.Enabled = true;
                try
                {
                    if (_aSelectedFunction == Function.AsignarAulaACurso)
                    {
                        Classroom classroomChosen = _service.GetClassroomFromName(comboBoxA2.SelectedItem.ToString());
                        Utils.ShowThroughtTextBox(textBoxA2, classroomChosen.ToString(),
                                                  labelA4, "Informaciones sobre aula seleccionada");
                    }
                    else if (_aSelectedFunction == Function.AsignarProfesorACurso)
                    {
                        Teacher teacherChosen = _service.GetTeacherFromName(comboBoxA2.SelectedItem.ToString());
                        Utils.ShowThroughtTextBox(textBoxA2, teacherChosen.ToString(),
                                                  labelA4, "Informaciones sobre el profesor seleccionado");
                    }
                }
                catch(ServiceException _exception)
                {
                    Console.WriteLine("EXCEPCIÓN: " + _exception.Message);
                    Utils.Message("ERROR: Nombre de curso o clase no encontrado, revisa la consola para más detalles", "Error");
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
