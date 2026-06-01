using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProyectoFinal.DAL;

namespace ProyectoFinal.Vistas
{
    public partial class Historial : Form
    {
        private readonly VentasDAL _dal = new();

        public Historial()
        {
            InitializeComponent();
            this.Load += Historial_Load;
            btnBuscarHistorial.Click += (s, e) => CargarGrid();
            txtBuscarHistorial.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) CargarGrid();
            };
        }

        private void Historial_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            // Rango por defecto: mes actual
            dtpInicioReporte.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpFinReporte.Value = DateTime.Today;
            CargarGrid();
        }

        private void ConfigurarGrid()
        {
            dgvHistorial.ReadOnly = true;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.MultiSelect = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.AllowUserToAddRows = false;
        }

        private void CargarGrid()
        {
            if (dtpInicioReporte.Value > dtpFinReporte.Value)
            {
                MessageBox.Show("La fecha inicio no puede ser mayor que la fecha fin.", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvHistorial.DataSource = _dal.ObtenerHistorial(
                dtpInicioReporte.Value,
                dtpFinReporte.Value,
                txtBuscarHistorial.Text.Trim());
        }
    }
}
