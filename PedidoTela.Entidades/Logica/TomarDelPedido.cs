using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class TomarDelPedido
    {
        private int idPedidoMontar;
        private string numeroPedido;
        private int codigoColor;
        private string estado;
        private decimal disponible;
        private string tipoPedido;

        public TomarDelPedido() { }

        public TomarDelPedido(int idPedidoMontar, string numeroPedido, int codigoColor, string estado, decimal disponible, string tipoPedido)
        {
            this.idPedidoMontar = idPedidoMontar;
            this.numeroPedido = numeroPedido;
            this.codigoColor = codigoColor;
            this.estado = estado;
            this.disponible = disponible;
            this.TipoPedido = tipoPedido;
        }

        public string NumeroPedido { get => numeroPedido; set => numeroPedido = value; }
        public int CodigoColor { get => codigoColor; set => codigoColor = value; }
        public string Estado { get => estado; set => estado = value; }
        public decimal Disponible { get => disponible; set => disponible = value; }
        public int IdPedidoMontar { get => idPedidoMontar; set => idPedidoMontar = value; }
        public string TipoPedido { get => tipoPedido; set => tipoPedido = value; }
    }
}
