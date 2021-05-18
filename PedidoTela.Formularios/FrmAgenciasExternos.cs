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
    public partial class frmAgenciasExternos : MaterialSkin.Controls.MaterialForm
    {
        #region Variables
        Controlador control = new Controlador();
        Validar validacion = new Validar();
        Utilidades utilidades = new Utilidades();
        List<int> listaIdSolicitudes = new List<int>();
        int idsolTela, id;
        bool bandera = false;   
        List<MontajeTelaDetalle> detalleSeleccionado = new List<MontajeTelaDetalle>();
        #endregion

        #region Getter && Setter
        public List<MontajeTelaDetalle> DetalleSeleccionado { get => detalleSeleccionado; set => detalleSeleccionado = value; }
        public int IdsolTela { get => idsolTela; set => idsolTela = value; }
        public List<int> ListaIdSolicitudes { get => listaIdSolicitudes; set => listaIdSolicitudes = value; }
        #endregion

        #region Constructor
        public frmAgenciasExternos(Controlador controlador, List<MontajeTelaDetalle> listaSeleccionada, int numFilasSelccionadas, int idSolicitudTelas)
        {
            InitializeComponent();
            DetalleSeleccionado = listaSeleccionada;
            control = controlador;
            dtpFechaLlegada.Format = DateTimePickerFormat.Custom;
            dtpFechaLlegada.CustomFormat = "dd/MM/yyyy";
            IdsolTela = idSolicitudTelas;
           
        }
        #endregion

        #region Método inicial de Carga
        private void FrmAgenciasExternos_Load(object sender, EventArgs e)
        {
            Cargarsolicitudes(DetalleSeleccionado);
            cargarCombobox(cbxComposicion, control.getComposicion());
            Iniciar(DetalleSeleccionado);
            txtCargo.Text = "Analista";
            txtDepartamento.Text = "Cortes B";
            txtTelefono.Text = "4055252";

            txtProveedor.MaxLength = 20;
            txtNit.MaxLength = 12;
            txtContacto.MaxLength = 20;
            txtOrdenCompra.MaxLength = 12;

            #region TooTipText
            dgvInfoConsolidar.Columns["descripColor"].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInfoConsolidar.Columns["codColor"].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInfoConsolidar.Columns["mCalculados"].HeaderCell.ToolTipText = "(Consumo * Total Unidades)*1.10";
            dgvInfoConsolidar.Columns["maSolicitar"].HeaderCell.ToolTipText = "M calculados -  M reservados";
            dgvInfoConsolidar.Columns["kgCalculado"].HeaderCell.ToolTipText = "M a solicitar / Rendimiento";

            dgvTotalConsolidado.Columns["mC"].HeaderCell.ToolTipText = "(Consumo * Total Unidades)*1.10";
             dgvTotalConsolidado.Columns["kgCalculados"].HeaderCell.ToolTipText = "(M a solicitar /Rendimiento)";

            #endregion
        }
        #endregion

        #region Eventos
        private void txtAnchoTela_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.validarDecimal(sender, e);
        }

        private void txtExtencion_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }
        
        private void txtRendimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtRendimiento.Text.Trim() != "")
            {
                validacion.validarDecimal(sender, e);
            }
        }

        private void txtProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtOrdenCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtDesPrenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtPedidoAgencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void txtRendimiento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dgvInfoConsolidar.RowCount; i++)
                {
                    if (txtRendimiento.Text.Trim() != "")
                    {
                        if (dgvInfoConsolidar.Rows[i].Cells[13].Value != null && dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString() != "")
                        {
                            decimal mSolicitar = decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString());
                            decimal rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
                            dgvInfoConsolidar.Rows[i].Cells[14].Value = utilidades.calcularKgCalculados(mSolicitar, rendimiento);
                        }
                    }
                    else
                    {
                        dgvInfoConsolidar.Rows[i].Cells[14].Value = 0;
                    }
                }

                calcularTotalesPorColores();
            }
            catch
            {
                txtRendimiento.Text = "";
            }
        }

        private void dgvInfoConsolidar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 1 && e.ColumnIndex < 10 || e.ColumnIndex == 11 || e.ColumnIndex >= 13)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }

        private void dgvTotalConsolidado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex <= 11)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }

        private void dgvInfoConsolidar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvInfoConsolidar.CurrentRow.Cells[2].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[3].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[4].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[5].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[6].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[7].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[8].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[9].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[11].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[13].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[14].ReadOnly = true;

            if (dgvInfoConsolidar.Columns[e.ColumnIndex].Name == "codColor" || dgvInfoConsolidar.Columns[e.ColumnIndex].Name == "descripColor")
            {
                frmBuscarColor buscarColor = new frmBuscarColor(control);
                buscarColor.StartPosition = FormStartPosition.CenterScreen;
                if (buscarColor.ShowDialog() == DialogResult.OK)
                {
                    Objeto obj = buscarColor.Elemento;
                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[0].Value = obj.Id;
                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[1].Value = obj.Nombre;
                }

            }
            calcularTotalesPorColores();
        }

        private void dgvTotalConsolidado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i <= 11; i++)
            {
                dgvTotalConsolidado.CurrentRow.Cells[i].ReadOnly = true;
            }
        }

        private void dgvInfoConsolidar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10) //Cuando cambia el consumo [10] cambia M Calculados [11] y KG Calculados[14]
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
                            int totalUnidades = int.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[9].Value.ToString());
                            dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value = utilidades.calcularMCalculados(consumo, totalUnidades);


                            // cuando cambia M Calculados [11] se actualiza M Solicitar [13]
                            if (dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value != null && dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value.ToString().Trim() != "")
                            {
                                decimal mCalculados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value.ToString());

                                if (dgvInfoConsolidar.Rows[e.RowIndex].Cells[12].Value != null && dgvInfoConsolidar.Rows[e.RowIndex].Cells[12].Value.ToString() != "")
                                {
                                    decimal mReservados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[12].Value.ToString());
                                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = utilidades.calcularMSolicitar(mCalculados, mReservados);
                                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[14].Value = decimal.Round(decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value.ToString()) / decimal.Parse(txtRendimiento.Text), 2);

                                }
                                else
                                {
                                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = mCalculados;
                                }
                            }
                            else
                            {
                                dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = "";
                            }

                        }
                    }
                    else
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[14].Value = "";
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value = "";
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = "";
                    }
                }
                catch 
                {
                    dgvInfoConsolidar.CurrentCell.Value = "";
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else if (e.ColumnIndex == 11) // cuando cambia M Calculados [11] se actualiza M Solicitar [13]
            {
                if (dgvInfoConsolidar.CurrentCell.Value != null && dgvInfoConsolidar.CurrentCell.Value.ToString().Trim() != "")
                {
                    decimal mCalculados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value.ToString());

                    if (dgvInfoConsolidar.Rows[e.RowIndex].Cells[12].Value != null && dgvInfoConsolidar.Rows[e.RowIndex].Cells[12].Value.ToString() != "")
                    {
                        decimal mReservados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[12].Value.ToString());
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = utilidades.calcularMSolicitar(mCalculados, mReservados);
                    }
                    else
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = mCalculados;
                    }
                }
                else
                {
                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = "";
                }
            }

            else if (e.ColumnIndex == 12) // cuando cambia M Reservados [12] cambia el M Solicitar [13]
            {
                try
                {
                    if (dgvInfoConsolidar.CurrentCell.Value != null && dgvInfoConsolidar.CurrentCell.Value.ToString().Trim() != "")
                    {
                        if (dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value != null && dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value.ToString() != "")
                        {
                            decimal mReservados = decimal.Parse(dgvInfoConsolidar.CurrentCell.Value.ToString());
                            decimal mCalculados = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value.ToString());
                            if (mCalculados >= mReservados)
                            {
                                decimal mSolicitar = utilidades.calcularMSolicitar(mCalculados, mReservados); ;
                                dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = mSolicitar;

                                if (txtRendimiento.Text.Trim() != "")
                                {
                                    decimal rendimiento = decimal.Parse(txtRendimiento.Text);
                                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[14].Value = decimal.Round(mSolicitar / rendimiento, 2);
                                }
                            }
                            else
                            {
                                dgvInfoConsolidar.CurrentCell.Value = "";
                                MessageBox.Show("M Reservados no puede ser mayor a M Calculados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            dgvInfoConsolidar.CurrentCell.Value = "";
                            MessageBox.Show("Por favor ingrese el consumo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value;
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[14].Value = decimal.Round(decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value.ToString()) / decimal.Parse(txtRendimiento.Text), 2);

                    }
                }
                catch 
                {
                    dgvInfoConsolidar.CurrentCell.Value = "";
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            calcularTotalesPorColores();
        }

        private void dgvTotalConsolidado_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                try
                {
                    if (dgvTotalConsolidado.CurrentCell.Value != null && dgvTotalConsolidado.CurrentCell.Value.ToString().Trim() != "")
                    {
                        decimal valor = decimal.Parse(dgvTotalConsolidado.CurrentCell.Value.ToString());
                        decimal vfinal = Decimal.Round(valor, 2);
                        dgvTotalConsolidado.CurrentCell.Value = valor;
                    }
                }
                catch (Exception ex)
                {
                    dgvTotalConsolidado.CurrentCell.Value = "";
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
       
        /// <summary>
        /// Guarda la infromación de la vista (frmAgenciasExternos) en la BD, las entidades son: spt_agencias_externos, cfc_spt_agen_infoconsolidar  y cfc_spt_agen_totalconsolidar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (cbxComposicion.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un valor para Composición.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtExtencion.Text != "")
                {
                    if (txtAnchoTela.Text != "")
                    {
                        if (txtRendimiento.Text != "")
                        {
                            if (txtProveedor.Text != "")
                            {
                                if (txtNit.Text != "")
                                {
                                    if (txtContacto.Text != "")
                                    {
                                        if (txtPedidoAgencia.Text != "")
                                        {
                                            if (dgvInfoConsolidar.RowCount > 0 && dgvTotalConsolidado.RowCount > 0)
                                            {
                                                if (!validarValoresConsumo())
                                                {
                                                    if (!validarValoresReserva())
                                                    {
                                                        if (!validarTotalAPedir())
                                                        {
                                                            if (!validarUnidadTotal())                                                            {
               
                                                                AgenciasExternos elemento = ObtenerEncabezado();

                                                                if (control.ExisteAgenciasExterno(IdsolTela))
                                                                {
                                                                    control.ActualizarAgenciasExterno(elemento);
                                                                }
                                                                else
                                                                {
                                                                    control.addAgenciaExterno(elemento);
                                                                }
                                                                id = control.getIdAgenciasExterno(IdsolTela);

                                                                if (id != 0)
                                                                {
                                                                    control.eliminarAgenciasExternoInformacion(id);
                                                                    control.eliminarAgenciasExternoTotal(id);

                                                                    GuardarTotalConsolidar(id);
                                                                    GuardarInformacionConsolidar(id);
                                                                }
                                                                AgregarConsolidado();
                                                                MessageBox.Show("Agencias-Externos se guardó con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                                
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
                                            else
                                            {
                                                MessageBox.Show("Por favor, adicione al menos un color.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Por favor, ingrese un valor para Pedido Agencia.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Por favor, ingrese un valor para Contacto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Por favor, ingrese un valor para Nit.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Por favor, ingrese un valor para Proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, ingrese un valor para Rendimiento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, ingrese un valor para Ancho de tela.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese el valor para la Extención.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        /// <summary>
        /// Actualiza las solicitudes seleccionadas a un  nuevo estado => (Solicitud de Inventario)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Se asignar valores para la fecha. 
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            // El estado que se le debe dar a solicitud cuando es confirmada

            string estado = "Solicitud de Inventario";

            if (id != 0)
            {
                for (int i = 0; i < ListaIdSolicitudes.Count; i++)
                {
                    control.actualizarEstado(ListaIdSolicitudes[i], estado, fechaActual);
                }
            
                MessageBox.Show("La información se guardó con éxito. \n El estado se actualizó a Solicitud de Inventario.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                // Deshabilita los diferentes botones y demás contenido del formulario que se quiere que no sea modificado una vez se confirme la solicitud.
                btnConfirmar.Enabled = false;
                btnGrabar.Enabled = false;

                dgvInfoConsolidar.ReadOnly = true;
                dgvTotalConsolidado.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Por favor, Grabe la Información.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
       
        /// <summary>
        ///  El sistema genera el siguiente formato Solicitud de Número de Pedido.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>   
        private void btnImprimirSIP_Click(object sender, EventArgs e)
        {
            AgenciasExternos objAgencias = control.getAgenciasExterno(IdsolTela);
            if(objAgencias.IdAgencias != 0)
            {
                frmImprimirSIP imprimir = new frmImprimirSIP(control, IdsolTela);
                imprimir.ShowDialog();
            }
            else
            {
                MessageBox.Show("Agencias Externos no ha sido guardada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Cierra el formulario actual.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Permite cargar una lista con todos los id_solicitud seleccionados.
        /// </summary>
        /// <param name="prmLista">Lista de tipo MontajeTelaDetalle, la cual representa las filas seleccionadas en el vista  inicial de filtros (frmSolicitudListaTelas).</param>
        private void Cargarsolicitudes(List<MontajeTelaDetalle> prmLista)
        {
            List<int> listaSolicitudes = new List<int>();
            for (int i = 0; i < prmLista.Count; i++)
            {
                listaSolicitudes.Add(prmLista[i].IdSolTela);
            }
            ListaIdSolicitudes = listaSolicitudes.Distinct().ToList();
        }


        /// <summary>
        /// Busca la información en las respectivas entidades si encuentra dastos los carga y la bandera el True, de lo contrario la bandera es False y se procede a 
        /// cargar la vista con la información que se ha seleccionado de la vista anterior.
        /// </summary>
        /// <param name="prmLista"> Lista de tipo MontajeTelaDetalle, representa las filas seleccionadas en el vista  inicial de filtros (frmSolicitudListaTelas). </param>
        public void Iniciar(List<MontajeTelaDetalle> prmLista)
        {    
            Cargar();
            // Bandera controlada en el método Cargar()
            if (!this.bandera)
            {
                //Carga el DataGridView (dgvInfoConsolidar) el cual pertenece a la sección de información a consolidar.
                cargarDgvInfoConsolidar(prmLista);
                //Carga el DataGridView (dgvTotalConsolidado) el cual pertenece a la sección de total consolidado.
                cargarDgvTotalConsolidar(prmLista);
            }
               
        }

        /// <summary>
        /// Carga el DataGridView (dgvInfoConsolidar) con la información solicitada.
        /// </summary>
        /// <param name="prmLista">Lista de tipo DetalleLista contiene la informacion a cargar en el DatagridView.</param>
        private void cargarDgvInfoConsolidar(List<MontajeTelaDetalle> prmLista)
        {
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {

                    dgvInfoConsolidar.Rows.Add(prmLista[i].Vte.ToString(),
                    prmLista[i].DesColor.ToString(),
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
                    txtSolicitadoPor.Text =DetalleSeleccionado[i].Disenador.ToString();
                    txtEnsayoRef.Text += prmLista[i].RefSimilar.ToString() + "\n";
                    txtDesPrenda.Text = prmLista[i].DescPrenda.ToString();               
                }
                    txtNomTela.Text = prmLista[0].DesTela.ToString();
                    txtDisenadora.Text = prmLista[0].Disenador.ToString();
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Carga el DataGridView (dgvToltalConsolidar) con la información solicitada.
        /// </summary>
        /// <param name="prmLista">Lista de tipo DetalleLista contiene la informacion a cargar en el DatagridView.</param>
        private void cargarDgvTotalConsolidar(List<MontajeTelaDetalle> prmLista)
        {
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {

                    dgvTotalConsolidado.Rows.Add(prmLista[i].Vte.ToString(),
                    prmLista[i].DesColor.ToString(),
                    prmLista[i].Tiendas.ToString(),
                    prmLista[i].Exito.ToString(),
                    prmLista[i].Cencosud.ToString(),
                    prmLista[i].Sao.ToString(),
                    prmLista[i].Comercio.ToString(),
                    prmLista[i].Rosado.ToString(),
                    prmLista[i].Otros.ToString(),
                    prmLista[i].TotaUnidades.ToString(),
                    prmLista[i].Masolicitar.ToString()
                    );
                    
                }
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        /// <summary>
        /// Permite realizar la carga de los datos para el ComboBox (cbxComposicion).
        /// </summary>
        /// <param name="prmLista">Lista de tipo Objeto,la cual tiene los datos para Composicion.</param>
        private void cargarCombobox(ComboBox prmCombo, List<Objeto> prmLista)
        {
            prmCombo.DataSource = prmLista;
            prmCombo.DisplayMember = "Nombre";
            prmCombo.ValueMember = "Id";
            prmCombo.SelectedIndex = -1;
            prmCombo.AutoCompleteCustomSource = cargarCombobox(prmLista);
            prmCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            prmCombo.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        /// <summary>
        /// Permite el autocompletado de los comboBox mostrados en la vista.
        /// </summary>
        /// <param name="prmLista">Lista de tipo objeto la cual es autocompletada.</param>
        /// <returns></returns>
        private AutoCompleteStringCollection cargarCombobox(List<Objeto> prmLista)
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            foreach (Objeto obj in prmLista)
            {
                datos.Add(obj.Nombre);
            }
            return datos;
        }

        /// <summary>
        /// Obtine la información correspondiente al encabezado de la vista.
        /// </summary>
        /// <returns>Retorna un objeto de Tipo AgenciasExternos, representa la información del encabezado.</returns>
        private AgenciasExternos ObtenerEncabezado()
        {
            AgenciasExternos elemento = new AgenciasExternos();
            elemento.SolicitadoPor = txtSolicitadoPor.Text.Trim();
            elemento.NombreTela = txtNomTela.Text.Trim();
            elemento.Disenadora = txtDisenadora.Text.Trim();
            elemento.Cargo = txtCargo.Text.Trim();
            elemento.Telefono = txtTelefono.Text.Trim();
            elemento.EnsayoRef = txtEnsayoRef.Text.Trim();
            elemento.Departamento = txtDepartamento.Text.Trim();
            elemento.AnchoTela = decimal.Parse(txtAnchoTela.Text.Trim());
            elemento.Proveedor = txtProveedor.Text.Trim();
            elemento.OrdenCompra = txtOrdenCompra.Text.Trim();
            elemento.Extencion = txtExtencion.Text.Trim();
            elemento.DescPrenda = txtDesPrenda.Text.Trim();
            elemento.Rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
            elemento.Contacto = txtContacto.Text.Trim();
            elemento.PedidoAgencia = txtPedidoAgencia.Text.Trim();
            elemento.Composicion = cbxComposicion.GetItemText(cbxComposicion.SelectedItem);
            elemento.Nit = txtNit.Text.Trim();
            string fecha = dtpFechaLlegada.Value.ToString("dd/MM/yyyy");
            elemento.FechaLlegadaTela = fecha;
            elemento.IdSolTela = IdsolTela;
            return elemento;
        }

        /// <summary>
        /// Guarda la información correspondiente al primer DtaGridView presente en la vista
        /// </summary>
        /// <param name="id">Id de Agencias Externos.</param>
        private void GuardarInformacionConsolidar(int id)
        {
            for (int i = 0; i < dgvInfoConsolidar.RowCount; i++)
            {

                AgenciasInfoConsolidar detalle = new AgenciasInfoConsolidar();
                detalle.IdAgencias = id;
                detalle.CodColor = (dgvInfoConsolidar.Rows[i].Cells[0].Value.ToString());
                detalle.DesColor = (dgvInfoConsolidar.Rows[i].Cells[1].Value != null && dgvInfoConsolidar.Rows[i].Cells[1].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[1].Value.ToString() : "";
                detalle.Tiendas = (dgvInfoConsolidar.Rows[i].Cells[2].Value != null && dgvInfoConsolidar.Rows[i].Cells[2].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[2].Value.ToString()) : 0;
                detalle.Exito = (dgvInfoConsolidar.Rows[i].Cells[3].Value != null && dgvInfoConsolidar.Rows[i].Cells[3].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[3].Value.ToString()) : 0;
                detalle.Cencosud = (dgvInfoConsolidar.Rows[i].Cells[4].Value != null && dgvInfoConsolidar.Rows[i].Cells[4].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[4].Value.ToString()) : 0;
                detalle.Sao = (dgvInfoConsolidar.Rows[i].Cells[5].Value != null && dgvInfoConsolidar.Rows[i].Cells[5].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[5].Value.ToString()) : 0;
                detalle.ComercioOrg = (dgvInfoConsolidar.Rows[i].Cells[6].Value != null && dgvInfoConsolidar.Rows[i].Cells[6].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[6].Value.ToString()) : 0;
                detalle.Rosado = (dgvInfoConsolidar.Rows[i].Cells[7].Value != null && dgvInfoConsolidar.Rows[i].Cells[7].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[7].Value.ToString()) : 0;
                detalle.Otros = (dgvInfoConsolidar.Rows[i].Cells[8].Value != null && dgvInfoConsolidar.Rows[i].Cells[8].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[8].Value.ToString()) : 0;
                detalle.TotalUnidades = (dgvInfoConsolidar.Rows[i].Cells[9].Value != null && dgvInfoConsolidar.Rows[i].Cells[9].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[9].Value.ToString()) : 0;
                detalle.Consumo = (dgvInfoConsolidar.Rows[i].Cells[10].Value != null && dgvInfoConsolidar.Rows[i].Cells[10].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[10].Value.ToString()) : 0;
                detalle.MCalculados = (dgvInfoConsolidar.Rows[i].Cells[11].Value != null && dgvInfoConsolidar.Rows[i].Cells[11].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[11].Value.ToString()) : 0;
                detalle.MReservados = (dgvInfoConsolidar.Rows[i].Cells[12].Value != null && dgvInfoConsolidar.Rows[i].Cells[12].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[12].Value.ToString()) : 0;
                detalle.MaSolicitar = (dgvInfoConsolidar.Rows[i].Cells[13].Value != null && dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString()) : 0;
                detalle.KgCalculados = (dgvInfoConsolidar.Rows[i].Cells[14].Value != null && dgvInfoConsolidar.Rows[i].Cells[14].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[14].Value.ToString()) : 0;
                control.addInfoConsolidar(detalle);
            }
        }

        /// <summary>
        /// Guarda la información correspondiente al segundo DtaGridView presente en la vista
        /// </summary>
        /// <param name="id">Id de Agencias Externos.</param>
        private void GuardarTotalConsolidar(int id)
        {
            for (int i = 0; i < dgvTotalConsolidado.RowCount; i++)
            {
                AgenciaTotalConsolidar detalle = new AgenciaTotalConsolidar();
                detalle.IdAgencias = id;
                detalle.CodColor = (dgvTotalConsolidado.Rows[i].Cells[0].Value.ToString());
                detalle.DesColor = (dgvTotalConsolidado.Rows[i].Cells[1].Value != null && dgvTotalConsolidado.Rows[i].Cells[1].Value.ToString() != "") ? dgvTotalConsolidado.Rows[i].Cells[1].Value.ToString() : "";
                detalle.Tiendas = (dgvTotalConsolidado.Rows[i].Cells[2].Value != null && dgvTotalConsolidado.Rows[i].Cells[2].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[2].Value.ToString()) : 0;
                detalle.Exito = (dgvTotalConsolidado.Rows[i].Cells[3].Value != null && dgvTotalConsolidado.Rows[i].Cells[3].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[3].Value.ToString()) : 0;
                detalle.Cencosud = (dgvTotalConsolidado.Rows[i].Cells[4].Value != null && dgvTotalConsolidado.Rows[i].Cells[4].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[4].Value.ToString()) : 0;
                detalle.Sao = (dgvTotalConsolidado.Rows[i].Cells[5].Value != null && dgvTotalConsolidado.Rows[i].Cells[5].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[5].Value.ToString()) : 0;
                detalle.ComercioOrg = (dgvTotalConsolidado.Rows[i].Cells[6].Value != null && dgvTotalConsolidado.Rows[i].Cells[6].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[6].Value.ToString()) : 0;
                detalle.Rosado = (dgvTotalConsolidado.Rows[i].Cells[7].Value != null && dgvTotalConsolidado.Rows[i].Cells[7].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[7].Value.ToString()) : 0;
                detalle.Otros = (dgvTotalConsolidado.Rows[i].Cells[8].Value != null && dgvTotalConsolidado.Rows[i].Cells[8].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[8].Value.ToString()) : 0;
                detalle.TotalUnidades = (dgvTotalConsolidado.Rows[i].Cells[9].Value != null && dgvTotalConsolidado.Rows[i].Cells[9].Value.ToString() != "") ? int.Parse(dgvTotalConsolidado.Rows[i].Cells[9].Value.ToString()) : 0;
                detalle.MCalculados = (dgvTotalConsolidado.Rows[i].Cells[10].Value != null && dgvTotalConsolidado.Rows[i].Cells[10].Value.ToString() != "") ? decimal.Parse(dgvTotalConsolidado.Rows[i].Cells[10].Value.ToString()) : 0;
                detalle.KgCalculados = (dgvTotalConsolidado.Rows[i].Cells[11].Value != null && dgvTotalConsolidado.Rows[i].Cells[11].Value.ToString() != "") ? decimal.Parse(dgvTotalConsolidado.Rows[i].Cells[11].Value.ToString()) : 0;
                detalle.TotalaPedir = (dgvTotalConsolidado.Rows[i].Cells[12].Value != null && dgvTotalConsolidado.Rows[i].Cells[12].Value.ToString() != "") ? decimal.Parse(dgvTotalConsolidado.Rows[i].Cells[12].Value.ToString()) : 0;
                detalle.UniMedidaTela = (dgvTotalConsolidado.Rows[i].Cells[13].Value != null && dgvTotalConsolidado.Rows[i].Cells[13].Value.ToString() != "") ? dgvTotalConsolidado.Rows[i].Cells[13].Value.ToString() : "";
                control.addTotalConsolidar(detalle);
            }
        }

        /// <summary>
        /// Calcula y edita algunos de los campos de los dataGridView de la vista según los colores cargados. 
        /// </summary>
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
                        objColor.Tiendas += (dgvInfoConsolidar.Rows[i].Cells[2].Value != null && dgvInfoConsolidar.Rows[i].Cells[2].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[2].Value.ToString()) : 0;
                        objColor.Exito += (dgvInfoConsolidar.Rows[i].Cells[3].Value != null && dgvInfoConsolidar.Rows[i].Cells[3].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[3].Value.ToString()) : 0;
                        objColor.Cencosud += (dgvInfoConsolidar.Rows[i].Cells[4].Value != null && dgvInfoConsolidar.Rows[i].Cells[4].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[4].Value.ToString()) : 0;
                        objColor.Sao += (dgvInfoConsolidar.Rows[i].Cells[5].Value != null && dgvInfoConsolidar.Rows[i].Cells[5].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[5].Value.ToString()) : 0;
                        objColor.ComercioOrg += (dgvInfoConsolidar.Rows[i].Cells[6].Value != null && dgvInfoConsolidar.Rows[i].Cells[6].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[6].Value.ToString()) : 0;
                        objColor.Rosado += (dgvInfoConsolidar.Rows[i].Cells[7].Value != null && dgvInfoConsolidar.Rows[i].Cells[7].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[7].Value.ToString()) : 0;
                        objColor.Otros += (dgvInfoConsolidar.Rows[i].Cells[8].Value != null && dgvInfoConsolidar.Rows[i].Cells[8].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[8].Value.ToString()) : 0;
                        objColor.TotalUnidades += (dgvInfoConsolidar.Rows[i].Cells[9].Value != null && dgvInfoConsolidar.Rows[i].Cells[9].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[9].Value.ToString()) : 0;
                        objColor.MCalculados += (dgvInfoConsolidar.Rows[i].Cells[13].Value != null && dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString()) : 0;
                        objColor.KgCalculados += (dgvInfoConsolidar.Rows[i].Cells[14].Value != null && dgvInfoConsolidar.Rows[i].Cells[14].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[14].Value.ToString()) : 0;
                    }
                }
                totales.Add(objColor);
            }

            if (totales.Count != 0)
            {
                //Si hay más filas en total consolidado que colores se eliminan filas
                if (totales.Count < dgvTotalConsolidado.Rows.Count)
                {
                    for (int i = totales.Count; i < dgvTotalConsolidado.Rows.Count; i++)
                    {
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
                    dgvTotalConsolidado.Rows[i].Cells[2].Value = totales[i].Tiendas.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[3].Value = totales[i].Exito.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[4].Value = totales[i].Cencosud.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[5].Value = totales[i].Sao.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[6].Value = totales[i].ComercioOrg.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[7].Value = totales[i].Rosado.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[8].Value = totales[i].Otros.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[9].Value = totales[i].TotalUnidades.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[10].Value = totales[i].MCalculados.ToString();
                    dgvTotalConsolidado.Rows[i].Cells[11].Value = totales[i].KgCalculados.ToString();
                }
            }
        }

        /// <summary>
        /// Válida el estado del campo consumo del DatgridView (dgvInfoConsolidar) no se encuentre vacío.
        /// </summary>
        /// <returns>Retorna True si el campo está vacío, False de contrario.</returns>
        private bool validarValoresConsumo()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvInfoConsolidar.Rows)
            {
                if (row.Cells[10].Value == null || row.Cells[10].Value.ToString() == "")
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        /// <summary>
        /// Válida el estado del campo M resevar del DataGridView (dgvInfoConsolidar).
        /// </summary>
        /// <returns>Retorn True si el campo está vacío, False de lo contrario.</returns>
        private bool validarValoresReserva()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvInfoConsolidar.Rows)
            {
                if (row.Cells[12].Value == null || row.Cells[12].Value.ToString() == "")
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        /// <summary>
        /// Válida el estado del campo Total a Pedir del DatagridView (dgvTotalConsolidado).
        /// </summary>
        /// <returns>Retorna True si el campo está vacío, False de lo contrario.</returns>
        private bool validarTotalAPedir()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvTotalConsolidado.Rows)
            {
                if (row.Cells[12].Value == null || row.Cells[12].Value.ToString() == "")
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        /// <summary>
        /// Válida el estado del campo Unidad de medida de tela del DataGridView (dgvTotalConsolidado)
        /// </summary>
        /// <returns></returns>
        private bool validarUnidadTotal()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvTotalConsolidado.Rows)
            {
                if (row.Cells[13].Value == null || row.Cells[13].Value.ToString() == "")
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        /// <summary>
        /// Agrega el consolidado a lista de solicitudes seleccionadas en la vista frmSolicitudListaTelas, al momento de dar clic en Guardar.
        /// </summary>
        private void AgregarConsolidado()
        {
            int maxConsolidado = control.consultarMaxConsolidado();
            for (int i = 0; i < ListaIdSolicitudes.Count; i++)
            {
                control.agregarConsolidado(ListaIdSolicitudes[i], maxConsolidado + 1);
            }

        }

        /// <summary>
        /// Realiza el cargue inicial de los datos para la vista (frmAgenciasExternos).
        /// </summary>   
        private void Cargar()
        {
            AgenciasExternos objAgencias = control.getAgenciasExterno(IdsolTela);
            id = objAgencias.IdAgencias;
            if (id != 0)
            {
                txtSolicitadoPor.Text = objAgencias.Disenadora.ToString();
                txtNomTela.Text = objAgencias.NombreTela.ToString();
                txtDisenadora.Text = objAgencias.Disenadora.ToString();
                txtCargo.Text = objAgencias.Cargo.ToString();
                txtTelefono.Text = objAgencias.Telefono.ToString();
                txtEnsayoRef.Text = objAgencias.EnsayoRef.ToString();
                txtDepartamento.Text = objAgencias.Departamento.ToString();
                txtAnchoTela.Text = objAgencias.AnchoTela.ToString();
                txtProveedor.Text = objAgencias.Proveedor.ToString();
                txtOrdenCompra.Text = objAgencias.OrdenCompra.ToString();
                txtExtencion.Text = objAgencias.Extencion.ToString();
                txtDesPrenda.Text = objAgencias.DescPrenda.ToString();
                txtRendimiento.Text = objAgencias.Rendimiento.ToString();
                txtContacto.Text = objAgencias.Contacto.ToString();
                txtPedidoAgencia.Text = objAgencias.PedidoAgencia.ToString();
                cbxComposicion.Text = objAgencias.Composicion;
                txtNit.Text = objAgencias.Nit.ToString();
                dtpFechaLlegada.Text = objAgencias.FechaLlegadaTela.ToString();

            /*Carga detalle Información a  Consolidar*/
            List<AgenciasInfoConsolidar> listaInfoConsolidar = control.getInfoConsolidar(objAgencias.IdAgencias);
            if (listaInfoConsolidar.Count > 0)
            {
                foreach (AgenciasInfoConsolidar obj in listaInfoConsolidar)
                {
                    dgvInfoConsolidar.Rows.Add(obj.CodColor, obj.DesColor, obj.Tiendas, obj.Exito,
                        obj.Cencosud, obj.Sao, obj.ComercioOrg, obj.Rosado, obj.Otros, obj.TotalUnidades, obj.Consumo, obj.MCalculados, obj.MReservados, obj.MaSolicitar,obj.KgCalculados);
                }
            }

            /*Carga detalle Toltal a  Consolidar*/
            List<AgenciaTotalConsolidar> listaTotalConsolidado = control.getTotalConsolidado(objAgencias.IdAgencias);
            if (listaTotalConsolidado.Count > 0)
            {
                foreach (AgenciaTotalConsolidar obj in listaTotalConsolidado)
                {
                    dgvTotalConsolidado.Rows.Add(obj.CodColor, obj.DesColor, obj.Tiendas, obj.Exito,
                        obj.Cencosud, obj.Sao, obj.ComercioOrg, obj.Rosado, obj.Otros, obj.TotalUnidades, obj.MCalculados, obj.KgCalculados, obj.TotalaPedir, obj.UniMedidaTela);
                }
            }

            /*Esta bandera controla el cargue los dataGridView, es decir, si es true, en método  cargarDgvInfoConsolidar(prmLista) y cargarDgvTotalConsolidar(prmLista),
             * no se ejecutan, debido a que la información ya esta guardada en la BD. */
            this.bandera = true;
              
            }
        }
        #endregion
    }
}
