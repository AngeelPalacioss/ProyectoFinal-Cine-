using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinal
{
    public static class Estilos
    {
        // Paleta de colores
        public static Color ColorPrimario    = Color.FromArgb(26, 58, 92);
        public static Color ColorSecundario  = Color.FromArgb(240, 244, 248);
        public static Color ColorAcento      = Color.FromArgb(41, 128, 185);
        public static Color ColorTexto       = Color.FromArgb(33, 37, 41);
        public static Color ColorBlancoRoto  = Color.FromArgb(248, 249, 250);

        public static void AplicarForm(Form form)
        {
            form.BackColor = ColorBlancoRoto;
            form.Font = new Font("Segoe UI", 9.5f);

            EstilarControles(form.Controls);
        }

        private static void EstilarControles(Control.ControlCollection controles)
        {
            foreach (Control c in controles)
            {
                switch (c)
                {
                    case Button btn:
                        EstilarBoton(btn);
                        break;
                    case DataGridView dgv:
                        EstilarGrid(dgv);
                        break;
                    case TextBox txt:
                        EstilarTextBox(txt);
                        break;
                    case Label lbl:
                        lbl.ForeColor = ColorTexto;
                        lbl.Font = new Font("Segoe UI", 9.5f);
                        break;
                    case Panel pnl:
                        pnl.BackColor = Color.White;
                        EstilarControles(pnl.Controls);
                        break;
                    case ComboBox cb:
                        cb.FlatStyle = FlatStyle.Flat;
                        cb.Font = new Font("Segoe UI", 9.5f);
                        break;
                }

                if (c.Controls.Count > 0 && c is not Panel)
                    EstilarControles(c.Controls);
            }
        }

        private static void EstilarBoton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            btn.Cursor = Cursors.Hand;
            btn.Height = 32;

            // Cancelar = rojo, Confirmar = verde, resto = azul
            if (btn.Text.ToLower().Contains("cancelar"))
            {
                btn.BackColor = Color.FromArgb(192, 57, 43);
                btn.ForeColor = Color.White;
            }
            else if (btn.Text.ToLower().Contains("confirmar") ||
                        btn.Text.ToLower().Contains("guardar"))
            {
                btn.BackColor = Color.FromArgb(39, 174, 96);
                btn.ForeColor = Color.White;
            }
            else
            {
                btn.BackColor = ColorPrimario;
                btn.ForeColor = Color.White;
            }
        }

        private static void EstilarTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.Font = new Font("Segoe UI", 9.5f);
            txt.BackColor = Color.White;
        }

        private static void EstilarGrid(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(220, 220, 220);
            dgv.BackgroundColor = Color.White;
            dgv.RowHeadersVisible = false;
            dgv.Font = new Font("Segoe UI", 9f);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = ColorTexto;
            dgv.DefaultCellStyle.SelectionBackColor = ColorAcento;
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(4, 2, 4, 2);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorPrimario;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold);
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 36;
            dgv.EnableHeadersVisualStyles = false;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 252);
            dgv.RowTemplate.Height = 30;
        }
    }
}
