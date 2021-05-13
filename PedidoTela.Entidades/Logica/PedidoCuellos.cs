using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class PedidoCuellos
    {

        private int idPedidoCuellos;
        private string codigo;
        private string codigoVte;
        private string descripcionVte;
        private decimal xs;
        private decimal s;
        private decimal m;
        private decimal l;
        private decimal xl;
        private decimal dosxl;
        private decimal cuatro;
        private decimal seis;
        private decimal ocho;
        private decimal diez;
        private decimal doce;
        private decimal catorce;
        private decimal dieciseis;
        private decimal dieciocho;
        private decimal veinte;
        private decimal veintidos;
        private decimal veinticuatro;
        private decimal ancho;
        private decimal tipoTejido;
        private int totalUnidades;

        public PedidoCuellos() { }

        public PedidoCuellos(string codigoVte, string descripcionVte)
        {
            this.CodigoVte = codigoVte;
            this.DescripcionVte = descripcionVte;
        }

        public PedidoCuellos(int idPedidoCuellos, string codigo, string codigoVte, string descripcionVte, decimal xs, decimal s, decimal m, decimal l, decimal xl, decimal dosxl, decimal cuatro, decimal seis, decimal ocho, decimal diez, decimal doce, decimal catorce, decimal dieciseis, decimal dieciocho, decimal veinte, decimal veintidos, decimal veinticuatro, decimal ancho, decimal tipoTejido, int totalUnidades)
        {
            this.IdPedidoCuellos = idPedidoCuellos;
            this.codigo = codigo;
            this.codigoVte = codigoVte;
            this.descripcionVte = descripcionVte;
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
            this.totalUnidades = totalUnidades;
        }

        public string Codigo { get => codigo; set => codigo = value; }
        public string CodigoVte { get => codigoVte; set => codigoVte = value; }
        public string DescripcionVte { get => descripcionVte; set => descripcionVte = value; }
        public decimal Xs { get => xs; set => xs = value; }
        public decimal S { get => s; set => s = value; }
        public decimal M { get => m; set => m = value; }
        public decimal L { get => l; set => l = value; }
        public decimal Xl { get => xl; set => xl = value; }
        public decimal Dosxl { get => dosxl; set => dosxl = value; }
        public decimal Cuatro { get => cuatro; set => cuatro = value; }
        public decimal Seis { get => seis; set => seis = value; }
        public decimal Ocho { get => ocho; set => ocho = value; }
        public decimal Diez { get => diez; set => diez = value; }
        public decimal Doce { get => doce; set => doce = value; }
        public decimal Catorce { get => catorce; set => catorce = value; }
        public decimal Dieciseis { get => dieciseis; set => dieciseis = value; }
        public decimal Dieciocho { get => dieciocho; set => dieciocho = value; }
        public decimal Veinte { get => veinte; set => veinte = value; }
        public decimal Veintidos { get => veintidos; set => veintidos = value; }
        public decimal Veinticuatro { get => veinticuatro; set => veinticuatro = value; }
        public decimal Ancho { get => ancho; set => ancho = value; }
        public decimal TipoTejido { get => tipoTejido; set => tipoTejido = value; }
        public int TotalUnidades { get => totalUnidades; set => totalUnidades = value; }
        public int IdPedidoCuellos { get => idPedidoCuellos; set => idPedidoCuellos = value; }
    }
}
