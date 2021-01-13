namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Ayuda = new System.Windows.Forms.Button();
            this.Registrarse = new System.Windows.Forms.Button();
            this.Iniciar_sesion = new System.Windows.Forms.Button();
            this.groupBox_registro = new System.Windows.Forms.GroupBox();
            this.Contraseña_Registro = new System.Windows.Forms.TextBox();
            this.Nombre_Registro = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Registrarse_Button = new System.Windows.Forms.Button();
            this.groupBox_inciar = new System.Windows.Forms.GroupBox();
            this.Contraseña = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Iniciar_Button = new System.Windows.Forms.Button();
            this.QuererConsulta = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Cancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Invitados_textBox = new System.Windows.Forms.TextBox();
            this.dosCdos = new System.Windows.Forms.RadioButton();
            this.unoCuno = new System.Windows.Forms.RadioButton();
            this.Conectados_groupBox = new System.Windows.Forms.GroupBox();
            this.Conectados_Grid = new System.Windows.Forms.DataGridView();
            this.Invitar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.IniciarPartida = new System.Windows.Forms.Button();
            this.Invitacion_groupBox = new System.Windows.Forms.GroupBox();
            this.invitacion_label = new System.Windows.Forms.Label();
            this.rechazar_button = new System.Windows.Forms.Button();
            this.aceptar_button = new System.Windows.Forms.Button();
            this.Desconectar = new System.Windows.Forms.Button();
            this.Dar_baja = new System.Windows.Forms.Button();
            this.Baja_groupBox = new System.Windows.Forms.GroupBox();
            this.contrasena_baja = new System.Windows.Forms.TextBox();
            this.baja_nombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Baja_button = new System.Windows.Forms.Button();
            this.timer_invitar = new System.Windows.Forms.Timer(this.components);
            this.timer_iniciar_partida = new System.Windows.Forms.Timer(this.components);
            this.Invitacion_Grid = new System.Windows.Forms.DataGridView();
            this.Invitaciones_groupBox = new System.Windows.Forms.GroupBox();
            this.Invitacion_textBox = new System.Windows.Forms.TextBox();
            this.groupBox_registro.SuspendLayout();
            this.groupBox_inciar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Conectados_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Conectados_Grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.Invitacion_groupBox.SuspendLayout();
            this.Baja_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Invitacion_Grid)).BeginInit();
            this.Invitaciones_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(105, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(348, 169);
            this.panel1.TabIndex = 13;
            // 
            // Ayuda
            // 
            this.Ayuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.Ayuda.Location = new System.Drawing.Point(244, 181);
            this.Ayuda.Name = "Ayuda";
            this.Ayuda.Size = new System.Drawing.Size(73, 25);
            this.Ayuda.TabIndex = 8;
            this.Ayuda.Text = "Ayuda";
            this.Ayuda.UseVisualStyleBackColor = true;
            // 
            // Registrarse
            // 
            this.Registrarse.Location = new System.Drawing.Point(218, 262);
            this.Registrarse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Registrarse.Name = "Registrarse";
            this.Registrarse.Size = new System.Drawing.Size(127, 36);
            this.Registrarse.TabIndex = 11;
            this.Registrarse.Text = "Registrarse";
            this.Registrarse.UseVisualStyleBackColor = true;
            this.Registrarse.Click += new System.EventHandler(this.Registrarse_Click);
            // 
            // Iniciar_sesion
            // 
            this.Iniciar_sesion.Location = new System.Drawing.Point(218, 212);
            this.Iniciar_sesion.Name = "Iniciar_sesion";
            this.Iniciar_sesion.Size = new System.Drawing.Size(127, 37);
            this.Iniciar_sesion.TabIndex = 10;
            this.Iniciar_sesion.Text = "Iniciar sesión";
            this.Iniciar_sesion.UseVisualStyleBackColor = true;
            this.Iniciar_sesion.Click += new System.EventHandler(this.Iniciar_sesion_Click);
            // 
            // groupBox_registro
            // 
            this.groupBox_registro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox_registro.Controls.Add(this.Contraseña_Registro);
            this.groupBox_registro.Controls.Add(this.Nombre_Registro);
            this.groupBox_registro.Controls.Add(this.label5);
            this.groupBox_registro.Controls.Add(this.label6);
            this.groupBox_registro.Controls.Add(this.Registrarse_Button);
            this.groupBox_registro.Location = new System.Drawing.Point(55, 360);
            this.groupBox_registro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_registro.Name = "groupBox_registro";
            this.groupBox_registro.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_registro.Size = new System.Drawing.Size(461, 100);
            this.groupBox_registro.TabIndex = 9;
            this.groupBox_registro.TabStop = false;
            this.groupBox_registro.Text = "¿No tienes cuenta? Regístrate";
            this.groupBox_registro.Visible = false;
            // 
            // Contraseña_Registro
            // 
            this.Contraseña_Registro.Location = new System.Drawing.Point(107, 60);
            this.Contraseña_Registro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Contraseña_Registro.Name = "Contraseña_Registro";
            this.Contraseña_Registro.Size = new System.Drawing.Size(100, 22);
            this.Contraseña_Registro.TabIndex = 12;
            // 
            // Nombre_Registro
            // 
            this.Nombre_Registro.Location = new System.Drawing.Point(107, 28);
            this.Nombre_Registro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Nombre_Registro.Name = "Nombre_Registro";
            this.Nombre_Registro.Size = new System.Drawing.Size(100, 22);
            this.Nombre_Registro.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nombre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Contraseña";
            // 
            // Registrarse_Button
            // 
            this.Registrarse_Button.Location = new System.Drawing.Point(325, 58);
            this.Registrarse_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Registrarse_Button.Name = "Registrarse_Button";
            this.Registrarse_Button.Size = new System.Drawing.Size(101, 27);
            this.Registrarse_Button.TabIndex = 3;
            this.Registrarse_Button.Text = "Registrarse";
            this.Registrarse_Button.UseVisualStyleBackColor = true;
            this.Registrarse_Button.Click += new System.EventHandler(this.Registrarse_Button_Click);
            // 
            // groupBox_inciar
            // 
            this.groupBox_inciar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.groupBox_inciar.Controls.Add(this.Contraseña);
            this.groupBox_inciar.Controls.Add(this.Nombre);
            this.groupBox_inciar.Controls.Add(this.label2);
            this.groupBox_inciar.Controls.Add(this.label1);
            this.groupBox_inciar.Controls.Add(this.Iniciar_Button);
            this.groupBox_inciar.Location = new System.Drawing.Point(49, 364);
            this.groupBox_inciar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_inciar.Name = "groupBox_inciar";
            this.groupBox_inciar.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_inciar.Size = new System.Drawing.Size(464, 100);
            this.groupBox_inciar.TabIndex = 8;
            this.groupBox_inciar.TabStop = false;
            this.groupBox_inciar.Text = "Iniciar sesión";
            this.groupBox_inciar.Visible = false;
            // 
            // Contraseña
            // 
            this.Contraseña.Location = new System.Drawing.Point(109, 60);
            this.Contraseña.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Contraseña.Name = "Contraseña";
            this.Contraseña.Size = new System.Drawing.Size(100, 22);
            this.Contraseña.TabIndex = 8;
            // 
            // Nombre
            // 
            this.Nombre.Location = new System.Drawing.Point(109, 28);
            this.Nombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(100, 22);
            this.Nombre.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Contraseña";
            // 
            // Iniciar_Button
            // 
            this.Iniciar_Button.Location = new System.Drawing.Point(311, 63);
            this.Iniciar_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Iniciar_Button.Name = "Iniciar_Button";
            this.Iniciar_Button.Size = new System.Drawing.Size(120, 31);
            this.Iniciar_Button.TabIndex = 4;
            this.Iniciar_Button.Text = "Iniciar sesión";
            this.Iniciar_Button.UseVisualStyleBackColor = true;
            this.Iniciar_Button.Click += new System.EventHandler(this.Iniciar_Button_Click);
            // 
            // QuererConsulta
            // 
            this.QuererConsulta.Location = new System.Drawing.Point(830, 61);
            this.QuererConsulta.Name = "QuererConsulta";
            this.QuererConsulta.Size = new System.Drawing.Size(207, 36);
            this.QuererConsulta.TabIndex = 35;
            this.QuererConsulta.Text = "Quiero hacer una consulta";
            this.QuererConsulta.UseVisualStyleBackColor = true;
            this.QuererConsulta.Click += new System.EventHandler(this.QuererConsulta_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Cancelar);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Invitados_textBox);
            this.groupBox2.Controls.Add(this.dosCdos);
            this.groupBox2.Controls.Add(this.unoCuno);
            this.groupBox2.Location = new System.Drawing.Point(784, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 215);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Modo";
            // 
            // Cancelar
            // 
            this.Cancelar.Location = new System.Drawing.Point(29, 166);
            this.Cancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(187, 34);
            this.Cancelar.TabIndex = 8;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = true;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Jugar partida con:";
            // 
            // Invitados_textBox
            // 
            this.Invitados_textBox.Location = new System.Drawing.Point(16, 126);
            this.Invitados_textBox.Name = "Invitados_textBox";
            this.Invitados_textBox.Size = new System.Drawing.Size(222, 22);
            this.Invitados_textBox.TabIndex = 16;
            // 
            // dosCdos
            // 
            this.dosCdos.AutoSize = true;
            this.dosCdos.Location = new System.Drawing.Point(16, 65);
            this.dosCdos.Name = "dosCdos";
            this.dosCdos.Size = new System.Drawing.Size(93, 21);
            this.dosCdos.TabIndex = 15;
            this.dosCdos.TabStop = true;
            this.dosCdos.Text = "2 contra 2";
            this.dosCdos.UseVisualStyleBackColor = true;
            // 
            // unoCuno
            // 
            this.unoCuno.AutoSize = true;
            this.unoCuno.Location = new System.Drawing.Point(16, 31);
            this.unoCuno.Name = "unoCuno";
            this.unoCuno.Size = new System.Drawing.Size(93, 21);
            this.unoCuno.TabIndex = 14;
            this.unoCuno.TabStop = true;
            this.unoCuno.Text = "1 contra 1";
            this.unoCuno.UseVisualStyleBackColor = true;
            // 
            // Conectados_groupBox
            // 
            this.Conectados_groupBox.Controls.Add(this.Conectados_Grid);
            this.Conectados_groupBox.Controls.Add(this.Invitar);
            this.Conectados_groupBox.Location = new System.Drawing.Point(569, 107);
            this.Conectados_groupBox.Name = "Conectados_groupBox";
            this.Conectados_groupBox.Size = new System.Drawing.Size(209, 215);
            this.Conectados_groupBox.TabIndex = 32;
            this.Conectados_groupBox.TabStop = false;
            this.Conectados_groupBox.Text = "En línea:";
            // 
            // Conectados_Grid
            // 
            this.Conectados_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Conectados_Grid.ColumnHeadersVisible = false;
            this.Conectados_Grid.Location = new System.Drawing.Point(13, 20);
            this.Conectados_Grid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Conectados_Grid.Name = "Conectados_Grid";
            this.Conectados_Grid.RowHeadersVisible = false;
            this.Conectados_Grid.RowTemplate.Height = 24;
            this.Conectados_Grid.Size = new System.Drawing.Size(187, 150);
            this.Conectados_Grid.TabIndex = 6;
            this.Conectados_Grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Conectados_Grid_CellContentClick);
            // 
            // Invitar
            // 
            this.Invitar.Location = new System.Drawing.Point(13, 174);
            this.Invitar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Invitar.Name = "Invitar";
            this.Invitar.Size = new System.Drawing.Size(187, 34);
            this.Invitar.TabIndex = 7;
            this.Invitar.Text = "Invitar";
            this.Invitar.UseVisualStyleBackColor = true;
            this.Invitar.Click += new System.EventHandler(this.Invitar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.IndianRed;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(1088, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 96);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(172, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Esperando una respuesta";
            // 
            // IniciarPartida
            // 
            this.IniciarPartida.Location = new System.Drawing.Point(321, 192);
            this.IniciarPartida.Name = "IniciarPartida";
            this.IniciarPartida.Size = new System.Drawing.Size(139, 36);
            this.IniciarPartida.TabIndex = 36;
            this.IniciarPartida.Text = "Iniciar partida";
            this.IniciarPartida.UseVisualStyleBackColor = true;
            this.IniciarPartida.Click += new System.EventHandler(this.IniciarPartida_Click);
            // 
            // Invitacion_groupBox
            // 
            this.Invitacion_groupBox.BackColor = System.Drawing.Color.LightGreen;
            this.Invitacion_groupBox.Controls.Add(this.invitacion_label);
            this.Invitacion_groupBox.ForeColor = System.Drawing.Color.Black;
            this.Invitacion_groupBox.Location = new System.Drawing.Point(1088, 364);
            this.Invitacion_groupBox.Name = "Invitacion_groupBox";
            this.Invitacion_groupBox.Size = new System.Drawing.Size(253, 96);
            this.Invitacion_groupBox.TabIndex = 33;
            this.Invitacion_groupBox.TabStop = false;
            this.Invitacion_groupBox.Text = "Tienes una invitación";
            this.Invitacion_groupBox.Visible = false;
            // 
            // invitacion_label
            // 
            this.invitacion_label.AutoSize = true;
            this.invitacion_label.Location = new System.Drawing.Point(26, 24);
            this.invitacion_label.Name = "invitacion_label";
            this.invitacion_label.Size = new System.Drawing.Size(186, 17);
            this.invitacion_label.TabIndex = 0;
            this.invitacion_label.Text = "No tienes ninguna invitación";
            // 
            // rechazar_button
            // 
            this.rechazar_button.Location = new System.Drawing.Point(217, 190);
            this.rechazar_button.Name = "rechazar_button";
            this.rechazar_button.Size = new System.Drawing.Size(98, 38);
            this.rechazar_button.TabIndex = 2;
            this.rechazar_button.Text = "Rechazar";
            this.rechazar_button.UseVisualStyleBackColor = true;
            this.rechazar_button.Click += new System.EventHandler(this.rechazar_button_Click);
            // 
            // aceptar_button
            // 
            this.aceptar_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.aceptar_button.Location = new System.Drawing.Point(114, 190);
            this.aceptar_button.Name = "aceptar_button";
            this.aceptar_button.Size = new System.Drawing.Size(97, 38);
            this.aceptar_button.TabIndex = 1;
            this.aceptar_button.Text = "Aceptar";
            this.aceptar_button.UseVisualStyleBackColor = false;
            this.aceptar_button.Click += new System.EventHandler(this.aceptar_button_Click);
            // 
            // Desconectar
            // 
            this.Desconectar.Location = new System.Drawing.Point(569, 61);
            this.Desconectar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Size = new System.Drawing.Size(130, 36);
            this.Desconectar.TabIndex = 31;
            this.Desconectar.Text = "Desconectar";
            this.Desconectar.UseVisualStyleBackColor = true;
            this.Desconectar.Click += new System.EventHandler(this.Desconectar_Click);
            // 
            // Dar_baja
            // 
            this.Dar_baja.Location = new System.Drawing.Point(218, 308);
            this.Dar_baja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dar_baja.Name = "Dar_baja";
            this.Dar_baja.Size = new System.Drawing.Size(127, 36);
            this.Dar_baja.TabIndex = 37;
            this.Dar_baja.Text = "Dar de baja";
            this.Dar_baja.UseVisualStyleBackColor = true;
            this.Dar_baja.Click += new System.EventHandler(this.Dar_baja_Click);
            // 
            // Baja_groupBox
            // 
            this.Baja_groupBox.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Baja_groupBox.Controls.Add(this.contrasena_baja);
            this.Baja_groupBox.Controls.Add(this.baja_nombre);
            this.Baja_groupBox.Controls.Add(this.label4);
            this.Baja_groupBox.Controls.Add(this.label7);
            this.Baja_groupBox.Controls.Add(this.Baja_button);
            this.Baja_groupBox.Location = new System.Drawing.Point(55, 499);
            this.Baja_groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Baja_groupBox.Name = "Baja_groupBox";
            this.Baja_groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Baja_groupBox.Size = new System.Drawing.Size(467, 100);
            this.Baja_groupBox.TabIndex = 13;
            this.Baja_groupBox.TabStop = false;
            this.Baja_groupBox.Text = "¿Quieres eliminar tu cuenta?";
            this.Baja_groupBox.Visible = false;
            // 
            // contrasena_baja
            // 
            this.contrasena_baja.Location = new System.Drawing.Point(107, 60);
            this.contrasena_baja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.contrasena_baja.Name = "contrasena_baja";
            this.contrasena_baja.Size = new System.Drawing.Size(100, 22);
            this.contrasena_baja.TabIndex = 12;
            // 
            // baja_nombre
            // 
            this.baja_nombre.Location = new System.Drawing.Point(107, 28);
            this.baja_nombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.baja_nombre.Name = "baja_nombre";
            this.baja_nombre.Size = new System.Drawing.Size(100, 22);
            this.baja_nombre.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Nombre";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 17);
            this.label7.TabIndex = 9;
            this.label7.Text = "Contraseña";
            // 
            // Baja_button
            // 
            this.Baja_button.Location = new System.Drawing.Point(292, 58);
            this.Baja_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Baja_button.Name = "Baja_button";
            this.Baja_button.Size = new System.Drawing.Size(134, 27);
            this.Baja_button.TabIndex = 3;
            this.Baja_button.Text = "Darme de baja";
            this.Baja_button.UseVisualStyleBackColor = true;
            this.Baja_button.Click += new System.EventHandler(this.Baja_button_Click);
            // 
            // Invitacion_Grid
            // 
            this.Invitacion_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Invitacion_Grid.ColumnHeadersVisible = false;
            this.Invitacion_Grid.Location = new System.Drawing.Point(6, 29);
            this.Invitacion_Grid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Invitacion_Grid.Name = "Invitacion_Grid";
            this.Invitacion_Grid.RowHeadersVisible = false;
            this.Invitacion_Grid.RowTemplate.Height = 24;
            this.Invitacion_Grid.Size = new System.Drawing.Size(447, 150);
            this.Invitacion_Grid.TabIndex = 8;
            this.Invitacion_Grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Invitacion_Grid_CellContentClick);
            // 
            // Invitaciones_groupBox
            // 
            this.Invitaciones_groupBox.Controls.Add(this.rechazar_button);
            this.Invitaciones_groupBox.Controls.Add(this.Invitacion_textBox);
            this.Invitaciones_groupBox.Controls.Add(this.aceptar_button);
            this.Invitaciones_groupBox.Controls.Add(this.Invitacion_Grid);
            this.Invitaciones_groupBox.Controls.Add(this.IniciarPartida);
            this.Invitaciones_groupBox.Location = new System.Drawing.Point(569, 345);
            this.Invitaciones_groupBox.Name = "Invitaciones_groupBox";
            this.Invitaciones_groupBox.Size = new System.Drawing.Size(468, 239);
            this.Invitaciones_groupBox.TabIndex = 38;
            this.Invitaciones_groupBox.TabStop = false;
            this.Invitaciones_groupBox.Text = "Invitaciones:";
            // 
            // Invitacion_textBox
            // 
            this.Invitacion_textBox.Location = new System.Drawing.Point(6, 198);
            this.Invitacion_textBox.Name = "Invitacion_textBox";
            this.Invitacion_textBox.Size = new System.Drawing.Size(93, 22);
            this.Invitacion_textBox.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 628);
            this.Controls.Add(this.Invitaciones_groupBox);
            this.Controls.Add(this.Baja_groupBox);
            this.Controls.Add(this.Dar_baja);
            this.Controls.Add(this.Ayuda);
            this.Controls.Add(this.QuererConsulta);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Conectados_groupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Invitacion_groupBox);
            this.Controls.Add(this.Desconectar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Registrarse);
            this.Controls.Add(this.Iniciar_sesion);
            this.Controls.Add(this.groupBox_registro);
            this.Controls.Add(this.groupBox_inciar);
            this.Name = "Form1";
            this.Text = " Inicio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox_registro.ResumeLayout(false);
            this.groupBox_registro.PerformLayout();
            this.groupBox_inciar.ResumeLayout(false);
            this.groupBox_inciar.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Conectados_groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Conectados_Grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Invitacion_groupBox.ResumeLayout(false);
            this.Invitacion_groupBox.PerformLayout();
            this.Baja_groupBox.ResumeLayout(false);
            this.Baja_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Invitacion_Grid)).EndInit();
            this.Invitaciones_groupBox.ResumeLayout(false);
            this.Invitaciones_groupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Ayuda;
        private System.Windows.Forms.Button Registrarse;
        private System.Windows.Forms.Button Iniciar_sesion;
        private System.Windows.Forms.GroupBox groupBox_registro;
        private System.Windows.Forms.TextBox Contraseña_Registro;
        private System.Windows.Forms.TextBox Nombre_Registro;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Registrarse_Button;
        private System.Windows.Forms.GroupBox groupBox_inciar;
        private System.Windows.Forms.TextBox Contraseña;
        private System.Windows.Forms.TextBox Nombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Iniciar_Button;
        private System.Windows.Forms.Button QuererConsulta;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Invitados_textBox;
        private System.Windows.Forms.RadioButton dosCdos;
        private System.Windows.Forms.RadioButton unoCuno;
        private System.Windows.Forms.GroupBox Conectados_groupBox;
        private System.Windows.Forms.DataGridView Conectados_Grid;
        private System.Windows.Forms.Button Invitar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox Invitacion_groupBox;
        private System.Windows.Forms.Button rechazar_button;
        private System.Windows.Forms.Button aceptar_button;
        private System.Windows.Forms.Label invitacion_label;
        private System.Windows.Forms.Button Desconectar;
        private System.Windows.Forms.Button IniciarPartida;
        private System.Windows.Forms.Button Dar_baja;
        private System.Windows.Forms.GroupBox Baja_groupBox;
        private System.Windows.Forms.TextBox contrasena_baja;
        private System.Windows.Forms.TextBox baja_nombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Baja_button;
        private System.Windows.Forms.Timer timer_invitar;
        private System.Windows.Forms.Timer timer_iniciar_partida;
        private System.Windows.Forms.DataGridView Invitacion_Grid;
        private System.Windows.Forms.GroupBox Invitaciones_groupBox;
        private System.Windows.Forms.TextBox Invitacion_textBox;
    }
}

