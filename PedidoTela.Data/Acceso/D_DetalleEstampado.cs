using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_DetalleEstampado
    {
        #region Consultas
        private readonly string consultaInserDetalle = "INSERT INTO cfc_spt_sol_detalleEstampado (idDetalleEst,codigoColor,desc_color,tiendas,exito,cencosud,sao,comercio,rosado,total, idEstampado) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";
        #endregion
        #region Métodos

        public string Agregar(DetalleEstampado elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                     
                    
                    con.Parametros.Add(new IfxParameter("@codigo_color", elemento.CodigoColor));
                    con.Parametros.Add(new IfxParameter("@desc_color", elemento.Desc_color));
                    con.Parametros.Add(new IfxParameter("@fondo", elemento.Fondo));
                    con.Parametros.Add(new IfxParameter("@des_fondo", elemento.Des_fondo));
                    con.Parametros.Add(new IfxParameter("@tiendas", elemento.Tiendas));
                    con.Parametros.Add(new IfxParameter("@exito", elemento.Exito));
                    con.Parametros.Add(new IfxParameter("@cencosud", elemento.Cencosud));
                    con.Parametros.Add(new IfxParameter("@sao", elemento.Sao));
                    con.Parametros.Add(new IfxParameter("@comercio", elemento.Comercio));
                    con.Parametros.Add(new IfxParameter("@rosado", elemento.Rosado));
                    con.Parametros.Add(new IfxParameter("@otros", elemento.Otros));
                    con.Parametros.Add(new IfxParameter("@total", elemento.Total));

                    con.Parametros.Add(new IfxParameter("@idEstampado", elemento.IdEstampado));

                    var datos = con.EjecutarConsulta(this.consultaInserDetalle);
                    con.cerrarConexion();
                }
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
