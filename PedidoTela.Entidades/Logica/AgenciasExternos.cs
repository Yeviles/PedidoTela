using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class AgenciasExternos
    {
        private int idAgencias;
        private string solicitadoPor;
        private string cargo;
        private string departamento;
        private string telefono;
        private string extencion;
        private string referenciaTela;
        private string tipoTejido;
        private string fondo;
        private string nombreTela;
        private decimal anchoTela;
        private decimal rendimiento;
        private string composicion;
        private string muestrario;
        private string ocasionUso;
        private string tema;
        private string entrada;
        private string ensayoRef;
        private string fechaTienda;
        private string disenadora;
        private string descPrenda;
        private string proveedor;
        private string nit;
        private string contacto;
        private string pedidoAgencia;
        private string ordenCompra;
        private string fechaLlegadaTela;
        private int idSolTela;

        public AgenciasExternos() { }

        public AgenciasExternos(string solicitadoPor, string cargo, string departamento, string telefono, string extencion, string referenciaTela, string tipoTejido, string fondo, string nombreTela, decimal anchoTela, decimal rendimiento, string muestrario, string ocasionUso, string tema, string entrada, string ensayoRef, string fechaTienda, string disenadora, string descPrenda, string proveedor, string nit, string contacto, string pedidoAgencia, string ordenCompra, string fechaLlegadaTela, int idSolTela, string composicion, int idAgencias)
        {
            this.SolicitadoPor = solicitadoPor;
            this.Cargo = cargo;
            this.Departamento = departamento;
            this.Telefono = telefono;
            this.Extencion = extencion;
            this.ReferenciaTela = referenciaTela;
            this.TipoTejido = tipoTejido;
            this.Fondo = fondo;
            this.NombreTela = nombreTela;
            this.AnchoTela = anchoTela;
            this.Rendimiento = rendimiento;
            this.Muestrario = muestrario;
            this.OcasionUso = ocasionUso;
            this.Tema = tema;
            this.Entrada = entrada;
            this.EnsayoRef = ensayoRef;
            this.FechaTienda = fechaTienda;
            this.Disenadora = disenadora;
            this.DescPrenda = descPrenda;
            this.Proveedor = proveedor;
            this.Nit = nit;
            this.Contacto = contacto;
            this.PedidoAgencia = pedidoAgencia;
            this.OrdenCompra = ordenCompra;
            this.FechaLlegadaTela = fechaLlegadaTela;
            this.IdSolTela = idSolTela;
            this.Composicion = composicion;
            this.IdAgencias = idAgencias;
        }

        public string SolicitadoPor { get => solicitadoPor; set => solicitadoPor = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Extencion { get => extencion; set => extencion = value; }
        public string ReferenciaTela { get => referenciaTela; set => referenciaTela = value; }
        public string TipoTejido { get => tipoTejido; set => tipoTejido = value; }
        public string Fondo { get => fondo; set => fondo = value; }
        public string NombreTela { get => nombreTela; set => nombreTela = value; }
        public decimal AnchoTela { get => anchoTela; set => anchoTela = value; }
        public decimal Rendimiento { get => rendimiento; set => rendimiento = value; }
        public string Muestrario { get => muestrario; set => muestrario = value; }
        public string OcasionUso { get => ocasionUso; set => ocasionUso = value; }
        public string Tema { get => tema; set => tema = value; }
        public string Entrada { get => entrada; set => entrada = value; }
        public string EnsayoRef { get => ensayoRef; set => ensayoRef = value; }
        public string FechaTienda { get => fechaTienda; set => fechaTienda = value; }
        public string Disenadora { get => disenadora; set => disenadora = value; }
        public string DescPrenda { get => descPrenda; set => descPrenda = value; }
        public string Proveedor { get => proveedor; set => proveedor = value; }
        public string Nit { get => nit; set => nit = value; }
        public string Contacto { get => contacto; set => contacto = value; }
        public string PedidoAgencia { get => pedidoAgencia; set => pedidoAgencia = value; }
        public string OrdenCompra { get => ordenCompra; set => ordenCompra = value; }
        public string FechaLlegadaTela { get => fechaLlegadaTela; set => fechaLlegadaTela = value; }
        public int IdSolTela { get => idSolTela; set => idSolTela = value; }
        public string Composicion { get => composicion; set => composicion = value; }
        public int IdAgencias { get => idAgencias; set => idAgencias = value; }
    }
}
