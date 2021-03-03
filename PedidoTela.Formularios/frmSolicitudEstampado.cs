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
    public partial class frmSolicitudEstampado : MaterialSkin.Controls.MaterialForm
    {
        Controlador controlador = new Controlador();
        Validar validacion = new Validar();
        public frmSolicitudEstampado()
        {
            InitializeComponent();
        }

        private void frmSolicitudEstampado_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
            
            txbCoordinaCon.MaxLength = 40;

            cargarCombobox(cbxTipoTela, controlador.getTipoTejido());

        }
        public void recibirInfoTela(string prmRefTela, string nomTela)
        {
            txbRefTela.Text= prmRefTela;
            txbNomTela.Text = nomTela;
        }
        /// <summary>
        /// Muestra todos los idEnsayo encontrados en la BD.
        /// </summary>
        /// <param name="prmCombo">ComobBox de Seleccón. </param>
        /// <param name="prmLista">Contien los idensayo.</param>
        private void cargarCombobox(ComboBox prmCombo, List<TipoTejido> prmLista)
        {
            prmCombo.DataSource = prmLista;
            prmCombo.DisplayMember = "Descripcion";
            prmCombo.ValueMember = "Tipo";
            prmCombo.SelectedIndex = -1;
            prmCombo.AutoCompleteCustomSource = cargarCombobox(prmLista);
            prmCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            prmCombo.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }
        /// <summary>
        /// Autocompleta la lista desplegable del ComboBox.
        /// </summary>
        /// <param name="prmLista">Lista de Ensayos-Referencias</param>
        /// <returns></returns>
        private AutoCompleteStringCollection cargarCombobox(List<TipoTejido> prmLista)
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            foreach (TipoTejido obj in prmLista)
            {
                datos.Add(obj.Descripcion);
            }
            return datos;
        }

        private void txbNdibujo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);

        }

        private void txbNcilindro_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmTipoSolicitud frmTsolicitud = new frmTipoSolicitud();
            frmTsolicitud.Show();
        }

        private void cbxSiCoordinadoEst_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxSiCoordinadoEst.Checked==true)
            {
                txbCoordinaCon.ReadOnly = false;
                txbCoordinaCon.Focus();
                txbCoordinaCon.BackColor = Color.LightGoldenrodYellow;
                cbxNoCoordinadoEst.Checked = false;
            }
           
        }

        private void cbxNoCoordinadoEst_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxNoCoordinadoEst.Checked == true)
            {
                txbCoordinaCon.ReadOnly = true;
                cbxSiCoordinadoEst.Checked = false;

            }
        }
    }
}
