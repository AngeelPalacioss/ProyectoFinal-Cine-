namespace ProyectoFinal.Vistas
{
    partial class Ventas
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
            dateTimePicker1 = new DateTimePicker();
            label2 = new Label();
            btnFuncionesVenta = new Button();
            dgvVentas = new DataGridView();
            label9 = new Label();
            panel1 = new Panel();
            txtPrecioBase = new TextBox();
            txtCantBoletos = new TextBox();
            txtDescuentoAplic = new TextBox();
            btnCancelarVenta = new Button();
            btnConfirmarVenta = new Button();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label8 = new Label();
            txtTotal = new TextBox();
            cbPeliculaSelec = new ComboBox();
            cbTipoBoleto = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 30);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 0;
            label1.Text = "Sistema de Ventas";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(90, 64);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(261, 23);
            dateTimePicker1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 64);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 2;
            label2.Text = "Fecha:";
            // 
            // btnFuncionesVenta
            // 
            btnFuncionesVenta.Location = new Point(380, 66);
            btnFuncionesVenta.Name = "btnFuncionesVenta";
            btnFuncionesVenta.Size = new Size(101, 23);
            btnFuncionesVenta.TabIndex = 3;
            btnFuncionesVenta.Text = "Ver Funciones";
            btnFuncionesVenta.UseVisualStyleBackColor = true;
            // 
            // dgvVentas
            // 
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(25, 118);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.Size = new Size(737, 156);
            dgvVentas.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(25, 277);
            label9.Name = "label9";
            label9.Size = new Size(88, 15);
            label9.TabIndex = 22;
            label9.Text = "Datos de Venta:";
            // 
            // panel1
            // 
            panel1.Controls.Add(cbTipoBoleto);
            panel1.Controls.Add(cbPeliculaSelec);
            panel1.Controls.Add(txtPrecioBase);
            panel1.Controls.Add(txtCantBoletos);
            panel1.Controls.Add(txtDescuentoAplic);
            panel1.Controls.Add(btnCancelarVenta);
            panel1.Controls.Add(btnConfirmarVenta);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtTotal);
            panel1.Location = new Point(25, 300);
            panel1.Name = "panel1";
            panel1.Size = new Size(737, 269);
            panel1.TabIndex = 21;
            // 
            // txtPrecioBase
            // 
            txtPrecioBase.Location = new Point(468, 33);
            txtPrecioBase.Name = "txtPrecioBase";
            txtPrecioBase.Size = new Size(189, 23);
            txtPrecioBase.TabIndex = 22;
            // 
            // txtCantBoletos
            // 
            txtCantBoletos.Location = new Point(55, 91);
            txtCantBoletos.Name = "txtCantBoletos";
            txtCantBoletos.Size = new Size(189, 23);
            txtCantBoletos.TabIndex = 20;
            // 
            // txtDescuentoAplic
            // 
            txtDescuentoAplic.Enabled = false;
            txtDescuentoAplic.Location = new Point(55, 151);
            txtDescuentoAplic.Name = "txtDescuentoAplic";
            txtDescuentoAplic.Size = new Size(189, 23);
            txtDescuentoAplic.TabIndex = 19;
            // 
            // btnCancelarVenta
            // 
            btnCancelarVenta.BackColor = Color.Red;
            btnCancelarVenta.Location = new Point(370, 222);
            btnCancelarVenta.Name = "btnCancelarVenta";
            btnCancelarVenta.Size = new Size(75, 23);
            btnCancelarVenta.TabIndex = 15;
            btnCancelarVenta.Text = "Cancelar";
            btnCancelarVenta.UseVisualStyleBackColor = false;
            // 
            // btnConfirmarVenta
            // 
            btnConfirmarVenta.BackColor = Color.Lime;
            btnConfirmarVenta.Location = new Point(228, 222);
            btnConfirmarVenta.Name = "btnConfirmarVenta";
            btnConfirmarVenta.Size = new Size(109, 23);
            btnConfirmarVenta.TabIndex = 14;
            btnConfirmarVenta.Text = "Confirmar Venta";
            btnConfirmarVenta.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Enabled = false;
            label7.Location = new Point(487, 130);
            label7.Name = "label7";
            label7.Size = new Size(78, 15);
            label7.TabIndex = 12;
            label7.Text = "Total a Pagar:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(487, 70);
            label6.Name = "label6";
            label6.Size = new Size(87, 15);
            label6.TabIndex = 11;
            label6.Text = "Tipo de Boleto:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(487, 15);
            label5.Name = "label5";
            label5.Size = new Size(70, 15);
            label5.TabIndex = 10;
            label5.Text = "Precio Base:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(73, 130);
            label4.Name = "label4";
            label4.Size = new Size(116, 15);
            label4.TabIndex = 9;
            label4.Text = "Descuento Aplicado:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(73, 70);
            label3.Name = "label3";
            label3.Size = new Size(116, 15);
            label3.TabIndex = 8;
            label3.Text = "Cantidad de Boletos:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(73, 15);
            label8.Name = "label8";
            label8.Size = new Size(123, 15);
            label8.TabIndex = 7;
            label8.Text = "Pelicula Seleccionada:";
            // 
            // txtTotal
            // 
            txtTotal.Enabled = false;
            txtTotal.Location = new Point(468, 151);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(189, 23);
            txtTotal.TabIndex = 1;
            // 
            // cbPeliculaSelec
            // 
            cbPeliculaSelec.FormattingEnabled = true;
            cbPeliculaSelec.Location = new Point(55, 33);
            cbPeliculaSelec.Name = "cbPeliculaSelec";
            cbPeliculaSelec.Size = new Size(189, 23);
            cbPeliculaSelec.TabIndex = 23;
            // 
            // cbTipoBoleto
            // 
            cbTipoBoleto.FormattingEnabled = true;
            cbTipoBoleto.Location = new Point(468, 91);
            cbTipoBoleto.Name = "cbTipoBoleto";
            cbTipoBoleto.Size = new Size(189, 23);
            cbTipoBoleto.TabIndex = 24;
            // 
            // Ventas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 581);
            Controls.Add(label9);
            Controls.Add(panel1);
            Controls.Add(dgvVentas);
            Controls.Add(btnFuncionesVenta);
            Controls.Add(label2);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            Name = "Ventas";
            Text = "Ventas";
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Label label2;
        private Button btnFuncionesVenta;
        private DataGridView dgvVentas;
        private Label label9;
        private Panel panel1;
        private TextBox txtPrecioBase;
        private TextBox txtCantBoletos;
        private TextBox txtDescuentoAplic;
        private Button btnCancelarVenta;
        private Button btnConfirmarVenta;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label8;
        private TextBox txtTotal;
        private ComboBox cbPeliculaSelec;
        private ComboBox cbTipoBoleto;
    }
}