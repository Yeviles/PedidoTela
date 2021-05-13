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
    public partial class frmPedidoaMontarCuellos : MaterialSkin.Controls.MaterialForm
    {
        #region Variables
        private Controlador control = new Controlador();
        List<MontajeTelaDetalle> detalleSeleccionado = new List<MontajeTelaDetalle>();
        List<int> listaIdSolicitudes = new List<int>();
        List<string> listaEsayosRef = new List<string>();
        int idSolicitudTelas;
        bool bandera= false;
        #endregion

        #region Setter && Getter
        public List<MontajeTelaDetalle> DetalleSeleccionado { get => detalleSeleccionado; set => detalleSeleccionado = value; }
        public List<int> ListaIdSolicitudes { get => listaIdSolicitudes; set => listaIdSolicitudes = value; }
        public List<string> ListaEsayosRef { get => listaEsayosRef; set => listaEsayosRef = value; }
           #endregion

        #region Constructor
        public frmPedidoaMontarCuellos(Controlador control, List<MontajeTelaDetalle> listaSeleccionada, int idsolTela)
        {
            InitializeComponent();
            dtpFechaLlegada.Format = DateTimePickerFormat.Custom;
            dtpFechaLlegada.CustomFormat = "dd/MM/yyyy";
            this.control = control;
            this.idSolicitudTelas = idsolTela;
            DetalleSeleccionado = listaSeleccionada;
            Cargarsolicitudes(DetalleSeleccionado);
            Iniciar(DetalleSeleccionado);
        }
        #endregion

        private void frmPedidoaMontarCuellos_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
            cargarCombobox(cbxTipoMarcacion, control.getTipoMarcacion());
        }
        #region Eventos
       
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
        #region Métodos
        /// <summary>
        /// Permite cargar una lista con todos los id_solicitud seleccionados.
        /// </summary>
        /// <param name="prmLista"></param>
        private void Cargarsolicitudes(List<MontajeTelaDetalle> prmLista)
        {
            List<int> listaSolicitudes = new List<int>();
            for (int i = 0; i < prmLista.Count; i++)
            {
                listaSolicitudes.Add(prmLista[i].IdSolTela);
            }
           ListaIdSolicitudes = listaSolicitudes.Distinct().ToList();
        }

        /// <summary>
        /// Busca la informaón en las respectivas entidades si encuentra dastos los carga y la bandera el True, de lo contrario la bandera es False y se procede a 
        /// cargar la vista con la informacion que se ha seleccionado de la vista anterior.
        /// </summary>
        /// <param name="prmLista"> Lista de tipo MontajeTelaDetalle, la cual representa las filas seleccionadas en el vista  inicial de selección (frmSolicitudListaTelas). </param>
        private void Iniciar(List<MontajeTelaDetalle> prmLista)
        {
            List<int> idDetalleCuellos = new List<int>();
            Cargar();
            // Bandera controlada en el método Cargar()
            if (!this.bandera)
            {
                //Carga el DataGridView (dgvInfoConsolidar) el cual pertenece a la sección de información a consolidar.
                cargarDgvInfoConsolidar(prmLista);
                idDetalleCuellos=control.consultarIdDetalleCuellos(ListaIdSolicitudes);
                cargarDgvCuellos(control.getPedidoCuellos(idDetalleCuellos));
             }

        }

        /// <summary>
        /// Carga la informacion de los ComboBox.
        /// </summary>
        /// <param name="combo"></param>
        /// <param name="lista"></param>
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
        /// <param name="lista">Lista de tipo objeto</param>
        ///<returns></returns>*/
        private AutoCompleteStringCollection cargarCombobox(List<Objeto> lista)
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            foreach (Objeto obj in lista)
            {
                datos.Add(obj.Nombre);
            }
            return datos;
        }

        /// <summary>
        /// Carga el segungo DataGridView expuesto en la vista, el cual corresponde a información a consolidar.
        /// </summary>
        /// <param name="prmLista">Lista de tipo MontajeTelaDetalle, la cual representa las filas seleccionadas en el vista  inicial de seleccion (frmSolicitudListaTelas).</param>
        private void cargarDgvInfoConsolidar(List<MontajeTelaDetalle> prmLista)
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
                   // ListaIdSolicitudes.Add(prmLista[i].IdSolTela);
                    ListaEsayosRef.Add(prmLista[i].RefSimilar);
                }
                txtDesPrenda.Text = prmLista[0].DescPrenda.ToString();
                txtDisenador.Text = prmLista[0].Disenador.ToString();
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cargarDgvCuellos(List<PedidoCuellos> prmLista)
        {
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {
                    dgvCuellos.Rows.Add(prmLista[i].Codigo.ToString(),
                    prmLista[i].Xs.ToString(),
                    prmLista[i].S.ToString(),
                    prmLista[i].M.ToString(),
                    prmLista[i].L.ToString(),
                    prmLista[i].Xl.ToString(),
                    prmLista[i].Dosxl.ToString(),
                    prmLista[i].Cuatro.ToString(),
                    prmLista[i].Seis.ToString(),
                    prmLista[i].Ocho.ToString(),
                    prmLista[i].Diez.ToString(),
                    prmLista[i].Doce.ToString(),
                    prmLista[i].Catorce.ToString(),
                    prmLista[i].Dieciseis.ToString(),
                    prmLista[i].Dieciocho.ToString(),
                    prmLista[i].Veinte.ToString(),
                    prmLista[i].Veintidos.ToString(),
                    prmLista[i].Veinticuatro.ToString(),
                    prmLista[i].Ancho.ToString(),
                    prmLista[i].TipoTejido.ToString()
                    );
                }
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Cargar()
        {

        }

        #endregion

        private void dgvCuellos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex <=19)
            {
                e.CellStyle.BackColor = Color.PaleGoldenrod;
            }
        }
    }
}
