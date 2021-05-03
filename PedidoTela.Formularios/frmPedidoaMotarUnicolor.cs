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
    public partial class frmPedidoaMotarUnicolor : MaterialSkin.Controls.MaterialForm
    {
        #region Variables
        private String seleccion;
        private Controlador control = new Controlador();
        List<MontajeTelaDetalle> detalleSeleccionado = new List<MontajeTelaDetalle>();
        List<int> listaIdSolicitudes= new List<int>();
        List<string> listaEsayosRef = new List<string>();

        Validar validacion = new Validar();
        int contItemSeleccionado = 0, idSolTela,id, consecutivo=0;
        bool bandera = false;
        #endregion

        #region Setter && Getter
        public string Seleccion { get => seleccion; set => seleccion = value; }
        public List<MontajeTelaDetalle> DetalleSeleccionado { get => detalleSeleccionado; set => detalleSeleccionado = value; }
        public int ContItemSeleccionado { get => contItemSeleccionado; set => contItemSeleccionado = value; }
        public int IdSolTela { get => idSolTela; set => idSolTela = value; }
        public List<int> ListaIdSolicitudes { get => listaIdSolicitudes; set => listaIdSolicitudes = value; }
        public List<string> ListaEsayosRef { get => listaEsayosRef; set => listaEsayosRef = value; }

        #endregion

        #region Constructor
        public frmPedidoaMotarUnicolor(Controlador controlador, List<MontajeTelaDetalle> listaSeleccionada, int contador, string tipoPedidoMontar, int idSolTela)
        {
            InitializeComponent();
            control = controlador;
            DetalleSeleccionado = listaSeleccionada;
            ContItemSeleccionado = contador;
            Seleccion = tipoPedidoMontar;
            dtpFechaLlegada.Format = DateTimePickerFormat.Custom;
            dtpFechaLlegada.CustomFormat = "dd/MM/yyyy";
            IdSolTela = idSolTela;
            Validaciones(DetalleSeleccionado, ContItemSeleccionado);

        }
        #endregion

        #region Método inicial de Carga
        private void frmPedidoaMotarUnicolor_Load(object sender, EventArgs e)
        {
            cargarCombobox(cbxTipoMarcacion, control.getTipoMarcacion());
            
            dgvInfoConsolidar.Columns["descripColor"].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInfoConsolidar.Columns["codColor"].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInfoConsolidar.Columns["mCalculados"].HeaderCell.ToolTipText = "(Consumo * Total Unidades)*1.10";
            dgvInfoConsolidar.Columns["maSolicitar"].HeaderCell.ToolTipText = "M calculados -  M reservados";
            dgvInfoConsolidar.Columns["kgCalculados1"].HeaderCell.ToolTipText = "M a solicitar / Rendimiento";

            dgvTotalConsolidado.Columns["codigoColor"].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvTotalConsolidado.Columns["desColor"].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvTotalConsolidado.Columns["mCalcu"].HeaderCell.ToolTipText = "(Consumo * Total Unidades)*1.10";
            dgvTotalConsolidado.Columns["kgCalculados"].HeaderCell.ToolTipText = "M a solicitar / Rendimiento";

        }
        #endregion

        /// <summary>
        /// Se válida que en la lista (List<DetalleListaTela> listaSeleccionada) que llega al contructor por argumentos, tenga un atributo estado y que 
        /// este contenga valor de Solicitud de Inventario o Reserva Parcial, si cumple esta condición procede a llenar el encabezado  y las DataGridView de la vista actual.
        /// </summary>
        /// <param name="prmLista"> Lista de tipo DetalleListaTela, la cual representa las filas seleccionadas en el vista frmSolicitudListaTelas. </param>
        /// <param name="cont">Cantidad de filas que han sido seleccionadas en la vista frmSolicitudListaTelas.</param>
        private void Validaciones(List<MontajeTelaDetalle> prmLista, int numfilasSeleccionadas)
        {
            int b = 0;

            if (numfilasSeleccionadas >= 2)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {
                    if (prmLista[i].Estado == "Solicitud Inventario" || prmLista[i].Estado == "Reserva parcial" || prmLista[i].Estado == "Por Analizar")
                    {
                        b += 1;
                    }
                }
                if (b == prmLista.Count)
                {
                    this.Show();
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
                else
                {
                    MessageBox.Show("El estado de solicitud No corresponde a Solicitud de Inventario o Reserva Parcial.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Por favor seleccione al menos dos items.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
        
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
                    //prmLista[i].IdSolTela.ToString(),
                    //prmLista[i].IdDetalleSolicitud.ToString()
                    );

                    txtEnsayoRef.Text += prmLista[i].RefSimilar.ToString() + "\n";
                    txtDesPrenda.Text = prmLista[i].DescPrenda.ToString();
                   // idSolTela = prmLista[i].IdSolTela;
                    IdSolTela = prmLista[i].IdSolTela;
                    ListaIdSolicitudes.Add(prmLista[i].IdSolTela);
                    ListaEsayosRef.Add(prmLista[i].RefSimilar);
                }
                txtNomTela.Text = prmLista[0].DesTela.ToString();
                txtDisenador.Text = prmLista[0].Disenador.ToString();
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

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

        /*<summary> Permite el autocompletado de un comboBox </summary>
         * <param name="lista">Lista de tipo objeto</param>
         * <returns></returns>*/
        private AutoCompleteStringCollection cargarCombobox(List<Objeto> lista)
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            foreach (Objeto obj in lista)
            {
                datos.Add(obj.Nombre);
            }
            return datos;
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtRendimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.validarDecimal(sender, e);
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
        }

        private void dgvInfoConsolidar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 1 && e.ColumnIndex < 10 || e.ColumnIndex == 11)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }

        private void dgvTotalConsolidado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 1 && e.ColumnIndex <= 10)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }

        private void dgvTotalConsolidado_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                try
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
                catch
                {
                    dgvTotalConsolidado.CurrentCell.Value = "";
                    MessageBox.Show("Unicamente se permiten valores numéricos", "TTipo de dato no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvInfoConsolidar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10 || e.ColumnIndex == 12)
            {
                try
                {
                    if (dgvInfoConsolidar.CurrentCell.Value != null && dgvInfoConsolidar.CurrentCell.Value.ToString().Trim() != "")
                    {
                        if (dgvInfoConsolidar.CurrentCell.Value != null && dgvInfoConsolidar.CurrentCell.Value.ToString().Trim() != "")
                        {
                            decimal valor = decimal.Parse(dgvInfoConsolidar.CurrentCell.Value.ToString());
                            decimal vfinal = Decimal.Round(valor, 2);
                            dgvInfoConsolidar.CurrentCell.Value = valor;

                        }
                    }
                    if (dgvInfoConsolidar.Rows[e.RowIndex].Cells[12].Value.ToString() != "")
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value.ToString()) - decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[12].Value.ToString());
                    }
                }
                catch
                {
                    dgvInfoConsolidar.CurrentCell.Value = "";
                    MessageBox.Show("Unicamente se permiten valores numéricos", "TTipo de dato no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvTotalConsolidado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTotalConsolidado.CurrentRow.Cells[2].ReadOnly = true;
            dgvTotalConsolidado.CurrentRow.Cells[3].ReadOnly = true;
            dgvTotalConsolidado.CurrentRow.Cells[4].ReadOnly = true;
            dgvTotalConsolidado.CurrentRow.Cells[5].ReadOnly = true;
            dgvTotalConsolidado.CurrentRow.Cells[6].ReadOnly = true;
            dgvTotalConsolidado.CurrentRow.Cells[7].ReadOnly = true;
            dgvTotalConsolidado.CurrentRow.Cells[8].ReadOnly = true;
            dgvTotalConsolidado.CurrentRow.Cells[9].ReadOnly = true;
            dgvTotalConsolidado.CurrentRow.Cells[10].ReadOnly = true;
            dgvTotalConsolidado.CurrentRow.Cells[11].ReadOnly = true;

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

        private void txtRendimiento_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvTotalConsolidado.RowCount; i++)
            {
                if (txtRendimiento.Text != "")
                {
                    dgvTotalConsolidado.Rows[i].Cells[11].Value = Decimal.Round((decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString()) / decimal.Parse(txtRendimiento.Text)), 2);
                    dgvInfoConsolidar.Rows[i].Cells[14].Value = Decimal.Round((decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString()) / decimal.Parse(txtRendimiento.Text)), 2);
                }
                else
                {
                    dgvTotalConsolidado.Rows[i].Cells[11].Value = "";
                    dgvInfoConsolidar.Rows[i].Cells[14].Value = "";
                }
            }
        }

        /// <summary>
        /// Boton  confirmar el  sistema  genera   un  consecutivo   y   la   solicitud     cambie  al   estado   Radicado.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Consulta el número máximo que representa el último Consolidado actualizado en la tabla cfc_spt_tipo_solicitud
            int maxConsecutivo = control.consultarMaxConsolidado();
           
            // Se asignar valores para la fecha. 
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            
            // El estado que se le debe dar a solicitud cuando es confirmada
            string estado = "Radicado";

            if (id != 0)
            {
                for (int i = 0; i < ListaIdSolicitudes.Count; i++)
                {
                    control.agregarConsolidado(ListaIdSolicitudes[i], maxConsecutivo + 1, fechaActual, estado);
                }
                MessageBox.Show("La información se guardó con éxito. \n El estado se actualizó a Radicado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Deshabilita los diferentes botones y demás contenido del formulario que se quiere que no sea modificado una vez se confirme la solicitud.
                btnConfirmar.Enabled = false;
                btnGrabar.Enabled = false;
                pnlEmcabezado.Enabled = false;
                dgvInfoConsolidar.ReadOnly = true;
                dgvTotalConsolidado.ReadOnly = true;

                //consulta el consecutivo generado y se muestra en la vista.
                consecutivo = control.consultarConsecutivo(id);
                lblConsecutivo.Text = "Consecutivo: " + consecutivo;
            }
            else
            {
                MessageBox.Show("Por favor, Grabe la Información.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            bool b = false; 
            if (txtRendimiento.Text == "")
            {
                MessageBox.Show("Por favor, ingrese un valor para Rendimiento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }           
            else
            {
                if (cbxTipoMarcacion.SelectedIndex != -1)
                {
                    if (txtAnalista.Text != "")
                    {
                        if (txtDesPrenda.Text != "")
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
                                    //Se obtiene el encabezado de la vista.
                                    PedMontarUnicolor elemento = ObtenerEncabezado();
                                    if (control.consultarIdPedUnicolor(IdSolTela))
                                    {
                                        control.actualizarPedUnicolor(elemento);
                                        b = true;
                                    }
                                    else
                                    {
                                        control.addPedUnicolor(elemento);
                                    }
                                    //Agrega el Consolidado.
                                    AgregarConsolidado();

                                    //Consulta el id que se genero cuando se guarda la infromación del encabezado.
                                    id = control.getIdPedUnicolor(IdSolTela);

                                    //Lista con lis ids de cada uno de los detalles de la vista
                                    List<int> listaIDInfoConsolidar = control.getIdPedUnicolorInfoCon(id);
                                    List<int> listaIDtotalconsolidar = control.getIdPedUnicolorTotalCon(id);
                                    try
                                    {
                                        for (int i = 0; i < dgvInfoConsolidar.RowCount; i++)
                                        {
                                            //Se obtiene la informacion de la primera dataGridView (dgvInfoConsolidar)
                                            PedUnicolorInfoCon detalle = ObtenerInfoConsolidar(i);
                                            if (b)
                                            {
                                                if (i < listaIDInfoConsolidar.Count)
                                                {
                                                 control.actuPedUnicolorInfoCon(detalle, listaIDInfoConsolidar[i]);
                                                }
                                                else { control.addPedUnicolorInfoCon(detalle);}
                                            }
                                            else { control.addPedUnicolorInfoCon(detalle);}
                                        }
                                        for (int i = 0; i < dgvTotalConsolidado.RowCount; i++)
                                        {
                                            //Se obtiene la informacion de la segunada dataGridView (dgvTotalConsolidado)
                                            PedUnicolorTotalCon detalle = ObtenerTotalConsolidar(i);
                                            if (b)
                                            {
                                                if (i < listaIDtotalconsolidar.Count)
                                                {
                                                    control.actuaPedUnicolorTotalConsol(detalle, listaIDtotalconsolidar[i]);
                                                }
                                                else{control.addPedUnicolorTotalCons(detalle);}
                                            }
                                            else{control.addPedUnicolorTotalCons(detalle);}
                                        }

                                        MessageBox.Show("Pedido Unicolor se guardó con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Pedido Unicolor no se pudo guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        else
                        {
                            MessageBox.Show("Por favor, Ingrese un valor para Descripción Prenda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, Ingrese un valor para Analista Cortes B.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                   MessageBox.Show("Por favor, Seleccione un valor para Tipo de Marcación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
        /// <summary>
        /// Obtine todo los elementos del encabezado de la vista.
        /// </summary>
        /// <returns></returns>
        private PedMontarUnicolor ObtenerEncabezado()
        {
            PedMontarUnicolor elemento = new PedMontarUnicolor();
            elemento.NomTela = txtNomTela.Text.Trim();
            elemento.Disenador = txtDisenador.Text.Trim();
            elemento.Rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
            elemento.EnsayoRef = txtEnsayoRef.Text.Trim();
            elemento.DescPrenda = txtDesPrenda.Text.Trim();
            elemento.Clase = cbxClase.SelectedItem.ToString();
            elemento.TipoMarcacion = cbxTipoMarcacion.GetItemText(cbxTipoMarcacion.SelectedItem);
            elemento.Rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
            elemento.AnalistasCortesB = txtAnalista.Text.Trim();
            string fecha = dtpFechaLlegada.Value.ToString("dd/MM/yyyy");
            elemento.FechaLlegada = fecha;
            elemento.IdSolTela = IdSolTela;
            return elemento;
        }

        /// <summary>
        /// Se obtiene la informacion de la primera dataGridView (dgvInfoConsolidar)
        /// </summary>
        /// <param name="i">Índice de creación del objeto.</param>
        /// <returns>Retorna un objeto de tipo PedUnicolorInfoCon el cual representa una fila del dataGridView.</returns>
        private PedUnicolorInfoCon ObtenerInfoConsolidar(int i)
        {
            PedUnicolorInfoCon detalle = new PedUnicolorInfoCon();
            detalle.IdPedUnicolor = id;
            detalle.CodColor = (dgvInfoConsolidar.Rows[i].Cells[0].Value.ToString());
            detalle.DescColor = (dgvInfoConsolidar.Rows[i].Cells[1].Value != null && dgvInfoConsolidar.Rows[i].Cells[1].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[1].Value.ToString() : "";
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
            detalle.MSolicitar = (dgvInfoConsolidar.Rows[i].Cells[13].Value != null && dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[13].Value.ToString()) : 0;
            detalle.KgCalculados = (dgvInfoConsolidar.Rows[i].Cells[14].Value != null && dgvInfoConsolidar.Rows[i].Cells[14].Value.ToString() != "") ? decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[14].Value.ToString()) : 0;
            
            return detalle;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmImprimirPedUnicolor frmPedUnicolor = new frmImprimirPedUnicolor(control,IdSolTela);
            frmPedUnicolor.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        ///Se obtiene la informacion de la segunada dataGridView (dgvTotalConsolidado).
        /// </summary>
        /// <param name="i">Índice de creación del objeto.</param>
        /// <returns>Retorna un objeto de tipo PedUnicolorTotalCon el cual representa una fila del dataGridView.</returns>
        private PedUnicolorTotalCon ObtenerTotalConsolidar(int i)
        {
            PedUnicolorTotalCon detalle = new PedUnicolorTotalCon( );
            detalle.IdPedUnicolor = id;
            detalle.CodColor = (dgvTotalConsolidado.Rows[i].Cells[0].Value.ToString());
            detalle.DescColor = (dgvTotalConsolidado.Rows[i].Cells[1].Value != null && dgvTotalConsolidado.Rows[i].Cells[1].Value.ToString() != "") ? dgvTotalConsolidado.Rows[i].Cells[1].Value.ToString() : "";
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
            detalle.TotalPedir = (dgvTotalConsolidado.Rows[i].Cells[12].Value != null && dgvTotalConsolidado.Rows[i].Cells[12].Value.ToString() != "") ? decimal.Parse(dgvTotalConsolidado.Rows[i].Cells[12].Value.ToString()) : 0;
            detalle.UniMedida = (dgvTotalConsolidado.Rows[i].Cells[13].Value != null && dgvTotalConsolidado.Rows[i].Cells[13].Value.ToString() != "") ? dgvTotalConsolidado.Rows[i].Cells[13].Value.ToString() : "";
            return detalle;
        }

        /// <summary>
        /// Agrega el consolidado a lista de solicitudes seleccionadas en la vista frmSolicitudListaTelas
        /// </summary>
        private void AgregarConsolidado()
        {
            int maxConsolidado = control.consultarMaxConsolidado();
            for (int i = 0; i < ListaIdSolicitudes.Count; i++)
            {
                control.agregarConsolidado(ListaIdSolicitudes[i], maxConsolidado + 1, "","");
            }

        }

        private void Cargar()
        {
            PedMontarUnicolor objPedUnicolor = control.getPedUnicolor(IdSolTela);
            id = objPedUnicolor.IdPedUnicolor;
            if (id != 0)
            {
    
                txtNomTela.Text = objPedUnicolor.NomTela.ToString();
                txtDisenador.Text = objPedUnicolor.Disenador.ToString();
                txtEnsayoRef.Text = objPedUnicolor.EnsayoRef.ToString();
                txtDesPrenda.Text = objPedUnicolor.DescPrenda.ToString();
                cbxClase.Text = objPedUnicolor.Clase.ToString();
                cbxTipoMarcacion.Text = objPedUnicolor.TipoMarcacion.ToString();
                txtRendimiento.Text = objPedUnicolor.Rendimiento.ToString();
                txtAnalista.Text = objPedUnicolor.AnalistasCortesB.ToString();
                dtpFechaLlegada.Text = objPedUnicolor.FechaLlegada.ToString();

                /*Carga detalle Información a  Consolidar*/
                List<PedUnicolorInfoCon> listaInfoConsolidar = control.getPedUnicolorInfoCon(objPedUnicolor.IdPedUnicolor);
                if (listaInfoConsolidar.Count > 0)
                {
                    foreach (PedUnicolorInfoCon obj in listaInfoConsolidar)
                    {
                        dgvInfoConsolidar.Rows.Add(obj.CodColor, obj.DescColor, obj.Tiendas, obj.Exito,
                            obj.Cencosud, obj.Sao, obj.ComercioOrg, obj.Rosado, obj.Otros, obj.TotalUnidades, obj.Consumo, obj.MCalculados, obj.MReservados, obj.MSolicitar,obj.KgCalculados);
                    }
                }

                /*Carga detalle Toltal a  Consolidar*/
                List<PedUnicolorTotalCon> listaTotalConsolidado = control.getPedUnicolorTotalCon(objPedUnicolor.IdPedUnicolor);
                if (listaTotalConsolidado.Count > 0)
                {
                    foreach (PedUnicolorTotalCon obj in listaTotalConsolidado)
                    {
                        dgvTotalConsolidado.Rows.Add(obj.CodColor, obj.DescColor, obj.Tiendas, obj.Exito,
                            obj.Cencosud, obj.Sao, obj.ComercioOrg, obj.Rosado, obj.Otros, obj.TotalUnidades, obj.MCalculados, obj.KgCalculados, obj.TotalPedir, obj.UniMedida);
                    }
                }

                /*Esta bandera controla el cargue los dataGridView, es decir, si es true, en método  cargarDgvInfoConsolidar(prmLista) y cargarDgvTotalConsolidar(prmLista),
                 * no se ejecutan, debido a que la información ya esta guardada en la BD. */
                this.bandera = true;

            }
        }

    }
}
