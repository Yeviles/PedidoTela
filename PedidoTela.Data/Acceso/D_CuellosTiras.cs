using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_CuellosTiras
    {
        #region Consultas
        private readonly string consultarTodo = "select idCuellos,identificador,cuellos,punos,tiras,coordinado,coordinadoCon,observacion from cfc_spt_sol_Cuellos where identificador = ?;";
        private readonly string consultaInsert = "insert into cfc_spt_sol_Cuellos (identificador,cuellos,punos,tiras,coordinado,coordinadoCon,observacion) values (?, ?, ?, ?, ?, ?, ?);";
        private readonly string consultaId = "SELECT idCuellos FROM cfc_spt_sol_Cuellos WHERE identificador = ?;";

        #endregion

        #region Métodos 
        public CuellosTiras Consultar(string identificador)
        {
            CuellosTiras cuellos = new CuellosTiras();
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@identificador", identificador));
                    var datos = con.EjecutarConsulta(this.consultarTodo);
                    while (datos.Read())
                    {
                        cuellos.IdCuellos = int.Parse(datos["idCuellos"].ToString());
                        cuellos.Identificador = datos["identificador"].ToString();
                        cuellos.Cuellos = bool.Parse(datos["cuellos"].ToString());
                        cuellos.Punos = bool.Parse(datos["punos"].ToString());
                        cuellos.Tiras = bool.Parse(datos["tiras"].ToString());
                        cuellos.Coordinado = bool.Parse(datos["coordinado"].ToString());
                        cuellos.CoordinadoCon = (datos["coordinadoCon"].ToString().Trim().Length > 0) ? datos["coordinadoCon"].ToString().Trim() : "";
                        cuellos.Observacion = datos["observacion"].ToString();

                    }
                    con.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return cuellos;
        }
        public string Agregar(CuellosTiras elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@identificador", elemento.Identificador));
                    con.Parametros.Add(new IfxParameter("@cuellos", elemento.Cuellos));
                    con.Parametros.Add(new IfxParameter("@punos", elemento.Punos));
                    con.Parametros.Add(new IfxParameter("@tiras", elemento.Tiras));
                    con.Parametros.Add(new IfxParameter("@coordinado", elemento.Coordinado));
                    con.Parametros.Add(new IfxParameter("@coordinadoCon", elemento.CoordinadoCon));
                    con.Parametros.Add(new IfxParameter("@observacion", elemento.Observacion));
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
        public int ConsultarId(string identificador)
        {
            int id = 0;
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@identificador", identificador));
                    var datos = con.EjecutarConsultaEscalar(this.consultaId);
                    id = int.Parse(datos.ToString());

                    con.cerrarConexion();
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
