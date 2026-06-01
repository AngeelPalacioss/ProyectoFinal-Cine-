using ProyectoFinal.DAL;

namespace ProyectoFinal
{
    public partial class Form1 : Form
    {
        private readonly LoginDAL _loginDAL = new();

        public Form1()
        {
            InitializeComponent();
            // Ocultar password
            txtContraseña.PasswordChar = '*';
            // Enter en cualquier campo dispara login
            txtUsuario.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) Ingresar(); };
            txtContraseña.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) Ingresar(); };
        }

        private void btnIngresar_Click(object sender, EventArgs e) => Ingresar();

        private void Ingresar()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Ingresa usuario y contrasena.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            
            
            bool ok = _loginDAL.Autenticar(txtUsuario.Text.Trim(),
                                           txtContraseña.Text.Trim(),
                                           out string mensaje);
            if (ok)
            {
                var menu = new Vistas.MenuPrincipal();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(mensaje, "Error de acceso",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraseña.Clear();
                txtUsuario.Focus();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e) { }
    }
}