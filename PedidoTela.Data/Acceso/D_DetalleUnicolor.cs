using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_DetalleUnicolor
    {
        private readonly string consultaInsert = "INSERT INTO cfc_spt_sol_unicolor_detalle (idunicolor, codigo_color, descripcion, tiendas, exito, cencosud, sao, comercio, rosado, otros, total) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";

        public string Agregar(DetalleUnicolor elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@idensayo", elemento.IdUnicolor));
                    con.Parametros.Add(new IfxParameter("@codigo_color", elemento.CodigoColor));
                    con.Parametros.Add(new IfxParameter("@descripcion", elemento.Descripcion));
                    con.Parametros.Add(new IfxParameter("@tiendas", elemento.Tiendas));
                    con.Parametros.Add(new IfxParameter("@exito", elemento.Exito));
                    con.Parametros.Add(new IfxParameter("@cencosud", elemento.Cencosud));
                    con.Parametros.Add(new IfxParameter("@sao", elemento.Sao));
                    con.Parametros.Add(new IfxParameter("@comercio", elemento.Comercio));
                    con.Parametros.Add(new IfxParameter("@rosado", elemento.Rosado));
                    con.Parametros.Add(new IfxParameter("@otros", elemento.Otros));
                    con.Parametros.Add(new IfxParameter("@total", elemento.Total));
                    var datos = con.EjecutarConsulta(this.consultaInsert);
                    con.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                respuesta = "Error: " + ex.Message;
            }
            return respuesta;
        }
    }
}
