using IBM.Data.Informix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_Editar
    {
        #region Consultas
        private readonly string consultarConsecutivo = "SELECT id_tipo_sol FROM cfc_spt_tipo_solicitud WHERE  consecutivo_pedido = ?; ";
        
        private readonly string consultaTipoPedido = "SELECT tipo_pedido FROM cfc_spt_tipo_solicitud WHERE consecutivo_pedido= ?;";
        
        private readonly string consultaEstado = "SELECT estado FROM cfc_spt_tipo_solicitud WHERE estado = 'Devolucion' AND consecutivo_pedido = ?;";
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
       
        public bool consultarEstado(int prmConsecutivo)
        {
            string estado = "";
            using (var administrador = new clsConexion())
            {
                try
                {
                    administrador.Parametros.Add(new IfxParameter("@consecutivo_pedido", prmConsecutivo));
                    var datos = administrador.EjecutarConsulta(consultaEstado);
                    datos.Read();
                    estado = datos["estado"].ToString().Trim();
                    administrador.cerrarConexion();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public string consultarTipoPedido(int prmConsecutivo)
        {
            string tipoPedido = "", respuesta = "";
            using (var administrador = new clsConexion())
            {
                try
                {
                    administrador.Parametros.Add(new IfxParameter("@consecutivo_pedido", prmConsecutivo));
                    var datos = administrador.EjecutarConsulta(consultaTipoPedido);
                    datos.Read();
                    tipoPedido = datos["tipo_pedido"].ToString().Trim();

                    administrador.cerrarConexion();

                }
                catch (Exception ex)
                {
                    respuesta = "Error: " + ex.Message;
                }
                return tipoPedido;
            }
        }
        #endregion
    }
}
