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

        private readonly string consultaInsert = "INSERT INTO cfc_spt_sol_plano_pretenido (identificador, referencia_tela, coordinado, coordinado_con, observacion, id_sol_tela) VALUES(?, ?, ?, ?, ?, ?);";
        private readonly string consultaAll = "SELECT idplano, identificador, referencia_tela, coordinado, coordinado_con, observacion FROM cfc_spt_sol_plano_pretenido WHERE id_sol_tela = ?;";
        private readonly string consultaId = "SELECT idplano FROM cfc_spt_sol_plano_pretenido WHERE identificador = ?;";
        
        private readonly string consultaIdPla = "SELECT idplano FROM cfc_spt_sol_plano_pretenido WHERE id_sol_tela = ?;";
         
        private readonly string consultaIdentificador = "select identificador from cfc_spt_sol_plano_pretenido where id_sol_tela = ?;";

        private readonly string consultaIdSolTela = "SELECT id_sol_tela FROM cfc_spt_sol_plano_pretenido WHERE idplano = ?;";

        private readonly string consultaConsecutivo = "SELECT MAX(consecutivo) as consecutivo FROM cfc_spt_sol_plano_pretenido;";
        
        private readonly string consultaUpdateConsecutivo = "UPDATE cfc_spt_sol_plano_pretenido set consecutivo=? WHERE idplano= ?;";

        private readonly string actualizar = "UPDATE cfc_spt_sol_plano_pretenido SET referencia_tela =?, coordinado=?, coordinado_con=?, observacion=?,identificador=? WHERE id_sol_tela=?;";
        
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

        public int ConsultarId(string prmIdentificador)
        {
            int id = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    conexion.Parametros.Add(new IfxParameter("@identificador", prmIdentificador));
                    var datos = conexion.EjecutarConsulta(consultaId);
                    datos.Read();
                    id = int.Parse(datos["idplano"].ToString());

                    conexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return id;
        }
        public int ConsultarIdPla(int idSolTela)
        {
            int id = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    conexion.Parametros.Add(new IfxParameter("@id_sol_tela", idSolTela));
                    var datos = conexion.EjecutarConsulta(consultaIdPla);
                    datos.Read();
                    id = int.Parse(datos["idplano"].ToString());

                    conexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return id;
        }
        public int ConsultarIdSolTela(int idPlano)
        {
            int id = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    conexion.Parametros.Add(new IfxParameter("@idplano", idPlano));
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
       
        public PlanoPretenido Consultar(int idSolTela)
        {
            PlanoPretenido plano = new PlanoPretenido();
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_sol_tela", idSolTela));
                    var datos = con.EjecutarConsulta(this.consultaAll);
                    while (datos.Read())
                    {
                        plano.Id = int.Parse(datos["idplano"].ToString());
                        plano.Identificador = datos["identificador"].ToString();
                        plano.ReferenciaTela = datos["referencia_tela"].ToString();
                        bool so = false;
                        if(datos["coordinado"].ToString() == "t") { so = true; }
                        plano.Coordinado = so;
                        plano.CoordinadoCon = (datos["coordinado_con"].ToString().Trim().Length > 0) ? datos["coordinado_con"].ToString().Trim() : "";
                        plano.Observacion = datos["observacion"].ToString();
                       // plano.Consecutivo = int.Parse(datos["consecutivo"].ToString());
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
                    con.Parametros.Add(new IfxParameter("@id_sol_tela",elemento.IdSolTela));
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

        public string Actualizar(PlanoPretenido prmPlano)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    //con.Parametros.Add(new IfxParameter("@identificador", prmPlano.Identificador));
                    con.Parametros.Add(new IfxParameter("@referencia_tela", prmPlano.ReferenciaTela));
                    con.Parametros.Add(new IfxParameter("@coordinado", prmPlano.Coordinado));
                    con.Parametros.Add(new IfxParameter("@coordinado_con", prmPlano.CoordinadoCon));
                    con.Parametros.Add(new IfxParameter("@observacion", prmPlano.Observacion));
                    con.Parametros.Add(new IfxParameter("@identificador", prmPlano.Identificador));
                    con.Parametros.Add(new IfxParameter("@id_sol_tela", prmPlano.IdSolTela));
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
    }
}
