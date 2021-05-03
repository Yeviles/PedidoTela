using System;
using MaterialSkin;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PedidoTela.Entidades.Logica;
using PedidoTela.Controlodores;

namespace PedidoTela.Formularios
{
    public partial class frmPedidoaMontarPretenido : MaterialSkin.Controls.MaterialForm

    {
        #region Variables
        private Controlador control = new Controlador();
        #endregion
        #region Constructor
        public frmPedidoaMontarPretenido(Controlador controlador)
        {
            
            InitializeComponent();
            this.control = controlador;
        }
        #endregion

        #region Método inicial de Carga
        private void frmPedidoaMontarPretenido_Load(object sender, EventArgs e)
        {
            cargarCombobox(cbxTipoMarcacion, control.getTipoMarcacion());
        }
        #endregion

        #region Eventos

        #endregion

        #region Métodos

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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
