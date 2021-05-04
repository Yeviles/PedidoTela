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
    public partial class frmPedidoaMontarEstampado : MaterialSkin.Controls.MaterialForm
    {
        #region variables
        private Controlador control = new Controlador();
        private List<MontajeTelaDetalle> solicitudes = new List<MontajeTelaDetalle>();
        private Validar validacion = new Validar();
        private int contador = 0, idSolTela;
        private bool bandera = false;
        #endregion

        public frmPedidoaMontarEstampado(Controlador control, List<MontajeTelaDetalle> solicitudes, int contador)
        {
            InitializeComponent();
            this.control = control;
            this.solicitudes = solicitudes;
            this.contador = contador;
            cargarDgvInfoConsolidar(solicitudes);
            cargarDgvTotalConsolidar(solicitudes);
        }

        #region Eventos
        private void frmPedidoaMontarEstampado_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
            cargarCombobox(cbxTipoMarcacion, control.getTipoMarcacion());
        }      

        private void txtRendimiento_TextChanged(object sender, EventArgs e)
        {
            if (txtRendimiento.Text.Trim() != "")
            {
                for (int i = 0; i < dgvTotalConsolidado.RowCount; i++)
                {
                    decimal valor = decimal.Parse(dgvInfoConsolidar.Rows[i].Cells[15].Value.ToString()) / decimal.Parse(txtRendimiento.Text.Trim());
                    dgvInfoConsolidar.Rows[i].Cells[16].Value = Decimal.Round(valor, 2);
                }                
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

                    dgvTotalConsolidado.Rows[e.RowIndex].Cells[0].Value = obj.Id;
                    dgvTotalConsolidado.Rows[e.RowIndex].Cells[1].Value = obj.Nombre;
                }
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

                    dgvTotalConsolidado.Rows[e.RowIndex].Cells[2].Value = obj.Id;
                    dgvTotalConsolidado.Rows[e.RowIndex].Cells[3].Value = obj.Nombre;
                }
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
                            dgvInfoConsolidar.Rows[e.RowIndex].Cells[16].Value = decimal.Round(valor - decimal.Parse(txtRendimiento.Text));
                        }
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
            
        }

        #region Formato grillas
        private void dgvInfoConsolidar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 3 && e.ColumnIndex <= 9 || e.ColumnIndex > 10 && e.ColumnIndex <= 13)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }

        private void dgvTotalConsolidado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex > 3 && e.ColumnIndex <= 10)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }
        #endregion
        #region Botones
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            
            if (txtRendimiento.Text.Trim() != "")
            {
                
            }
            else
            {
                MessageBox.Show("Por favor ingrese un valor en el campo rendimiento.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void cargarDgvInfoConsolidar(List<MontajeTelaDetalle> prmLista)
        {
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {
                    dgvInfoConsolidar.Rows.Add(prmLista[i].Vte.ToString(),
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
                    idSolTela = prmLista[i].IdSolTela;
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
                        prmLista[i].MCalculados.ToString()
                    );
                }
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void calcularTotalesPorColores() {
            List<Objeto> contadores = new List<Objeto>();
            //Se llena la lista con los códigos de los colores
            Objeto color = new Objeto();
            color.Id = dgvInfoConsolidar.Rows[0].Cells[0].Value.ToString();
            contadores.Add(color);
            for (int i = 0; i < dgvInfoConsolidar.RowCount; i++)
            {
                foreach (Objeto obj in contadores)
                {
                    if (dgvInfoConsolidar.Rows[i].Cells[0].Value.ToString() != obj.Id)
                    {
                        color = new Objeto();
                        color.Id = dgvInfoConsolidar.Rows[i].Cells[0].Value.ToString();
                    }
                }
            }
        }

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
        #endregion
    }
}
