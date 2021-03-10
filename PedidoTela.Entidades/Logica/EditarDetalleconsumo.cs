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
		private string desc_prenda;
		private string referencia_tela;
		private string desc_tela;
		private string consumo;
		private string sku;
		private string fecha_tienda;

        public EditarDetalleconsumo() { }

        public EditarDetalleconsumo( string identificador, string tipo, string desc_prenda, string referencia_tela, string desc_tela, string consumo, string sku, string fecha_tienda)
        {
           
            this.Identificador = identificador;
            this.Tipo = tipo;
            this.Desc_prenda = desc_prenda;
            this.Referencia_tela = referencia_tela;
            this.Desc_tela = desc_tela;
            this.Consumo = consumo;
            this.Sku = sku;
            this.Fecha_tienda = fecha_tienda;
        }

        public string Identificador { get => identificador; set => identificador = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Desc_prenda { get => desc_prenda; set => desc_prenda = value; }
        public string Referencia_tela { get => referencia_tela; set => referencia_tela = value; }
        public string Desc_tela { get => desc_tela; set => desc_tela = value; }
        public string Consumo { get => consumo; set => consumo = value; }
        public string Sku { get => sku; set => sku = value; }
        public string Fecha_tienda { get => fecha_tienda; set => fecha_tienda = value; }
    }
}
