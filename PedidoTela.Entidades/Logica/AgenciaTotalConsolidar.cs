using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class AgenciaTotalConsolidar
    {
        private int idAgencias;
        private string codColor;
        private string desColor;
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
        private decimal totalaPedir;
        private string uniMedidaTela;

        public AgenciaTotalConsolidar() { }
        public AgenciaTotalConsolidar(string codColor, string desColor, int tiendas, int exito, int cencosud, int sao, int comercioOrg, int rosado, int otros, int totalUnidades, decimal mCalculados, decimal kgCalculados, decimal totalaPedir, string uniMedidaTela, int idAgencias )
        {
            this.CodColor = codColor;
            this.DesColor = desColor;
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
            this.TotalaPedir = totalaPedir;
            this.UniMedidaTela = uniMedidaTela;
            this.idAgencias = idAgencias;
        }

        public string CodColor { get => codColor; set => codColor = value; }
        public string DesColor { get => desColor; set => desColor = value; }
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
        public decimal TotalaPedir { get => totalaPedir; set => totalaPedir = value; }
        public string UniMedidaTela { get => uniMedidaTela; set => uniMedidaTela = value; }
        public int IdAgencias { get => idAgencias; set => idAgencias = value; }
    }
}
