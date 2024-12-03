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

        public static List<string> TaughtCoursesToStringList(List<TaughtCourse> taughtCourses)
        {
            List<string> taughtCoursesList = new List<string>();
            taughtCoursesList.Add(" - selecciona un curso a impartir - ");
            foreach (var taughtCourse in taughtCourses)
            {
                taughtCoursesList.Add(taughtCourse.Course.Name);
            }
            return taughtCoursesList;
        }

        public static List<string> StudentsToStringList(List<Student> students)
        {
            List<string> studentsList = new List<string>();
            foreach (var student in students)
            {
                studentsList.Add(student.Name);
            }
            return studentsList;
        }

        public static List<string> ClassroomsToStringList(List<Classroom> classrooms)
        {
            List<string> classroomsList = new List<string>();
            foreach (var classroom in classrooms)
            {
                classroomsList.Add(classroom.Name);
            }
            return classroomsList;
        }

        public static List<string> TeachersToStringList(List<Teacher> teachers)
        {
            List<string> teachersList = new List<string>();
            foreach (var teacher in teachers)
            {
                teachersList.Add(teacher.Name);
            }
            return teachersList;
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
                    output += teacher.Name + ", ";
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
                return taughtCourse.Classroom.Name;
            }
            else
            {
                return "aun no asignada";
            }
        }

        public static string PrintTaughtCourseInfo(TaughtCourse taughtCourse)
        {
            return "nome curso: " + taughtCourse.Course.Name +
                   "\r\n" + PrintTeachersName(taughtCourse) +
                   "\r\naula asignada: " + PrintClassroomName(taughtCourse) +
                   "\r\nfecha de inicio: " + taughtCourse.StartDateTime.Date.ToString("dd/MM/yyyy") +
                   "\r\nfecha de finalización: " + taughtCourse.EndDate.ToString("dd/MM/yyyy") +
                   "\r\nhora de comienzo: " + taughtCourse.StartDateTime.TimeOfDay.ToString(@"hh\:mm") +
                   "\r\nhora de finalización: " + taughtCourse.StartDateTime.AddMinutes(taughtCourse.SessionDuration).TimeOfDay.ToString(@"hh\:mm");
        }
        
        public static string PrintStudentInfo(Student student)
        {
            return "nome: " + student.Name +
                   "\r\ndni: " + student.Id +
                   "\r\ndirección: " + student.Address +
                   "\r\ncodigo postal: " + student.ZipCode;
        }

        public static string PrintTeacherInfo(Teacher teacher)
        {
            return "nome: " + teacher.Name +
                   "\r\ndni: " + teacher.Id +
                   "\r\ndirección: " + teacher.Address +
                   "\r\ncodigo postal: " + teacher.ZipCode;
        }

        public static string PrintClassroomInfo(Classroom classroom)
        {
            return "nome: " + classroom.Name +
                   "\r\ncapacidad: " + classroom.MaxCapacity;
        }
    }
}