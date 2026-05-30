namespace ProyectoFinal.Vistas
{
    partial class Peliculas
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
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            dgvPeliculas = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            txtNombrePeli = new TextBox();
            txtFGeneroPeli = new TextBox();
            txtDirectorPeli = new TextBox();
            txtClasificacionPeli = new TextBox();
            txtDuracionPeli = new TextBox();
            dtpFechaEstreno = new DateTimePicker();
            rtbSinopsis = new RichTextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            btnGuardarPeli = new Button();
            btnCancelarPeli = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPeliculas).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(388, 29);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(204, 23);
            txtBuscar.TabIndex = 0;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(610, 28);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 1;
            btnBuscar.TabStop = false;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // dgvPeliculas
            // 
            dgvPeliculas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPeliculas.Location = new Point(28, 84);
            dgvPeliculas.Name = "dgvPeliculas";
            dgvPeliculas.Size = new Size(737, 170);
            dgvPeliculas.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancelarPeli);
            panel1.Controls.Add(btnGuardarPeli);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(rtbSinopsis);
            panel1.Controls.Add(dtpFechaEstreno);
            panel1.Controls.Add(txtDuracionPeli);
            panel1.Controls.Add(txtClasificacionPeli);
            panel1.Controls.Add(txtDirectorPeli);
            panel1.Controls.Add(txtFGeneroPeli);
            panel1.Controls.Add(txtNombrePeli);
            panel1.Location = new Point(28, 287);
            panel1.Name = "panel1";
            panel1.Size = new Size(737, 309);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 269);
            label1.Name = "label1";
            label1.Size = new Size(123, 15);
            label1.TabIndex = 4;
            label1.Text = "Nueva Pelicula/ Editar";
            // 
            // txtNombrePeli
            // 
            txtNombrePeli.Location = new Point(55, 33);
            txtNombrePeli.Name = "txtNombrePeli";
            txtNombrePeli.Size = new Size(189, 23);
            txtNombrePeli.TabIndex = 0;
            // 
            // txtFGeneroPeli
            // 
            txtFGeneroPeli.Location = new Point(55, 88);
            txtFGeneroPeli.Name = "txtFGeneroPeli";
            txtFGeneroPeli.Size = new Size(189, 23);
            txtFGeneroPeli.TabIndex = 1;
            // 
            // txtDirectorPeli
            // 
            txtDirectorPeli.Location = new Point(468, 33);
            txtDirectorPeli.Name = "txtDirectorPeli";
            txtDirectorPeli.Size = new Size(189, 23);
            txtDirectorPeli.TabIndex = 2;
            // 
            // txtClasificacionPeli
            // 
            txtClasificacionPeli.Location = new Point(468, 88);
            txtClasificacionPeli.Name = "txtClasificacionPeli";
            txtClasificacionPeli.Size = new Size(189, 23);
            txtClasificacionPeli.TabIndex = 3;
            // 
            // txtDuracionPeli
            // 
            txtDuracionPeli.Location = new Point(55, 148);
            txtDuracionPeli.Name = "txtDuracionPeli";
            txtDuracionPeli.Size = new Size(189, 23);
            txtDuracionPeli.TabIndex = 4;
            // 
            // dtpFechaEstreno
            // 
            dtpFechaEstreno.Location = new Point(468, 148);
            dtpFechaEstreno.Name = "dtpFechaEstreno";
            dtpFechaEstreno.Size = new Size(189, 23);
            dtpFechaEstreno.TabIndex = 5;
            // 
            // rtbSinopsis
            // 
            rtbSinopsis.Location = new Point(55, 209);
            rtbSinopsis.Name = "rtbSinopsis";
            rtbSinopsis.Size = new Size(602, 54);
            rtbSinopsis.TabIndex = 6;
            rtbSinopsis.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 15);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 7;
            label2.Text = "Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 70);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 8;
            label3.Text = "Genero:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 130);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 9;
            label4.Text = "Duracion:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(487, 15);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 10;
            label5.Text = "Director:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(487, 70);
            label6.Name = "label6";
            label6.Size = new Size(77, 15);
            label6.TabIndex = 11;
            label6.Text = "Clasificacion:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(487, 130);
            label7.Name = "label7";
            label7.Size = new Size(99, 15);
            label7.TabIndex = 12;
            label7.Text = "Fecha de Estreno:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(73, 191);
            label8.Name = "label8";
            label8.Size = new Size(53, 15);
            label8.TabIndex = 13;
            label8.Text = "Sinopsis:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(28, 32);
            label9.Name = "label9";
            label9.Size = new Size(120, 15);
            label9.TabIndex = 5;
            label9.Text = "Catalogo de Peliculas";
            // 
            // btnGuardarPeli
            // 
            btnGuardarPeli.Location = new Point(266, 269);
            btnGuardarPeli.Name = "btnGuardarPeli";
            btnGuardarPeli.Size = new Size(75, 23);
            btnGuardarPeli.TabIndex = 14;
            btnGuardarPeli.Text = "Guardar";
            btnGuardarPeli.UseVisualStyleBackColor = true;
            // 
            // btnCancelarPeli
            // 
            btnCancelarPeli.Location = new Point(379, 269);
            btnCancelarPeli.Name = "btnCancelarPeli";
            btnCancelarPeli.Size = new Size(75, 23);
            btnCancelarPeli.TabIndex = 15;
            btnCancelarPeli.Text = "Cancelar";
            btnCancelarPeli.UseVisualStyleBackColor = true;
            // 
            // Peliculas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 639);
            Controls.Add(label9);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(dgvPeliculas);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Name = "Peliculas";
            Text = "Peliculas";
            ((System.ComponentModel.ISupportInitialize)dgvPeliculas).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvPeliculas;
        private Panel panel1;
        private RichTextBox rtbSinopsis;
        private DateTimePicker dtpFechaEstreno;
        private TextBox txtDuracionPeli;
        private TextBox txtClasificacionPeli;
        private TextBox txtDirectorPeli;
        private TextBox txtFGeneroPeli;
        private TextBox txtNombrePeli;
        private Label label1;
        private Button btnCancelarPeli;
        private Button btnGuardarPeli;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label9;
    }
}