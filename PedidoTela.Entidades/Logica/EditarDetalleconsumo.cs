using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class EditarDetalleconsumo
    {
		//private int idsolicitud; es Atoincrementable 
		private string identificador;
		private string tipo;
		private string descripcionPrenda;
		private string referenciaTela;
		private string descripcionTela;
		private string tipoSolicitud;
		private string consumo;
		private string sku;
		private string fechaTienda;

        public EditarDetalleconsumo() { }

        public EditarDetalleconsumo(string identificador, string tipo, string descripcionPrenda, string referenciaTela, string descripcionTela, string tipoSolicitud, string consumo, string sku, string fechaTienda)
        {
            this.Identificador = identificador;
            this.Tipo = tipo;
            this.DescripcionPrenda = descripcionPrenda;
            this.ReferenciaTela = referenciaTela;
            this.DescripcionTela = descripcionTela;
            this.TipoSolicitud = tipoSolicitud;
            this.Consumo = consumo;
            this.Sku = sku;
            this.FechaTienda = fechaTienda;
        }

        public string Identificador { get => identificador; set => identificador = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string DescripcionPrenda { get => descripcionPrenda; set => descripcionPrenda = value; }
        public string ReferenciaTela { get => referenciaTela; set => referenciaTela = value; }
        public string DescripcionTela { get => descripcionTela; set => descripcionTela = value; }
        public string TipoSolicitud { get => tipoSolicitud; set => tipoSolicitud = value; }
        public string Consumo { get => consumo; set => consumo = value; }
        public string Sku { get => sku; set => sku = value; }
        public string FechaTienda { get => fechaTienda; set => fechaTienda = value; }
    }
}
