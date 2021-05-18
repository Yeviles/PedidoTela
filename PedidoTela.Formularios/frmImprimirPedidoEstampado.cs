﻿using Microsoft.Reporting.WinForms;
using PedidoTela.Controlodores;
using PedidoTela.Entidades;
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
using System.Drawing.Printing;

namespace PedidoTela.Formularios
{
    public partial class frmImprimirPedidoEstampado : MaterialSkin.Controls.MaterialForm
    {
        private Controlador control;
        private int idSolicitud;


        public frmImprimirPedidoEstampado(Controlador control, int idsolicitud)
        {
            InitializeComponent();
            this.control = control;
            this.idSolicitud = idsolicitud;
        }

        private void frmImprimirPedidoEstampado_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new MaterialSkin.ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);

            PedidoAMontar pedido = control.getPedidoEstampado(idSolicitud);

            if (pedido.Id != 0)
            {
                List<PedidoMontarInformacion> listaInformacion = control.getPedidoEstampadoInformacion(pedido.Id);
                List<PedidoMontarTotal> listaTotal = control.getPedidoEstampadoTotal(pedido.Id);
                List<TomarDelPedido> listaPedido = control.getPedido(pedido.Id);

                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("nomTela", pedido.Tela));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("disenador", pedido.Disenador));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ensayo_ref", pedido.EnsayoReferencia));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("desc_prenda", pedido.DescripcionPrenda));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("fecha_llegada", pedido.FechaLlegada));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("clase", pedido.Clase));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_marcacion", pedido.TipoMarcacion));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("rendimiento", pedido.Rendimiento.ToString()));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("analista_corteb", pedido.AnalistasCortesB));
                this.reportViewer1.LocalReport.DataSources.Clear();

                if (listaInformacion != null && listaTotal != null)
                {
                    ReportDataSource rds1 = new ReportDataSource("Informacion", listaInformacion);
                    ReportDataSource rds2 = new ReportDataSource("Total", listaTotal);
                    ReportDataSource rds3 = new ReportDataSource("Pedidos", listaPedido);
                    this.reportViewer1.LocalReport.DataSources.Add(rds1);
                    this.reportViewer1.LocalReport.DataSources.Add(rds2);
                    this.reportViewer1.LocalReport.DataSources.Add(rds3);
                }

                this.reportViewer1.RefreshReport();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}