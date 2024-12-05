using GestAca.Entities;
using GestAca.Services;
using GestAca.Persistence;
using System.Windows.Forms;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace GestAca.GUI
{
    internal class Utils
    {
        public static bool Confirmacion(string contenido, string titulo)
        {
            return MessageBox.Show(contenido, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void Message(string contenido, string titulo)
        {
            MessageBox.Show(contenido, titulo, MessageBoxButtons.OK, MessageBoxIcon.Question);
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

        public static string PrintStudents(List<Student> students)//da eliminare
        {
            string output = "";
            if (students.Count > 0) {
                foreach (var student in students)
                {
                    output += "nome: " + student.Name + " | dni: " + student.Id +"\r\n";
                }
            }
            else
            {
                output += "there are no students enrolled in this course";
            }
            return output;
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
    }
}