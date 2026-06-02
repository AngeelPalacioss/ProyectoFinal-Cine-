using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProyectoFinal.DAL;
using ProyectoFinal.Modelos;

namespace ProyectoFinal.Vistas
{
    public partial class Peliculas : Form
    {
        private readonly PeliculasDAL _dal = new();
        private int _pelIdSeleccionada = 0;

        public Peliculas()
        {
            InitializeComponent();
            this.Load += Peliculas_Load;
            dgvPeliculas.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                var fila = dgvPeliculas.Rows[e.RowIndex];
                _pelIdSeleccionada = Convert.ToInt32(fila.Cells["pel_id"].Value);
                txtNombrePeli.Text = fila.Cells["titulo"].Value?.ToString() ?? "";
                txtFGeneroPeli.Text = fila.Cells["genero"].Value?.ToString() ?? "";
                txtDirectorPeli.Text = fila.Cells["director"].Value?.ToString() ?? "";
                txtClasificacionPeli.Text = fila.Cells["clasificacion"].Value?.ToString() ?? "";
                txtDuracionPeli.Text = fila.Cells["duracion_min"].Value?.ToString() ?? "";
                if (fila.Cells["fecha_estreno"].Value != DBNull.Value &&
                    fila.Cells["fecha_estreno"].Value != null)
                    dtpFechaEstreno.Value = Convert.ToDateTime(fila.Cells["fecha_estreno"].Value);
            };
            btnBuscar.Click += (s, e) => CargarGrid(txtBuscar.Text.Trim());
            btnGuardarPeli.Click += BtnGuardar_Click;
            btnCancelarPeli.Click += (s, e) => LimpiarFormulario();
            txtBuscar.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) CargarGrid(txtBuscar.Text.Trim()); };

            Estilos.AplicarForm(this);
        }

        private void Peliculas_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarGrid();
        }

        private void ConfigurarGrid()
        {
            dgvPeliculas.ReadOnly = true;
            dgvPeliculas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPeliculas.MultiSelect = false;
            dgvPeliculas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPeliculas.AllowUserToAddRows = false;
        }

        private void CargarGrid(string filtro = "")
        {
            dgvPeliculas.DataSource = _dal.ObtenerTodas(filtro);
        }

        /*
        private void DgvPeliculas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPeliculas.CurrentRow == null) return;
            var fila = dgvPeliculas.CurrentRow;

            _pelIdSeleccionada = Convert.ToInt32(fila.Cells["pel_id"].Value);
            txtNombrePeli.Text = fila.Cells["titulo"].Value?.ToString() ?? "";
            txtFGeneroPeli.Text = fila.Cells["genero"].Value?.ToString() ?? "";
            txtDirectorPeli.Text = fila.Cells["director"].Value?.ToString() ?? "";
            txtClasificacionPeli.Text = fila.Cells["clasificacion"].Value?.ToString() ?? "";
            txtDuracionPeli.Text = fila.Cells["duracion_min"].Value?.ToString() ?? "";
            rtbSinopsis.Text = "";

            if (fila.Cells["fecha_estreno"].Value != DBNull.Value &&
                fila.Cells["fecha_estreno"].Value != null)
                dtpFechaEstreno.Value = Convert.ToDateTime(fila.Cells["fecha_estreno"].Value);
        }*/

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombrePeli.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtDuracionPeli.Text, out int duracion) || duracion <= 0)
            {
                MessageBox.Show("Duracion invalida.", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var p = new Pelicula
            {
                PelId = _pelIdSeleccionada,
                Titulo = txtNombrePeli.Text.Trim(),
                Director = txtDirectorPeli.Text.Trim(),
                Genero = txtFGeneroPeli.Text.Trim(),
                DuracionMin = duracion,
                Clasificacion = txtClasificacionPeli.Text.Trim(),
                Sinopsis = rtbSinopsis.Text.Trim(),
                FechaEstreno = dtpFechaEstreno.Value,
                Activa = 1
            };

            bool ok = _dal.Guardar(p, out string mensaje);

            if (ok)
            {
                MessageBox.Show("Guardado correctamente.", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarGrid();
            }
            else
            {
                MessageBox.Show("Error: " + mensaje, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarFormulario()
        {
            _pelIdSeleccionada = 0;
            txtNombrePeli.Clear();
            txtDirectorPeli.Clear();
            txtFGeneroPeli.Clear();
            txtClasificacionPeli.Clear();
            txtDuracionPeli.Clear();
            rtbSinopsis.Clear();
            dtpFechaEstreno.Value = DateTime.Today;
            dgvPeliculas.ClearSelection();
        }
    }
}
