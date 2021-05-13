using MaterialSkin;
using PedidoTela.Controlodores;
using PedidoTela.Entidades;
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
    public partial class frmPedidoaMontarEstampado : MaterialSkin.Controls.MaterialForm
    {
        #region variables
        private Controlador control = new Controlador();
        private List<MontajeTelaDetalle> solicitudes = new List<MontajeTelaDetalle>();
        private List<int> listaIdSolicitudes = new List<int>();
        private List<string> listaEsayosRef = new List<string>();
        private Validar validacion = new Validar();
        private int idSolicitud, id, consecutivo;
        private bool bandera = false;
        #endregion

        public frmPedidoaMontarEstampado(Controlador control, List<MontajeTelaDetalle> solicitudes)
        {
            InitializeComponent();
            this.control = control;
            this.solicitudes = solicitudes;
        }

        #region Eventos

        private void frmPedidoaMontarEstampado_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
            cargarCombobox(cbxTipoMarcacion, control.getTipoMarcacion());
            cargar();
            if (id == 0) {
                cargarDgvInfoConsolidar(solicitudes);
                calcularTotalesPorColores();
            }
            dgvInfoConsolidar.Columns[0].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInfoConsolidar.Columns[1].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInfoConsolidar.Columns[13].HeaderCell.ToolTipText = "(Consumo * Total Unidades)*1.10";
            dgvInfoConsolidar.Columns[15].HeaderCell.ToolTipText = "M calculados -  M reservados";
            dgvInfoConsolidar.Columns[16].HeaderCell.ToolTipText = "M a solicitar / Rendimiento";

            dgvTotalConsolidado.Columns[12].HeaderCell.ToolTipText = "(Consumo * Total Unidades)*1.10";
            dgvTotalConsolidado.Columns[13].HeaderCell.ToolTipText = "M a solicitar / Rendimiento";
        }

        private void cbxClase_SelectedIndexChanged(object sender, EventArgs e)
        {  
            if (cbxClase.SelectedIndex != -1 && cbxClase.SelectedItem.ToString().ToLower() == "no tejer")
            {
                this.bandera = true;
                btnAgregarPedido.Enabled = true;
            }
            else
            {
                this.bandera = false;
            }
        }

        private void txtRendimiento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvInfoConsolidar.RowCount; i++)
                {
                    if (txtRendimiento.Text.Trim() != "")
                    {
                        if (dgvInfoConsolidar.Rows[i].Cells[15].Value != null && dgvInfoConsolidar.Rows[i].Cells[15].Value.ToString() != "") {
                            decimal mSolicitar = decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[15].Value.ToString());
                            decimal rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
                            dgvInfoConsolidar.Rows[i].Cells[16].Value = calcularKgCalculados(mSolicitar, rendimiento);
                        }
                    }
                    else
                    {
                        dgvInfoConsolidar.Rows[i].Cells[16].Value = 0;
                    }
                }
                calcularTotalesPorColores();
            }
            catch 
            {
                txtRendimiento.Text = "";
            }
        }

        private void txtRendimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtRendimiento.Text.Trim() != "")
            {
                validacion.validarDecimal(sender, e);
            }
        }

        private void dgvInfoConsolidar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                frmBuscarColor buscarColor = new frmBuscarColor(control);
                buscarColor.StartPosition = FormStartPosition.CenterScreen;
                if (buscarColor.ShowDialog() == DialogResult.OK)
                {
                    Objeto obj = buscarColor.Elemento;
                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[0].Value = obj.Id;
                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[1].Value = obj.Nombre;

                    //dgvTotalConsolidado.Rows[e.RowIndex].Cells[0].Value = obj.Id;
                    //dgvTotalConsolidado.Rows[e.RowIndex].Cells[1].Value = obj.Nombre;
                }
                calcularTotalesPorColores();
            }
            else if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                frmBuscarColor buscarColor = new frmBuscarColor(control);
                buscarColor.StartPosition = FormStartPosition.CenterScreen;
                if (buscarColor.ShowDialog() == DialogResult.OK)
                {
                    Objeto obj = buscarColor.Elemento;
                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[2].Value = obj.Id;
                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[3].Value = obj.Nombre;

                    //dgvTotalConsolidado.Rows[e.RowIndex].Cells[2].Value = obj.Id;
                    //dgvTotalConsolidado.Rows[e.RowIndex].Cells[3].Value = obj.Nombre;
                }
                calcularTotalesPorColores();
            }
            
        }

        private void dgvInfoConsolidar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12) //Cuando cambia el consumo [12] cambia M Calculados [13]
            {
                try
                {
                    if (dgvInfoConsolidar.CurrentCell.Value != null && dgvInfoConsolidar.CurrentCell.Value.ToString().Trim() != "")
                    {
                        dgvInfoConsolidar.CurrentCell.Value = dgvInfoConsolidar.CurrentCell.Value.ToString().Replace(",", ".");
                        dgvInfoConsolidar.CurrentCell.Value = Regex.Replace(dgvInfoConsolidar.CurrentCell.Value.ToString(), @"[^0-9.]", "");

                        if (dgvInfoConsolidar.CurrentCell.Value != null && dgvInfoConsolidar.CurrentCell.Value.ToString().Trim() != "")
                        {
                            decimal consumo = decimal.Parse(dgvInfoConsolidar.CurrentCell.Value.ToString());
                            int totalUnidades = int.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value.ToString());
                            dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = calcularMCalculados(consumo, totalUnidades);


                            // cuando cambia M Calculados [13] se actualiza M Solicitar [15]
                            if (dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value != null && dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value.ToString().Trim() != "")
                            {
                                decimal mCalculados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value.ToString());

                                if (dgvInfoConsolidar.Rows[e.RowIndex].Cells[14].Value != null && dgvInfoConsolidar.Rows[e.RowIndex].Cells[14].Value.ToString() != "")
                                {
                                    decimal mReservados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[14].Value.ToString());
                                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[15].Value = calcularMSolicitar(mCalculados, mReservados);
                                }
                                else
                                {
                                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[15].Value = mCalculados;
                                }
                            }
                            else
                            {
                                dgvInfoConsolidar.Rows[e.RowIndex].Cells[15].Value = "";
                            }

                        }
                    }
                    else
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[16].Value = "";
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = "";
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[15].Value = "";
                    }
                }
                catch (Exception ex)
                {
                    dgvInfoConsolidar.CurrentCell.Value = "";
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (e.ColumnIndex == 13) // cuando cambia M Calculados [13] se actualiza M Solicitar [15]
            {
                if (dgvInfoConsolidar.CurrentCell.Value != null && dgvInfoConsolidar.CurrentCell.Value.ToString().Trim() != "")
                {
                    decimal mCalculados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value.ToString());

                    if (dgvInfoConsolidar.Rows[e.RowIndex].Cells[14].Value != null && dgvInfoConsolidar.Rows[e.RowIndex].Cells[14].Value.ToString() != "")
                    {
                        decimal mReservados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[14].Value.ToString());
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[15].Value = calcularMSolicitar(mCalculados, mReservados);
                    }
                    else {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[15].Value = mCalculados;
                    }
                }
                else {
                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[15].Value = "";
                }
            }
            else if (e.ColumnIndex == 14) // cuando cambia M Reservados [14] cambia el M Solicitar [15]
            {
                try
                {
                    if (dgvInfoConsolidar.CurrentCell.Value != null && dgvInfoConsolidar.CurrentCell.Value.ToString().Trim() != "")
                    {
                        if (dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value != null && dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value.ToString() != "")
                        {
                            decimal mReservados = decimal.Parse(dgvInfoConsolidar.CurrentCell.Value.ToString());
                            decimal mCalculados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value.ToString());
                            if (mCalculados >= mReservados) {
                                decimal mSolicitar = calcularMSolicitar(mCalculados, mReservados); ;
                                dgvInfoConsolidar.Rows[e.RowIndex].Cells[15].Value = mSolicitar;

                                if (txtRendimiento.Text.Trim() != "")
                                {
                                    decimal rendimiento = decimal.Parse(txtRendimiento.Text);
                                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[16].Value = decimal.Round(mSolicitar / rendimiento, 2);
                                }
                            }
                            else
                            {
                                dgvInfoConsolidar.CurrentCell.Value = "";
                                MessageBox.Show("M Reservados no puede ser mayor a M Calculados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else {
                            dgvInfoConsolidar.CurrentCell.Value = "";
                            MessageBox.Show("Por favor ingrese el consumo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[15].Value = dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value;
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[16].Value = decimal.Round(decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[15].Value.ToString()) / decimal.Parse(txtRendimiento.Text),2);
                    }
                }
                catch (Exception ex)
                {
                    dgvInfoConsolidar.CurrentCell.Value = "";
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            calcularTotalesPorColores();
        }

        private void dgvTotalConsolidado_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 14)
            {
                try
                {
                    if (dgvTotalConsolidado.CurrentCell.Value != null && dgvTotalConsolidado.CurrentCell.Value.ToString().Trim() != "")
                    {
                        dgvTotalConsolidado.CurrentCell.Value = dgvTotalConsolidado.CurrentCell.Value.ToString().Replace(",", ".");
                        dgvTotalConsolidado.CurrentCell.Value = Regex.Replace(dgvTotalConsolidado.CurrentCell.Value.ToString(), @"[^0-9.]", "");
                    }
                    else
                    {
                        dgvTotalConsolidado.CurrentCell.Value = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #region Formato grillas
        private void dgvInfoConsolidar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 3 && e.ColumnIndex <= 11 || e.ColumnIndex > 12 && e.ColumnIndex <= 13 || e.ColumnIndex > 14 && e.ColumnIndex <= 16)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }

        private void dgvTotalConsolidado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex <= 13)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }
        #endregion

        #region Botones
        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            frmBuscarPedido buscar = new frmBuscarPedido(control, solicitudes[0].IdProgramador);
            if (buscar.ShowDialog() == DialogResult.OK) {
                TomarDelPedido obj = buscar.Elemento;
                dgvPedidos.Rows.Add();
                dgvPedidos.Rows[dgvPedidos.Rows.Count - 1].Cells[0].Value = obj.NumeroPedido;
                dgvPedidos.Rows[dgvPedidos.Rows.Count - 1].Cells[1].Value = obj.CodigoColor;
                dgvPedidos.Rows[dgvPedidos.Rows.Count - 1].Cells[2].Value = obj.Estado;
                dgvPedidos.Rows[dgvPedidos.Rows.Count - 1].Cells[3].Value = obj.Disponible;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e) 
        {
            if (this.bandera && dgvPedidos.RowCount == 0)
            {
                MessageBox.Show("Por favor, seleccione al menos un pedido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (cbxClase.SelectedIndex != -1)
                {
                    if (cbxTipoMarcacion.SelectedIndex != -1)
                    {
                        if (txtRendimiento.Text.Trim() != "")
                        {
                            if (txtAnalista.Text != "")
                            {
                                if (txtDesPrenda.Text != "")
                                {
                                    if (dgvInfoConsolidar.RowCount > 0 && dgvTotalConsolidado.RowCount > 0)
                                    {
                                        if (!validarValoresConsumo())
                                        {
                                            if (!validarValoresReserva())
                                            {
                                                if (!validarTotalAPedir())
                                                {

                                                    if (!validarUnidadTotal())
                                                    {
                                                        PedidoAMontar pedido = new PedidoAMontar();
                                                        pedido.Id = id;
                                                        pedido.Tela = txtNomTela.Text.Trim();
                                                        pedido.Disenador = txtDisenador.Text.Trim();
                                                        pedido.Rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
                                                        pedido.EnsayoReferencia = txtEnsayoRef.Text.Trim();
                                                        pedido.DescripcionPrenda = txtDesPrenda.Text.Trim();
                                                        pedido.Clase = cbxClase.SelectedItem.ToString();
                                                        pedido.TipoMarcacion = ((Objeto)cbxTipoMarcacion.SelectedItem).Nombre;
                                                        pedido.Rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
                                                        pedido.AnalistasCortesB = txtAnalista.Text.Trim();
                                                        pedido.FechaLlegada = dtpFechaLlegada.Value.ToString("dd/MM/yyyy");
                                                        pedido.IdSolicitud = idSolicitud;
                                                        if (control.existePedidoEstampado(idSolicitud))
                                                        {
                                                            control.actualizarPedidoEstampado(pedido);
                                                        }
                                                        else
                                                        {
                                                            control.addPedidoEstampado(pedido);
                                                            pedido.Id = control.getIdPedidoEstampado(idSolicitud);
                                                        }
                                                        if (pedido.Id != 0)
                                                        {
                                                            control.eliminarPedidoEstampadoTotal(pedido.Id);
                                                            control.eliminarPedidoEstampadoInformacion(pedido.Id);
                                                            control.eliminarPedido(pedido.Id);

                                                            guardarPedido(pedido.Id);
                                                            guardarInformacion(pedido.Id);
                                                            guardarTotal(pedido.Id);
                                                        }
                                                        //Agrega el Consolidado.
                                                        AgregarConsolidado();

                                                        MessageBox.Show("Pedido Estampado se guardó con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("Por favor seleccione los valores para la columna: Unidad medida tela.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Por favor ingrese los valores para la columna: Total a pedir.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Por favor ingrese los valores para la columna: M Reservados.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Por favor ingrese los valores para la columna: Consumo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Por favor ingrese un valor en el campo Descripción prenda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Por favor ingrese un valor en el campo Analista corte B.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor ingrese un valor en el campo Rendimiento tela.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor seleccione un valor en el campo Tipo marcación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor seleccione un valor en el campo Clase", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int maxConsecutivo = control.consultarMaxConsecutivoPedido();
            // Se asignar valores para la fecha. 
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            // El estado que se le debe dar a solicitud cuando es confirmada

            string estado = "Radicado";

            if (id != 0)
            {
                for (int i = 0; i < listaIdSolicitudes.Count; i++)
                {
                    control.agregarConsecutivo(listaIdSolicitudes[i], maxConsecutivo + 1, fechaActual, estado);
                }
                MessageBox.Show("La información se guardó con éxito. \n El estado se actualizó a Radicado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Deshabilita los diferentes botones y demás contenido del formulario que se quiere que no sea modificado una vez se confirme la solicitud.
                btnConfirmar.Enabled = false;
                btnGrabar.Enabled = false;

                dgvInfoConsolidar.ReadOnly = true;
                dgvTotalConsolidado.ReadOnly = true;

                //Consulta el consecutivo generado y se muestra en la vista.
                consecutivo = control.consultarConsecutivoPedido(idSolicitud);
                lblConsecutivo.Text = "Consecutivo: " + consecutivo;
            }
            else
            {
                MessageBox.Show("Por favor, Grabe la Información.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                frmImprimirPedidoEstampado imprimir = new frmImprimirPedidoEstampado(control, idSolicitud);
                imprimir.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor guarde el consolidado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion

        #region otros métodos
        ///<summary> Realiza la carga de los datos en el ComboBox </summary>
        ///<param name="lista">Lista de tipo Objeto</param>
        ///<returns></returns>*/
        private void cargarCombobox(ComboBox combo, List<Objeto> lista)
        {
            combo.DataSource = lista;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "Id";
            combo.SelectedIndex = -1;
            combo.AutoCompleteCustomSource = cargarCombobox(lista);
            combo.AutoCompleteMode = AutoCompleteMode.Suggest;
            combo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        ///<summary> Permite el autocompletado de un comboBox </summary>
         ///<param name="lista">Lista de tipo objeto</param>
         /// <returns></returns>*/
        private AutoCompleteStringCollection cargarCombobox(List<Objeto> lista)
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            foreach (Objeto obj in lista)
            {
                datos.Add(obj.Nombre);
            }
            return datos;
        }

        private void cargarDgvInfoConsolidar(List<MontajeTelaDetalle> prmLista)
        {
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {
                    dgvInfoConsolidar.Rows.Add(
                        prmLista[i].Vte.ToString(),
                        prmLista[i].DesColor.ToString(),
                        prmLista[i].CodFondo.ToString(),
                        prmLista[i].Fondo.ToString(),
                        prmLista[i].Tiendas.ToString(),
                        prmLista[i].Exito.ToString(),
                        prmLista[i].Cencosud.ToString(),
                        prmLista[i].Sao.ToString(),
                        prmLista[i].Comercio.ToString(),
                        prmLista[i].Rosado.ToString(),
                        prmLista[i].Otros.ToString(),
                        prmLista[i].TotaUnidades.ToString(),
                        prmLista[i].Consumo.ToString(),
                        prmLista[i].MCalculados.ToString(),
                        prmLista[i].MReservados.ToString(),
                        prmLista[i].Masolicitar.ToString()
                    );

                    txtEnsayoRef.Text += prmLista[i].RefSimilar.ToString() + "\n";
                    txtDesPrenda.Text = prmLista[i].DescPrenda.ToString();
                    idSolicitud = prmLista[i].IdSolTela;
                    listaIdSolicitudes.Add(prmLista[i].IdSolTela);
                    listaEsayosRef.Add(prmLista[i].RefSimilar);
                }
                txtNomTela.Text = prmLista[0].DesTela.ToString();
                txtDisenador.Text = prmLista[0].Disenador.ToString();
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void calcularTotalesPorColores()
        {
            List<Objeto> colores = new List<Objeto>();
            for (int i = 0; i < dgvInfoConsolidar.RowCount; i++)
            {
                Objeto color = new Objeto();
                color.Id = dgvInfoConsolidar.Rows[i].Cells[0].Value.ToString().ToLower();
                color.Nombre = dgvInfoConsolidar.Rows[i].Cells[1].Value.ToString().ToLower();
                bool existe = false;
                foreach (Objeto obj in colores)
                {
                    if (obj.Nombre == color.Nombre)
                    {
                        existe = true;
                    }
                }
                if (!existe)
                {
                    colores.Add(color);
                }
            }
            List<PedidoMontarTotal> totales = new List<PedidoMontarTotal>(); 
            foreach (Objeto obj in colores)
            {
                PedidoMontarTotal objColor = new PedidoMontarTotal(0, obj.Id, obj.Nombre, "", "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "");
                for (int i = 0; i < dgvInfoConsolidar.RowCount; i++)
                {
                    if (dgvInfoConsolidar.Rows[i].Cells[1].Value.ToString().ToLower() == obj.Nombre)
                    {
                        objColor.Fondo = dgvInfoConsolidar.Rows[i].Cells[2].Value.ToString();
                        objColor.DescripcionFondo = dgvInfoConsolidar.Rows[i].Cells[3].Value.ToString();
                        objColor.Tiendas += (dgvInfoConsolidar.Rows[i].Cells[4].Value != null && dgvInfoConsolidar.Rows[i].Cells[4].Value.ToString() != "") ?int.Parse(dgvInfoConsolidar.Rows[i].Cells[4].Value.ToString()): 0;
                        objColor.Exito += (dgvInfoConsolidar.Rows[i].Cells[5].Value != null && dgvInfoConsolidar.Rows[i].Cells[5].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[5].Value.ToString()):0;
                        objColor.Cencosud += (dgvInfoConsolidar.Rows[i].Cells[6].Value != null && dgvInfoConsolidar.Rows[i].Cells[6].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[6].Value.ToString()):0;
                        objColor.Sao += (dgvInfoConsolidar.Rows[i].Cells[7].Value != null && dgvInfoConsolidar.Rows[i].Cells[7].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[7].Value.ToString()):0;
                        objColor.ComercioOrg += (dgvInfoConsolidar.Rows[i].Cells[8].Value != null && dgvInfoConsolidar.Rows[i].Cells[8].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[8].Value.ToString()):0;
                        objColor.Rosado += (dgvInfoConsolidar.Rows[i].Cells[9].Value != null && dgvInfoConsolidar.Rows[i].Cells[9].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[9].Value.ToString()):0;
                        objColor.Otros += (dgvInfoConsolidar.Rows[i].Cells[10].Value != null && dgvInfoConsolidar.Rows[i].Cells[10].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[10].Value.ToString()):0;
                        objColor.TotalUnidades += (dgvInfoConsolidar.Rows[i].Cells[11].Value != null && dgvInfoConsolidar.Rows[i].Cells[11].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[11].Value.ToString()):0;
                        objColor.MCalculados += (dgvInfoConsolidar.Rows[i].Cells[13].Value != null && dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString()):0;
                        objColor.KgCalculados += (dgvInfoConsolidar.Rows[i].Cells[16].Value != null && dgvInfoConsolidar.Rows[i].Cells[16].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[16].Value.ToString()):0;
                    }
                }
                totales.Add(objColor);
            }

            if (totales.Count != 0)
            {
                //Si hay más filas en total consolidado que colores se eliminan filas
                if (totales.Count < dgvTotalConsolidado.Rows.Count) {
                    for (int i = totales.Count; i < dgvTotalConsolidado.Rows.Count; i++) {
                        dgvTotalConsolidado.Rows.RemoveAt(i);
                    }
                }//Si hay más colores que filas en total consolidado se agregan filas
                else if (totales.Count > dgvTotalConsolidado.Rows.Count)
                {
                    for (int i = dgvTotalConsolidado.Rows.Count; i < totales.Count; i++)
                    {
                        dgvTotalConsolidado.Rows.Add();
                    }
                }
                //Se agrega la información en las filas
                for (int i = 0; i < totales.Count; i++)
                {
                    dgvTotalConsolidado.Rows[i].Cells[0].Value = totales[i].CodidoColor;
                    dgvTotalConsolidado.Rows[i].Cells[1].Value = totales[i].DescripcionColor.ToUpper();
                    dgvTotalConsolidado.Rows[i].Cells[2].Value = totales[i].Fondo;
                    dgvTotalConsolidado.Rows[i].Cells[3].Value = totales[i].DescripcionFondo.ToUpper();
                    dgvTotalConsolidado.Rows[i].Cells[4].Value = totales[i].Tiendas.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[5].Value = totales[i].Exito.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[6].Value = totales[i].Cencosud.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[7].Value = totales[i].Sao.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[8].Value = totales[i].ComercioOrg.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[9].Value = totales[i].Rosado.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[10].Value = totales[i].Otros.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[11].Value = totales[i].TotalUnidades.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[12].Value = totales[i].MCalculados.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[13].Value = totales[i].KgCalculados.ToString();
                }
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool validarValoresConsumo()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvInfoConsolidar.Rows)
            {
                if (row.Cells[12].Value == null || row.Cells[12].Value == "")
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        private bool validarValoresReserva() {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvInfoConsolidar.Rows)
            {
                if (row.Cells[14].Value == null || row.Cells[14].Value == "")
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        private bool validarTotalAPedir()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvTotalConsolidado.Rows)
            {
                if (row.Cells[14].Value == null || row.Cells[14].Value.ToString() == "")
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        private bool validarUnidadTotal()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvTotalConsolidado.Rows)
            {
                if (row.Cells[15].Value == null || row.Cells[15].Value.ToString() == "")
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        /// <summary>
        /// Agrega el consolidado a lista de solicitudes seleccionadas en la vista frmSolicitudListaTelas, al momento d e dar clic en Guardar.
        /// </summary>
        private void AgregarConsolidado()
        {
            int maxConsolidado = control.consultarMaxConsolidado();
            for (int i = 0; i < listaIdSolicitudes.Count; i++)
            {
                control.agregarConsolidado(listaIdSolicitudes[i], maxConsolidado + 1);
            }

        }

        private void cargar()
        {
            PedidoAMontar pedido = new PedidoAMontar();
            foreach (MontajeTelaDetalle solicitud in solicitudes)
            {
                pedido = control.getPedidoEstampado(solicitud.IdSolTela);
                if (pedido != null)
                {
                    idSolicitud = solicitud.IdSolTela;
                }
            }
            
            id = pedido.Id;
            if (id != 0)
            {
                txtNomTela.Text = pedido.Tela.ToString();
                txtDisenador.Text = pedido.Disenador.ToString();
                txtEnsayoRef.Text = pedido.EnsayoReferencia.ToString();
                txtDesPrenda.Text = pedido.DescripcionPrenda.ToString();
                cbxClase.Text = pedido.Clase.ToString();
                cbxTipoMarcacion.Text = pedido.TipoMarcacion.ToString();
                txtRendimiento.Text = pedido.Rendimiento.ToString();
                txtAnalista.Text = pedido.AnalistasCortesB.ToString();
                dtpFechaLlegada.Text = pedido.FechaLlegada.ToString();

                dgvInfoConsolidar.Rows.Clear();
                dgvTotalConsolidado.Rows.Clear();
                /* Carga Pedido */

                List<TomarDelPedido> listaPedido = control.getPedido(pedido.Id);
                if (listaPedido.Count > 0)
                {
                    foreach (TomarDelPedido obj in listaPedido)
                    {
                        dgvPedidos.Rows.Add(obj.NumeroPedido, obj.CodigoColor, obj.Estado, obj.Disponible);
                    }
                }
                /* Carga detalle Información a  Consolidar */
                List<PedidoMontarInformacion> listaInfoConsolidar = control.getPedidoEstampadoInformacion(pedido.Id);
                if (listaInfoConsolidar.Count > 0)
                {
                    foreach (PedidoMontarInformacion obj in listaInfoConsolidar)
                    {
                        dgvInfoConsolidar.Rows.Add(obj.CodigoColor, obj.DescripcionColor, obj.Fondo, obj.DescripcionFondo, 
                            obj.Tiendas, obj.Exito, obj.Cencosud, obj.Sao, obj.ComercioOrg, obj.Rosado, obj.Otros, 
                            obj.TotalUnidades, obj.Consumo, obj.MCalculados, obj.MReservados, obj.MSolicitar, obj.KgCalculados);
                    }
                }

                /* Carga detalle Toltal a  Consolidar */
                List<PedidoMontarTotal> listaTotalConsolidado = control.getPedidoEstampadoTotal(pedido.Id);
                if (listaTotalConsolidado.Count > 0)
                {
                    foreach (PedidoMontarTotal obj in listaTotalConsolidado)
                    {
                        dgvTotalConsolidado.Rows.Add(obj.CodidoColor, obj.DescripcionColor, obj.Fondo, obj.DescripcionFondo, 
                            obj.Tiendas, obj.Exito, obj.Cencosud, obj.Sao, obj.ComercioOrg, obj.Rosado, obj.Otros, 
                            obj.TotalUnidades, obj.MCalculados, obj.KgCalculados, obj.TotalPedir, obj.UnidadMedida);
                    }
                }
            }
        }

        private void guardarInformacion(int idPedido) {
            foreach (DataGridViewRow row in dgvInfoConsolidar.Rows) {
                PedidoMontarInformacion info = new PedidoMontarInformacion();
                info.IdPedidoAMontar = idPedido;
                info.CodigoColor = row.Cells[0].Value.ToString();
                info.DescripcionColor = row.Cells[1].Value.ToString();
                info.Fondo = row.Cells[2].Value.ToString();
                info.DescripcionFondo = row.Cells[3].Value.ToString();
                info.Tiendas = int.Parse(row.Cells[4].Value.ToString());
                info.Exito = int.Parse(row.Cells[5].Value.ToString());
                info.Cencosud = int.Parse(row.Cells[6].Value.ToString());
                info.Sao = int.Parse(row.Cells[7].Value.ToString());
                info.ComercioOrg = int.Parse(row.Cells[8].Value.ToString());
                info.Rosado = int.Parse(row.Cells[9].Value.ToString());
                info.Otros = int.Parse(row.Cells[10].Value.ToString());
                info.TotalUnidades = int.Parse(row.Cells[11].Value.ToString());
                info.Consumo = decimal.Parse(row.Cells[12].Value.ToString());
                info.MCalculados = decimal.Parse(row.Cells[13].Value.ToString());
                info.MReservados = decimal.Parse(row.Cells[14].Value.ToString());
                info.MSolicitar = decimal.Parse(row.Cells[15].Value.ToString());
                info.KgCalculados = decimal.Parse(row.Cells[16].Value.ToString());
                control.addPedidoEstampadoInformacion(info);
            }
        }

        private void guardarTotal(int idPedido)
        {
            foreach (DataGridViewRow row in dgvTotalConsolidado.Rows)
            {
                PedidoMontarTotal total = new PedidoMontarTotal();
                total.IdPedidoAmontar = idPedido;
                total.CodidoColor = row.Cells[0].Value.ToString();
                total.DescripcionColor = row.Cells[1].Value.ToString();
                total.Fondo = row.Cells[2].Value.ToString();
                total.DescripcionFondo = row.Cells[3].Value.ToString();
                total.Tiendas = int.Parse(row.Cells[4].Value.ToString());
                total.Exito = int.Parse(row.Cells[5].Value.ToString());
                total.Cencosud = int.Parse(row.Cells[6].Value.ToString());
                total.Sao = int.Parse(row.Cells[7].Value.ToString());
                total.ComercioOrg = int.Parse(row.Cells[8].Value.ToString());
                total.Rosado = int.Parse(row.Cells[9].Value.ToString());
                total.Otros = int.Parse(row.Cells[10].Value.ToString());
                total.TotalUnidades = int.Parse(row.Cells[11].Value.ToString());
                total.MCalculados = decimal.Parse(row.Cells[12].Value.ToString());
                total.KgCalculados = decimal.Parse(row.Cells[13].Value.ToString());
                total.TotalPedir = decimal.Parse(row.Cells[14].Value.ToString());
                total.UnidadMedida = row.Cells[15].Value.ToString();
                control.addPedidoEstampadoTotal(total);
            }
        }

        private void guardarPedido(int id)
        {
            for (int i = 0; i < dgvPedidos.RowCount; i++)
            {
                TomarDelPedido pedido = new TomarDelPedido();
                pedido.IdPedidoMontar = id;
                pedido.NumeroPedido = (dgvPedidos.Rows[i].Cells[0].Value.ToString());
                pedido.CodigoColor = (dgvPedidos.Rows[i].Cells[1].Value != null && dgvPedidos.Rows[i].Cells[1].Value.ToString() != "") ? int.Parse(dgvPedidos.Rows[i].Cells[1].Value.ToString()) : 0;
                pedido.Estado = (dgvPedidos.Rows[i].Cells[2].Value != null && dgvPedidos.Rows[i].Cells[2].Value.ToString() != "") ? dgvPedidos.Rows[i].Cells[2].Value.ToString() : "";
                pedido.Disponible = (dgvPedidos.Rows[i].Cells[3].Value != null && dgvPedidos.Rows[i].Cells[3].Value.ToString() != "") ? decimal.Parse(dgvPedidos.Rows[i].Cells[3].Value.ToString()) : 0;
                pedido.TipoPedido = "ESTAMPADO";
                control.addPedido(pedido);
            }
        }

        private decimal calcularMCalculados(decimal consumo, int totalUnidades) {
            return decimal.Round(consumo * totalUnidades * decimal.Parse("1.10"), 2);
        }

        private decimal calcularMSolicitar(decimal mCalculados, decimal mReservados)
        {
            return decimal.Round(mCalculados - mReservados, 2);
        }

        private decimal calcularKgCalculados(decimal mSolicitar, decimal rendimiento)
        {
            return decimal.Round(mSolicitar / rendimiento, 2);
        }

        #endregion
    }
}
