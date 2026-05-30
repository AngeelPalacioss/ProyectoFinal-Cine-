namespace ProyectoFinal.Vistas
{
    partial class Funciones
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
            dateTimePicker1 = new DateTimePicker();
            btnFiltrarFecha = new Button();
            dgvFunciones = new DataGridView();
            panel1 = new Panel();
            btnCancelarFuncion = new Button();
            btnGuardarFuncion = new Button();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            dtpFechaFuncion = new DateTimePicker();
            txtHoraInicio = new TextBox();
            txtCosto = new TextBox();
            cbPeliculas = new ComboBox();
            cbEstadoFuncion = new ComboBox();
            cbSalas = new ComboBox();
            label8 = new Label();
            txtHoraFinal = new TextBox();
            label1 = new Label();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFunciones).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(37, 65);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(234, 23);
            dateTimePicker1.TabIndex = 0;
            // 
            // btnFiltrarFecha
            // 
            btnFiltrarFecha.Location = new Point(313, 65);
            btnFiltrarFecha.Name = "btnFiltrarFecha";
            btnFiltrarFecha.Size = new Size(75, 23);
            btnFiltrarFecha.TabIndex = 1;
            btnFiltrarFecha.Text = "Filtrar";
            btnFiltrarFecha.UseVisualStyleBackColor = true;
            // 
            // dgvFunciones
            // 
            dgvFunciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFunciones.Location = new Point(37, 121);
            dgvFunciones.Name = "dgvFunciones";
            dgvFunciones.Size = new Size(737, 159);
            dgvFunciones.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtHoraFinal);
            panel1.Controls.Add(cbSalas);
            panel1.Controls.Add(cbEstadoFuncion);
            panel1.Controls.Add(cbPeliculas);
            panel1.Controls.Add(btnCancelarFuncion);
            panel1.Controls.Add(btnGuardarFuncion);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dtpFechaFuncion);
            panel1.Controls.Add(txtHoraInicio);
            panel1.Controls.Add(txtCosto);
            panel1.Location = new Point(37, 322);
            panel1.Name = "panel1";
            panel1.Size = new Size(737, 278);
            panel1.TabIndex = 4;
            // 
            // btnCancelarFuncion
            // 
            btnCancelarFuncion.Location = new Point(582, 222);
            btnCancelarFuncion.Name = "btnCancelarFuncion";
            btnCancelarFuncion.Size = new Size(75, 23);
            btnCancelarFuncion.TabIndex = 15;
            btnCancelarFuncion.Text = "Cancelar";
            btnCancelarFuncion.UseVisualStyleBackColor = true;
            btnCancelarFuncion.Click += btnCancelarPeli_Click;
            // 
            // btnGuardarFuncion
            // 
            btnGuardarFuncion.Location = new Point(469, 222);
            btnGuardarFuncion.Name = "btnGuardarFuncion";
            btnGuardarFuncion.Size = new Size(75, 23);
            btnGuardarFuncion.TabIndex = 14;
            btnGuardarFuncion.Text = "Guardar";
            btnGuardarFuncion.UseVisualStyleBackColor = true;
            btnGuardarFuncion.Click += this.btnGuardarPeli_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(487, 130);
            label7.Name = "label7";
            label7.Size = new Size(41, 15);
            label7.TabIndex = 12;
            label7.Text = "Costo:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(487, 70);
            label6.Name = "label6";
            label6.Size = new Size(84, 15);
            label6.TabIndex = 11;
            label6.Text = "Hora de Inicio:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(487, 15);
            label5.Name = "label5";
            label5.Size = new Size(31, 15);
            label5.TabIndex = 10;
            label5.Text = "Sala:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 130);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 9;
            label4.Text = "Hora de Final:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 70);
            label3.Name = "label3";
            label3.Size = new Size(41, 15);
            label3.TabIndex = 8;
            label3.Text = "Fecha:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 15);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 7;
            label2.Text = "Pelicula:";
            // 
            // dtpFechaFuncion
            // 
            dtpFechaFuncion.Location = new Point(55, 91);
            dtpFechaFuncion.Name = "dtpFechaFuncion";
            dtpFechaFuncion.Size = new Size(189, 23);
            dtpFechaFuncion.TabIndex = 5;
            // 
            // txtHoraInicio
            // 
            txtHoraInicio.Location = new Point(468, 91);
            txtHoraInicio.Name = "txtHoraInicio";
            txtHoraInicio.Size = new Size(189, 23);
            txtHoraInicio.TabIndex = 3;
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(468, 151);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(189, 23);
            txtCosto.TabIndex = 1;
            // 
            // cbPeliculas
            // 
            cbPeliculas.FormattingEnabled = true;
            cbPeliculas.Location = new Point(55, 33);
            cbPeliculas.Name = "cbPeliculas";
            cbPeliculas.Size = new Size(189, 23);
            cbPeliculas.TabIndex = 16;
            // 
            // cbEstadoFuncion
            // 
            cbEstadoFuncion.FormattingEnabled = true;
            cbEstadoFuncion.Location = new Point(55, 222);
            cbEstadoFuncion.Name = "cbEstadoFuncion";
            cbEstadoFuncion.Size = new Size(189, 23);
            cbEstadoFuncion.TabIndex = 17;
            // 
            // cbSalas
            // 
            cbSalas.FormattingEnabled = true;
            cbSalas.Location = new Point(468, 33);
            cbSalas.Name = "cbSalas";
            cbSalas.Size = new Size(189, 23);
            cbSalas.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(73, 191);
            label8.Name = "label8";
            label8.Size = new Size(45, 15);
            label8.TabIndex = 13;
            label8.Text = "Estado:";
            label8.Click += label8_Click;
            // 
            // txtHoraFinal
            // 
            txtHoraFinal.Location = new Point(55, 151);
            txtHoraFinal.Name = "txtHoraFinal";
            txtHoraFinal.Size = new Size(189, 23);
            txtHoraFinal.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 27);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 5;
            label1.Text = "Funciones";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(37, 304);
            label9.Name = "label9";
            label9.Size = new Size(125, 15);
            label9.TabIndex = 8;
            label9.Text = "Nueva Funcion/ Editar";
            // 
            // Funciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 622);
            Controls.Add(label9);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(dgvFunciones);
            Controls.Add(btnFiltrarFecha);
            Controls.Add(dateTimePicker1);
            Name = "Funciones";
            Text = "Funciones";
            ((System.ComponentModel.ISupportInitialize)dgvFunciones).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dateTimePicker1;
        private Button btnFiltrarFecha;
        private DataGridView dgvFunciones;
        private Panel panel1;
        private ComboBox cbSalas;
        private ComboBox cbEstadoFuncion;
        private ComboBox cbPeliculas;
        private Button btnCancelarFuncion;
        private Button btnGuardarFuncion;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private DateTimePicker dtpFechaFuncion;
        private TextBox txtHoraInicio;
        private TextBox txtCosto;
        private TextBox txtHoraFinal;
        private Label label1;
        private Label label9;
    }
}