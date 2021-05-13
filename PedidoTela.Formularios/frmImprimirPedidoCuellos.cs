using MaterialSkin;
using Microsoft.Reporting.WinForms;
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
    public partial class frmImprimirPedidoCuellos :  MaterialSkin.Controls.MaterialForm
    {
        private Controlador control;
        private int idSolTela;
        public frmImprimirPedidoCuellos(Controlador controlador, int idSolicitudTela)
        {
            InitializeComponent();
            this.control = controlador;
            this.idSolTela = idSolicitudTela;
        }

        private void frmImprimirPedidoCuellos_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);

            PedidoAMontar objPedidoCuellos = control.getPedidoCuellos(idSolTela);

            List<PedidoMontarInformacion> listaInfoConsolidar = control.getPedidoCuellosInfo(objPedidoCuellos.Id);
            List<PedidoCuellos> listaProporcion = control.getPedidoCuellosProporcion(objPedidoCuellos.Id);

            List<PedidoMontarInformacion> lista = new List<PedidoMontarInformacion>();
            List<PedidoCuellos> lista1 = new List<PedidoCuellos>();

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ensayo_ref", objPedidoCuellos.EnsayoReferencia));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("disenador", objPedidoCuellos.Disenador));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("analista_corteb", objPedidoCuellos.AnalistasCortesB));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("fecha_llegada", objPedidoCuellos.FechaLlegada));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_marcacion", objPedidoCuellos.TipoMarcacion));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("desc_prenda", objPedidoCuellos.DescripcionPrenda));
            this.reportViewer1.LocalReport.DataSources.Clear();

            if (listaInfoConsolidar != null && listaProporcion != null)
            {
                int i = 0;
                foreach (PedidoMontarInformacion elem in listaInfoConsolidar)
                {
                    PedidoMontarInformacion obj = new PedidoMontarInformacion();
                    obj.CodigoColor = elem.CodigoColor;
                    obj.DescripcionColor = elem.DescripcionColor;
                    obj.CodigoH1 = elem.CodigoH1;
                    obj.DescripcionH1 = elem.DescripcionH1;
                    obj.CodigoH2 = elem.DescripcionH2;
                    obj.DescripcionH3 = elem.DescripcionH3;
                    obj.CodigoH4 = elem.CodigoH4;
                    obj.DescripcionH4 = elem.DescripcionH4;
                    obj.CodigoH5 = elem.CodigoH5;
                    obj.DescripcionH5 = elem.DescripcionH5;
                    obj.TotalUnidades = elem.TotalUnidades;
                    lista.Add(obj);
                    i++;
                }
                foreach (PedidoCuellos elem in listaProporcion)
                {
                    PedidoCuellos obj = new PedidoCuellos();
                    obj.CodigoVte = elem.CodigoVte;
                    obj.DescripcionVte = elem.DescripcionVte;
                    obj.Xs = elem.Xs;
                    obj.S = elem.S;
                    obj.M = elem.M;
                    obj.L = elem.L;
                    obj.Xl = elem.Dosxl;
                    obj.Cuatro = elem.Cuatro;
                    obj.Ocho = elem.Ocho;
                    obj.Doce = elem.Doce;
                    obj.Catorce = elem.Catorce;
                    obj.Dieciseis = elem.Dieciseis;
                    obj.Dieciocho = elem.Dieciocho;
                    obj.Veinte = elem.Veinte;
                    obj.Veintidos = elem.Veintidos;
                    obj.Veinticuatro = elem.Veinticuatro;
                    obj.TotalUnidades = elem.TotalUnidades;
                    lista1.Add(obj);
                    i++;
                }
                ReportDataSource rds1 = new ReportDataSource("informacionConsolidar", lista);
                ReportDataSource rds2 = new ReportDataSource("proporcion", lista1);
                //ReportDataSource rds3 = new ReportDataSource("totalconsolidar", listaTotalConsolidado);
                this.reportViewer1.LocalReport.DataSources.Add(rds1);
                this.reportViewer1.LocalReport.DataSources.Add(rds2);
                //this.reportViewer1.LocalReport.DataSources.Add(rds3);
            }

            this.reportViewer1.RefreshReport();
           
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
