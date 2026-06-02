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
    public partial class Funciones : Form
    {
        private readonly FuncionesDAL _dal = new();
        private readonly PeliculasDAL _pelDal = new();
        private readonly SalasDAL _salaDal = new();
        private int _funcIdSeleccionada = 0;

        public Funciones()
        {
            InitializeComponent();
            this.Load += Funciones_Load;
            dgvFunciones.SelectionChanged += DgvFunciones_SelectionChanged;
            btnFiltrarFecha.Click += (s, e) => CargarGrid();
            btnGuardarFuncion.Click += BtnGuardar_Click;
            btnCancelarFuncion.Click += (s, e) => LimpiarFormulario();
            // Calcular hora fin automaticamente al cambiar hora inicio
            txtHoraInicio.Leave += CalcularHoraFin;
            cbPeliculas.SelectedIndexChanged += CalcularHoraFin;

            Estilos.AplicarForm(this);
        }

        private void Funciones_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarComboBoxes();
            CargarGrid();

            cbEstadoFuncion.Items.AddRange(new[] { "Activa", "Cancelada", "Finalizada" });
            cbEstadoFuncion.SelectedIndex = 0;
        }

        private void ConfigurarGrid()
        {
            dgvFunciones.ReadOnly = true;
            dgvFunciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFunciones.MultiSelect = false;
            dgvFunciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFunciones.AllowUserToAddRows = false;
        }

        private void CargarComboBoxes()
        {
            var peliculas = _pelDal.ObtenerTodas();
            cbPeliculas.DataSource = peliculas;
            cbPeliculas.DisplayMember = "titulo";
            cbPeliculas.ValueMember = "pel_id";

            var salas = _salaDal.ObtenerActivas();
            cbSalas.DataSource = salas;
            cbSalas.DisplayMember = "nombre";
            cbSalas.ValueMember = "sala_id";
        }

        private void CargarGrid()
        {
            dgvFunciones.DataSource = _dal.ObtenerPorFecha(dateTimePicker1.Value);
        }

        private void CalcularHoraFin(object? sender, EventArgs e)
        {
            if (cbPeliculas.SelectedValue == null) return;
            if (!TimeSpan.TryParse(txtHoraInicio.Text, out TimeSpan inicio)) return;

            try
            {
                var peliculas = _pelDal.ObtenerTodas();
                int pelId = Convert.ToInt32(cbPeliculas.SelectedValue);
                var filas = peliculas.Select($"pel_id = {pelId}");
                if (filas.Length == 0) return;

                int duracion = Convert.ToInt32(filas[0]["duracion_min"]);
                var fin = inicio.Add(TimeSpan.FromMinutes(duracion));
                txtHoraFinal.Text = fin.ToString(@"hh\:mm");
            }
            catch { }
        }

        private void DgvFunciones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFunciones.CurrentRow == null) return;
            var fila = dgvFunciones.CurrentRow;

            _funcIdSeleccionada = Convert.ToInt32(fila.Cells["func_id"].Value);
            txtHoraInicio.Text = fila.Cells["hora_inicio"].Value?.ToString() ?? "";
            txtHoraFinal.Text = fila.Cells["hora_fin"].Value?.ToString() ?? "";
            txtCosto.Text = fila.Cells["precio_base"].Value?.ToString() ?? "";
            cbEstadoFuncion.Text = fila.Cells["estado"].Value?.ToString() ?? "";
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (cbPeliculas.SelectedValue == null || cbSalas.SelectedValue == null)
            {
                MessageBox.Show("Selecciona pelicula y sala.", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtCosto.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Precio invalido.", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var f = new Funcion
            {
                FuncId = _funcIdSeleccionada,
                PelId = Convert.ToInt32(cbPeliculas.SelectedValue),
                SalaId = Convert.ToInt32(cbSalas.SelectedValue),
                Fecha = dtpFechaFuncion.Value.Date,
                HoraInicio = txtHoraInicio.Text.Trim(),
                HoraFin = txtHoraFinal.Text.Trim(),
                PrecioBase = precio,
                Estado = cbEstadoFuncion.Text
            };

            bool ok = _dal.Guardar(f, out string mensaje);

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
            _funcIdSeleccionada = 0;
            txtHoraInicio.Clear();
            txtHoraFinal.Clear();
            txtCosto.Clear();
            cbEstadoFuncion.SelectedIndex = 0;
            dgvFunciones.ClearSelection();
        }

        // Eventos requeridos por el Designer
        private void btnGuardarPeli_Click(object sender, EventArgs e) => BtnGuardar_Click(sender, e);
        private void btnCancelarPeli_Click(object sender, EventArgs e) => LimpiarFormulario();
        private void label8_Click(object sender, EventArgs e) { }
    }
}
