using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_Estampado
    {
        #region Consultas
        private readonly string consultaInsert = "INSERT INTO cfc_spt_sol_estampado (ensayo_ref,referencia_tela,nombre_tela,tipo_estampado,tipo_tejido,n_dibujos,n_cilindros,coordinado_con,coordinado,observaciones) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";

        #endregion
        #region Métodos
        public string Agregar(Estampado elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
   
                    con.Parametros.Add(new IfxParameter("@esayo_ref", elemento.Esayo_ref));
                    con.Parametros.Add(new IfxParameter("@referencia_tela", elemento.Referencia_tela));
                    con.Parametros.Add(new IfxParameter("@nombre_tela", elemento.Nombre_tela));
                    con.Parametros.Add(new IfxParameter("@tipo_estampado", elemento.Tipo_estampado));
                    con.Parametros.Add(new IfxParameter("@tipo_tejido", elemento.Tipo_tejido));
                    con.Parametros.Add(new IfxParameter("@n_dibujos", elemento.N_dibujos));
                    con.Parametros.Add(new IfxParameter("@n_cilindros", elemento.N_cilindors));
                    con.Parametros.Add(new IfxParameter("@coordinado_con", elemento.Coordinado_con));
                    con.Parametros.Add(new IfxParameter("@coordinado", elemento.Coordinado));
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
        #endregion
    }
}
