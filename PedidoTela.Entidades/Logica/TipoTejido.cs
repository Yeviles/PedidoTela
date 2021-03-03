using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class TipoTejido
    {
        private string codigoTela;
        private string nombreTela;
        private string idTipoTela;
        private string nombreTipoTela;

        public TipoTejido(){}

        public string CodigoTela { get => codigoTela; set => codigoTela = value; }
        public string NombreTela { get => nombreTela; set => nombreTela = value; }
        public string IdTipoTela { get => idTipoTela; set => idTipoTela = value; }
        public string NombreTipoTela { get => nombreTipoTela; set => nombreTipoTela = value; }
    }
}
