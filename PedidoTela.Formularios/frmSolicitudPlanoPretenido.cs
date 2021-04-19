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
        private int id = 0, consecutivo = 0, idSolTelas;

        public frmSolicitudPlanoPretenido(Controlador control, string identificador, string codigoTela,string desTela, int idSTelas)
        {
            this.control = control;
            this.identificador = identificador;
            this.codigoTela = codigoTela;
            this.idSolTelas = idSTelas;
            InitializeComponent();
            lbIdentificador.Text = identificador;
            TipoTejido tt = control.getTipoTejido(codigoTela);
            txbRefTela.Text = codigoTela;
            txbNomTela.Text = desTela;
            cargar();
            if (dgvPlano.RowCount < 0)
            {
                //btnGrabar.Enabled = false;
                //dgvPlano.ReadOnly = true;
                btnConfirmar.Enabled = false;
            }
           
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
                txbCoordinaCon.ReadOnly = true;
                txbCoordinaCon.BackColor = Color.LightGoldenrodYellow;
                cbxSiCoordinado.Checked = false;

            }
        }

        private void cbxSiCoordinado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSiCoordinado.Checked)
            {
                txbCoordinaCon.ReadOnly = false;
                txbCoordinaCon.Focus();
                txbCoordinaCon.BackColor = Color.White;
                cbxNoCoordinado.Checked = false;
            }
        }

        private void dgvPlano_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex < 12)
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
            if (dgvPlano.Columns[e.ColumnIndex].Name == "eliminar")
            {
                dgvPlano.Rows.Remove(dgvPlano.CurrentRow);
            }
        }

        private void dgvPlano_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvPlano.CurrentRow.Cells[20].ReadOnly = true;
            int ultimaColumna = dgvPlano.ColumnCount - 2;
            if (e.ColumnIndex > 11 && e.ColumnIndex < ultimaColumna) {
                try
                {
                    if (dgvPlano.CurrentCell.Value != null)
                    {
                        

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

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            bool b = false;
            List<int> listaIdDetalles = new List<int>();
            if (!cbxSiCoordinado.Checked && !cbxNoCoordinado.Checked)
            {
                MessageBox.Show("Por favor, seleccione un valor para coordinado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtObservaciones.Text.Trim().Length > 0)
                {
                    if (dgvPlano.RowCount > 0)
                    {
                        bool vacio = false;
                        foreach (DataGridViewRow row in dgvPlano.Rows) {
                            if (row.Cells[2].Value == null || row.Cells[4].Value == null || row.Cells[6].Value == null ||
                                row.Cells[8].Value == null || row.Cells[10].Value == null) {
                                vacio = true;
                            }
                        }
                        if (!vacio) {
                            PlanoPretenido elemento = new PlanoPretenido();
                            elemento.Identificador = identificador;
                            elemento.ReferenciaTela = codigoTela;
                            elemento.DescripcionTela = txbNomTela.Text;
                            elemento.Coordinado = (cbxSiCoordinado.Checked) ? true : false;
                            elemento.CoordinadoCon = (txbCoordinaCon.Text.Trim().Length > 0) ? txbCoordinaCon.Text.Trim() : "";
                            elemento.Observacion = (txtObservaciones.Text.Trim().Length > 0) ? txtObservaciones.Text.Trim() : "";
                            elemento.IdSolTela = idSolTelas;

                            if (control.consultarIdentificadorPla(idSolTelas))
                            {
                                control.ActualizarPlano(elemento);
                                b = true;
                            }
                            else
                            {
                                control.addPlanoPretenido(elemento);
                            }
                                id = control.getIdPlano(idSolTelas);
                               listaIdDetalles = control.getIdDetallePlano(id);
                            //Console.WriteLine("ID: " + id);
                            try
                                {
                                   for (int i = 0; i < dgvPlano.RowCount; i++)
                                    {
                                        DetallePlanoPretenido detalle = new DetallePlanoPretenido();
                                        detalle.IdPlano = id;
                                        detalle.CodigoVte = dgvPlano.Rows[i].Cells[0].Value.ToString();
                                        detalle.DescripcionVte = dgvPlano.Rows[i].Cells[1].Value.ToString().Trim();
                                        detalle.CodigoH1 = dgvPlano.Rows[i].Cells[2].Value.ToString();
                                        detalle.DescripcionH1 = dgvPlano.Rows[i].Cells[3].Value.ToString().Trim();
                                        detalle.CodigoH2 = dgvPlano.Rows[i].Cells[4].Value.ToString();
                                        detalle.DescripcionH2 = dgvPlano.Rows[i].Cells[5].Value.ToString().Trim();
                                        detalle.CodigoH3 = dgvPlano.Rows[i].Cells[6].Value.ToString();
                                        detalle.DescripcionH3 = dgvPlano.Rows[i].Cells[7].Value.ToString().Trim();
                                        detalle.CodigoH4 = dgvPlano.Rows[i].Cells[8].Value.ToString();
                                        detalle.DescripcionH4 = dgvPlano.Rows[i].Cells[9].Value.ToString().Trim();
                                        detalle.CodigoH5 = dgvPlano.Rows[i].Cells[10].Value.ToString();
                                        detalle.DescripcionH5 = dgvPlano.Rows[i].Cells[11].Value.ToString().Trim();
                                        detalle.Tiendas = (dgvPlano.Rows[i].Cells[12].Value != null && dgvPlano.Rows[i].Cells[12].Value.ToString() != "") ? int.Parse(dgvPlano.Rows[i].Cells[12].Value.ToString()) : 0;
                                        detalle.Exito = (dgvPlano.Rows[i].Cells[13].Value != null && dgvPlano.Rows[i].Cells[13].Value.ToString() != "") ? int.Parse(dgvPlano.Rows[i].Cells[13].Value.ToString()) : 0;
                                        detalle.Cencosud = (dgvPlano.Rows[i].Cells[14].Value != null && dgvPlano.Rows[i].Cells[14].Value.ToString() != "") ? int.Parse(dgvPlano.Rows[i].Cells[14].Value.ToString()) : 0;
                                        detalle.Sao = (dgvPlano.Rows[i].Cells[15].Value != null && dgvPlano.Rows[i].Cells[15].Value.ToString() != "") ? int.Parse(dgvPlano.Rows[i].Cells[15].Value.ToString()) : 0;
                                        detalle.Comercio = (dgvPlano.Rows[i].Cells[16].Value != null && dgvPlano.Rows[i].Cells[16].Value.ToString() != "") ? int.Parse(dgvPlano.Rows[i].Cells[16].Value.ToString()) : 0;
                                        detalle.Rosado = (dgvPlano.Rows[i].Cells[17].Value != null && dgvPlano.Rows[i].Cells[17].Value.ToString() != "") ? int.Parse(dgvPlano.Rows[i].Cells[17].Value.ToString()) : 0;
                                        detalle.Otros = (dgvPlano.Rows[i].Cells[18].Value != null && dgvPlano.Rows[i].Cells[18].Value.ToString() != "") ? int.Parse(dgvPlano.Rows[i].Cells[18].Value.ToString()) : 0;
                                        detalle.Total = (dgvPlano.Rows[i].Cells[19].Value != null && dgvPlano.Rows[i].Cells[19].Value.ToString() != "") ? int.Parse(dgvPlano.Rows[i].Cells[19].Value.ToString()) : 0;
                                        
                                    //btnConfirmar.Enabled = true;

                                    if (b)
                                    {
                                        if (i < listaIdDetalles.Count)
                                        {
                                            control.ActualizarDetallePlano(detalle, listaIdDetalles[i]);
                                        }
                                        else
                                        {
                                            control.addDetallePlanoPretenido(detalle);
                                        }
                                    }
                                    else
                                    {
                                        control.addDetallePlanoPretenido(detalle);
                                    }
                                }
                                    MessageBox.Show("Plano preteñido se guardó con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                              MessageBox.Show("Detalle plano preteñido no se pudo guardar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            }
                        else
                        {
                            MessageBox.Show("Los colores H1 - H5 están vacíos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, adicione al menos un color", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese las observaciones de diseño", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
                
            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            //PlanoPretenido objPretenido = control.getPlanoPretenido(identificador);
            //id = objPretenido.Id;
            //int idSolicitud = control.consultarIdsolicitud(identificador);
            int maxConsecutivo = control.consultarMaximo();
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            string estado = "Por Analizar";

            if (id != 0)
            {
   
                control.agregarConsecutivo(idSolTelas, id, "PRETEÑIDO", maxConsecutivo + 1, fechaActual, estado, fechaActual, identificador);
                MessageBox.Show("El consecutivo se guardó con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnConfirmar.Enabled = false;
                btnGrabar.Enabled = false;
                txtObservaciones.ReadOnly = true;
                btnAddColor.Enabled = false;
                dgvPlano.ReadOnly = true;
                consecutivo = control.consultarConsecutivo(id);
                lblConsecutivo.Text = "Consecutivo: " + consecutivo;
                DialogResult = DialogResult.OK;
                
            }
            else
            {
                MessageBox.Show("Por favor, Grabe la Información.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbCoordinaCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void dgvPlano_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvPlano.Columns[e.ColumnIndex].Name == "eliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = dgvPlano.Rows[e.RowIndex].Cells["eliminar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(@"eliminar.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 25, e.CellBounds.Top + 3);

                dgvPlano.Rows[e.RowIndex].Height = icoAtomico.Height + 50;
                dgvPlano.Columns[e.ColumnIndex].Width = icoAtomico.Width + 50;

                e.Handled = true;
            }
        }

        private void cargar()
        {
            PlanoPretenido planoP = control.getPlanoPretenido(idSolTelas);
            id = planoP.Id;
            if (planoP.Coordinado)
            {
                cbxSiCoordinado.Checked = true;
                txbCoordinaCon.Text = planoP.CoordinadoCon;
            }
            else
            {
                cbxNoCoordinado.Checked = true;
            }
            txtObservaciones.Text = planoP.Observacion;
            consecutivo = control.consultarConsecutivo(id);
            if (id != 0 && consecutivo != 0)
            {
                lblConsecutivo.Text = "Consecutivo: " + consecutivo;
                btnConfirmar.Enabled = false;
                dgvPlano.ReadOnly = true;
                btnGrabar.Enabled = false;
                btnAddColor.Enabled = false;
            }

            /*Carga detalle plano preteñido*/
            List<DetallePlanoPretenido> lista = control.getDetallePlanoPretenido(planoP.Id);
            if (lista.Count > 0)
            {
                foreach (DetallePlanoPretenido obj in lista)
                {
                    dgvPlano.Rows.Add(obj.CodigoVte, obj.DescripcionVte, obj.CodigoH1, obj.DescripcionH1, obj.CodigoH2, obj.DescripcionH2,
                        obj.CodigoH3, obj.DescripcionH3, obj.CodigoH4, obj.DescripcionH4, obj.CodigoH5, obj.DescripcionH5,
                        obj.Exito, obj.Tiendas, obj.Cencosud, obj.Sao, obj.Comercio, obj.Rosado, obj.Otros, obj.Total);
                }
                //btnAddColor.Enabled = false;
                //dgvPlano.ReadOnly = true;
                //btnGrabar.Enabled = false;
                //txtObservaciones.Enabled = false;
            }
        }
    }
}
