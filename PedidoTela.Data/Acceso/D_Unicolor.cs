using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_Unicolor
    {
        private readonly string consultaInsert = "INSERT INTO produccion:eliot.cfc_spt_sol_unicolor (idensayo, referencia_tela, descripcion_tela, tipo_tejido, coordinado, coordinado_con, observaciones) VALUES(?, ?, ?, ?, ?, ?, ?);";

        public string Agregar(Unicolor elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@idensayo", elemento.IdEnsayo));
                    con.Parametros.Add(new IfxParameter("@referencia_tela", elemento.ReferenciaTela));
                    con.Parametros.Add(new IfxParameter("@descripcion_tela", elemento.DescripcionTela));
                    con.Parametros.Add(new IfxParameter("@tipo_tejido", elemento.TipoTejido));
                    con.Parametros.Add(new IfxParameter("@coordinado", elemento.Coordinado));
                    con.Parametros.Add(new IfxParameter("@coordinado_con", elemento.CoordinadoCon));
                    con.Parametros.Add(new IfxParameter("@observaciones", elemento.Observaciones));
                    var datos = con.EjecutarConsulta(this.consultaInsert);
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
    }
}
