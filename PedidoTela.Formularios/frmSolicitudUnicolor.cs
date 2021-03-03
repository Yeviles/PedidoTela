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
    public partial class frmSolicitudUnicolor : MaterialSkin.Controls.MaterialForm
    {
        private Controlador control;
        private int idEnsayo;
        private string codigoTela;
        public frmSolicitudUnicolor(Controlador control, int idEnsayo, string codigoTela)
        {
            this.control = control;
            this.idEnsayo = idEnsayo;
            this.codigoTela = codigoTela;
            InitializeComponent();
            TipoTejido tt = control.getTipoTejido(codigoTela);
            txbRefTela.Text = tt.CodigoTela;
            txbNomTela.Text = tt.NombreTela;
            txbTipoTejido.Text = tt.NombreTipoTela;
        }

        private void frmSolicitudUnicolor_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            /*frmTipoSolicitud frmTsoli = new frmTipoSolicitud();
            frmTsoli.Show();    */
            this.Close();
        }

        private void cbxSiCoordinado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSiCoordinado.Checked)
            {
                lbCoordinaCon.Visible = true;
                txbCoordinaCon.Visible = true;
                cbxNoCoordinado.Checked = false;
            }
            else {
                lbCoordinaCon.Visible = false;
                txbCoordinaCon.Visible = false;
            }
        }

        private void cbxNoCoordinado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNoCoordinado.Checked) {
                cbxSiCoordinado.Checked = false;
            }
        }

        private void btnAddColor_Click(object sender, EventArgs e)
        {
            frmBuscarColor buscarColor = new frmBuscarColor(control);
            buscarColor.StartPosition = FormStartPosition.CenterScreen;
            if (buscarColor.ShowDialog() == DialogResult.OK)
            {
                Objeto obj = buscarColor.Elemento;
                dgvUnicolor.Rows.Add();
                dgvUnicolor.Rows[dgvUnicolor.Rows.Count - 1].Cells[0].Value = obj.Id;
                dgvUnicolor.Rows[dgvUnicolor.Rows.Count - 1].Cells[1].Value = obj.Nombre;
            }
        }

        private void dgvUnicolor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvUnicolor.CurrentCell.Value != null)
                {
                    int ultimaColumna = dgvUnicolor.ColumnCount - 1;

                    if (e.ColumnIndex > 1 && e.ColumnIndex < ultimaColumna)
                    {
                        dgvUnicolor.CurrentCell.Value = Regex.Replace(dgvUnicolor.CurrentCell.Value.ToString().Trim(), @"[^0-9]", "");
                        if (dgvUnicolor.CurrentCell.Value.ToString() != "")
                        {
                            int total = 0;
                            for (int i = 2; i < ultimaColumna; i++)
                            {
                                if (dgvUnicolor.Rows[e.RowIndex].Cells[i].Value != null && dgvUnicolor.Rows[e.RowIndex].Cells[i].Value.ToString() != "")
                                {
                                    total += int.Parse(dgvUnicolor.Rows[e.RowIndex].Cells[i].Value.ToString());
                                }
                            }
                            dgvUnicolor.Rows[e.RowIndex].Cells[ultimaColumna].Value = total;
                        }
                    }
                }
            }
            catch (ArgumentException aex)
            {
                dgvUnicolor.CurrentCell.Value = "";
                MessageBox.Show("Unicamente se permiten valores numéricos", "TTipo de dato no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            Unicolor elemento = new Unicolor();
            elemento.IdEnsayo = idEnsayo;
            elemento.ReferenciaTela = codigoTela;
            elemento.DescripcionTela = txbNomTela.Text;
            elemento.Coordinado = (cbxSiCoordinado.Checked)? true:false;
            elemento.CoordinadoCon = txbCoordinaCon.Text;
            elemento.Observaciones = txbObservaciones.Text;
            if (control.addUnicolor(elemento)) {
                try {

                    MessageBox.Show("Unicolor se guardo con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) {
                    MessageBox.Show("Unicolor no se pudo guardar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }
    }
}
