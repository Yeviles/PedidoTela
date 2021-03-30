using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class DisponibleParaReserva
    {
        private string disenadora;
        private string pedido;
        private string referencia;
        private string nomTela;
        private string color;
        private string estado;
        private string disponible;
        private string cantidadReservado;
        private string diponibleTeorico;
        private string metrosaReservar;
        private string ensayo;
        public DisponibleParaReserva() { }
        public DisponibleParaReserva(string disenadora, string pedido, string referencia, string nomTela, string color, string estado, string disponible, string cantidadReservado, string diponibleTeorico, string metrosaReservar, string ensayo)
        {
            this.Disenadora = disenadora;
            this.Pedido = pedido;
            this.Referencia = referencia;
            this.NomTela = nomTela;
            this.Color = color;
            this.Estado = estado;
            this.Disponible = disponible;
            this.CantidadReservado = cantidadReservado;
            this.DiponibleTeorico = diponibleTeorico;
            this.MetrosaReservar = metrosaReservar;
            this.Ensayo = ensayo;
        }

        public string Disenadora { get => disenadora; set => disenadora = value; }
        public string Pedido { get => pedido; set => pedido = value; }
        public string Referencia { get => referencia; set => referencia = value; }
        public string NomTela { get => nomTela; set => nomTela = value; }
        public string Color { get => color; set => color = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Disponible { get => disponible; set => disponible = value; }
        public string CantidadReservado { get => cantidadReservado; set => cantidadReservado = value; }
        public string DiponibleTeorico { get => diponibleTeorico; set => diponibleTeorico = value; }
        public string MetrosaReservar { get => metrosaReservar; set => metrosaReservar = value; }
        public string Ensayo { get => ensayo; set => ensayo = value; }
    }
}
