using IBM.Data.Informix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
   public class D_Devolucion
    {
        #region Consultas
        private readonly string consultarDevolucion = "SELECT motivo_devolucion FROM cfc_spt_tipo_solicitud WHERE estado = 'Devolucion' AND consecutivo_pedido = ?; ";
        private readonly string consultarConsecutivo = "SELECT id_tipo_sol FROM cfc_spt_tipo_solicitud WHERE estado = 'Radicado' AND consecutivo_pedido = ?; ";
        private readonly string actualizarConsecutivo = "UPDATE cfc_spt_tipo_solicitud SET fecha_estado = ?, estado=?, motivo_devolucion=? WHERE consecutivo_pedido = ?; ";
        #endregion

        #region Métodos Consulta
        public bool existeConsecutivo(int prmConsecutivo)
        {
            int idTipoSolicitud;
            using (var administrador = new clsConexion())
            {
                try
                {
                    administrador.Parametros.Add(new IfxParameter("@consecutivo_pedido", prmConsecutivo));
                    var datos = administrador.EjecutarConsulta(consultarConsecutivo);
                    datos.Read();
                    idTipoSolicitud = int.Parse(datos["id_tipo_sol"].ToString().Trim());
                    administrador.cerrarConexion();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public string existeDevolucion(int prmConsecutivo)
        {
            string motivoDevolucion = "", respuesta ="";
            using (var administrador = new clsConexion())
            {
                try
                {
                    administrador.Parametros.Add(new IfxParameter("@consecutivo_pedido", prmConsecutivo));
                    var datos = administrador.EjecutarConsulta(consultarDevolucion);
                    datos.Read();
                    motivoDevolucion = datos["motivo_devolucion"].ToString().Trim();

                    administrador.cerrarConexion();
           
                }
                catch (Exception ex)
                {
                    respuesta = "Error: " + ex.Message;
                }
                return motivoDevolucion;
            }
        }
        #endregion

        #region Métodos Actualizar
        public string ActualizarConsecutivo( int prmConsecutivo, string prmFecha, string prmEstado, string prmMotivoDevolucion)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@fecha_estado", prmFecha));
                    con.Parametros.Add(new IfxParameter("@estado", prmEstado));
                    con.Parametros.Add(new IfxParameter("@motivo_devolucion", prmMotivoDevolucion));

                    con.Parametros.Add(new IfxParameter("@consecutivo_pedido", prmConsecutivo));
                    var datos = con.EjecutarConsulta(this.actualizarConsecutivo);
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
    }
}
