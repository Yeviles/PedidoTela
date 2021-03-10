using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class DetalleConsumo
    {
        private string ensayo_referencia;
        private string codi_prenda;
        private string desc_prenda;
        private string codigo_tela;
        private string descripcion_tela;
        private string tipo;
        private string consumo_est;
    
     
        public DetalleConsumo() { }

        public DetalleConsumo(string ensayo_referencia, string codi_prenda, string desc_prenda, string codigo_tela, string descripcion_tela, string tipo, string consumo_est)
        {
            this.Ensayo_referencia = ensayo_referencia;
            this.Codi_prenda = codi_prenda;
            this.Desc_prenda = desc_prenda;
            this.Codigo_tela = codigo_tela;
            this.Descripcion_tela = descripcion_tela;
            this.Tipo = tipo;
            this.Consumo_est = consumo_est;
        }

        public string Ensayo_referencia { get => ensayo_referencia; set => ensayo_referencia = value; }
        public string Codi_prenda { get => codi_prenda; set => codi_prenda = value; }
        public string Desc_prenda { get => desc_prenda; set => desc_prenda = value; }
        public string Codigo_tela { get => codigo_tela; set => codigo_tela = value; }
        public string Descripcion_tela { get => descripcion_tela; set => descripcion_tela = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Consumo_est { get => consumo_est; set => consumo_est = value; }
    }
}
