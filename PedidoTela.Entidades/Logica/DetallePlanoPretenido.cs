using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class DetallePlanoPretenido
    {
        private int id;
        private int idPlano;
        private string codigoVte;
        private string descripcionVte;
        private string codigoH1;
        private string descripcionH1;
        private string codigoH2;
        private string descripcionH2;
        private string codigoH3;
        private string descripcionH3;
        private string codigoH4;
        private string descripcionH4;
        private string codigoH5;
        private string descripcionH5;
        private int tiendas;
        private int exito;
        private int cencosud;
        private int sao;
        private int comercio;
        private int rosado;
        private int otros;
        private int total;

        public DetallePlanoPretenido() { }

        public DetallePlanoPretenido(int id, int idPlano, string codigoVte, string descripcionVte, string codigoH1, string descripcionH1, string codigoH2, string descripcionH2, string codigoH3, string descripcionH3, string codigoH4, string descripcionH4, string codigoH5, string descripcionH5, int tiendas, int exito, int cencosud, int sao, int comercio, int rosado, int otros, int total)
        {
            this.Id = id;
            this.IdPlano = idPlano;
            this.CodigoVte = codigoVte;
            this.DescripcionVte = descripcionVte;
            this.CodigoH1 = codigoH1;
            this.DescripcionH1 = descripcionH1;
            this.CodigoH2 = codigoH2;
            this.DescripcionH2 = descripcionH2;
            this.CodigoH3 = codigoH3;
            this.DescripcionH3 = descripcionH3;
            this.CodigoH4 = codigoH4;
            this.DescripcionH4 = descripcionH4;
            this.CodigoH5 = codigoH5;
            this.DescripcionH5 = descripcionH5;
            this.Tiendas = tiendas;
            this.Exito = exito;
            this.Cencosud = cencosud;
            this.Sao = sao;
            this.Comercio = comercio;
            this.Rosado = rosado;
            this.Otros = otros;
            this.Total = total;
        }

        public int Id { get => id; set => id = value; }
        public int IdPlano { get => idPlano; set => idPlano = value; }
        public string CodigoVte { get => codigoVte; set => codigoVte = value; }
        public string DescripcionVte { get => descripcionVte; set => descripcionVte = value; }
        public string CodigoH1 { get => codigoH1; set => codigoH1 = value; }
        public string DescripcionH1 { get => descripcionH1; set => descripcionH1 = value; }
        public string CodigoH2 { get => codigoH2; set => codigoH2 = value; }
        public string DescripcionH2 { get => descripcionH2; set => descripcionH2 = value; }
        public string CodigoH3 { get => codigoH3; set => codigoH3 = value; }
        public string DescripcionH3 { get => descripcionH3; set => descripcionH3 = value; }
        public string CodigoH4 { get => codigoH4; set => codigoH4 = value; }
        public string DescripcionH4 { get => descripcionH4; set => descripcionH4 = value; }
        public string CodigoH5 { get => codigoH5; set => codigoH5 = value; }
        public string DescripcionH5 { get => descripcionH5; set => descripcionH5 = value; }
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
