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
using MaterialSkin;

namespace PedidoTela.Formularios
{
    public partial class frmImprimirSIP : MaterialSkin.Controls.MaterialForm
    {
        private Controlador control;
        private int idSolicitudTela;

        public frmImprimirSIP(Controlador control, int idSolicitudTela)
        {
            this.control = control;
            this.idSolicitudTela = idSolicitudTela;
            InitializeComponent();
        }

        private void frmImprimirSIP_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);

            AgenciasExternos agencia = control.getAgenciasExterno(idSolicitudTela);
            List<AgenciasSIP> lista = new List<AgenciasSIP>();
            List<AgenciasInfoConsolidar> listaInfoConsolidar = control.getInfoConsolidar(agencia.IdAgencias);
            List<AgenciaTotalConsolidar> listaTotalConsolidado = control.getTotalConsolidado(agencia.IdAgencias);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("referencia", agencia.NombreTela));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("solicitud", agencia.SolicitadoPor));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("extension", agencia.Extencion));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("pedido", agencia.PedidoAgencia));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("orden", agencia.OrdenCompra));
            this.reportViewer1.LocalReport.DataSources.Clear();
            if (listaInfoConsolidar != null && listaTotalConsolidado != null) {
                int i = 0;
                foreach (AgenciaTotalConsolidar elem in listaTotalConsolidado) {
                    AgenciasSIP obj = new AgenciasSIP();
                    obj.Color = elem.DesColor;
                    obj.MCalculados = listaInfoConsolidar[i].MaSolicitar.ToString();
                    obj.KgCalculados = elem.KgCalculados.ToString();
                    lista.Add(obj);
                    i++;
                }
                ReportDataSource rds1 = new ReportDataSource("agencia", lista);
                //ReportDataSource rds2 = new ReportDataSource("infoconsolidar", listaInfoConsolidar);
                //ReportDataSource rds3 = new ReportDataSource("totalconsolidar", listaTotalConsolidado);
                this.reportViewer1.LocalReport.DataSources.Add(rds1);
                //this.reportViewer1.LocalReport.DataSources.Add(rds2);
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
