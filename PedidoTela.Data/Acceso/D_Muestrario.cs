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
        //private readonly string consultar= "SELECT nmro_mstrrio,trim(desc_mstrrio) as desc_mstrrio FROM m_muestrario WHERE estdo=1;";
        private readonly string consultar= "select distinct (m.nmro_mstrrio), m.desc_mstrrio from cfc_spt_sol_tela st "+
                                            "left join m_muestrario m on st.muestrario =  m.nmro_mstrrio;";
        
        public List<Objeto> consultarMuestrario()
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var administrar = new clsConexion())
            {
                var datos = administrar.EjecutarConsulta(consultar);
                while (datos.Read())
                {
                    Objeto muestrario = new Objeto();
                    muestrario.Id = datos["desc_mstrrio"].ToString().Trim();
                    muestrario.Nombre = datos["nmro_mstrrio"].ToString().Trim();
                    respuesta.Add(muestrario);
                }

            }

                return respuesta;
        }
    }
    
}
