namespace ProyectoFinal.Vistas
{
    partial class Descuentos
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
            txtPorcentajeDesc = new TextBox();
            txtNombreDesc = new TextBox();
            txtDiasDesc = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            dgvDescuentos = new DataGridView();
            label9 = new Label();
            label1 = new Label();
            txtHoraInicioDesc = new TextBox();
            txtHoraFinalDesc = new TextBox();
            txtActivoDesc = new TextBox();
            btnGuardarDesc = new Button();
            btnCancelarDesc = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDescuentos).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancelarDesc);
            panel1.Controls.Add(btnGuardarDesc);
            panel1.Controls.Add(txtActivoDesc);
            panel1.Controls.Add(txtHoraFinalDesc);
            panel1.Controls.Add(txtHoraInicioDesc);
            panel1.Controls.Add(txtPorcentajeDesc);
            panel1.Controls.Add(txtNombreDesc);
            panel1.Controls.Add(txtDiasDesc);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(32, 290);
            panel1.Name = "panel1";
            panel1.Size = new Size(737, 269);
            panel1.TabIndex = 6;
            // 
            // txtPorcentajeDesc
            // 
            txtPorcentajeDesc.Location = new Point(468, 33);
            txtPorcentajeDesc.Name = "txtPorcentajeDesc";
            txtPorcentajeDesc.Size = new Size(189, 23);
            txtPorcentajeDesc.TabIndex = 22;
            // 
            // txtNombreDesc
            // 
            txtNombreDesc.Location = new Point(55, 33);
            txtNombreDesc.Name = "txtNombreDesc";
            txtNombreDesc.Size = new Size(189, 23);
            txtNombreDesc.TabIndex = 21;
            // 
            // txtDiasDesc
            // 
            txtDiasDesc.Location = new Point(55, 91);
            txtDiasDesc.Name = "txtDiasDesc";
            txtDiasDesc.Size = new Size(189, 23);
            txtDiasDesc.TabIndex = 20;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(487, 130);
            label7.Name = "label7";
            label7.Size = new Size(44, 15);
            label7.TabIndex = 12;
            label7.Text = "Activo:";
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
            label5.Size = new Size(66, 15);
            label5.TabIndex = 10;
            label5.Text = "Porcentaje:";
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
            label3.Size = new Size(105, 15);
            label3.TabIndex = 8;
            label3.Text = "Dias de la Semana:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 15);
            label2.Name = "label2";
            label2.Size = new Size(132, 15);
            label2.TabIndex = 7;
            label2.Text = "Nombre del Descuento:";
            label2.Click += label2_Click;
            // 
            // dgvDescuentos
            // 
            dgvDescuentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDescuentos.Location = new Point(32, 67);
            dgvDescuentos.Name = "dgvDescuentos";
            dgvDescuentos.Size = new Size(737, 159);
            dgvDescuentos.TabIndex = 5;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(32, 272);
            label9.Name = "label9";
            label9.Size = new Size(139, 15);
            label9.TabIndex = 20;
            label9.Text = "Nuevo Descuento/ Editar";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 24);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 21;
            label1.Text = "Descuentos";
            // 
            // txtHoraInicioDesc
            // 
            txtHoraInicioDesc.Location = new Point(468, 91);
            txtHoraInicioDesc.Name = "txtHoraInicioDesc";
            txtHoraInicioDesc.Size = new Size(189, 23);
            txtHoraInicioDesc.TabIndex = 23;
            // 
            // txtHoraFinalDesc
            // 
            txtHoraFinalDesc.Location = new Point(55, 148);
            txtHoraFinalDesc.Name = "txtHoraFinalDesc";
            txtHoraFinalDesc.Size = new Size(189, 23);
            txtHoraFinalDesc.TabIndex = 24;
            // 
            // txtActivoDesc
            // 
            txtActivoDesc.Location = new Point(468, 148);
            txtActivoDesc.Name = "txtActivoDesc";
            txtActivoDesc.Size = new Size(189, 23);
            txtActivoDesc.TabIndex = 25;
            // 
            // btnGuardarDesc
            // 
            btnGuardarDesc.Location = new Point(259, 216);
            btnGuardarDesc.Name = "btnGuardarDesc";
            btnGuardarDesc.Size = new Size(75, 23);
            btnGuardarDesc.TabIndex = 26;
            btnGuardarDesc.Text = "Guardar";
            btnGuardarDesc.UseVisualStyleBackColor = true;
            // 
            // btnCancelarDesc
            // 
            btnCancelarDesc.Location = new Point(375, 216);
            btnCancelarDesc.Name = "btnCancelarDesc";
            btnCancelarDesc.Size = new Size(75, 23);
            btnCancelarDesc.TabIndex = 27;
            btnCancelarDesc.Text = "Cancelar";
            btnCancelarDesc.UseVisualStyleBackColor = true;
            // 
            // Descuentos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 589);
            Controls.Add(label1);
            Controls.Add(label9);
            Controls.Add(panel1);
            Controls.Add(dgvDescuentos);
            Name = "Descuentos";
            Text = "Descuentos";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDescuentos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox txtHoraFinal;
        private ComboBox cbEstadoFuncion;
        private Button btnCancelarFuncion;
        private Button btnGuardarFuncion;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtHoraInicio;
        private TextBox txtCosto;
        private DataGridView dgvDescuentos;
        private Label label9;
        private TextBox txtPorcentajeDesc;
        private TextBox txtNombreDesc;
        private TextBox txtDiasDesc;
        private Label label1;
        private TextBox txtHoraFinalDesc;
        private TextBox txtHoraInicioDesc;
        private Button btnCancelarDesc;
        private Button btnGuardarDesc;
        private TextBox txtActivoDesc;
    }
}