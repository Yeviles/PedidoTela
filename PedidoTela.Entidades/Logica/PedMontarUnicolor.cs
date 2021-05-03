﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class PedMontarUnicolor
    {
        private int idPedUnicolor;
        private string nomTela;
        private string disenador;
        private string ensayoRef;
        private string descPrenda;
        private string clase;
        private string tipoMarcacion;
        private decimal rendimiento;
        private string analistasCortesB;
        private string fechaLlegada;
        private int idSolTela;

        public PedMontarUnicolor() { }
        public PedMontarUnicolor(string nomTela, string disenador, string ensayoRef, string descPrenda, string clase, string tipoMarcacion, decimal rendimiento, string analistasCortesB, string fechaLlegada, int idPedUnicolor = 0, int idSolTela = 0)
        {
            this.NomTela = nomTela;
            this.Disenador = disenador;
            this.EnsayoRef = ensayoRef;
            this.DescPrenda = descPrenda;
            this.Clase = clase;
            this.TipoMarcacion = tipoMarcacion;
            this.Rendimiento = rendimiento;
            this.AnalistasCortesB = analistasCortesB;
            this.FechaLlegada = fechaLlegada;
            this.IdPedUnicolor = idPedUnicolor;
            this.IdSolTela = idSolTela;
        }

        public string NomTela { get => nomTela; set => nomTela = value; }
        public string Disenador { get => disenador; set => disenador = value; }
        public string EnsayoRef { get => ensayoRef; set => ensayoRef = value; }
        public string DescPrenda { get => descPrenda; set => descPrenda = value; }
        public string Clase { get => clase; set => clase = value; }
        public string TipoMarcacion { get => tipoMarcacion; set => tipoMarcacion = value; }
        public decimal Rendimiento { get => rendimiento; set => rendimiento = value; }
        public string AnalistasCortesB { get => analistasCortesB; set => analistasCortesB = value; }
        public string FechaLlegada { get => fechaLlegada; set => fechaLlegada = value; }
        public int IdPedUnicolor { get => idPedUnicolor; set => idPedUnicolor = value; }
        public int IdSolTela { get => idSolTela; set => idSolTela = value; }
    }
}
