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
        private string nombreTela;
        private string disenadora;
        private string cargo;
        private string telefono;
        private string ensayoRef;
        private string departamento;
        private decimal anchoTela;
        private string proveedor;
        private string ordenCompra;
        private string extencion;
        private string descPrenda;
        private decimal rendimiento;
        private string contacto;
        private string pedidoAgencia;
        private string composicion;
        private string tipoMarcacion;
        private string nit;
        private string fechaLlegadaTela;
        private int idSolTela;

       
        public AgenciasExternos() { }

        public AgenciasExternos(int idAgencias, string solicitadoPor, string nombreTela, string disenadora, string cargo, string telefono, string ensayoRef, string departamento, decimal anchoTela, string proveedor, string ordenCompra, string extencion, string descPrenda, decimal rendimiento, string contacto, string pedidoAgencia, string composicion, string tipoMarcacion,string nit, string fechaLlegadaTela, int idSolTela)
        {
            this.IdAgencias = idAgencias;
            this.SolicitadoPor = solicitadoPor;
            this.NombreTela = nombreTela;
            this.Disenadora = disenadora;
            this.Cargo = cargo;
            this.Telefono = telefono;
            this.EnsayoRef = ensayoRef;
            this.Departamento = departamento;
            this.AnchoTela = anchoTela;
            this.Proveedor = proveedor;
            this.OrdenCompra = ordenCompra;
            this.Extencion = extencion;
            this.DescPrenda = descPrenda;
            this.Rendimiento = rendimiento;
            this.Contacto = contacto;
            this.PedidoAgencia = pedidoAgencia;
            this.Composicion = composicion;
            this.Nit = nit;
            this.FechaLlegadaTela = fechaLlegadaTela;
            this.IdSolTela = idSolTela;
            this.TipoMarcacion = tipoMarcacion;
        }

        public int IdAgencias { get => idAgencias; set => idAgencias = value; }
        public string SolicitadoPor { get => solicitadoPor; set => solicitadoPor = value; }
        public string NombreTela { get => nombreTela; set => nombreTela = value; }
        public string Disenadora { get => disenadora; set => disenadora = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string EnsayoRef { get => ensayoRef; set => ensayoRef = value; }
        public string Departamento { get => departamento; set => departamento = value; }
        public decimal AnchoTela { get => anchoTela; set => anchoTela = value; }
        public string Proveedor { get => proveedor; set => proveedor = value; }
        public string OrdenCompra { get => ordenCompra; set => ordenCompra = value; }
        public string Extencion { get => extencion; set => extencion = value; }
        public string DescPrenda { get => descPrenda; set => descPrenda = value; }
        public decimal Rendimiento { get => rendimiento; set => rendimiento = value; }
        public string Contacto { get => contacto; set => contacto = value; }
        public string PedidoAgencia { get => pedidoAgencia; set => pedidoAgencia = value; }
        public string Composicion { get => composicion; set => composicion = value; }
        public string TipoMarcacion { get => tipoMarcacion; set => tipoMarcacion = value; }
        public string Nit { get => nit; set => nit = value; }
        public string FechaLlegadaTela { get => fechaLlegadaTela; set => fechaLlegadaTela = value; }
        public int IdSolTela { get => idSolTela; set => idSolTela = value; }
    }
}
