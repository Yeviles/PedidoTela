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
using PedidoTela.Controlodores;
using PedidoTela.Entidades;
using PedidoTela.Entidades.Logica;
using Microsoft.Reporting.WinForms;

namespace PedidoTela.Formularios
{
    public partial class frmImprimirPedidoPlano : MaterialSkin.Controls.MaterialForm
    {
        private Controlador control;
        private int idSolTela;

        public frmImprimirPedidoPlano(Controlador controlador, int idSolicitudTela)
        {
            this.control = controlador;
            this.idSolTela = idSolicitudTela;
            InitializeComponent();
        }

        private void frmImprimirPedidoPlano_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);

            PedidoAMontar objPlano = control.getPedidoPlano(idSolTela);

            if (objPlano.Id != 0)
            {
                //List<PedidoMontarInformacion> listaInfoConsolidar = control.getPedUnicolorInfoCon(objPlano.Id);
                List<PedidoMontarTotal> listaTotalConsolidado = control.getPedidoPlanoTotal(objPlano.Id);

                List<PedidoMontarTotal> lista1 = new List<PedidoMontarTotal>();

                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("nomTela", objPlano.Tela));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("disenador", objPlano.Disenador));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ensayo_ref", objPlano.EnsayoReferencia));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("desc_prenda", objPlano.DescripcionPrenda));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("fecha_llegada", objPlano.FechaLlegada));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("clase", objPlano.Clase));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_marcacion", objPlano.TipoMarcacion));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("rendimiento", objPlano.Rendimiento.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("analista_corteb", objPlano.AnalistasCortesB));
                this.reportViewer1.LocalReport.DataSources.Clear();
                if (listaTotalConsolidado != null)
                {
                    int i = 0;
                    foreach (PedidoMontarTotal elem in listaTotalConsolidado)
                    {
                        PedidoMontarTotal obj = new PedidoMontarTotal();
                        obj.CodidoColor = elem.CodidoColor;
                        obj.DescripcionColor = elem.DescripcionColor;
                        obj.CodigoH1 = elem.CodigoH1;
                        obj.DescripcionH1 = elem.DescripcionH1;
                        obj.CodigoH2 = elem.CodigoH2;
                        obj.DescripcionH2 = elem.DescripcionH2;
                        obj.CodigoH3 = elem.CodigoH3;
                        obj.DescripcionH3 = elem.DescripcionH3;
                        obj.CodigoH4 = elem.CodigoH4;
                        obj.DescripcionH4 = elem.DescripcionH4;
                        obj.CodigoH5 = elem.CodigoH5;
                        obj.DescripcionH5 = elem.DescripcionH5;
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
                }
                ReportDataSource rds2 = new ReportDataSource("PedidoPlanoTotal", lista1);
                //ReportDataSource rds3 = new ReportDataSource("totalconsolidar", listaTotalConsolidado);
                this.reportViewer1.LocalReport.DataSources.Add(rds2);
                //this.reportViewer1.LocalReport.DataSources.Add(rds3);
                
                this.reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("El consolidado no ha sido guardado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
