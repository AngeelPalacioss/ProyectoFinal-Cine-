namespace ProyectoFinal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            btnIngresar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(97, 170);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 8;
            label1.Text = "Sistema de Cine";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(120, 215);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 9;
            label2.Text = "Usuario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(109, 296);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 10;
            label3.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(97, 248);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(100, 23);
            txtUsuario.TabIndex = 11;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(97, 334);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(100, 23);
            txtContraseña.TabIndex = 12;
            txtContraseña.TextChanged += textBox2_TextChanged;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(113, 387);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(75, 23);
            btnIngresar.TabIndex = 13;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(305, 434);
            Controls.Add(btnIngresar);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Button btnIngresar;
    }
}
