namespace ProyectoFinal.Vistas
{
    partial class Salas
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
            panel1 = new Panel();
            btnCancelarSala = new Button();
            btnGuardarSala = new Button();
            aaa = new Label();
            label3 = new Label();
            label2 = new Label();
            txtCapacidadSala = new TextBox();
            txtTipoSala = new TextBox();
            txtNombSala = new TextBox();
            dgvSalas = new DataGridView();
            label1 = new Label();
            label4 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalas).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancelarSala);
            panel1.Controls.Add(btnGuardarSala);
            panel1.Controls.Add(aaa);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtCapacidadSala);
            panel1.Controls.Add(txtTipoSala);
            panel1.Controls.Add(txtNombSala);
            panel1.Location = new Point(31, 272);
            panel1.Name = "panel1";
            panel1.Size = new Size(737, 134);
            panel1.TabIndex = 5;
            // 
            // btnCancelarSala
            // 
            btnCancelarSala.Location = new Point(582, 87);
            btnCancelarSala.Name = "btnCancelarSala";
            btnCancelarSala.Size = new Size(75, 23);
            btnCancelarSala.TabIndex = 15;
            btnCancelarSala.Text = "Cancelar";
            btnCancelarSala.UseVisualStyleBackColor = true;
            // 
            // btnGuardarSala
            // 
            btnGuardarSala.Location = new Point(469, 87);
            btnGuardarSala.Name = "btnGuardarSala";
            btnGuardarSala.Size = new Size(75, 23);
            btnGuardarSala.TabIndex = 14;
            btnGuardarSala.Text = "Guardar";
            btnGuardarSala.UseVisualStyleBackColor = true;
            // 
            // aaa
            // 
            aaa.AutoSize = true;
            aaa.Location = new Point(487, 15);
            aaa.Name = "aaa";
            aaa.Size = new Size(66, 15);
            aaa.TabIndex = 10;
            aaa.Text = "Capacidad:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 70);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 8;
            label3.Text = "Tipo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 15);
            label2.Name = "label2";
            label2.Size = new Size(103, 15);
            label2.TabIndex = 7;
            label2.Text = "Nombre/Numero:";
            // 
            // txtCapacidadSala
            // 
            txtCapacidadSala.Location = new Point(468, 33);
            txtCapacidadSala.Name = "txtCapacidadSala";
            txtCapacidadSala.Size = new Size(189, 23);
            txtCapacidadSala.TabIndex = 2;
            // 
            // txtTipoSala
            // 
            txtTipoSala.Location = new Point(55, 88);
            txtTipoSala.Name = "txtTipoSala";
            txtTipoSala.Size = new Size(189, 23);
            txtTipoSala.TabIndex = 1;
            // 
            // txtNombSala
            // 
            txtNombSala.Location = new Point(55, 33);
            txtNombSala.Name = "txtNombSala";
            txtNombSala.Size = new Size(189, 23);
            txtNombSala.TabIndex = 0;
            // 
            // dgvSalas
            // 
            dgvSalas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalas.Location = new Point(31, 69);
            dgvSalas.Name = "dgvSalas";
            dgvSalas.Size = new Size(737, 170);
            dgvSalas.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 25);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 6;
            label1.Text = "Salas";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 254);
            label4.Name = "label4";
            label4.Size = new Size(103, 15);
            label4.TabIndex = 7;
            label4.Text = "Nueva Sala/ Editar";
            // 
            // Salas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 426);
            Controls.Add(label4);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(dgvSalas);
            Name = "Salas";
            Text = "Salas";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSalas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnCancelarSala;
        private Button btnGuardarSala;
        private Label aaa;
        private Label label3;
        private Label label2;
        private TextBox txtCapacidadSala;
        private TextBox txtTipoSala;
        private TextBox txtNombSala;
        private DataGridView dgvSalas;
        private Label label1;
        private Label label4;
    }
}