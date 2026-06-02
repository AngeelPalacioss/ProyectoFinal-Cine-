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
    public partial class Descuentos : Form
    {
        private readonly DescuentosDAL _dal = new();
        private int _descIdSeleccionado = 0;

        public Descuentos()
        {
            InitializeComponent();
            this.Load += Descuentos_Load;
            dgvDescuentos.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                var fila = dgvDescuentos.Rows[e.RowIndex];
                _descIdSeleccionado = Convert.ToInt32(fila.Cells["desc_id"].Value);
                txtNombreDesc.Text = fila.Cells["nombre"].Value?.ToString() ?? "";
                txtPorcentajeDesc.Text = fila.Cells["porcentaje"].Value?.ToString() ?? "";
                txtDiasDesc.Text = fila.Cells["dia_semana"].Value?.ToString() ?? "";
                txtHoraInicioDesc.Text = fila.Cells["hora_inicio"].Value?.ToString() ?? "";
                txtHoraFinalDesc.Text = fila.Cells["hora_fin"].Value?.ToString() ?? "";
                txtActivoDesc.Text = fila.Cells["activo"].Value?.ToString() ?? "";
            };
            btnGuardarDesc.Click += BtnGuardar_Click;
            btnCancelarDesc.Click += (s, e) => LimpiarFormulario();

            Estilos.AplicarForm(this);
        }

        private void Descuentos_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarGrid();
        }

        private void ConfigurarGrid()
        {
            dgvDescuentos.ReadOnly = true;
            dgvDescuentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDescuentos.MultiSelect = false;
            dgvDescuentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDescuentos.AllowUserToAddRows = false;
        }

        private void CargarGrid()
        {
            dgvDescuentos.DataSource = _dal.ObtenerTodos();
        }

        /*
        private void DgvDescuentos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDescuentos.CurrentRow == null) return;
            var fila = dgvDescuentos.CurrentRow;

            _descIdSeleccionado = Convert.ToInt32(fila.Cells["desc_id"].Value);
            txtNombreDesc.Text = fila.Cells["nombre"].Value?.ToString() ?? "";
            txtPorcentajeDesc.Text = fila.Cells["porcentaje"].Value?.ToString() ?? "";
            txtDiasDesc.Text = fila.Cells["dia_semana"].Value?.ToString() ?? "";
            txtHoraInicioDesc.Text = fila.Cells["hora_inicio"].Value?.ToString() ?? "";
            txtHoraFinalDesc.Text = fila.Cells["hora_fin"].Value?.ToString() ?? "";
            txtActivoDesc.Text = fila.Cells["activo"].Value?.ToString() ?? "";
        }*/

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreDesc.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPorcentajeDesc.Text, out decimal pct) || pct <= 0 || pct > 100)
            {
                MessageBox.Show("Porcentaje invalido (1-100).", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var d = new Descuento
            {
                DescId = _descIdSeleccionado,
                Nombre = txtNombreDesc.Text.Trim(),
                Porcentaje = pct,
                DiaSemana = string.IsNullOrWhiteSpace(txtDiasDesc.Text) ? "Todos" : txtDiasDesc.Text.Trim(),
                HoraInicio = string.IsNullOrWhiteSpace(txtHoraInicioDesc.Text) ? "00:00" : txtHoraInicioDesc.Text.Trim(),
                HoraFin = string.IsNullOrWhiteSpace(txtHoraFinalDesc.Text) ? "23:59" : txtHoraFinalDesc.Text.Trim(),
                Activo = txtActivoDesc.Text == "0" ? 0 : 1
            };

            bool ok = _dal.Guardar(d, out string mensaje);

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
            _descIdSeleccionado = 0;
            txtNombreDesc.Clear();
            txtPorcentajeDesc.Clear();
            txtDiasDesc.Clear();
            txtHoraInicioDesc.Clear();
            txtHoraFinalDesc.Clear();
            txtActivoDesc.Text = "1";
            dgvDescuentos.ClearSelection();
        }

        private void label2_Click(object sender, EventArgs e) { }
    }
}
