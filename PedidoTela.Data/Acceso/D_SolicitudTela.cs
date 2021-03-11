using IBM.Data.Informix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_SolicitudTela
    {
        #region Consultas
        private readonly string consultaIdSolicitud = "select idsolicitud from cfc_spt_sol_tela where identificador = ?;";

        #endregion
        public int consultarIdSolicitud(string prmIdentificador)
        {
            int id = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    conexion.Parametros.Add(new IfxParameter("@identificador", prmIdentificador));
                    var datos = conexion.EjecutarConsulta(consultaIdSolicitud);
                    datos.Read();
                    id = int.Parse(datos["idsolicitud"].ToString());
                    conexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return id;
        }
    }
}
