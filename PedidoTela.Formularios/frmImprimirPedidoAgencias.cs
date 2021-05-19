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
    public partial class frmImprimirPedidoAgencias : MaterialSkin.Controls.MaterialForm
    {
        private Controlador control;
        private int idSolicitud;
        private AgenciasExternos agencia;
        public frmImprimirPedidoAgencias(Controlador control, int idSolicitud)
        {
            this.control = control;
            this.idSolicitud = idSolicitud;
            InitializeComponent();
        }

        private void frmImprimirPedidoAgencias_Load(object sender, EventArgs e)
        {
            agencia = control.getAgenciasExterno(idSolicitud);
            List<AgenciasInfoConsolidar> listaInformacion = control.getInfoConsolidar(agencia.IdAgencias);
            List<AgenciaTotalConsolidar> listaTotal = control.getTotalConsolidado(agencia.IdAgencias);

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("solicitado", agencia.SolicitadoPor));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tela", agencia.NombreTela));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("disenador", agencia.Disenadora));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("cargo", agencia.Cargo));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("telefono", agencia.Telefono));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("departamento", agencia.Departamento));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("extension", agencia.Extencion));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ensayo_ref", agencia.EnsayoRef));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("desc_prenda", agencia.DescPrenda));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ancho", agencia.AnchoTela.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("proveedor", agencia.Proveedor));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("orden", agencia.OrdenCompra));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("rendimiento", agencia.Rendimiento.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_marcacion", agencia.TipoMarcacion));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("contacto", agencia.Contacto));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("pedido", agencia.PedidoAgencia));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("composicion", agencia.Composicion));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("nit", agencia.Nit));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("fecha_llegada", agencia.FechaLlegadaTela));
            this.reportViewer1.LocalReport.DataSources.Clear();

            if (listaInformacion != null && listaTotal != null)
            {
                ReportDataSource rds1 = new ReportDataSource("informacion", listaInformacion);
                ReportDataSource rds2 = new ReportDataSource("consolidado", listaTotal);
                this.reportViewer1.LocalReport.DataSources.Add(rds1);
                this.reportViewer1.LocalReport.DataSources.Add(rds2);
            }

            this.reportViewer1.RefreshReport();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
