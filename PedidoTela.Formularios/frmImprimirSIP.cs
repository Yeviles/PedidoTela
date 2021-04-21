using Microsoft.Reporting.WinForms;
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
    public partial class frmImprimirSIP : MaterialSkin.Controls.MaterialForm
    {
        private Controlador control;
        private List<ReporteReservaTela> lista;

        public frmImprimirSIP(Controlador control)
        {
            this.control = control;
            lista = new List<ReporteReservaTela>();
            InitializeComponent();
        }

        private void frmImprimirSIP_Load(object sender, EventArgs e)
        {
            cargarCombobox(cbxTipoSolicitud, control.getTipoSol());
            cargarCombobox(cbxMuestrario, control.getListaMuestrario());
            cargarCombobox(cbxTema, control.getListaTema());
            cargarCombobox(cbxEntrada, control.getListaEntrada());
            this.reportViewer1.RefreshReport();
        }

        #region otros métodos
        /*<summary> Carga toda la información de los comboBox mostrados en la vista. </summary>
        <param name="prmCombo">ComboBox a llenar.</param>
        <param name="prmLista">Lista de tipo Objeto, la cual es cargada en el comboBox.</param>*/
        private void cargarCombobox(ComboBox prmCombo, List<Objeto> prmLista)
        {
            prmCombo.DataSource = prmLista;
            prmCombo.DisplayMember = "Nombre";
            prmCombo.ValueMember = "Id";
            prmCombo.SelectedIndex = -1;
            prmCombo.AutoCompleteCustomSource = cargarCombobox(prmLista);
            prmCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            prmCombo.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }

        /* <summary> Permite el autocompletado de los comboBox mostrados en la vista.</summary>
        <param name="prmLista">Lista de tipo objeto la cual es autocompletada.</param>
        <returns></returns>*/
        private AutoCompleteStringCollection cargarCombobox(List<Objeto> prmLista)
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            foreach (Objeto obj in prmLista)
            {
                datos.Add(obj.Nombre);
            }
            return datos;
        }
        #endregion

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            dgvReserva.Rows.Clear();
            ListaTela objTela = new ListaTela();
            objTela.TipoSolicitud = (cbxTipoSolicitud.SelectedIndex != -1 && cbxTipoSolicitud.Text  != "") ? cbxTipoSolicitud.Text.ToString() : "";
            objTela.EnsayoRefSimilar = txbEnsayoRef.Text.Trim();
            objTela.Muestrario = cbxMuestrario.GetItemText(cbxMuestrario.SelectedItem);
            objTela.Tema = cbxTema.GetItemText(cbxTema.SelectedItem);
            objTela.Entrada = cbxEntrada.GetItemText(cbxEntrada.SelectedItem);
            objTela.Disenador = "";
            objTela.OcasionUso = "";
            objTela.Estado = "";
            objTela.FechaTienda = "";
            objTela.RefTela = "";
            objTela.NomTela = "";
            objTela.Solicitud = "";
            objTela.Color = "";
            objTela.Clase = "";
            objTela.Coordinado = "";
            objTela.NumDibujo = "";
            List<DetalleListaTela> detalles = control.consultarListaTelas(objTela);
            lista = new List<ReporteReservaTela>();
            if (detalles != null) {
                foreach (DetalleListaTela detalle in detalles)
                {
                    if (detalle.CantidadReservado != "" && detalle.CantidadReservado != "0")
                    {
                        ReporteReservaTela item = new ReporteReservaTela();
                        item.Muestrario = detalle.Muestrario;
                        item.Tema = detalle.Muestrario;
                        item.Entrada = detalle.Entrada;
                        item.EnsayoReferencia = (detalle.Ensayo != null && detalle.Ensayo != "") ? detalle.Ensayo : detalle.RefSimilar;
                        item.NumeroPedido = control.consultarPedido(detalle.RefSimilar, detalle.RefTela, detalle.Vte).Pedido;
                        item.Color = detalle.DesColor;
                        item.Cantidad = detalle.CantidadReservado;
                        lista.Add(item);
                    }
                }

                foreach (ReporteReservaTela item in lista) {
                    dgvReserva.Rows.Add((object)item.EnsayoReferencia, (object) item.Muestrario, (object)item.Tema, (object)item.Entrada, (object)item.NumeroPedido, (object)item.Color, (object)item.Cantidad);
                }
            }
            cargarReporte();
        }

        private void cargarReporte() {
            ReportDataSource rds1 = new ReportDataSource("DataSet1", lista);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
            this.reportViewer1.RefreshReport();
        }
    }
}
