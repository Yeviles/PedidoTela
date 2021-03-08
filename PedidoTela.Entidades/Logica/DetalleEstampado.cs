using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class DetalleEstampado
    {
        private string codigoColor;
        private string desc_color;
        private string fondo;
        private string des_fondo;
        private int tiendas;
        private int exito;
        private int cencosud;
        private int sao;
        private int comercio;
        private int rosado;
        private int otros;
        private int total;
        private int idEstampado;

        public DetalleEstampado() { }

        public DetalleEstampado(string codigoColor, string desc_color, string fondo, string des_fondo, int tiendas, int exito, int cencosud, int sao, int comercio, int rosado, int otros, int total, int idEstampado)
        {
            this.codigoColor = codigoColor;
            this.desc_color = desc_color;
            this.fondo = fondo;
            this.des_fondo = des_fondo;
            this.tiendas = tiendas;
            this.exito = exito;
            this.cencosud = cencosud;
            this.sao = sao;
            this.comercio = comercio;
            this.rosado = rosado;
            this.otros = otros;
            this.total = total;
            this.IdEstampado = idEstampado;
        }

        public string CodigoColor { get => codigoColor; set => codigoColor = value; }
        public string Desc_color { get => desc_color; set => desc_color = value; }
        public string Fondo { get => fondo; set => fondo = value; }
        public string Des_fondo { get => des_fondo; set => des_fondo = value; }
        public int Tiendas { get => tiendas; set => tiendas = value; }
        public int Exito { get => exito; set => exito = value; }
        public int Cencosud { get => cencosud; set => cencosud = value; }
        public int Sao { get => sao; set => sao = value; }
        public int Comercio { get => comercio; set => comercio = value; }
        public int Rosado { get => rosado; set => rosado = value; }
        public int Otros { get => otros; set => otros = value; }
        public int Total { get => total; set => total = value; }
        public int IdEstampado { get => idEstampado; set => idEstampado = value; }
    }
}
