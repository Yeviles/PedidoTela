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
        private int xs;
        private int s;
        private int m;
        private int l;
        private int xl;
        private int dosxl;
        private int cuatro;
        private int seis;
        private int ocho;
        private int diez;
        private int doce;
        private int catorce;
        private int dieciseis;
        private int dieciocho;
        private int veinte;
        private int veintidos;
        private int veinticuatro;
        private string ancho;

        public DetalleCuelloUno() { }

        public DetalleCuelloUno(int idDetalleCuelloUno, int idCuellos, string codigo, int xs, int s, int m, int l, int xl, int dosxl, int cuatro, int seis, int ocho, int diez, int doce, int catorce, int dieciseis, int dieciocho, int veinte, int veintidos, int veinticuatro, string ancho)
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
        }

        public int IdDetalleCuelloUno { get => idDetalleCuelloUno; set => idDetalleCuelloUno = value; }
        public int IdCuellos { get => idCuellos; set => idCuellos = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public int Xs { get => xs; set => xs = value; }
        public int S { get => s; set => s = value; }
        public int M { get => m; set => m = value; }
        public int L { get => l; set => l = value; }
        public int Xl { get => xl; set => xl = value; }
        public int Dosxl { get => dosxl; set => dosxl = value; }
        public int Cuatro { get => cuatro; set => cuatro = value; }
        public int Seis { get => seis; set => seis = value; }
        public int Ocho { get => ocho; set => ocho = value; }
        public int Diez { get => diez; set => diez = value; }
        public int Doce { get => doce; set => doce = value; }
        public int Catorce { get => catorce; set => catorce = value; }
        public int Dieciseis { get => dieciseis; set => dieciseis = value; }
        public int Dieciocho { get => dieciocho; set => dieciocho = value; }
        public int Veinte { get => veinte; set => veinte = value; }
        public int Veintidos { get => veintidos; set => veintidos = value; }
        public int Veinticuatro { get => veinticuatro; set => veinticuatro = value; }
        public string Ancho { get => ancho; set => ancho = value; }
    }
}
