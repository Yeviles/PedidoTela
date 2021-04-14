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
        private readonly string consultaInsert = "INSERT INTO cfc_spt_sol_unicolor (identificador, referencia_tela, tipo_tejido, coordinado, coordinado_con, observacion,id_sol_tela) VALUES(?, ?, ?, ?, ?, ?, ?);";
        //private readonly string consultaAll = "SELECT idunicolor, identificador, referencia_tela, tipo_tejido, coordinado, NVL(coordinado_con, '') AS coordinado_con, observacion FROM cfc_spt_sol_unicolor WHERE identificador = ?;";
        
        private readonly string consultaAll = "SELECT idunicolor, identificador, referencia_tela, tipo_tejido, coordinado, NVL(coordinado_con, '') AS coordinado_con, observacion FROM cfc_spt_sol_unicolor WHERE id_sol_tela = ?;";
        
        private readonly string consultaId = "SELECT idunicolor FROM cfc_spt_sol_unicolor WHERE identificador = ?;";
        
        private readonly string consultaIdUni = "SELECT idunicolor FROM cfc_spt_sol_unicolor WHERE id_sol_tela = ?;";
        
        private readonly string consultaIdSolTela = "SELECT id_sol_tela FROM cfc_spt_sol_unicolor WHERE idunicolor = ?;";
        
        private readonly string consultaConsecutivo = "SELECT MAX(consecutivo) as consecutivo FROM cfc_spt_sol_unicolor;";
        private readonly string consultaUpdateConsecutivo = "UPDATE cfc_spt_sol_unicolor set consecutivo=? WHERE idplano= ?;";

        private readonly string consultaIdentificador = "select identificador from cfc_spt_sol_unicolor where id_sol_tela = ?;";

        private readonly string actualizar = "UPDATE cfc_spt_sol_unicolor SET referencia_tela =?, tipo_tejido =?, coordinado =?, coordinado_con =?, observacion =?,identificador =? WHERE id_sol_tela =?;";

        //public int ConsultarIdUnicolor(string identificador)
        //{
        //    int id = 0;
        //    try
        //    {
        //        using (var con = new clsConexion())
        //        {
        //            con.Parametros.Add(new IfxParameter("@identificador", identificador));
        //            var datos = con.EjecutarConsulta(consultaId);
        //            id = int.Parse(datos.ToString());

        //            con.cerrarConexion();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //    return id;
        //}
        public int ConsultarIdUnicolor(string prmIdentificador)
        {
            int id = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    conexion.Parametros.Add(new IfxParameter("@identificador", prmIdentificador));
                    var datos = conexion.EjecutarConsulta(consultaId);
                    datos.Read();
                    id = int.Parse(datos["idunicolor"].ToString());

                    conexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return id;
        }
        public int ConsultarIdUni(int idSolTela)
        {
            int id = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    conexion.Parametros.Add(new IfxParameter("@id_sol_tela", idSolTela));
                    var datos = conexion.EjecutarConsulta(consultaIdUni);
                    datos.Read();
                    id = int.Parse(datos["idunicolor"].ToString());

                    conexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return id;
        }
        public int ConsultarIdSolTela(int idUnicolor)
        {
            int id = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    conexion.Parametros.Add(new IfxParameter("@idunicolor", idUnicolor));
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
        
        public bool consultarIdentificador(int  idSolTela)
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

        public Unicolor Consultar(int identificador)
        {
            Unicolor unicolor = new Unicolor();
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_sol_tela", identificador));
                    var datos = con.EjecutarConsulta(this.consultaAll);
                    while (datos.Read())
                    {
                        unicolor.Id = int.Parse(datos["idunicolor"].ToString());
                        unicolor.Identificador = datos["identificador"].ToString();
                        unicolor.ReferenciaTela = datos["referencia_tela"].ToString();
                        unicolor.TipoTejido = datos["tipo_tejido"].ToString();
                        bool so = false;
                        if (datos["coordinado"].ToString() == "t") { so = true; }
                        unicolor.Coordinado = so;
                        unicolor.CoordinadoCon = (datos["coordinado_con"].ToString().Trim().Length > 0) ? datos["coordinado_con"].ToString().Trim() : "";
                        unicolor.Observacion = datos["observacion"].ToString().Trim();
                    }
                    con.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return unicolor;
        }

        public string Agregar(Unicolor elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@identificador", elemento.Identificador));
                    con.Parametros.Add(new IfxParameter("@referencia_tela", elemento.ReferenciaTela));
                    con.Parametros.Add(new IfxParameter("@tipo_tejido", elemento.TipoTejido));
                    con.Parametros.Add(new IfxParameter("@coordinado", elemento.Coordinado));
                    con.Parametros.Add(new IfxParameter("@coordinado_con", elemento.CoordinadoCon));
                    con.Parametros.Add(new IfxParameter("@observacion", elemento.Observacion));
                    con.Parametros.Add(new IfxParameter("@id_sol_tela", elemento.IdSolicitudTela));
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

        public string Actualizar(Unicolor prmUnicolor)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@referencia_tela", prmUnicolor.ReferenciaTela));
                    con.Parametros.Add(new IfxParameter("@tipo_tejido", prmUnicolor.TipoTejido));
                    con.Parametros.Add(new IfxParameter("@coordinado", prmUnicolor.Coordinado));
                    con.Parametros.Add(new IfxParameter("@coordinado_con", prmUnicolor.CoordinadoCon));
                    con.Parametros.Add(new IfxParameter("@observacion", prmUnicolor.Observacion));
                    con.Parametros.Add(new IfxParameter("@identificador", prmUnicolor.Identificador));
                    con.Parametros.Add(new IfxParameter("@id_sol_tela", prmUnicolor.IdSolicitudTela));

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
