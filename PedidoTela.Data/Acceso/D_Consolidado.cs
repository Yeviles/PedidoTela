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
        private readonly string agregarConsecutivo = "UPDATE cfc_spt_tipo_solicitud SET consecutivo_pedido=?, fecha_estado=?, estado =? WHERE id_solicitud=?; ";

        private readonly string actualizarConsolidado = "UPDATE cfc_spt_tipo_solicitud SET consecutivo_consolidado=?, tipo_pedido=? WHERE id_solicitud=?; ";

        private readonly string conMaxConsolidado = "select max(consecutivo_consolidado) as max_Consolidado from  cfc_spt_tipo_solicitud;";

        private readonly string consConsecutivoPedido = "select consecutivo_pedido FROM cfc_spt_tipo_solicitud where id_solicitud = ?;";

        private readonly string consultaMaxPedido = "select max(consecutivo_pedido) as max from  cfc_spt_tipo_solicitud;";

        #endregion

        #region Métodos de Actualización

        public string AgregarConsecutivo(int prmIdsolicitud, int prmConsecutivo, string prmFecha, string prmEstado)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@consecutivo_pedido", prmConsecutivo));
                    con.Parametros.Add(new IfxParameter("@fecha_estado", prmFecha));
                    con.Parametros.Add(new IfxParameter("@estado", prmEstado));
                    con.Parametros.Add(new IfxParameter("@id_solicitud", prmIdsolicitud));

                    var datos = con.EjecutarConsulta(this.agregarConsecutivo);
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
       
        public string ActualizarConsolidado(int prmIdsolicitud, int prmConsolidado, string prmTipoPedido)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@consecutivo_consolidado", prmConsolidado));
                    con.Parametros.Add(new IfxParameter("@tipo_pedido", prmTipoPedido));
                    con.Parametros.Add(new IfxParameter("@id_solicitud", prmIdsolicitud));

                    var datos = con.EjecutarConsulta(this.actualizarConsolidado);
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

        public int consultarConsecutivoPedido(int prmIdSolicitud)
        {
            int id = 0;
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_solicitud", prmIdSolicitud));
                    var datos = con.EjecutarConsulta(consConsecutivoPedido);
                    datos.Read();
                    id = int.Parse(datos["consecutivo_pedido"].ToString());
                    con.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return id;
        }
        
        public int consultarMaxconsecutivo()
        {
            int max = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    var datos = conexion.EjecutarConsulta(consultaMaxPedido);
                    datos.Read();
                    //max = int.Parse(datos.ToString().Trim());
                    max = int.Parse(datos["max"].ToString());
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
