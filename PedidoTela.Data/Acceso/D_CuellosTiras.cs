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
        private readonly string consultarTodo = "select idCuellos,identificador,cuellos,punos,tiras,coordinado,coordinadoCon,observacion from cfc_spt_sol_Cuellos where id_sol_tela = ?;";
        
        private readonly string consultaInsert = "insert into cfc_spt_sol_Cuellos (identificador,cuellos,punos,tiras,coordinado,coordinadoCon,observacion,id_sol_tela) values (?, ?, ?, ?, ?, ?, ?,?);";
        
        private readonly string consultaId = "SELECT idCuellos FROM cfc_spt_sol_Cuellos WHERE id_sol_tela = ?;";
        
        private readonly string consultaIdentificador = "SELECT identificador FROM cfc_spt_sol_Cuellos WHERE id_sol_tela = ?;";

        private readonly string actualizar = "UPDATE cfc_spt_sol_Cuellos SET cuellos=?,punos=?, tiras=?, coordinado=?,coordinadoCon=?, observacion=?, identificador=? WHERE id_sol_tela =?;";

        private readonly string consultaIdSolTela = "SELECT id_sol_tela FROM cfc_spt_sol_Cuellos WHERE idCuellos = ?;";

        #endregion

        #region Métodos 
        public CuellosTiras Consultar(int idSolTela)
        {
            CuellosTiras cuellos = new CuellosTiras();
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_sol_tela", idSolTela));
                    var datos = con.EjecutarConsulta(this.consultarTodo);
                    while (datos.Read())
                    {
                        cuellos.IdCuellos = int.Parse(datos["idCuellos"].ToString());
                        cuellos.Identificador = datos["identificador"].ToString();
                        cuellos.Cuellos = bool.Parse(datos["cuellos"].ToString());
                        cuellos.Punos = bool.Parse(datos["punos"].ToString());
                        cuellos.Tiras = bool.Parse(datos["tiras"].ToString());
                        bool so = false;
                        if (datos["coordinado"].ToString()=="t") { so = true; }
                        cuellos.Coordinado = so;
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
        
        public int ConsultarIdSolCuel(int idCuellos)
        {
            int id = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    conexion.Parametros.Add(new IfxParameter("@idCuellos", idCuellos));
                    var datos = conexion.EjecutarConsulta(consultaIdSolTela);
                    datos.Read();
                    id = int.Parse(datos["id_sol_tela"].ToString());

                    conexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return id;
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
                    con.Parametros.Add(new IfxParameter("@id_sol_tela", elemento.IdSolTela));
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

        public int ConsultarId(int idSolTela)
        {
            int id = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    conexion.Parametros.Add(new IfxParameter("@id_sol_tela", idSolTela));
                    var datos = conexion.EjecutarConsulta(consultaId);
                    datos.Read();
                    id = int.Parse(datos["idCuellos"].ToString());

                    conexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return id;
        }

        public string Actualizar(CuellosTiras elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@cuellos", elemento.Cuellos));
                    con.Parametros.Add(new IfxParameter("@punos", elemento.Punos));
                    con.Parametros.Add(new IfxParameter("@tiras", elemento.Tiras));
                    con.Parametros.Add(new IfxParameter("@coordinado", elemento.Coordinado));
                    con.Parametros.Add(new IfxParameter("@coordinadoCon", elemento.CoordinadoCon));
                    con.Parametros.Add(new IfxParameter("@observacion", elemento.Observacion));
                    con.Parametros.Add(new IfxParameter("@identificador", elemento.Identificador));

                    con.Parametros.Add(new IfxParameter("@id_sol_tela", elemento.IdSolTela));
                    var datos = con.EjecutarConsulta(actualizar);

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

        public bool consultarIdentificador(int idSolTela)
        {
            string ensayo;
            using (var administrador = new clsConexion())
            {
                try
                {
                    administrador.Parametros.Add(new IfxParameter("@id_sol_tela", idSolTela));
                    var datos = administrador.EjecutarConsulta(consultaIdentificador);
                    datos.Read();
                    ensayo = datos["identificador"].ToString().Trim();
                    administrador.cerrarConexion();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

        }
        #endregion
    }
}
