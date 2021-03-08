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
            cargar();
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
            if (!cbxSiCoordinado.Checked && !cbxNoCoordinado.Checked)
            {
                MessageBox.Show("Por favor, seleccione un valor para coordinado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                if (txbObservaciones.Text.Trim().Length > 0)
                {
                    if (dgvUnicolor.RowCount > 0)
                    {
                        Unicolor elemento = new Unicolor();
                        elemento.Identificador = idEnsayo.ToString();
                        elemento.ReferenciaTela = codigoTela;
                        elemento.DescripcionTela = txbNomTela.Text;
                        elemento.TipoTejido = txbTipoTejido.Text;
                        elemento.Coordinado = (cbxSiCoordinado.Checked) ? true : false;
                        elemento.CoordinadoCon = (txbCoordinaCon.Text.Trim().Length > 0) ? txbCoordinaCon.Text.Trim() : "";
                        elemento.Observaciones = (txbObservaciones.Text.Trim().Length > 0) ? txbObservaciones.Text.Trim() : ""; ;
                        if (control.addUnicolor(elemento))
                        {
                            int id = control.getIdUnicolor(idEnsayo.ToString());
                            try
                            {
                                foreach (DataGridViewRow row in dgvUnicolor.Rows)
                                {
                                    DetalleUnicolor detalle = new DetalleUnicolor();
                                    detalle.IdUnicolor = id;
                                    detalle.CodigoColor = row.Cells[0].Value.ToString();
                                    detalle.Descripcion = row.Cells[1].Value.ToString();
                                    detalle.Tiendas = (row.Cells[2].Value != null && row.Cells[2].Value.ToString() != "") ? int.Parse(row.Cells[2].Value.ToString()) : 0;
                                    detalle.Exito = (row.Cells[3].Value != null && row.Cells[3].Value.ToString() != "") ? int.Parse(row.Cells[3].Value.ToString()) : 0;
                                    detalle.Cencosud = (row.Cells[4].Value != null && row.Cells[4].Value.ToString() != "") ? int.Parse(row.Cells[4].Value.ToString()) : 0;
                                    detalle.Sao = (row.Cells[5].Value != null && row.Cells[5].Value.ToString() != "") ? int.Parse(row.Cells[5].Value.ToString()) : 0;
                                    detalle.Comercio = (row.Cells[6].Value != null && row.Cells[6].Value.ToString() != "") ? int.Parse(row.Cells[6].Value.ToString()) : 0;
                                    detalle.Rosado = (row.Cells[7].Value != null && row.Cells[7].Value.ToString() != "") ? int.Parse(row.Cells[7].Value.ToString()) : 0;
                                    detalle.Otros = (row.Cells[8].Value != null && row.Cells[8].Value.ToString() != "") ? int.Parse(row.Cells[8].Value.ToString()) : 0;
                                    detalle.Total = (row.Cells[9].Value != null && row.Cells[9].Value.ToString() != "") ? int.Parse(row.Cells[9].Value.ToString()) : 0;
                                    control.addDetalleUnicolor(detalle);
                                }
                                MessageBox.Show("Unicolor se guardó con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Detalle unicolor no se pudo guardar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else {
                        MessageBox.Show("Por favor, adicione al menos un color", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else {
                    MessageBox.Show("Por favor, ingrese las observaciones de diseño", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }

        private void cargar() {
            Unicolor unicolor = control.getUnicolor(idEnsayo.ToString());
            if (unicolor.Coordinado) {
                cbxSiCoordinado.Checked = true;
                txbCoordinaCon.Text = unicolor.CoordinadoCon;
            }
            else {
                cbxNoCoordinado.Checked = true;
            }
            txbObservaciones.Text = unicolor.Observaciones;

            /*Carga detalle unicolor*/
            List<DetalleUnicolor> lista = control.getDetalleUnicolor(unicolor.Id);
            if (lista.Count > 0)
            {
                foreach (DetalleUnicolor obj in lista)
                {
                    dgvUnicolor.Rows.Add(obj.CodigoColor, obj.Descripcion, obj.Exito, obj.Tiendas,
                        obj.Cencosud, obj.Sao, obj.Comercio, obj.Rosado, obj.Otros, obj.Total);
                }
                btnAddColor.Enabled = false;
            }
        }
    }
}
