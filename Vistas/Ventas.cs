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
    public partial class Ventas : Form
    {
        private readonly VentasDAL _ventasDAL = new();
        private readonly FuncionesDAL _funcDAL = new();
        private readonly DescuentosDAL _descDAL = new();

        private int _funcIdSeleccionada = 0;
        private decimal _precioBase = 0;
        private int? _descIdAplicado = null;
        private decimal _descPct = 0;
        private decimal _descPctDia = 0;  // descuento automatico por dia/hora
        private bool _cargando = false; // agrega junto a las otras variables

        public Ventas()
        {
            InitializeComponent();
            this.Load += Ventas_Load;

            btnFuncionesVenta.Click += (s, e) => CargarFunciones();
            dgvVentas.SelectionChanged += DgvVentas_SelectionChanged;
            btnConfirmarVenta.Click += BtnConfirmar_Click;
            btnCancelarVenta.Click += (s, e) => LimpiarFormulario();
            cbTipoBoleto.SelectedIndexChanged += RecalcularTotal;
            txtCantBoletos.TextChanged += RecalcularTotal;
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();

            cbTipoBoleto.Items.AddRange(new[] { "Normal", "Estudiante", "Tercera edad" });
            cbTipoBoleto.SelectedIndex = 0;

            cbPeliculaSelec.Enabled = false;
            txtDescuentoAplic.Enabled = false;
            txtTotal.Enabled = false;
            txtPrecioBase.Enabled = false;
        }

        private void ConfigurarGrid()
        {
            dgvVentas.ReadOnly = true;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.MultiSelect = false;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.AllowUserToAddRows = false;
        }

        private void CargarFunciones()
        {
            dgvVentas.DataSource = _funcDAL.ObtenerPorFecha(dateTimePicker1.Value);
        }

        private void DgvVentas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null) return;
            _cargando = true; // bloquear recalculo mientras cargamos

            var fila = dgvVentas.CurrentRow;

            _funcIdSeleccionada = Convert.ToInt32(fila.Cells["func_id"].Value);
            _precioBase = Convert.ToDecimal(fila.Cells["precio_base"].Value);
            string horaInicio = fila.Cells["hora_inicio"].Value?.ToString() ?? "00:00";

            txtPrecioBase.Text = _precioBase.ToString("F2");
            cbPeliculaSelec.Text = fila.Cells["titulo"].Value?.ToString() ?? "";

            var dtDesc = _descDAL.ObtenerDescuentoAplicable(dateTimePicker1.Value, horaInicio);
            if (dtDesc.Rows.Count > 0)
            {
                _descIdAplicado = Convert.ToInt32(dtDesc.Rows[0]["desc_id"]);
                _descPctDia = Convert.ToDecimal(dtDesc.Rows[0]["porcentaje"]);
                txtDescuentoAplic.Text = $"{dtDesc.Rows[0]["nombre"]} ({_descPctDia}%)";
            }
            else
            {
                _descIdAplicado = null;
                _descPctDia = 0;
                txtDescuentoAplic.Text = "Sin descuento";
            }

            cbTipoBoleto.SelectedIndex = 0;
            _cargando = false; // desbloquear
            RecalcularTotal(null, EventArgs.Empty); // recalcular una sola vez con todo listo
        }

        private void RecalcularTotal(object? sender, EventArgs e)
        {
            if (_cargando) return;
            if (_precioBase == 0) return;
            if (!int.TryParse(txtCantBoletos.Text, out int cant) || cant <= 0) return;

            decimal descTipo = cbTipoBoleto.Text switch
            {
                "Estudiante" => 25m,
                "Tercera edad" => 30m,
                _ => 0m
            };

            // Calcular con variable local, no tocar _descPct aqui
            decimal descAplicar = Math.Max(_descPctDia, descTipo);
            decimal total = cant * _precioBase * (1 - descAplicar / 100);
            txtTotal.Text = total.ToString("F2");

            // Solo actualizar _descPct para cuando se confirme la venta
            _descPct = descAplicar;
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (_funcIdSeleccionada == 0)
            {
                MessageBox.Show("Selecciona una funcion primero.", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCantBoletos.Text, out int cant) || cant <= 0)
            {
                MessageBox.Show("Cantidad de boletos invalida.", "Validacion",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                $"Confirmar venta de {cant} boleto(s) por ${txtTotal.Text}?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            bool ok = _ventasDAL.RegistrarVenta(
                _funcIdSeleccionada, _descIdAplicado, cant,
                _precioBase, _descPct, cbTipoBoleto.Text,
                out int bolId, out decimal total, out string mensaje);

            if (ok)
            {
                MessageBox.Show($"Venta registrada.\nFolio: #{bolId}\nTotal: ${total:F2}",
                    "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                CargarFunciones();
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
            _precioBase = 0;
            _descIdAplicado = null;
            _descPct = 0;
            _descPctDia = 0;
            txtPrecioBase.Clear();
            txtCantBoletos.Clear();
            txtDescuentoAplic.Clear();
            txtTotal.Clear();
            cbPeliculaSelec.Text = "";
            cbTipoBoleto.SelectedIndex = 0;
            dgvVentas.ClearSelection();
        }
    }
}