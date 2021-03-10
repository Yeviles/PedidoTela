using IBM.Data.Informix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_TipoSolicitud
    {
        #region Consultas
        private readonly string agregarConsecutivo = "insert into cfc_spt_tipo_solicitud(id_solicitud, id_tipo, tipo, consecutivo) values(?, ?, ?, ?);";
        private readonly string consConsecutivo = "select consecutivo cfc_spt_tipo_solicitud where id_tipo = ?;";

        private readonly string consultaMax = "select idSolicitud(consecutivo) as idSolicitud from  cfc_spt_tipo_solicitud;";

        #endregion
        public string Agregar(int prmIdsolicitud, int prmIdtipo, string tipo, int prmConsecutivo)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_solicitud ", prmIdsolicitud));
                    con.Parametros.Add(new IfxParameter("@id_tipo", prmIdtipo));
                    con.Parametros.Add(new IfxParameter("@tipo", tipo));
                    con.Parametros.Add(new IfxParameter("@consecutivo", prmConsecutivo));

                    //con.Parametros.Add(new IfxParameter("ide", prmConsecutivo));
                    var datos = con.EjecutarConsulta(this.agregarConsecutivo);
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

        public bool consultarConsecutivo(int prmIdentificador)
        {
            string ensayo;
            using (var administrador = new clsConexion())
            {
                try
                {
                    administrador.Parametros.Add(new IfxParameter("@id_tipo", prmIdentificador));
                    var datos = administrador.EjecutarConsulta(this.consConsecutivo);
                    datos.Read();
                    ensayo = datos["consecutivo"].ToString().Trim();
                    administrador.cerrarConexion();
                    if (ensayo != "")
                    {
                        return true;
                    }
                    else
                    {
                        return false;

                    }
                }
                catch
                {
                    return false;
                }

            }
        }

        public int consultarMaximo()
        {
            int max = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    var datos = conexion.EjecutarConsultaEscalar(this.consultaMax);
                    max = int.Parse(datos.ToString().Trim());
                    conexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return max;
        }

    }
}
