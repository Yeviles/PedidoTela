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
        private readonly string consultaInsert = "INSERT INTO cfc_spt_sol_unicolor (idensayo, referencia_tela, tipo_tejido, coordinado, coordinado_con, observaciones) VALUES(?, ?, ?, ?, ?, ?);";
        private readonly string consultaAll = "SELECT idunicolor, idensayo, referencia_tela, tipo_tejido, coordinado, coordinado_con, observaciones FROM cfc_spt_sol_unicolor WHERE idensayo = 715;";
        private readonly string consultaId = "SELECT idunicolor FROM cfc_spt_sol_unicolor WHERE idensayo = ?;";

        public int ConsultarId(string identificador)
        {
            int id = 0;
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@idensayo", identificador));
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

        public Unicolor Consultar(string identificador)
        {
            Unicolor unicolor = new Unicolor();
            try
            {
                using (var con = new clsConexion())
                {
                    //con.Parametros.Add(new IfxParameter("@idensayo", identificador));
                    var datos = con.EjecutarConsulta(this.consultaAll);
                    while (datos.Read())
                    {
                        unicolor.Id = int.Parse(datos["idunicolor"].ToString());
                        unicolor.Identificador = datos["idensayo"].ToString();
                        unicolor.ReferenciaTela = datos["referencia_tela"].ToString();
                        unicolor.TipoTejido = datos["tipo_tejido"].ToString();
                        unicolor.Coordinado = bool.Parse(datos["coordinado"].ToString());
                        unicolor.CoordinadoCon = (datos["coordinado_con"].ToString().Trim().Length > 0) ? datos["coordinado_con"].ToString().Trim() : "";
                        unicolor.Observaciones = datos["observaciones"].ToString();
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
                    con.Parametros.Add(new IfxParameter("@idensayo", elemento.Identificador));
                    con.Parametros.Add(new IfxParameter("@referencia_tela", elemento.ReferenciaTela));
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
