using System;
using System.Collections.Generic;
using PedidoTela.Entidades.Logica;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_TipoPedido
    {
        #region Consultas
        private readonly string consulta1 = "select tipo, descripcion from cfc_m_tipo_pedido";
        //private readonly string consulta2 = " select  distinct (tipo) from cfc_spt_tipo_solicitud;";
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

        #endregion
    }
}
