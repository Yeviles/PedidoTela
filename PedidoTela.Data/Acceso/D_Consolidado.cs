using IBM.Data.Informix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_Consolidado
    {
        #region Consulas
        private readonly string actuConsolidado = "UPDATE cfc_spt_tipo_solicitud SET consolidado=? WHERE id_solicitud=?; ";

        private readonly string conMaxConsolidado = "select max(consolidado) as max_Consolidado from  cfc_spt_tipo_solicitud;";

        #endregion

        #region Métodos de Actualización

        public string ActualizarConsolidado(int prmIdsolicitud, int prmConsolidado)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@consolidado", prmConsolidado));
                    con.Parametros.Add(new IfxParameter("@id_solicitud ", prmIdsolicitud));

                    var datos = con.EjecutarConsulta(this.actuConsolidado);
                    con.cerrarConexion();
                }
                respuesta = "ok";
            }
            catch (Exception ex)
            {
                respuesta = "Error: " + ex.Message;
            }
            return respuesta;
        }

        #endregion

        #region Métodos de Consulta
        /// <summary>
        /// Permite consultar el número máximo para el campo consolidado en la entidad  cfc_spt_tipo_solicitud,
        /// </summary>
        /// <returns>Retorna el número máximo encontrado</returns>
        public int ConsultarMaxConsolidado()
        {
            int max = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    var datos = conexion.EjecutarConsulta(conMaxConsolidado);
                    datos.Read();
                    //max = int.Parse(datos.ToString().Trim());
                    max = int.Parse(datos["max_Consolidado"].ToString());
                    conexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return max;
        }
        #endregion
    }
}
