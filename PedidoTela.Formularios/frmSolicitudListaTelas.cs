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
        Controlador controlador = new Controlador();
        Validar validacion = new Validar();
        
        List<DetalleListaTela> detalle = new List<DetalleListaTela>();
        Utilidades utilidades = new Utilidades();
        string validarCoordinado = "";
        int idSolicitudTelas = 0;

        public List<DetalleListaTela> Detalle { get => detalle; set => detalle = value; }
       
        public frmSolicitudListaTelas()
        {
            InitializeComponent();
            dtpFechaTienda.Format = DateTimePickerFormat.Custom;
            dtpFechaTienda.CustomFormat = "dd/MM/yyyy";
            txbEstado.CharacterCasing = CharacterCasing.Upper;
            txbClase.CharacterCasing = CharacterCasing.Upper;
            btnConsolidar.Enabled = false;
            btnVerDetalle.Enabled = false;
            btnImprimir.Enabled = false;
            btnEditar.Enabled = false;
            btnDevolucion.Enabled = false;


            // ToolTips
            this.ttMuestrario.SetToolTip(this.cbxMuestrario, "Campo Obligatorio");
        }
        
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
        /// Consulta en la base de datos, según los filtros (comboBox) seleccionados, luego procede a llenar la DatagridView con la infromación traida.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            ListaTela objTela = new ListaTela();
            if (cbxMuestrario.SelectedIndex == -1)
            {
                MessageBox.Show("Campo obligatorio,Por favor, seleccione un valor para Tipo Muestrario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //string fecha = "";
                //if (dtpFechaTienda.Value.ToString("dd/MM/yyyy") != "01/01/1753")
                //{
                //   fecha = dtpFechaTienda.Value.ToString("dd/MM/yyyy");
                //}
                string fecha = dtpFechaTienda.Value.ToString("dd/MM/yyyy");
               

                objTela.TipoSolicitud = (cbxTipoSolicitud.SelectedIndex != -1 && cbxTipoSolicitud.SelectedItem.ToString() != "") ? cbxTipoSolicitud.SelectedText.ToString() : "";
                objTela.Muestrario = cbxMuestrario.GetItemText(cbxMuestrario.SelectedItem);
                objTela.OcasionUso = cbxOcasionUso.GetItemText(cbxOcasionUso.SelectedItem);
                objTela.Tema = cbxTema.GetItemText(cbxTema.SelectedItem);
                objTela.Entrada = cbxEntrada.GetItemText(cbxEntrada.SelectedItem);
                objTela.Disenador = cbxDisenador.GetItemText(cbxDisenador.SelectedItem);
                objTela.EnsayoRefSimilar = txbEnsayoRef.Text.Trim();
                objTela.Estado = txbEstado.Text.Trim();
                
                objTela.FechaTienda = fecha;
                objTela.RefTela = cbxRefTela.GetItemText(cbxRefTela.SelectedItem);
                objTela.NomTela = cbxNomTela.GetItemText(cbxNomTela.SelectedItem);
                objTela.Solicitud = txbSolicitud.Text.Trim();
                objTela.Color = cbxColor.GetItemText(cbxColor.SelectedItem);
                objTela.Clase = txbClase.Text.Trim();   
                objTela.Coordinado = validarCoordinado;
                objTela.NumDibujo = txbNdibujo.Text.Trim();

                dgvSolicitudTelas.Rows.Clear();
                Detalle = controlador.consultarListaTelas(objTela);
                cargarDataGridView(Detalle);
                //// Vacía las cajas de texto del plIncial 
                //validacion.limpiar(pnlInicial);
                ////Limpian los ComboBox 
                //cbxMuestrario.SelectedIndex = -1;
                //cbxTipoSolicitud.SelectedIndex = -1;
                //cbxOcasionUso.SelectedIndex = -1;
                //cbxTema.SelectedIndex = -1;
                //cbxEntrada.SelectedIndex = -1;
                //cbxDisenador.SelectedIndex = -1;
                //cbxNomTela.SelectedIndex = -1;
                //cbxRefTela.SelectedIndex = -1;
                //cbxColor.SelectedIndex = -1;

              }


        }
       
        /// <summary>
        /// Llena el DataGridview con la información filtrada y consultada.
        /// </summary>
        /// <param name="prmLista">Lista de tipo DetalleListaTela, información para llenar el DataGridView.</param>
        private void cargarDataGridView(List<DetalleListaTela> prmLista)
        {
            
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {
                    if (prmLista[i].Coordinado == "f")
                    {
                        prmLista[i].Coordinado = "NO";
                    } else if (prmLista[i].Coordinado == "t")
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
                    prmLista[i].DescPrenda.ToString()
                    );
                    this.idSolicitudTelas = prmLista[i].IdSolTela;
                 
                }
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            List<DetalleListaTela> listaFilasSeleccionadas = ListaFilasSeleccionadas();
            frmAnalizarInventario frmAnalizarInventario = new frmAnalizarInventario(controlador, listaFilasSeleccionadas, contador);
         
        }
       
        /// <summary>
        /// Permite abrir la vista Agencias Externos a Traves del Botón InventarioExterno
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInventarioExt_Click(object sender, EventArgs e)
        {
            /// Cuenta cuantas filas de la DataGridView (dgvSolicitudTelas) en la vista frmSolicitudListaTelas ha sido chequeada (seleccionada).
            int contador = utilidades.ContarChecked(dgvSolicitudTelas);
            /// Realiza el respectivo método que retorna la lista de filas Seleccionadas
            List<DetalleListaTela> listaFilasSeleccionadas = ListaFilasSeleccionadas();
            FrmAgenciasExternos frmAgenciasExterno = new FrmAgenciasExternos(controlador, listaFilasSeleccionadas, contador, idSolicitudTelas);
        }
        
        /// <summary>
        /// Genera una lista de tipo DetalleListaTela, la cual es representada por las filas seleccionadas en la dataGridView (dgvSolicitudTelas) es decir 
        /// en la vista frmSolicitudListaTelas, para más comprensión son las filas Chequedas. 
        /// </summary>
        /// <returns>Retorna una Lista de Tipo DetalleLista, que representas las filas seleccionadas.</returns>
        private List<DetalleListaTela> ListaFilasSeleccionadas()
        {
            List<DetalleListaTela> listaSeleccionadas = new List<DetalleListaTela>();
            //int contador = utilidades.ContarChecked(dgvSolicitudTelas);

            for (int i = 0; i <= dgvSolicitudTelas.RowCount - 1; i++)
            {

                if (Convert.ToBoolean(dgvSolicitudTelas.Rows[i].Cells["sel"].Value) == true)
                {
                    DetalleListaTela objInfo = new DetalleListaTela();

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
                    objInfo.Tiendas = Detalle[i].Tiendas.ToString();
                    objInfo.Exito = Detalle[i].Exito.ToString();
                    objInfo.Cencosud = Detalle[i].Cencosud.ToString();
                    objInfo.Sao = Detalle[i].Sao.ToString();
                    objInfo.Comercio = Detalle[i].Comercio.ToString();
                    objInfo.Rosado = Detalle[i].Rosado.ToString();
                    objInfo.Otros = Detalle[i].Otros.ToString();
                    objInfo.MCalculados = utilidades.mCalculados2(dgvSolicitudTelas.Rows[i].Cells[15].Value.ToString(), dgvSolicitudTelas.Rows[i].Cells[16].Value.ToString());

                    objInfo.MReservados = Detalle[i].MReservados.ToString();
                    objInfo.Masolicitar = utilidades.mSolicitar(objInfo.MCalculados, Detalle[i].MReservados.ToString());
                    controlador.setMCalculados(int.Parse(dgvSolicitudTelas.Rows[i].Cells[28].Value.ToString()), utilidades.mCalculados2(dgvSolicitudTelas.Rows[i].Cells[15].Value.ToString(), dgvSolicitudTelas.Rows[i].Cells[16].Value.ToString()));
                    objInfo.CantidadReservado = (Detalle[i].CantidadReservado != null && Detalle[i].CantidadReservado != "") ? Detalle[i].CantidadReservado : "0";
                    objInfo.IdSolTela = Detalle[i].IdSolTela;
                    objInfo.IdDetalleSolicitud = Detalle[i].IdDetalleSolicitud;
                    objInfo.IdProgramador = Detalle[i].IdProgramador;
                    objInfo.DescPrenda = Detalle[i].DescPrenda;

                    listaSeleccionadas.Add(objInfo);
                }


            }
            return listaSeleccionadas;
        }
        
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
        /// Verifica que coordinadoNo, es checked entonces el Sicoordinado el false.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxNoCoordinado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNoCoordinado.Checked)
            {
                cbxSiCoordinado.Checked = false;
                validarCoordinado = "false";

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
                validarCoordinado = "true";
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
        /// Permite Salir de la vista actual, llevando al usuario a la vista inicial
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmInicial frmInicial = new frmInicial();
            this.Close();
            frmInicial.Show();
        }

      
    }
}
