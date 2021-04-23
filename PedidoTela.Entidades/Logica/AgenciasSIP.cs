using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class AgenciasSIP
    {
        private string color;
        private string mCalculados;
        private string kgCalculados;

        public string Color { get => color; set => color = value; }
        public string MCalculados { get => mCalculados; set => mCalculados = value; }
        public string KgCalculados { get => kgCalculados; set => kgCalculados = value; }
    }
}
