using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class PedidoCuellos
    {
        private int idCuellos;
        private string codigo;
        private string xs;
        private string s;
        private string m;
        private string l;
        private string xl;
        private string dosxl;
        private string cuatro;
        private string seis;
        private string ocho;
        private string diez;
        private string doce;
        private string catorce;
        private string dieciseis;
        private string dieciocho;
        private string veinte;
        private string veintidos;
        private string veinticuatro;
        private string ancho;
        private string tipoTejido;

        public PedidoCuellos() { }

        public PedidoCuellos(int idCuellos, string codigo, string xs, string s, string m, string l, string xl, string dosxl, string cuatro, string seis, string ocho, string diez, string doce, string catorce, string dieciseis, string dieciocho, string veinte, string veintidos, string veinticuatro, string ancho, string tipoTejido)
        {
            this.idCuellos = idCuellos;
            this.codigo = codigo;
            this.xs = xs;
            this.s = s;
            this.m = m;
            this.l = l;
            this.xl = xl;
            this.dosxl = dosxl;
            this.cuatro = cuatro;
            this.seis = seis;
            this.ocho = ocho;
            this.diez = diez;
            this.doce = doce;
            this.catorce = catorce;
            this.dieciseis = dieciseis;
            this.dieciocho = dieciocho;
            this.veinte = veinte;
            this.veintidos = veintidos;
            this.veinticuatro = veinticuatro;
            this.ancho = ancho;
            this.tipoTejido = tipoTejido;
        }

        public int IdCuellos { get => idCuellos; set => idCuellos = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Xs { get => xs; set => xs = value; }
        public string S { get => s; set => s = value; }
        public string M { get => m; set => m = value; }
        public string L { get => l; set => l = value; }
        public string Xl { get => xl; set => xl = value; }
        public string Dosxl { get => dosxl; set => dosxl = value; }
        public string Cuatro { get => cuatro; set => cuatro = value; }
        public string Seis { get => seis; set => seis = value; }
        public string Ocho { get => ocho; set => ocho = value; }
        public string Diez { get => diez; set => diez = value; }
        public string Doce { get => doce; set => doce = value; }
        public string Catorce { get => catorce; set => catorce = value; }
        public string Dieciseis { get => dieciseis; set => dieciseis = value; }
        public string Dieciocho { get => dieciocho; set => dieciocho = value; }
        public string Veinte { get => veinte; set => veinte = value; }
        public string Veintidos { get => veintidos; set => veintidos = value; }
        public string Veinticuatro { get => veinticuatro; set => veinticuatro = value; }
        public string Ancho { get => ancho; set => ancho = value; }
        public string TipoTejido { get => tipoTejido; set => tipoTejido = value; }
    }
}
