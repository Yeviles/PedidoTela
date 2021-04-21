using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_Composicion
    {
        #region Consultas
        private readonly string consultarComposicion = "  select  trim(codi_compo) as codi_compo, trim(desc_compo1) ||  CASE WHEN desc_compo2 is NULL THEN '' ELSE ' ' || trim(desc_compo2)END as descripcion " +
                                                        " from inmcompo "+
                                                        " where estado = 'A'";
        #endregion
        public List<Objeto> getComposicion()
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var administracionConexion = new clsConexion())
            {
                var datosDataReader = administracionConexion.EjecutarConsulta(consultarComposicion);
                while (datosDataReader.Read())
                {
                    Objeto objComposicion = new Objeto();
                    objComposicion.Id = datosDataReader["codi_compo"].ToString().Trim();
                    objComposicion.Nombre = datosDataReader["descripcion"].ToString().Trim();
                    respuesta.Add(objComposicion);
                };
                administracionConexion.cerrarConexion();
            }
            return respuesta;
        }
    }
}
