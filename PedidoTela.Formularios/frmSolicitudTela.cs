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
    public partial class frmSolicitudTela : MaterialSkin.Controls.MaterialForm
    {

        Controlador controlador = new Controlador();
        ErrorProvider errorProvider = new ErrorProvider();
        Validar validacion = new Validar();
        bool editando = false;

        public frmSolicitudTela()
        {
            InitializeComponent();

            this.ttTipo.SetToolTip(this.cbxTipo, "Por favor Seleccione un Tipo");
            this.ttEnsayoRef.SetToolTip(this.txbEnsRefDigitado, "Precione Enter para Buscar");
            this.ttSku.SetToolTip(this.txbSku, "Por favor Ingrese solo 3 Carateres");
            dtpFechaTienda.Format = DateTimePickerFormat.Custom;
            dtpFechaTienda.CustomFormat = "dd/MM/yyyy";
            txbSku.MaxLength = 3;

        }

        private void frmSolicitudTela_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey400, Primary.Grey100, Accent.Green100, TextShade.WHITE);
        }

        /// <summary>
        /// Carga la información referente a las TexBox (Diseñador, Ocasión de Uso, Muestrario, Entrada, Tema y Año).
        /// </summary>
        /// <param name="prmCombo">ComboBox de Selección.</param>
        /// <param name="prmlista">Lista de Ensayos - Referencias</param>
        private void cargarTexBox(ComboBox prmCombo, List<Ensayo> prmlista)
        {
            if (prmlista.Count != 0)
            {
                txbDisenador.Text = prmlista[0].Programador.ToString();
                txbOcasionUso.Text = prmlista[0].Ocasion_uso.ToString();
                txbMuestrario.Text = prmlista[0].Nmro_muestrario.ToString();
                txbEntrada.Text = prmlista[0].Entrada.ToString();
                txbTema.Text = prmlista[0].Tema.ToString();
                txbAnio.Text = prmlista[0].Anio_muestrario.ToString();
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        /// <summary>
        /// Carga la información del Detalle Consumo.
        /// </summary>
        /// <param name="prmLista">Lista de Tipo DetalleConsumo</param>
        private void cargarDataGridView(List<DetalleConsumo> prmLista)
        {
            if (prmLista.Count != 0)
            {
                dgvDetalleConsumo.Rows.Add(prmLista[0].Ensayo_referencia.ToString(),
                prmLista[0].Desc_prenda.ToString(),
                prmLista[0].Codigo_tela.ToString(),
                prmLista[0].Descripcion_tela.ToString(),
                "",
                prmLista[0].Consumo_est.ToString());                
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Carga los datos que se han Editado 
        /// </summary>
        /// <param name="prmLista"></param>
        private void cargarDgvDatosEditados(List<EditarDetalleconsumo> prmLista)
        {
            dgvDetalleConsumo.Rows.Clear();
            if (prmLista.Count != 0)
            {
                dgvDetalleConsumo.Rows.Add(prmLista[0].Identificador.ToString(),
                prmLista[0].DescripcionPrenda.ToString(),
                prmLista[0].ReferenciaTela.ToString(),
                prmLista[0].DescripcionTela.ToString(),
                prmLista[0].TipoSolicitud.ToString(),
                decimal.Round(decimal.Parse(prmLista[0].Consumo.ToString().Replace(".", ",")), 2).ToString());
                txbSku.Text = prmLista[0].Sku.ToString();
                dtpFechaTienda.Value = DateTime.Parse(prmLista[0].FechaTienda.ToString());
            }
            else
            {
                cargarDataGridView(controlador.getDetalleConsumoEnsayo(txbEnsRefDigitado.Text));
            }
        }

        private void cargarDgvEditadosPorREf(List<EditarDetalleconsumo> prmLista)
        {
            dgvDetalleConsumo.Rows.Clear();
            if (prmLista.Count != 0)
            {
                dgvDetalleConsumo.Rows.Add(prmLista[0].Identificador.ToString(),
                prmLista[0].DescripcionPrenda.ToString(),
                prmLista[0].ReferenciaTela.ToString(),
                prmLista[0].DescripcionTela.ToString(),
                prmLista[0].TipoSolicitud.ToString(),
                decimal.Round(decimal.Parse(prmLista[0].Consumo.ToString().Replace(".", ",")), 2).ToString());
                txbSku.Text = prmLista[0].Sku.ToString();
                dtpFechaTienda.Value = DateTime.Parse(prmLista[0].FechaTienda.ToString());
            }
            else
            {
                cargarDataGridView(controlador.getDetalleConsumoReferencia(txbEnsRefDigitado.Text));
            }
        }

        /// <summary>
        /// Válida que TexBox(txbSku) se ingresen solo Letras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbSku_Validating(object sender, CancelEventArgs e)
        {

            if (txbSku.Text == "")
            {
                //e.Cancel = true;
                txbSku.Select(0, txbSku.Text.Length);
                errorProvider.SetError(txbSku, "Debe introducir el SKU");
            }
        }

        /// <summary>
        /// Según la selección de una celda en el DatagridView(dgvDetalleconsumo) realizá una acción.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDetalleConsumo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6) {
                editando = true;
            }
            if (e.RowIndex > -1) {
                if (dgvDetalleConsumo.Columns[e.ColumnIndex].Name == "guardar")
                {
                    guardarDetalleCons(e);
                    dgvDetalleConsumo.CurrentRow.Cells[2].ReadOnly = true;
                    dgvDetalleConsumo.CurrentRow.Cells[3].ReadOnly = true;
                    dgvDetalleConsumo.CurrentRow.Cells[4].ReadOnly = true;
                    dgvDetalleConsumo.CurrentRow.Cells[6].ReadOnly = false;
                    editando = false;
                }
                else if (!editando)
                {
                    string identificador = dgvDetalleConsumo.CurrentRow.Cells[0].Value.ToString().Trim();
                    int id = controlador.consultarIdsolicitud(identificador);
                    if (id != 0)
                    {
                        frmTipoSolicitud objTipoSolicitud = new frmTipoSolicitud();
                        objTipoSolicitud.StartPosition = FormStartPosition.CenterScreen;
                        if (objTipoSolicitud.ShowDialog() == DialogResult.OK)
                        {
                            String seleccion = objTipoSolicitud.Seleccion;
                            if (seleccion == "unicolor")
                            {
                                frmSolicitudUnicolor frmUnicolor = new frmSolicitudUnicolor(controlador, identificador, dgvDetalleConsumo.Rows[e.RowIndex].Cells[2].Value.ToString());
                                frmUnicolor.Show();
                            }
                            else if (seleccion == "estampado")
                            {
                                pnl frmEstamapado = new pnl(controlador, identificador);
                                frmEstamapado.Show();
                                frmEstamapado.recibirInfoTela(dgvDetalleConsumo.CurrentRow.Cells["refTela"].Value.ToString(), dgvDetalleConsumo.CurrentRow.Cells["desTela"].Value.ToString());
                            }
                            else if (seleccion == "planoPre")
                            {
                                frmSolicitudPlanoPretenido frmPlapretenido = new frmSolicitudPlanoPretenido(controlador, identificador, dgvDetalleConsumo.Rows[e.RowIndex].Cells[2].Value.ToString());
                                frmPlapretenido.Show();
                            }
                            else if (seleccion == "cuelloPun")
                            {
                                frmSolicitudCuellosTiras frmCuellos = new frmSolicitudCuellosTiras(controlador,identificador);
                                frmCuellos.Show();
                            }
                        }
                    }
                    else {
                        MessageBox.Show("Por favor, guarde la solicitud!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    dgvDetalleConsumo.ReadOnly = false;

                    if (e.ColumnIndex > 1 && e.ColumnIndex < 6)
                    {
                        dgvDetalleConsumo.CurrentRow.Cells[0].ReadOnly = true;
                        dgvDetalleConsumo.CurrentRow.Cells[1].ReadOnly = true;
                        dgvDetalleConsumo.CurrentRow.Cells[2].ReadOnly = false;
                        dgvDetalleConsumo.CurrentRow.Cells[3].ReadOnly = false;
                        dgvDetalleConsumo.CurrentRow.Cells[4].ReadOnly = false;
                        dgvDetalleConsumo.CurrentRow.Cells[5].ReadOnly = false;
                        dgvDetalleConsumo.CurrentRow.Cells[6].ReadOnly = true;

                        dgvDetalleConsumo.CurrentRow.Cells[2].Style.BackColor = Color.PaleGoldenrod;
                        dgvDetalleConsumo.CurrentRow.Cells[3].Style.BackColor = Color.PaleGoldenrod;
                        dgvDetalleConsumo.CurrentRow.Cells[4].Style.BackColor = Color.PaleGoldenrod;
                        dgvDetalleConsumo.CurrentRow.Cells[5].Style.BackColor = Color.PaleGoldenrod;
                    }

                    if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
                    {
                        frmEditarDsolicitudTela objEditar = new frmEditarDsolicitudTela(controlador);
                        objEditar.StartPosition = FormStartPosition.CenterScreen;

                        if (objEditar.ShowDialog() == DialogResult.OK)
                        {
                            Objeto obj = objEditar.Elemento;
                            dgvDetalleConsumo.Rows[dgvDetalleConsumo.Rows.Count - 1].Cells[2].Value = obj.Id;
                            dgvDetalleConsumo.Rows[dgvDetalleConsumo.Rows.Count - 1].Cells[3].Value = obj.Nombre;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Consulta la información del Detalle consumo, primero consulta en la tabla cfc_spt_sol_tela si no encuentra información, consulta en las tablas ya previamente establecidas con anterioridad
        /// tales como, cfc_telas_ensayo, cfc_m_prgrmdor, cfc_m_capsulas, entre otras. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (txbEnsRefDigitado.Text == "" || cbxTipo.SelectedItem.ToString() == null)
            {
                MessageBox.Show("Por favor ingrese Ensayo/Referencia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cbxTipo.SelectedItem.ToString() == "Ensayo")
            {
                cargarDgvDatosEditados(controlador.getDcEditadoPorEnsayo(txbEnsRefDigitado.Text));
            }
            else
            {
                cargarDgvEditadosPorREf(controlador.getDetalleEditadoPorRef(txbEnsRefDigitado.Text));
            }
        }

        /// <summary>
        /// Carga información según un identificador de Ensayo o una Referencia.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbEnsRefDigitado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxTipo.SelectedItem == null)
            {
                MessageBox.Show("Por Favor selecione un tipo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cbxTipo.SelectedItem.ToString() == "Ensayo" && (e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                string[] objId = txbEnsRefDigitado.Text.Split('-');
                if (objId.Length < 3)
                {
                    MessageBox.Show("No existe infación sobre el N° ensayo ingresado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cargarTexBox(cbxTipo, controlador.getEnsayo(txbEnsRefDigitado.Text));
                    dgvDetalleConsumo.Rows.Clear();
                    txbSku.Clear();
                    dtpFechaTienda.Value = DateTime.Now;
                }
            }
            else if (cbxTipo.SelectedItem.ToString() == "Referencia" && (e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                cargarTexBox(cbxTipo, controlador.getReferencia(txbEnsRefDigitado.Text));
                dgvDetalleConsumo.Rows.Clear();
                txbSku.Clear();
                dtpFechaTienda.Value = DateTime.Now;
            }
        }

        /// <summary>
        /// Habilita el campo de texto txbEnsRefDigitado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbxTipo.SelectedItem.ToString() == "Ensayo" || (cbxTipo.SelectedItem.ToString() == "Referencia"))
            {
                txbEnsRefDigitado.ReadOnly = false;
                txbEnsRefDigitado.Focus();
                txbEnsRefDigitado.BackColor = Color.LightGoldenrodYellow;
                validacion.limpiar(pnlAdicionarSolicitud);
            }
            else
            {
                MessageBox.Show("Por Favor selecione un tipo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        /// <summary>
        /// Muestra un mensaje de advertencia si el campo de texto txbSku está vacío
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbSku_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void dgvDetalleConsumo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5) {
                if (dgvDetalleConsumo.CurrentCell.Value != null && dgvDetalleConsumo.CurrentCell.Value.ToString().Trim() != "")
                {
                    dgvDetalleConsumo.CurrentCell.Value = dgvDetalleConsumo.CurrentCell.Value.ToString().Trim().Replace(".", ",");
                    dgvDetalleConsumo.CurrentCell.Value = Regex.Replace(dgvDetalleConsumo.CurrentCell.Value.ToString().Trim(), @"[^0-9,]", "");
                    if (dgvDetalleConsumo.CurrentCell.Value != null && dgvDetalleConsumo.CurrentCell.Value.ToString().Trim() != "") {
                        decimal valor = Decimal.Parse(dgvDetalleConsumo.CurrentCell.Value.ToString());
                        decimal vfinal = Decimal.Round(valor, 2);
                        dgvDetalleConsumo.CurrentCell.Value = vfinal;
                    }
                }
            }
        }

        /// <summary>
        /// Muestra las imagnes.ico en las celdas editar y guardar del DataGridView(dgvDetalleConsumo)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDetalleConsumo_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvDetalleConsumo.Columns[e.ColumnIndex].Name == "editar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = dgvDetalleConsumo.Rows[e.RowIndex].Cells["editar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(@"editar6.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 25, e.CellBounds.Top + 3);

                dgvDetalleConsumo.Rows[e.RowIndex].Height = icoAtomico.Height + 50;
                dgvDetalleConsumo.Columns[e.ColumnIndex].Width = icoAtomico.Width + 50;

                e.Handled = true;
            }
            if (e.ColumnIndex >= 0 && dgvDetalleConsumo.Columns[e.ColumnIndex].Name == "guardar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = dgvDetalleConsumo.Rows[e.RowIndex].Cells["guardar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(@"guardar.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 25, e.CellBounds.Top + 3);

                dgvDetalleConsumo.Rows[e.RowIndex].Height = icoAtomico.Height + 50;
                dgvDetalleConsumo.Columns[e.ColumnIndex].Width = icoAtomico.Width + 50;

                e.Handled = true;
            }
        }

        /// <summary>
        /// Guarda los datos editados de la DataGridView(dgvDetalleConsumo)  en la tabla cfc_spt_sol_telaa, los cuales son Referencia Tela, Descripción de la Tela
        /// ,fecha_tienda y el sku.
        /// </summary>
        /// <param name="e"></param>
        private void guardarDetalleCons(DataGridViewCellEventArgs e)
        {
            EditarDetalleconsumo detalle = new EditarDetalleconsumo();
            detalle = obtenerObjDetalleConsumo(e);
            if (detalle != null) {
                if (controlador.consultarIdentificador(txbEnsRefDigitado.Text))
                {
                    //Realiza un UPDATE dado que el Indentificador ya esta en la tabla.
                    if (controlador.setDcEditadoPorEnsayo(detalle, txbEnsRefDigitado.Text))
                    {
                        MessageBox.Show("La información se actualizo con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    controlador.addDetalleConsumo(detalle);
                    MessageBox.Show("La información se guardó con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
                   
        }

        private EditarDetalleconsumo obtenerObjDetalleConsumo(DataGridViewCellEventArgs e)
        {
            EditarDetalleconsumo elemento = new EditarDetalleconsumo();
            string fecha = dtpFechaTienda.Value.ToString("dd/MM/yyyy");
            if (fecha == "")
            {
                elemento = null;
                MessageBox.Show("Por favor, seleccione un valor para fecha.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                if (txbSku.Text.Trim().Length == 0)
                {
                    elemento = null;
                    MessageBox.Show("Por favor, ingrese el SKU.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else {
                    if (dgvDetalleConsumo.RowCount > 0)
                    {
                        elemento.Identificador = (string)dgvDetalleConsumo.Rows[e.RowIndex].Cells[0].Value;
                        elemento.Tipo = cbxTipo.SelectedItem.ToString();
                        elemento.DescripcionPrenda = (string)dgvDetalleConsumo.Rows[e.RowIndex].Cells[1].Value;
                        elemento.ReferenciaTela = (string)dgvDetalleConsumo.Rows[e.RowIndex].Cells[2].Value;
                        elemento.DescripcionTela = (string)dgvDetalleConsumo.Rows[e.RowIndex].Cells[3].Value;
                        elemento.Consumo = (dgvDetalleConsumo.Rows[e.RowIndex].Cells[5].Value != null) ? dgvDetalleConsumo.Rows[e.RowIndex].Cells[5].Value.ToString() : "0";
                        elemento.Sku = txbSku.Text.Trim();
                        elemento.FechaTienda = fecha;
                        return elemento;
                    }
                }
            }
            
            return elemento;
        }
    }
}
