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
    public partial class frmPrueba : Form
    {
        Controlador controlador = new Controlador();
        public frmPrueba()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga 
        /// </summary>
        /// <param name="prmCombo"></param>
        /// <param name="prmlista"></param>
        private void cargarTexBox(ComboBox prmCombo, List<Ensayo> prmlista)
        {
                txbDisenador.Text = prmlista[0].Programador.ToString();
                txbOcasionUso.Text = prmlista[0].Ocasion_uso.ToString();
                txbMuestrario.Text = prmlista[0].Nmro_muestrario.ToString();
                txbEntrada.Text = prmlista[0].Entrada.ToString();
                txbTema.Text = prmlista[0].Tema.ToString();
                txbAnio.Text = prmlista[0].Anio_muestrario.ToString();
        }

        private void frmPrueba_Load(object sender, EventArgs e)
        {
            cargarCombobox(cbxEnsayo, controlador.getIdEnsayo());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prmCombo"></param>
        /// <param name="prmLista"></param>
        private void cargarCombobox(ComboBox prmCombo, List<string> prmLista)
        {
            prmCombo.DataSource = prmLista;
            prmCombo.SelectedIndex = -1;
            prmCombo.AutoCompleteCustomSource = cargarCombobox(prmLista);
            prmCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            prmCombo.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prmLista"></param>
        /// <returns></returns>
        private AutoCompleteStringCollection cargarCombobox(List<string> prmLista)
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            foreach (string obj in prmLista)
            {
                datos.Add(obj);
            }
            return datos;
        }

        private void cbxEnsayo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cargarTexBox(cbxEnsayo, controlador.getEnsayo(cbxEnsayo.SelectedItem.ToString()));
            
        }
    }
}
