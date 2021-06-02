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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidoTela.Formularios
{
    public partial class frmSolicitudListaTelas : MaterialSkin.Controls.MaterialForm
    {
        #region Variables
        Controlador controlador = new Controlador();
        Validar validacion = new Validar();
        Utilidades utilidades = new Utilidades();
        List<MontajeTelaDetalle> montajeTelaDetalles = new List<MontajeTelaDetalle>();
        string coordina = "";
        int idSolicitudTelas = 0;
        #endregion

        #region Constructor
        public frmSolicitudListaTelas()
        {
            InitializeComponent();
            dtpFechaTienda.Format = DateTimePickerFormat.Custom;
            dtpFechaTienda.CustomFormat = "dd/MM/yyyy";
            txbClase.CharacterCasing = CharacterCasing.Upper;
            btnVerDetalle.Enabled = false;
            // ToolTips
            this.ttMuestrario.SetToolTip(this.cbxMuestrario, "Campo Obligatorio");
        }
        #endregion

        #region Método inicial de Carga
        private void frmSolicitudListaTelas_Load_1(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);

            cargarCombobox(cbxTipoSolicitud, controlador.getTipoSol());
            cargarCombobox(cbxMuestrario, controlador.getListaMuestrario());
            cargarCombobox(cbxOcasionUso, controlador.getListaOcasionUso());
            cargarCombobox(cbxTema, controlador.getListaTema());
            cargarCombobox(cbxEntrada, controlador.getListaEntrada());
            cargarCombobox(cbxDisenador, controlador.getListaDisenador());

            cargarCombobox(cbxNomTela, controlador.getNomTelas());
            cargarCombobox(cbxRefTela, controlador.getRefTelas());
            cargarCombobox(cbxColor, controlador.getColoresT());

            dgvSolicitudTelas.CellContentClick += new DataGridViewCellEventHandler(dgvSolicitudTelas_CellClick);
            btnConsultar.Click += new EventHandler(btnConsultar_Click);
        }
        #endregion

        #region Eventos

        /// <summary>
        /// Válida  que txbNdibujos (Número de dibujos) sea puda ingresar solo letras. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbNdibujo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }
       
        /// <summary>
        /// Establece que cbxMuestrario (Muestrario) sea mayúscula.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxMuestrario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        /// <summary>
        /// Estable que cbxOcasionUso (Ocasion de Uso) sea mayúscula.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxOcasionUso_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        /// <summary>
        /// Estable que el cbxTema (Tema) sea mayúscula.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxTema_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        /// <summary>
        /// Establece que el cbxEntrada (Entrada) sea mayúscula.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        /// <summary>
        /// Establece que el cbxDisenado(Diseñaor) sea mayúscula.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDisenador_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        /// <summary>
        /// Verifica que coordinadoNo, es checked entonces el Sicoordinado el false.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxNoCoordinado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNoCoordinado.Checked)
            {
                cbxSiCoordinado.Checked = false;
                coordina = "f";
            }
        }

        /// <summary>
        /// Verifica que coordinadoSi, es checked, entonces el Nocoordinado es false.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxSiCoordinado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSiCoordinado.Checked)
            {
                cbxNoCoordinado.Checked = false;
                coordina = "t";
            }

        }

        /// <summary>
        /// Válida que el txbSolicitud (Solicitud) sea solo de tipo númerico.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbSolicitud_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }
       
        /// <summary>
        /// Genera o estable que la columna inicial del DataGridView se pueda ser de verificación, es decir que la selección de las filas se realiza a traves CheckBoxColumn.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSolicitudTelas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvSolicitudTelas.EndEdit();
            //Comprobar que se ha hecho clic en el CheckBox de la fila.
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                // Bucle para verificar si todas las casillas de verificación de las filas están marcadas o no.
                foreach (DataGridViewRow row in dgvSolicitudTelas.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["sel"].EditedFormattedValue) == false)
                    {
                        dgvSolicitudTelas.Rows[e.RowIndex].Cells["sel"].Value = true;

                        //break;
                    }
                    dgvSolicitudTelas.RefreshEdit();

                }
            }

        }
        #endregion

        #region Botones
        /// <summary>
        /// Consulta en la base de datos, según los filtros (comboBox) seleccionados, luego procede a llenar la DatagridView con la infromación traida.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            MontajeTela objTela = new MontajeTela();
            if (cbxMuestrario.SelectedIndex == -1)
            {
                MessageBox.Show("Campo obligatorio,Por favor, seleccione un valor para Tipo Muestrario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string fecha = dtpFechaTienda.Value.ToString("dd/MM/yyyy");
                if (cbxHabilitarFecha.Checked)
                {
                    objTela.FechaTienda = fecha;
                }
                else
                {
                    objTela.FechaTienda = "";
                }

                objTela.TipoSolicitud = (cbxTipoSolicitud.SelectedIndex != -1 && cbxTipoSolicitud.Text != "") ? cbxTipoSolicitud.Text.ToString() : "";
                objTela.Muestrario = cbxMuestrario.GetItemText(cbxMuestrario.SelectedItem);
                objTela.OcasionUso = cbxOcasionUso.GetItemText(cbxOcasionUso.SelectedItem);
                objTela.Tema = cbxTema.GetItemText(cbxTema.SelectedItem);
                objTela.Entrada = cbxEntrada.GetItemText(cbxEntrada.SelectedItem);
                objTela.Disenador = cbxDisenador.GetItemText(cbxDisenador.SelectedItem);
                objTela.EnsayoRefSimilar = txbEnsayoRef.Text.Trim();
                objTela.Estado = (cbxEstado.SelectedIndex != -1 && cbxEstado.Text != "") ? cbxEstado.Text.ToString() : "";

                //objTela.FechaTienda = fecha;
                objTela.RefTela = cbxRefTela.GetItemText(cbxRefTela.SelectedItem);
                objTela.NomTela = cbxNomTela.GetItemText(cbxNomTela.SelectedItem);
                objTela.Solicitud = txbSolicitud.Text.Trim();
                objTela.Color = cbxColor.GetItemText(cbxColor.SelectedItem);
                objTela.Clase = txbClase.Text.Trim();
                objTela.Coordinado = coordina;
                objTela.NumDibujo = txbNdibujo.Text.Trim();

                dgvSolicitudTelas.Rows.Clear();
                montajeTelaDetalles = controlador.consultarListaTelas(objTela);
                cargarDataGridView(montajeTelaDetalles);
            }
        }

        /// <summary>
        /// Permite abrir la vista Reserva Tela a través des boton AnalizarInventario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnaInventario_Click(object sender, EventArgs e)
        {
            /// Cuenta cuantas filas de la DataGridView (dgvSolicitudTelas) en la vista frmSolicitudListaTelas ha sido chequeada (seleccionada).
            int contador = utilidades.ContarChecked(dgvSolicitudTelas);
            /// Realiza el respectivo método que retorna la lista de filas Seleccionadas
            if (contador > 1)
            {
                List<MontajeTelaDetalle> listaFilasSeleccionadas = obtenerListaFilasSeleccionadas();
                frmAnalizarInventario frmAnalizarInventario = new frmAnalizarInventario(controlador, listaFilasSeleccionadas, contador);
            }
            else
            {
                MessageBox.Show("Por favor seleccione al menos dos items", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Permite abrir la vista Agencias Externos a Traves del Botón InventarioExterno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInventarioExt_Click(object sender, EventArgs e)
        {
            /// Cuenta cuantas filas de la DataGridView (dgvSolicitudTelas) en la vista frmSolicitudListaTelas ha sido chequeada (seleccionada).
            int cantFilasSeleccionadas = utilidades.ContarChecked(dgvSolicitudTelas);
            int b = 0;
            if (cantFilasSeleccionadas > 1)
            {
                for (int i = 0; i < dgvSolicitudTelas.RowCount; i++)
                {
                    if (dgvSolicitudTelas.Rows[i].Cells[0].Value.Equals(true))//Columna de checks
                    {
                        if ( dgvSolicitudTelas.Rows[i].Cells[26].Value.ToString() == "Reserva parcial" || dgvSolicitudTelas.Rows[i].Cells[26].Value.ToString() == "Por Analizar")
                        {
                            b += 1;
                        }
                    }
                }
                if (b == cantFilasSeleccionadas)
                {
                    /*Realiza el respectivo método que retorna la lista de filas Seleccionadas*/
                    List<MontajeTelaDetalle> listaFilasSeleccionadas = obtenerListaFilasSeleccionadas();
                    frmAgenciasExternos frmAgenciasExterno = new frmAgenciasExternos(controlador, listaFilasSeleccionadas, cantFilasSeleccionadas, int.Parse(listaFilasSeleccionadas[0].IdSolTela.ToString()));
                    frmAgenciasExterno.Show();
                }
                else
                {
                    MessageBox.Show("El estado de solicitud No corresponde a Reserva Parcial o Por Analizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione al menos dos items.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }
        
        private void btnConsolidar_Click(object sender, EventArgs e)
        {
        
            /// Cuenta cuantas filas de la DataGridView (dgvSolicitudTelas) en la vista frmSolicitudListaTelas ha sido chequeada (seleccionada).
            int cantFilasSeleccionadas = utilidades.ContarChecked(dgvSolicitudTelas);
            int b = 0;
            if (cantFilasSeleccionadas > 1)
            {
                for (int i = 0; i < dgvSolicitudTelas.RowCount; i++)
                {
                    if (dgvSolicitudTelas.Rows[i].Cells[0].Value.Equals(true))//Columna de checks
                    {
                        if (dgvSolicitudTelas.Rows[i].Cells[26].Value.ToString() == "Solicitud de Inventario" || dgvSolicitudTelas.Rows[i].Cells[26].Value.ToString() == "Reserva parcial" || dgvSolicitudTelas.Rows[i].Cells[26].Value.ToString() == "Por Analizar")
                        {
                            b += 1;
                        }
                    }
                }
                if (b == cantFilasSeleccionadas)
                {
                    /*Realiza el respectivo método que retorna la lista de filas Seleccionadas*/
                    List<MontajeTelaDetalle> listaFilasSeleccionadas = obtenerListaFilasSeleccionadas();

                    string tipo = "";
                    //Validar consolidado
                    if (validarTieneConsolidado(listaFilasSeleccionadas))
                    {
                        if (validarIgualConsolidado(listaFilasSeleccionadas))
                        {
                            tipo = listaFilasSeleccionadas[0].TipoPedido;
                        }
                        else {
                            MessageBox.Show("Las solicitudes no corresponden al mismo pedido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        //Validar que las solicitudes tengan el mismo estado
                        bool valTipo = validarMismoTipoSolicitud(listaFilasSeleccionadas);
                        bool valCoordinado = validarCoordinado(listaFilasSeleccionadas);
                        if (valTipo)
                        {
                            if (valCoordinado)
                            {
                                if (listaFilasSeleccionadas.Count == 3)
                                {
                                    if (!validarCoordinadoSolicitudEsPlano(listaFilasSeleccionadas))
                                    {
                                        tipo = "COORDINADO";
                                    }
                                    else
                                    {
                                        MessageBox.Show("Pedido a montar COORDINADO no permite solicitudes de tipo Plano Preteñido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Pedido a montar COORDINADO permite consolidar solo tres (3) solicitudes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                if (validarAgencias(listaFilasSeleccionadas))
                                {
                                    tipo = "AGENCIAS EXTERNO";
                                }
                                else
                                {
                                    tipo = listaFilasSeleccionadas[0].TipoSolicitud;
                                }
                            }
                        }
                        else
                        {

                            if (valCoordinado)
                            {
                                if (listaFilasSeleccionadas.Count == 3)
                                {
                                    if (!validarCoordinadoSolicitudEsPlano(listaFilasSeleccionadas))
                                    {
                                        tipo = "COORDINADO";
                                    }
                                    else
                                    {
                                        MessageBox.Show("Pedido a montar COORDINADO no permite solicitudes de tipo Plano Preteñido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Pedido a montar COORDINADO permite consolidar tres (3) solicitudes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else if (validarAgencias(listaFilasSeleccionadas))
                            {
                                tipo = "AGENCIAS EXTERNOS";
                            }
                            else
                            {
                                MessageBox.Show("Por favor seleccione solicitudes con estado: Solicitud de Inventario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    if (tipo != "")
                    {
                        frmTipoPedidoaMontar frmTipoPedido = new frmTipoPedidoaMontar(controlador, listaFilasSeleccionadas, tipo, int.Parse(listaFilasSeleccionadas[0].IdSolTela.ToString()));
                        //frmTipoPedido.Show();
                        if (frmTipoPedido.ShowDialog() == DialogResult.OK)
                        {
                            //btnConsultar.Click += new EventHandler(btnConsultar_Click);
                            btnConsultar.PerformClick();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El estado de solicitud No corresponde a Solicitud de Inventario, Reserva Parcial o Por Analizar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione al menos dos items.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
            }

        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            int cantFilasSeleccionadas = utilidades.ContarChecked(dgvSolicitudTelas);
            List<MontajeTelaDetalle> listaFilasSeleccionadas = obtenerListaFilasSeleccionadas();
            if (listaFilasSeleccionadas.Count != 0)
            {          
                int consolidado = int.Parse(listaFilasSeleccionadas[0].Consolidado);
                int b = 0;
                if (cantFilasSeleccionadas > 1 && consolidado != 0)
                {

                    for (int i = 0; i < dgvSolicitudTelas.RowCount; i++)
                    {
                        if (dgvSolicitudTelas.Rows[i].Cells[0].Value.Equals(true))//Columna de checks
                        {
                            if (dgvSolicitudTelas.Rows[i].Cells[26].Value.ToString() == "Radicado" && int.Parse(dgvSolicitudTelas.Rows[i].Cells[31].Value.ToString()) == consolidado)
                            {
                                
                                b += 1;
                            }
                        }
                    }
                }
                if (b == cantFilasSeleccionadas)
                {

                    frmDevolucion objFrmDevolcion = new frmDevolucion(controlador, listaFilasSeleccionadas[0].ConsecutivoPedido.ToString());
                    objFrmDevolcion.Show();
                }
                else
                {
                 MessageBox.Show("Los items seleccionados no corresponden a estado Radicado o su Cosecutivo no es igual.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                frmDevolucion objFrmDevolcion = new frmDevolucion(controlador, "");
                objFrmDevolcion.Show();
            }
           
        }
        
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int cantFilasSeleccionadas = utilidades.ContarChecked(dgvSolicitudTelas);
            List<MontajeTelaDetalle> listaFilasSeleccionadas = obtenerListaFilasSeleccionadas();
            if (listaFilasSeleccionadas.Count != 0)
            {
                int consolidado = int.Parse(listaFilasSeleccionadas[0].Consolidado);
                int b = 0;
                if (cantFilasSeleccionadas > 1 && consolidado != 0)
                {

                    for (int i = 0; i < dgvSolicitudTelas.RowCount; i++)
                    {
                        if (dgvSolicitudTelas.Rows[i].Cells[0].Value.Equals(true))//Columna de checks
                        {
                            if (dgvSolicitudTelas.Rows[i].Cells[26].Value.ToString() == "Devolucion" && int.Parse(dgvSolicitudTelas.Rows[i].Cells[31].Value.ToString()) == consolidado)
                            {

                                b += 1;
                            }
                        }
                    }
                }
                if (b == cantFilasSeleccionadas)
                {

                    frmEditar frmEditar = new frmEditar(controlador, int.Parse(listaFilasSeleccionadas[0].ConsecutivoPedido.ToString()), listaFilasSeleccionadas[0].TipoPedido, listaFilasSeleccionadas);
                    frmEditar.Show();
                }
                else
                {
                    MessageBox.Show("Los items seleccionados no corresponden a estado Devolución o su Cosecutivo no es igual.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                frmEditar frmEditar = new frmEditar(controlador, 0,"",null);
                frmEditar.Show();
            }
        }
       
        /// <summary>
        /// Permite Salir de la vista actual, llevando al usuario a la vista inicial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmInicial frmInicial = new frmInicial();
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmImprimir frmImprimir = new frmImprimir(controlador);
            frmImprimir.Show();
        }
        #endregion
        
        #region Métodos 
        /// <summary>
        /// Carga toda la información de los comboBox mostrados en la vista.
        /// </summary>
        /// <param name="prmCombo">ComboBox a llenar.</param>
        /// <param name="prmLista">Lista de tipo Objeto, la cual es cargada en el comboBox.</param>
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
        /// Genera una lista de tipo DetalleListaTela, la cual es representada por las filas seleccionadas en la dataGridView (dgvSolicitudTelas) es decir 
        /// en la vista frmSolicitudListaTelas, para más comprensión son las filas Chequedas. 
        /// </summary>
        /// <returns>Retorna una Lista de Tipo DetalleLista, que representas las filas seleccionadas.</returns>
        private List<MontajeTelaDetalle> obtenerListaFilasSeleccionadas()
        {
            List<MontajeTelaDetalle> listaSeleccionadas = new List<MontajeTelaDetalle>();

            for (int i = 0; i <= dgvSolicitudTelas.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(dgvSolicitudTelas.Rows[i].Cells["sel"].Value) == true)
                {
                    MontajeTelaDetalle objInfo = new MontajeTelaDetalle();

                    objInfo.Solicitud = dgvSolicitudTelas.Rows[i].Cells[1].Value.ToString();
                    objInfo.TipoSolicitud = dgvSolicitudTelas.Rows[i].Cells[2].Value.ToString();
                    objInfo.Ensayo = dgvSolicitudTelas.Rows[i].Cells[3].Value.ToString();
                    objInfo.RefSimilar = dgvSolicitudTelas.Rows[i].Cells[4].Value.ToString();
                    objInfo.NumDibujos = int.Parse(dgvSolicitudTelas.Rows[i].Cells[5].Value.ToString());
                    objInfo.CodFondo = dgvSolicitudTelas.Rows[i].Cells[6].Value.ToString();
                    objInfo.Fondo = dgvSolicitudTelas.Rows[i].Cells[7].Value.ToString();
                    objInfo.TipoTela = dgvSolicitudTelas.Rows[i].Cells[8].Value.ToString();
                    objInfo.Coordinado = dgvSolicitudTelas.Rows[i].Cells[9].Value.ToString();
                    objInfo.CoordinadoCon = dgvSolicitudTelas.Rows[i].Cells[10].Value.ToString();
                    objInfo.RefTela = dgvSolicitudTelas.Rows[i].Cells[11].Value.ToString();
                    objInfo.DesTela = dgvSolicitudTelas.Rows[i].Cells[12].Value.ToString();
                    objInfo.Vte = dgvSolicitudTelas.Rows[i].Cells[13].Value.ToString();
                    objInfo.DesColor = dgvSolicitudTelas.Rows[i].Cells[14].Value.ToString();
                    objInfo.TotaUnidades = dgvSolicitudTelas.Rows[i].Cells[15].Value.ToString();
                    objInfo.Consumo = dgvSolicitudTelas.Rows[i].Cells[16].Value.ToString();
                    objInfo.Marca = dgvSolicitudTelas.Rows[i].Cells[17].Value.ToString();
                    objInfo.Muestrario = dgvSolicitudTelas.Rows[i].Cells[18].Value.ToString();
                    objInfo.OcasionUso = dgvSolicitudTelas.Rows[i].Cells[19].Value.ToString();
                    objInfo.Tema = dgvSolicitudTelas.Rows[i].Cells[20].Value.ToString();
                    objInfo.Entrada = dgvSolicitudTelas.Rows[i].Cells[21].Value.ToString();
                    objInfo.FechaTienda = dgvSolicitudTelas.Rows[i].Cells[22].Value.ToString();
                    objInfo.Disenador = dgvSolicitudTelas.Rows[i].Cells[23].Value.ToString();
                    objInfo.ObsDiseno = dgvSolicitudTelas.Rows[i].Cells[24].Value.ToString();
                    objInfo.FechaSolTelas = dgvSolicitudTelas.Rows[i].Cells[25].Value.ToString();
                    objInfo.Estado = dgvSolicitudTelas.Rows[i].Cells[26].Value.ToString();
                    objInfo.FechaEstado = dgvSolicitudTelas.Rows[i].Cells[27].Value.ToString();
                    objInfo.CodigoH1 = montajeTelaDetalles[i].CodigoH1;
                    objInfo.DescripcionH1 = montajeTelaDetalles[i].DescripcionH1.ToString();
                    objInfo.CodigoH2 = montajeTelaDetalles[i].CodigoH2;
                    objInfo.DescripcionH2 = montajeTelaDetalles[i].DescripcionH2.ToString();
                    objInfo.CodigoH3 = montajeTelaDetalles[i].CodigoH3;
                    objInfo.DescripcionH3 = montajeTelaDetalles[i].DescripcionH3.ToString();
                    objInfo.CodigoH4 = montajeTelaDetalles[i].CodigoH4;
                    objInfo.DescripcionH4 = montajeTelaDetalles[i].DescripcionH4.ToString();
                    objInfo.CodigoH5 = montajeTelaDetalles[i].CodigoH5;
                    objInfo.DescripcionH5 = montajeTelaDetalles[i].DescripcionH5.ToString();
                    objInfo.Tiendas = montajeTelaDetalles[i].Tiendas.ToString();
                    objInfo.Exito = montajeTelaDetalles[i].Exito.ToString();
                    objInfo.Cencosud = montajeTelaDetalles[i].Cencosud.ToString();
                    objInfo.Sao = montajeTelaDetalles[i].Sao.ToString();
                    objInfo.Comercio = montajeTelaDetalles[i].Comercio.ToString();
                    objInfo.Rosado = montajeTelaDetalles[i].Rosado.ToString();
                    objInfo.Otros = montajeTelaDetalles[i].Otros.ToString();
                    objInfo.MCalculados = utilidades.mCalculados2(dgvSolicitudTelas.Rows[i].Cells[15].Value.ToString(), dgvSolicitudTelas.Rows[i].Cells[16].Value.ToString());

                    objInfo.MReservados = montajeTelaDetalles[i].MReservados.ToString();
                    objInfo.Masolicitar = utilidades.mSolicitar(objInfo.MCalculados, montajeTelaDetalles[i].MReservados.ToString());
                    controlador.setMCalculados(int.Parse(dgvSolicitudTelas.Rows[i].Cells[28].Value.ToString()), utilidades.mCalculados2(dgvSolicitudTelas.Rows[i].Cells[15].Value.ToString(), dgvSolicitudTelas.Rows[i].Cells[16].Value.ToString()));
                    objInfo.CantidadReservado = (montajeTelaDetalles[i].CantidadReservado != null && montajeTelaDetalles[i].CantidadReservado != "") ? montajeTelaDetalles[i].CantidadReservado : "0";
                    objInfo.IdSolTela = montajeTelaDetalles[i].IdSolTela;
                    objInfo.IdDetalleSolicitud = montajeTelaDetalles[i].IdDetalleSolicitud;
                    objInfo.IdProgramador = montajeTelaDetalles[i].IdProgramador;
                    objInfo.DescPrenda = montajeTelaDetalles[i].DescPrenda;
                    objInfo.Consolidado = montajeTelaDetalles[i].Consolidado;
                    objInfo.TipoPedido = montajeTelaDetalles[i].TipoPedido;
                    objInfo.ConsecutivoPedido = montajeTelaDetalles[i].ConsecutivoPedido;

                    listaSeleccionadas.Add(objInfo);
                }


            }
            return listaSeleccionadas;
        }

        /// <summary>
        /// Llena el DataGridview con la información filtrada y consultada.
        /// </summary>
        /// <param name="prmLista">Lista de tipo DetalleListaTela, información para llenar el DataGridView.</param>
        private void cargarDataGridView(List<MontajeTelaDetalle> prmLista)
        {

            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {
                    if (prmLista[i].Coordinado == "f")
                    {
                        prmLista[i].Coordinado = "NO";
                    }
                    else if (prmLista[i].Coordinado == "t")
                    {
                        prmLista[i].Coordinado = "SI";
                    }
                    dgvSolicitudTelas.Rows.Add(prmLista[i].Sel.ToString(),
                    prmLista[i].Solicitud.ToString(),
                    prmLista[i].TipoSolicitud.ToString(),
                    prmLista[i].Tipo.ToString(),
                    prmLista[i].RefSimilar.ToString(),
                    prmLista[i].NumDibujos.ToString(),
                    prmLista[i].CodFondo.ToString(),
                    prmLista[i].Fondo.ToString(),
                    prmLista[i].TipoTela.ToString(),
                    prmLista[i].Coordinado.ToString(),
                    prmLista[i].CoordinadoCon.ToString(),
                    prmLista[i].RefTela.ToString(),
                    prmLista[i].DesTela.ToString(),
                    prmLista[i].Vte.ToString(),
                    prmLista[i].DesColor.ToString(),
                    prmLista[i].TotaUnidades.ToString(),
                    prmLista[i].Consumo.ToString(),
                    prmLista[i].Marca.ToString(),
                    prmLista[i].Muestrario.ToString(),
                    prmLista[i].OcasionUso.ToString(),
                    prmLista[i].Tema.ToString(),
                    prmLista[i].Entrada.ToString(),
                    prmLista[i].FechaTienda.ToString(),
                    prmLista[i].Disenador.ToString(),
                    prmLista[i].ObsDiseno.ToString(),
                    prmLista[i].FechaSolTelas.ToString(),
                    prmLista[i].Estado.ToString(),
                    prmLista[i].FechaEstado.ToString(),
                    prmLista[i].IdSolTela.ToString(),
                    prmLista[i].IdProgramador.ToString(),
                    prmLista[i].DescPrenda.ToString(),
                    prmLista[i].Consolidado.ToString(),
                    prmLista[i].TipoPedido.ToString(),
                    prmLista[i].ConsecutivoPedido.ToString()

                    );
                    idSolicitudTelas = prmLista[i].IdSolTela;

                }
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private bool validarMismoTipoSolicitud(List<MontajeTelaDetalle> lista)
        {
            string tipoSolicitud = lista[0].TipoSolicitud;
            foreach (MontajeTelaDetalle item in lista)
            {
                if (item.TipoSolicitud.ToUpper() != tipoSolicitud.ToUpper())
                {
                    return false;
                }
            }
            return true;
        }

        private bool validarCoordinado(List<MontajeTelaDetalle> lista)
        {
            foreach (MontajeTelaDetalle item in lista)
            {
                if (item.Coordinado.ToUpper() != "SI")
                {
                    return false;
                }
            }
            return true;
        }
        private bool validarCoordinadoSolicitudEsPlano(List<MontajeTelaDetalle> lista)
        {
            foreach (MontajeTelaDetalle item in lista)
            {
                if (item.TipoSolicitud.ToUpper() == "PRETEÑIDO")
                {
                    return true;
                }
            }
            return false;
        }

        private bool validarAgencias(List<MontajeTelaDetalle> lista)
        {
            foreach (MontajeTelaDetalle item in lista)
            {
                if (item.Estado.ToUpper() != "SOLICITUD DE INVENTARIO")
                {
                    return false;
                }
            }
            return true;
        }

        private bool validarTieneConsolidado(List<MontajeTelaDetalle> lista)
        {
            foreach (MontajeTelaDetalle item in lista)
            {
                if (item.Consolidado == null || item.Consolidado == "")
                {
                    return false;
                }
            }
            return true;
        }

        private bool validarIgualConsolidado(List<MontajeTelaDetalle> lista)
        {
            string consolidado = lista[0].Consolidado;
            foreach (MontajeTelaDetalle item in lista)
            {
                if (item.Consolidado != null && item.Consolidado != "" && item.Consolidado != consolidado)
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        private void cbxHabilitarFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxHabilitarFecha.Checked)
            {
                dtpFechaTienda.Visible = true;
            }
            else
            {
                dtpFechaTienda.Visible = false;
            }
        }
    }
}
