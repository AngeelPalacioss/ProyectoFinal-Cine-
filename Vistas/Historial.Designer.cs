namespace ProyectoFinal.Vistas
{
    partial class Historial
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
            label1 = new Label();
            label2 = new Label();
            dtpInicioReporte = new DateTimePicker();
            dtpFinReporte = new DateTimePicker();
            txtBuscarHistorial = new TextBox();
            label3 = new Label();
            btnBuscarHistorial = new Button();
            dgvHistorial = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 58);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 0;
            label1.Text = "Desde:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(372, 58);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 1;
            label2.Text = "Hasta:";
            // 
            // dtpInicioReporte
            // 
            dtpInicioReporte.Location = new Point(111, 50);
            dtpInicioReporte.Name = "dtpInicioReporte";
            dtpInicioReporte.Size = new Size(230, 23);
            dtpInicioReporte.TabIndex = 2;
            // 
            // dtpFinReporte
            // 
            dtpFinReporte.Location = new Point(441, 52);
            dtpFinReporte.Name = "dtpFinReporte";
            dtpFinReporte.Size = new Size(230, 23);
            dtpFinReporte.TabIndex = 3;
            // 
            // txtBuscarHistorial
            // 
            txtBuscarHistorial.Location = new Point(259, 100);
            txtBuscarHistorial.Name = "txtBuscarHistorial";
            txtBuscarHistorial.Size = new Size(230, 23);
            txtBuscarHistorial.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(139, 103);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 5;
            label3.Text = "Buscar Pelicula:";
            // 
            // btnBuscarHistorial
            // 
            btnBuscarHistorial.Location = new Point(549, 100);
            btnBuscarHistorial.Name = "btnBuscarHistorial";
            btnBuscarHistorial.Size = new Size(75, 23);
            btnBuscarHistorial.TabIndex = 6;
            btnBuscarHistorial.Text = "Buscar";
            btnBuscarHistorial.UseVisualStyleBackColor = true;
            // 
            // dgvHistorial
            // 
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(47, 161);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.Size = new Size(624, 150);
            dgvHistorial.TabIndex = 7;
            // 
            // Historial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(720, 356);
            Controls.Add(dgvHistorial);
            Controls.Add(btnBuscarHistorial);
            Controls.Add(label3);
            Controls.Add(txtBuscarHistorial);
            Controls.Add(dtpFinReporte);
            Controls.Add(dtpInicioReporte);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Historial";
            Text = "Historial";
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dtpInicioReporte;
        private DateTimePicker dtpFinReporte;
        private TextBox txtBuscarHistorial;
        private Label label3;
        private Button btnBuscarHistorial;
        private DataGridView dgvHistorial;
    }
}