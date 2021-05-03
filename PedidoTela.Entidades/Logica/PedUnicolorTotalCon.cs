using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class PedUnicolorTotalCon
    {
        private int idPedUnicolor;
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
        private decimal mCalculados;
        private decimal kgCalculados;
        private decimal totalPedir;
        private string uniMedida;

        public PedUnicolorTotalCon() { }

        public PedUnicolorTotalCon(string codColor, string descColor, int tiendas, int exito, int cencosud, int sao, int comercioOrg, int rosado, int otros, int totalUnidades, decimal mCalculados, decimal kgCalculados, decimal totalPedir, string uniMedida, int idPedUnicolor)
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
            this.MCalculados = mCalculados;
            this.KgCalculados = kgCalculados;
            this.TotalPedir = totalPedir;
            this.UniMedida = uniMedida;
            this.IdPedUnicolor = idPedUnicolor;
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
        public decimal MCalculados { get => mCalculados; set => mCalculados = value; }
        public decimal KgCalculados { get => kgCalculados; set => kgCalculados = value; }
        public decimal TotalPedir { get => totalPedir; set => totalPedir = value; }
        public string UniMedida { get => uniMedida; set => uniMedida = value; }
        public int IdPedUnicolor { get => idPedUnicolor; set => idPedUnicolor = value; }
    }
}
