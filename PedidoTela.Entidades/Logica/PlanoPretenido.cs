using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class PlanoPretenido
    {
        private int id;
        private string identificador;
        private string referenciaTela;
        private string descripcionTela;
        private bool coordinado;
        private string coordinadoCon;
        private string observacion;
        private int idSolTela;
        private string tipoTejido;
     

        public PlanoPretenido() { }

        public PlanoPretenido(int id, string identificador, string referenciaTela, string descripcionTela, bool coordinado, string coordinadoCon, string observacion, int idSolTela, string tipoTejido)
        {
            this.Id = id;
            this.Identificador = identificador;
            this.ReferenciaTela = referenciaTela;
            this.DescripcionTela = descripcionTela;
            this.Coordinado = coordinado;
            this.CoordinadoCon = coordinadoCon;
            this.Observacion = observacion;
            this.IdSolTela = idSolTela;
            this.TipoTejido = tipoTejido;
        }

        public int Id { get => id; set => id = value; }
        public string Identificador { get => identificador; set => identificador = value; }
        public string ReferenciaTela { get => referenciaTela; set => referenciaTela = value; }
        public string DescripcionTela { get => descripcionTela; set => descripcionTela = value; }
        public bool Coordinado { get => coordinado; set => coordinado = value; }
        public string CoordinadoCon { get => coordinadoCon; set => coordinadoCon = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public int IdSolTela { get => idSolTela; set => idSolTela = value; }
        public string TipoTejido { get => tipoTejido; set => tipoTejido = value; }
    }
}
