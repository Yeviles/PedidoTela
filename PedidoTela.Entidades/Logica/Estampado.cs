using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class Estampado
    {
        //id serial not null,
        private string esayo_ref;
		private string referencia_tela;
		private string nombre_tela;
		private string tipo_estampado;
		private string tipo_tejido;
		private int n_dibujos;
		private int n_cilindros;
		private string coordinado_con;
		private bool coordinado;
        private string observaciones;

        public Estampado() { }

        public Estampado(string esayo_ref, string referencia_tela, string nombre_tela, string tipo_estampado, string tipo_tejido, int n_dibujos, int n_cilindors, string coordinado_con, bool coordinado, string observaciones)
        {
            this.Esayo_ref = esayo_ref;
            this.referencia_tela = referencia_tela;
            this.nombre_tela = nombre_tela;
            this.tipo_estampado = tipo_estampado;
            this.tipo_tejido = tipo_tejido;
            this.n_dibujos = n_dibujos;
            this.n_cilindros = n_cilindors;
            this.coordinado_con = coordinado_con;
            this.coordinado = coordinado;
            this.observaciones = observaciones;
        }

        public string Referencia_tela { get => referencia_tela; set => referencia_tela = value; }
        public string Nombre_tela { get => nombre_tela; set => nombre_tela = value; }
        public string Tipo_estampado { get => tipo_estampado; set => tipo_estampado = value; }
        public string Tipo_tejido { get => tipo_tejido; set => tipo_tejido = value; }
        public int N_dibujos { get => n_dibujos; set => n_dibujos = value; }
        public int N_cilindors { get => n_cilindros; set => n_cilindros = value; }
        public string Coordinado_con { get => coordinado_con; set => coordinado_con = value; }
        public bool Coordinado { get => coordinado; set => coordinado = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public string Esayo_ref { get => esayo_ref; set => esayo_ref = value; }
    }
}
