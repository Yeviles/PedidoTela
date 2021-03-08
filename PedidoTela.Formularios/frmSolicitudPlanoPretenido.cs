using MaterialSkin;
using PedidoTela.Controlodores;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidoTela.Formularios
{
    public partial class frmSolicitudPlanoPretenido : MaterialSkin.Controls.MaterialForm
    {
        private Controlador control;
        private string identificador;
        private string codigoTela;
        public frmSolicitudPlanoPretenido(Controlador control, string identificador, string codigoTela)
        {
            this.control = control;
            this.identificador = identificador;
            this.codigoTela = codigoTela;
            InitializeComponent();
            TipoTejido tt = control.getTipoTejido(codigoTela);
            txbRefTela.Text = tt.CodigoTela;
            txbNomTela.Text = tt.NombreTela;
            cargar();
        }

        private void frmSolicitudPlanoPretenido_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);


        }

        private void btnAddColor_Click(object sender, EventArgs e)
        {
            frmBuscarColor buscarColor = new frmBuscarColor(control);
            buscarColor.StartPosition = FormStartPosition.CenterScreen;
            if (buscarColor.ShowDialog() == DialogResult.OK)
            {
                Objeto obj = buscarColor.Elemento;
                dgvPlano.Rows.Add();
                dgvPlano.Rows[dgvPlano.Rows.Count - 1].Cells[0].Value = obj.Id;
                dgvPlano.Rows[dgvPlano.Rows.Count - 1].Cells[1].Value = obj.Nombre;
            }
        }

        private void cbxNoCoordinado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNoCoordinado.Checked)
            {
                cbxSiCoordinado.Checked = false;
            }
        }

        private void cbxSiCoordinado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSiCoordinado.Checked)
            {
                lbCoordinaCon.Visible = true;
                txbCoordinaCon.Visible = true;
                cbxNoCoordinado.Checked = false;
            }
            else
            {
                lbCoordinaCon.Visible = false;
                txbCoordinaCon.Visible = false;
            }
        }

        private void dgvPlano_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 12)
            {
                frmBuscarColor buscarColor = new frmBuscarColor(control);
                buscarColor.StartPosition = FormStartPosition.CenterScreen;

                if (buscarColor.ShowDialog() == DialogResult.OK)
                {
                    Objeto obj = buscarColor.Elemento;
                    if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
                    {
                        dgvPlano.Rows[e.RowIndex].Cells[2].Value = obj.Id;
                        dgvPlano.Rows[e.RowIndex].Cells[3].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
                    {
                        dgvPlano.Rows[e.RowIndex].Cells[4].Value = obj.Id;
                        dgvPlano.Rows[e.RowIndex].Cells[5].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 6 || e.ColumnIndex == 7)
                    {
                        dgvPlano.Rows[e.RowIndex].Cells[6].Value = obj.Id;
                        dgvPlano.Rows[e.RowIndex].Cells[7].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 8 || e.ColumnIndex == 9)
                    {
                        dgvPlano.Rows[e.RowIndex].Cells[8].Value = obj.Id;
                        dgvPlano.Rows[e.RowIndex].Cells[9].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 10 || e.ColumnIndex == 11)
                    {
                        dgvPlano.Rows[e.RowIndex].Cells[10].Value = obj.Id;
                        dgvPlano.Rows[e.RowIndex].Cells[11].Value = obj.Nombre;
                    }
                }
            }
        }

        private void dgvPlano_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 11 && e.ColumnIndex < dgvPlano.ColumnCount) {
                try
                {
                    if (dgvPlano.CurrentCell.Value != null)
                    {
                        int ultimaColumna = dgvPlano.ColumnCount - 1;

                        if (e.ColumnIndex > 1 && e.ColumnIndex < ultimaColumna)
                        {
                            dgvPlano.CurrentCell.Value = Regex.Replace(dgvPlano.CurrentCell.Value.ToString().Trim(), @"[^0-9]", "");

                            if (dgvPlano.CurrentCell.Value.ToString() != "")
                            {
                                int total = 0;
                                for (int i = 12; i < ultimaColumna; i++)
                                {
                                    if (dgvPlano.Rows[e.RowIndex].Cells[i].Value != null && dgvPlano.Rows[e.RowIndex].Cells[i].Value.ToString() != "")
                                    {
                                        total += int.Parse(dgvPlano.Rows[e.RowIndex].Cells[i].Value.ToString());
                                    }
                                }
                                dgvPlano.Rows[e.RowIndex].Cells[ultimaColumna].Value = total;
                            }
                        }
                    }
                }
                catch (ArgumentException aex)
                {
                    dgvPlano.CurrentCell.Value = "";
                    MessageBox.Show("Unicamente se permiten valores numéricos", "TTipo de dato no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void cargar()
        {
        }
    }
}
