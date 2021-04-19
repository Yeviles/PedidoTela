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
        private string identificador;
        private string codigoTela;
        private int id = 0, consecutivo = 0;
        public bool esClickBtnGrabar = false;
        private int idSolicitudTelas;

        public frmSolicitudUnicolor(Controlador control, string identificador, string codigoTela,string desTela, int idSolicitud)
        {
            this.control = control;
            this.identificador = identificador;
            this.codigoTela = codigoTela;
            this.idSolicitudTelas = idSolicitud;

            InitializeComponent();

            lbIdentificador.Text = identificador;

            TipoTejido tt = control.getTipoTejido(codigoTela);
            txbRefTela.Text = codigoTela;
            txbNomTela.Text = desTela;
            txbTipoTejido.Text = tt.NombreTipoTela;
            cargar();
            if (dgvUnicolor.RowCount < 0)
            {
                btnConfirmar.Enabled = false;
            }
            if (esClickBtnGrabar)
            {
                frmTipoSolicitud tipo = new frmTipoSolicitud();
                tipo.cbxCuePunTiras.Enabled = false;
            }

        }

        private void frmSolicitudUnicolor_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void cbxNoCoordinado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNoCoordinado.Checked)
            {
                txbCoordinaCon.ReadOnly = true;
                txbCoordinaCon.BackColor = Color.LightGoldenrodYellow;
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
            dgvUnicolor.CurrentRow.Cells[10].ReadOnly = true;
            try
            {
                if (dgvUnicolor.CurrentCell.Value != null)
                {
                    int ultimaColumna = dgvUnicolor.ColumnCount - 2;

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
            bool b = false;
            List<int> listaIdDetalles = new List<int>();
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
                        elemento.Identificador = identificador;
                        elemento.ReferenciaTela = codigoTela;
                        elemento.DescripcionTela = txbNomTela.Text;
                        elemento.TipoTejido = txbTipoTejido.Text;
                        elemento.Coordinado = (cbxSiCoordinado.Checked) ? true : false;
                        elemento.CoordinadoCon = (txbCoordinaCon.Text.Trim().Length > 0) ? txbCoordinaCon.Text.Trim() : "";
                        elemento.Observacion = (txbObservaciones.Text.Trim().Length > 0) ? txbObservaciones.Text.Trim() : "";
                        elemento.IdSolicitudTela = idSolicitudTelas;

                        if (control.consultarIdentificadorUni(idSolicitudTelas))
                        {
                            control.Actualizar(elemento);
                            b = true;
                        }
                        else
                        {
                            control.addUnicolor(elemento);
                        }
                        id = control.getIdUni(idSolicitudTelas);
                        listaIdDetalles = control.getIdDetalle(id);
                        try
                        {
                            for (int i = 0; i < dgvUnicolor.RowCount; i++)
                            {
                                DetalleUnicolor detalle = new DetalleUnicolor();
                                detalle.IdUnicolor = id;
                                detalle.CodigoColor = dgvUnicolor.Rows[i].Cells[0].Value.ToString();
                                detalle.Descripcion = dgvUnicolor.Rows[i].Cells[1].Value.ToString().Trim();
                                detalle.Tiendas = (dgvUnicolor.Rows[i].Cells[2].Value != null && dgvUnicolor.Rows[i].Cells[2].Value.ToString() != "") ? int.Parse(dgvUnicolor.Rows[i].Cells[2].Value.ToString()) : 0;
                                detalle.Exito = (dgvUnicolor.Rows[i].Cells[3].Value != null && dgvUnicolor.Rows[i].Cells[3].Value.ToString() != "") ? int.Parse(dgvUnicolor.Rows[i].Cells[3].Value.ToString()) : 0;
                                detalle.Cencosud = (dgvUnicolor.Rows[i].Cells[4].Value != null && dgvUnicolor.Rows[i].Cells[4].Value.ToString() != "") ? int.Parse(dgvUnicolor.Rows[i].Cells[4].Value.ToString()) : 0;
                                detalle.Sao = (dgvUnicolor.Rows[i].Cells[5].Value != null && dgvUnicolor.Rows[i].Cells[5].Value.ToString() != "") ? int.Parse(dgvUnicolor.Rows[i].Cells[5].Value.ToString()) : 0;
                                detalle.Comercio = (dgvUnicolor.Rows[i].Cells[6].Value != null && dgvUnicolor.Rows[i].Cells[6].Value.ToString() != "") ? int.Parse(dgvUnicolor.Rows[i].Cells[6].Value.ToString()) : 0;
                                detalle.Rosado = (dgvUnicolor.Rows[i].Cells[7].Value != null && dgvUnicolor.Rows[i].Cells[7].Value.ToString() != "") ? int.Parse(dgvUnicolor.Rows[i].Cells[7].Value.ToString()) : 0;
                                detalle.Otros = (dgvUnicolor.Rows[i].Cells[8].Value != null && dgvUnicolor.Rows[i].Cells[8].Value.ToString() != "") ? int.Parse(dgvUnicolor.Rows[i].Cells[8].Value.ToString()) : 0;
                                detalle.Total = (dgvUnicolor.Rows[i].Cells[9].Value != null && dgvUnicolor.Rows[i].Cells[9].Value.ToString() != "") ? int.Parse(dgvUnicolor.Rows[i].Cells[9].Value.ToString()) : 0;

                                if (b)
                                {
                                    if(i < listaIdDetalles.Count)
                                    {
                                        control.ActualizarDetalle(detalle, listaIdDetalles[i]);
                                    }
                                    else
                                    {
                                        control.addDetalleUnicolor(detalle);
                                    }
                                }
                                else
                                {
                                    control.addDetalleUnicolor(detalle);
                                }
                            }
                            esClickBtnGrabar = true;
                            //DialogResult = DialogResult.OK("Hola");
                            MessageBox.Show("Unicolor se guardó con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           
                        }
                        catch 
                        {
                            MessageBox.Show("Detalle unicolor no se pudo guardar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            //consulta el id que esta en la tabla  cfc_spt_sol_tela
           //int idSolicitud = control.consultarIdsolicitud(identificador);
            // Consulta el número máximo que representa el último consecutivo ingresado en la tabla cfc_spt_tipo_solicitud
            int maxConsecutivo = control.consultarMaximo();
            // Se asignar valores para la fecha. 
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            // El estado que se le debe dar a solicitud cuando es confirmada

            string estado = "Por Analizar";

            if (id != 0)
            {
                control.agregarConsecutivo(idSolicitudTelas, id, "UNICOLOR", maxConsecutivo + 1, fechaActual, estado, fechaActual,identificador);
                MessageBox.Show("El consecutivo se guardó con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Deshabilita los diferentes botones y demás contenido del formulario que se quiere que no sea modificado una vez se confirme la solicitud.
                btnConfirmar.Enabled = false;
                btnGrabar.Enabled = false;
                txbObservaciones.Enabled = false;
                btnAddColor.Enabled = false;
                dgvUnicolor.ReadOnly = true;
                
                //consulta el consecutivo generado y se muestra en la vista.
                consecutivo = control.consultarConsecutivo(id);
                lblConsecutivo.Text = "Consecutivo: " + consecutivo;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Por favor, Grabe la Información.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txbCoordinaCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void dgvUnicolor_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvUnicolor.Columns[e.ColumnIndex].Name == "eliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = dgvUnicolor.Rows[e.RowIndex].Cells["eliminar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(@"eliminar.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 25, e.CellBounds.Top + 3);

                dgvUnicolor.Rows[e.RowIndex].Height = icoAtomico.Height + 50;
                dgvUnicolor.Columns[e.ColumnIndex].Width = icoAtomico.Width + 50;

                e.Handled = true;
            }
        }

        private void dgvUnicolor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUnicolor.Columns[e.ColumnIndex].Name == "eliminar")
            {
                dgvUnicolor.Rows.Remove(dgvUnicolor.CurrentRow);
            }
        }

        private void cargar() {
            //int idUnicolor = (control.getIdUnicolor(identificador).ToString() != null && control.getIdUnicolor(identificador).ToString() != "") ? int.Parse(control.getIdUnicolor(identificador).ToString()) : 0;

            Unicolor unicolor = control.getUnicolor(idSolicitudTelas);
            id = unicolor.Id;
            if (unicolor.Coordinado) {
                cbxSiCoordinado.Checked = true;
                txbCoordinaCon.Text = unicolor.CoordinadoCon;
            }
            else {
                cbxNoCoordinado.Checked = true;
            }
            txbObservaciones.Text = unicolor.Observacion;
            consecutivo = control.consultarConsecutivo(id);
            if (id != 0 && consecutivo != 0)
            {
                lblConsecutivo.Text = "Consecutivo: " + consecutivo;
                dgvUnicolor.ReadOnly = true;
                btnConfirmar.Enabled = false;
                btnGrabar.Enabled = false;
                btnAddColor.Enabled = false;
            }
            /*Carga detalle unicolor*/
            List<DetalleUnicolor> lista = control.getDetalleUnicolor(unicolor.Id);
            if (lista.Count > 0)
            {
                foreach (DetalleUnicolor obj in lista)
                {
                    dgvUnicolor.Rows.Add(obj.CodigoColor, obj.Descripcion, obj.Exito, obj.Tiendas,
                        obj.Cencosud, obj.Sao, obj.Comercio, obj.Rosado, obj.Otros, obj.Total);
                }
                //btnAddColor.Enabled = false;
                //dgvUnicolor.ReadOnly = true;
                //btnGrabar.Enabled = false;
                //txbObservaciones.Enabled = false;
            }
        }
    }
}
