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

        #endregion
    }
}
