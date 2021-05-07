using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class MontajeTelaDetalle
    {
        private string consolidado;
        private bool sel;
        private string solicitud;
        private string tipoSolicitud;
        private string ensayo;
        private string refSimilar;
        private int numDibujos;
        private string codFondo;
        private string fondo;
        private string tipoTela;
        private string coordinado;
        private string coordinadoCon;
        private string refTela;
        private string desTela;
        private string vte;
        private string desColor;
        private string totaUnidades;
        private string consumo;
        private string marca;
        private string muestrario;
        private string ocasionUso;
        private string tema;
        private string entrada;
        private string fechaTienda;
        private string disenador;
        private string obsDiseno;
        private string fechaSolTelas;
        private string estado;
        private string fechaEstado;
        private string tiendas;
        private string exito;
        private string cencosud;
        private string sao;
        private string comercio;
        private string rosado;
        private string otros;
        private string mCalculados;
        private string mReservados;
        private string masolicitar;
        private string tipo;
        private int idSolTela;
        private string cantidadReservado;
        private string idDetalleSolicitud;
        private int idProgramador;
        private string descPrenda;
        private int codigoH1;
        private string descripcionH1;
        private int codigoH2;
        private string descripcionH2;
        private int codigoH3;
        private string descripcionH3;
        private int codigoH4;
        private string descripcionH4;
        private int codigoH5;
        private string descripcionH5;

        public MontajeTelaDetalle() {}


        public MontajeTelaDetalle(bool sel, string solicitud, string tipoSolicitud, string ensayo, string refSimilar, int numDibujos, string codFondo, string fondo, string tipoTela, string coordinado, string coordinadoCon, string refTela, string desTela, string vte, string desColor, string totaUnidades, string consumo, string marca, string muestrario, string ocasionUso, string tema, string entrada, string fechaTienda, string disenador, string obsDiseno, string fechaSolTelas, string estado, string fechaEstado, string tiendas, string exito, string cencosud, string sao, string comercio, string rosado, string otros, string mCalculados, string mReservados, string masolicitar, string tipo, int idSolTela, string cantidadReservado, string idDetalleSolicitud = null, int idProgramador = 0, string descPrenda = null, string consolidado = null, int codigoH1 = 0, string descripcionH1 = null, int codigoH2 = 0, string descripcionH2 = null, int codigoH3 = 0, string descripcionH3 = null, int codigoH4 = 0, string descripcionH4 = null, int codigoH5 = 0, string descripcionH5 = null)
        {
            this.Sel = sel;
            this.Solicitud = solicitud;
            this.TipoSolicitud = tipoSolicitud;
            this.Ensayo = ensayo;
            this.RefSimilar = refSimilar;
            this.NumDibujos = numDibujos;
            this.CodFondo = codFondo;
            this.Fondo = fondo;
            this.TipoTela = tipoTela;
            this.Coordinado = coordinado;
            this.CoordinadoCon = coordinadoCon;
            this.RefTela = refTela;
            this.DesTela = desTela;
            this.Vte = vte;
            this.DesColor = desColor;
            this.TotaUnidades = totaUnidades;
            this.Consumo = consumo;
            this.Marca = marca;
            this.Muestrario = muestrario;
            this.OcasionUso = ocasionUso;
            this.Tema = tema;
            this.Entrada = entrada;
            this.FechaTienda = fechaTienda;
            this.Disenador = disenador;
            this.ObsDiseno = obsDiseno;
            this.FechaSolTelas = fechaSolTelas;
            this.Estado = estado;
            this.FechaEstado = fechaEstado;
            this.Tiendas = tiendas;
            this.Exito = exito;
            this.Cencosud = cencosud;
            this.Sao = sao;
            this.Comercio = comercio;
            this.Rosado = rosado;
            this.Otros = otros;
            this.MCalculados = mCalculados;
            this.MReservados = mReservados;
            this.Masolicitar = masolicitar;
            this.Tipo = tipo;
            this.IdSolTela = idSolTela;
            this.CantidadReservado = cantidadReservado;
            this.IdDetalleSolicitud = idDetalleSolicitud;
            this.IdProgramador = idProgramador;
            this.DescPrenda = descPrenda;
            this.Consolidado = consolidado;
            this.CodigoH1 = codigoH1;
            this.DescripcionH1 = descripcionH1;
            this.CodigoH2 = codigoH2;
            this.DescripcionH2 = descripcionH2;
            this.CodigoH3 = codigoH3;
            this.DescripcionH3 = descripcionH3;
            this.CodigoH4 = codigoH4;
            this.DescripcionH4 = descripcionH4;
            this.CodigoH5 = codigoH5;
            this.DescripcionH5 = descripcionH5;
        }

        public bool Sel { get => sel; set => sel = value; }
        public string Solicitud { get => solicitud; set => solicitud = value; }
        public string TipoSolicitud { get => tipoSolicitud; set => tipoSolicitud = value; }
        public string Ensayo { get => ensayo; set => ensayo = value; }
        public string RefSimilar { get => refSimilar; set => refSimilar = value; }
        public int NumDibujos { get => numDibujos; set => numDibujos = value; }
        public string CodFondo { get => codFondo; set => codFondo = value; }
        public string Fondo { get => fondo; set => fondo = value; }
        public string TipoTela { get => tipoTela; set => tipoTela = value; }
        public string Coordinado { get => coordinado; set => coordinado = value; }
        public string CoordinadoCon { get => coordinadoCon; set => coordinadoCon = value; }
        public string RefTela { get => refTela; set => refTela = value; }
        public string DesTela { get => desTela; set => desTela = value; }
        public string Vte { get => vte; set => vte = value; }
        public string DesColor { get => desColor; set => desColor = value; }
        public string TotaUnidades { get => totaUnidades; set => totaUnidades = value; }
        public string Consumo { get => consumo; set => consumo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Muestrario { get => muestrario; set => muestrario = value; }
        public string OcasionUso { get => ocasionUso; set => ocasionUso = value; }
        public string Tema { get => tema; set => tema = value; }
        public string Entrada { get => entrada; set => entrada = value; }
        public string FechaTienda { get => fechaTienda; set => fechaTienda = value; }
        public string Disenador { get => disenador; set => disenador = value; }
        public string ObsDiseno { get => obsDiseno; set => obsDiseno = value; }
        public string FechaSolTelas { get => fechaSolTelas; set => fechaSolTelas = value; }
        public string Estado { get => estado; set => estado = value; }
        public string FechaEstado { get => fechaEstado; set => fechaEstado = value; }
        public string Tiendas { get => tiendas; set => tiendas = value; }
        public string Exito { get => exito; set => exito = value; }
        public string Cencosud { get => cencosud; set => cencosud = value; }
        public string Sao { get => sao; set => sao = value; }
        public string Comercio { get => comercio; set => comercio = value; }
        public string Rosado { get => rosado; set => rosado = value; }
        public string Otros { get => otros; set => otros = value; }
        public string MCalculados { get => mCalculados; set => mCalculados = value; }
        public string MReservados { get => mReservados; set => mReservados = value; }
        public string Masolicitar { get => masolicitar; set => masolicitar = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int IdSolTela { get => idSolTela; set => idSolTela = value; }
        public string CantidadReservado { get => cantidadReservado; set => cantidadReservado = value; }
        public string IdDetalleSolicitud { get => idDetalleSolicitud; set => idDetalleSolicitud = value; }
        public int IdProgramador { get => idProgramador; set => idProgramador = value; }
        public string DescPrenda { get => descPrenda; set => descPrenda = value; }
        public string Consolidado { get => consolidado; set => consolidado = value; }
        public int CodigoH1 { get => codigoH1; set => codigoH1 = value; }
        public string DescripcionH1 { get => descripcionH1; set => descripcionH1 = value; }
        public int CodigoH2 { get => codigoH2; set => codigoH2 = value; }
        public string DescripcionH2 { get => descripcionH2; set => descripcionH2 = value; }
        public int CodigoH3 { get => codigoH3; set => codigoH3 = value; }
        public string DescripcionH3 { get => descripcionH3; set => descripcionH3 = value; }
        public int CodigoH4 { get => codigoH4; set => codigoH4 = value; }
        public string DescripcionH4 { get => descripcionH4; set => descripcionH4 = value; }
        public int CodigoH5 { get => codigoH5; set => codigoH5 = value; }
        public string DescripcionH5 { get => descripcionH5; set => descripcionH5 = value; }
    }
}
