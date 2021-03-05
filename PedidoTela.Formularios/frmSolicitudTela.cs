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

        public frmSolicitudTela()
        {
            InitializeComponent();

            this.ttTipo.SetToolTip(this.cbxTipo, "Por favor Seleccione un Tipo");
            this.ttEnsayoRef.SetToolTip(this.txbEnsRefDigitado, "Precione Enter para Buscar");
            this.ttSku.SetToolTip(this.txbSku, "Por favor Ingrese solo 3 Carateres");
            dtpFechaTienda.Format = DateTimePickerFormat.Custom;
            dtpFechaTienda.CustomFormat = "dd/MM/yyyy";
            txbSku.MaxLength = 3;
           
        }

        private void frmSolicitudTela_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey400, Primary.Grey100, Accent.Green100, TextShade.WHITE);
         
            
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
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void cargarDataGridView(List<DetalleConsumo> prmLista)
        {
            if (prmLista.Count != 0)
            {
                dgvDetalleConsumo.Rows.Add ( prmLista[0].Ensayo_referencia.ToString(),
                prmLista[0].Desc_prenda.ToString(),
                prmLista[0].Codigo_tela.ToString(),
                prmLista[0].Descripcion_tela.ToString(),
                prmLista[0].Consumo_est.ToString());
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txbSku_Validating(object sender, CancelEventArgs e)
        {

            if (txbSku.Text == "")
            {
                //e.Cancel = true;
                txbSku.Select(0, txbSku.Text.Length);
                errorProvider.SetError(txbSku, "Debe introducir el SKU");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            frmTipoSolicitud objTipoSolicitud = new frmTipoSolicitud();

            objTipoSolicitud.StartPosition = FormStartPosition.CenterScreen;
            if (objTipoSolicitud.ShowDialog() == DialogResult.OK)
            {
                String seleccion = objTipoSolicitud.Seleccion;
                if (seleccion == "unicolor")
                {
                    frmSolicitudUnicolor frmUnicolor = new frmSolicitudUnicolor(controlador, 715,dgvDetalleConsumo.Rows[e.RowIndex].Cells[2].Value.ToString());
                    frmUnicolor.Show();
                }
                else if (seleccion == "estampado")
                {
                    frmSolicitudEstampado frmEstamapado = new frmSolicitudEstampado();
                    frmEstamapado.Show();
                    frmEstamapado.recibirInfoTela(dgvDetalleConsumo.CurrentRow.Cells["refTela"].Value.ToString(), dgvDetalleConsumo.CurrentRow.Cells["desTela"].Value.ToString());
                }
                else if (seleccion == "planoPre")
                {
                    frmSolicitudPlanoPretenido frmPlapretenido = new frmSolicitudPlanoPretenido();
                    frmPlapretenido.Show();

                }
                else if (seleccion == "cuelloPun")
                {
                    frmSolicitudCuellosTiras frmCuellos = new frmSolicitudCuellosTiras();
                    frmCuellos.Show();
                }

            }
        }
        
        private void btnConsultar_Click(object sender, EventArgs e)
        {
       
            if (txbEnsRefDigitado.Text == "" || cbxTipo.SelectedItem.ToString()==null)
            {
                MessageBox.Show("Por favor ingrese Ensayo/Referencia", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cbxTipo.SelectedItem.ToString() == "Ensayo")
            {
                cargarDataGridView(controlador.getDetalleConsumoEnsayo(txbEnsRefDigitado.Text));
            }
            else
            {
                cargarDataGridView(controlador.getDetalleConsumoReferencia(txbEnsRefDigitado.Text));
            }
            
        }

        private void txbEnsRefDigitado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbxTipo.SelectedItem == null)
            {
                MessageBox.Show("Por Favor selecione un tipo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cbxTipo.SelectedItem.ToString() == "Ensayo" && (e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                string[] objId = txbEnsRefDigitado.Text.Split('-');
                if (objId.Length<3)
                {
                    MessageBox.Show("No existe infación sobre el N° ensayo ingresado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cargarTexBox(cbxTipo, controlador.getEnsayo(txbEnsRefDigitado.Text));
                    dgvDetalleConsumo.Rows.Clear();
                }

            }
                
            else if (cbxTipo.SelectedItem.ToString() == "Referencia" && (e.KeyChar == Convert.ToChar(Keys.Enter)))
            {
                cargarTexBox(cbxTipo, controlador.getReferencia(txbEnsRefDigitado.Text));
                dgvDetalleConsumo.Rows.Clear();
               
            }
        }

        private void cbxTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(cbxTipo.SelectedItem.ToString() == "Ensayo" || (cbxTipo.SelectedItem.ToString() == "Referencia")) 
            {
                txbEnsRefDigitado.ReadOnly = false;
                txbEnsRefDigitado.Focus();
                txbEnsRefDigitado.BackColor = Color.LightGoldenrodYellow;
                validacion.limpiar(pnlAdicionarSolicitud);
            }
            else
            {
                MessageBox.Show("Por Favor selecione un tipo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
        }

        private void txbSku_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloLetras(e);
        }

        private void dgvDetalleConsumo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(dgvDetalleConsumo.Columns[e.ColumnIndex].Name == "editar")
            {

            }

        }
    }
}
