using System;
using System.Collections.Generic;
using PedidoTela.Entidades.Logica;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBM.Data.Informix;

namespace PedidoTela.Data.Acceso
{
    public class D_TipoPedido
    {
        #region Consultas
        private readonly string consulta1 = "select tipo, descripcion from cfc_m_tipo_pedido";
        //private readonly string consulta2 = " select  distinct (tipo) from cfc_spt_tipo_solicitud;";
        private readonly string consultaIdsolicitud = "SELECT id_solicitud FROM cfc_spt_tipo_solicitud WHERE tipo_pedido = ? AND consecutivo_pedido = ?;";


        #endregion
        #region Métodos
        public List<TipoPedido> ConsultarTipoTejido()
        {
            List<TipoPedido> respuesta = new List<TipoPedido>();
            using (var administrador = new clsConexion())
            {
                var datos = administrador.EjecutarConsulta(consulta1);
                while (datos.Read())
                {
                    TipoPedido objTipoTejido = new TipoPedido();
                    objTipoTejido.Tipo = datos["tipo"].ToString().Trim();
                    objTipoTejido.Descripcion = datos["descripcion"].ToString().Trim();

                    respuesta.Add(objTipoTejido);
                };
                administrador.cerrarConexion();
            }
            return respuesta;

        }
        
        public List<Objeto> ConsultarTipoSolicitud()
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var administrador = new clsConexion())
            {
                var datos = administrador.EjecutarConsulta(consulta1);
                while (datos.Read())
                {
                    Objeto objTipoTejido = new Objeto();
                    objTipoTejido.Id = datos["tipo"].ToString().Trim();
                    objTipoTejido.Nombre = datos["descripcion"].ToString().Trim();

                    respuesta.Add(objTipoTejido);
                };
                administrador.cerrarConexion();
            }
            return respuesta;

        }

        public int consultarIdSolicitud(int prmConsecutivo, string prmTipoPedido)
        {
            int id = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    conexion.Parametros.Add(new IfxParameter("@tipo_pedido", prmTipoPedido));
                    conexion.Parametros.Add(new IfxParameter("@consecutivo_pedido", prmConsecutivo));
                    var datos = conexion.EjecutarConsulta(consultaIdsolicitud);
                    datos.Read();
                    id = int.Parse(datos["id_solicitud"].ToString());

                    conexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return id;
        }

        #endregion
    }
}
