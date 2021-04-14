using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class Unicolor
    {
        private int id;
        private string identificador;
        private string referenciaTela;
        private string descripcionTela;
        private string tipoTejido;
        private bool coordinado;
        private string coordinadoCon;
        private string observacion;
        private int idSolicitudTela;



        public Unicolor() { }

        public Unicolor(int id, string identificador, string referenciaTela, string descripcionTela, string tipoTejido, bool coordinado, string coordinadoCon, string observaciones, int idSolicitudTela = 0)
        {
            this.Id = id;
            this.Identificador = identificador;
            this.ReferenciaTela = referenciaTela;
            this.DescripcionTela = descripcionTela;
            this.TipoTejido = tipoTejido;
            this.Coordinado = coordinado;
            this.CoordinadoCon = coordinadoCon;
            this.Observacion = observaciones;
            this.IdSolicitudTela = idSolicitudTela;
        }

        public int Id { get => id; set => id = value; }
        public string Identificador { get => identificador; set => identificador = value; }
        public string ReferenciaTela { get => referenciaTela; set => referenciaTela = value; }
        public string DescripcionTela { get => descripcionTela; set => descripcionTela = value; }
        public string TipoTejido { get => tipoTejido; set => tipoTejido = value; }
        public bool Coordinado { get => coordinado; set => coordinado = value; }
        public string CoordinadoCon { get => coordinadoCon; set => coordinadoCon = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int IdSolicitudTela { get => idSolicitudTela; set => idSolicitudTela = value; }
    }
}
