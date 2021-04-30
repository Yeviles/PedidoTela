using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class InfoConPedUnicolor
    {
        private string codColor;
        private string descColor;
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
        private decimal mSolicitar;
        private decimal kgCalculados;

        public InfoConPedUnicolor(string codColor, string descColor, int tiendas, int exito, int cencosud, int sao, int comercioOrg, int rosado, int otros, int totalUnidades, decimal consumo, decimal mCalculados, decimal mSolicitar, decimal kgCalculados)
        {
            this.CodColor = codColor;
            this.DescColor = descColor;
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
            this.MSolicitar = mSolicitar;
            this.KgCalculados = kgCalculados;
        }

        public string CodColor { get => codColor; set => codColor = value; }
        public string DescColor { get => descColor; set => descColor = value; }
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
        public decimal MSolicitar { get => mSolicitar; set => mSolicitar = value; }
        public decimal KgCalculados { get => kgCalculados; set => kgCalculados = value; }
    }
}
