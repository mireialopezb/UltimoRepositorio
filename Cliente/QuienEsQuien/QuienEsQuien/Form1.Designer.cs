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
            this.Registrarse_Button = new System.Windows.Forms.Button();
            this.groupBox_inciar = new System.Windows.Forms.GroupBox();
            this.Contraseña = new System.Windows.Forms.TextBox();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Baja_button = new System.Windows.Forms.Button();
            this.Iniciar_Button = new System.Windows.Forms.Button();
            this.QuererConsulta = new System.Windows.Forms.Button();
            this.Cancelar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Invitados_textBox = new System.Windows.Forms.TextBox();
            this.Conectados_groupBox = new System.Windows.Forms.GroupBox();
            this.Conectados_Grid = new System.Windows.Forms.DataGridView();
            this.Invitar = new System.Windows.Forms.Button();
            this.IniciarPartida = new System.Windows.Forms.Button();
            this.rechazar_button = new System.Windows.Forms.Button();
            this.aceptar_button = new System.Windows.Forms.Button();
            this.Desconectar = new System.Windows.Forms.Button();
            this.Dar_baja = new System.Windows.Forms.Button();
            this.timer_invitar = new System.Windows.Forms.Timer(this.components);
            this.Invitacion_Grid = new System.Windows.Forms.DataGridView();
            this.Invitaciones_groupBox = new System.Windows.Forms.GroupBox();
            this.Invitacion_textBox = new System.Windows.Forms.TextBox();
            this.Usuario_lbl = new System.Windows.Forms.Label();
            this.groupBox_inciar.SuspendLayout();
            this.Conectados_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Conectados_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Invitacion_Grid)).BeginInit();
            this.Invitaciones_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(157, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 207);
            this.panel1.TabIndex = 13;
            // 
            // Ayuda
            // 
            this.Ayuda.BackColor = System.Drawing.Color.Transparent;
            this.Ayuda.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Ayuda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Ayuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.Ayuda.Location = new System.Drawing.Point(478, 214);
            this.Ayuda.Name = "Ayuda";
            this.Ayuda.Size = new System.Drawing.Size(113, 36);
            this.Ayuda.TabIndex = 8;
            this.Ayuda.Text = "Ayuda";
            this.Ayuda.UseVisualStyleBackColor = false;
            this.Ayuda.Visible = false;
            this.Ayuda.Click += new System.EventHandler(this.Ayuda_Click);
            // 
            // Registrarse
            // 
            this.Registrarse.BackColor = System.Drawing.Color.Transparent;
            this.Registrarse.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Registrarse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Registrarse.Location = new System.Drawing.Point(302, 258);
            this.Registrarse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Registrarse.Name = "Registrarse";
            this.Registrarse.Size = new System.Drawing.Size(127, 36);
            this.Registrarse.TabIndex = 11;
            this.Registrarse.Text = "Registrarse";
            this.Registrarse.UseVisualStyleBackColor = false;
            this.Registrarse.Click += new System.EventHandler(this.Registrarse_Click);
            // 
            // Iniciar_sesion
            // 
            this.Iniciar_sesion.BackColor = System.Drawing.Color.Transparent;
            this.Iniciar_sesion.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Iniciar_sesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Iniciar_sesion.Location = new System.Drawing.Point(302, 208);
            this.Iniciar_sesion.Name = "Iniciar_sesion";
            this.Iniciar_sesion.Size = new System.Drawing.Size(127, 37);
            this.Iniciar_sesion.TabIndex = 10;
            this.Iniciar_sesion.Text = "Iniciar sesión";
            this.Iniciar_sesion.UseVisualStyleBackColor = false;
            this.Iniciar_sesion.Click += new System.EventHandler(this.Iniciar_sesion_Click);
            // 
            // Registrarse_Button
            // 
            this.Registrarse_Button.BackColor = System.Drawing.Color.Transparent;
            this.Registrarse_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Registrarse_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Registrarse_Button.Location = new System.Drawing.Point(299, 44);
            this.Registrarse_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Registrarse_Button.Name = "Registrarse_Button";
            this.Registrarse_Button.Size = new System.Drawing.Size(101, 36);
            this.Registrarse_Button.TabIndex = 3;
            this.Registrarse_Button.Text = "Registrarse";
            this.Registrarse_Button.UseVisualStyleBackColor = false;
            this.Registrarse_Button.Click += new System.EventHandler(this.Registrarse_Button_Click);
            // 
            // groupBox_inciar
            // 
            this.groupBox_inciar.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_inciar.Controls.Add(this.Contraseña);
            this.groupBox_inciar.Controls.Add(this.Nombre);
            this.groupBox_inciar.Controls.Add(this.label2);
            this.groupBox_inciar.Controls.Add(this.label1);
            this.groupBox_inciar.Controls.Add(this.Baja_button);
            this.groupBox_inciar.Controls.Add(this.Registrarse_Button);
            this.groupBox_inciar.Controls.Add(this.Iniciar_Button);
            this.groupBox_inciar.Location = new System.Drawing.Point(148, 361);
            this.groupBox_inciar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_inciar.Name = "groupBox_inciar";
            this.groupBox_inciar.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_inciar.Size = new System.Drawing.Size(423, 100);
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
            // Baja_button
            // 
            this.Baja_button.BackColor = System.Drawing.Color.Transparent;
            this.Baja_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Baja_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Baja_button.Location = new System.Drawing.Point(262, 46);
            this.Baja_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Baja_button.Name = "Baja_button";
            this.Baja_button.Size = new System.Drawing.Size(138, 32);
            this.Baja_button.TabIndex = 3;
            this.Baja_button.Text = "Darme de baja";
            this.Baja_button.UseVisualStyleBackColor = false;
            this.Baja_button.Click += new System.EventHandler(this.Baja_button_Click);
            // 
            // Iniciar_Button
            // 
            this.Iniciar_Button.BackColor = System.Drawing.Color.Transparent;
            this.Iniciar_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Iniciar_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Iniciar_Button.Location = new System.Drawing.Point(280, 47);
            this.Iniciar_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Iniciar_Button.Name = "Iniciar_Button";
            this.Iniciar_Button.Size = new System.Drawing.Size(120, 31);
            this.Iniciar_Button.TabIndex = 4;
            this.Iniciar_Button.Text = "Iniciar sesión";
            this.Iniciar_Button.UseVisualStyleBackColor = false;
            this.Iniciar_Button.Click += new System.EventHandler(this.Iniciar_Button_Click);
            // 
            // QuererConsulta
            // 
            this.QuererConsulta.BackColor = System.Drawing.Color.Transparent;
            this.QuererConsulta.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.QuererConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.QuererConsulta.Location = new System.Drawing.Point(265, 214);
            this.QuererConsulta.Name = "QuererConsulta";
            this.QuererConsulta.Size = new System.Drawing.Size(207, 36);
            this.QuererConsulta.TabIndex = 35;
            this.QuererConsulta.Text = "Quiero hacer una consulta";
            this.QuererConsulta.UseVisualStyleBackColor = false;
            this.QuererConsulta.Visible = false;
            this.QuererConsulta.Click += new System.EventHandler(this.QuererConsulta_Click);
            // 
            // Cancelar
            // 
            this.Cancelar.BackColor = System.Drawing.Color.Transparent;
            this.Cancelar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancelar.Location = new System.Drawing.Point(13, 265);
            this.Cancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cancelar.Name = "Cancelar";
            this.Cancelar.Size = new System.Drawing.Size(187, 34);
            this.Cancelar.TabIndex = 8;
            this.Cancelar.Text = "Cancelar";
            this.Cancelar.UseVisualStyleBackColor = false;
            this.Cancelar.Click += new System.EventHandler(this.Cancelar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Jugar partida con:";
            // 
            // Invitados_textBox
            // 
            this.Invitados_textBox.Location = new System.Drawing.Point(13, 200);
            this.Invitados_textBox.Name = "Invitados_textBox";
            this.Invitados_textBox.Size = new System.Drawing.Size(185, 22);
            this.Invitados_textBox.TabIndex = 16;
            // 
            // Conectados_groupBox
            // 
            this.Conectados_groupBox.BackColor = System.Drawing.Color.Transparent;
            this.Conectados_groupBox.Controls.Add(this.Cancelar);
            this.Conectados_groupBox.Controls.Add(this.Conectados_Grid);
            this.Conectados_groupBox.Controls.Add(this.label3);
            this.Conectados_groupBox.Controls.Add(this.Invitar);
            this.Conectados_groupBox.Controls.Add(this.Invitados_textBox);
            this.Conectados_groupBox.Location = new System.Drawing.Point(41, 205);
            this.Conectados_groupBox.Name = "Conectados_groupBox";
            this.Conectados_groupBox.Size = new System.Drawing.Size(209, 320);
            this.Conectados_groupBox.TabIndex = 32;
            this.Conectados_groupBox.TabStop = false;
            this.Conectados_groupBox.Text = "En línea:";
            this.Conectados_groupBox.Visible = false;
            // 
            // Conectados_Grid
            // 
            this.Conectados_Grid.BackgroundColor = System.Drawing.Color.White;
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
            this.Invitar.BackColor = System.Drawing.Color.Transparent;
            this.Invitar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Invitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Invitar.Location = new System.Drawing.Point(13, 227);
            this.Invitar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Invitar.Name = "Invitar";
            this.Invitar.Size = new System.Drawing.Size(187, 34);
            this.Invitar.TabIndex = 7;
            this.Invitar.Text = "Invitar";
            this.Invitar.UseVisualStyleBackColor = false;
            this.Invitar.Click += new System.EventHandler(this.Invitar_Click);
            // 
            // IniciarPartida
            // 
            this.IniciarPartida.BackColor = System.Drawing.Color.Transparent;
            this.IniciarPartida.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.IniciarPartida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IniciarPartida.Location = new System.Drawing.Point(321, 223);
            this.IniciarPartida.Name = "IniciarPartida";
            this.IniciarPartida.Size = new System.Drawing.Size(139, 36);
            this.IniciarPartida.TabIndex = 36;
            this.IniciarPartida.Text = "Iniciar partida";
            this.IniciarPartida.UseVisualStyleBackColor = false;
            this.IniciarPartida.Click += new System.EventHandler(this.IniciarPartida_Click);
            // 
            // rechazar_button
            // 
            this.rechazar_button.BackColor = System.Drawing.Color.Transparent;
            this.rechazar_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.rechazar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rechazar_button.Location = new System.Drawing.Point(217, 221);
            this.rechazar_button.Name = "rechazar_button";
            this.rechazar_button.Size = new System.Drawing.Size(98, 38);
            this.rechazar_button.TabIndex = 2;
            this.rechazar_button.Text = "Rechazar";
            this.rechazar_button.UseVisualStyleBackColor = false;
            this.rechazar_button.Click += new System.EventHandler(this.rechazar_button_Click);
            // 
            // aceptar_button
            // 
            this.aceptar_button.BackColor = System.Drawing.Color.Transparent;
            this.aceptar_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.aceptar_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aceptar_button.Location = new System.Drawing.Point(114, 221);
            this.aceptar_button.Name = "aceptar_button";
            this.aceptar_button.Size = new System.Drawing.Size(97, 38);
            this.aceptar_button.TabIndex = 1;
            this.aceptar_button.Text = "Aceptar";
            this.aceptar_button.UseVisualStyleBackColor = false;
            this.aceptar_button.Click += new System.EventHandler(this.aceptar_button_Click);
            // 
            // Desconectar
            // 
            this.Desconectar.BackColor = System.Drawing.Color.Transparent;
            this.Desconectar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Desconectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Desconectar.ForeColor = System.Drawing.Color.Black;
            this.Desconectar.Location = new System.Drawing.Point(597, 214);
            this.Desconectar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Size = new System.Drawing.Size(130, 36);
            this.Desconectar.TabIndex = 31;
            this.Desconectar.Text = "Desconectar";
            this.Desconectar.UseVisualStyleBackColor = false;
            this.Desconectar.Visible = false;
            this.Desconectar.Click += new System.EventHandler(this.Desconectar_Click);
            // 
            // Dar_baja
            // 
            this.Dar_baja.BackColor = System.Drawing.Color.Transparent;
            this.Dar_baja.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Dar_baja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Dar_baja.Location = new System.Drawing.Point(302, 307);
            this.Dar_baja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dar_baja.Name = "Dar_baja";
            this.Dar_baja.Size = new System.Drawing.Size(127, 36);
            this.Dar_baja.TabIndex = 37;
            this.Dar_baja.Text = "Dar de baja";
            this.Dar_baja.UseVisualStyleBackColor = false;
            this.Dar_baja.Click += new System.EventHandler(this.Dar_baja_Click);
            // 
            // timer_invitar
            // 
            this.timer_invitar.Interval = 1000;
            this.timer_invitar.Tick += new System.EventHandler(this.timer_invitar_Tick_1);
            // 
            // Invitacion_Grid
            // 
            this.Invitacion_Grid.BackgroundColor = System.Drawing.Color.White;
            this.Invitacion_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Invitacion_Grid.ColumnHeadersVisible = false;
            this.Invitacion_Grid.Location = new System.Drawing.Point(6, 26);
            this.Invitacion_Grid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Invitacion_Grid.Name = "Invitacion_Grid";
            this.Invitacion_Grid.RowHeadersVisible = false;
            this.Invitacion_Grid.RowTemplate.Height = 24;
            this.Invitacion_Grid.Size = new System.Drawing.Size(447, 190);
            this.Invitacion_Grid.TabIndex = 8;
            this.Invitacion_Grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Invitacion_Grid_CellContentClick);
            // 
            // Invitaciones_groupBox
            // 
            this.Invitaciones_groupBox.BackColor = System.Drawing.Color.Transparent;
            this.Invitaciones_groupBox.Controls.Add(this.rechazar_button);
            this.Invitaciones_groupBox.Controls.Add(this.Invitacion_textBox);
            this.Invitaciones_groupBox.Controls.Add(this.aceptar_button);
            this.Invitaciones_groupBox.Controls.Add(this.Invitacion_Grid);
            this.Invitaciones_groupBox.Controls.Add(this.IniciarPartida);
            this.Invitaciones_groupBox.Location = new System.Drawing.Point(259, 255);
            this.Invitaciones_groupBox.Name = "Invitaciones_groupBox";
            this.Invitaciones_groupBox.Size = new System.Drawing.Size(468, 270);
            this.Invitaciones_groupBox.TabIndex = 38;
            this.Invitaciones_groupBox.TabStop = false;
            this.Invitaciones_groupBox.Text = "Invitaciones:";
            this.Invitaciones_groupBox.Visible = false;
            // 
            // Invitacion_textBox
            // 
            this.Invitacion_textBox.Location = new System.Drawing.Point(6, 229);
            this.Invitacion_textBox.Name = "Invitacion_textBox";
            this.Invitacion_textBox.Size = new System.Drawing.Size(93, 22);
            this.Invitacion_textBox.TabIndex = 18;
            // 
            // Usuario_lbl
            // 
            this.Usuario_lbl.AutoSize = true;
            this.Usuario_lbl.BackColor = System.Drawing.Color.Transparent;
            this.Usuario_lbl.Location = new System.Drawing.Point(591, 18);
            this.Usuario_lbl.Name = "Usuario_lbl";
            this.Usuario_lbl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Usuario_lbl.Size = new System.Drawing.Size(46, 17);
            this.Usuario_lbl.TabIndex = 39;
            this.Usuario_lbl.Text = "label8";
            this.Usuario_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Usuario_lbl.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(758, 565);
            this.Controls.Add(this.Usuario_lbl);
            this.Controls.Add(this.Invitaciones_groupBox);
            this.Controls.Add(this.Dar_baja);
            this.Controls.Add(this.Ayuda);
            this.Controls.Add(this.QuererConsulta);
            this.Controls.Add(this.groupBox_inciar);
            this.Controls.Add(this.Conectados_groupBox);
            this.Controls.Add(this.Desconectar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Registrarse);
            this.Controls.Add(this.Iniciar_sesion);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = " Inicio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox_inciar.ResumeLayout(false);
            this.groupBox_inciar.PerformLayout();
            this.Conectados_groupBox.ResumeLayout(false);
            this.Conectados_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Conectados_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Invitacion_Grid)).EndInit();
            this.Invitaciones_groupBox.ResumeLayout(false);
            this.Invitaciones_groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Ayuda;
        private System.Windows.Forms.Button Registrarse;
        private System.Windows.Forms.Button Iniciar_sesion;
        private System.Windows.Forms.Button Registrarse_Button;
        private System.Windows.Forms.GroupBox groupBox_inciar;
        private System.Windows.Forms.TextBox Contraseña;
        private System.Windows.Forms.TextBox Nombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Iniciar_Button;
        private System.Windows.Forms.Button QuererConsulta;
        private System.Windows.Forms.Button Cancelar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Invitados_textBox;
        private System.Windows.Forms.GroupBox Conectados_groupBox;
        private System.Windows.Forms.DataGridView Conectados_Grid;
        private System.Windows.Forms.Button Invitar;
        private System.Windows.Forms.Button rechazar_button;
        private System.Windows.Forms.Button aceptar_button;
        private System.Windows.Forms.Button Desconectar;
        private System.Windows.Forms.Button IniciarPartida;
        private System.Windows.Forms.Button Dar_baja;
        private System.Windows.Forms.Button Baja_button;
        private System.Windows.Forms.Timer timer_invitar;
        private System.Windows.Forms.DataGridView Invitacion_Grid;
        private System.Windows.Forms.GroupBox Invitaciones_groupBox;
        private System.Windows.Forms.TextBox Invitacion_textBox;
        private System.Windows.Forms.Label Usuario_lbl;
    }
}

