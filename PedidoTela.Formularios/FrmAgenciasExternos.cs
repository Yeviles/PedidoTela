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
    public partial class FrmAgenciasExternos : MaterialSkin.Controls.MaterialForm
    {
        #region Variables
        Controlador control = new Controlador();
        Validar validacion = new Validar();
        int idsolTela, id;
        bool bandera = false;   
        List<DetalleListaTela> detalleSeleccionado = new List<DetalleListaTela>();
        #endregion

        #region Getter && Setter
        public List<DetalleListaTela> DetalleSeleccionado { get => detalleSeleccionado; set => detalleSeleccionado = value; }
        public int IdsolTela { get => idsolTela; set => idsolTela = value; }
        #endregion

        #region Constructor
        public FrmAgenciasExternos(Controlador controlador, List<DetalleListaTela> listaSeleccionada, int numFilasSelccionadas, int idSolicitudTelas)
        {
            InitializeComponent();
            DetalleSeleccionado = listaSeleccionada;
            control = controlador;
            control.IdUsuario = 216;
            dtpFechaLlegada.Format = DateTimePickerFormat.Custom;
            dtpFechaLlegada.CustomFormat = "dd/MM/yyyy";
            IdsolTela = idSolicitudTelas;
            Validaciones(DetalleSeleccionado, numFilasSelccionadas);

        }
        #endregion

        #region Método inicial de Carga
        private void FrmAgenciasExternos_Load(object sender, EventArgs e)
        {
            cargarCombobox(cbxComposicion, control.getComposicion());
            txtCargo.Text = "Analista";
            txtDepartamento.Text = "Cortes B";
            txtTelefono.Text = "4055252";

            txtProveedor.MaxLength = 20;
            txtNit.MaxLength = 12;
            txtContacto.MaxLength = 20;
            txtOrdenCompra.MaxLength = 12;
            // ToolTipText
            dgvInfoConsolidar.Columns["descripColor"].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInfoConsolidar.Columns["codColor"].HeaderCell.ToolTipText = "Clic item si desea modificar";

            dgvTotalConsolidado.Columns["mC"].HeaderCell.ToolTipText = "(Consumo * Total Unidades)*1.10";
            dgvTotalConsolidado.Columns["desColor"].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvTotalConsolidado.Columns["codigoColor"].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvTotalConsolidado.Columns["kgCalculados"].HeaderCell.ToolTipText = "(M a solicitar /Rendimiento)";


        }
        #endregion

        #region Eventos
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvInfoConsolidar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
        }

        private void dgvTotalConsolidado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTotalConsolidado.Columns[e.ColumnIndex].Name == "codigoColor" || dgvTotalConsolidado.Columns[e.ColumnIndex].Name == "desColor")
            {
                frmBuscarColor buscarColor = new frmBuscarColor(control);
                buscarColor.StartPosition = FormStartPosition.CenterScreen;
                if (buscarColor.ShowDialog() == DialogResult.OK)
                {
                    Objeto obj = buscarColor.Elemento;
                    dgvTotalConsolidado.Rows[e.RowIndex].Cells[0].Value = obj.Id;
                    dgvTotalConsolidado.Rows[e.RowIndex].Cells[1].Value = obj.Nombre;
                }
            }
          }

        private void dgvTotalConsolidado_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                if (dgvTotalConsolidado.CurrentCell.Value != null && dgvTotalConsolidado.CurrentCell.Value.ToString().Trim() != "")
                {
                    if (dgvTotalConsolidado.CurrentCell.Value != null && dgvTotalConsolidado.CurrentCell.Value.ToString().Trim() != "")
                    {
                        decimal valor = decimal.Parse(dgvTotalConsolidado.CurrentCell.Value.ToString());
                        decimal vfinal = Decimal.Round(valor, 2);
                        dgvTotalConsolidado.CurrentCell.Value = valor;
                    }
                }
            }
        }

        private void txtRendimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.validarDecimal(sender, e);    
         }

        private void txtAnchoTela_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.validarDecimal(sender, e);
        }

        private void txtExtencion_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        /// <summary>
        /// Actualiza el campo KgCalculados, de la datagridview (dgvTotalConsolidado) una vez se ingrese datos en el textbox (txtRendimiento).
        /// Se realiza lasiguente  operanción: M a  solicitar  /Rendimiento  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRendimiento_TextChanged(object sender, EventArgs e)
        {
           
                for (int i = 0; i < dgvTotalConsolidado.RowCount; i++)
                {
                if (txtRendimiento.Text != "")
                {

                    dgvTotalConsolidado.Rows[i].Cells[11].Value =Decimal.Round((decimal.Parse(dgvTotalConsolidado.Rows[i].Cells[10].Value.ToString()) / decimal.Parse(txtRendimiento.Text)),2);

                }
                else
                {
                    dgvTotalConsolidado.Rows[i].Cells[11].Value = "";
                }
                
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            bool b = false;
            List<int> listaIDInfoConsolidar = new List<int>();

            List<int> listaIDtotalconsolidar = new List<int>();

            if (cbxComposicion.SelectedIndex == -1)          
            {
                MessageBox.Show("Por favor, seleccione un valor para Composición.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtExtencion.Text == "")
            {
                MessageBox.Show("Por favor, ingrese el valor para la Extención.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtAnchoTela.Text == "")
            {
                MessageBox.Show("Por favor, ingrese un valor para Ancho de tela.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtRendimiento.Text =="")
            {
                MessageBox.Show("Por favor, ingrese un valor para Rendimiento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtProveedor.Text == "")
            {
                MessageBox.Show("Por favor, ingrese un valor para Proveedor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtNit.Text == "")
            {
                MessageBox.Show("Por favor, ingrese un valor para Nit.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtContacto.Text == "")
            {
                MessageBox.Show("Por favor, ingrese un valor para Contacto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtPedidoAgencia.Text == "")
            {
                MessageBox.Show("Por favor, ingrese un valor para Pedido Agencia.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (dgvInfoConsolidar.RowCount > 0 && dgvTotalConsolidado.RowCount > 0)
                {
                        bool vacio = false;
                        foreach (DataGridViewRow row in dgvTotalConsolidado.Rows)
                        {
                            if (row.Cells[11].Value == null || row.Cells[12].Value == null || row.Cells[13].Value == null)
                            {
                                vacio = true;
                            }
                        }

                        if (!vacio)
                        {

                            AgenciasExternos elemento = new AgenciasExternos();
                            elemento.SolicitadoPor = txtSolicitadoPor.Text.Trim();
                            elemento.Cargo = txtCargo.Text.Trim();
                            elemento.Departamento = txtDepartamento.Text.Trim();
                            elemento.Telefono = txtTelefono.Text.Trim();
                            elemento.Extencion = txtExtencion.Text.Trim();
                            elemento.ReferenciaTela = txtRefTela.Text.Trim();
                            elemento.TipoTejido = txtTipoTejido.Text.Trim();
                            elemento.Fondo = txtFondo.Text.Trim();
                            elemento.NombreTela = txtNomTela.Text.Trim();
                            elemento.AnchoTela = decimal.Parse(txtAnchoTela.Text.Trim());
                            elemento.Rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
                            elemento.Composicion = cbxComposicion.GetItemText(cbxComposicion.SelectedItem);
                            elemento.Muestrario = txtMuestrario.Text.Trim();
                            elemento.OcasionUso = txtOcasionUso.Text.Trim();
                            elemento.Tema = txtTema.Text.Trim();
                            elemento.Entrada = txtEntrada.Text.Trim();
                            elemento.EnsayoRef = txtEnsayoRef.Text.Trim();
                            elemento.FechaTienda = txtFechaTienda.Text.Trim();
                            elemento.Disenadora = txtDisenadora.Text.Trim();
                            elemento.DescPrenda = txtDescPrenda.Text.Trim();
                            elemento.Proveedor = txtProveedor.Text.Trim();
                            elemento.Nit = txtNit.Text.Trim();
                            elemento.Contacto = txtContacto.Text.Trim();
                            elemento.PedidoAgencia = txtPedidoAgencia.Text.Trim();
                            elemento.OrdenCompra = txtOrdenCompra.Text.Trim();
                            elemento.FechaLlegadaTela = dtpFechaLlegada.Value.ToString();
                            elemento.IdSolTela = IdsolTela;

                            if (control.consultarIdAgenciasExt(IdsolTela))
                            {
                                control.ActualizarAgenciasExt(elemento);
                                b = true;
                            }
                            else
                            {
                                control.addAgenciaExt(elemento);
                            }
                            id = control.getIdAgenciasExt(IdsolTela);

                            listaIDInfoConsolidar = control.getIdInfoaConsolidar(id);
                            listaIDtotalconsolidar = control.getIdTotalConsolidado(id);
                            //Console.WriteLine("ID: " + id);
                            try
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


                                if (b)
                                    {
                                        if (i < listaIDInfoConsolidar.Count)
                                        {
                                            control.ActualizarInfoConsolidar(detalle, listaIDInfoConsolidar[i]);
                                        }
                                        else
                                        {
                                            control.addInfoConsolidar(detalle);
                                        }
                                    }
                                    else
                                    {
                                        control.addInfoConsolidar(detalle);
                                    }

                                }
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

                                if (b)
                                    {
                                        if (i < listaIDtotalconsolidar.Count)
                                        {
                                            control.ActualizarTotalConsolidar(detalle, listaIDtotalconsolidar[i]);
                                        }
                                        else
                                        {
                                            control.addTotalConsolidar(detalle);
                                        }
                                    }
                                    else
                                    {
                                        control.addTotalConsolidar(detalle);
                                    }

                                }
                                  MessageBox.Show("Agencias-Externo se guardó con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            catch
                            {
                                MessageBox.Show("Agencias-Externo no se pudo guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Los campos Kg Calculados, total a Pedir y unidad de Medida Tela deben estar llenos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, adicione al menos un color.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Se válida que en la lista (List<DetalleListaTela> listaSeleccionada) que llega al contructor por argumentos, tenga un atributo estado y que 
        /// este contenga valor de Por Analizar o Reserva Parcial, si cumple esta condición procede a llenar el encabezado  y las DataGridView de la vista actual.
        /// </summary>
        /// <param name="prmLista"> Lista de tipo DetalleListaTela, la cual representa las filas seleccionadas en el vista frmSolicitudListaTelas. </param>
        /// <param name="cont">Cantidad de filas que han sido seleccionadas en la vista frmSolicitudListaTelas.</param>
        public void Validaciones(List<DetalleListaTela> prmLista, int numfilasSeleccionadas)
        {
            int b = 0;
           
            if (numfilasSeleccionadas >= 2)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {
                    if (prmLista[i].Estado == "Por Analizar" || prmLista[i].Estado == "Reserva parcial")
                    {
                        b += 1;
                    }
                }
                if (b == prmLista.Count)
                {
                    this.Show();
                    Cargar();
                    if (!this.bandera)
                    {

                        //Carga el DataGridView (dgvInfoConsolidar) el cual pertenece a la sección de información a consolidar.
                        cargarDgvInfoConsolidar(prmLista);
                        //Carga el DataGridView (dgvTotalConsolidado) el cual pertenece a la sección de total consolidado.
                        cargarDgvTotalConsolidar(prmLista);
                    }
                }
                else
                {
                    MessageBox.Show("El estado de solicitud No corresponde a Por Analizar o Reserva Parcial", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar mínimo dos filas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        /// <summary>
        /// Carga el DataGridView (dgvInfoConsolidar) con la información solicitada.
        /// </summary>
        /// <param name="prmLista">Lista de tipo DetalleLista contiene la informacion a cargar en la DatagridView.</param>
        private void cargarDgvInfoConsolidar(List<DetalleListaTela> prmLista)
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
                    //prmLista[i].IdSolTela.ToString(),
                    //prmLista[i].IdDetalleSolicitud.ToString()
                    );
                    txtSolicitadoPor.Text = control.IdUsuario.ToString();
                    txtNomTela.Text = prmLista[i].DesTela.ToString();
                    txtRefTela.Text = prmLista[i].RefTela.ToString();
                    txtTipoTejido.Text = prmLista[i].TipoTela.ToString();
                    txtFondo.Text = prmLista[i].Fondo.ToString();
                    txtMuestrario.Text = prmLista[i].Muestrario.ToString();
                    txtOcasionUso.Text = prmLista[i].OcasionUso.ToString();
                    txtFechaTienda.Text = prmLista[i].FechaTienda.ToString();
                    txtDisenadora.Text = prmLista[i].Disenador.ToString();
                    txtEnsayoRef.Text = prmLista[i].RefSimilar.ToString();
                    txtTema.Text = prmLista[i].Tema.ToString();
                    txtEntrada.Text = prmLista[i].Entrada.ToString();
                    txtDescPrenda.Text = prmLista[i].DescPrenda.ToString();
                   
                    IdsolTela = prmLista[i].IdSolTela;
                    
                }
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Carga el DataGridView (dgvToltalConsolidar) con la información solicitada.
        /// </summary>
        /// <param name="prmLista">Lista de tipo DetalleLista contiene la informacion a cargar en la DatagridView.</param>
        private void cargarDgvTotalConsolidar(List<DetalleListaTela> prmLista)
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
                    prmLista[i].MCalculados.ToString()
                   
                    //prmLista[i].IdSolTela.ToString(),
                    //prmLista[i].IdDetalleSolicitud.ToString()
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

        private void btnConfirmarSIP_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimirSIP_Click(object sender, EventArgs e)
        {
            frmImprimirSIP imprimir = new frmImprimirSIP(control, IdsolTela);
            imprimir.ShowDialog();
        }

        /// <summary>
        /// Realiza el cargue inicial de los datos para la vista (frmAgenciasExternos).
        /// </summary>
        private void Cargar()
        {
            AgenciasExternos objAgencias = control.getAgenciasExt(IdsolTela);
            id = objAgencias.IdAgencias;
            if (id != 0)
            {
             cbxComposicion.Text = objAgencias.Composicion;
  
                txtSolicitadoPor.Text = objAgencias.SolicitadoPor.ToString();
                txtCargo.Text = objAgencias.Cargo.ToString();
                txtDepartamento.Text = objAgencias.Departamento.ToString();
                txtTelefono.Text = objAgencias.Telefono.ToString();
                txtExtencion.Text = objAgencias.Extencion.ToString();
                txtRefTela.Text = objAgencias.ReferenciaTela.ToString();
                txtTipoTejido.Text = objAgencias.TipoTejido.ToString();
                txtFondo.Text = objAgencias.Fondo.ToString();
                txtNomTela.Text = objAgencias.NombreTela.ToString();
                txtNomTela.Text = objAgencias.NombreTela.ToString();
                txtAnchoTela.Text = objAgencias.AnchoTela.ToString();
                txtRendimiento.Text = objAgencias.Rendimiento.ToString();
                txtMuestrario.Text = objAgencias.Muestrario.ToString();
                txtOcasionUso.Text = objAgencias.OcasionUso.ToString();
                txtTema.Text = objAgencias.Tema.ToString();
                txtEntrada.Text = objAgencias.Entrada.ToString();
                txtEnsayoRef.Text = objAgencias.EnsayoRef.ToString();
                txtFechaTienda.Text = objAgencias.FechaTienda.ToString();
                txtDisenadora.Text = objAgencias.Disenadora.ToString();
                txtDescPrenda.Text = objAgencias.DescPrenda.ToString();
                txtProveedor.Text = objAgencias.Proveedor.ToString();
                txtNit.Text = objAgencias.Nit.ToString();
                txtContacto.Text = objAgencias.Contacto.ToString();
                txtPedidoAgencia.Text = objAgencias.PedidoAgencia.ToString();
                txtOrdenCompra.Text = objAgencias.OrdenCompra.ToString();
                dtpFechaLlegada.Text = objAgencias.FechaLlegadaTela.ToString();

            /*Carga detalle Información a  Consolidar*/
            List<AgenciasInfoConsolidar> listaInfoConsolidar = control.getInfoConsolidar(objAgencias.IdAgencias);
            if (listaInfoConsolidar.Count > 0)
            {
                foreach (AgenciasInfoConsolidar obj in listaInfoConsolidar)
                {
                    dgvInfoConsolidar.Rows.Add(obj.CodColor, obj.DesColor, obj.Tiendas, obj.Exito,
                        obj.Cencosud, obj.Sao, obj.ComercioOrg, obj.Rosado, obj.Otros, obj.TotalUnidades, obj.Consumo, obj.MCalculados, obj.MReservados, obj.MaSolicitar);
                }
                //btnGrabar.Enabled = false;
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
                //btnGrabar.Enabled = false;
            }
          
                this.bandera = true;
                //dgvInfoConsolidar.ReadOnly = true;
                //dgvTotalConsolidado.ReadOnly = true;
              
            }
        }
        #endregion
    }
}
