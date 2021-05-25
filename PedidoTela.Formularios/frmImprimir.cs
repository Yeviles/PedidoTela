using MaterialSkin;
using Microsoft.Reporting.WinForms;
using PedidoTela.Controlodores;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidoTela.Formularios
{
    public partial class frmImprimir : MaterialSkin.Controls.MaterialForm
    {
        Controlador control = new Controlador();
        Validar validacion = new Validar();

        public frmImprimir(Controlador control)
        {
            InitializeComponent();
            this.control = control;
        }

        private void frmImprimir_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void btnSolicitudTelas_Click(object sender, EventArgs e)
        {
            pnlSolicitudInventario.Visible = false;
            pnlPedidoTela.Visible = false;
            pnlSolicitudTelas.Visible = true;
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.Visible = true;

        }

        private void btnSolicitudInventario_Click(object sender, EventArgs e)
        {
            pnlSolicitudTelas.Visible = false;
            pnlPedidoTela.Visible = false;
            pnlSolicitudInventario.Visible = true;
            dgvSolicitudInventario.Rows.Clear();
            this.reportViewer1.LocalReport.DataSources.Clear();
            List<Objeto> lista = control.getSolicitudesInventario();
            cargarDgvSolicitudInventario(lista);
            this.reportViewer1.Visible = false;
        }

        private void btnPedidoTela_Click(object sender, EventArgs e)
        {
            pnlPedidoTela.Visible = false;
            pnlSolicitudInventario.Visible = false;
            pnlPedidoTela.Visible = true;
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBuscarSolTelas_Click(object sender, EventArgs e)
        {
            if(cbxTipoSolicitud.Text != "")
            {
                if (txtEnsayoRef.Text != "")
                {
                    if (cbxTipoSolicitud.SelectedItem.ToString() == "UNICOLOR")
                    {
                        int idUnicolor = control.getIdUnicolor(txtEnsayoRef.Text);
                        if (idUnicolor != 0)
                        {
                            int idSolicitud = control.getIdSoltela(idUnicolor);
                            imprimirSolicitudUnicolor(idSolicitud);
                        }
                        else
                        {
                            MessageBox.Show("El Ensayo o Referencia ingresados \n No existe en las solicitudes Unicolor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                   
                    else if (cbxTipoSolicitud.SelectedItem.ToString() == "ESTAMPADO")
                    {
                        int idEstampado = control.consultarIdEstampado(txtEnsayoRef.Text);
                        if (idEstampado != 0)
                        {
                            int idSolicitud = control.getIdSoltelaEst(idEstampado);
                            imprimirSolicitudEstampado(idSolicitud);
                        }
                        else
                        {
                            MessageBox.Show("El Ensayo o Referencia ingresados \n No existe en las solicitudes Estampado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    
                    else if (cbxTipoSolicitud.SelectedItem.ToString() == "PLANO PRETEÑIDO")
                    {
                        int idPlano = control.getIdPlanoPretenido(txtEnsayoRef.Text);
                        if (idPlano !=0)
                        {
                            int idSolicitud = control.getIdSoltelaPla(idPlano);
                            imprimirSolicitudPlano(idSolicitud);
                        }
                        else
                        {
                            MessageBox.Show("El Ensayo o Referencia ingresados \n No existe en las solicitudes Plano Preteñido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    
                    else if (cbxTipoSolicitud.SelectedItem.ToString() == "CUELLOS PUÑOS TIRAS")
                    {
                        int idCuellos = control.consultarIdCuellos(txtEnsayoRef.Text);
                        if (idCuellos != 0)
                        {
                            int idSolicitud = control.getIdSoltelaCue(idCuellos);
                            imprimirSolicitudCuellos(idSolicitud);
                        }
                        else
                        {
                            MessageBox.Show("El Ensayo o Referencia ingresados \n No existe en las solicitudes Cuellos Puños y Tiras.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un valor para Ensayo/Referencia.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Por favor seleccione un tipo de solicitud.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnBuscarSolInventario_Click(object sender, EventArgs e)
        {
         
            if (txtEnsayoRefInventario.Text != "")
            {
                int idSolicitud = control.consultarIdSolicitudAgencias(txtEnsayoRefInventario.Text);
                if (idSolicitud != 0)
                {
                    frmImprimirSIP imprimir = new frmImprimirSIP(control, idSolicitud);
                    imprimir.Show();
                }
                else
                {
                    MessageBox.Show("El Ensayo/referencia ingresados \n No existe en Inventario Externo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un valor para Ensayo/Referencia.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnbuscarPedidoTela_Click(object sender, EventArgs e)
        {
            if (cbxTipoPedido.Text!="")
            {
                if (txtConsecutivoPedido.Text != "")
                {
                    if (cbxTipoPedido.SelectedItem.ToString() == "UNICOLOR")
                    {
                        int idSolicitud = control.consultarIdSolicitud(int.Parse(txtConsecutivoPedido.Text), "UNICOLOR");
                        if (idSolicitud != 0)
                        {
                            frmImprimirPedUnicolor frmPedUnicolor = new frmImprimirPedUnicolor(control, idSolicitud);
                            frmPedUnicolor.Show();
                        }
                        else
                        {
                            MessageBox.Show("El consecutivo ingresado \n No existe en las Pedido Unicolor", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (cbxTipoPedido.SelectedItem.ToString() == "ESTAMPADO")
                    {
                        int idSolicitud = control.consultarIdSolicitud(int.Parse(txtConsecutivoPedido.Text), "ESTAMPADO");
                        if (idSolicitud != 0)
                        {
                            frmImprimirPedidoEstampado imprimir = new frmImprimirPedidoEstampado(control, idSolicitud);
                            imprimir.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("El consecutivo ingresado \n No existe en las Pedido Estampado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (cbxTipoPedido.SelectedItem.ToString() == "PLANO PRETEÑIDO")
                    {
                        int idSolicitud = control.consultarIdSolicitud(int.Parse(txtConsecutivoPedido.Text), "PLANO");
                        if (idSolicitud != 0)
                        {
                            frmImprimirPedidoPlano frmPedUnicolor = new frmImprimirPedidoPlano(control, idSolicitud);
                            frmPedUnicolor.Show();
                        }
                        else
                        {
                            MessageBox.Show("El consecutivo ingresado \n No existe en las Pedido Plano Preteñido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (cbxTipoPedido.SelectedItem.ToString() == "CUELLOS PUÑOS TIRAS")
                    {
                        int idSolicitud = control.consultarIdSolicitud(int.Parse(txtConsecutivoPedido.Text), "CUELLOS");
                        if (idSolicitud != 0)
                        {
                            frmImprimirPedidoCuellos frmImprimirPedidoCuellos = new frmImprimirPedidoCuellos(control, idSolicitud);
                            frmImprimirPedidoCuellos.Show();

                        }
                        else
                        {
                            MessageBox.Show("El consecutivo ingresado \n No existe en las Pedido Cuellos Puños Tiras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (cbxTipoPedido.SelectedItem.ToString() == "COORDINADO 3 EN 1")
                    {
                        int idSolicitud = control.consultarIdSolicitud(int.Parse(txtConsecutivoPedido.Text), "COORDINADO");
                        if (idSolicitud != 0)
                        {
                            frmImprimirPedidoCoordinado imprimir = new frmImprimirPedidoCoordinado(control, idSolicitud);
                            imprimir.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("El consecutivo ingresado \n No existe en las Pedido Coordinado 3 en 1", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (cbxTipoPedido.SelectedItem.ToString() == "AGENCIAS EXTERNOS")
                    {
                        int idSolicitud = control.consultarIdSolicitud(int.Parse(txtConsecutivoPedido.Text), "AGENCIAS EXTERNOS");
                        if (idSolicitud != 0)
                        {
                            frmImprimirPedidoAgencias imprimir = new frmImprimirPedidoAgencias(control, idSolicitud);
                            imprimir.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("El consecutivo ingresado \n No existe en las Pedido Agencias Externos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese un valor para Consecutivo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                MessageBox.Show("Por favor seleccione un tipo de Pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void imprimirSolicitudUnicolor(int idSolicitud)
        {
   
            Unicolor unicolor = control.getUnicolor(idSolicitud);
            List<DetalleUnicolor> listaUnicolor = control.getDetalleUnicolor(unicolor.Id);
            
            List<DetalleUnicolor> lista = new List<DetalleUnicolor>();
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PedidoTela.Formularios.PDFSolicitudUnicolor.rdlc"; 
           
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("EnsayoRef", unicolor.Identificador));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("referencia_tela", unicolor.ReferenciaTela));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("nombre_tela", unicolor.ReferenciaTela));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_tejido", unicolor.TipoTejido));
            if (unicolor.Coordinado.ToString() == "true")
            {
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("coordinado", "SI"));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("coordinado_con", unicolor.CoordinadoCon.ToString()));
            }
            else
            {
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("coordinado", "NO"));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("coordinado_con", "Sin coordinado"));
            }
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("observaciones", unicolor.Observacion.ToString()));

            this.reportViewer1.LocalReport.DataSources.Clear();

            if (listaUnicolor != null)
            {
                int i = 0;
                foreach (DetalleUnicolor elem in listaUnicolor)
                {
                    DetalleUnicolor obj = new DetalleUnicolor();
                    obj.CodigoColor = elem.CodigoColor;
                    obj.Descripcion = elem.Descripcion;
                    obj.Tiendas = elem.Tiendas;
                    obj.Exito = elem.Exito;
                    obj.Cencosud = elem.Cencosud;
                    obj.Sao = elem.Sao;
                    obj.Comercio = elem.Comercio;
                    obj.Rosado = elem.Rosado;
                    obj.Otros = elem.Otros;
                    obj.Total = elem.Total;
                    lista.Add(obj);
                    i++;
                }

                ReportDataSource rds1 = new ReportDataSource("detalleUnicolor", lista);
                this.reportViewer1.LocalReport.DataSources.Add(rds1);
            }

            this.reportViewer1.RefreshReport();
        }

        private void imprimirSolicitudEstampado(int idSolicitud)
        {
            Estampado estampado = control.getEstampado(idSolicitud);
            List<DetalleEstampado> listaEstampado = control.getDetalleEstampado(estampado.IdEstampado);

            List<DetalleEstampado> lista = new List<DetalleEstampado>();
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PedidoTela.Formularios.PDFSolicitudEstampado.rdlc";

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ensayoRef", estampado.Esayo_ref));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("referencia_tela", estampado.Referencia_tela));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("nombre_tela", estampado.Nombre_tela));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_estampado", estampado.Tipo_estampado));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_tejido", estampado.Tipo_tejido));
            if(estampado.Coordinado.ToString() == "true")
            {
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("coordinado", "SI"));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("coordinado_con", estampado.Coordinado_con.ToString()));
            }
            else
            {
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("coordinado", "NO"));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("coordinado_con","Sin coordinado"));
            }
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("num_dibujos", estampado.N_dibujos.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("num_cilindros", estampado.N_cilindros.ToString()));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("observaciones", estampado.Observaciones.ToString()));
            this.reportViewer1.LocalReport.DataSources.Clear();

            if (listaEstampado != null)
            {
                int i = 0;
                foreach (DetalleEstampado elem in listaEstampado)
                {
                    DetalleEstampado obj = new DetalleEstampado();
                    obj.CodigoColor = elem.CodigoColor;
                    obj.Desc_color = elem.Desc_color;
                    obj.Fondo = elem.Fondo;
                    obj.Des_fondo = elem.Des_fondo;
                    obj.Tiendas = elem.Tiendas;
                    obj.Exito = elem.Exito;
                    obj.Cencosud = elem.Cencosud;
                    obj.Sao = elem.Sao;
                    obj.Comercio = elem.Comercio;
                    obj.Rosado = elem.Rosado;
                    obj.Otros = elem.Otros;
                    obj.Total = elem.Total;
                    lista.Add(obj);
                    i++;
                }

                ReportDataSource rds1 = new ReportDataSource("detalleEstampado", lista);
                this.reportViewer1.LocalReport.DataSources.Add(rds1);
            }

            this.reportViewer1.RefreshReport();
        }

        private void imprimirSolicitudPlano(int idSolicitud)
        {
            PlanoPretenido plano = control.getPlanoPretenido(idSolicitud);
            List<DetallePlanoPretenido> listaPlano = control.getDetallePlanoPretenido(plano.Id);

            List<DetallePlanoPretenido> lista = new List<DetallePlanoPretenido>();
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PedidoTela.Formularios.PDFSolicitudPlano.rdlc";

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ensayo_ref", plano.Identificador));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("referencia_tela", plano.ReferenciaTela));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("nombre_tela", plano.ReferenciaTela));
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_tejido", plano.TipoTejido));
            if (plano.Coordinado.ToString() == "true")
            {
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("coordinado", "SI"));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("coordinado_con", plano.CoordinadoCon.ToString()));
            }
            else
            {
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("coordinado", "NO"));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("coordinado_con", "Sin coordinado"));
            }

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("observaciones", plano.Observacion.ToString()));
            this.reportViewer1.LocalReport.DataSources.Clear();

            if (listaPlano != null)
            {
                int i = 0;
                foreach (DetallePlanoPretenido elem in listaPlano)
                {
                    DetallePlanoPretenido obj = new DetallePlanoPretenido();
                    obj.CodigoVte = elem.CodigoVte;
                    obj.DescripcionVte = elem.DescripcionVte;
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
                    obj.Comercio = elem.Comercio;
                    obj.Rosado = elem.Rosado;
                    obj.Otros = elem.Otros;
                    obj.Total = elem.Total;
                    lista.Add(obj);
                    i++;
                }

                ReportDataSource rds1 = new ReportDataSource("detallePlano", lista);
                this.reportViewer1.LocalReport.DataSources.Add(rds1);
            }

            this.reportViewer1.RefreshReport();
        }
        
        private void imprimirSolicitudCuellos(int idSolicitud)
        {
            CuellosTiras cuellos = control.getCuellosTiras(idSolicitud);
            List<DetalleCuelloUno> listaUno = control.getDetalleCuellosUno(cuellos.IdCuellos);
            List<DetalleCuelloDos> listaDos = control.getDetalleCuellosDos(cuellos.IdCuellos);

            List<DetalleCuelloUno> lista1 = new List<DetalleCuelloUno>();
            List<DetalleCuelloDos> lista2 = new List<DetalleCuelloDos>();

            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PedidoTela.Formularios.PDFSolicitudCuellos.rdlc";


            this.reportViewer1.LocalReport.EnableExternalImages = true;
            cargarImagen(cuellos.Identificador, idSolicitud);
            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("ensayo_ref", cuellos.Identificador));

            if (cuellos.Cuellos)
            {
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_cuellos", "Cuellos"));
            }
            if (cuellos.Punos)
            {
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_punos", "Puños"));
            }
            if (cuellos.Tiras)
            {
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_tiras", "Tiras"));
            }
            if (cuellos.Cuellos && cuellos.Punos)
            {
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_cuellos", "Cuellos"));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_tiras", "Puños"));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_tiras", "-"));
            }
             if(cuellos.Tiras && cuellos.Cuellos)
            {
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_tiras", "Tiras"));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_cuellos", "Cuellos"));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_punos", "-"));


            }
            if (cuellos.Punos && cuellos.Tiras)
            {
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_cuellos", "-"));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_punos", "Puños"));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("tipo_tiras", "Puños"));

            }

            if (cuellos.Coordinado.ToString() == "true")
            {
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("coordinado", "SI"));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("coordinado_con", cuellos.CoordinadoCon.ToString()));
            }
            else
            {
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("coordinado", "NO"));
                this.reportViewer1.LocalReport.SetParameters(new ReportParameter("coordinado_con", "Sin coordinado"));
            }

            this.reportViewer1.LocalReport.SetParameters(new ReportParameter("observaciones", cuellos.Observacion.ToString()));
            this.reportViewer1.LocalReport.DataSources.Clear();

            if (listaUno != null&& listaDos != null)
            {
                int i = 0;
                foreach (DetalleCuelloUno elem in listaUno)
                {
                    DetalleCuelloUno obj = new DetalleCuelloUno();
                    obj.NombreChechSel = elem.NombreChechSel;
                    obj.Codigo = elem.Codigo;
                    obj.Xs = elem.Xs;
                    obj.S = elem.S;
                    obj.M = elem.M;
                    obj.L = elem.L;
                    obj.Xl = elem.Xl;
                    obj.Dosxl = elem.Dosxl;
                    obj.Cuatro = elem.Cuatro;
                    obj.Seis = elem.Seis;
                    obj.Ocho = elem.Ocho;
                    obj.Diez = elem.Diez;
                    obj.Doce = elem.Doce;
                    obj.Catorce = elem.Catorce;
                    obj.Dieciseis = elem.Dieciseis;
                    obj.Dieciocho = elem.Dieciocho;
                    obj.Veinte = elem.Veinte;
                    obj.Veintidos = elem.Veintidos;
                    obj.Veinticuatro = elem.Veinticuatro;
                    obj.Ancho = elem.Ancho;
                    lista1.Add(obj);
                    i++;
                }
                foreach (DetalleCuelloDos elem in listaDos)
                {
                    DetalleCuelloDos obj = new DetalleCuelloDos();
                    obj.CodigoVte = elem.CodigoVte;
                    obj.DescripcionVte = elem.DescripcionVte;
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
                    obj.Total = elem.Total;
                    lista2.Add(obj);

                    lista2.Add(obj);
                    i++;
                }

                ReportDataSource rds1 = new ReportDataSource("detalleCuello1", lista1);
                ReportDataSource rds2 = new ReportDataSource("detalleCuelloDos", lista2);
                this.reportViewer1.LocalReport.DataSources.Add(rds1);
                this.reportViewer1.LocalReport.DataSources.Add(rds2);
            }

            this.reportViewer1.RefreshReport();
        }

        private void cargarImagen(string identificador, int idSolTela)
        {
            try
            {
                string ruta = Application.StartupPath + "\\Imagenes\\" + identificador + idSolTela + "\\imagen\\";
                string rutaCuelloss = ruta + identificador + idSolTela + "_imagen_cuello.jpeg";
                string rutaPunoss = ruta + identificador + idSolTela + "_imagen_punos.jpeg";
                string rutaTirass = ruta + identificador + idSolTela + "_imagen_tiras.jpeg";

                Image varImgCuellos = null, varImgPunos = null, varImgTiras = null;

                if (Directory.Exists(ruta))
                {
                    if (File.Exists(rutaCuelloss))
                    {
                        varImgCuellos = Image.FromStream(new MemoryStream(File.ReadAllBytes(rutaCuelloss)));
                    }
                    if (File.Exists(rutaPunoss))
                    {
                        varImgPunos = Image.FromStream(new MemoryStream(File.ReadAllBytes(rutaPunoss)));
                    }
                    if (File.Exists(rutaTirass))
                    {
                        varImgTiras = Image.FromStream(new MemoryStream(File.ReadAllBytes(rutaTirass)));
                    }
                }
                //else
                //{
                //    MessageBox.Show("Directorio de imagenes no encontrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}

                if (varImgCuellos != null)
                {
                    //rutaCuelloss.Split('.');
                    //ReportParameter rutaCuello = new ReportParameter("rutaCuello",new Uri(split[split.Length - 1].ToLower()).AbsoluteUri);
                    ReportParameter rutaCuello = new ReportParameter("rutaCuello",new Uri(rutaCuelloss).AbsoluteUri);
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rutaCuello });

                }
                if (varImgPunos != null)
                {
                    //string[] split = rutaPunoss.Split('.');
                    ReportParameter rutaPuno = new ReportParameter("rutaPuno",new Uri(rutaPunoss).AbsoluteUri);
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rutaPuno });
                }
                if (varImgTiras != null)
                {
                    //string[] split = rutaTirass.Split('.');
                    ReportParameter rutaTira = new ReportParameter("rutaTira",new Uri(rutaTirass).AbsoluteUri);
                    this.reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rutaTira });

                }

            }
            catch (FileNotFoundException) { }
            catch (OutOfMemoryException) { }
        }

        private void cargarDgvSolicitudInventario(List<Objeto> prmLista)
        {
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {
                    dgvSolicitudInventario.Rows.Add(prmLista[i].Id.ToString(),
                    prmLista[i].Nombre.ToString()
        
                    );
                }
            }
           
        }

            private void txtConsecutivoPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void txtConsecutivoInventario_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void dgvSolicitudInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (dgvSolicitudInventario.Rows.Count != 0)
                {
                    if (dgvSolicitudInventario.Columns[e.ColumnIndex].Name == "ensayoRef" || dgvSolicitudInventario.Columns[e.ColumnIndex].Name == "estados")
                    {
                        txtEnsayoRefInventario.Text = dgvSolicitudInventario.Rows[e.RowIndex].Cells[0].Value.ToString();
                    }
                }
            }
        }
    }
}
