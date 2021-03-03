using System;
using System.Collections.Generic;
using PedidoTela.Entidades.Logica;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_TipoTejido
    {
        #region Consultas
        private readonly string consulta1 = "select tipo, descripcion from cfc_m_tipo_pedido";

        #endregion
        #region Métodos
        public List<TipoTejido> ConsultarTipoTejido()
        {
            List<TipoTejido> respuesta = new List<TipoTejido>();
            using (var administrador = new clsConexion())
            {
                var datos = administrador.EjecutarConsulta(consulta1);
                while (datos.Read())
                {
                    TipoTejido objTipoTejido = new TipoTejido();
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
