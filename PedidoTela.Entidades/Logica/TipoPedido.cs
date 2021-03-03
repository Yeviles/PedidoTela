using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class TipoPedido
    {
        private string tipo;
        private string descripcion;
        public TipoPedido() { }
        public TipoPedido(string tipo, string descripcion)
        {
            this.Tipo = tipo;
            this.Descripcion = descripcion;
        }

        public string Tipo { get => tipo; set => tipo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
