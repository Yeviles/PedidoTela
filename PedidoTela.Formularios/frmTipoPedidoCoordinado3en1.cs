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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidoTela.Formularios
{
    public partial class frmTipoPedidoCoordinado3en1 : MaterialSkin.Controls.MaterialForm
    {
        #region variables
        private Controlador control = new Controlador();
        private List<MontajeTelaDetalle> listaSolicitudes = new List<MontajeTelaDetalle>();
        List<MontajeTelaDetalle> listaUnicolor = new List<MontajeTelaDetalle>();
        List<MontajeTelaDetalle> listaEstampado = new List<MontajeTelaDetalle>();
        List<MontajeTelaDetalle> listaPlano = new List<MontajeTelaDetalle>();
        private List<int> listaIdSolicitudes = new List<int>();
        private List<string> listaEsayosRef = new List<string>();
        private int idSolicitudEstampado, id, consecutivo;
        #endregion

        public frmTipoPedidoCoordinado3en1(Controlador control, List<MontajeTelaDetalle> solicitudes, string principal, string coordinado1, string coordinado2)
        {
            this.control = control;
            this.listaSolicitudes = solicitudes;
            cargarListas();
            InitializeComponent();

            if (listaUnicolor.Count == 0)
            {
                ((Control)this.tabPage1).Enabled = false;
            }

            if (listaEstampado.Count == 0)
            {
                ((Control)this.tabPage2).Enabled = false;
            }
            else {
                inicioEstampado();
            }

            if (listaPlano.Count == 0)
            {
                ((Control)this.tabPage3).Enabled = false;
            }
        }

        private void frmTipoPedSelecCoordinar_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
        }

        private void cargarListas()
        {
            foreach (MontajeTelaDetalle solicitud in listaSolicitudes)
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
            }
        }

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
                    idSolicitudEstampado = prmLista[i].IdSolTela;
                    listaIdSolicitudes.Add(prmLista[i].IdSolTela);
                    listaEsayosRef.Add(prmLista[i].RefSimilar);
                }
                txtNomTela.Text = prmLista[0].DesTela.ToString();
                txtDisenador.Text = prmLista[0].Disenador.ToString();
            }
        }

        private void calcularTotalesPorColores()
        {
            List<Objeto> colores = new List<Objeto>();
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
            List<PedidoMontarTotal> totales = new List<PedidoMontarTotal>();
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
                totales.Add(objColor);
            }

            if (totales.Count != 0)
            {
                //Si hay más filas en total consolidado que colores se eliminan filas
                if (totales.Count < dgvConsolidarEstampado.Rows.Count)
                {
                    for (int i = totales.Count; i < dgvConsolidarEstampado.Rows.Count; i++)
                    {
                        dgvConsolidarEstampado.Rows.RemoveAt(i);
                    }
                }//Si hay más colores que filas en total consolidado se agregan filas
                else if (totales.Count > dgvConsolidarEstampado.Rows.Count)
                {
                    for (int i = dgvConsolidarEstampado.Rows.Count; i < totales.Count; i++)
                    {
                        dgvConsolidarEstampado.Rows.Add();
                    }
                }
                //Se agrega la información en las filas
                for (int i = 0; i < totales.Count; i++)
                {
                    dgvConsolidarEstampado.Rows[i].Cells[0].Value = totales[i].CodidoColor;
                    dgvConsolidarEstampado.Rows[i].Cells[1].Value = totales[i].DescripcionColor.ToUpper();
                    dgvConsolidarEstampado.Rows[i].Cells[2].Value = totales[i].Fondo;
                    dgvConsolidarEstampado.Rows[i].Cells[3].Value = totales[i].DescripcionFondo.ToUpper();
                    dgvConsolidarEstampado.Rows[i].Cells[4].Value = totales[i].Tiendas.ToString();
                    dgvConsolidarEstampado.Rows[i].Cells[5].Value = totales[i].Exito.ToString();
                    dgvConsolidarEstampado.Rows[i].Cells[6].Value = totales[i].Cencosud.ToString();
                    dgvConsolidarEstampado.Rows[i].Cells[7].Value = totales[i].Sao.ToString();
                    dgvConsolidarEstampado.Rows[i].Cells[8].Value = totales[i].ComercioOrg.ToString();
                    dgvConsolidarEstampado.Rows[i].Cells[9].Value = totales[i].Rosado.ToString();
                    dgvConsolidarEstampado.Rows[i].Cells[10].Value = totales[i].Otros.ToString();
                    dgvConsolidarEstampado.Rows[i].Cells[11].Value = totales[i].TotalUnidades.ToString();
                    dgvConsolidarEstampado.Rows[i].Cells[12].Value = totales[i].MCalculados.ToString();
                    dgvConsolidarEstampado.Rows[i].Cells[13].Value = totales[i].KgCalculados.ToString();
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
            foreach (DataGridViewRow row in dgvInformacionEstampado.Rows)
            {
                if (row.Cells[12].Value == null || row.Cells[12].Value == "")
                {
                    vacio = true;
                }
            }
            return vacio;
        }

        private bool validarValoresReserva()
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

        private bool validarTotalAPedir()
        {
            bool vacio = false;
            foreach (DataGridViewRow row in dgvConsolidarEstampado.Rows)
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
            foreach (DataGridViewRow row in dgvConsolidarEstampado.Rows)
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
                control.agregarConsolidado(listaIdSolicitudes[i], maxConsolidado + 1,"COORDINADO");
            }

        }

        private void cargarEstampado()
        {
            PedidoAMontar pedido = new PedidoAMontar();
            foreach (MontajeTelaDetalle solicitud in listaEstampado)
            {
                pedido = control.getPedidoEstampado(solicitud.IdSolTela);
                if (pedido != null)
                {
                    idSolicitudEstampado = solicitud.IdSolTela;
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

                dgvInformacionEstampado.Rows.Clear();
                dgvConsolidarEstampado.Rows.Clear();
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
                        dgvInformacionEstampado.Rows.Add(obj.CodigoColor, obj.DescripcionColor, obj.Fondo, obj.DescripcionFondo,
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
                        dgvConsolidarEstampado.Rows.Add(obj.CodidoColor, obj.DescripcionColor, obj.Fondo, obj.DescripcionFondo,
                            obj.Tiendas, obj.Exito, obj.Cencosud, obj.Sao, obj.ComercioOrg, obj.Rosado, obj.Otros,
                            obj.TotalUnidades, obj.MCalculados, obj.KgCalculados, obj.TotalPedir, obj.UnidadMedida);
                    }
                }
            }
        }

        private void guardarInformacion(int idPedido)
        {
            foreach (DataGridViewRow row in dgvInformacionEstampado.Rows)
            {
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
            foreach (DataGridViewRow row in dgvConsolidarEstampado.Rows)
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

        private decimal calcularMCalculados(decimal consumo, int totalUnidades)
        {
            return decimal.Round(consumo * totalUnidades * decimal.Parse("1.10"), 2);
        }

        private decimal calcularMSolicitar(decimal mCalculados, decimal mReservados)
        {
            return decimal.Round(mCalculados - mReservados, 2);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private decimal calcularKgCalculados(decimal mSolicitar, decimal rendimiento)
        {
            return decimal.Round(mSolicitar / rendimiento, 2);
        }

        private void inicioEstampado(){
            cargarCombobox(cbxTipoMarcacion, control.getTipoMarcacion());
            cargarEstampado();
            if (id == 0)
            {
                cargarDgvInfoConsolidar(listaEstampado);
                calcularTotalesPorColores();
            }
            dgvInformacionEstampado.Columns[0].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInformacionEstampado.Columns[1].HeaderCell.ToolTipText = "Clic item si desea modificar";
            dgvInformacionEstampado.Columns[13].HeaderCell.ToolTipText = "(Consumo * Total Unidades)*1.10";
            dgvInformacionEstampado.Columns[15].HeaderCell.ToolTipText = "M calculados -  M reservados";
            dgvInformacionEstampado.Columns[16].HeaderCell.ToolTipText = "M a solicitar / Rendimiento";

            dgvConsolidarEstampado.Columns[12].HeaderCell.ToolTipText = "(Consumo * Total Unidades)*1.10";
            dgvConsolidarEstampado.Columns[13].HeaderCell.ToolTipText = "M a solicitar / Rendimiento";
        }

        #endregion
    }
}
