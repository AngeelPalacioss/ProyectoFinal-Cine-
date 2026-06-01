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
    public partial class Reportes : Form
    {
        private readonly ReportesDAL _dal = new();

        // DataGridViews uno por reporte
        private DataGridView dgv1 = new(), dgv2 = new(), dgv3 = new(), dgv4 = new(),
                             dgv5 = new(), dgv6 = new(), dgv7 = new();

        public Reportes()
        {
            InitializeComponent();
            this.Load += Reportes_Load;
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            ConstruirTabs();
        }

        private void ConstruirTabs()
        {
            // Limpiar tabs existentes del Designer y crear 7
            tabControl1.TabPages.Clear();

            AgregarTab("R1: Cartelera", dgv1, CrearPanelR1());
            AgregarTab("R2: Por Genero", dgv2, CrearPanelSimple(dgv2, () => _dal.R2_IngresosPorGenero()));
            AgregarTab("R3: Sobre Promedio", dgv3, CrearPanelSimple(dgv3, () => _dal.R3_FuncionessobrePromedio()));
            AgregarTab("R4: Con Funcion", dgv4, CrearPanelSimple(dgv4, () => _dal.R4_PeliculasConFuncionActiva()));
            AgregarTab("R5: Historial", dgv5, CrearPanelSimple(dgv5, () => _dal.R5_HistorialVentas()));
            AgregarTab("R6: Catalogo", dgv6, CrearPanelSimple(dgv6, () => _dal.R6_CatalogoPaginado()));
            AgregarTab("R7: Actividad", dgv7, CrearPanelSimple(dgv7, () => _dal.R7_ActividadReciente()));
        }

        private void AgregarTab(string titulo, DataGridView dgv, Panel panel)
        {
            ConfigurarDgv(dgv);
            var tab = new TabPage(titulo);
            tab.Controls.Add(panel);
            tabControl1.TabPages.Add(tab);
        }

        private void ConfigurarDgv(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.Dock = DockStyle.Fill;
        }

        // Panel R1 tiene DateTimePicker para filtrar por fecha
        private Panel CrearPanelR1()
        {
            var panel = new Panel { Dock = DockStyle.Fill };

            var dtp = new DateTimePicker
            {
                Value = DateTime.Today,
                Location = new Point(10, 10),
                Size = new Size(200, 23)
            };

            var btn = new Button
            {
                Text = "Ejecutar",
                Location = new Point(220, 10),
                Size = new Size(80, 23)
            };

            dgv1.Location = new Point(0, 45);
            dgv1.Size = new Size(750, 340);

            btn.Click += (s, e) =>
            {
                try { dgv1.DataSource = _dal.R1_CartelераDia(dtp.Value); }
                catch (Exception ex) { MostrarError(ex); }
            };

            panel.Controls.Add(dtp);
            panel.Controls.Add(btn);
            panel.Controls.Add(dgv1);
            return panel;
        }

        // Panel generico con boton Ejecutar
        private Panel CrearPanelSimple(DataGridView dgv, Func<System.Data.DataTable> consulta)
        {
            var panel = new Panel { Dock = DockStyle.Fill };

            var btn = new Button
            {
                Text = "Ejecutar reporte",
                Location = new Point(10, 10),
                Size = new Size(120, 23)
            };

            dgv.Location = new Point(0, 45);
            dgv.Size = new Size(750, 340);

            btn.Click += (s, e) =>
            {
                try { dgv.DataSource = consulta(); }
                catch (Exception ex) { MostrarError(ex); }
            };

            panel.Controls.Add(btn);
            panel.Controls.Add(dgv);
            return panel;
        }

        private void MostrarError(Exception ex)
        {
            MessageBox.Show("Error al ejecutar reporte:\n" + ex.Message,
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
