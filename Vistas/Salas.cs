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
    public partial class Salas : Form
    {
        private readonly SalasDAL _dal = new();
        private int _salaIdSeleccionada = 0;

        public Salas()
        {
            InitializeComponent();
            this.Load += Salas_Load;
            dgvSalas.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                var fila = dgvSalas.Rows[e.RowIndex];
                _salaIdSeleccionada = Convert.ToInt32(fila.Cells["sala_id"].Value);
                txtNombSala.Text = fila.Cells["nombre"].Value?.ToString() ?? "";
                txtCapacidadSala.Text = fila.Cells["capacidad"].Value?.ToString() ?? "";
                txtTipoSala.Text = fila.Cells["tipo"].Value?.ToString() ?? "";
            };
            btnGuardarSala.Click += BtnGuardar_Click;
            btnCancelarSala.Click += (s, e) => LimpiarFormulario();
            Estilos.AplicarForm(this);
        }

        private void Salas_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarGrid();
        }

        private void ConfigurarGrid()
        {
            dgvSalas.ReadOnly = true;
            dgvSalas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSalas.MultiSelect = false;
            dgvSalas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalas.AllowUserToAddRows = false;
        }

        private void CargarGrid()
        {
            dgvSalas.DataSource = _dal.ObtenerTodas();
        }
        /*
        private void DgvSalas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSalas.CurrentRow == null) return;
            var fila = dgvSalas.CurrentRow;

            _salaIdSeleccionada = Convert.ToInt32(fila.Cells["sala_id"].Value);
            txtNombSala.Text = fila.Cells["nombre"].Value?.ToString() ?? "";
            txtCapacidadSala.Text = fila.Cells["capacidad"].Value?.ToString() ?? "";
            txtTipoSala.Text = fila.Cells["tipo"].Value?.ToString() ?? "";
        }*/

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombSala.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCapacidadSala.Text, out int capacidad) || capacidad <= 0)
            {
                MessageBox.Show("Capacidad invalida.", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var s = new Sala
            {
                SalaId = _salaIdSeleccionada,
                Nombre = txtNombSala.Text.Trim(),
                Capacidad = capacidad,
                Tipo = string.IsNullOrWhiteSpace(txtTipoSala.Text) ? "Normal" : txtTipoSala.Text.Trim(),
                Activa = 1
            };

            bool ok = _dal.Guardar(s, out string mensaje);

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
            _salaIdSeleccionada = 0;
            txtNombSala.Clear();
            txtCapacidadSala.Clear();
            txtTipoSala.Clear();
            dgvSalas.ClearSelection();
        }
    }
}
