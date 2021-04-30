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
        private String seleccion;
        private Controlador control = new Controlador();
        List<DetalleListaTela> detalleSeleccionado = new List<DetalleListaTela>();
        Validar validacion = new Validar();
        int contItemSeleccionado = 0, idSolTela;
        bool bandera = false;

        public string Seleccion { get => seleccion; set => seleccion = value; }
        public List<DetalleListaTela> DetalleSeleccionado { get => detalleSeleccionado; set => detalleSeleccionado = value; }
        public int ContItemSeleccionado { get => contItemSeleccionado; set => contItemSeleccionado = value; }
        public int IdSolTela { get => idSolTela; set => idSolTela = value; }

        public frmPedidoaMotarUnicolor(Controlador controlador, List<DetalleListaTela> listaSeleccionada, int contador, string tipoPedidoMontar)
        {
            InitializeComponent();
            control = controlador;
            DetalleSeleccionado = listaSeleccionada;
            ContItemSeleccionado = contador;
            Seleccion = tipoPedidoMontar;
            dtpFechaLlegada.Format = DateTimePickerFormat.Custom;
            dtpFechaLlegada.CustomFormat = "dd/MM/yyyy";
            Validaciones(DetalleSeleccionado, ContItemSeleccionado);

        }

        private void frmPedidoaMotarUnicolor_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
            cargarCombobox(cbxTipoMarcacion, control.getTipoMarcacion());
        }

        /// <summary>
        /// Se válida que en la lista (List<DetalleListaTela> listaSeleccionada) que llega al contructor por argumentos, tenga un atributo estado y que 
        /// este contenga valor de Solicitud de Inventario o Reserva Parcial, si cumple esta condición procede a llenar el encabezado  y las DataGridView de la vista actual.
        /// </summary>
        /// <param name="prmLista"> Lista de tipo DetalleListaTela, la cual representa las filas seleccionadas en el vista frmSolicitudListaTelas. </param>
        /// <param name="cont">Cantidad de filas que han sido seleccionadas en la vista frmSolicitudListaTelas.</param>
        private void Validaciones(List<DetalleListaTela> prmLista, int numfilasSeleccionadas)
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

                    txtEnsayoRef.Text += prmLista[i].RefSimilar.ToString() + "\n";
                    txtDesPrenda.Text = prmLista[i].DescPrenda.ToString();
                    idSolTela = prmLista[i].IdSolTela;
                    IdSolTela = prmLista[i].IdSolTela;

                }
                txtNomTela.Text = prmLista[0].DesTela.ToString();
                txtDisenador.Text = prmLista[0].Disenador.ToString();
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

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

        private void Cargar()
        {
            
        }

    }
}
