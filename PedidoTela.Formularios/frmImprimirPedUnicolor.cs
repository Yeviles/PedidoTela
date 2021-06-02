using Microsoft.Reporting.WinForms;
using PedidoTela.Controlodores;
using PedidoTela.Entidades.Logica;
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
using PedidoTela.Entidades;

namespace PedidoTela.Formularios
{
    public partial class frmImprimirPedUnicolor : MaterialSkin.Controls.MaterialForm
    {
        private Controlador control;
        private int idSolTela;

        public frmImprimirPedUnicolor(Controlador controlador, int idSolicitudTela)
        {
            this.control = controlador;
            this.idSolTela = idSolicitudTela;
            InitializeComponent();

        }

        private void frmImprimirPedUnicolor_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);

            PedidoAMontar objPedUnicolor = control.getPedUnicolor(idSolTela);
            List<PedidoMontarInformacion> listaInfoConsolidar = control.getPedUnicolorInfoCon(objPedUnicolor.Id);
            List<PedidoMontarTotal> listaTotalConsolidado = control.getPedUnicolorTotalCon(objPedUnicolor.Id);

            List<PedidoMontarInformacion> lista = new List<PedidoMontarInformacion>();
            List<PedidoMontarTotal> lista1 = new List<PedidoMontarTotal>();

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("nomTela", objPedUnicolor.Tela));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("disenador", objPedUnicolor.Disenador));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ensayo_ref", objPedUnicolor.EnsayoReferencia));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("desc_prenda", objPedUnicolor.DescripcionPrenda));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("fecha_llegada", objPedUnicolor.FechaLlegada));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("clase", objPedUnicolor.Clase));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_marcacion", objPedUnicolor.TipoMarcacion.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("rendimiento", objPedUnicolor.Rendimiento.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("analista_corteb", objPedUnicolor.AnalistasCortesB));
            this.reportViewer1.LocalReport.DataSources.Clear();

            if (listaInfoConsolidar != null && listaTotalConsolidado != null)
            {
                int i = 0;
                foreach (PedidoMontarInformacion elem in listaInfoConsolidar)
                {
                    PedidoMontarInformacion obj = new PedidoMontarInformacion();
                    obj.CodigoColor = elem.CodigoColor;
                    obj.DescripcionColor = elem.DescripcionColor;
                    obj.Tiendas = elem.Tiendas;
                    obj.Exito = elem.Exito;
                    obj.Cencosud = elem.Cencosud;
                    obj.Sao = elem.Sao;
                    obj.ComercioOrg = elem.ComercioOrg;
                    obj.Rosado = elem.Rosado;
                    obj.Otros = elem.Otros;
                    obj.TotalUnidades = elem.TotalUnidades;
                    obj.MCalculados = elem.MCalculados;
                    obj.MReservados = elem.MReservados;
                    obj.MSolicitar = elem.MSolicitar;
                    obj.KgCalculados = elem.KgCalculados;
                    lista.Add(obj);
                    i++;
                }
                foreach (PedidoMontarTotal elem in listaTotalConsolidado)
                {
                    PedidoMontarTotal obj = new PedidoMontarTotal();
                    obj.CodidoColor = elem.CodidoColor;
                    obj.DescripcionColor = elem.DescripcionColor;
                    obj.Tiendas = elem.Tiendas;
                    obj.Exito = elem.Exito;
                    obj.Cencosud = elem.Cencosud;
                    obj.Sao = elem.Sao;
                    obj.ComercioOrg = elem.ComercioOrg;
                    obj.Rosado = elem.Rosado;
                    obj.Otros = elem.Otros;
                    obj.TotalUnidades = elem.TotalUnidades;
                    obj.MCalculados = elem.MCalculados;
                    obj.KgCalculados = elem.KgCalculados;
                    obj.TotalPedir = elem.TotalPedir;
                    obj.UnidadMedida = elem.UnidadMedida;
                    lista1.Add(obj);
                    i++;
                }
                ReportDataSource rds1 = new ReportDataSource("informacionConsolidar", lista);
                ReportDataSource rds2 = new ReportDataSource("TotalConsolidado", lista1);
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
