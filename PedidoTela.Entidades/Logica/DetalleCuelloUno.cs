using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class DetalleCuelloUno
    {
        private int idDetalleCuelloUno;
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
        private string nombreChechSel;

        public DetalleCuelloUno() { }

        public DetalleCuelloUno(int idDetalleCuelloUno, int idCuellos, string codigo, string xs, string s, string m, string l, string xl, string dosxl, string cuatro, string seis, string ocho, string diez, string doce, string catorce, string dieciseis, string dieciocho, string veinte, string veintidos, string veinticuatro, string ancho, string nombreChechSel)
        {
            this.IdDetalleCuelloUno = idDetalleCuelloUno;
            this.IdCuellos = idCuellos;
            this.Codigo = codigo;
            this.Xs = xs;
            this.S = s;
            this.M = m;
            this.L = l;
            this.Xl = xl;
            this.Dosxl = dosxl;
            this.Cuatro = cuatro;
            this.Seis = seis;
            this.Ocho = ocho;
            this.Diez = diez;
            this.Doce = doce;
            this.Catorce = catorce;
            this.Dieciseis = dieciseis;
            this.Dieciocho = dieciocho;
            this.Veinte = veinte;
            this.Veintidos = veintidos;
            this.Veinticuatro = veinticuatro;
            this.Ancho = ancho;
            this.NombreChechSel = nombreChechSel;
        }

        public int IdDetalleCuelloUno { get => idDetalleCuelloUno; set => idDetalleCuelloUno = value; }
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
        public string NombreChechSel { get => nombreChechSel; set => nombreChechSel = value; }
    }
}
