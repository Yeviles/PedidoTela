using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class Objeto
    {
        private string id;
        private string nombre;
        public Objeto()
        {

        }
        public Objeto(string prmId, string prmNombre)
        {
            Id = prmId;
            Nombre = prmNombre;
        }
        public Objeto(string prmId)
        {
            Id = prmId;
         
        }

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
