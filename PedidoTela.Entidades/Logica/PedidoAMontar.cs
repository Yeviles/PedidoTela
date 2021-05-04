using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades
{
    public class PedidoAMontar
    {
        private int id;
        private int idSolicitud;
        private string tela;
        private string disenador;
        private string ensayoReferencia;
        private string descripcionPrenda;
        private string clase;
        private string tipoMarcacion;
        private decimal rendimiento;
        private string analistasCortesB;
        private string fechaLlegada;

        public PedidoAMontar(){}

        public PedidoAMontar(int id, int idSolicitud, string tela, string disenador, string ensayoReferencia, string descripcionPrenda, string clase, string tipoMarcacion, decimal rendimiento, string analistasCortesB, string fechaLlegada)
        {
            this.id = id;
            this.idSolicitud = idSolicitud;
            this.tela = tela;
            this.disenador = disenador;
            this.ensayoReferencia = ensayoReferencia;
            this.descripcionPrenda = descripcionPrenda;
            this.clase = clase;
            this.tipoMarcacion = tipoMarcacion;
            this.rendimiento = rendimiento;
            this.analistasCortesB = analistasCortesB;
            this.fechaLlegada = fechaLlegada;
        }

        public int Id { get => id; set => id = value; }
        public int IdSolicitud { get => idSolicitud; set => idSolicitud = value; }
        public string Tela { get => tela; set => tela = value; }
        public string Disenador { get => disenador; set => disenador = value; }
        public string EnsayoReferencia { get => ensayoReferencia; set => ensayoReferencia = value; }
        public string DescripcionPrenda { get => descripcionPrenda; set => descripcionPrenda = value; }
        public string Clase { get => clase; set => clase = value; }
        public string TipoMarcacion { get => tipoMarcacion; set => tipoMarcacion = value; }
        public decimal Rendimiento { get => rendimiento; set => rendimiento = value; }
        public string AnalistasCortesB { get => analistasCortesB; set => analistasCortesB = value; }
        public string FechaLlegada { get => fechaLlegada; set => fechaLlegada = value; }
    }
}