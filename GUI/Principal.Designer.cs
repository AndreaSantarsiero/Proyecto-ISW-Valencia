using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Windows.Forms;

namespace GestAca.GUI
{
    partial class Principal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.botonResetDB = new System.Windows.Forms.Button();
            this.tabControlUsuario = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panelEmpleado = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.labelE10 = new System.Windows.Forms.Label();
            this.textBoxE8 = new System.Windows.Forms.TextBox();
            this.labelE9 = new System.Windows.Forms.Label();
            this.textBoxE7 = new System.Windows.Forms.TextBox();
            this.labelE8 = new System.Windows.Forms.Label();
            this.textBoxE6 = new System.Windows.Forms.TextBox();
            this.labelE6 = new System.Windows.Forms.Label();
            this.textBoxE4 = new System.Windows.Forms.TextBox();
            this.labelE7 = new System.Windows.Forms.Label();
            this.textBoxE5 = new System.Windows.Forms.TextBox();
            this.labelE5 = new System.Windows.Forms.Label();
            this.buttonE2 = new System.Windows.Forms.Button();
            this.dataGridViewE1 = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxE3 = new System.Windows.Forms.TextBox();
            this.labelE4 = new System.Windows.Forms.Label();
            this.textBoxE2 = new System.Windows.Forms.TextBox();
            this.buttonE1 = new System.Windows.Forms.Button();
            this.labelE2 = new System.Windows.Forms.Label();
            this.textBoxE1 = new System.Windows.Forms.TextBox();
            this.labelE3 = new System.Windows.Forms.Label();
            this.comboBoxE1 = new System.Windows.Forms.ComboBox();
            this.labelE1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelEmpleado = new System.Windows.Forms.FlowLayoutPanel();
            this.botonEmpleadoInscribirAlumnoEnCurso = new System.Windows.Forms.Button();
            this.botonEmpleadoMostrarAlumnosDeUnCurso = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panelAdministrador = new System.Windows.Forms.Panel();
            this.labelA4 = new System.Windows.Forms.Label();
            this.textBoxA2 = new System.Windows.Forms.TextBox();
            this.buttonA1 = new System.Windows.Forms.Button();
            this.comboBoxA2 = new System.Windows.Forms.ComboBox();
            this.labelA2 = new System.Windows.Forms.Label();
            this.textBoxA1 = new System.Windows.Forms.TextBox();
            this.labelA3 = new System.Windows.Forms.Label();
            this.comboBoxA1 = new System.Windows.Forms.ComboBox();
            this.labelA1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelAdministrador = new System.Windows.Forms.FlowLayoutPanel();
            this.botonAdministradorAsignarProfesorACurso = new System.Windows.Forms.Button();
            this.botonAdministradorAsignarAulaACurso = new System.Windows.Forms.Button();
            this.tabControlUsuario.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panelEmpleado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewE1)).BeginInit();
            this.flowLayoutPanelEmpleado.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panelAdministrador.SuspendLayout();
            this.flowLayoutPanelAdministrador.SuspendLayout();
            this.SuspendLayout();
            // 
            // botonResetDB
            // 
            this.botonResetDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.botonResetDB.Enabled = false;
            this.botonResetDB.Location = new System.Drawing.Point(915, 15);
            this.botonResetDB.Margin = new System.Windows.Forms.Padding(4);
            this.botonResetDB.Name = "botonResetDB";
            this.botonResetDB.Size = new System.Drawing.Size(205, 49);
            this.botonResetDB.TabIndex = 1;
            this.botonResetDB.Text = "Reiniciar base de datos";
            this.botonResetDB.UseVisualStyleBackColor = true;
            this.botonResetDB.Click += new System.EventHandler(this.botonBasesDeDatos_Click);
            // 
            // tabControlUsuario
            // 
            this.tabControlUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlUsuario.Controls.Add(this.tabPage1);
            this.tabControlUsuario.Controls.Add(this.tabPage2);
            this.tabControlUsuario.Location = new System.Drawing.Point(3, 71);
            this.tabControlUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.tabControlUsuario.Name = "tabControlUsuario";
            this.tabControlUsuario.SelectedIndex = 0;
            this.tabControlUsuario.Size = new System.Drawing.Size(1123, 606);
            this.tabControlUsuario.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panelEmpleado);
            this.tabPage1.Controls.Add(this.flowLayoutPanelEmpleado);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1115, 577);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Empleado";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panelEmpleado
            // 
            this.panelEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEmpleado.Controls.Add(this.checkBox1);
            this.panelEmpleado.Controls.Add(this.labelE10);
            this.panelEmpleado.Controls.Add(this.textBoxE8);
            this.panelEmpleado.Controls.Add(this.labelE9);
            this.panelEmpleado.Controls.Add(this.textBoxE7);
            this.panelEmpleado.Controls.Add(this.labelE8);
            this.panelEmpleado.Controls.Add(this.textBoxE6);
            this.panelEmpleado.Controls.Add(this.labelE6);
            this.panelEmpleado.Controls.Add(this.textBoxE4);
            this.panelEmpleado.Controls.Add(this.labelE7);
            this.panelEmpleado.Controls.Add(this.textBoxE5);
            this.panelEmpleado.Controls.Add(this.labelE5);
            this.panelEmpleado.Controls.Add(this.buttonE2);
            this.panelEmpleado.Controls.Add(this.dataGridViewE1);
            this.panelEmpleado.Controls.Add(this.textBoxE3);
            this.panelEmpleado.Controls.Add(this.labelE4);
            this.panelEmpleado.Controls.Add(this.textBoxE2);
            this.panelEmpleado.Controls.Add(this.buttonE1);
            this.panelEmpleado.Controls.Add(this.labelE2);
            this.panelEmpleado.Controls.Add(this.textBoxE1);
            this.panelEmpleado.Controls.Add(this.labelE3);
            this.panelEmpleado.Controls.Add(this.comboBoxE1);
            this.panelEmpleado.Controls.Add(this.labelE1);
            this.panelEmpleado.Location = new System.Drawing.Point(259, 4);
            this.panelEmpleado.Name = "panelEmpleado";
            this.panelEmpleado.Size = new System.Drawing.Size(849, 566);
            this.panelEmpleado.TabIndex = 8;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(24, 231);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(97, 20);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.Text = "Pago único";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // labelE10
            // 
            this.labelE10.AutoSize = true;
            this.labelE10.Location = new System.Drawing.Point(21, 385);
            this.labelE10.Name = "labelE10";
            this.labelE10.Size = new System.Drawing.Size(38, 16);
            this.labelE10.TabIndex = 30;
            this.labelE10.Text = "IBAN";
            this.labelE10.Visible = false;
            // 
            // textBoxE8
            // 
            this.textBoxE8.Location = new System.Drawing.Point(65, 379);
            this.textBoxE8.Name = "textBoxE8";
            this.textBoxE8.Size = new System.Drawing.Size(252, 22);
            this.textBoxE8.TabIndex = 29;
            this.textBoxE8.Visible = false;
            // 
            // labelE9
            // 
            this.labelE9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelE9.AutoSize = true;
            this.labelE9.Location = new System.Drawing.Point(638, 354);
            this.labelE9.Name = "labelE9";
            this.labelE9.Size = new System.Drawing.Size(89, 16);
            this.labelE9.TabIndex = 28;
            this.labelE9.Text = "código postal";
            this.labelE9.Visible = false;
            // 
            // textBoxE7
            // 
            this.textBoxE7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxE7.Location = new System.Drawing.Point(733, 348);
            this.textBoxE7.Name = "textBoxE7";
            this.textBoxE7.Size = new System.Drawing.Size(92, 22);
            this.textBoxE7.TabIndex = 27;
            this.textBoxE7.Visible = false;
            // 
            // labelE8
            // 
            this.labelE8.AutoSize = true;
            this.labelE8.Location = new System.Drawing.Point(21, 354);
            this.labelE8.Name = "labelE8";
            this.labelE8.Size = new System.Drawing.Size(62, 16);
            this.labelE8.TabIndex = 26;
            this.labelE8.Text = "dirección";
            this.labelE8.Visible = false;
            // 
            // textBoxE6
            // 
            this.textBoxE6.Location = new System.Drawing.Point(89, 351);
            this.textBoxE6.Name = "textBoxE6";
            this.textBoxE6.Size = new System.Drawing.Size(518, 22);
            this.textBoxE6.TabIndex = 25;
            this.textBoxE6.Visible = false;
            // 
            // labelE6
            // 
            this.labelE6.AutoSize = true;
            this.labelE6.Location = new System.Drawing.Point(21, 323);
            this.labelE6.Name = "labelE6";
            this.labelE6.Size = new System.Drawing.Size(53, 16);
            this.labelE6.TabIndex = 24;
            this.labelE6.Text = "nombre";
            this.labelE6.Visible = false;
            // 
            // textBoxE4
            // 
            this.textBoxE4.Location = new System.Drawing.Point(80, 320);
            this.textBoxE4.Name = "textBoxE4";
            this.textBoxE4.Size = new System.Drawing.Size(348, 22);
            this.textBoxE4.TabIndex = 23;
            this.textBoxE4.Visible = false;
            // 
            // labelE7
            // 
            this.labelE7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelE7.AutoSize = true;
            this.labelE7.Location = new System.Drawing.Point(652, 326);
            this.labelE7.Name = "labelE7";
            this.labelE7.Size = new System.Drawing.Size(25, 16);
            this.labelE7.TabIndex = 22;
            this.labelE7.Text = "dni";
            this.labelE7.Visible = false;
            // 
            // textBoxE5
            // 
            this.textBoxE5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxE5.Location = new System.Drawing.Point(683, 323);
            this.textBoxE5.Name = "textBoxE5";
            this.textBoxE5.Size = new System.Drawing.Size(142, 22);
            this.textBoxE5.TabIndex = 21;
            this.textBoxE5.Visible = false;
            // 
            // labelE5
            // 
            this.labelE5.AutoSize = true;
            this.labelE5.Location = new System.Drawing.Point(21, 294);
            this.labelE5.Name = "labelE5";
            this.labelE5.Size = new System.Drawing.Size(152, 16);
            this.labelE5.TabIndex = 20;
            this.labelE5.Text = "registracciòn estudiante:";
            this.labelE5.Visible = false;
            // 
            // buttonE2
            // 
            this.buttonE2.Location = new System.Drawing.Point(199, 202);
            this.buttonE2.Name = "buttonE2";
            this.buttonE2.Size = new System.Drawing.Size(75, 23);
            this.buttonE2.TabIndex = 19;
            this.buttonE2.Text = "buscar dni";
            this.buttonE2.UseVisualStyleBackColor = true;
            this.buttonE2.Visible = false;
            this.buttonE2.Click += new System.EventHandler(this.buttonE2_Click);
            // 
            // dataGridViewE1
            // 
            this.dataGridViewE1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewE1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewE1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.pagamento});
            this.dataGridViewE1.Location = new System.Drawing.Point(24, 203);
            this.dataGridViewE1.Name = "dataGridViewE1";
            this.dataGridViewE1.RowHeadersWidth = 51;
            this.dataGridViewE1.RowTemplate.Height = 24;
            this.dataGridViewE1.Size = new System.Drawing.Size(801, 340);
            this.dataGridViewE1.TabIndex = 18;
            this.dataGridViewE1.Visible = false;
            // 
            // nombre
            // 
            this.nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nombre.HeaderText = "nombre";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 82;
            // 
            // pagamento
            // 
            this.pagamento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pagamento.HeaderText = "pagamento";
            this.pagamento.MinimumWidth = 6;
            this.pagamento.Name = "pagamento";
            this.pagamento.ReadOnly = true;
            // 
            // textBoxE3
            // 
            this.textBoxE3.Location = new System.Drawing.Point(24, 203);
            this.textBoxE3.Name = "textBoxE3";
            this.textBoxE3.Size = new System.Drawing.Size(142, 22);
            this.textBoxE3.TabIndex = 17;
            this.textBoxE3.Visible = false;
            // 
            // labelE4
            // 
            this.labelE4.AutoSize = true;
            this.labelE4.Location = new System.Drawing.Point(314, 183);
            this.labelE4.Name = "labelE4";
            this.labelE4.Size = new System.Drawing.Size(293, 16);
            this.labelE4.TabIndex = 16;
            this.labelE4.Text = "Informaciones sobre el estudiante seleccionado";
            this.labelE4.Visible = false;
            // 
            // textBoxE2
            // 
            this.textBoxE2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxE2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxE2.Location = new System.Drawing.Point(317, 203);
            this.textBoxE2.Multiline = true;
            this.textBoxE2.Name = "textBoxE2";
            this.textBoxE2.ReadOnly = true;
            this.textBoxE2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxE2.Size = new System.Drawing.Size(509, 69);
            this.textBoxE2.TabIndex = 15;
            this.textBoxE2.Visible = false;
            // 
            // buttonE1
            // 
            this.buttonE1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonE1.Location = new System.Drawing.Point(697, 491);
            this.buttonE1.Name = "buttonE1";
            this.buttonE1.Size = new System.Drawing.Size(128, 52);
            this.buttonE1.TabIndex = 14;
            this.buttonE1.Text = "Inscribir";
            this.buttonE1.UseVisualStyleBackColor = true;
            this.buttonE1.Visible = false;
            this.buttonE1.Click += new System.EventHandler(this.buttonE1_Click);
            // 
            // labelE2
            // 
            this.labelE2.AutoSize = true;
            this.labelE2.Location = new System.Drawing.Point(314, 21);
            this.labelE2.Name = "labelE2";
            this.labelE2.Size = new System.Drawing.Size(322, 16);
            this.labelE2.TabIndex = 12;
            this.labelE2.Text = "Informaciones sobre el curso a impartir seleccionado";
            this.labelE2.Visible = false;
            // 
            // textBoxE1
            // 
            this.textBoxE1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxE1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxE1.Location = new System.Drawing.Point(317, 40);
            this.textBoxE1.Multiline = true;
            this.textBoxE1.Name = "textBoxE1";
            this.textBoxE1.ReadOnly = true;
            this.textBoxE1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxE1.Size = new System.Drawing.Size(509, 121);
            this.textBoxE1.TabIndex = 11;
            this.textBoxE1.Visible = false;
            // 
            // labelE3
            // 
            this.labelE3.AutoSize = true;
            this.labelE3.Location = new System.Drawing.Point(21, 183);
            this.labelE3.Name = "labelE3";
            this.labelE3.Size = new System.Drawing.Size(216, 16);
            this.labelE3.TabIndex = 9;
            this.labelE3.Text = "dni estudiante que quieres inscribir:";
            this.labelE3.Visible = false;
            // 
            // comboBoxE1
            // 
            this.comboBoxE1.FormattingEnabled = true;
            this.comboBoxE1.Location = new System.Drawing.Point(24, 40);
            this.comboBoxE1.Name = "comboBoxE1";
            this.comboBoxE1.Size = new System.Drawing.Size(250, 24);
            this.comboBoxE1.TabIndex = 0;
            this.comboBoxE1.Text = " - selecciona un curso a impartir - ";
            this.comboBoxE1.Visible = false;
            this.comboBoxE1.SelectedIndexChanged += new System.EventHandler(this.comboBoxE1_SelectedIndexChanged);
            // 
            // labelE1
            // 
            this.labelE1.AutoSize = true;
            this.labelE1.Location = new System.Drawing.Point(21, 21);
            this.labelE1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelE1.Name = "labelE1";
            this.labelE1.Size = new System.Drawing.Size(145, 16);
            this.labelE1.TabIndex = 7;
            this.labelE1.Text = "Selecciona una funcion";
            // 
            // flowLayoutPanelEmpleado
            // 
            this.flowLayoutPanelEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanelEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelEmpleado.Controls.Add(this.botonEmpleadoInscribirAlumnoEnCurso);
            this.flowLayoutPanelEmpleado.Controls.Add(this.botonEmpleadoMostrarAlumnosDeUnCurso);
            this.flowLayoutPanelEmpleado.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelEmpleado.Location = new System.Drawing.Point(3, 4);
            this.flowLayoutPanelEmpleado.Margin = new System.Windows.Forms.Padding(13, 4, 4, 4);
            this.flowLayoutPanelEmpleado.Name = "flowLayoutPanelEmpleado";
            this.flowLayoutPanelEmpleado.Size = new System.Drawing.Size(249, 566);
            this.flowLayoutPanelEmpleado.TabIndex = 5;
            // 
            // botonEmpleadoInscribirAlumnoEnCurso
            // 
            this.botonEmpleadoInscribirAlumnoEnCurso.Location = new System.Drawing.Point(4, 4);
            this.botonEmpleadoInscribirAlumnoEnCurso.Margin = new System.Windows.Forms.Padding(4, 4, 13, 4);
            this.botonEmpleadoInscribirAlumnoEnCurso.Name = "botonEmpleadoInscribirAlumnoEnCurso";
            this.botonEmpleadoInscribirAlumnoEnCurso.Size = new System.Drawing.Size(235, 49);
            this.botonEmpleadoInscribirAlumnoEnCurso.TabIndex = 1;
            this.botonEmpleadoInscribirAlumnoEnCurso.Text = "Inscribir alumno en curso";
            this.botonEmpleadoInscribirAlumnoEnCurso.UseVisualStyleBackColor = true;
            this.botonEmpleadoInscribirAlumnoEnCurso.Click += new System.EventHandler(this.botonInscribirAlumnoEnCurso_Click);
            // 
            // botonEmpleadoMostrarAlumnosDeUnCurso
            // 
            this.botonEmpleadoMostrarAlumnosDeUnCurso.Location = new System.Drawing.Point(4, 61);
            this.botonEmpleadoMostrarAlumnosDeUnCurso.Margin = new System.Windows.Forms.Padding(4, 4, 8, 4);
            this.botonEmpleadoMostrarAlumnosDeUnCurso.Name = "botonEmpleadoMostrarAlumnosDeUnCurso";
            this.botonEmpleadoMostrarAlumnosDeUnCurso.Size = new System.Drawing.Size(235, 49);
            this.botonEmpleadoMostrarAlumnosDeUnCurso.TabIndex = 0;
            this.botonEmpleadoMostrarAlumnosDeUnCurso.Text = "Mostrar alumnos de un curso";
            this.botonEmpleadoMostrarAlumnosDeUnCurso.UseVisualStyleBackColor = true;
            this.botonEmpleadoMostrarAlumnosDeUnCurso.Click += new System.EventHandler(this.botonMostrarAlumnosDeUnCurso_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panelAdministrador);
            this.tabPage2.Controls.Add(this.flowLayoutPanelAdministrador);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1115, 577);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Administrador";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panelAdministrador
            // 
            this.panelAdministrador.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelAdministrador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAdministrador.Controls.Add(this.labelA4);
            this.panelAdministrador.Controls.Add(this.textBoxA2);
            this.panelAdministrador.Controls.Add(this.buttonA1);
            this.panelAdministrador.Controls.Add(this.comboBoxA2);
            this.panelAdministrador.Controls.Add(this.labelA2);
            this.panelAdministrador.Controls.Add(this.textBoxA1);
            this.panelAdministrador.Controls.Add(this.labelA3);
            this.panelAdministrador.Controls.Add(this.comboBoxA1);
            this.panelAdministrador.Controls.Add(this.labelA1);
            this.panelAdministrador.Location = new System.Drawing.Point(259, 4);
            this.panelAdministrador.Name = "panelAdministrador";
            this.panelAdministrador.Size = new System.Drawing.Size(849, 566);
            this.panelAdministrador.TabIndex = 9;
            // 
            // labelA4
            // 
            this.labelA4.AutoSize = true;
            this.labelA4.Location = new System.Drawing.Point(314, 183);
            this.labelA4.Name = "labelA4";
            this.labelA4.Size = new System.Drawing.Size(293, 16);
            this.labelA4.TabIndex = 16;
            this.labelA4.Text = "Informaciones sobre el estudiante seleccionado";
            this.labelA4.Visible = false;
            // 
            // textBoxA2
            // 
            this.textBoxA2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxA2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxA2.Location = new System.Drawing.Point(317, 203);
            this.textBoxA2.Multiline = true;
            this.textBoxA2.Name = "textBoxA2";
            this.textBoxA2.ReadOnly = true;
            this.textBoxA2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxA2.Size = new System.Drawing.Size(509, 69);
            this.textBoxA2.TabIndex = 15;
            this.textBoxA2.Visible = false;
            // 
            // buttonA1
            // 
            this.buttonA1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonA1.Location = new System.Drawing.Point(697, 491);
            this.buttonA1.Name = "buttonA1";
            this.buttonA1.Size = new System.Drawing.Size(128, 52);
            this.buttonA1.TabIndex = 14;
            this.buttonA1.Text = "Asignar";
            this.buttonA1.UseVisualStyleBackColor = true;
            this.buttonA1.Visible = false;
            this.buttonA1.Click += new System.EventHandler(this.buttonA1_Click);
            // 
            // comboBoxA2
            // 
            this.comboBoxA2.FormattingEnabled = true;
            this.comboBoxA2.Location = new System.Drawing.Point(24, 203);
            this.comboBoxA2.Name = "comboBoxA2";
            this.comboBoxA2.Size = new System.Drawing.Size(250, 24);
            this.comboBoxA2.TabIndex = 13;
            this.comboBoxA2.Visible = false;
            this.comboBoxA2.SelectedIndexChanged += new System.EventHandler(this.comboBoxA2_SelectedIndexChanged);
            // 
            // labelA2
            // 
            this.labelA2.AutoSize = true;
            this.labelA2.Location = new System.Drawing.Point(314, 21);
            this.labelA2.Name = "labelA2";
            this.labelA2.Size = new System.Drawing.Size(322, 16);
            this.labelA2.TabIndex = 12;
            this.labelA2.Text = "Informaciones sobre el curso a impartir seleccionado";
            this.labelA2.Visible = false;
            // 
            // textBoxA1
            // 
            this.textBoxA1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxA1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxA1.Location = new System.Drawing.Point(317, 40);
            this.textBoxA1.Multiline = true;
            this.textBoxA1.Name = "textBoxA1";
            this.textBoxA1.ReadOnly = true;
            this.textBoxA1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxA1.Size = new System.Drawing.Size(509, 121);
            this.textBoxA1.TabIndex = 11;
            this.textBoxA1.Visible = false;
            // 
            // labelA3
            // 
            this.labelA3.AutoSize = true;
            this.labelA3.Location = new System.Drawing.Point(21, 183);
            this.labelA3.Name = "labelA3";
            this.labelA3.Size = new System.Drawing.Size(77, 16);
            this.labelA3.TabIndex = 9;
            this.labelA3.Text = "Seleccion 2";
            this.labelA3.Visible = false;
            // 
            // comboBoxA1
            // 
            this.comboBoxA1.FormattingEnabled = true;
            this.comboBoxA1.Location = new System.Drawing.Point(24, 40);
            this.comboBoxA1.Name = "comboBoxA1";
            this.comboBoxA1.Size = new System.Drawing.Size(250, 24);
            this.comboBoxA1.TabIndex = 0;
            this.comboBoxA1.Text = " - selecciona un curso a impartir - ";
            this.comboBoxA1.Visible = false;
            this.comboBoxA1.SelectedIndexChanged += new System.EventHandler(this.comboBoxA1_SelectedIndexChanged);
            // 
            // labelA1
            // 
            this.labelA1.AutoSize = true;
            this.labelA1.Location = new System.Drawing.Point(21, 21);
            this.labelA1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelA1.Name = "labelA1";
            this.labelA1.Size = new System.Drawing.Size(145, 16);
            this.labelA1.TabIndex = 7;
            this.labelA1.Text = "Selecciona una funcion";
            // 
            // flowLayoutPanelAdministrador
            // 
            this.flowLayoutPanelAdministrador.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.flowLayoutPanelAdministrador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelAdministrador.Controls.Add(this.botonAdministradorAsignarProfesorACurso);
            this.flowLayoutPanelAdministrador.Controls.Add(this.botonAdministradorAsignarAulaACurso);
            this.flowLayoutPanelAdministrador.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelAdministrador.Location = new System.Drawing.Point(3, 4);
            this.flowLayoutPanelAdministrador.Margin = new System.Windows.Forms.Padding(13, 4, 4, 4);
            this.flowLayoutPanelAdministrador.Name = "flowLayoutPanelAdministrador";
            this.flowLayoutPanelAdministrador.Size = new System.Drawing.Size(249, 566);
            this.flowLayoutPanelAdministrador.TabIndex = 2;
            // 
            // botonAdministradorAsignarProfesorACurso
            // 
            this.botonAdministradorAsignarProfesorACurso.Location = new System.Drawing.Point(4, 4);
            this.botonAdministradorAsignarProfesorACurso.Margin = new System.Windows.Forms.Padding(4, 4, 13, 4);
            this.botonAdministradorAsignarProfesorACurso.Name = "botonAdministradorAsignarProfesorACurso";
            this.botonAdministradorAsignarProfesorACurso.Size = new System.Drawing.Size(235, 49);
            this.botonAdministradorAsignarProfesorACurso.TabIndex = 1;
            this.botonAdministradorAsignarProfesorACurso.Text = "Asignar profesor a curso";
            this.botonAdministradorAsignarProfesorACurso.UseVisualStyleBackColor = true;
            this.botonAdministradorAsignarProfesorACurso.Click += new System.EventHandler(this.botonAsignarProfesorACurso_Click);
            // 
            // botonAdministradorAsignarAulaACurso
            // 
            this.botonAdministradorAsignarAulaACurso.Location = new System.Drawing.Point(4, 61);
            this.botonAdministradorAsignarAulaACurso.Margin = new System.Windows.Forms.Padding(4, 4, 8, 4);
            this.botonAdministradorAsignarAulaACurso.Name = "botonAdministradorAsignarAulaACurso";
            this.botonAdministradorAsignarAulaACurso.Size = new System.Drawing.Size(235, 49);
            this.botonAdministradorAsignarAulaACurso.TabIndex = 0;
            this.botonAdministradorAsignarAulaACurso.Text = "Asignar aula a curso";
            this.botonAdministradorAsignarAulaACurso.UseVisualStyleBackColor = true;
            this.botonAdministradorAsignarAulaACurso.Click += new System.EventHandler(this.botonAsignarAulaACurso_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 673);
            this.Controls.Add(this.tabControlUsuario);
            this.Controls.Add(this.botonResetDB);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Principal";
            this.Text = "GestAca GUI";
            this.tabControlUsuario.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panelEmpleado.ResumeLayout(false);
            this.panelEmpleado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewE1)).EndInit();
            this.flowLayoutPanelEmpleado.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panelAdministrador.ResumeLayout(false);
            this.panelAdministrador.PerformLayout();
            this.flowLayoutPanelAdministrador.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button botonResetDB;
        private System.Windows.Forms.TabControl tabControlUsuario;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAdministrador;
        private System.Windows.Forms.Button botonAdministradorAsignarAulaACurso;
        private System.Windows.Forms.Button botonAdministradorAsignarProfesorACurso;
        private System.Windows.Forms.Label labelE1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelEmpleado;
        private System.Windows.Forms.Button botonEmpleadoInscribirAlumnoEnCurso;
        private System.Windows.Forms.Button botonEmpleadoMostrarAlumnosDeUnCurso;
        private System.Windows.Forms.Panel panelEmpleado;
        private System.Windows.Forms.ComboBox comboBoxE1;
        private Label labelE3;
        private TextBox textBoxE1;
        private Label labelE2;
        private Button buttonE1;
        private Label labelE4;
        private TextBox textBoxE2;
        private Panel panelAdministrador;
        private Label labelA4;
        private TextBox textBoxA2;
        private Button buttonA1;
        private ComboBox comboBoxA2;
        private Label labelA2;
        private TextBox textBoxA1;
        private Label labelA3;
        private ComboBox comboBoxA1;
        private Label labelA1;


        //nuestros metodos
        private void ComboBoxE1InfoNotVisible()
        {
            this.labelE2.Visible = false;
            this.textBoxE1.Text = "";
            this.textBoxE1.Visible = false;
        }

        private void dataGridViewE1NotVisible()
        {
            this.labelE3.Visible = false;
            this.labelE3.Text = "";
            this.dataGridViewE1.Visible = false;
        }

        private void TextBoxE3InfoNotVisible()
        {
            this.labelE4.Visible = false;
            this.textBoxE2.Text = "";
            this.textBoxE2.Visible = false;
        }

        private void EnableStudentRegistration()
        {
            this.labelE5.Visible = true;
            this.labelE6.Visible = true;
            this.labelE7.Visible = true;
            this.labelE8.Visible = true;
            this.labelE9.Visible = true;
            this.labelE10.Visible = true;
            this.textBoxE4.Text = "";
            this.textBoxE4.Visible = true;
            this.textBoxE5.Text = "";
            this.textBoxE5.Visible = true;
            this.textBoxE6.Text = "";
            this.textBoxE6.Visible = true;
            this.textBoxE7.Text = "";
            this.textBoxE7.Visible = true;
            this.textBoxE8.Text = "";
            this.textBoxE8.Visible = true;
            this.buttonE1.Text = "Registrar";
            this.buttonE1.Enabled = true;
        }

        private void DisableStudentRegistration()
        {
            this.labelE5.Visible = false;
            this.labelE6.Visible = false;
            this.labelE7.Visible = false;
            this.labelE8.Visible = false;
            this.labelE9.Visible = false;
            this.labelE10.Visible = false;
            this.textBoxE4.Text = "";
            this.textBoxE4.Visible = false;
            this.textBoxE5.Text = "";
            this.textBoxE5.Visible = false;
            this.textBoxE6.Text = "";
            this.textBoxE6.Visible = false;
            this.textBoxE7.Text = "";
            this.textBoxE7.Visible = false;
            this.textBoxE8.Text = "";
            this.textBoxE8.Visible = false;
            this.buttonE1.Text = "Inscribir";
            this.buttonE1.Enabled = false;
        }

        private void ComboBoxE1ToDefaultResetGUI()
        {
            this.dataGridViewE1.Rows.Clear();
            this.dataGridViewE1.Visible = false;
            this.labelE3.Text = "";
            this.labelE3.Visible = false;
            this.textBoxE3.Visible = false;
            this.textBoxE3.Text = "";
            this.buttonE2.Visible = false;
            this.buttonE1.Enabled = false;
            this.buttonE1.Visible = false;
        }

        private void ResetEmpleadoGUI()
        {
            this.comboBoxE1.SelectedIndex = -1;
            this.checkBox1.Checked = false;
            this.checkBox1.Visible = false;
            this.checkBox1.Enabled = false;
            ComboBoxE1InfoNotVisible();
            TextBoxE3InfoNotVisible();
            ComboBoxE1ToDefaultResetGUI();
            DisableStudentRegistration();
        }

        private void ComboBoxA1InfoNotVisible()
        {
            this.labelA2.Visible = false;
            this.textBoxA1.Text = "";
            this.textBoxA1.Visible = false;
        }

        private void ComboBoxA2InfoNotVisible()
        {
            this.labelA4.Visible = false;
            this.textBoxA2.Text = "";
            this.textBoxA2.Visible = false;
        }

        private void ComboBoxA1ToDefaultResetGUI()
        {
            this.buttonA1.Enabled = false;
            this.buttonA1.Visible = false;
            this.comboBoxA2.Enabled = false;
            this.comboBoxA2.Visible = false;
            this.comboBoxA2.Enabled = false;
            this.labelA3.Text = "";
            this.labelA3.Visible = false;
        }

        private void ResetAdminGUI()
        {
            this.comboBoxA1.SelectedIndex = -1;
            this.comboBoxA2.SelectedIndex = -1;
            ComboBoxA1InfoNotVisible();
            ComboBoxA2InfoNotVisible();
            ComboBoxA1ToDefaultResetGUI();
        }

        private void ResetGUI()
        {
            ResetEmpleadoGUI();
            ResetAdminGUI();
        }

        private TextBox textBoxE3;
        private DataGridView dataGridViewE1;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn pagamento;
        private Button buttonE2;
        private TextBox textBoxE5;
        private Label labelE5;
        private Label labelE7;
        private Label labelE8;
        private TextBox textBoxE6;
        private Label labelE6;
        private TextBox textBoxE4;
        private Label labelE9;
        private TextBox textBoxE7;
        private Label labelE10;
        private TextBox textBoxE8;
        private CheckBox checkBox1;
    }
}

