using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_OcasionUso
    {
        //private readonly string consultar = "SELECT em.idmundo, em.desc_mundo " +
        //  "FROM cfc_e_mundo em INNER JOIN cfc_m_mundo mm ON em.idmundo=mm.idmundo " +
        //  "INNER JOIN cfc_m_claseprod mc ON mm.codi_claseprod = mc.codi_claseprod " +
        //  "WHERE em.activo='t' AND mm.activo='t';";
        private readonly string consultar = "select distinct (mu.desc_mundo), mu.idmundo  from cfc_spt_sol_tela st " +
                                            "left join cfc_e_mundo mu on st.idmundo = mu.idmundo; ";

        public List<Objeto> consultarOcasionUso()
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var administracionConexion = new clsConexion())
            {
                var datosDataReader = administracionConexion.EjecutarConsulta(consultar);
                while (datosDataReader.Read())
                {
                    Objeto ocasionUso = new Objeto();
                    ocasionUso.Id = datosDataReader["idmundo"].ToString().Trim();
                    ocasionUso.Nombre = datosDataReader["desc_mundo"].ToString().Trim();
                    respuesta.Add(ocasionUso);
                };
                administracionConexion.cerrarConexion();
            }
            return respuesta;
        }
    }
}
