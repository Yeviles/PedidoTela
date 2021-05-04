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

            PedMontarUnicolor objPedUnicolor = control.getPedUnicolor(idSolTela);

            if (objPedUnicolor.IdPedUnicolor != 0)
            {
                List<PedUnicolorInfoCon> listaInfoConsolidar = control.getPedUnicolorInfoCon(objPedUnicolor.IdPedUnicolor);
                List<PedUnicolorTotalCon> listaTotalConsolidado = control.getPedUnicolorTotalCon(objPedUnicolor.IdPedUnicolor);

                List<PedUnicolorInfoCon> lista = new List<PedUnicolorInfoCon>();
                List<PedUnicolorTotalCon> lista1 = new List<PedUnicolorTotalCon>();

                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("nomTela", objPedUnicolor.NomTela));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("disenador", objPedUnicolor.Disenador));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ensayo_ref", objPedUnicolor.EnsayoRef));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("desc_prenda", objPedUnicolor.DescPrenda));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("fecha_llegada", objPedUnicolor.FechaLlegada));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("clase", objPedUnicolor.Clase));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_marcacion", objPedUnicolor.TipoMarcacion));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("rendimiento", objPedUnicolor.Rendimiento.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("analista_corteb", objPedUnicolor.AnalistasCortesB));
                this.reportViewer1.LocalReport.DataSources.Clear();

                if (listaInfoConsolidar != null && listaTotalConsolidado != null)
                {
                    int i = 0;
                    foreach (PedUnicolorInfoCon elem in listaInfoConsolidar)
                    {
                        PedUnicolorInfoCon obj = new PedUnicolorInfoCon();
                        obj.CodColor = elem.CodColor;
                        obj.DescColor = elem.DescColor;
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
                    foreach (PedUnicolorTotalCon elem in listaTotalConsolidado)
                    {
                        PedUnicolorTotalCon obj = new PedUnicolorTotalCon();
                        obj.CodColor = elem.CodColor;
                        obj.DescColor = elem.DescColor;
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
                        obj.UniMedida = elem.UniMedida;
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
