using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_Muestrario
    {
        private readonly string consultar= "SELECT nmro_mstrrio,trim(desc_mstrrio) as desc_mstrrio FROM m_muestrario WHERE estdo=1;";
        
        public List<Objeto> consultarMuestrario()
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var administrar = new clsConexion())
            {
                var datos = administrar.EjecutarConsulta(consultar);
                while (datos.Read())
                {
                    Objeto muestrario = new Objeto();
                    muestrario.Id = datos["nmro_mstrrio"].ToString().Trim();
                    muestrario.Nombre = datos["desc_mstrrio"].ToString().Trim();
                    respuesta.Add(muestrario);
                }

            }

                return respuesta;
        }
    }
    
}
