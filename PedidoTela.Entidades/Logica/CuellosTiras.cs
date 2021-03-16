using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class CuellosTiras
    {
        private int idCuellos;
        private string identificador;
        private bool cuellos;
        private bool punos;
        private bool tiras;
        private bool coordinado;
        private string coordinadoCon;
        private string observacion;



        public CuellosTiras() { }

        public CuellosTiras(int idCuellos, string identificador, bool cuellos, bool punos, bool tiras, bool coordinado, string coordinadoCon, string observacion)
        {
            this.IdCuellos = idCuellos;
            this.Identificador = identificador;
            this.Cuellos = cuellos;
            this.Punos = punos;
            this.Tiras = tiras;
            this.Coordinado = coordinado;
            this.CoordinadoCon = coordinadoCon;
            this.Observacion = observacion;
        
        }

        public int IdCuellos { get => idCuellos; set => idCuellos = value; }
        public string Identificador { get => identificador; set => identificador = value; }
        public bool Cuellos { get => cuellos; set => cuellos = value; }
        public bool Punos { get => punos; set => punos = value; }
        public bool Tiras { get => tiras; set => tiras = value; }
        public bool Coordinado { get => coordinado; set => coordinado = value; }
        public string CoordinadoCon { get => coordinadoCon; set => coordinadoCon = value; }
        public string Observacion { get => observacion; set => observacion = value; }
    
    }
}
