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
        private string idmundo;
        private string codi_capsula;
        private string codi_entrada;
        private string muestrario;
        private string id_disenador;
        private string codi_linea;
        private string idProgramador;
       
        public string Idmundo { get => idmundo; set => idmundo = value; }
        public string Codi_capsula { get => codi_capsula; set => codi_capsula = value; }
        public string Codi_entrada { get => codi_entrada; set => codi_entrada = value; }
        public string Muestrario { get => muestrario; set => muestrario = value; }
        public string Id_disenador { get => id_disenador; set => id_disenador = value; }
        public string Codi_linea { get => codi_linea; set => codi_linea = value; }
        public string IdProgramador { get => idProgramador; set => idProgramador = value; }
     
        public frmSolicitudTela()
        {
            InitializeComponent();

            this.ttTipo.SetToolTip(this.cbxTipo, "Por favor Seleccione un Tipo");
            this.ttEnsayoRef.SetToolTip(this.txbEnsRefDigitado, "Precione Enter para Buscar");
            this.ttSku.SetToolTip(this.txbSku, "Por favor Ingrese solo 3 Carateres");
            dtpFechaTienda.Format = DateTimePickerFormat.Custom;
            dtpFechaTienda.CustomFormat = "dd/MM/yyyy";
            txbSku.MaxLength = 3;

            dgvDetalleConsumo.Columns["editar"].HeaderCell.ToolTipText = "Campos a Editar CONSUMO, DESCRIPCIÓN Y REFERENCIA TELA ";
            dgvDetalleConsumo.Columns["ensayoRef"].HeaderCell.ToolTipText = "Doble clic para seleccionar tipo de solicitud ";
            dgvDetalleConsumo.Columns["tipoSolicitud"].HeaderCell.ToolTipText = "Doble clic para seleccionar tipo de solicitud";
            dgvDetalleConsumo.Columns["desPrenda"].HeaderCell.ToolTipText = "Doble clic para seleccionar tipo de solicitud";

        }

        private void frmSolicitudTela_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey400, Primary.Grey100, Accent.Green100, TextShade.WHITE);
            txbSku.CharacterCasing = CharacterCasing.Upper;
      
        
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
                Idmundo = prmlista[0].Idmundo.ToString();
                Codi_capsula = prmlista[0].Codi_capsula.ToString();
                Codi_entrada = prmlista[0].Codi_entrada.ToString();
                Muestrario = prmlista[0].Nmro_muestrario.ToString();
                Id_disenador = prmlista[0].Id_disenador.ToString();
                Codi_linea = prmlista[0].Codi_linea.ToString();
                IdProgramador = prmlista[0].Idprogramador.ToString();


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
                for (int i = 0; i < prmLista.Count; i++)
                {
                    dgvDetalleConsumo.Rows.Add(prmLista[i].Ensayo_referencia.ToString(),
                    "",
                    prmLista[i].Desc_prenda.ToString(),
                    prmLista[i].Codigo_tela.ToString(),
                    prmLista[i].Descripcion_tela.ToString(),
                    prmLista[i].Consumo_est.ToString().Replace(",", ".")

                    );
                  
                }
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

                for (int i = 0; i < prmLista.Count; i++)
                {
                    dgvDetalleConsumo.Rows.Add(prmLista[i].Identificador.ToString(),
                        prmLista[i].TipoSolicitud.ToString(),
                    prmLista[i].DescripcionPrenda.ToString(),
                    prmLista[i].ReferenciaTela.ToString(),
                    prmLista[i].DescripcionTela.ToString(),
                    decimal.Round(decimal.Parse(prmLista[i].Consumo.ToString().Replace(",", ".")), 2).ToString(),
                    "",
                    "",
                    prmLista[i].Idsolicitud.ToString());
                    txbSku.Text = prmLista[i].Sku.ToString();
                    dtpFechaTienda.Value = (prmLista[i].FechaTienda.ToString() != "") ? DateTime.Parse(prmLista[i].FechaTienda.ToString()):DateTime.Now;
                    
                }
            }
            else
            {
                cargarDataGridView(controlador.getDetalleConsumoEnsayo(txbEnsRefDigitado.Text));
            }
        }

        private void cargarDgvEditadosPorREf(List<EditarDetalleconsumo> prmLista)
        {
            //Pilas agregur los for
            dgvDetalleConsumo.Rows.Clear();
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {
                    dgvDetalleConsumo.Rows.Add(prmLista[i].Identificador.ToString(),
                         prmLista[i].TipoSolicitud.ToString(),
                    prmLista[i].DescripcionPrenda.ToString(),
                    prmLista[i].ReferenciaTela.ToString(),
                    prmLista[i].DescripcionTela.ToString(),   
                    // tener en cuenta la configuración regional para los decimales. 
                    decimal.Round(decimal.Parse(prmLista[i].Consumo.ToString().Replace(".", ",")), 2).ToString(),
                    "",
                    "",
                     prmLista[i].Idsolicitud.ToString()
                    );
                    txbSku.Text = prmLista[i].Sku.ToString();
                    dtpFechaTienda.Value = (prmLista[i].FechaTienda.ToString() != "") ? DateTime.Parse(prmLista[i].FechaTienda.ToString()) : DateTime.Now;
                    txbMuestrario.Text = prmLista[i].Muestrario.ToString();
               
                }
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
        /// Se encarga de validar el tipo de solicitud cuando se ha guardado en frmSolicitudTela.
        /// el cual es llamado en el método dgvDetalleConsumo_CellClick().
        /// </summary>
        /// <param name="e"></param>
        /// <returns>String, que indica el tipo de solicitud que se ha guardado. </returns>
        private string validarTipoSolocitudGuardada(DataGridViewCellEventArgs e)
        {
            //Realiza un consulta del id_sol_tela encontrados en cada una de las tablas que representan el tipo de solicitud.
            int idUnicolor = controlador.getIdUni(int.Parse(dgvDetalleConsumo.Rows[e.RowIndex].Cells[8].Value.ToString()));
            int idEstampado = controlador.consultarIdEst(int.Parse(dgvDetalleConsumo.Rows[e.RowIndex].Cells[8].Value.ToString()));
            int idPlano = controlador.getIdPlano(int.Parse(dgvDetalleConsumo.Rows[e.RowIndex].Cells[8].Value.ToString()));
            int idCuellos = controlador.getIdCuellos(int.Parse(dgvDetalleConsumo.Rows[e.RowIndex].Cells[8].Value.ToString()));
            
            string SolicitudGuardada = "";
            // Los siguiente if verifican si el id_sol_tela consultado en los items anteriores es igual al que en el momento se selecciona en la DatagridView.
           if (controlador.getIdSoltela(idUnicolor) == int.Parse(dgvDetalleConsumo.Rows[e.RowIndex].Cells[8].Value.ToString()))
            {
                SolicitudGuardada = "UNICOLOR";
            }
            else if (controlador.getIdSoltelaEst(idEstampado) == int.Parse(dgvDetalleConsumo.Rows[e.RowIndex].Cells[8].Value.ToString()))
            {
                SolicitudGuardada = "ESTAMPADO";
            }else if (controlador.getIdSoltelaPla(idPlano) == int.Parse(dgvDetalleConsumo.Rows[e.RowIndex].Cells[8].Value.ToString()))
            {
                SolicitudGuardada = "PRETEÑIDO";
            }else if (controlador.getIdSoltelaCue(idCuellos) == int.Parse(dgvDetalleConsumo.Rows[e.RowIndex].Cells[8].Value.ToString()))
            {
                SolicitudGuardada = "TIRAS/CUELLOS/PUÑOS";
            }
            else
            {
                SolicitudGuardada = "Ninguna";
            }

            return SolicitudGuardada;


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
                if (dgvDetalleConsumo.Columns[e.ColumnIndex].Name == "guardar" && dgvDetalleConsumo.CurrentRow.Cells[1].Value.ToString() == "")
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
                    string tipoSolGuardado = validarTipoSolocitudGuardada(e);
                     if (id != 0)
                    {
                        frmTipoSolicitud objTipoSolicitud = new frmTipoSolicitud();
                        objTipoSolicitud.StartPosition = FormStartPosition.CenterScreen;
                        if (objTipoSolicitud.ShowDialog() == DialogResult.OK)
                        {
                            String seleccion = objTipoSolicitud.Seleccion;
                            if (seleccion == "unicolor" && tipoSolGuardado == "Ninguna" || tipoSolGuardado == "UNICOLOR" && dgvDetalleConsumo.Rows[e.RowIndex].Cells["tipoSolicitud"].Value.ToString() == "" || dgvDetalleConsumo.Rows[e.RowIndex].Cells["tipoSolicitud"].Value.ToString() == "UNICOLOR" )
                            {                            
                                frmSolicitudUnicolor frmUnicolor = new frmSolicitudUnicolor(controlador, identificador, dgvDetalleConsumo.Rows[e.RowIndex].Cells[3].Value.ToString(), dgvDetalleConsumo.Rows[e.RowIndex].Cells[4].Value.ToString(), int.Parse(dgvDetalleConsumo.Rows[e.RowIndex].Cells[8].Value.ToString()));
                               
                                if (frmUnicolor.ShowDialog() == DialogResult.OK)
                                {
                                   
                                    btnConsultar.PerformClick();
                                    
                                }
                            }
                            
                            else if (seleccion == "estampado" && tipoSolGuardado == "Ninguna" || tipoSolGuardado == "ESTAMPADO" && dgvDetalleConsumo.Rows[e.RowIndex].Cells["tipoSolicitud"].Value.ToString() == "" || dgvDetalleConsumo.Rows[e.RowIndex].Cells["tipoSolicitud"].Value.ToString() == "ESTAMPADO")
                            {
                                frmSolicitudEstampado frmEstamapado = new frmSolicitudEstampado(controlador, identificador, dgvDetalleConsumo.Rows[e.RowIndex].Cells[3].Value.ToString(), dgvDetalleConsumo.Rows[e.RowIndex].Cells[4].Value.ToString(), int.Parse(dgvDetalleConsumo.Rows[e.RowIndex].Cells[8].Value.ToString()));
                                if (frmEstamapado.ShowDialog() == DialogResult.OK)
                                {
                                    btnConsultar.PerformClick();

                                }
                                 }
                            
                            else if (seleccion == "planoPre" && tipoSolGuardado == "Ninguna" || tipoSolGuardado == "PRETEÑIDO" && dgvDetalleConsumo.Rows[e.RowIndex].Cells["tipoSolicitud"].Value.ToString() == "" || dgvDetalleConsumo.Rows[e.RowIndex].Cells["tipoSolicitud"].Value.ToString() == "PRETEÑIDO")
                            {
                                frmSolicitudPlanoPretenido frmPlapretenido = new frmSolicitudPlanoPretenido(controlador, identificador, dgvDetalleConsumo.Rows[e.RowIndex].Cells[3].Value.ToString(), dgvDetalleConsumo.Rows[e.RowIndex].Cells[4].Value.ToString(), int.Parse(dgvDetalleConsumo.Rows[e.RowIndex].Cells[8].Value.ToString()));
                                if (frmPlapretenido.ShowDialog() == DialogResult.OK)
                                {
                                    btnConsultar.PerformClick();

                                }
                            }
                           
                            else if (seleccion == "cuelloPun" && tipoSolGuardado == "Ninguna" || tipoSolGuardado == "TIRAS/CUELLOS/PUÑOS" && dgvDetalleConsumo.Rows[e.RowIndex].Cells["tipoSolicitud"].Value.ToString() == "" || dgvDetalleConsumo.Rows[e.RowIndex].Cells["tipoSolicitud"].Value.ToString() == "TIRAS/CUELLOS/PUÑOS")
                            {
                                frmSolicitudCuellosTiras frmCuellos = new frmSolicitudCuellosTiras(controlador,identificador, int.Parse(dgvDetalleConsumo.Rows[e.RowIndex].Cells[8].Value.ToString()));
                                if (frmCuellos.ShowDialog() == DialogResult.OK)
                                {
                                    btnConsultar.PerformClick();

                                }
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
                     }
                    if (dgvDetalleConsumo.CurrentRow.Cells[1].Value.ToString() != "")
                    {
                        if (e.ColumnIndex == 7 || e.ColumnIndex == 6 || e.ColumnIndex == 3 || e.ColumnIndex == 4 || e.ColumnIndex == 5)
                        {
                            MessageBox.Show("No se puede editar ni guardar, la solitud ya se ha confirmado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            editando = false;
                        }
                      

                    }
                    else if (e.ColumnIndex == 3 || e.ColumnIndex == 4 )
                    {
                        
                        frmEditarDsolicitudTela objEditar = new frmEditarDsolicitudTela(controlador);
                        objEditar.StartPosition = FormStartPosition.CenterScreen;

                        if (objEditar.ShowDialog() == DialogResult.OK)
                        {
                            Objeto obj = objEditar.Elemento;
                            dgvDetalleConsumo.CurrentRow.Cells[3].Value = obj.Id;
                            dgvDetalleConsumo.CurrentRow.Cells[4].Value = obj.Nombre;
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
                cargarDataGridView(controlador.getDetalleConsumoEnsayo(txbEnsRefDigitado.Text));
                //Guarda la información cuando se da click en el boton consultar
                if (!controlador.consultarIdentificador(txbEnsRefDigitado.Text))
                {
                    controlador.GuardarListaDetalleConsumo(ListaSolicitudTelas());
                }
                
                cargarDgvDatosEditados(controlador.getDcEditadoPorEnsayo(txbEnsRefDigitado.Text));
            }
            else
            {
                cargarDataGridView(controlador.getDetalleConsumoReferencia(txbEnsRefDigitado.Text));
                //Guarda la información cuando se da click en el boton consultar
                if (!controlador.consultarIdentificador(txbEnsRefDigitado.Text))
                {
                    controlador.GuardarListaDetalleConsumo(ListaSolicitudTelas());
                }
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

                    txbTema.BackColor = Color.LightGoldenrodYellow;
                    txbDisenador.BackColor = Color.LightGoldenrodYellow;
                    txbOcasionUso.BackColor = Color.LightGoldenrodYellow;
                    txbMuestrario.BackColor = Color.LightGoldenrodYellow;
                    txbEntrada.BackColor = Color.LightGoldenrodYellow;
                    txbAnio.BackColor = Color.LightGoldenrodYellow;
                    txbSku.Clear();
                    dtpFechaTienda.Value = DateTime.Now;
                }
            }
            else if (cbxTipo.SelectedItem.ToString() == "Referencia" && (e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                cargarTexBox(cbxTipo, controlador.getReferencia(txbEnsRefDigitado.Text));
                dgvDetalleConsumo.Rows.Clear();

                txbTema.BackColor = Color.LightGoldenrodYellow;
                txbDisenador.BackColor = Color.LightGoldenrodYellow;
                txbOcasionUso.BackColor = Color.LightGoldenrodYellow;
                txbMuestrario.BackColor = Color.LightGoldenrodYellow;
                txbEntrada.BackColor = Color.LightGoldenrodYellow;
                txbAnio.BackColor = Color.LightGoldenrodYellow;
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
                txbEnsRefDigitado.BackColor = Color.White;
                txbDisenador.BackColor = Color.White;
                txbOcasionUso.BackColor = Color.White;
                txbMuestrario.BackColor = Color.White;
                txbEntrada.BackColor = Color.White;
                txbAnio.BackColor = Color.White;
                txbTema.BackColor = Color.White;
                validacion.limpiar(pnlAdicionarSolicitud);
                dgvDetalleConsumo.Rows.Clear();
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
            //validacion.SoloLetras(e);
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void dgvDetalleConsumo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5) {
                if (dgvDetalleConsumo.CurrentCell.Value != null && dgvDetalleConsumo.CurrentCell.Value.ToString().Trim() != "")
                {
                    dgvDetalleConsumo.CurrentCell.Value = dgvDetalleConsumo.CurrentCell.Value.ToString().Trim().Replace(",", ".");
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
            if (detalle.Identificador != null)
            {

                if (!controlador.consultarIdentificador(detalle.Identificador.ToString()))
                {
                    controlador.addDetalleConsumo(detalle);
                    MessageBox.Show("La información se guardó con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    controlador.ActualizarSolicitudTela(detalle, dgvDetalleConsumo.Rows[e.RowIndex].Cells[0].Value.ToString());
                    MessageBox.Show("La información se Actualizó con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private EditarDetalleconsumo obtenerObjDetalleConsumo(DataGridViewCellEventArgs e)
        {
            EditarDetalleconsumo elemento = new EditarDetalleconsumo();
            Ensayo ensayo = new Ensayo();
            string fecha = dtpFechaTienda.Value.ToString("dd/MM/yyyy");
            if (fecha == "")
            {
                //elemento = null;
                MessageBox.Show("Por favor, seleccione un valor para fecha.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                if (txbSku.Text.Trim().Length == 0)
                {
                   // elemento = null;
                    MessageBox.Show("Por favor, ingrese el SKU.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else {
                    if (dgvDetalleConsumo.RowCount > 0)
                    {
                        elemento.Identificador = (string)dgvDetalleConsumo.Rows[e.RowIndex].Cells[0].Value;
                        elemento.Idmundo = Idmundo;
                        elemento.Codi_capsula = Codi_capsula.ToString();
                        elemento.Codi_entrada = Codi_entrada.ToString();
                        elemento.Tipo = cbxTipo.SelectedItem.ToString();
                        elemento.DescripcionPrenda = (string)dgvDetalleConsumo.Rows[e.RowIndex].Cells[2].Value;
                        elemento.Sku = txbSku.Text.Trim();
                        elemento.FechaTienda = fecha;
                        elemento.ReferenciaTela = (string)dgvDetalleConsumo.Rows[e.RowIndex].Cells[3].Value;
                        elemento.DescripcionTela = (string)dgvDetalleConsumo.Rows[e.RowIndex].Cells[4].Value;
                        elemento.Consumo = (dgvDetalleConsumo.Rows[e.RowIndex].Cells[5].Value != null) ? dgvDetalleConsumo.Rows[e.RowIndex].Cells[5].Value.ToString() : "0";
                        elemento.Muestrario = Muestrario.ToString();
                        elemento.Id_disenador = Id_disenador.ToString();
                        elemento.Codi_linea = Codi_linea.ToString();
                        elemento.Idsolicitud = int.Parse(dgvDetalleConsumo.Rows[e.RowIndex].Cells[8].Value.ToString());
                        return elemento;
                    }
                }
            }
            
            return elemento;
        }

        private void dgvDetalleConsumo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvDetalleConsumo.Columns[e.ColumnIndex].Name== "ensayoRef" || this.dgvDetalleConsumo.Columns[e.ColumnIndex].Name == "desPrenda" 
                || this.dgvDetalleConsumo.Columns[e.ColumnIndex].Name == "tipoSolicitud")
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }
       
        /// <summary>
       /// Llena una lista con los datos consultados. 
       /// </summary>
       /// <returns></returns>
        public List<EditarDetalleconsumo> ListaSolicitudTelas()
        {
            List<EditarDetalleconsumo> listaDetalleconsumo = new List<EditarDetalleconsumo>();
            for (int i = 0; i <= dgvDetalleConsumo.RowCount - 1; i++)
            { 
                if (dgvDetalleConsumo.RowCount > 0)
                {
                    EditarDetalleconsumo elemento = new EditarDetalleconsumo();
                    elemento.Identificador = (string)dgvDetalleConsumo.Rows[i].Cells[0].Value;
                    elemento.Idmundo = Idmundo;
                    elemento.Codi_capsula = Codi_capsula.ToString();
                    elemento.Codi_entrada = Codi_entrada.ToString();
                    elemento.Tipo = cbxTipo.SelectedItem.ToString();
                    elemento.DescripcionPrenda = (string)dgvDetalleConsumo.Rows[i].Cells[2].Value;
                    elemento.Sku = "";
                    elemento.FechaTienda = "";
                    elemento.ReferenciaTela = (string)dgvDetalleConsumo.Rows[i].Cells[3].Value;
                    elemento.DescripcionTela = (string)dgvDetalleConsumo.Rows[i].Cells[4].Value;
                    elemento.Consumo = (dgvDetalleConsumo.Rows[i].Cells[5].Value != null) ? dgvDetalleConsumo.Rows[i].Cells[5].Value.ToString() : "0";
                    elemento.Muestrario = Muestrario.ToString();
                    elemento.Id_disenador = Id_disenador.ToString();
                    elemento.Codi_linea = Codi_linea.ToString();
                    elemento.IdProgramador = int.Parse(IdProgramador.ToString());
                  


                    //elemento.Idsolicitud = (int)dgvDetalleConsumo.Rows[i].Cells[8].Value;
                    listaDetalleconsumo.Add(elemento);
                }
            }
            return listaDetalleconsumo;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            frmInicial frmInicial = new frmInicial();
            this.Close();
            frmInicial.Show();
        }
    }
}
