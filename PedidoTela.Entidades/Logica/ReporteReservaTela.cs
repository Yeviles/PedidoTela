using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class ReporteReservaTela
    {
        public string Muestrario { get; set; }
        public string Tema { get; set; }
        public string Entrada { get; set; }
        public string EnsayoReferencia { get; set; }
        public string NumeroPedido { get; set; }
        public string Color { get; set; }
        public string Cantidad { get; set; }

        public ReporteReservaTela() { }
    }
}
