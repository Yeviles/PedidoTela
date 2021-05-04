using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class PedidoMontarInformacion
    {
        private int idPedidoAMontar;
        private string codigoColor;
        private string descripcionColor;
        private int codigoH1;
        private string descripcionH1;
        private int codigoH2;
        private string descripcionH2;
        private int codigoH3;
        private string descripcionH3;
        private int codigoH4;
        private string descripcionH4;
        private int codigoH5;
        private string descripcionH5;
        private int tiendas;
        private int exito;
        private int cencosud;
        private int sao;
        private int comercioOrg;
        private int rosado;
        private int otros;
        private int totalUnidades;
        private decimal consumo;
        private decimal mCalculados;
        private decimal mReservados;
        private decimal mSolicitar;
        private decimal kgCalculados;

        public PedidoMontarInformacion() { }

        public PedidoMontarInformacion(int idPedidoAMontar, string codigoColor, string descripcionColor, int codigoH1, string descripcionH1, int codigoH2, string descripcionH2, int codigoH3, string descripcionH3, int codigoH4, string descripcionH4, int codigoH5, string descripcionH5, int tiendas, int exito, int cencosud, int sao, int comercioOrg, int rosado, int otros, int totalUnidades, decimal consumo, decimal mCalculados, decimal mReservados, decimal mSolicitar, decimal kgCalculados)
        {
            this.IdPedidoAMontar = idPedidoAMontar;
            this.CodigoColor = codigoColor;
            this.DescripcionColor = descripcionColor;
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
            this.ComercioOrg = comercioOrg;
            this.Rosado = rosado;
            this.Otros = otros;
            this.TotalUnidades = totalUnidades;
            this.Consumo = consumo;
            this.MCalculados = mCalculados;
            this.MReservados = mReservados;
            this.MSolicitar = mSolicitar;
            this.KgCalculados = kgCalculados;
        }

        public int IdPedidoAMontar { get => idPedidoAMontar; set => idPedidoAMontar = value; }
        public string CodigoColor { get => codigoColor; set => codigoColor = value; }
        public string DescripcionColor { get => descripcionColor; set => descripcionColor = value; }
        public int CodigoH1 { get => codigoH1; set => codigoH1 = value; }
        public string DescripcionH1 { get => descripcionH1; set => descripcionH1 = value; }
        public int CodigoH2 { get => codigoH2; set => codigoH2 = value; }
        public string DescripcionH2 { get => descripcionH2; set => descripcionH2 = value; }
        public int CodigoH3 { get => codigoH3; set => codigoH3 = value; }
        public string DescripcionH3 { get => descripcionH3; set => descripcionH3 = value; }
        public int CodigoH4 { get => codigoH4; set => codigoH4 = value; }
        public string DescripcionH4 { get => descripcionH4; set => descripcionH4 = value; }
        public int CodigoH5 { get => codigoH5; set => codigoH5 = value; }
        public string DescripcionH5 { get => descripcionH5; set => descripcionH5 = value; }
        public int Tiendas { get => tiendas; set => tiendas = value; }
        public int Exito { get => exito; set => exito = value; }
        public int Cencosud { get => cencosud; set => cencosud = value; }
        public int Sao { get => sao; set => sao = value; }
        public int ComercioOrg { get => comercioOrg; set => comercioOrg = value; }
        public int Rosado { get => rosado; set => rosado = value; }
        public int Otros { get => otros; set => otros = value; }
        public int TotalUnidades { get => totalUnidades; set => totalUnidades = value; }
        public decimal Consumo { get => consumo; set => consumo = value; }
        public decimal MCalculados { get => mCalculados; set => mCalculados = value; }
        public decimal MReservados { get => mReservados; set => mReservados = value; }
        public decimal MSolicitar { get => mSolicitar; set => mSolicitar = value; }
        public decimal KgCalculados { get => kgCalculados; set => kgCalculados = value; }
    }
}
