namespace WindowsFormsApplication1
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.Resolver_groupBox = new System.Windows.Forms.GroupBox();
            this.jugador_personaje_grid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.personaje_textBox = new System.Windows.Forms.TextBox();
            this.Confirmar = new System.Windows.Forms.Button();
            this.Atras = new System.Windows.Forms.Button();
            this.panel_Resolver = new System.Windows.Forms.Panel();
            this.Resolver = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Seleccionar_button = new System.Windows.Forms.Button();
            this.panel_Seleccionado = new System.Windows.Forms.Panel();
            this.Chat_groupBox = new System.Windows.Forms.GroupBox();
            this.Chat_listBox = new System.Windows.Forms.ListBox();
            this.Enviar = new System.Windows.Forms.Button();
            this.Chat_TextBox = new System.Windows.Forms.TextBox();
            this.Tablero = new System.Windows.Forms.GroupBox();
            this.CristinaB_button = new System.Windows.Forms.Button();
            this.Gabri_button = new System.Windows.Forms.Button();
            this.Julen_button = new System.Windows.Forms.Button();
            this.Angela_button = new System.Windows.Forms.Button();
            this.David_Button = new System.Windows.Forms.Button();
            this.CristinaR_button = new System.Windows.Forms.Button();
            this.Izan_button = new System.Windows.Forms.Button();
            this.Enric_button = new System.Windows.Forms.Button();
            this.Mireia_button = new System.Windows.Forms.Button();
            this.Victor_button = new System.Windows.Forms.Button();
            this.Javi_button = new System.Windows.Forms.Button();
            this.Antonia_button = new System.Windows.Forms.Button();
            this.Andrea_button = new System.Windows.Forms.Button();
            this.Arnau_button = new System.Windows.Forms.Button();
            this.Emma_button = new System.Windows.Forms.Button();
            this.panel_Cristina_B = new System.Windows.Forms.Panel();
            this.panel_Angela = new System.Windows.Forms.Panel();
            this.panel_Gabri = new System.Windows.Forms.Panel();
            this.panel_Enric = new System.Windows.Forms.Panel();
            this.panel_Julen = new System.Windows.Forms.Panel();
            this.panel_Izan = new System.Windows.Forms.Panel();
            this.panel_Andrea = new System.Windows.Forms.Panel();
            this.panel_David = new System.Windows.Forms.Panel();
            this.panel_Victor = new System.Windows.Forms.Panel();
            this.panel_Mireia = new System.Windows.Forms.Panel();
            this.panel_Arnau = new System.Windows.Forms.Panel();
            this.panel_Cristina_R = new System.Windows.Forms.Panel();
            this.panel_Antonia = new System.Windows.Forms.Panel();
            this.panel_Javi = new System.Windows.Forms.Panel();
            this.panel_Emma = new System.Windows.Forms.Panel();
            this.rival = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Duracion_label = new System.Windows.Forms.Label();
            this.nombre_lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Resolver_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jugador_personaje_grid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.Chat_groupBox.SuspendLayout();
            this.Tablero.SuspendLayout();
            this.SuspendLayout();
            // 
            // Resolver_groupBox
            // 
            this.Resolver_groupBox.BackColor = System.Drawing.Color.Transparent;
            this.Resolver_groupBox.Controls.Add(this.jugador_personaje_grid);
            this.Resolver_groupBox.Controls.Add(this.label1);
            this.Resolver_groupBox.Controls.Add(this.personaje_textBox);
            this.Resolver_groupBox.Controls.Add(this.Confirmar);
            this.Resolver_groupBox.Controls.Add(this.Atras);
            this.Resolver_groupBox.Controls.Add(this.panel_Resolver);
            this.Resolver_groupBox.Location = new System.Drawing.Point(88, 436);
            this.Resolver_groupBox.Name = "Resolver_groupBox";
            this.Resolver_groupBox.Size = new System.Drawing.Size(200, 424);
            this.Resolver_groupBox.TabIndex = 22;
            this.Resolver_groupBox.TabStop = false;
            this.Resolver_groupBox.Text = "Personaje de...";
            this.Resolver_groupBox.UseCompatibleTextRendering = true;
            this.Resolver_groupBox.Visible = false;
            // 
            // jugador_personaje_grid
            // 
            this.jugador_personaje_grid.BackgroundColor = System.Drawing.Color.White;
            this.jugador_personaje_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jugador_personaje_grid.ColumnHeadersVisible = false;
            this.jugador_personaje_grid.Location = new System.Drawing.Point(36, 23);
            this.jugador_personaje_grid.Name = "jugador_personaje_grid";
            this.jugador_personaje_grid.RowHeadersVisible = false;
            this.jugador_personaje_grid.RowTemplate.Height = 24;
            this.jugador_personaje_grid.Size = new System.Drawing.Size(128, 102);
            this.jugador_personaje_grid.TabIndex = 5;
            this.jugador_personaje_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.jugador_personaje_grid_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Es: ";
            // 
            // personaje_textBox
            // 
            this.personaje_textBox.Location = new System.Drawing.Point(36, 134);
            this.personaje_textBox.Name = "personaje_textBox";
            this.personaje_textBox.Size = new System.Drawing.Size(128, 22);
            this.personaje_textBox.TabIndex = 3;
            // 
            // Confirmar
            // 
            this.Confirmar.Location = new System.Drawing.Point(36, 345);
            this.Confirmar.Name = "Confirmar";
            this.Confirmar.Size = new System.Drawing.Size(131, 29);
            this.Confirmar.TabIndex = 2;
            this.Confirmar.Text = "Confirmar";
            this.Confirmar.UseVisualStyleBackColor = true;
            this.Confirmar.Click += new System.EventHandler(this.Confirmar_Click);
            // 
            // Atras
            // 
            this.Atras.Location = new System.Drawing.Point(36, 379);
            this.Atras.Name = "Atras";
            this.Atras.Size = new System.Drawing.Size(131, 27);
            this.Atras.TabIndex = 2;
            this.Atras.Text = "Atrás";
            this.Atras.UseVisualStyleBackColor = true;
            this.Atras.Click += new System.EventHandler(this.Atras_Click);
            // 
            // panel_Resolver
            // 
            this.panel_Resolver.BackColor = System.Drawing.Color.Transparent;
            this.panel_Resolver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Resolver.Location = new System.Drawing.Point(36, 180);
            this.panel_Resolver.Name = "panel_Resolver";
            this.panel_Resolver.Size = new System.Drawing.Size(131, 158);
            this.panel_Resolver.TabIndex = 0;
            // 
            // Resolver
            // 
            this.Resolver.Location = new System.Drawing.Point(121, 397);
            this.Resolver.Name = "Resolver";
            this.Resolver.Size = new System.Drawing.Size(131, 33);
            this.Resolver.TabIndex = 1;
            this.Resolver.Text = "Resolver";
            this.Resolver.UseVisualStyleBackColor = true;
            this.Resolver.Click += new System.EventHandler(this.Resolver_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.Seleccionar_button);
            this.groupBox3.Controls.Add(this.panel_Seleccionado);
            this.groupBox3.Location = new System.Drawing.Point(88, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 290);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "¿Quieres que este sea tu personaje?";
            // 
            // Seleccionar_button
            // 
            this.Seleccionar_button.Location = new System.Drawing.Point(34, 233);
            this.Seleccionar_button.Name = "Seleccionar_button";
            this.Seleccionar_button.Size = new System.Drawing.Size(131, 33);
            this.Seleccionar_button.TabIndex = 1;
            this.Seleccionar_button.Text = "Confirmar";
            this.Seleccionar_button.UseVisualStyleBackColor = true;
            this.Seleccionar_button.Click += new System.EventHandler(this.Seleccionar_button_Click);
            // 
            // panel_Seleccionado
            // 
            this.panel_Seleccionado.BackColor = System.Drawing.Color.Transparent;
            this.panel_Seleccionado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Seleccionado.Location = new System.Drawing.Point(34, 56);
            this.panel_Seleccionado.Name = "panel_Seleccionado";
            this.panel_Seleccionado.Size = new System.Drawing.Size(131, 158);
            this.panel_Seleccionado.TabIndex = 0;
            // 
            // Chat_groupBox
            // 
            this.Chat_groupBox.BackColor = System.Drawing.Color.Transparent;
            this.Chat_groupBox.Controls.Add(this.Chat_listBox);
            this.Chat_groupBox.Controls.Add(this.Enviar);
            this.Chat_groupBox.Controls.Add(this.Chat_TextBox);
            this.Chat_groupBox.Location = new System.Drawing.Point(1408, 96);
            this.Chat_groupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Chat_groupBox.Name = "Chat_groupBox";
            this.Chat_groupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Chat_groupBox.Size = new System.Drawing.Size(415, 764);
            this.Chat_groupBox.TabIndex = 20;
            this.Chat_groupBox.TabStop = false;
            this.Chat_groupBox.Text = "Chat";
            // 
            // Chat_listBox
            // 
            this.Chat_listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Chat_listBox.FormattingEnabled = true;
            this.Chat_listBox.HorizontalScrollbar = true;
            this.Chat_listBox.ItemHeight = 16;
            this.Chat_listBox.Location = new System.Drawing.Point(9, 20);
            this.Chat_listBox.Name = "Chat_listBox";
            this.Chat_listBox.Size = new System.Drawing.Size(390, 692);
            this.Chat_listBox.TabIndex = 26;
            this.Chat_listBox.TabStop = false;
            this.Chat_listBox.UseTabStops = false;
            this.Chat_listBox.UseWaitCursor = true;
            // 
            // Enviar
            // 
            this.Enviar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Enviar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Enviar.Location = new System.Drawing.Point(321, 717);
            this.Enviar.Name = "Enviar";
            this.Enviar.Size = new System.Drawing.Size(78, 32);
            this.Enviar.TabIndex = 2;
            this.Enviar.Text = "Enviar";
            this.Enviar.UseVisualStyleBackColor = false;
            this.Enviar.Click += new System.EventHandler(this.Enviar_Click);
            // 
            // Chat_TextBox
            // 
            this.Chat_TextBox.Location = new System.Drawing.Point(9, 722);
            this.Chat_TextBox.Name = "Chat_TextBox";
            this.Chat_TextBox.Size = new System.Drawing.Size(306, 22);
            this.Chat_TextBox.TabIndex = 1;
            // 
            // Tablero
            // 
            this.Tablero.BackColor = System.Drawing.Color.Transparent;
            this.Tablero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Tablero.Controls.Add(this.CristinaB_button);
            this.Tablero.Controls.Add(this.Gabri_button);
            this.Tablero.Controls.Add(this.Julen_button);
            this.Tablero.Controls.Add(this.Angela_button);
            this.Tablero.Controls.Add(this.David_Button);
            this.Tablero.Controls.Add(this.CristinaR_button);
            this.Tablero.Controls.Add(this.Izan_button);
            this.Tablero.Controls.Add(this.Enric_button);
            this.Tablero.Controls.Add(this.Mireia_button);
            this.Tablero.Controls.Add(this.Victor_button);
            this.Tablero.Controls.Add(this.Javi_button);
            this.Tablero.Controls.Add(this.Antonia_button);
            this.Tablero.Controls.Add(this.Andrea_button);
            this.Tablero.Controls.Add(this.Arnau_button);
            this.Tablero.Controls.Add(this.Emma_button);
            this.Tablero.Controls.Add(this.panel_Cristina_B);
            this.Tablero.Controls.Add(this.panel_Angela);
            this.Tablero.Controls.Add(this.panel_Gabri);
            this.Tablero.Controls.Add(this.panel_Enric);
            this.Tablero.Controls.Add(this.panel_Julen);
            this.Tablero.Controls.Add(this.panel_Izan);
            this.Tablero.Controls.Add(this.panel_Andrea);
            this.Tablero.Controls.Add(this.panel_David);
            this.Tablero.Controls.Add(this.panel_Victor);
            this.Tablero.Controls.Add(this.panel_Mireia);
            this.Tablero.Controls.Add(this.panel_Arnau);
            this.Tablero.Controls.Add(this.panel_Cristina_R);
            this.Tablero.Controls.Add(this.panel_Antonia);
            this.Tablero.Controls.Add(this.panel_Javi);
            this.Tablero.Controls.Add(this.panel_Emma);
            this.Tablero.Location = new System.Drawing.Point(368, 96);
            this.Tablero.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tablero.Name = "Tablero";
            this.Tablero.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Tablero.Size = new System.Drawing.Size(993, 764);
            this.Tablero.TabIndex = 19;
            this.Tablero.TabStop = false;
            // 
            // CristinaB_button
            // 
            this.CristinaB_button.Location = new System.Drawing.Point(824, 702);
            this.CristinaB_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CristinaB_button.Name = "CristinaB_button";
            this.CristinaB_button.Size = new System.Drawing.Size(131, 32);
            this.CristinaB_button.TabIndex = 25;
            this.CristinaB_button.Text = "Cristina B";
            this.CristinaB_button.UseVisualStyleBackColor = true;
            this.CristinaB_button.Click += new System.EventHandler(this.CristinaB_button_Click_1);
            // 
            // Gabri_button
            // 
            this.Gabri_button.Location = new System.Drawing.Point(824, 462);
            this.Gabri_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Gabri_button.Name = "Gabri_button";
            this.Gabri_button.Size = new System.Drawing.Size(131, 32);
            this.Gabri_button.TabIndex = 24;
            this.Gabri_button.Text = "Gabri";
            this.Gabri_button.UseVisualStyleBackColor = true;
            this.Gabri_button.Click += new System.EventHandler(this.Gabri_button_Click_1);
            // 
            // Julen_button
            // 
            this.Julen_button.Location = new System.Drawing.Point(824, 213);
            this.Julen_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Julen_button.Name = "Julen_button";
            this.Julen_button.Size = new System.Drawing.Size(131, 32);
            this.Julen_button.TabIndex = 23;
            this.Julen_button.Text = "Julen";
            this.Julen_button.UseVisualStyleBackColor = true;
            this.Julen_button.Click += new System.EventHandler(this.Julen_button_Click_1);
            // 
            // Angela_button
            // 
            this.Angela_button.Location = new System.Drawing.Point(627, 702);
            this.Angela_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Angela_button.Name = "Angela_button";
            this.Angela_button.Size = new System.Drawing.Size(131, 32);
            this.Angela_button.TabIndex = 22;
            this.Angela_button.Text = "Angela";
            this.Angela_button.UseVisualStyleBackColor = true;
            this.Angela_button.Click += new System.EventHandler(this.Angela_button_Click_1);
            // 
            // David_Button
            // 
            this.David_Button.Location = new System.Drawing.Point(627, 462);
            this.David_Button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.David_Button.Name = "David_Button";
            this.David_Button.Size = new System.Drawing.Size(131, 32);
            this.David_Button.TabIndex = 21;
            this.David_Button.Text = "David";
            this.David_Button.UseVisualStyleBackColor = true;
            this.David_Button.Click += new System.EventHandler(this.David_Button_Click_1);
            // 
            // CristinaR_button
            // 
            this.CristinaR_button.Location = new System.Drawing.Point(627, 212);
            this.CristinaR_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CristinaR_button.Name = "CristinaR_button";
            this.CristinaR_button.Size = new System.Drawing.Size(131, 32);
            this.CristinaR_button.TabIndex = 20;
            this.CristinaR_button.Text = "Cristina R";
            this.CristinaR_button.UseVisualStyleBackColor = true;
            this.CristinaR_button.Click += new System.EventHandler(this.CristinaR_button_Click_1);
            // 
            // Izan_button
            // 
            this.Izan_button.Location = new System.Drawing.Point(429, 699);
            this.Izan_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Izan_button.Name = "Izan_button";
            this.Izan_button.Size = new System.Drawing.Size(131, 32);
            this.Izan_button.TabIndex = 19;
            this.Izan_button.Text = "Izan";
            this.Izan_button.UseVisualStyleBackColor = true;
            this.Izan_button.Click += new System.EventHandler(this.Izan_button_Click_1);
            // 
            // Enric_button
            // 
            this.Enric_button.Location = new System.Drawing.Point(229, 699);
            this.Enric_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Enric_button.Name = "Enric_button";
            this.Enric_button.Size = new System.Drawing.Size(131, 32);
            this.Enric_button.TabIndex = 19;
            this.Enric_button.Text = "Enric";
            this.Enric_button.UseVisualStyleBackColor = true;
            this.Enric_button.Click += new System.EventHandler(this.Enric_button_Click_1);
            // 
            // Mireia_button
            // 
            this.Mireia_button.Location = new System.Drawing.Point(429, 459);
            this.Mireia_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Mireia_button.Name = "Mireia_button";
            this.Mireia_button.Size = new System.Drawing.Size(131, 32);
            this.Mireia_button.TabIndex = 18;
            this.Mireia_button.Text = "Mireia";
            this.Mireia_button.UseVisualStyleBackColor = true;
            this.Mireia_button.Click += new System.EventHandler(this.Mireia_button_Click_1);
            // 
            // Victor_button
            // 
            this.Victor_button.Location = new System.Drawing.Point(229, 459);
            this.Victor_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Victor_button.Name = "Victor_button";
            this.Victor_button.Size = new System.Drawing.Size(131, 32);
            this.Victor_button.TabIndex = 18;
            this.Victor_button.Text = "Victor";
            this.Victor_button.UseVisualStyleBackColor = true;
            this.Victor_button.Click += new System.EventHandler(this.Victor_button_Click_1);
            // 
            // Javi_button
            // 
            this.Javi_button.Location = new System.Drawing.Point(429, 210);
            this.Javi_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Javi_button.Name = "Javi_button";
            this.Javi_button.Size = new System.Drawing.Size(131, 32);
            this.Javi_button.TabIndex = 17;
            this.Javi_button.Text = "Javi";
            this.Javi_button.UseVisualStyleBackColor = true;
            this.Javi_button.Click += new System.EventHandler(this.Javi_button_Click_1);
            // 
            // Antonia_button
            // 
            this.Antonia_button.Location = new System.Drawing.Point(229, 210);
            this.Antonia_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Antonia_button.Name = "Antonia_button";
            this.Antonia_button.Size = new System.Drawing.Size(131, 32);
            this.Antonia_button.TabIndex = 17;
            this.Antonia_button.Text = "Antonia";
            this.Antonia_button.UseVisualStyleBackColor = true;
            this.Antonia_button.Click += new System.EventHandler(this.Antonia_button_Click_1);
            // 
            // Andrea_button
            // 
            this.Andrea_button.Location = new System.Drawing.Point(32, 697);
            this.Andrea_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Andrea_button.Name = "Andrea_button";
            this.Andrea_button.Size = new System.Drawing.Size(131, 32);
            this.Andrea_button.TabIndex = 16;
            this.Andrea_button.Text = "Andrea";
            this.Andrea_button.UseVisualStyleBackColor = true;
            this.Andrea_button.Click += new System.EventHandler(this.Andrea_button_Click_1);
            // 
            // Arnau_button
            // 
            this.Arnau_button.Location = new System.Drawing.Point(32, 457);
            this.Arnau_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Arnau_button.Name = "Arnau_button";
            this.Arnau_button.Size = new System.Drawing.Size(131, 32);
            this.Arnau_button.TabIndex = 15;
            this.Arnau_button.Text = "Arnau";
            this.Arnau_button.UseVisualStyleBackColor = true;
            this.Arnau_button.Click += new System.EventHandler(this.Arnau_button_Click_1);
            // 
            // Emma_button
            // 
            this.Emma_button.Location = new System.Drawing.Point(32, 208);
            this.Emma_button.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Emma_button.Name = "Emma_button";
            this.Emma_button.Size = new System.Drawing.Size(131, 32);
            this.Emma_button.TabIndex = 14;
            this.Emma_button.Text = "Emma";
            this.Emma_button.UseVisualStyleBackColor = true;
            this.Emma_button.Click += new System.EventHandler(this.Emma_button_Click_1);
            // 
            // panel_Cristina_B
            // 
            this.panel_Cristina_B.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Cristina_B.Location = new System.Drawing.Point(824, 540);
            this.panel_Cristina_B.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Cristina_B.Name = "panel_Cristina_B";
            this.panel_Cristina_B.Size = new System.Drawing.Size(131, 156);
            this.panel_Cristina_B.TabIndex = 12;
            // 
            // panel_Angela
            // 
            this.panel_Angela.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Angela.Location = new System.Drawing.Point(627, 539);
            this.panel_Angela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Angela.Name = "panel_Angela";
            this.panel_Angela.Size = new System.Drawing.Size(131, 156);
            this.panel_Angela.TabIndex = 9;
            // 
            // panel_Gabri
            // 
            this.panel_Gabri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Gabri.Location = new System.Drawing.Point(824, 300);
            this.panel_Gabri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Gabri.Name = "panel_Gabri";
            this.panel_Gabri.Size = new System.Drawing.Size(131, 156);
            this.panel_Gabri.TabIndex = 13;
            // 
            // panel_Enric
            // 
            this.panel_Enric.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Enric.Location = new System.Drawing.Point(229, 537);
            this.panel_Enric.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Enric.Name = "panel_Enric";
            this.panel_Enric.Size = new System.Drawing.Size(131, 156);
            this.panel_Enric.TabIndex = 3;
            // 
            // panel_Julen
            // 
            this.panel_Julen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Julen.Location = new System.Drawing.Point(824, 50);
            this.panel_Julen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Julen.Name = "panel_Julen";
            this.panel_Julen.Size = new System.Drawing.Size(131, 156);
            this.panel_Julen.TabIndex = 11;
            // 
            // panel_Izan
            // 
            this.panel_Izan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Izan.Location = new System.Drawing.Point(429, 537);
            this.panel_Izan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Izan.Name = "panel_Izan";
            this.panel_Izan.Size = new System.Drawing.Size(131, 156);
            this.panel_Izan.TabIndex = 7;
            // 
            // panel_Andrea
            // 
            this.panel_Andrea.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Andrea.Location = new System.Drawing.Point(32, 535);
            this.panel_Andrea.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Andrea.Name = "panel_Andrea";
            this.panel_Andrea.Size = new System.Drawing.Size(131, 156);
            this.panel_Andrea.TabIndex = 1;
            // 
            // panel_David
            // 
            this.panel_David.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_David.Location = new System.Drawing.Point(627, 299);
            this.panel_David.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_David.Name = "panel_David";
            this.panel_David.Size = new System.Drawing.Size(131, 156);
            this.panel_David.TabIndex = 10;
            // 
            // panel_Victor
            // 
            this.panel_Victor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Victor.Location = new System.Drawing.Point(229, 297);
            this.panel_Victor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Victor.Name = "panel_Victor";
            this.panel_Victor.Size = new System.Drawing.Size(131, 156);
            this.panel_Victor.TabIndex = 4;
            // 
            // panel_Mireia
            // 
            this.panel_Mireia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Mireia.Location = new System.Drawing.Point(429, 297);
            this.panel_Mireia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Mireia.Name = "panel_Mireia";
            this.panel_Mireia.Size = new System.Drawing.Size(131, 156);
            this.panel_Mireia.TabIndex = 6;
            // 
            // panel_Arnau
            // 
            this.panel_Arnau.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Arnau.Location = new System.Drawing.Point(32, 295);
            this.panel_Arnau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Arnau.Name = "panel_Arnau";
            this.panel_Arnau.Size = new System.Drawing.Size(131, 156);
            this.panel_Arnau.TabIndex = 1;
            // 
            // panel_Cristina_R
            // 
            this.panel_Cristina_R.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Cristina_R.Location = new System.Drawing.Point(627, 50);
            this.panel_Cristina_R.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Cristina_R.Name = "panel_Cristina_R";
            this.panel_Cristina_R.Size = new System.Drawing.Size(131, 156);
            this.panel_Cristina_R.TabIndex = 8;
            // 
            // panel_Antonia
            // 
            this.panel_Antonia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Antonia.Location = new System.Drawing.Point(229, 48);
            this.panel_Antonia.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Antonia.Name = "panel_Antonia";
            this.panel_Antonia.Size = new System.Drawing.Size(131, 156);
            this.panel_Antonia.TabIndex = 2;
            // 
            // panel_Javi
            // 
            this.panel_Javi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Javi.Location = new System.Drawing.Point(429, 48);
            this.panel_Javi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Javi.Name = "panel_Javi";
            this.panel_Javi.Size = new System.Drawing.Size(131, 156);
            this.panel_Javi.TabIndex = 5;
            // 
            // panel_Emma
            // 
            this.panel_Emma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel_Emma.Location = new System.Drawing.Point(32, 46);
            this.panel_Emma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Emma.Name = "panel_Emma";
            this.panel_Emma.Size = new System.Drawing.Size(131, 156);
            this.panel_Emma.TabIndex = 0;
            // 
            // rival
            // 
            this.rival.AutoSize = true;
            this.rival.BackColor = System.Drawing.Color.Transparent;
            this.rival.Location = new System.Drawing.Point(85, 62);
            this.rival.Name = "rival";
            this.rival.Size = new System.Drawing.Size(47, 17);
            this.rival.TabIndex = 27;
            this.rival.Text = "Rival: ";
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Duracion_label
            // 
            this.Duracion_label.AutoSize = true;
            this.Duracion_label.Location = new System.Drawing.Point(32, 33);
            this.Duracion_label.Name = "Duracion_label";
            this.Duracion_label.Size = new System.Drawing.Size(16, 17);
            this.Duracion_label.TabIndex = 28;
            this.Duracion_label.Text = "0";
            this.Duracion_label.Visible = false;
            // 
            // nombre_lbl
            // 
            this.nombre_lbl.AutoSize = true;
            this.nombre_lbl.BackColor = System.Drawing.Color.Transparent;
            this.nombre_lbl.Location = new System.Drawing.Point(1726, 62);
            this.nombre_lbl.Name = "nombre_lbl";
            this.nombre_lbl.Size = new System.Drawing.Size(46, 17);
            this.nombre_lbl.TabIndex = 29;
            this.nombre_lbl.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Amiri Quran", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(691, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(360, 59);
            this.label2.TabIndex = 30;
            this.label2.Text = "FIN DE LA PARTIDA";
            this.label2.Visible = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1890, 876);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombre_lbl);
            this.Controls.Add(this.Duracion_label);
            this.Controls.Add(this.rival);
            this.Controls.Add(this.Resolver);
            this.Controls.Add(this.Resolver_groupBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.Chat_groupBox);
            this.Controls.Add(this.Tablero);
            this.DoubleBuffered = true;
            this.Name = "Form3";
            this.Text = "Partida";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Resolver_groupBox.ResumeLayout(false);
            this.Resolver_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jugador_personaje_grid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.Chat_groupBox.ResumeLayout(false);
            this.Chat_groupBox.PerformLayout();
            this.Tablero.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Resolver_groupBox;
        private System.Windows.Forms.Button Confirmar;
        private System.Windows.Forms.Button Atras;
        private System.Windows.Forms.Button Resolver;
        private System.Windows.Forms.Panel panel_Resolver;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button Seleccionar_button;
        private System.Windows.Forms.Panel panel_Seleccionado;
        private System.Windows.Forms.GroupBox Chat_groupBox;
        private System.Windows.Forms.ListBox Chat_listBox;
        private System.Windows.Forms.Button Enviar;
        private System.Windows.Forms.TextBox Chat_TextBox;
        private System.Windows.Forms.GroupBox Tablero;
        private System.Windows.Forms.Button CristinaB_button;
        private System.Windows.Forms.Button Gabri_button;
        private System.Windows.Forms.Button Julen_button;
        private System.Windows.Forms.Button Angela_button;
        private System.Windows.Forms.Button David_Button;
        private System.Windows.Forms.Button CristinaR_button;
        private System.Windows.Forms.Button Izan_button;
        private System.Windows.Forms.Button Enric_button;
        private System.Windows.Forms.Button Mireia_button;
        private System.Windows.Forms.Button Victor_button;
        private System.Windows.Forms.Button Javi_button;
        private System.Windows.Forms.Button Antonia_button;
        private System.Windows.Forms.Button Andrea_button;
        private System.Windows.Forms.Button Arnau_button;
        private System.Windows.Forms.Button Emma_button;
        private System.Windows.Forms.Panel panel_Cristina_B;
        private System.Windows.Forms.Panel panel_Angela;
        private System.Windows.Forms.Panel panel_Gabri;
        private System.Windows.Forms.Panel panel_Enric;
        private System.Windows.Forms.Panel panel_Julen;
        private System.Windows.Forms.Panel panel_Izan;
        private System.Windows.Forms.Panel panel_Andrea;
        private System.Windows.Forms.Panel panel_David;
        private System.Windows.Forms.Panel panel_Victor;
        private System.Windows.Forms.Panel panel_Mireia;
        private System.Windows.Forms.Panel panel_Arnau;
        private System.Windows.Forms.Panel panel_Cristina_R;
        private System.Windows.Forms.Panel panel_Antonia;
        private System.Windows.Forms.Panel panel_Javi;
        private System.Windows.Forms.Panel panel_Emma;
        private System.Windows.Forms.Label rival;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label Duracion_label;
        private System.Windows.Forms.TextBox personaje_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView jugador_personaje_grid;
        private System.Windows.Forms.Label nombre_lbl;
        private System.Windows.Forms.Label label2;
    }
}