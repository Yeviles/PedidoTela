using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_PlanoPretenido
    {

        private readonly string consultaInsert = "INSERT INTO cfc_spt_sol_plano_pretenido (identificador, referencia_tela, coordinado, coordinado_con, observacion, consecutivo) VALUES(?, ?, ?, ?, ?, ?);";
        private readonly string consultaAll = "SELECT idplano, identificador, referencia_tela, coordinado, coordinado_con, observacion, NVL(consecutivo, '0') as consecutivo FROM cfc_spt_sol_plano_pretenido WHERE identificador = ?;";
        private readonly string consultaId = "SELECT idplano FROM cfc_spt_sol_plano_pretenido WHERE identificador = ?;";
        private readonly string consultaConsecutivo = "SELECT MAX(consecutivo) as consecutivo FROM cfc_spt_sol_plano_pretenido;";
        private readonly string consultaUpdateConsecutivo = "UPDATE cfc_spt_sol_plano_pretenido set consecutivo=? WHERE idplano= ?;";

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

        public int Consultarconsecutivo()
        {
            int id = 0;
            try
            {
                using (var con = new clsConexion())
                {
                    var datos = con.EjecutarConsultaEscalar(this.consultaConsecutivo);
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
        public PlanoPretenido Consultar(string identificador)
        {
            PlanoPretenido plano = new PlanoPretenido();
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@identificador", identificador));
                    var datos = con.EjecutarConsulta(this.consultaAll);
                    while (datos.Read())
                    {
                        plano.Id = int.Parse(datos["idplano"].ToString());
                        plano.Identificador = datos["identificador"].ToString();
                        plano.ReferenciaTela = datos["referencia_tela"].ToString();
                        plano.Coordinado = bool.Parse(datos["coordinado"].ToString());
                        plano.CoordinadoCon = (datos["coordinado_con"].ToString().Trim().Length > 0) ? datos["coordinado_con"].ToString().Trim() : "";
                        plano.Observacion = datos["observacion"].ToString();
                        plano.Consecutivo = int.Parse(datos["consecutivo"].ToString());
                    }
                    con.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return plano;
        }

        public string Agregar(PlanoPretenido elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@identificador", elemento.Identificador));
                    con.Parametros.Add(new IfxParameter("@referencia_tela", elemento.ReferenciaTela));
                    con.Parametros.Add(new IfxParameter("@coordinado", elemento.Coordinado));
                    con.Parametros.Add(new IfxParameter("@coordinado_con", elemento.CoordinadoCon));
                    con.Parametros.Add(new IfxParameter("@observacion", elemento.Observacion));
                    con.Parametros.Add(new IfxParameter("@consecutivo", "0"));
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

        public string AgregarConsecutivo(int elemento, int idPlano)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@consecutivo", elemento.ToString()));
                    con.Parametros.Add(new IfxParameter("@idplano", idPlano.ToString()));
                    var datos = con.EjecutarConsulta(this.consultaUpdateConsecutivo);
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
