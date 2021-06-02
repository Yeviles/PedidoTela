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
    public partial class frmPedidoCoordinado3en1 : MaterialSkin.Controls.MaterialForm
    {
        #region variables
        private Controlador control = new Controlador();
        private Validar validacion = new Validar();
        private List<MontajeTelaDetalle> solicitudes = new List<MontajeTelaDetalle>();
        private List<PedidoMontarInformacion> informacion = new List<PedidoMontarInformacion>();
        List<MontajeTelaDetalle> listaUnicolor = new List<MontajeTelaDetalle>();
        List<MontajeTelaDetalle> listaEstampado = new List<MontajeTelaDetalle>();
        List<MontajeTelaDetalle> listaPlano = new List<MontajeTelaDetalle>();
        List<MontajeTelaDetalle> listaCuello = new List<MontajeTelaDetalle>();
        private List<int> listaIdSolicitudes = new List<int>();
        private List<string> listaEsayosRef = new List<string>();
        private List<Objeto> colores = new List<Objeto>();
        private int idSolicitud, id, consecutivo;
        private bool existia = false;
        #endregion

        public frmPedidoCoordinado3en1(Controlador control, List<MontajeTelaDetalle> solicitudes, int idSolicitud, string principal, string coordinado1, string coordinado2)
        {
            this.control = control;
            this.solicitudes = solicitudes;
            this.idSolicitud = idSolicitud;
           
            InitializeComponent();
            dtpFechaLlegada.Format = DateTimePickerFormat.Custom;
            dtpFechaLlegada.CustomFormat = "dd/MM/yyyy";
            cargarCombobox(cbxTipoMarcacion, control.getTipoMarcacion());
            cargar();
        }

        private void frmTipoPedSelecCoordinar_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
            cargarSolicitudes(solicitudes);
        }

        private void cargarListas()
        {
            idSolicitud = solicitudes[0].IdSolTela;
            foreach (MontajeTelaDetalle solicitud in solicitudes)
            {
                if (solicitud.TipoSolicitud.ToLower() == "unicolor")
                {
                    listaUnicolor.Add(solicitud);
                }
                else if (solicitud.TipoSolicitud.ToLower() == "estampado")
                {
                    listaEstampado.Add(solicitud);
                }
                if (solicitud.TipoSolicitud.ToLower() == "preteñido")
                {
                    listaPlano.Add(solicitud);
                }
                if (solicitud.TipoSolicitud.ToLower() == "tiras/cuellos/puños")
                {
                    listaCuello.Add(solicitud);
                }
            }
        }

        #region Botones
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            bool swUnicolor = true;
            bool swEstampado = true;
            bool swPlano = true;
            bool swCuello = true;
            if (validarGeneral()) {
                if (listaUnicolor.Count > 0)
                {
                    swUnicolor = validarUnicolor();
                }
                if (listaEstampado.Count > 0) {
                    swEstampado = validarEstampado();
                }
                if (listaPlano.Count > 0)
                {
                    swPlano = validarPlano();
                }
                if (listaCuello.Count>0)
                {
                    swCuello = validarCuello();
                }

                if (swUnicolor && swEstampado && swPlano || swCuello) {
                    if (!validarTotalAPedir() && !validarUnidadTotal()) {
                        guardarPedido();
                        if (id != 0) {
                            control.eliminarPedidoCoordinadoInformacion(id);
                            control.eliminarPedidoCoordinadoTotal(id);
                            control.eliminarPedido(id); //Tomar del pedido
                            control.eliminarPedidoCoordinadoCuellosProporcion(id);//Coordinado cuellos

                            guardarTomarDelPedido();
                            guardarInformacion();
                            guardarTotal();
                            GuardarProporcion(id);//Coordinado cuellos
                            MessageBox.Show("Pedido guardado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (!existia) {
                                agregarConsolidado();
                            }
                        }                    
                    }
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
                for (int i = 0; i < solicitudes.Count; i++)
                {
                    control.agregarConsecutivo(listaIdSolicitudes[i], maxConsecutivo + 1, fechaActual, estado);
                }
                MessageBox.Show("La información se guardó con éxito. \n El estado se actualizó a Radicado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Deshabilita los diferentes botones y demás contenido del formulario que se quiere que no sea modificado una vez se confirme la solicitud.
                btnConfirmar.Enabled = false;
                btnGrabar.Enabled = false;

                dgvInformacionUnicolor.ReadOnly = true;
                dgvInformacionEstampado.ReadOnly = true;
                dgvInformacionPlano.ReadOnly = true;
                dgvConsolidar.ReadOnly = true;

                //Consulta el consecutivo generado y se muestra en la vista.
                consecutivo = control.consultarConsecutivoPedido(idSolicitud);
                lblConsecutivo.Text = "Consecutivo: " + consecutivo;
            }
            else
            {
                MessageBox.Show("Por favor guarde la Información.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (id != 0)
            {
                frmImprimirPedidoCoordinado imprimir = new frmImprimirPedidoCoordinado(control, idSolicitud);
                imprimir.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor guarde el consolidado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            frmBuscarPedido buscar = new frmBuscarPedido(control, solicitudes[0].IdProgramador);
            if (buscar.ShowDialog() == DialogResult.OK)
            {
                TomarDelPedido obj = buscar.Elemento;
                dgvPedidos.Rows.Add();
                dgvPedidos.Rows[dgvPedidos.Rows.Count - 1].Cells[0].Value = obj.NumeroPedido;
                dgvPedidos.Rows[dgvPedidos.Rows.Count - 1].Cells[1].Value = obj.CodigoColor;
                dgvPedidos.Rows[dgvPedidos.Rows.Count - 1].Cells[2].Value = obj.Estado;
                dgvPedidos.Rows[dgvPedidos.Rows.Count - 1].Cells[3].Value = obj.Disponible;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Unicolor

        #region eventos
        private void dgvInformacionUnicolor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 1 && e.ColumnIndex < 10 || e.ColumnIndex == 11 || e.ColumnIndex >= 13)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }

        private void dgvInformacionUnicolor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvInformacionUnicolor.CurrentRow.Cells[2].ReadOnly = true;
            dgvInformacionUnicolor.CurrentRow.Cells[3].ReadOnly = true;
            dgvInformacionUnicolor.CurrentRow.Cells[4].ReadOnly = true;
            dgvInformacionUnicolor.CurrentRow.Cells[5].ReadOnly = true;
            dgvInformacionUnicolor.CurrentRow.Cells[6].ReadOnly = true;
            dgvInformacionUnicolor.CurrentRow.Cells[7].ReadOnly = true;
            dgvInformacionUnicolor.CurrentRow.Cells[8].ReadOnly = true;
            dgvInformacionUnicolor.CurrentRow.Cells[9].ReadOnly = true;
            dgvInformacionUnicolor.CurrentRow.Cells[11].ReadOnly = true;
            dgvInformacionUnicolor.CurrentRow.Cells[13].ReadOnly = true;
            dgvInformacionUnicolor.CurrentRow.Cells[14].ReadOnly = true;

            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                frmBuscarColor buscarColor = new frmBuscarColor(control);
                buscarColor.StartPosition = FormStartPosition.CenterScreen;
                if (buscarColor.ShowDialog() == DialogResult.OK)
                {
                    Objeto obj = buscarColor.Elemento;
                    dgvInformacionUnicolor.Rows[e.RowIndex].Cells[0].Value = obj.Id;
                    dgvInformacionUnicolor.Rows[e.RowIndex].Cells[1].Value = obj.Nombre;
                }

            }
            calcularTotalesPorColores();
        }

        private void dgvInformacionUnicolor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10) //Cuando cambia el consumo [10] cambia M Calculados [11] y KG Calculados[14]
            {
                try
                {
                    if (dgvInformacionUnicolor.CurrentCell.Value != null && dgvInformacionUnicolor.CurrentCell.Value.ToString().Trim() != "")
                    {
                        dgvInformacionUnicolor.CurrentCell.Value = dgvInformacionUnicolor.CurrentCell.Value.ToString().Replace(",", ".");
                        dgvInformacionUnicolor.CurrentCell.Value = Regex.Replace(dgvInformacionUnicolor.CurrentCell.Value.ToString(), @"[^0-9.]", "");

                        if (dgvInformacionUnicolor.CurrentCell.Value != null && dgvInformacionUnicolor.CurrentCell.Value.ToString().Trim() != "")
                        {
                            decimal consumo = decimal.Parse(dgvInformacionUnicolor.CurrentCell.Value.ToString());
                            int totalUnidades = int.Parse(dgvInformacionUnicolor.Rows[e.RowIndex].Cells[9].Value.ToString());
                            dgvInformacionUnicolor.Rows[e.RowIndex].Cells[11].Value = calcularMCalculados(consumo, totalUnidades);


                            // cuando cambia M Calculados [11] se actualiza M Solicitar [13]
                            if (dgvInformacionUnicolor.Rows[e.RowIndex].Cells[11].Value != null && dgvInformacionUnicolor.Rows[e.RowIndex].Cells[11].Value.ToString().Trim() != "")
                            {
                                decimal mCalculados = decimal.Parse(dgvInformacionUnicolor.Rows[e.RowIndex].Cells[11].Value.ToString());

                                if (dgvInformacionUnicolor.Rows[e.RowIndex].Cells[12].Value != null && dgvInformacionUnicolor.Rows[e.RowIndex].Cells[12].Value.ToString() != "")
                                {
                                    decimal mReservados = decimal.Parse(dgvInformacionUnicolor.Rows[e.RowIndex].Cells[12].Value.ToString());
                                    dgvInformacionUnicolor.Rows[e.RowIndex].Cells[13].Value = calcularMSolicitar(mCalculados, mReservados);
                                    dgvInformacionUnicolor.Rows[e.RowIndex].Cells[14].Value = decimal.Round(decimal.Parse(dgvInformacionUnicolor.Rows[e.RowIndex].Cells[13].Value.ToString()) / decimal.Parse(txtRendimiento.Text), 2);
                                }
                                else
                                {
                                    dgvInformacionUnicolor.Rows[e.RowIndex].Cells[13].Value = mCalculados;
                                }
                            }
                            else
                            {
                                dgvInformacionUnicolor.Rows[e.RowIndex].Cells[13].Value = "";
                            }

                        }
                    }
                    else
                    {
                        dgvInformacionUnicolor.Rows[e.RowIndex].Cells[14].Value = "";
                        dgvInformacionUnicolor.Rows[e.RowIndex].Cells[11].Value = "";
                        dgvInformacionUnicolor.Rows[e.RowIndex].Cells[13].Value = "";
                    }
                    calcularTotalesPorColores();
                }
                catch (Exception ex)
                {
                    dgvInformacionUnicolor.CurrentCell.Value = "";
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (e.ColumnIndex == 11) // cuando cambia M Calculados [11] se actualiza M Solicitar [13]
            {
                if (dgvInformacionUnicolor.CurrentCell.Value != null && dgvInformacionUnicolor.CurrentCell.Value.ToString().Trim() != "")
                {
                    decimal mCalculados = decimal.Parse(dgvInformacionUnicolor.Rows[e.RowIndex].Cells[11].Value.ToString());

                    if (dgvInformacionUnicolor.Rows[e.RowIndex].Cells[12].Value != null && dgvInformacionUnicolor.Rows[e.RowIndex].Cells[12].Value.ToString() != "")
                    {
                        decimal mReservados = decimal.Parse(dgvInformacionUnicolor.Rows[e.RowIndex].Cells[12].Value.ToString());
                        dgvInformacionUnicolor.Rows[e.RowIndex].Cells[13].Value = calcularMSolicitar(mCalculados, mReservados);
                    }
                    else
                    {
                        dgvInformacionUnicolor.Rows[e.RowIndex].Cells[13].Value = mCalculados;
                    }
                }
                else
                {
                    dgvInformacionUnicolor.Rows[e.RowIndex].Cells[13].Value = "";
                }
                calcularTotalesPorColores();
            }
            else if (e.ColumnIndex == 12) // cuando cambia M Reservados [12] cambia el M Solicitar [13]
            {
                try
                {
                    if (dgvInformacionUnicolor.CurrentCell.Value != null && dgvInformacionUnicolor.CurrentCell.Value.ToString().Trim() != "")
                    {
                        if (dgvInformacionUnicolor.Rows[e.RowIndex].Cells[11].Value != null && dgvInformacionUnicolor.Rows[e.RowIndex].Cells[11].Value.ToString() != "")
                        {
                            decimal mReservados = decimal.Parse(dgvInformacionUnicolor.CurrentCell.Value.ToString());
                            decimal mCalculados = decimal.Parse(dgvInformacionUnicolor.Rows[e.RowIndex].Cells[11].Value.ToString());
                            if (mCalculados >= mReservados)
                            {
                                decimal mSolicitar = calcularMSolicitar(mCalculados, mReservados); ;
                                dgvInformacionUnicolor.Rows[e.RowIndex].Cells[13].Value = mSolicitar;

                                if (txtRendimiento.Text.Trim() != "")
                                {
                                    decimal rendimiento = decimal.Parse(txtRendimiento.Text);
                                    dgvInformacionUnicolor.Rows[e.RowIndex].Cells[14].Value = decimal.Round(mSolicitar / rendimiento, 2);
                                }
                            }
                            else
                            {
                                dgvInformacionUnicolor.CurrentCell.Value = "";
                                MessageBox.Show("M Reservados no puede ser mayor a M Calculados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            dgvInformacionUnicolor.CurrentCell.Value = "";
                            MessageBox.Show("Por favor ingrese el consumo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        dgvInformacionUnicolor.Rows[e.RowIndex].Cells[13].Value = dgvInformacionUnicolor.Rows[e.RowIndex].Cells[11].Value;
                        dgvInformacionUnicolor.Rows[e.RowIndex].Cells[14].Value = decimal.Round(decimal.Parse(dgvInformacionUnicolor.Rows[e.RowIndex].Cells[13].Value.ToString()) / decimal.Parse(txtRendimiento.Text), 2);
                    }
                    calcularTotalesPorColores();
                }
                catch (Exception ex)
                {
                    dgvInformacionUnicolor.CurrentCell.Value = "";
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion
        private void inicioUnicolor() {
            if (id == 0) {
                cargarDgvInfoConsolidarUnicolor(listaUnicolor);
            }
            #region ToolTipsText
            dgvInformacionUnicolor.Columns[0].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInformacionUnicolor.Columns[1].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInformacionUnicolor.Columns[11].HeaderCell.ToolTipText = "(Consumo * Total Unidades)*1.10";
            dgvInformacionUnicolor.Columns[13].HeaderCell.ToolTipText = "M calculados -  M reservados";
            dgvInformacionUnicolor.Columns[14].HeaderCell.ToolTipText = "M a solicitar / Rendimiento";
            #endregion
        }

        /// <summary> Carga el DataGridView correspondiente a información a consolidar de Unicolor.</summary>
        /// <param name="prmLista">Lista de tipo MontajeTelaDetalle, representa las filas seleccionadas en el vista  inicial de filtros (frmSolicitudListaTelas).</param>
        private void cargarDgvInfoConsolidarUnicolor(List<MontajeTelaDetalle> prmLista)
        {
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {
                    dgvInformacionUnicolor.Rows.Add(prmLista[i].Vte.ToString(),
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
                }
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void obtenerColoresUnicolor()
        {
            if (listaUnicolor.Count > 0)
            {
                for (int i = 0; i < dgvInformacionUnicolor.RowCount; i++)
                {
                    Objeto color = new Objeto();
                    color.Id = dgvInformacionUnicolor.Rows[i].Cells[0].Value.ToString().ToLower();
                    color.Nombre = dgvInformacionUnicolor.Rows[i].Cells[1].Value.ToString().ToLower();
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
            }
        }

        private bool validarUnicolor()
        {
            bool bandera = false;
            if (dgvInformacionUnicolor.RowCount > 0)
            {
                if (!validarValoresConsumoUnicolor())
                {
                    if (!validarValoresReservaUnicolor())
                    {
                        bandera = true;
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
            return bandera;
        }

        private bool validarValoresConsumoUnicolor()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvInformacionUnicolor.Rows)
            {
                if (row.Cells[10].Value == null || row.Cells[10].Value.ToString() == "")
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        private bool validarValoresReservaUnicolor()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvInformacionUnicolor.Rows)
            {
                if (row.Cells[12].Value == null || row.Cells[12].Value.ToString() == "")
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        private void obtenerInformacionUnicolor()
        {
            if (dgvInformacionUnicolor.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvInformacionUnicolor.Rows)
                {
                    PedidoMontarInformacion info = new PedidoMontarInformacion();
                    info.IdPedidoAMontar = id;
                    info.CodigoColor = (row.Cells[0].Value.ToString());
                    info.DescripcionColor = (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "") ? row.Cells[1].Value.ToString() : "";
                    info.Fondo = "";
                    info.DescripcionFondo = "";
                    info.CodigoH1 = "";
                    info.DescripcionH1 = "";
                    info.CodigoH2 = "";
                    info.DescripcionH2 = "";
                    info.CodigoH3 = "";
                    info.DescripcionH3 = "";
                    info.CodigoH4 = "";
                    info.DescripcionH4 = "";
                    info.CodigoH5 = "";
                    info.DescripcionH5 = "";
                    info.Tiendas = (row.Cells[2].Value != null && row.Cells[2].Value.ToString() != "") ? int.Parse(row.Cells[2].Value.ToString()) : 0;
                    info.Exito = (row.Cells[3].Value != null && row.Cells[3].Value.ToString() != "") ? int.Parse(row.Cells[3].Value.ToString()) : 0;
                    info.Cencosud = (row.Cells[4].Value != null && row.Cells[4].Value.ToString() != "") ? int.Parse(row.Cells[4].Value.ToString()) : 0;
                    info.Sao = (row.Cells[5].Value != null && row.Cells[5].Value.ToString() != "") ? int.Parse(row.Cells[5].Value.ToString()) : 0;
                    info.ComercioOrg = (row.Cells[6].Value != null && row.Cells[6].Value.ToString() != "") ? int.Parse(row.Cells[6].Value.ToString()) : 0;
                    info.Rosado = (row.Cells[7].Value != null && row.Cells[7].Value.ToString() != "") ? int.Parse(row.Cells[7].Value.ToString()) : 0;
                    info.Otros = (row.Cells[8].Value != null && row.Cells[8].Value.ToString() != "") ? int.Parse(row.Cells[8].Value.ToString()) : 0;
                    info.TotalUnidades = (row.Cells[9].Value != null && row.Cells[9].Value.ToString() != "") ? int.Parse(row.Cells[9].Value.ToString()) : 0;
                    info.Consumo = (row.Cells[10].Value != null && row.Cells[10].Value.ToString() != "") ? decimal.Parse(row.Cells[10].Value.ToString()) : 0;
                    info.MCalculados = (row.Cells[11].Value != null && row.Cells[11].Value.ToString() != "") ? decimal.Parse(row.Cells[11].Value.ToString()) : 0;
                    info.MReservados = (row.Cells[12].Value != null && row.Cells[12].Value.ToString() != "") ? decimal.Parse(row.Cells[12].Value.ToString()) : 0;
                    info.MSolicitar = (row.Cells[13].Value != null && row.Cells[13].Value.ToString() != "") ? decimal.Parse(row.Cells[13].Value.ToString()) : 0;
                    info.KgCalculados = (row.Cells[14].Value != null && row.Cells[14].Value.ToString() != "") ? decimal.Parse(row.Cells[14].Value.ToString()) : 0;
                    informacion.Add(info);
                }
            }
        }

        #endregion

        #region Estampado
        #region eventos
        private void dgvInformacionEstampado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 3 && e.ColumnIndex <= 11 || e.ColumnIndex > 12 && e.ColumnIndex <= 13 || e.ColumnIndex > 14 && e.ColumnIndex <= 16)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }

        private void dgvInformacionEstampado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
            {
                frmBuscarColor buscarColor = new frmBuscarColor(control);
                buscarColor.StartPosition = FormStartPosition.CenterScreen;
                if (buscarColor.ShowDialog() == DialogResult.OK)
                {
                    Objeto obj = buscarColor.Elemento;
                    dgvInformacionEstampado.Rows[e.RowIndex].Cells[0].Value = obj.Id;
                    dgvInformacionEstampado.Rows[e.RowIndex].Cells[1].Value = obj.Nombre;
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
                    dgvInformacionEstampado.Rows[e.RowIndex].Cells[2].Value = obj.Id;
                    dgvInformacionEstampado.Rows[e.RowIndex].Cells[3].Value = obj.Nombre;
                }
                calcularTotalesPorColores();
            }
        }

        private void dgvInformacionEstampado_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 12) //Cuando cambia el consumo [12] cambia M Calculados [13] y KG Calculados[16]
            {
                try
                {
                    if (dgvInformacionEstampado.CurrentCell.Value != null && dgvInformacionEstampado.CurrentCell.Value.ToString().Trim() != "")
                    {
                        dgvInformacionEstampado.CurrentCell.Value = dgvInformacionEstampado.CurrentCell.Value.ToString().Replace(",", ".");
                        dgvInformacionEstampado.CurrentCell.Value = Regex.Replace(dgvInformacionEstampado.CurrentCell.Value.ToString(), @"[^0-9.]", "");

                        if (dgvInformacionEstampado.CurrentCell.Value != null && dgvInformacionEstampado.CurrentCell.Value.ToString().Trim() != "")
                        {
                            decimal consumo = decimal.Parse(dgvInformacionEstampado.CurrentCell.Value.ToString());
                            int totalUnidades = int.Parse(dgvInformacionEstampado.Rows[e.RowIndex].Cells[11].Value.ToString());
                            dgvInformacionEstampado.Rows[e.RowIndex].Cells[13].Value = calcularMCalculados(consumo, totalUnidades);


                            // cuando cambia M Calculados [13] se actualiza M Solicitar [15]
                            if (dgvInformacionEstampado.Rows[e.RowIndex].Cells[13].Value != null && dgvInformacionEstampado.Rows[e.RowIndex].Cells[13].Value.ToString().Trim() != "")
                            {
                                decimal mCalculados = decimal.Parse(dgvInformacionEstampado.Rows[e.RowIndex].Cells[13].Value.ToString());

                                if (dgvInformacionEstampado.Rows[e.RowIndex].Cells[14].Value != null && dgvInformacionEstampado.Rows[e.RowIndex].Cells[14].Value.ToString() != "")
                                {
                                    decimal mReservados = decimal.Parse(dgvInformacionEstampado.Rows[e.RowIndex].Cells[14].Value.ToString());
                                    dgvInformacionEstampado.Rows[e.RowIndex].Cells[15].Value = calcularMSolicitar(mCalculados, mReservados);
                                    dgvInformacionEstampado.Rows[e.RowIndex].Cells[16].Value = decimal.Round(decimal.Parse(dgvInformacionEstampado.Rows[e.RowIndex].Cells[15].Value.ToString()) / decimal.Parse(txtRendimiento.Text), 2);

                                }
                                else
                                {
                                    dgvInformacionEstampado.Rows[e.RowIndex].Cells[15].Value = mCalculados;
                                }
                            }
                            else
                            {
                                dgvInformacionEstampado.Rows[e.RowIndex].Cells[15].Value = "";
                            }

                        }
                    }
                    else
                    {
                        dgvInformacionEstampado.Rows[e.RowIndex].Cells[16].Value = "";
                        dgvInformacionEstampado.Rows[e.RowIndex].Cells[13].Value = "";
                        dgvInformacionEstampado.Rows[e.RowIndex].Cells[15].Value = "";
                    }
                }
                catch (Exception ex)
                {
                    dgvInformacionEstampado.CurrentCell.Value = "";
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (e.ColumnIndex == 13) // cuando cambia M Calculados [13] se actualiza M Solicitar [15]
            {
                if (dgvInformacionEstampado.CurrentCell.Value != null && dgvInformacionEstampado.CurrentCell.Value.ToString().Trim() != "")
                {
                    decimal mCalculados = decimal.Parse(dgvInformacionEstampado.Rows[e.RowIndex].Cells[13].Value.ToString());

                    if (dgvInformacionEstampado.Rows[e.RowIndex].Cells[14].Value != null && dgvInformacionEstampado.Rows[e.RowIndex].Cells[14].Value.ToString() != "")
                    {
                        decimal mReservados = decimal.Parse(dgvInformacionEstampado.Rows[e.RowIndex].Cells[14].Value.ToString());
                        dgvInformacionEstampado.Rows[e.RowIndex].Cells[15].Value = calcularMSolicitar(mCalculados, mReservados);
                    }
                    else
                    {
                        dgvInformacionEstampado.Rows[e.RowIndex].Cells[15].Value = mCalculados;
                    }
                }
                else
                {
                    dgvInformacionEstampado.Rows[e.RowIndex].Cells[15].Value = "";
                }
            }
            else if (e.ColumnIndex == 14) // cuando cambia M Reservados [14] cambia el M Solicitar [15]
            {
                try
                {
                    if (dgvInformacionEstampado.CurrentCell.Value != null && dgvInformacionEstampado.CurrentCell.Value.ToString().Trim() != "")
                    {
                        if (dgvInformacionEstampado.Rows[e.RowIndex].Cells[13].Value != null && dgvInformacionEstampado.Rows[e.RowIndex].Cells[13].Value.ToString() != "")
                        {
                            decimal mReservados = decimal.Parse(dgvInformacionEstampado.CurrentCell.Value.ToString());
                            decimal mCalculados = decimal.Parse(dgvInformacionEstampado.Rows[e.RowIndex].Cells[13].Value.ToString());
                            if (mCalculados >= mReservados)
                            {
                                decimal mSolicitar = calcularMSolicitar(mCalculados, mReservados); ;
                                dgvInformacionEstampado.Rows[e.RowIndex].Cells[15].Value = mSolicitar;

                                if (txtRendimiento.Text.Trim() != "")
                                {
                                    decimal rendimiento = decimal.Parse(txtRendimiento.Text);
                                    dgvInformacionEstampado.Rows[e.RowIndex].Cells[16].Value = decimal.Round(mSolicitar / rendimiento, 2);
                                }
                            }
                            else
                            {
                                dgvInformacionEstampado.CurrentCell.Value = "";
                                MessageBox.Show("M Reservados no puede ser mayor a M Calculados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            dgvInformacionEstampado.CurrentCell.Value = "";
                            MessageBox.Show("Por favor ingrese el consumo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        dgvInformacionEstampado.Rows[e.RowIndex].Cells[15].Value = dgvInformacionEstampado.Rows[e.RowIndex].Cells[13].Value;
                        dgvInformacionEstampado.Rows[e.RowIndex].Cells[16].Value = decimal.Round(decimal.Parse(dgvInformacionEstampado.Rows[e.RowIndex].Cells[15].Value.ToString()) / decimal.Parse(txtRendimiento.Text), 2);
                    }
                }
                catch (Exception ex)
                {
                    dgvInformacionEstampado.CurrentCell.Value = "";
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            calcularTotalesPorColores();
        }
        #endregion
        private void inicioEstampado()
        {
            if (id == 0)
            {
                cargarDgvInfoConsolidarEstampado(listaEstampado);
            }
            dgvInformacionEstampado.Columns[0].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInformacionEstampado.Columns[1].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInformacionEstampado.Columns[13].HeaderCell.ToolTipText = "(Consumo * Total Unidades)*1.10";
            dgvInformacionEstampado.Columns[15].HeaderCell.ToolTipText = "M calculados -  M reservados";
            dgvInformacionEstampado.Columns[16].HeaderCell.ToolTipText = "M a solicitar / Rendimiento";
        }

        private void cargarDgvInfoConsolidarEstampado(List<MontajeTelaDetalle> prmLista)
        {
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {
                    dgvInformacionEstampado.Rows.Add(
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
                    listaIdSolicitudes.Add(prmLista[i].IdSolTela);
                    listaEsayosRef.Add(prmLista[i].RefSimilar);
                }
                txtNomTela.Text = prmLista[0].DesTela.ToString();
                txtDisenador.Text = prmLista[0].Disenador.ToString();
            }
        }

        private void obtenerColoresEstampado()
        {
            if (listaEstampado.Count > 0) {
                for (int i = 0; i < dgvInformacionEstampado.RowCount; i++)
                {
                    Objeto color = new Objeto();
                    color.Id = dgvInformacionEstampado.Rows[i].Cells[0].Value.ToString().ToLower();
                    color.Nombre = dgvInformacionEstampado.Rows[i].Cells[1].Value.ToString().ToLower();
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
            }
        }

        private bool validarValoresConsumoEstampado()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvInformacionEstampado.Rows)
            {
                if (row.Cells[12].Value == null || row.Cells[12].Value == "")
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        private bool validarValoresReservaEstampado()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvInformacionEstampado.Rows)
            {
                if (row.Cells[14].Value == null || row.Cells[14].Value == "")
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        private bool validarEstampado() {
            bool bandera = false;
            if (dgvInformacionEstampado.RowCount > 0)
            {
                if (!validarValoresConsumoEstampado())
                {
                    if (!validarValoresReservaEstampado())
                    {
                        bandera = true;
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
            return bandera;
        }

        private void obtenerInformacionEstampado()
        {
            if (dgvInformacionEstampado.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvInformacionEstampado.Rows)
                {
                    PedidoMontarInformacion info = new PedidoMontarInformacion();
                    info.IdPedidoAMontar = id;
                    info.CodigoColor = row.Cells[0].Value.ToString();
                    info.DescripcionColor = row.Cells[1].Value.ToString();
                    info.Fondo = row.Cells[2].Value.ToString();
                    info.DescripcionFondo = row.Cells[3].Value.ToString();
                    info.CodigoH1 = "";
                    info.DescripcionH1 = "";
                    info.CodigoH2 = "";
                    info.DescripcionH2 = "";
                    info.CodigoH3 = "";
                    info.DescripcionH3 = "";
                    info.CodigoH4 = "";
                    info.DescripcionH4 = "";
                    info.CodigoH5 = "";
                    info.DescripcionH5 = "";
                    info.Tiendas = (row.Cells[4].Value != null && row.Cells[4].Value.ToString() != "") ? int.Parse(row.Cells[4].Value.ToString()) : 0;
                    info.Exito = (row.Cells[5].Value != null && row.Cells[5].Value.ToString() != "") ? int.Parse(row.Cells[5].Value.ToString()) : 0;
                    info.Cencosud = (row.Cells[6].Value != null && row.Cells[6].Value.ToString() != "") ? int.Parse(row.Cells[6].Value.ToString()) : 0;
                    info.Sao = (row.Cells[7].Value != null && row.Cells[7].Value.ToString() != "") ? int.Parse(row.Cells[7].Value.ToString()) : 0;
                    info.ComercioOrg = (row.Cells[8].Value != null && row.Cells[8].Value.ToString() != "") ? int.Parse(row.Cells[8].Value.ToString()) : 0;
                    info.Rosado = (row.Cells[9].Value != null && row.Cells[9].Value.ToString() != "") ? int.Parse(row.Cells[9].Value.ToString()) : 0;
                    info.Otros = (row.Cells[10].Value != null && row.Cells[10].Value.ToString() != "") ? int.Parse(row.Cells[10].Value.ToString()) : 0;
                    info.TotalUnidades = (row.Cells[11].Value != null && row.Cells[11].Value.ToString() != "") ? int.Parse(row.Cells[11].Value.ToString()) : 0;
                    info.Consumo = (row.Cells[12].Value != null && row.Cells[12].Value.ToString() != "") ? decimal.Parse(row.Cells[12].Value.ToString()) : 0;
                    info.MCalculados = (row.Cells[13].Value != null && row.Cells[13].Value.ToString() != "") ? decimal.Parse(row.Cells[13].Value.ToString()) : 0;
                    info.MReservados = (row.Cells[14].Value != null && row.Cells[14].Value.ToString() != "") ? decimal.Parse(row.Cells[14].Value.ToString()) : 0;
                    info.MSolicitar = (row.Cells[15].Value != null && row.Cells[15].Value.ToString() != "") ? decimal.Parse(row.Cells[15].Value.ToString()) : 0;
                    info.KgCalculados = (row.Cells[16].Value != null && row.Cells[16].Value.ToString() != "") ? decimal.Parse(row.Cells[16].Value.ToString()) : 0;
                    informacion.Add(info);
                }
            }
        }
        #endregion

        #region Plano preteñido
        #region eventos
        private void dgvInformacionPlano_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 11 && e.ColumnIndex < 20 || e.ColumnIndex == 21 || e.ColumnIndex >= 23)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }

        private void dgvInformacionPlano_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvInformacionPlano.CurrentRow.Cells[13].ReadOnly = true;
            dgvInformacionPlano.CurrentRow.Cells[14].ReadOnly = true;
            dgvInformacionPlano.CurrentRow.Cells[15].ReadOnly = true;
            dgvInformacionPlano.CurrentRow.Cells[16].ReadOnly = true;
            dgvInformacionPlano.CurrentRow.Cells[17].ReadOnly = true;
            dgvInformacionPlano.CurrentRow.Cells[18].ReadOnly = true;
            dgvInformacionPlano.CurrentRow.Cells[19].ReadOnly = true;
            dgvInformacionPlano.CurrentRow.Cells[21].ReadOnly = true;
            dgvInformacionPlano.CurrentRow.Cells[23].ReadOnly = true;
            dgvInformacionPlano.CurrentRow.Cells[24].ReadOnly = true;

            if (e.RowIndex > -1 && e.ColumnIndex < 12)
            {
                frmBuscarColor buscarColor = new frmBuscarColor(control);
                buscarColor.StartPosition = FormStartPosition.CenterScreen;

                if (buscarColor.ShowDialog() == DialogResult.OK)
                {
                    Objeto obj = buscarColor.Elemento;
                    if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
                    {
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[0].Value = obj.Id;
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[1].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
                    {
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[2].Value = obj.Id;
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[3].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
                    {
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[4].Value = obj.Id;
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[5].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 6 || e.ColumnIndex == 7)
                    {
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[6].Value = obj.Id;
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[7].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 8 || e.ColumnIndex == 9)
                    {
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[8].Value = obj.Id;
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[9].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 10 || e.ColumnIndex == 11)
                    {
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[10].Value = obj.Id;
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[11].Value = obj.Nombre;
                    }
                }
            }
            calcularTotalesPorColores();
        }

        private void dgvInformacionPlano_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 20) //Cuando cambia el consumo [20] cambia M Calculados [21] y kg Calculado [24]
            {
                try
                {
                    if (dgvInformacionPlano.CurrentCell.Value != null && dgvInformacionPlano.CurrentCell.Value.ToString().Trim() != "")
                    {
                        dgvInformacionPlano.CurrentCell.Value = dgvInformacionPlano.CurrentCell.Value.ToString().Replace(",", ".");
                        dgvInformacionPlano.CurrentCell.Value = Regex.Replace(dgvInformacionPlano.CurrentCell.Value.ToString(), @"[^0-9.]", "");

                        if (dgvInformacionPlano.CurrentCell.Value != null && dgvInformacionPlano.CurrentCell.Value.ToString().Trim() != "")
                        {
                            decimal consumo = decimal.Parse(dgvInformacionPlano.CurrentCell.Value.ToString());
                            int totalUnidades = int.Parse(dgvInformacionPlano.Rows[e.RowIndex].Cells[19].Value.ToString());
                            dgvInformacionPlano.Rows[e.RowIndex].Cells[21].Value = calcularMCalculados(consumo, totalUnidades);


                            // cuando cambia M Calculados [21] se actualiza M Solicitar [23]
                            if (dgvInformacionPlano.Rows[e.RowIndex].Cells[21].Value != null && dgvInformacionPlano.Rows[e.RowIndex].Cells[21].Value.ToString().Trim() != "")
                            {
                                decimal mCalculados = decimal.Parse(dgvInformacionPlano.Rows[e.RowIndex].Cells[21].Value.ToString());

                                if (dgvInformacionPlano.Rows[e.RowIndex].Cells[22].Value != null && dgvInformacionPlano.Rows[e.RowIndex].Cells[22].Value.ToString() != "")
                                {
                                    decimal mReservados = decimal.Parse(dgvInformacionPlano.Rows[e.RowIndex].Cells[22].Value.ToString());
                                    dgvInformacionPlano.Rows[e.RowIndex].Cells[23].Value = calcularMSolicitar(mCalculados, mReservados);
                                    dgvInformacionPlano.Rows[e.RowIndex].Cells[24].Value = decimal.Round(decimal.Parse(dgvInformacionPlano.Rows[e.RowIndex].Cells[23].Value.ToString()) / decimal.Parse(txtRendimiento.Text), 2);

                                }
                                else
                                {
                                    dgvInformacionPlano.Rows[e.RowIndex].Cells[23].Value = mCalculados;
                                }
                            }
                            else
                            {
                                dgvInformacionPlano.Rows[e.RowIndex].Cells[23].Value = "";
                            }
                        }
                    }
                    else
                    {
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[24].Value = "";
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[21].Value = "";
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[23].Value = "";
                    }
                    calcularTotalesPorColores();
                }
                catch (Exception ex)
                {
                    dgvInformacionPlano.CurrentCell.Value = "";
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (e.ColumnIndex == 21) // cuando cambia M Calculados [21] se actualiza M Solicitar [23]
            {
                if (dgvInformacionPlano.CurrentCell.Value != null && dgvInformacionPlano.CurrentCell.Value.ToString().Trim() != "")
                {
                    decimal mCalculados = decimal.Parse(dgvInformacionPlano.Rows[e.RowIndex].Cells[21].Value.ToString());

                    if (dgvInformacionPlano.Rows[e.RowIndex].Cells[22].Value != null && dgvInformacionPlano.Rows[e.RowIndex].Cells[22].Value.ToString() != "")
                    {
                        decimal mReservados = decimal.Parse(dgvInformacionPlano.Rows[e.RowIndex].Cells[12].Value.ToString());
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[23].Value = calcularMSolicitar(mCalculados, mReservados);
                    }
                    else
                    {
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[23].Value = mCalculados;
                    }
                }
                else
                {
                    dgvInformacionPlano.Rows[e.RowIndex].Cells[23].Value = "";
                }
                calcularTotalesPorColores();
            }
            else if (e.ColumnIndex == 22) // cuando cambia M Reservados [22] cambia el M Solicitar [23]
            {
                try
                {
                    if (dgvInformacionPlano.CurrentCell.Value != null && dgvInformacionPlano.CurrentCell.Value.ToString().Trim() != "")
                    {
                        if (dgvInformacionPlano.Rows[e.RowIndex].Cells[21].Value != null && dgvInformacionPlano.Rows[e.RowIndex].Cells[21].Value.ToString() != "")
                        {
                            decimal mReservados = decimal.Parse(dgvInformacionPlano.CurrentCell.Value.ToString());
                            decimal mCalculados = decimal.Parse(dgvInformacionPlano.Rows[e.RowIndex].Cells[21].Value.ToString());
                            if (mCalculados >= mReservados)
                            {
                                decimal mSolicitar = calcularMSolicitar(mCalculados, mReservados); ;
                                dgvInformacionPlano.Rows[e.RowIndex].Cells[23].Value = mSolicitar;

                                if (txtRendimiento.Text.Trim() != "")
                                {
                                    decimal rendimiento = decimal.Parse(txtRendimiento.Text);
                                    dgvInformacionPlano.Rows[e.RowIndex].Cells[24].Value = decimal.Round(mSolicitar / rendimiento, 2);
                                }
                            }
                            else
                            {
                                dgvInformacionPlano.CurrentCell.Value = "";
                                MessageBox.Show("M Reservados no puede ser mayor a M Calculados", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            dgvInformacionPlano.CurrentCell.Value = "";
                            MessageBox.Show("Por favor ingrese el consumo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[23].Value = dgvInformacionPlano.Rows[e.RowIndex].Cells[21].Value;
                        dgvInformacionPlano.Rows[e.RowIndex].Cells[24].Value = decimal.Round(decimal.Parse(dgvInformacionPlano.Rows[e.RowIndex].Cells[23].Value.ToString()) / decimal.Parse(txtRendimiento.Text), 2);

                    }
                    calcularTotalesPorColores();
                }
                catch (Exception ex)
                {
                    dgvInformacionPlano.CurrentCell.Value = "";
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        private void inicioPlano() {
            if (id == 0) {
                cargarDgvInfoConsolidarPlano(listaPlano);
            }

            #region ToolTips
            dgvInformacionPlano.Columns[0].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInformacionPlano.Columns[1].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInformacionPlano.Columns[21].HeaderCell.ToolTipText = "(Consumo * Total Unidades)*1.10";
            dgvInformacionPlano.Columns[23].HeaderCell.ToolTipText = "M calculados -  M reservados";
            dgvInformacionPlano.Columns[24].HeaderCell.ToolTipText = "M a solicitar / Rendimiento";
            #endregion
        }

        private void cargarDgvInfoConsolidarPlano(List<MontajeTelaDetalle> prmLista)
        {
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {

                    dgvInformacionPlano.Rows.Add(prmLista[i].Vte.ToString(),
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
                }
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void obtenerColoresPlano()
        {
            if (listaPlano.Count > 0)
            {
                for (int i = 0; i < dgvInformacionPlano.RowCount; i++)
                {
                    Objeto color = new Objeto();
                    color.Id = dgvInformacionPlano.Rows[i].Cells[0].Value.ToString().ToLower();
                    color.Nombre = dgvInformacionPlano.Rows[i].Cells[1].Value.ToString().ToLower();
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
            }
        }

        private bool validarPlano()
        {
            bool bandera = false;
            if (dgvInformacionPlano.RowCount > 0)
            {
                if (!validarValoresConsumoPlano())
                {
                    if (!validarValoresReservaPlano())
                    {
                        bandera = true;
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
            return bandera;
        }

        private bool validarValoresConsumoPlano()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvInformacionPlano.Rows)
            {
                if (row.Cells[20].Value == null || row.Cells[20].Value.ToString() == "")
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        private bool validarValoresReservaPlano()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvInformacionPlano.Rows)
            {
                if (row.Cells[22].Value == null || row.Cells[22].Value.ToString() == "")
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        private void obtenerInformacionPlano()
        {
            if (dgvInformacionPlano.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvInformacionPlano.Rows)
                {
                    PedidoMontarInformacion info = new PedidoMontarInformacion();
                    info.IdPedidoAMontar = id;
                    info.CodigoColor = (row.Cells[0].Value.ToString());
                    info.DescripcionColor = (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "") ? row.Cells[1].Value.ToString() : "";
                    info.Fondo = "";
                    info.DescripcionFondo = "";
                    info.CodigoH1 = (row.Cells[2].Value != null && row.Cells[2].Value.ToString() != "") ? row.Cells[2].Value.ToString() : "";
                    info.DescripcionH1 = (row.Cells[3].Value != null && row.Cells[3].Value.ToString() != "") ? row.Cells[3].Value.ToString() : "";
                    info.CodigoH2 = (row.Cells[4].Value != null && row.Cells[4].Value.ToString() != "") ? row.Cells[4].Value.ToString() : "";
                    info.DescripcionH2 = (row.Cells[5].Value != null && row.Cells[5].Value.ToString() != "") ? row.Cells[5].Value.ToString() : "";
                    info.CodigoH3 = (row.Cells[6].Value != null && row.Cells[6].Value.ToString() != "") ? row.Cells[6].Value.ToString() : "";
                    info.DescripcionH3 = (row.Cells[7].Value != null && row.Cells[7].Value.ToString() != "") ? row.Cells[7].Value.ToString() : "";
                    info.CodigoH4 = (row.Cells[8].Value != null && row.Cells[8].Value.ToString() != "") ? row.Cells[8].Value.ToString() : "";
                    info.DescripcionH4 = (row.Cells[9].Value != null && row.Cells[9].Value.ToString() != "") ? row.Cells[9].Value.ToString() : "";
                    info.CodigoH5 = (row.Cells[10].Value != null && row.Cells[10].Value.ToString() != "") ? row.Cells[10].Value.ToString() : "";
                    info.DescripcionH5 = (row.Cells[11].Value != null && row.Cells[11].Value.ToString() != "") ? row.Cells[11].Value.ToString() : "";
                    info.Tiendas = (row.Cells[12].Value != null && row.Cells[12].Value.ToString() != "") ? int.Parse(row.Cells[12].Value.ToString()) : 0;
                    info.Exito = (row.Cells[13].Value != null && row.Cells[13].Value.ToString() != "") ? int.Parse(row.Cells[13].Value.ToString()) : 0;
                    info.Cencosud = (row.Cells[14].Value != null && row.Cells[14].Value.ToString() != "") ? int.Parse(row.Cells[14].Value.ToString()) : 0;
                    info.Sao = (row.Cells[15].Value != null && row.Cells[15].Value.ToString() != "") ? int.Parse(row.Cells[15].Value.ToString()) : 0;
                    info.ComercioOrg = (row.Cells[16].Value != null && row.Cells[16].Value.ToString() != "") ? int.Parse(row.Cells[16].Value.ToString()) : 0;
                    info.Rosado = (row.Cells[17].Value != null && row.Cells[17].Value.ToString() != "") ? int.Parse(row.Cells[17].Value.ToString()) : 0;
                    info.Otros = (row.Cells[18].Value != null && row.Cells[18].Value.ToString() != "") ? int.Parse(row.Cells[18].Value.ToString()) : 0;
                    info.TotalUnidades = (row.Cells[19].Value != null && row.Cells[19].Value.ToString() != "") ? int.Parse(row.Cells[19].Value.ToString()) : 0;
                    info.Consumo = (row.Cells[20].Value != null && row.Cells[20].Value.ToString() != "") ? decimal.Parse(row.Cells[20].Value.ToString()) : 0;
                    info.MCalculados = (row.Cells[21].Value != null && row.Cells[21].Value.ToString() != "") ? decimal.Parse(row.Cells[21].Value.ToString()) : 0;
                    info.MReservados = (row.Cells[22].Value != null && row.Cells[22].Value.ToString() != "") ? decimal.Parse(row.Cells[22].Value.ToString()) : 0;
                    info.MSolicitar = (row.Cells[23].Value != null && row.Cells[23].Value.ToString() != "") ? decimal.Parse(row.Cells[23].Value.ToString()) : 0;
                    info.KgCalculados = (row.Cells[24].Value != null && row.Cells[24].Value.ToString() != "") ? decimal.Parse(row.Cells[24].Value.ToString()) : 0;
                    informacion.Add(info);
                }
            }
        }

        private void obtenerInformacionCuello()
        {
            if (dgvInfoConsolidar.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgvInfoConsolidar.Rows)
                {
                    PedidoMontarInformacion info = new PedidoMontarInformacion();
                    info.IdPedidoAMontar = id;
                    info.CodigoColor = (row.Cells[0].Value.ToString());
                    info.DescripcionColor = (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "") ? row.Cells[1].Value.ToString() : "";
                    info.Fondo = "";info.DescripcionFondo = "";
                    info.CodigoH1 = (row.Cells[2].Value != null && row.Cells[2].Value.ToString() != "") ? row.Cells[2].Value.ToString() : "";
                    info.DescripcionH1 = (row.Cells[3].Value != null && row.Cells[3].Value.ToString() != "") ? row.Cells[3].Value.ToString() : "";
                    info.CodigoH2 = (row.Cells[4].Value != null && row.Cells[4].Value.ToString() != "") ? row.Cells[4].Value.ToString() : "";
                    info.DescripcionH2 = (row.Cells[5].Value != null && row.Cells[5].Value.ToString() != "") ? row.Cells[5].Value.ToString() : "";
                    info.CodigoH3 = (row.Cells[6].Value != null && row.Cells[6].Value.ToString() != "") ? row.Cells[6].Value.ToString() : "";
                    info.DescripcionH3 = (row.Cells[7].Value != null && row.Cells[7].Value.ToString() != "") ? row.Cells[7].Value.ToString() : "";
                    info.CodigoH4 = (row.Cells[8].Value != null && row.Cells[8].Value.ToString() != "") ? row.Cells[8].Value.ToString() : "";
                    info.DescripcionH4 = (row.Cells[9].Value != null && row.Cells[9].Value.ToString() != "") ? row.Cells[9].Value.ToString() : "";
                    info.CodigoH5 = (row.Cells[10].Value != null && row.Cells[10].Value.ToString() != "") ? row.Cells[10].Value.ToString() : "";
                    info.DescripcionH5 = (row.Cells[11].Value != null && row.Cells[11].Value.ToString() != "") ? row.Cells[11].Value.ToString() : "";
                    info.TotalUnidades = (row.Cells[12].Value != null && row.Cells[12].Value.ToString() != "") ? int.Parse(row.Cells[12].Value.ToString()) : 0;
                    info.Tiendas =0;info.Exito = 0;info.Cencosud = 0;info.Sao =  0; info.ComercioOrg = 0;info.Rosado =  0;info.Otros =  0;
                    informacion.Add(info);
                }
            }
        }

        #endregion

        #region Cuellos Puños Tiras
        private void inicioCuello()
        {
            if (id == 0)
            {
                CargarDgvInfoConsolidar(listaCuello);
                CargarDgvCuellos(listaCuello);
            }
        }
        
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
                    txtDesPrenda.Text = prmLista[i].DescPrenda.ToString();
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
                    if (obj.Id == color.Id)
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
                PedidoCuellos objColor = new PedidoCuellos(obj.Id, obj.Nombre);
                for (int i = 0; i < dgvProporcion.RowCount; i++)
                {
                    if (dgvProporcion.Rows[i].Cells[0].Value.ToString().ToLower() == obj.Id)
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
                    if (obj.Id == color.Id)
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
                    if (dgvInfoConsolidar.Rows[i].Cells[0].Value.ToString().ToLower() == obj.Id)
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

        private bool validarCuello()
        {
            bool bandera = false;
            if (dgvConsolidar.RowCount > 0)
            {
                if (!validarTotalCuello())
                {
                    bandera = true;
                }
                else
                {
                    MessageBox.Show("Por favor ingrese los valores para la columna: Consumo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            return bandera;
        }
        
        private bool validarTotalCuello()
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

        private void GuardarProporcion(int id)
        {
            for (int i = 0; i < dgvProporcion.RowCount; i++)
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
                control.addPedidoCoordinadoCuellosProporcion(detalle);
            }
        }

        #endregion

        #region Métodos generales

        #region eventos

        private void dgvConsolidar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex <= 11)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }
        #endregion

        /// <summary>
    /// Permite cargar una lista con todos los id_solicitud seleccionados.
    /// </summary>
    /// <param name="prmLista">Lista de tipo MontajeTelaDetalle, la cual representa las filas seleccionadas en el vista  inicial de filtros (frmSolicitudListaTelas).</param>
        private void cargarSolicitudes(List<MontajeTelaDetalle> prmLista)
        {
            List<int> listaSolicitudes = new List<int>();
            for (int i = 0; i < prmLista.Count; i++)
            {
                listaSolicitudes.Add(prmLista[i].IdSolTela);
            }
            listaIdSolicitudes = listaSolicitudes.Distinct().ToList();
        }

        /// <summary> Carga la información de la vista. </summary>
        private void cargar()
        {
            PedidoAMontar pedido = control.getPedidoCoordinado(idSolicitud);
            id = pedido.Id;
            if (id != 0)
            {
                existia = true;
                txtNomTela.Text = pedido.Tela.ToString();
                txtDisenador.Text = pedido.Disenador.ToString();
                txtEnsayoRef.Text = pedido.EnsayoReferencia.ToString();
                txtDesPrenda.Text = pedido.DescripcionPrenda.ToString();
                cbxClase.Text = pedido.Clase.ToString();
                txtRendimiento.Text = pedido.Rendimiento.ToString();
                txtAnalista.Text = pedido.AnalistasCortesB.ToString();
                dtpFechaLlegada.Text = pedido.FechaLlegada.ToString();
                cbxTipoMarcacion.Text = pedido.TipoMarcacion.ToString();

                /* Carga Pedido */
                List<TomarDelPedido> listaPedido = control.getPedido(pedido.Id);
                if (listaPedido.Count > 0)
                {
                    foreach (TomarDelPedido obj in listaPedido)
                    {
                        dgvPedidos.Rows.Add(obj.NumeroPedido, obj.CodigoColor, obj.Estado, obj.Disponible);
                    }
                }
                /*Carga detalle Información a  Consolidar*/
                List<PedidoMontarInformacion> listaInfoConsolidar = control.getPedidoCoordinadoInformacion(pedido.Id);
                if (listaInfoConsolidar.Count > 0)
                {
                    foreach (PedidoMontarInformacion obj in listaInfoConsolidar)
                    {
                        if (obj.Fondo.Trim() == "" && obj.CodigoH1.Trim() == "")
                        {
                            dgvInformacionUnicolor.Rows.Add(obj.CodigoColor, obj.DescripcionColor, obj.Tiendas, obj.Exito,
                            obj.Cencosud, obj.Sao, obj.ComercioOrg, obj.Rosado, obj.Otros, obj.TotalUnidades, obj.Consumo, obj.MCalculados, obj.MReservados, obj.MSolicitar, obj.KgCalculados);
                        }
                        else if (obj.Fondo.Trim() != "")
                        {
                            dgvInformacionEstampado.Rows.Add(obj.CodigoColor, obj.DescripcionColor, obj.Fondo, obj.DescripcionFondo, obj.Tiendas, obj.Exito,
                            obj.Cencosud, obj.Sao, obj.ComercioOrg, obj.Rosado, obj.Otros, obj.TotalUnidades, obj.Consumo, obj.MCalculados, obj.MReservados, obj.MSolicitar, obj.KgCalculados);
                        }
                        else if (obj.Fondo.Trim() == "" && obj.CodigoH1.Trim() != "")
                        {
                            dgvInformacionPlano.Rows.Add(obj.CodigoColor, obj.DescripcionColor, obj.CodigoH1, obj.DescripcionH1, obj.CodigoH2, obj.DescripcionH2, obj.CodigoH3, obj.DescripcionH3, obj.CodigoH4, obj.DescripcionH4, obj.CodigoH5, obj.DescripcionH5, obj.Tiendas, obj.Exito,
                            obj.Cencosud, obj.Sao, obj.ComercioOrg, obj.Rosado, obj.Otros, obj.TotalUnidades, obj.Consumo, obj.MCalculados, obj.MReservados, obj.MSolicitar, obj.KgCalculados);
                        }else if (obj.MCalculados == 0 && obj.MSolicitar == 0 && obj.CodigoH1 != "")
                        {
                            dgvInfoConsolidar.Rows.Add(obj.CodigoColor, obj.DescripcionColor, obj.CodigoH1, obj.DescripcionH1, obj.CodigoH2, obj.DescripcionH2, obj.CodigoH3, obj.DescripcionH3, obj.CodigoH4, obj.DescripcionH4, obj.CodigoH5, obj.DescripcionH5, obj.TotalUnidades);
                        }

                    }
                }

                /*Carga detalle Toltal a  Consolidar*/
                List<PedidoMontarTotal> listaTotalConsolidado = control.getPedidoCoordinadoTotal(pedido.Id);
                //List<PedidoMontarTotal> listaTotalConsolidado = control.getPedidoCoordinadoTotal(pedido.Id);

                if (listaTotalConsolidado.Count > 0)
                {
                    foreach (PedidoMontarTotal obj in listaTotalConsolidado)
                    {
                        dgvConsolidar.Rows.Add(obj.CodidoColor, obj.DescripcionColor, obj.Tiendas, obj.Exito,
                            obj.Cencosud, obj.Sao, obj.ComercioOrg, obj.Rosado, obj.Otros, obj.TotalUnidades,
                            obj.MCalculados, obj.KgCalculados, obj.TotalPedir, obj.UnidadMedida);
                    }
                }
            }
            else {
                cargarListas();
                if (listaUnicolor.Count == 0)
                {
                    ((Control)this.tabPage1).Enabled = false;
                }
                else
                {
                    inicioUnicolor();
                }

                if (listaEstampado.Count == 0)
                {
                    ((Control)this.tabPage2).Enabled = false;
                }
                else
                {
                    inicioEstampado();
                }

                if (listaPlano.Count == 0)
                {
                    ((Control)this.tabPage3).Enabled = false;
                }
                else
                {
                    inicioPlano();
                }
                if (listaCuello.Count == 0)
                {
                    ((Control)this.tabPage4).Enabled = false;
                }
                else
                {
                    dgvProporcion.Visible = true;
                    dgvConsolidar.Visible = false;
                    ///dgvPedidos.Visible = false;
                    inicioCuello();
                }
                calcularTotalesPorColores();
            }
        }

        /// <summary>
        ///  Calcula y edita algunos de los campos de los dataGridView de la vista según los colores cargados.
        /// </summary>
        private void calcularTotalesPorColores()
        {
            colores = new List<Objeto>();
            obtenerColoresUnicolor();
            obtenerColoresEstampado();
            obtenerColoresPlano();
            List<PedidoMontarTotal> subTotales = new List<PedidoMontarTotal>();
            List<PedidoMontarTotal> totales = new List<PedidoMontarTotal>();
            //Unicolor
            foreach (Objeto obj in colores)
            {
                PedidoMontarTotal objColor = new PedidoMontarTotal(0, obj.Id, obj.Nombre, "", "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "");
                for (int i = 0; i < dgvInformacionUnicolor.RowCount; i++)
                {
                    if (dgvInformacionUnicolor.Rows[i].Cells[1].Value.ToString().ToLower() == obj.Nombre)
                    {
                        objColor.Tiendas += (dgvInformacionUnicolor.Rows[i].Cells[2].Value != null && dgvInformacionUnicolor.Rows[i].Cells[2].Value.ToString() != "") ? int.Parse(dgvInformacionUnicolor.Rows[i].Cells[2].Value.ToString()) : 0;
                        objColor.Exito += (dgvInformacionUnicolor.Rows[i].Cells[3].Value != null && dgvInformacionUnicolor.Rows[i].Cells[3].Value.ToString() != "") ? int.Parse(dgvInformacionUnicolor.Rows[i].Cells[3].Value.ToString()) : 0;
                        objColor.Cencosud += (dgvInformacionUnicolor.Rows[i].Cells[4].Value != null && dgvInformacionUnicolor.Rows[i].Cells[4].Value.ToString() != "") ? int.Parse(dgvInformacionUnicolor.Rows[i].Cells[4].Value.ToString()) : 0;
                        objColor.Sao += (dgvInformacionUnicolor.Rows[i].Cells[5].Value != null && dgvInformacionUnicolor.Rows[i].Cells[5].Value.ToString() != "") ? int.Parse(dgvInformacionUnicolor.Rows[i].Cells[5].Value.ToString()) : 0;
                        objColor.ComercioOrg += (dgvInformacionUnicolor.Rows[i].Cells[6].Value != null && dgvInformacionUnicolor.Rows[i].Cells[6].Value.ToString() != "") ? int.Parse(dgvInformacionUnicolor.Rows[i].Cells[6].Value.ToString()) : 0;
                        objColor.Rosado += (dgvInformacionUnicolor.Rows[i].Cells[7].Value != null && dgvInformacionUnicolor.Rows[i].Cells[7].Value.ToString() != "") ? int.Parse(dgvInformacionUnicolor.Rows[i].Cells[7].Value.ToString()) : 0;
                        objColor.Otros += (dgvInformacionUnicolor.Rows[i].Cells[8].Value != null && dgvInformacionUnicolor.Rows[i].Cells[8].Value.ToString() != "") ? int.Parse(dgvInformacionUnicolor.Rows[i].Cells[8].Value.ToString()) : 0;
                        objColor.TotalUnidades += (dgvInformacionUnicolor.Rows[i].Cells[9].Value != null && dgvInformacionUnicolor.Rows[i].Cells[9].Value.ToString() != "") ? int.Parse(dgvInformacionUnicolor.Rows[i].Cells[9].Value.ToString()) : 0;
                        objColor.MCalculados += (dgvInformacionUnicolor.Rows[i].Cells[11].Value != null && dgvInformacionUnicolor.Rows[i].Cells[11].Value.ToString() != "") ? decimal.Parse(dgvInformacionUnicolor.Rows[i].Cells[11].Value.ToString()) : 0;
                        objColor.KgCalculados += (dgvInformacionUnicolor.Rows[i].Cells[14].Value != null && dgvInformacionUnicolor.Rows[i].Cells[14].Value.ToString() != "") ? decimal.Parse(dgvInformacionUnicolor.Rows[i].Cells[14].Value.ToString()) : 0;
                    }
                }
                subTotales.Add(objColor);
            }

            //Estampado
            foreach (Objeto obj in colores)
            {
                PedidoMontarTotal objColor = new PedidoMontarTotal(0, obj.Id, obj.Nombre, "", "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "");
                for (int i = 0; i < dgvInformacionEstampado.RowCount; i++)
                {
                    if (dgvInformacionEstampado.Rows[i].Cells[1].Value.ToString().ToLower() == obj.Nombre)
                    {
                        objColor.Fondo = dgvInformacionEstampado.Rows[i].Cells[2].Value.ToString();
                        objColor.DescripcionFondo = dgvInformacionEstampado.Rows[i].Cells[3].Value.ToString();
                        objColor.Tiendas += (dgvInformacionEstampado.Rows[i].Cells[4].Value != null && dgvInformacionEstampado.Rows[i].Cells[4].Value.ToString() != "") ? int.Parse(dgvInformacionEstampado.Rows[i].Cells[4].Value.ToString()) : 0;
                        objColor.Exito += (dgvInformacionEstampado.Rows[i].Cells[5].Value != null && dgvInformacionEstampado.Rows[i].Cells[5].Value.ToString() != "") ? int.Parse(dgvInformacionEstampado.Rows[i].Cells[5].Value.ToString()) : 0;
                        objColor.Cencosud += (dgvInformacionEstampado.Rows[i].Cells[6].Value != null && dgvInformacionEstampado.Rows[i].Cells[6].Value.ToString() != "") ? int.Parse(dgvInformacionEstampado.Rows[i].Cells[6].Value.ToString()) : 0;
                        objColor.Sao += (dgvInformacionEstampado.Rows[i].Cells[7].Value != null && dgvInformacionEstampado.Rows[i].Cells[7].Value.ToString() != "") ? int.Parse(dgvInformacionEstampado.Rows[i].Cells[7].Value.ToString()) : 0;
                        objColor.ComercioOrg += (dgvInformacionEstampado.Rows[i].Cells[8].Value != null && dgvInformacionEstampado.Rows[i].Cells[8].Value.ToString() != "") ? int.Parse(dgvInformacionEstampado.Rows[i].Cells[8].Value.ToString()) : 0;
                        objColor.Rosado += (dgvInformacionEstampado.Rows[i].Cells[9].Value != null && dgvInformacionEstampado.Rows[i].Cells[9].Value.ToString() != "") ? int.Parse(dgvInformacionEstampado.Rows[i].Cells[9].Value.ToString()) : 0;
                        objColor.Otros += (dgvInformacionEstampado.Rows[i].Cells[10].Value != null && dgvInformacionEstampado.Rows[i].Cells[10].Value.ToString() != "") ? int.Parse(dgvInformacionEstampado.Rows[i].Cells[10].Value.ToString()) : 0;
                        objColor.TotalUnidades += (dgvInformacionEstampado.Rows[i].Cells[11].Value != null && dgvInformacionEstampado.Rows[i].Cells[11].Value.ToString() != "") ? int.Parse(dgvInformacionEstampado.Rows[i].Cells[11].Value.ToString()) : 0;
                        objColor.MCalculados += (dgvInformacionEstampado.Rows[i].Cells[13].Value != null && dgvInformacionEstampado.Rows[i].Cells[13].Value.ToString() != "") ? decimal.Parse(dgvInformacionEstampado.Rows[i].Cells[13].Value.ToString()) : 0;
                        objColor.KgCalculados += (dgvInformacionEstampado.Rows[i].Cells[16].Value != null && dgvInformacionEstampado.Rows[i].Cells[16].Value.ToString() != "") ? decimal.Parse(dgvInformacionEstampado.Rows[i].Cells[16].Value.ToString()) : 0;
                    }
                }
                subTotales.Add(objColor);
            }

            //Plano
            foreach (Objeto obj in colores)
            {
                PedidoMontarTotal objColor = new PedidoMontarTotal(0, obj.Id, obj.Nombre, "", "", 0, "", 0, "", 0, "", 0, "", 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "");
                for (int i = 0; i < dgvInformacionPlano.RowCount; i++)
                {
                    if (dgvInformacionPlano.Rows[i].Cells[1].Value.ToString().ToLower() == obj.Nombre)
                    {
                        objColor.Tiendas += (dgvInformacionPlano.Rows[i].Cells[12].Value != null && dgvInformacionPlano.Rows[i].Cells[12].Value.ToString() != "") ? int.Parse(dgvInformacionPlano.Rows[i].Cells[12].Value.ToString()) : 0;
                        objColor.Exito += (dgvInformacionPlano.Rows[i].Cells[13].Value != null && dgvInformacionPlano.Rows[i].Cells[13].Value.ToString() != "") ? int.Parse(dgvInformacionPlano.Rows[i].Cells[13].Value.ToString()) : 0;
                        objColor.Cencosud += (dgvInformacionPlano.Rows[i].Cells[14].Value != null && dgvInformacionPlano.Rows[i].Cells[14].Value.ToString() != "") ? int.Parse(dgvInformacionPlano.Rows[i].Cells[14].Value.ToString()) : 0;
                        objColor.Sao += (dgvInformacionPlano.Rows[i].Cells[15].Value != null && dgvInformacionPlano.Rows[i].Cells[15].Value.ToString() != "") ? int.Parse(dgvInformacionPlano.Rows[i].Cells[15].Value.ToString()) : 0;
                        objColor.ComercioOrg += (dgvInformacionPlano.Rows[i].Cells[16].Value != null && dgvInformacionPlano.Rows[i].Cells[16].Value.ToString() != "") ? int.Parse(dgvInformacionPlano.Rows[i].Cells[16].Value.ToString()) : 0;
                        objColor.Rosado += (dgvInformacionPlano.Rows[i].Cells[17].Value != null && dgvInformacionPlano.Rows[i].Cells[17].Value.ToString() != "") ? int.Parse(dgvInformacionPlano.Rows[i].Cells[17].Value.ToString()) : 0;
                        objColor.Otros += (dgvInformacionPlano.Rows[i].Cells[18].Value != null && dgvInformacionPlano.Rows[i].Cells[18].Value.ToString() != "") ? int.Parse(dgvInformacionPlano.Rows[i].Cells[18].Value.ToString()) : 0;
                        objColor.TotalUnidades += (dgvInformacionPlano.Rows[i].Cells[19].Value != null && dgvInformacionPlano.Rows[i].Cells[19].Value.ToString() != "") ? int.Parse(dgvInformacionPlano.Rows[i].Cells[19].Value.ToString()) : 0;
                        objColor.MCalculados += (dgvInformacionPlano.Rows[i].Cells[21].Value != null && dgvInformacionPlano.Rows[i].Cells[21].Value.ToString() != "") ? decimal.Parse(dgvInformacionPlano.Rows[i].Cells[21].Value.ToString()) : 0;
                        objColor.KgCalculados += (dgvInformacionPlano.Rows[i].Cells[24].Value != null && dgvInformacionPlano.Rows[i].Cells[24].Value.ToString() != "") ? decimal.Parse(dgvInformacionPlano.Rows[i].Cells[24].Value.ToString()) : 0;
                    }
                }
                subTotales.Add(objColor);
            }


            foreach (Objeto objColor in colores) {
                PedidoMontarTotal elemento = new PedidoMontarTotal();
                elemento.CodidoColor = objColor.Id;
                elemento.DescripcionColor = objColor.Nombre;
                foreach (PedidoMontarTotal subTotal in subTotales)
                {
                    if (objColor.Nombre.ToLower() == subTotal.DescripcionColor.ToLower()) {
                        elemento.Tiendas += subTotal.Tiendas;
                        elemento.Exito += subTotal.Exito;
                        elemento.Cencosud += subTotal.Cencosud;
                        elemento.Sao += subTotal.Sao;
                        elemento.ComercioOrg += subTotal.ComercioOrg;
                        elemento.Rosado += subTotal.Rosado;
                        elemento.Otros += subTotal.Otros;
                        elemento.TotalUnidades += subTotal.TotalUnidades;
                        elemento.MCalculados += subTotal.MCalculados;
                        elemento.KgCalculados += subTotal.KgCalculados;
                    }
                }
                totales.Add(elemento);
            }

            if (totales.Count != 0)
            {
                //Si hay más filas en total consolidado que colores se eliminan filas
                if (totales.Count < dgvConsolidar.Rows.Count)
                {
                    for (int i = totales.Count; i < dgvConsolidar.Rows.Count; i++)
                    {
                        dgvConsolidar.Rows.RemoveAt(i);
                    }
                }//Si hay más colores que filas en total consolidado se agregan filas
                else if (totales.Count > dgvConsolidar.Rows.Count)
                {
                    for (int i = dgvConsolidar.Rows.Count; i < totales.Count; i++)
                    {
                        dgvConsolidar.Rows.Add();
                    }
                }
                //Se agrega la información en las filas
                for (int i = 0; i < totales.Count; i++)
                {
                    dgvConsolidar.Rows[i].Cells[0].Value = totales[i].CodidoColor;
                    dgvConsolidar.Rows[i].Cells[1].Value = totales[i].DescripcionColor.ToUpper();
                    dgvConsolidar.Rows[i].Cells[2].Value = totales[i].Tiendas.ToString();
                    dgvConsolidar.Rows[i].Cells[3].Value = totales[i].Exito.ToString();
                    dgvConsolidar.Rows[i].Cells[4].Value = totales[i].Cencosud.ToString();
                    dgvConsolidar.Rows[i].Cells[5].Value = totales[i].Sao.ToString();
                    dgvConsolidar.Rows[i].Cells[6].Value = totales[i].ComercioOrg.ToString();
                    dgvConsolidar.Rows[i].Cells[7].Value = totales[i].Rosado.ToString();
                    dgvConsolidar.Rows[i].Cells[8].Value = totales[i].Otros.ToString();
                    dgvConsolidar.Rows[i].Cells[9].Value = totales[i].TotalUnidades.ToString();
                    dgvConsolidar.Rows[i].Cells[10].Value = totales[i].MCalculados.ToString();
                    dgvConsolidar.Rows[i].Cells[11].Value = totales[i].KgCalculados.ToString();
                }
            }
        }

        private bool validarGeneral()
        {
            bool bandera = false;
            if (cbxClase.Text.ToLower() == "no tejer" && dgvPedidos.RowCount == 0)
            {
                MessageBox.Show("Por favor seleccione al menos un pedido a montar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (cbxClase.SelectedIndex != -1)
                {
                    if (cbxTipoMarcacion.Text != "")
                    {
                        if (txtRendimiento.Text.Trim() != "")
                        {
                            if (txtAnalista.Text != "")
                            {
                                if (txtDesPrenda.Text != "")
                                {
                                    bandera = true;
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
            return bandera;
        }

        private bool validarTotalAPedir()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvConsolidar.Rows)
            {
                if (row.Cells[12].Value == null || row.Cells[12].Value.ToString() == "")
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        private bool validarUnidadTotal()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvConsolidar.Rows)
            {
                if (row.Cells[13].Value == null || row.Cells[13].Value.ToString() == "")
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        private void guardarPedido()
        {
            PedidoAMontar pedido = new PedidoAMontar();
            pedido.Tela = txtNomTela.Text.Trim();
            pedido.Disenador = txtDisenador.Text.Trim();
            pedido.Rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
            pedido.EnsayoReferencia = txtEnsayoRef.Text.Trim();
            pedido.DescripcionPrenda = txtDesPrenda.Text.Trim();
            pedido.Clase = cbxClase.SelectedItem.ToString();
            pedido.TipoMarcacion = cbxTipoMarcacion.GetItemText(cbxTipoMarcacion.SelectedItem);
            pedido.Rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
            pedido.AnalistasCortesB = txtAnalista.Text.Trim();
            pedido.FechaLlegada = dtpFechaLlegada.Value.ToString("dd/MM/yyyy");
            pedido.IdSolicitud = idSolicitud;
            if (control.existePedidoCoordinado(idSolicitud))
            {
                control.actualizarPedidoCoordinado(pedido);
            }
            else
            {
                control.addPedidoCoordinado(pedido);
                id = control.getIdPedidoCoordinado(idSolicitud);
            }
        }

        private void guardarTomarDelPedido()
        {
            for (int i = 0; i < dgvPedidos.RowCount; i++)
            {
                TomarDelPedido pedido = new TomarDelPedido();
                pedido.IdPedidoMontar = id;
                pedido.NumeroPedido = (dgvPedidos.Rows[i].Cells[0].Value.ToString());
                pedido.CodigoColor = (dgvPedidos.Rows[i].Cells[1].Value != null && dgvPedidos.Rows[i].Cells[1].Value.ToString() != "") ? int.Parse(dgvPedidos.Rows[i].Cells[1].Value.ToString()) : 0;
                pedido.Estado = (dgvPedidos.Rows[i].Cells[2].Value != null && dgvPedidos.Rows[i].Cells[2].Value.ToString() != "") ? dgvPedidos.Rows[i].Cells[2].Value.ToString() : "";
                pedido.Disponible = (dgvPedidos.Rows[i].Cells[3].Value != null && dgvPedidos.Rows[i].Cells[3].Value.ToString() != "") ? decimal.Parse(dgvPedidos.Rows[i].Cells[3].Value.ToString()) : 0;
                pedido.TipoPedido = "COORDINADO";
                control.addPedido(pedido);
            }
        }

        private void guardarInformacion()
        {
            informacion = new List<PedidoMontarInformacion>();
            obtenerInformacionUnicolor();
            obtenerInformacionEstampado();
            obtenerInformacionPlano();
            obtenerInformacionCuello();
            foreach (PedidoMontarInformacion info in informacion) {
                control.addPedidoCoordinadoInformacion(info);
            }
        }

        private void guardarTotal()
        {
            foreach (DataGridViewRow row in dgvConsolidar.Rows)
            {
                PedidoMontarTotal total = new PedidoMontarTotal();
                total.IdPedidoAmontar = id;
                total.CodidoColor = row.Cells[0].Value.ToString();
                total.DescripcionColor = row.Cells[1].Value.ToString();
                total.Tiendas = int.Parse(row.Cells[2].Value.ToString());
                total.Exito = int.Parse(row.Cells[3].Value.ToString());
                total.Cencosud = int.Parse(row.Cells[4].Value.ToString());
                total.Sao = int.Parse(row.Cells[5].Value.ToString());
                total.ComercioOrg = int.Parse(row.Cells[6].Value.ToString());
                total.Rosado = int.Parse(row.Cells[7].Value.ToString());
                total.Otros = int.Parse(row.Cells[8].Value.ToString());
                total.TotalUnidades = int.Parse(row.Cells[9].Value.ToString());
                total.MCalculados = decimal.Parse(row.Cells[10].Value.ToString());
                total.KgCalculados = decimal.Parse(row.Cells[11].Value.ToString());
                total.TotalPedir = decimal.Parse(row.Cells[12].Value.ToString());
                total.UnidadMedida = row.Cells[13].Value.ToString();
                control.addPedidoCoordinadoTotal(total);
            }
        }

        /* <summary> Agrega el consolidado a lista de solicitudes seleccionadas en la vista frmSolicitudListaTelas, 
            * al momento de dar clic en Guardar.</summary>*/
        private void agregarConsolidado()
        {
            int maxConsolidado = control.consultarMaxConsolidado();
            for (int i = 0; i < listaIdSolicitudes.Count; i++)
            {
                control.agregarConsolidado(listaIdSolicitudes[i], maxConsolidado + 1, "COORDINADO");
            }

        }

    #endregion

        #region otros métodos
        private decimal calcularMCalculados(decimal consumo, int totalUnidades)
        {
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

        private void txtRendimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtRendimiento.Text.Trim() != "")
            {
                validacion.validarDecimal(sender, e);
            }
        }

        private void txtRendimiento_TextChanged(object sender, EventArgs e)
        {
            //Unicolor
            try
            {
                for (int i = 0; i < dgvInformacionUnicolor.RowCount; i++)
                {
                    if (txtRendimiento.Text.Trim() != "")
                    {
                        if (dgvInformacionUnicolor.Rows[i].Cells[13].Value != null && dgvInformacionUnicolor.Rows[i].Cells[13].Value.ToString() != "")
                        {
                            decimal mSolicitar = decimal.Parse(dgvInformacionUnicolor.Rows[i].Cells[13].Value.ToString());
                            decimal rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
                            dgvInformacionUnicolor.Rows[i].Cells[14].Value = calcularKgCalculados(mSolicitar, rendimiento);
                        }
                    }
                    else
                    {
                        dgvInformacionUnicolor.Rows[i].Cells[14].Value = 0;
                    }
                }

                calcularTotalesPorColores();
            }
            catch
            {
                txtRendimiento.Text = "";
            }
            //Estampado
            try
            {
                for (int i = 0; i < dgvInformacionEstampado.RowCount; i++)
                {
                    if (txtRendimiento.Text.Trim() != "")
                    {
                        if (dgvInformacionEstampado.Rows[i].Cells[15].Value != null && dgvInformacionEstampado.Rows[i].Cells[15].Value.ToString() != "")
                        {
                            decimal mSolicitar = decimal.Parse(dgvInformacionEstampado.Rows[i].Cells[15].Value.ToString());
                            decimal rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
                            dgvInformacionEstampado.Rows[i].Cells[16].Value = calcularKgCalculados(mSolicitar, rendimiento);
                        }
                    }
                    else
                    {
                        dgvInformacionEstampado.Rows[i].Cells[16].Value = 0;
                    }
                }
                calcularTotalesPorColores();
            }
            catch
            {
                txtRendimiento.Text = "";
            }
            //Plano preteñido
            try
            {
                for (int i = 0; i < dgvInformacionPlano.RowCount; i++)
                {
                    if (txtRendimiento.Text.Trim() != "")
                    {
                        if (dgvInformacionPlano.Rows[i].Cells[23].Value != null && dgvInformacionPlano.Rows[i].Cells[23].Value.ToString() != "")
                        {
                            decimal mSolicitar = decimal.Parse(dgvInformacionPlano.Rows[i].Cells[23].Value.ToString());
                            decimal rendimiento = decimal.Parse(txtRendimiento.Text.Trim());
                            dgvInformacionPlano.Rows[i].Cells[24].Value = calcularKgCalculados(mSolicitar, rendimiento);
                        }
                    }
                    else
                    {
                        dgvInformacionPlano.Rows[i].Cells[24].Value = 0;
                    }
                }

                calcularTotalesPorColores();
            }
            catch
            {
                txtRendimiento.Text = "";
            }
        }

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
        #endregion
    }
}
