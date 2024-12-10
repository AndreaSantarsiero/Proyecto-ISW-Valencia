using GestAca.Entities;
using GestAca.Services;
using GestAca.Persistence;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using System.Net;
using System.Text.RegularExpressions;

namespace GestAca.GUI
{
    internal class Utils
    {
        public static string TabZero = "----";


        public static bool Confirmacion(string contenido, string titulo)
        {
            return MessageBox.Show(contenido, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void Message(string contenido, string titulo)
        {
            MessageBox.Show(contenido, titulo, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        public static bool CorrectSelections(params System.Windows.Forms.ComboBox[] comboBoxes)
        {
            foreach (System.Windows.Forms.ComboBox comboBox in comboBoxes) { 
                if(comboBox.SelectedItem == null || comboBox.SelectedItem.ToString() == TabZero)
                {
                    return false;
                }
            }
            return true;
        }

        public static List<string> ElementToNameList(List<IGestAcaEntity> elements, string inicio)
        {
            List<string> cadenas = new List<string>{inicio};
            foreach (var e in elements){ cadenas.Add(e.GetName()); }
            return cadenas;
        }

        public static void ShowThroughtComboBox(System.Windows.Forms.ComboBox comboBox, List<string> parameters,
                                                System.Windows.Forms.Label label, string description)
        {
            label.Text = description;
            label.Visible = true;
            comboBox.DataSource = parameters;
            comboBox.Visible = true;
            comboBox.Enabled = true;
        }

        public static void ShowThroughtTextBox(System.Windows.Forms.TextBox textBox, string text,
                                               System.Windows.Forms.Label label, string description)
        {
            label.Text = description;
            label.Visible = true;
            textBox.Text = text;
            textBox.Visible = true;
        }

        public static void ShowThroughtdataGridView(System.Windows.Forms.DataGridView dataGridView, List<Student> students,
                                                    TaughtCourse taughtCourse, System.Windows.Forms.Label label, string description)
        {
            foreach (var student in students) { 
                foreach (var enrollment in student.Enrollments)
                {
                    if(enrollment.TaughtCourse == taughtCourse)
                    {
                        if(enrollment.UniquePayment == true)
                        {
                            dataGridView.Rows.Add(student.GetName(), "pagamento completo");
                        }
                        else
                        {
                            dataGridView.Rows.Add(student.GetName(), "pagamento por cuotas mensuales");
                        }
                    }
                }
            }
            label.Text = description;
            label.Visible = true;
            dataGridView.Visible = true;
        }

        public static string PrintTeachersName(TaughtCourse taughtCourse)
        {
            if(taughtCourse.Teachers.Count > 0)
            {
                string output = "";
                if (taughtCourse.Teachers.Count == 1)
                {
                    output = "profesor asignado: ";
                }
                else
                {
                    output = "profesores asignados: ";
                }
                foreach (var teacher in taughtCourse.Teachers)
                {
                    output += teacher.GetName() + ", ";
                }
                output = output.Substring(0, output.Length - 2);
                return output;
            }
            else
            {

                return "profesor asignado: aun no asignado";
            }
        }

        public static string PrintClassroomName(TaughtCourse taughtCourse)
        {
            if(taughtCourse.Classroom != null)
            {
                return taughtCourse.Classroom.GetName();
            }
            else
            {
                return "aun no asignada";
            }
        }

        public static string PrintTaughtCourseInfo(TaughtCourse taughtCourse)
        {
            return taughtCourse.ToString() +
                   "\r\n" + PrintTeachersName(taughtCourse) +
                   "\r\nAula asignada: " + PrintClassroomName(taughtCourse);
        }


        public static bool CheckNewStudentData(System.Windows.Forms.TextBox textBoxName,
                                               System.Windows.Forms.TextBox textBoxDni,
                                               System.Windows.Forms.TextBox textBoxDireccion,
                                               System.Windows.Forms.TextBox textBoxCP,
                                               System.Windows.Forms.TextBox textBoxIBAN)
        {
            string IBANWithoutSpaces = textBoxIBAN.Text.Replace(" ", "");

            return !string.IsNullOrEmpty(textBoxName.Text) && Regex.IsMatch(textBoxName.Text, @"^[A-Za-zÀ-ÿ\s.'-]+$") &&
                   textBoxDni.Text.Length == 9 && Regex.IsMatch(textBoxDni.Text, @"^\d{8}[A-Za-z]$") &&
                   !string.IsNullOrEmpty(textBoxDireccion.Text) && Regex.IsMatch(textBoxDireccion.Text, @"^[A-Za-z0-9\s,.'/-]+$") &&
                   Regex.IsMatch(textBoxCP.Text, @"^\d{5}$") &&
                   !string.IsNullOrEmpty(IBANWithoutSpaces) && Regex.IsMatch(IBANWithoutSpaces, @"^[A-Z0-9]{15,34}$");
        }
    }
}