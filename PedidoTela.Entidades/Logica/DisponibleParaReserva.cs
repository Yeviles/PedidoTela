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
        private string codiTela;
        private string color;
        private string desColor;
        private decimal anchoTrazo;
        private string desTalla;
        private string estado;
        private decimal disponible;
        private string cantidadReservado;
        private string diponibleTeorico;
        private string metrosaReservar;
        private string ensayo;
        private int idsolTela;
        public DisponibleParaReserva() { }

        public DisponibleParaReserva(string disenadora, string pedido, string referencia, string nomTela, string codiTela, string color, string desColor, decimal anchoTrazo, string desTalla, string estado, decimal disponible, string cantidadReservado, string diponibleTeorico, string metrosaReservar, string ensayo, int idsolTela)
        {
            this.disenadora = disenadora;
            this.pedido = pedido;
            this.referencia = referencia;
            this.nomTela = nomTela;
            this.codiTela = codiTela;
            this.color = color;
            this.desColor = desColor;
            this.anchoTrazo = anchoTrazo;
            this.desTalla = desTalla;
            this.estado = estado;
            this.disponible = disponible;
            this.cantidadReservado = cantidadReservado;
            this.diponibleTeorico = diponibleTeorico;
            this.metrosaReservar = metrosaReservar;
            this.ensayo = ensayo;
            this.idsolTela = idsolTela;
        }

        public string Disenadora { get => disenadora; set => disenadora = value; }
        public string Pedido { get => pedido; set => pedido = value; }
        public string Referencia { get => referencia; set => referencia = value; }
        public string NomTela { get => nomTela; set => nomTela = value; }
        public string Color { get => color; set => color = value; }
        public string Estado { get => estado; set => estado = value; }
        public decimal Disponible { get => disponible; set => disponible = value; }
        public string CantidadReservado { get => cantidadReservado; set => cantidadReservado = value; }
        public string DiponibleTeorico { get => diponibleTeorico; set => diponibleTeorico = value; }
        public string MetrosaReservar { get => metrosaReservar; set => metrosaReservar = value; }
        public string Ensayo { get => ensayo; set => ensayo = value; }
        public int IdsolTela { get => idsolTela; set => idsolTela = value; }
        public string CodiTela { get => codiTela; set => codiTela = value; }
        public string DesColor { get => desColor; set => desColor = value; }
        public decimal AnchoTrazo { get => anchoTrazo; set => anchoTrazo = value; }
        public string DesTalla { get => desTalla; set => desTalla = value; }
    }
}
