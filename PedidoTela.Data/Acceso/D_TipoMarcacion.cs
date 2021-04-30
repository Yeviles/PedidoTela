using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_TipoMarcacion
    {
        #region Consultas
        private readonly string consultarAll = "SELECT id_marcacion, desc_marcacion FROM cfc_m_marcacion WHERE activo='T';";
        #endregion

        public List<Objeto> consultar()
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var con = new clsConexion())
            {
                var datosDataReader = con.EjecutarConsulta(consultarAll);
                while (datosDataReader.Read())
                {
                    Objeto obj = new Objeto();
                    obj.Id = datosDataReader["id_marcacion"].ToString();
                    obj.Nombre = datosDataReader["desc_marcacion"].ToString();
                    respuesta.Add(obj);
                };
                con.cerrarConexion();
            }
            return respuesta;
        }
    }
}
