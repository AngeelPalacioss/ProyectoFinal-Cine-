namespace ProyectoFinal.Vistas
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            menuStrip1 = new MenuStrip();
            peliculasToolStripMenuItem = new ToolStripMenuItem();
            salasToolStripMenuItem = new ToolStripMenuItem();
            funcionesToolStripMenuItem = new ToolStripMenuItem();
            descuentosToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            lblUsuario = new Label();
            lblIngresos = new Label();
            lblBoletos = new Label();
            lblFunciones = new Label();
            lblFecha = new Label();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { peliculasToolStripMenuItem, salasToolStripMenuItem, funcionesToolStripMenuItem, descuentosToolStripMenuItem, usuariosToolStripMenuItem, ventasToolStripMenuItem, reportesToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(602, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // peliculasToolStripMenuItem
            // 
            peliculasToolStripMenuItem.Name = "peliculasToolStripMenuItem";
            peliculasToolStripMenuItem.Size = new Size(65, 20);
            peliculasToolStripMenuItem.Text = "Peliculas";
            // 
            // salasToolStripMenuItem
            // 
            salasToolStripMenuItem.Name = "salasToolStripMenuItem";
            salasToolStripMenuItem.Size = new Size(45, 20);
            salasToolStripMenuItem.Text = "Salas";
            // 
            // funcionesToolStripMenuItem
            // 
            funcionesToolStripMenuItem.Name = "funcionesToolStripMenuItem";
            funcionesToolStripMenuItem.Size = new Size(73, 20);
            funcionesToolStripMenuItem.Text = "Funciones";
            // 
            // descuentosToolStripMenuItem
            // 
            descuentosToolStripMenuItem.Name = "descuentosToolStripMenuItem";
            descuentosToolStripMenuItem.Size = new Size(80, 20);
            descuentosToolStripMenuItem.Text = "Descuentos";
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(64, 20);
            usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(53, 20);
            ventasToolStripMenuItem.Text = "Ventas";
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(65, 20);
            reportesToolStripMenuItem.Text = "Reportes";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(28, 109);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(38, 15);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "label1";
            // 
            // lblIngresos
            // 
            lblIngresos.AutoSize = true;
            lblIngresos.Location = new Point(443, 109);
            lblIngresos.Name = "lblIngresos";
            lblIngresos.Size = new Size(38, 15);
            lblIngresos.TabIndex = 2;
            lblIngresos.Text = "label2";
            // 
            // lblBoletos
            // 
            lblBoletos.AutoSize = true;
            lblBoletos.Location = new Point(50, 199);
            lblBoletos.Name = "lblBoletos";
            lblBoletos.Size = new Size(38, 15);
            lblBoletos.TabIndex = 3;
            lblBoletos.Text = "label3";
            // 
            // lblFunciones
            // 
            lblFunciones.AutoSize = true;
            lblFunciones.Location = new Point(454, 199);
            lblFunciones.Name = "lblFunciones";
            lblFunciones.Size = new Size(38, 15);
            lblFunciones.TabIndex = 4;
            lblFunciones.Text = "label4";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(198, 268);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(38, 15);
            lblFecha.TabIndex = 5;
            lblFecha.Text = "label5";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(236, 75);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(167, 164);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(602, 304);
            Controls.Add(pictureBox1);
            Controls.Add(lblFecha);
            Controls.Add(lblFunciones);
            Controls.Add(lblBoletos);
            Controls.Add(lblIngresos);
            Controls.Add(lblUsuario);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MenuPrincipal";
            Text = "Menu";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem peliculasToolStripMenuItem;
        private ToolStripMenuItem salasToolStripMenuItem;
        private ToolStripMenuItem funcionesToolStripMenuItem;
        private ToolStripMenuItem descuentosToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private Label lblUsuario;
        private Label lblIngresos;
        private Label lblBoletos;
        private Label lblFunciones;
        private Label lblFecha;
        private PictureBox pictureBox1;
    }
}