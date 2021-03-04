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
        private int idEnsayo;
        private string referenciaTela;
        private string descripcionTela;
        private string tipoTejido;
        private bool coordinado;
        private string coordinadoCon;
        private string observaciones;

        public Unicolor() { }

        public Unicolor(int id, int idEnsayo, string referenciaTela, string descripcionTela, string tipoTejido, bool coordinado, string coordinadoCon, string observaciones)
        {
            this.Id = id;
            this.IdEnsayo = idEnsayo;
            this.ReferenciaTela = referenciaTela;
            this.DescripcionTela = descripcionTela;
            this.TipoTejido = tipoTejido;
            this.Coordinado = coordinado;
            this.CoordinadoCon = coordinadoCon;
            this.Observaciones = observaciones;
        }

        public int Id { get => id; set => id = value; }
        public int IdEnsayo { get => idEnsayo; set => idEnsayo = value; }
        public string ReferenciaTela { get => referenciaTela; set => referenciaTela = value; }
        public string DescripcionTela { get => descripcionTela; set => descripcionTela = value; }
        public string TipoTejido { get => tipoTejido; set => tipoTejido = value; }
        public bool Coordinado { get => coordinado; set => coordinado = value; }
        public string CoordinadoCon { get => coordinadoCon; set => coordinadoCon = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
    }
}
