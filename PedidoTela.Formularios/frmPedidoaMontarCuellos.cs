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
    public partial class frmPedidoaMontarCuellos : MaterialSkin.Controls.MaterialForm
    {
        #region Variables
        private Controlador control = new Controlador();
        List<MontajeTelaDetalle> detalleSeleccionado = new List<MontajeTelaDetalle>();
        List<int> listaIdSolicitudes = new List<int>();
        List<string> listaEsayosRef = new List<string>();
        int idSolicitudTelas, id,consecutivo=0;
        bool bandera = false;
        #endregion

        #region Setter && Getter
        public List<MontajeTelaDetalle> DetalleSeleccionado { get => detalleSeleccionado; set => detalleSeleccionado = value; }
        public List<int> ListaIdSolicitudes { get => listaIdSolicitudes; set => listaIdSolicitudes = value; }
        public List<string> ListaEsayosRef { get => listaEsayosRef; set => listaEsayosRef = value; }
        #endregion

        #region Constructor
        public frmPedidoaMontarCuellos(Controlador control, List<MontajeTelaDetalle> listaSeleccionada, int idsolTela)
        {
            InitializeComponent();
            dtpFechaLlegada.Format = DateTimePickerFormat.Custom;
            dtpFechaLlegada.CustomFormat = "dd/MM/yyyy";
            this.control = control;
            this.idSolicitudTelas = idsolTela;
            DetalleSeleccionado = listaSeleccionada;
        }
        #endregion

        #region Método Inicial de Carga
        private void frmPedidoaMontarCuellos_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
            Cargarsolicitudes(DetalleSeleccionado);
            CargarCombobox(cbxTipoMarcacion, control.getTipoMarcacion());
            Iniciar(DetalleSeleccionado);
        }
        #endregion

        #region Eventos

        private void txtAnalistas_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }
        
        private void dgvInfoConsolidar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12)
            {
                try
                {
                    if (dgvInfoConsolidar.CurrentCell.Value != null && dgvInfoConsolidar.CurrentCell.Value.ToString().Trim() != "")
                    {
                        decimal valor = decimal.Parse(dgvInfoConsolidar.CurrentCell.Value.ToString());
                        decimal vfinal = Decimal.Round(valor, 2);
                        dgvInfoConsolidar.CurrentCell.Value = valor;
                    }
                }
                catch (Exception ex)
                {
                    dgvInfoConsolidar.CurrentCell.Value = 0;
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            CalcularTotalesPorColores();
        }

        private void dgvProporcion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > 1 && e.ColumnIndex < 19)
            {
                try
                {
                    if (dgvProporcion.CurrentCell.Value != null && dgvProporcion.CurrentCell.Value.ToString().Trim() != "")
                    {
                        dgvProporcion.CurrentCell.Value = dgvProporcion.CurrentCell.Value.ToString().Replace(",", ".");
                        decimal valor = decimal.Parse(dgvProporcion.CurrentCell.Value.ToString());
                        decimal vfinal = Decimal.Round(valor, 2);
                        dgvProporcion.CurrentCell.Value = valor;
                    }
                }
                catch (Exception ex)
                {
                    dgvProporcion.CurrentCell.Value = 0;
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            CalcularTotalTallaPorColores();
        }


        private void dgvInfoConsolidar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvInfoConsolidar.CurrentRow.Cells[0].ReadOnly = true;
            dgvInfoConsolidar.CurrentRow.Cells[1].ReadOnly = true;

            if (e.RowIndex > -1 && e.ColumnIndex > 1 && e.ColumnIndex < 12)
            {
                frmBuscarColor buscarColor = new frmBuscarColor(control);
                buscarColor.StartPosition = FormStartPosition.CenterScreen;

                if (buscarColor.ShowDialog() == DialogResult.OK)
                {
                    Objeto obj = buscarColor.Elemento;

                    if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[2].Value = obj.Id;
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[3].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[4].Value = obj.Id;
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[5].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 6 || e.ColumnIndex == 7)
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[6].Value = obj.Id;
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[7].Value = obj.Nombre;

                    }
                    else if (e.ColumnIndex == 8 || e.ColumnIndex == 9)
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[8].Value = obj.Id;
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[9].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 10 || e.ColumnIndex == 11)
                    {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[10].Value = obj.Id;
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[11].Value = obj.Nombre;
                    }
                }
            }
        }

        private void dgvInfoConsolidar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 2)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }

        private void dgvProporcion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 19)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }

        private void dgvProporcion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvProporcion.CurrentRow.Cells[19].ReadOnly = true;
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                frmBuscarColor buscarColor = new frmBuscarColor(control);
                buscarColor.StartPosition = FormStartPosition.CenterScreen;
                if (buscarColor.ShowDialog() == DialogResult.OK)
                {
                    Objeto obj = buscarColor.Elemento;
                    dgvProporcion.Rows[e.RowIndex].Cells[0].Value = obj.Id;
                    dgvProporcion.Rows[e.RowIndex].Cells[1].Value = obj.Nombre;
                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[0].Value = obj.Id;
                    dgvInfoConsolidar.Rows[e.RowIndex].Cells[1].Value = obj.Nombre;
                }
            }
            CalcularTotalTallaPorColores();
        }

        /// <summary>
        /// Guarda toda la información de la vista. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGrabar_Click(object sender, EventArgs e)
        {    
            if (cbxTipoMarcacion.SelectedIndex != -1)
            {
                if (txtAnalistas.Text != "")
                {
                    if (txtDesPrenda.Text != "")
                    {
                       
                        if (dgvInfoConsolidar.RowCount > 0 && dgvProporcion.RowCount > 0)
                        {
                            bool vacio = false;
                            foreach (DataGridViewRow row in dgvInfoConsolidar.Rows)
                            {
                                if (row.Cells[12].Value == null || row.Cells[12].Value.ToString() == "")
                                {
                                    vacio = true;
                                }
                            }
                            if (!vacio)
                            {
                                //Se obtiene el encabezado de la vista.
                                PedidoAMontar elemento = ObtenerEncabezado();
                                if (control.existePedidoCuellos(idSolicitudTelas))
                                {
                                    control.actualizarPedidoCuellos(elemento);
                                }
                                else
                                {
                                    control.addPedidoCuellos(elemento);
                                }

                                //Consulta el id que se genero cuando se guarda la infromación del encabezado.
                                id = control.getIdPedidoCuellos(idSolicitudTelas);
                                if (id != 0)
                                {
                                    control.eliminarPedidoCuellosInformacion(id);
                                    control.eliminarPedidoCuellosProporcion(id);

                                    GuardarInformacionConsolidar(id);
                                    GuardarProporcion(id);
                                }
                                //Agrega el Consolidado.
                                AgregarConsolidado();
                                MessageBox.Show("Pedido Cuellos-Puños-Tiras se guardó con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                               MessageBox.Show("Por favor ingrese los valores para la columna: Total a pedir.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        /// <summary>
        ///  Imprime los datos del consolidado, una vez este se encuentre guardado. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PedidoAMontar objPedidoCuellos = control.getPedidoCuellos(idSolicitudTelas);
            if (objPedidoCuellos.Id >0)
            { 
                frmImprimirPedidoCuellos frmImprimirPedidoCuellos = new frmImprimirPedidoCuellos(control,idSolicitudTelas);
                frmImprimirPedidoCuellos.Show();
            }
            else
            {
                MessageBox.Show("El consolidado no ha sido guardado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Boton  confirmar, el  sistema  genera   un  consecutivo   y   la   solicitud     cambia  al   estado   Radicado.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int maxConsecutivo = control.consultarMaxConsecutivoPedido();
            // Se asignar valores para la fecha. 
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            // El estado que se le debe dar a solicitud cuando es confirmada

            string estado = "Radicado";

            if (id != 0)
            {
                for (int i = 0; i < ListaIdSolicitudes.Count; i++)
                {
                    control.agregarConsecutivo(ListaIdSolicitudes[i], maxConsecutivo + 1, fechaActual, estado);
                }
                MessageBox.Show("La información se guardó con éxito. \n El estado se actualizó a Radicado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Deshabilita los diferentes botones y demás contenido del formulario que se quiere que no sea modificado una vez se confirme la solicitud.
                btnConfirmar.Enabled = false;
                btnGrabar.Enabled = false;

                dgvInfoConsolidar.ReadOnly = true;
                dgvProporcion.ReadOnly = true;

                //consulta el consecutivo generado y se muestra en la vista.
                consecutivo = control.consultarConsecutivoPedido(idSolicitudTelas);
                lblConsecutivo.Text = "Consecutivo: " + consecutivo;
            }
            else
            {
                MessageBox.Show("Por favor, Grabe la Información.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        /// <summary>
        /// Cierra la vista.
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
        /// <param name="prmLista"></param>
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
        /// Busca la informaón en las respectivas entidades si encuentra dastos los carga y la bandera el True, de lo contrario la bandera es False y se procede a 
        /// cargar la vista con la informacion que se ha seleccionado de la vista anterior.
        /// </summary>
        /// <param name="prmLista"> Lista de tipo MontajeTelaDetalle, la cual representa las filas seleccionadas en el vista  inicial de selección (frmSolicitudListaTelas). </param>
        private void Iniciar(List<MontajeTelaDetalle> prmLista)
        {
            List<int> idDetalleCuellos = new List<int>();
            Cargar();
            // Bandera controlada en el método Cargar()
            if (!this.bandera)
            {
                //Carga el DataGridView (dgvInfoConsolidar) el cual pertenece a la sección de información a consolidar.
                CargarDgvInfoConsolidar(prmLista);
                CargarDgvCuellos(prmLista);
            }

        }

        /// <summary>
        /// Carga la informacion de los ComboBox.
        /// </summary>
        /// <param name="combo"></param>
        /// <param name="lista"></param>
        private void CargarCombobox(ComboBox combo, List<Objeto> lista)
        {
            combo.DataSource = lista;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "Id";
            combo.SelectedIndex = -1;
            combo.AutoCompleteCustomSource = CargarCombobox(lista);
            combo.AutoCompleteMode = AutoCompleteMode.Suggest;
            combo.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        ///<summary> Permite el autocompletado de un comboBox </summary>
        /// <param name="lista">Lista de tipo objeto</param>
        ///<returns></returns>*/
        private AutoCompleteStringCollection CargarCombobox(List<Objeto> lista)
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            foreach (Objeto obj in lista)
            {
                datos.Add(obj.Nombre);
            }
            return datos;
        }

        /// <summary>
        /// Carga el primer DataGridView expuesto en la vista, corresponde a información a consolidar.
        /// </summary>
        /// <param name="prmLista">Lista de tipo MontajeTelaDetalle, representa las filas seleccionadas en el vista de filtros (frmSolicitudListaTelas).</param>
        private void CargarDgvInfoConsolidar(List<MontajeTelaDetalle> prmLista)
        {
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {
                    dgvInfoConsolidar.Rows.Add(prmLista[i].Vte.ToString(),
                    prmLista[i].DesColor.ToString(),
                    prmLista[i].CodigoH1.ToString(),
                    prmLista[i].DescripcionH1.ToString(),
                    prmLista[i].CodigoH2.ToString(),
                    prmLista[i].DescripcionH2.ToString(),
                    prmLista[i].CodigoH3.ToString(),
                    prmLista[i].DescripcionH3.ToString(),
                    prmLista[i].CodigoH4.ToString(),
                    prmLista[i].DescripcionH4.ToString(),
                    prmLista[i].CodigoH5.ToString(),
                    prmLista[i].DescripcionH5.ToString(),
                    prmLista[i].TotaUnidades.ToString()
                    );

                    txtEnsayoRef.Text += prmLista[i].RefSimilar.ToString() + "\n";
                    // ListaIdSolicitudes.Add(prmLista[i].IdSolTela);
                    ListaEsayosRef.Add(prmLista[i].RefSimilar);
                }
                txtDesPrenda.Text = prmLista[0].DescPrenda.ToString();
                txtDisenador.Text = prmLista[0].Disenador.ToString();
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Carga el segundo DatagridView expuesto en la vista, correspondienta a Proporcion.
        /// </summary>
        /// <param name="prmLista">Lista de tipo MontajeTelaDetalle, representa las filas seleccionadas en la vista de filtros (frmSolicitudListaTelas)  </param>
        private void CargarDgvCuellos(List<MontajeTelaDetalle> prmLista)
        {
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {
                    dgvProporcion.Rows.Add(prmLista[i].Vte.ToString(),
                    prmLista[i].DesColor.ToString(),
                    "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "",
                    prmLista[i].TotaUnidades.ToString()
                    );
                }
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Actualiza el total unidades de la DatagridView (dgvProporcion) una vez sea editado dicho campo en el DatagridView (dgvInformacionConsolidar).
        /// </summary>
        private void CalcularTotalesPorColores()
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
                        objColor.TotalUnidades += (dgvInfoConsolidar.Rows[i].Cells[12].Value != null && dgvInfoConsolidar.Rows[i].Cells[12].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[12].Value.ToString()) : 0;
                    }
                }
                totales.Add(objColor);
            }

            if (totales.Count != 0)
            {
                //Si hay más filas en total consolidado que colores se eliminan filas
                if (totales.Count < dgvProporcion.Rows.Count)
                {
                    for (int i = totales.Count; i < dgvProporcion.Rows.Count; i++)
                    {
                        dgvProporcion.Rows.RemoveAt(i);
                    }
                }//Si hay más colores que filas en total consolidado se agregan filas
                else if (totales.Count > dgvProporcion.Rows.Count)
                {
                    for (int i = dgvProporcion.Rows.Count; i < totales.Count; i++)
                    {
                        dgvProporcion.Rows.Add();
                    }
                }
                //Se agrega la información en las filas
                for (int i = 0; i < totales.Count; i++)
                {
                    dgvProporcion.Rows[i].Cells[0].Value = totales[i].CodidoColor;
                    dgvProporcion.Rows[i].Cells[1].Value = totales[i].DescripcionColor.ToUpper();
                    dgvProporcion.Rows[i].Cells[19].Value = totales[i].TotalUnidades.ToString();

                }
            }
        }

        /// <summary>
        /// Suma los valores de las tallas en el DatagridView (dgvProporcion) una vez se modifique el color, también actualia el DatagridView (dgvInfoConsolidar).
        /// </summary>
        private void CalcularTotalTallaPorColores()
        {
            List<Objeto> colores = new List<Objeto>();
            for (int i = 0; i < dgvProporcion.RowCount; i++)
            {
                Objeto color = new Objeto();
                color.Id = dgvProporcion.Rows[i].Cells[0].Value.ToString().ToLower();
                color.Nombre = dgvProporcion.Rows[i].Cells[1].Value.ToString().ToLower();
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
            
            List<PedidoCuellos> totales = new List<PedidoCuellos>();
            foreach (Objeto obj in colores)
            {
                PedidoCuellos objColor = new PedidoCuellos( obj.Id, obj.Nombre);
                for (int i = 0; i < dgvProporcion.RowCount; i++)
                {
                    if (dgvProporcion.Rows[i].Cells[1].Value.ToString().ToLower() == obj.Nombre)
                    {

                        objColor.Xs += (dgvProporcion.Rows[i].Cells[2].Value != null && dgvProporcion.Rows[i].Cells[2].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[2].Value.ToString()) : 0;
                        objColor.S += (dgvProporcion.Rows[i].Cells[3].Value != null && dgvProporcion.Rows[i].Cells[3].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[3].Value.ToString()) : 0;
                        objColor.M += (dgvProporcion.Rows[i].Cells[4].Value != null && dgvProporcion.Rows[i].Cells[4].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[4].Value.ToString()) : 0;
                        objColor.L += (dgvProporcion.Rows[i].Cells[5].Value != null && dgvProporcion.Rows[i].Cells[5].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[5].Value.ToString()) : 0;
                        objColor.Xl += (dgvProporcion.Rows[i].Cells[6].Value != null && dgvProporcion.Rows[i].Cells[6].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[6].Value.ToString()) : 0;
                        objColor.Dosxl += (dgvProporcion.Rows[i].Cells[7].Value != null && dgvProporcion.Rows[i].Cells[7].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[7].Value.ToString()) : 0;
                        objColor.Cuatro += (dgvProporcion.Rows[i].Cells[8].Value != null && dgvProporcion.Rows[i].Cells[8].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[8].Value.ToString()) : 0;
                        objColor.Seis += (dgvProporcion.Rows[i].Cells[9].Value != null && dgvProporcion.Rows[i].Cells[9].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[9].Value.ToString()) : 0;
                        objColor.Ocho += (dgvProporcion.Rows[i].Cells[10].Value != null && dgvProporcion.Rows[i].Cells[10].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[10].Value.ToString()) : 0;
                        objColor.Diez += (dgvProporcion.Rows[i].Cells[11].Value != null && dgvProporcion.Rows[i].Cells[11].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[11].Value.ToString()) : 0;
                        objColor.Doce += (dgvProporcion.Rows[i].Cells[12].Value != null && dgvProporcion.Rows[i].Cells[12].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[12].Value.ToString()) : 0;
                        objColor.Catorce += (dgvProporcion.Rows[i].Cells[13].Value != null && dgvProporcion.Rows[i].Cells[13].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[13].Value.ToString()) : 0;
                        objColor.Dieciseis += (dgvProporcion.Rows[i].Cells[14].Value != null && dgvProporcion.Rows[i].Cells[14].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[14].Value.ToString()) : 0;
                        objColor.Dieciocho += (dgvProporcion.Rows[i].Cells[15].Value != null && dgvProporcion.Rows[i].Cells[15].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[15].Value.ToString()) : 0;
                        objColor.Veinte += (dgvProporcion.Rows[i].Cells[16].Value != null && dgvProporcion.Rows[i].Cells[16].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[16].Value.ToString()) : 0;
                        objColor.Veintidos += (dgvProporcion.Rows[i].Cells[17].Value != null && dgvProporcion.Rows[i].Cells[17].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[17].Value.ToString()) : 0;
                        objColor.Veinticuatro += (dgvProporcion.Rows[i].Cells[18].Value != null && dgvProporcion.Rows[i].Cells[18].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[18].Value.ToString()) : 0;
                        objColor.TotalUnidades += (dgvProporcion.Rows[i].Cells[19].Value != null && dgvProporcion.Rows[i].Cells[19].Value.ToString() != "") ? int.Parse(dgvProporcion.Rows[i].Cells[19].Value.ToString()) : 0;
                    }
                }
                totales.Add(objColor);
            }

            if (totales.Count != 0)
            {
                //Si hay más filas en total consolidado que colores se eliminan filas
                if (totales.Count < dgvProporcion.Rows.Count)
                {
                    for (int i = totales.Count; i < dgvProporcion.Rows.Count; i++)
                    {
                        dgvProporcion.Rows.RemoveAt(i);
                        //dgvInfoConsolidar.Rows.Add();
                        //dgvInfoConsolidar.Rows.RemoveAt(i);
                    }
                }//Si hay más colores que filas en total consolidado se agregan filas
                else if (totales.Count > dgvInfoConsolidar.Rows.Count)
                {
                    for (int i = dgvInfoConsolidar.Rows.Count; i < totales.Count; i++)
                    {
                        dgvInfoConsolidar.Rows.Add();

                    }
                }
               
                //Se agrega la información en las filas
                for (int i = 0; i < totales.Count; i++)
                {
                    dgvInfoConsolidar.Rows[i].Cells[0].Value = dgvProporcion.Rows[i].Cells[0].Value;
                    //dgvInfoConsolidar.Rows[i].Cells[1].Value = totales[i].DescripcionVte.ToUpper();
                    dgvInfoConsolidar.Rows[i].Cells[1].Value = dgvProporcion.Rows[i].Cells[1].Value;
                    dgvInfoConsolidar.Rows[i].Cells[12].Value = totales[i].TotalUnidades.ToString();

                    
                   dgvProporcion.Rows[i].Cells[0].Value = totales[i].CodigoVte.ToString();
                   dgvProporcion.Rows[i].Cells[1].Value = totales[i].DescripcionVte.ToString().ToUpper();
                   dgvProporcion.Rows[i].Cells[2].Value = totales[i].Xs.ToString();
                   dgvProporcion.Rows[i].Cells[3].Value = totales[i].S.ToString();
                   dgvProporcion.Rows[i].Cells[4].Value = totales[i].M.ToString();
                   dgvProporcion.Rows[i].Cells[5].Value = totales[i].L.ToString();
                   dgvProporcion.Rows[i].Cells[6].Value = totales[i].Xl.ToString();
                   dgvProporcion.Rows[i].Cells[7].Value = totales[i].Dosxl.ToString();
                   dgvProporcion.Rows[i].Cells[8].Value = totales[i].Cuatro.ToString();
                   dgvProporcion.Rows[i].Cells[9].Value = totales[i].Seis.ToString();
                   dgvProporcion.Rows[i].Cells[10].Value = totales[i].Ocho.ToString();
                   dgvProporcion.Rows[i].Cells[11].Value = totales[i].Diez.ToString();
                   dgvProporcion.Rows[i].Cells[12].Value = totales[i].Doce.ToString();
                   dgvProporcion.Rows[i].Cells[13].Value = totales[i].Catorce.ToString();
                   dgvProporcion.Rows[i].Cells[14].Value = totales[i].Dieciseis.ToString();
                   dgvProporcion.Rows[i].Cells[15].Value = totales[i].Dieciocho.ToString();
                   dgvProporcion.Rows[i].Cells[16].Value = totales[i].Veinte.ToString();
                   dgvProporcion.Rows[i].Cells[17].Value = totales[i].Veintidos.ToString();
                   dgvProporcion.Rows[i].Cells[18].Value = totales[i].Veinticuatro.ToString();
                   dgvProporcion.Rows[i].Cells[19].Value = totales[i].TotalUnidades.ToString();
                   
                }
            }
        }

        /// <summary>
        /// Agrega el consolidado a lista de solicitudes seleccionadas en la vista frmSolicitudListaTelas, al momento de clickear en el btn Guardar.
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
        /// Obtiene la información correspondiente al encabezado de la vista.
        /// </summary>
        /// <returns>Retorna un objeto de tipo PedidoaMontar, representa la informacion ingresada y/o consultada en la vista.</returns>
        private PedidoAMontar ObtenerEncabezado()
        {
            PedidoAMontar elemento = new PedidoAMontar();
            elemento.EnsayoReferencia = txtEnsayoRef.Text.Trim();
            elemento.Disenador = txtDisenador.Text.Trim();
            elemento.AnalistasCortesB = txtAnalistas.Text.Trim();
            string fecha = dtpFechaLlegada.Value.ToString("dd/MM/yyyy");
            elemento.FechaLlegada = fecha;
            //elemento.TipoMarcacion = ((Objeto)cbxTipoMarcacion.SelectedItem).Nombre;
            elemento.TipoMarcacion = cbxTipoMarcacion.GetItemText(cbxTipoMarcacion.SelectedItem);
            elemento.DescripcionPrenda = txtDesPrenda.Text.Trim();
            elemento.IdSolicitud = idSolicitudTelas;
            return elemento;
        }
        
        /// <summary>
        /// Guarda la información del primer DataGridView presente en la vista.
        /// </summary>
        /// <param name="id">Id del Pedido Cuellos-Tiras-Puños </param>
        private void GuardarInformacionConsolidar(int id)
        {
            for (int i = 0; i < dgvInfoConsolidar.RowCount; i++)
            {
                PedidoMontarInformacion detalle = new PedidoMontarInformacion();
                detalle.IdPedidoAMontar = id;
                detalle.CodigoColor = (dgvInfoConsolidar.Rows[i].Cells[0].Value.ToString());
                detalle.DescripcionColor = (dgvInfoConsolidar.Rows[i].Cells[1].Value != null && dgvInfoConsolidar.Rows[i].Cells[1].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[1].Value.ToString() : "";
                detalle.CodigoH1 = (dgvInfoConsolidar.Rows[i].Cells[2].Value != null && dgvInfoConsolidar.Rows[i].Cells[2].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[2].Value.ToString() : "";
                detalle.DescripcionH1 = (dgvInfoConsolidar.Rows[i].Cells[3].Value != null && dgvInfoConsolidar.Rows[i].Cells[3].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[3].Value.ToString() : "";
                detalle.CodigoH2 = (dgvInfoConsolidar.Rows[i].Cells[4].Value != null && dgvInfoConsolidar.Rows[i].Cells[4].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[4].Value.ToString() : "";
                detalle.DescripcionH2 = (dgvInfoConsolidar.Rows[i].Cells[5].Value != null && dgvInfoConsolidar.Rows[i].Cells[5].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[5].Value.ToString() : "";
                detalle.CodigoH3 = (dgvInfoConsolidar.Rows[i].Cells[6].Value != null && dgvInfoConsolidar.Rows[i].Cells[6].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[6].Value.ToString() : "";
                detalle.DescripcionH3 = (dgvInfoConsolidar.Rows[i].Cells[7].Value != null && dgvInfoConsolidar.Rows[i].Cells[7].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[7].Value.ToString() : "";
                detalle.CodigoH4 = (dgvInfoConsolidar.Rows[i].Cells[8].Value != null && dgvInfoConsolidar.Rows[i].Cells[8].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[8].Value.ToString() : "";
                detalle.DescripcionH4 = (dgvInfoConsolidar.Rows[i].Cells[9].Value != null && dgvInfoConsolidar.Rows[i].Cells[9].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[9].Value.ToString() : "";
                detalle.CodigoH5 = (dgvInfoConsolidar.Rows[i].Cells[10].Value != null && dgvInfoConsolidar.Rows[i].Cells[10].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[10].Value.ToString() : "";
                detalle.DescripcionH5 = (dgvInfoConsolidar.Rows[i].Cells[11].Value != null && dgvInfoConsolidar.Rows[i].Cells[11].Value.ToString() != "") ? dgvInfoConsolidar.Rows[i].Cells[11].Value.ToString() : "";
                detalle.TotalUnidades = (dgvInfoConsolidar.Rows[i].Cells[12].Value != null && dgvInfoConsolidar.Rows[i].Cells[12].Value.ToString() != "") ? int.Parse(dgvInfoConsolidar.Rows[i].Cells[12].Value.ToString()) : 0;
                control.addPedidoCuellosInfo(detalle);
            }
        }

        /// <summary>
        /// Guarda la información del segundo DatagridView presente en la vista.
        /// </summary>
        /// <param name="id">Id del Pedido Cuellos-Tiras-Puños</param>
        private void GuardarProporcion(int id)
        {
            for(int i=0; i<dgvProporcion.RowCount; i++)
            {
                PedidoCuellos detalle = new PedidoCuellos();
                detalle.IdPedidoCuellos = id;
                detalle.CodigoVte = (dgvProporcion.Rows[i].Cells[0].Value.ToString());
                detalle.DescripcionVte = (dgvProporcion.Rows[i].Cells[1].Value != null && dgvProporcion.Rows[i].Cells[1].Value.ToString() != "") ? dgvProporcion.Rows[i].Cells[1].Value.ToString() : "";
                detalle.Xs = (dgvProporcion.Rows[i].Cells[2].Value != null && dgvProporcion.Rows[i].Cells[2].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[2].Value.ToString()) : 0;
                detalle.S = (dgvProporcion.Rows[i].Cells[3].Value != null && dgvProporcion.Rows[i].Cells[3].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[3].Value.ToString()) : 0;
                detalle.M = (dgvProporcion.Rows[i].Cells[4].Value != null && dgvProporcion.Rows[i].Cells[4].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[4].Value.ToString()) : 0;
                detalle.L = (dgvProporcion.Rows[i].Cells[5].Value != null && dgvProporcion.Rows[i].Cells[5].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[5].Value.ToString()) : 0;
                detalle.Xl = (dgvProporcion.Rows[i].Cells[6].Value != null && dgvProporcion.Rows[i].Cells[6].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[6].Value.ToString()) : 0;
                detalle.Dosxl = (dgvProporcion.Rows[i].Cells[7].Value != null && dgvProporcion.Rows[i].Cells[7].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[7].Value.ToString()) : 0;
                detalle.Cuatro = (dgvProporcion.Rows[i].Cells[8].Value != null && dgvProporcion.Rows[i].Cells[8].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[8].Value.ToString()) : 0;
                detalle.Seis = (dgvProporcion.Rows[i].Cells[9].Value != null && dgvProporcion.Rows[i].Cells[9].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[9].Value.ToString()) : 0;
                detalle.Ocho = (dgvProporcion.Rows[i].Cells[10].Value != null && dgvProporcion.Rows[i].Cells[10].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[10].Value.ToString()) : 0;
                detalle.Diez = (dgvProporcion.Rows[i].Cells[11].Value != null && dgvProporcion.Rows[i].Cells[11].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[11].Value.ToString()) : 0;
                detalle.Doce = (dgvProporcion.Rows[i].Cells[12].Value != null && dgvProporcion.Rows[i].Cells[12].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[12].Value.ToString()) : 0;
                detalle.Catorce = (dgvProporcion.Rows[i].Cells[13].Value != null && dgvProporcion.Rows[i].Cells[13].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[13].Value.ToString()) : 0;
                detalle.Dieciseis = (dgvProporcion.Rows[i].Cells[14].Value != null && dgvProporcion.Rows[i].Cells[14].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[14].Value.ToString()) : 0;
                detalle.Dieciocho = (dgvProporcion.Rows[i].Cells[15].Value != null && dgvProporcion.Rows[i].Cells[15].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[15].Value.ToString()) : 0;
                detalle.Veinte = (dgvProporcion.Rows[i].Cells[16].Value != null && dgvProporcion.Rows[i].Cells[16].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[16].Value.ToString()) : 0;
                detalle.Veintidos = (dgvProporcion.Rows[i].Cells[17].Value != null && dgvProporcion.Rows[i].Cells[17].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[17].Value.ToString()) : 0;
                detalle.Veinticuatro = (dgvProporcion.Rows[i].Cells[18].Value != null && dgvProporcion.Rows[i].Cells[18].Value.ToString() != "") ? decimal.Parse(dgvProporcion.Rows[i].Cells[18].Value.ToString()) : 0;
                detalle.TotalUnidades = (dgvProporcion.Rows[i].Cells[19].Value != null && dgvProporcion.Rows[i].Cells[19].Value.ToString() != "") ? int.Parse(dgvProporcion.Rows[i].Cells[19].Value.ToString()) : 0;
                control.addPedidoCuellosProporcion(detalle);
            }
        }
        
        /// <summary>
        /// Permite el cargue de los datos correspondientes a vista.
        /// </summary>
        private void Cargar()
        {
            PedidoAMontar objPedUnicolor = control.getPedidoCuellos(idSolicitudTelas);
            id = objPedUnicolor.Id;
            if (id != 0)
            {
                txtEnsayoRef.Text = objPedUnicolor.EnsayoReferencia.ToString();
                txtDisenador.Text = objPedUnicolor.Disenador.ToString();
                txtAnalistas.Text = objPedUnicolor.AnalistasCortesB.ToString();
                dtpFechaLlegada.Text = objPedUnicolor.FechaLlegada.ToString();
                cbxTipoMarcacion.Text = objPedUnicolor.TipoMarcacion.ToString();
                txtDesPrenda.Text = objPedUnicolor.DescripcionPrenda.ToString();

                /*Carga detalle Información a  Consolidar*/
                List<PedidoMontarInformacion> listaInfoConsolidar = control.getPedidoCuellosInfo(objPedUnicolor.Id);
                if (listaInfoConsolidar.Count > 0)
                {
                    foreach (PedidoMontarInformacion obj in listaInfoConsolidar)
                    {
                        dgvInfoConsolidar.Rows.Add(obj.CodigoColor, obj.DescripcionColor, obj.CodigoH1, obj.DescripcionH1, obj.CodigoH2, obj.DescripcionH2, obj.CodigoH3, obj.DescripcionH3, obj.CodigoH4, obj.DescripcionH4, obj.CodigoH5, obj.DescripcionH5, obj.TotalUnidades);
                    }
                }

                /*Carga detalle Toltal a  Consolidar*/
                List<PedidoCuellos> listaProporcion = control.getPedidoCuellosProporcion(objPedUnicolor.Id);
                if (listaProporcion.Count > 0)
                {
                    foreach (PedidoCuellos obj in listaProporcion)
                    {
                        dgvProporcion.Rows.Add(obj.CodigoVte, obj.DescripcionVte, obj.Xs, obj.S, obj.M, obj.L, obj.Xl, obj.Dosxl, obj.Cuatro, obj.Seis, obj.Ocho, obj.Diez, obj.Doce, obj.Catorce, obj.Dieciseis, obj.Dieciocho, obj.Veinte, obj.Veintidos, obj.Veinticuatro, obj.TotalUnidades);
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
