using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class DetalleUnicolor
    {
        private int id;
        private int idUnicolor;
        private string codigoColor;
        private string descripcion;
        private int tiendas;
        private int exito;
        private int cencosud;
        private int sao;
        private int comercio;
        private int rosado;
        private int otros;
        private int total;

        public DetalleUnicolor()
        {

        }

        public DetalleUnicolor(int idUnicolor, string codigoColor, string descripcion, int tiendas, int exito, int cencosud, int sao, int comercio, int rosado, int otros, int total)
        {
            this.idUnicolor = idUnicolor;
            this.codigoColor = codigoColor;
            this.descripcion = descripcion;
            this.tiendas = tiendas;
            this.exito = exito;
            this.cencosud = cencosud;
            this.sao = sao;
            this.comercio = comercio;
            this.rosado = rosado;
            this.otros = otros;
            this.total = total;
        }

        public int Id { get => id; set => id = value; }
        public int IdUnicolor { get => idUnicolor; set => idUnicolor = value; }
        public string CodigoColor { get => codigoColor; set => codigoColor = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Tiendas { get => tiendas; set => tiendas = value; }
        public int Exito { get => exito; set => exito = value; }
        public int Cencosud { get => cencosud; set => cencosud = value; }
        public int Sao { get => sao; set => sao = value; }
        public int Comercio { get => comercio; set => comercio = value; }
        public int Rosado { get => rosado; set => rosado = value; }
        public int Otros { get => otros; set => otros = value; }
        public int Total { get => total; set => total = value; }
    }
}
