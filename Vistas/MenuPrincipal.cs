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
    public partial class MenuPrincipal : Form
    {
        private readonly LoginDAL _loginDAL = new();

        public MenuPrincipal()
        {
            InitializeComponent();
            this.Load += MenuPrincipal_Load;

            // Eventos del menu
            peliculasToolStripMenuItem.Click += (s, e) => AbrirVentana(new Peliculas());
            salasToolStripMenuItem.Click += (s, e) => AbrirVentana(new Salas());
            funcionesToolStripMenuItem.Click += (s, e) => AbrirVentana(new Funciones());
            descuentosToolStripMenuItem.Click += (s, e) => AbrirVentana(new Descuentos());
            ventasToolStripMenuItem.Click += (s, e) => AbrirVentana(new Ventas());
            reportesToolStripMenuItem.Click += (s, e) => AbrirVentana(new Reportes());
            usuariosToolStripMenuItem.Click += (s, e) =>
            {
                string info = $"Usuarios del sistema:\n\n" +
                              $"• admin — Administrador (todos los permisos)\n" +
                              $"• cajero1, cajero2 — Taquilla (ventas)\n" +
                              $"• consulta1, consulta2 — Solo lectura\n\n" +
                              $"Para gestionar usuarios conectate como SYSTEM en Oracle SQL Developer.";
                MessageBox.Show(info, "Gestion de Usuarios",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            // Si se llega aqui sin login (Program.cs abre MenuPrincipal directo),
            // muestra el login primero.
            // NOTA: Cambia Program.cs para que abra Form1 (Login) en lugar de MenuPrincipal.
            AplicarPermisosPorRol();
            this.Text = $"CineSystem — {SesionGlobal.Nombre} [{SesionGlobal.Rol}]";
            CargarEstadisticas();
        }

        private void CargarEstadisticas()
        {
            try
            {
                var db = Conexion.Instancia;

                var dtFunciones = db.EjecutarConsulta(
                    "SELECT COUNT(*) AS total FROM FUNCIONES WHERE TRUNC(fecha) = TRUNC(SYSDATE) AND estado = 'Activa'");
                var dtBoletos = db.EjecutarConsulta(
                    "SELECT NVL(SUM(cantidad),0) AS total FROM BOLETOS WHERE TRUNC(fecha_venta) = TRUNC(SYSDATE)");
                var dtIngresos = db.EjecutarConsulta(
                    "SELECT NVL(SUM(total_pagado),0) AS total FROM BOLETOS WHERE TRUNC(fecha_venta) = TRUNC(SYSDATE)");

                // Actualiza labels que agregues en el Designer
                lblFunciones.Text = $"Funciones hoy: {dtFunciones.Rows[0]["total"]}";
                lblBoletos.Text = $"Boletos vendidos: {dtBoletos.Rows[0]["total"]}";
                lblIngresos.Text = $"Ingresos del dia: ${dtIngresos.Rows[0]["total"]:F2}";
                lblUsuario.Text = $"Bienvenido, {SesionGlobal.Nombre}";
                lblFecha.Text = DateTime.Now.ToString("dddd, dd 'de' MMMM 'de' yyyy");
            }
            catch { }
        }

        private void AplicarPermisosPorRol()
        {
            string rol = SesionGlobal.Rol;

            // Solo admin ve usuarios y descuentos
            usuariosToolStripMenuItem.Visible = rol == "admin";
            descuentosToolStripMenuItem.Visible = rol == "admin";
            salasToolStripMenuItem.Visible = rol == "admin";
            peliculasToolStripMenuItem.Visible = rol == "admin";
            funcionesToolStripMenuItem.Visible = rol == "admin";

            // Taquilla ve ventas y reportes
            ventasToolStripMenuItem.Visible = rol == "admin" || rol == "escritura";
            reportesToolStripMenuItem.Visible = rol == "admin" || rol == "escritura" || rol == "consulta";
        }

        private void AbrirVentana(Form ventana)
        {
            ventana.MdiParent = null;
            ventana.ShowDialog();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _loginDAL.CerrarSesion();
            Application.Exit();
            base.OnFormClosing(e);
        }
    }
}
