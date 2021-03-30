using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades
{
    public class AnalizarInventario
    {
        private string ensayo;
        private string similar;
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
        private string consumo;
        private string mCalculados;
        private string mReservados;
        private string maSolicitar;

        public AnalizarInventario() { }
        public AnalizarInventario(string ensayo, string similar, string codColor, string desColor, int tiendas, int exito, int cencosud, int sao, int comercioOrg, int rosado, int otros, string consumo, string mCalculados, string mReservados, string maSolicitar, int totalUnidades)
        {
            this.Ensayo = ensayo;
            this.Similar = similar;
            this.CodColor = codColor;
            this.DesColor = desColor;
            this.Tiendas = tiendas;
            this.Exito = exito;
            this.Cencosud = cencosud;
            this.Sao = sao;
            this.ComercioOrg = comercioOrg;
            this.Rosado = rosado;
            this.Otros = otros;
            this.Consumo = consumo;
            this.MCalculados = mCalculados;
            this.MReservados = mReservados;
            this.MaSolicitar = maSolicitar;
            this.TotalUnidades = totalUnidades;
        }

        public string Ensayo { get => ensayo; set => ensayo = value; }
        public string Similar { get => similar; set => similar = value; }
        public string CodColor { get => codColor; set => codColor = value; }
        public string DesColor { get => desColor; set => desColor = value; }
        public int Tiendas { get => tiendas; set => tiendas = value; }
        public int Exito { get => exito; set => exito = value; }
        public int Cencosud { get => cencosud; set => cencosud = value; }
        public int Sao { get => sao; set => sao = value; }
        public int ComercioOrg { get => comercioOrg; set => comercioOrg = value; }
        public int Rosado { get => rosado; set => rosado = value; }
        public int Otros { get => otros; set => otros = value; }
        public string Consumo { get => consumo; set => consumo = value; }
        public string MCalculados { get => mCalculados; set => mCalculados = value; }
        public string MReservados { get => mReservados; set => mReservados = value; }
        public string MaSolicitar { get => maSolicitar; set => maSolicitar = value; }
        public int TotalUnidades { get => totalUnidades; set => totalUnidades = value; }
    }
}
