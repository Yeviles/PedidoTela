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
        private int contador = 0, idSolicitud, id;
        private bool bandera = false;
        #endregion

        public frmPedidoaMontarEstampado(Controlador control, List<MontajeTelaDetalle> solicitudes, int contador)
        {
            InitializeComponent();
            this.control = control;
            this.solicitudes = solicitudes;
            this.contador = contador;
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
        }

        private void cbxClase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxClase.SelectedIndex != -1 && cbxClase.SelectedItem.ToString().ToLower() == "no tejer") {
                bandera = true;
            }
        }

        private void txtRendimiento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtRendimiento.Text.Trim() != "")
                {
                    for (int i = 0; i < dgvTotalConsolidado.RowCount; i++)
                    {
                        decimal valor = decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[15].Value.ToString()) / decimal.Parse(txtRendimiento.Text.Trim());
                        dgvInfoConsolidar.Rows[i].Cells[16].Value = Decimal.Round(valor, 2);
                    }
                }
                calcularTotalesPorColores();
            }
            catch {
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
            if (e.ColumnIndex == 14)
            {
                try
                {
                    if (dgvInfoConsolidar.CurrentCell.Value != null && dgvInfoConsolidar.CurrentCell.Value.ToString().Trim() != "")
                    {
                        decimal valor = decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[13].Value.ToString()) - decimal.Parse(dgvInfoConsolidar.Rows[e.RowIndex].Cells[14].Value.ToString());
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[15].Value = decimal.Round(valor, 2);

                        if (txtRendimiento.Text.Trim() != "")
                        {
                            decimal rendimiento = decimal.Parse(txtRendimiento.Text);
                            dgvInfoConsolidar.Rows[e.RowIndex].Cells[16].Value = decimal.Round(valor/rendimiento, 2);
                        }
                        calcularTotalesPorColores();
                    }
                    else {
                        dgvInfoConsolidar.Rows[e.RowIndex].Cells[16].Value = "";
                    }
                }
                catch (Exception ex)
                {
                    dgvInfoConsolidar.CurrentCell.Value = "";
                    MessageBox.Show("Tipo de dato no permitido\nSólo se permiten valores numéricos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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
            frmBuscarPedido buscar = new frmBuscarPedido();
            if (buscar.ShowDialog() == DialogResult.OK) { 
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
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
                                                    guardarInformacion(pedido.Id);
                                                    guardarTotal(pedido.Id);
                                                }
                                                //Agrega el Consolidado.
                                                //AgregarConsolidado();

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
            else {
                MessageBox.Show("Por favor seleccione un valor en el campo Clase", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion

        #region otros métodos
        /* <summary> Realiza la carga de los datos en el ComboBox </summary>
         * <param name="lista">Lista de tipo Objeto</param>
         * <returns></returns>*/
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

        private void cargarDgvInfoConsolidar(List<MontajeTelaDetalle> prmLista)
        {
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {
                    dgvInfoConsolidar.Rows.Add(
                        prmLista[i].Vte.ToString(),
                        prmLista[i].DesColor.ToString(),
                        prmLista[i].RefTela.ToString(),
                        prmLista[i].DesTela.ToString(),
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
                dgvTotalConsolidado.Rows.Clear();
                for (int i = 0; i < totales.Count; i++)
                {
                    dgvTotalConsolidado.Rows.Add(
                        totales[i].CodidoColor,
                        totales[i].DescripcionColor,
                        totales[i].Fondo,
                        totales[i].DescripcionFondo,
                        totales[i].Tiendas.ToString(),
                        totales[i].Exito.ToString(),
                        totales[i].Cencosud.ToString(),
                        totales[i].Sao.ToString(),
                        totales[i].ComercioOrg.ToString(),
                        totales[i].Rosado.ToString(),
                        totales[i].Otros.ToString(),
                        totales[i].TotalUnidades.ToString(),
                        totales[i].MCalculados.ToString(),
                        totales[i].KgCalculados.ToString()
                    );
                }
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
                control.agregarConsolidado(listaIdSolicitudes[i], maxConsolidado + 1, "", "Por Analizar");
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

        #endregion
    }
}
