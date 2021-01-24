namespace WindowsFormsApplication1
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.groupBox_consultas = new System.Windows.Forms.GroupBox();
            this.Mensaje_label = new System.Windows.Forms.Label();
            this.Fecha_Final = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Fecha_Inicio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ID_jugador_2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Tiempo = new System.Windows.Forms.RadioButton();
            this.Resultados = new System.Windows.Forms.RadioButton();
            this.Consulta_Grid = new System.Windows.Forms.DataGridView();
            this.Consulta_Button = new System.Windows.Forms.Button();
            this.Partidas = new System.Windows.Forms.RadioButton();
            this.Personajes = new System.Windows.Forms.RadioButton();
            this.Record = new System.Windows.Forms.RadioButton();
            this.ID_Jugador = new System.Windows.Forms.TextBox();
            this.ID_Partida = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox_consultas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Consulta_Grid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_consultas
            // 
            this.groupBox_consultas.BackColor = System.Drawing.Color.Transparent;
            this.groupBox_consultas.Controls.Add(this.Mensaje_label);
            this.groupBox_consultas.Controls.Add(this.Fecha_Final);
            this.groupBox_consultas.Controls.Add(this.label6);
            this.groupBox_consultas.Controls.Add(this.Fecha_Inicio);
            this.groupBox_consultas.Controls.Add(this.label5);
            this.groupBox_consultas.Controls.Add(this.ID_jugador_2);
            this.groupBox_consultas.Controls.Add(this.label2);
            this.groupBox_consultas.Controls.Add(this.Tiempo);
            this.groupBox_consultas.Controls.Add(this.Resultados);
            this.groupBox_consultas.Controls.Add(this.Consulta_Grid);
            this.groupBox_consultas.Controls.Add(this.Consulta_Button);
            this.groupBox_consultas.Controls.Add(this.Partidas);
            this.groupBox_consultas.Controls.Add(this.Personajes);
            this.groupBox_consultas.Controls.Add(this.Record);
            this.groupBox_consultas.Controls.Add(this.ID_Jugador);
            this.groupBox_consultas.Controls.Add(this.ID_Partida);
            this.groupBox_consultas.Controls.Add(this.label3);
            this.groupBox_consultas.Controls.Add(this.label4);
            this.groupBox_consultas.Location = new System.Drawing.Point(45, 30);
            this.groupBox_consultas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_consultas.Name = "groupBox_consultas";
            this.groupBox_consultas.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox_consultas.Size = new System.Drawing.Size(810, 395);
            this.groupBox_consultas.TabIndex = 28;
            this.groupBox_consultas.TabStop = false;
            this.groupBox_consultas.Text = "¿Qué quieres saber?";
            // 
            // Mensaje_label
            // 
            this.Mensaje_label.AutoSize = true;
            this.Mensaje_label.Location = new System.Drawing.Point(417, 38);
            this.Mensaje_label.Name = "Mensaje_label";
            this.Mensaje_label.Size = new System.Drawing.Size(61, 17);
            this.Mensaje_label.TabIndex = 30;
            this.Mensaje_label.Text = "Mensaje";
            // 
            // Fecha_Final
            // 
            this.Fecha_Final.Location = new System.Drawing.Point(30, 354);
            this.Fecha_Final.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Fecha_Final.Name = "Fecha_Final";
            this.Fecha_Final.Size = new System.Drawing.Size(100, 22);
            this.Fecha_Final.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 335);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Fecha final (dd/mm/aaaa):";
            // 
            // Fecha_Inicio
            // 
            this.Fecha_Inicio.Location = new System.Drawing.Point(30, 304);
            this.Fecha_Inicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Fecha_Inicio.Name = "Fecha_Inicio";
            this.Fecha_Inicio.Size = new System.Drawing.Size(100, 22);
            this.Fecha_Inicio.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 17);
            this.label5.TabIndex = 18;
            this.label5.Text = "Fecha inicio: (dd/mm/aaaa):";
            // 
            // ID_jugador_2
            // 
            this.ID_jugador_2.Location = new System.Drawing.Point(107, 219);
            this.ID_jugador_2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ID_jugador_2.Name = "ID_jugador_2";
            this.ID_jugador_2.Size = new System.Drawing.Size(100, 22);
            this.ID_jugador_2.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "ID_jugador";
            // 
            // Tiempo
            // 
            this.Tiempo.AutoSize = true;
            this.Tiempo.Location = new System.Drawing.Point(21, 250);
            this.Tiempo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tiempo.Name = "Tiempo";
            this.Tiempo.Size = new System.Drawing.Size(253, 21);
            this.Tiempo.TabIndex = 15;
            this.Tiempo.TabStop = true;
            this.Tiempo.Text = "¿Que partidas se han jugado en...?";
            this.Tiempo.UseVisualStyleBackColor = true;
            // 
            // Resultados
            // 
            this.Resultados.AutoSize = true;
            this.Resultados.Location = new System.Drawing.Point(21, 185);
            this.Resultados.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Resultados.Name = "Resultados";
            this.Resultados.Size = new System.Drawing.Size(320, 21);
            this.Resultados.TabIndex = 14;
            this.Resultados.TabStop = true;
            this.Resultados.Text = "¿Cuales son mis resultados con este jugador?";
            this.Resultados.UseVisualStyleBackColor = true;
            // 
            // Consulta_Grid
            // 
            this.Consulta_Grid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Consulta_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Consulta_Grid.ColumnHeadersVisible = false;
            this.Consulta_Grid.Location = new System.Drawing.Point(420, 65);
            this.Consulta_Grid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Consulta_Grid.Name = "Consulta_Grid";
            this.Consulta_Grid.RowHeadersVisible = false;
            this.Consulta_Grid.RowTemplate.Height = 24;
            this.Consulta_Grid.Size = new System.Drawing.Size(360, 255);
            this.Consulta_Grid.TabIndex = 8;
            this.Consulta_Grid.Visible = false;
            // 
            // Consulta_Button
            // 
            this.Consulta_Button.BackColor = System.Drawing.Color.Transparent;
            this.Consulta_Button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Consulta_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Consulta_Button.Location = new System.Drawing.Point(420, 326);
            this.Consulta_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Consulta_Button.Name = "Consulta_Button";
            this.Consulta_Button.Size = new System.Drawing.Size(108, 38);
            this.Consulta_Button.TabIndex = 2;
            this.Consulta_Button.Text = "Consulta";
            this.Consulta_Button.UseVisualStyleBackColor = false;
            this.Consulta_Button.Click += new System.EventHandler(this.Consulta_Button_Click_1);
            // 
            // Partidas
            // 
            this.Partidas.AutoSize = true;
            this.Partidas.Location = new System.Drawing.Point(21, 128);
            this.Partidas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Partidas.Name = "Partidas";
            this.Partidas.Size = new System.Drawing.Size(302, 21);
            this.Partidas.TabIndex = 13;
            this.Partidas.TabStop = true;
            this.Partidas.Text = "¿Cuantas partidas ha jugado este jugador?";
            this.Partidas.UseVisualStyleBackColor = true;
            // 
            // Personajes
            // 
            this.Personajes.AutoSize = true;
            this.Personajes.Location = new System.Drawing.Point(21, 71);
            this.Personajes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Personajes.Name = "Personajes";
            this.Personajes.Size = new System.Drawing.Size(338, 21);
            this.Personajes.TabIndex = 12;
            this.Personajes.TabStop = true;
            this.Personajes.Text = "¿Qué personajes se escogieron en esta partida?";
            this.Personajes.UseVisualStyleBackColor = true;
            // 
            // Record
            // 
            this.Record.AutoSize = true;
            this.Record.Location = new System.Drawing.Point(21, 37);
            this.Record.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Record.Name = "Record";
            this.Record.Size = new System.Drawing.Size(178, 21);
            this.Record.TabIndex = 11;
            this.Record.TabStop = true;
            this.Record.Text = "¿Quién tiene el record?";
            this.Record.UseVisualStyleBackColor = true;
            // 
            // ID_Jugador
            // 
            this.ID_Jugador.Location = new System.Drawing.Point(107, 153);
            this.ID_Jugador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ID_Jugador.Name = "ID_Jugador";
            this.ID_Jugador.Size = new System.Drawing.Size(100, 22);
            this.ID_Jugador.TabIndex = 10;
            // 
            // ID_Partida
            // 
            this.ID_Partida.Location = new System.Drawing.Point(107, 96);
            this.ID_Partida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ID_Partida.Name = "ID_Partida";
            this.ID_Partida.Size = new System.Drawing.Size(100, 22);
            this.ID_Partida.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "ID_jugador";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "ID_partida";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(897, 466);
            this.Controls.Add(this.groupBox_consultas);
            this.Name = "Form2";
            this.Text = "Consultas";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox_consultas.ResumeLayout(false);
            this.groupBox_consultas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Consulta_Grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_consultas;
        private System.Windows.Forms.TextBox Fecha_Final;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Fecha_Inicio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ID_jugador_2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton Tiempo;
        private System.Windows.Forms.RadioButton Resultados;
        private System.Windows.Forms.DataGridView Consulta_Grid;
        private System.Windows.Forms.Button Consulta_Button;
        private System.Windows.Forms.RadioButton Partidas;
        private System.Windows.Forms.RadioButton Personajes;
        private System.Windows.Forms.RadioButton Record;
        private System.Windows.Forms.TextBox ID_Jugador;
        private System.Windows.Forms.TextBox ID_Partida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label Mensaje_label;
    }
}