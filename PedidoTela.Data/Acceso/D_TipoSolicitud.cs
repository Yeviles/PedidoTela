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
        private readonly string agregarConsecutivo = "insert into cfc_spt_tipo_solicitud (id_solicitud, id_tipo, tipo, consecutivo,fecha_solicitud,estado,fecha_estado,identificador) values(?, ?, ?, ?, ?, ?, ?, ?);";
            
        private readonly string consConsecutivo = "select consecutivo FROM cfc_spt_tipo_solicitud where id_tipo = ?;";
   
        private readonly string consultaMax = "select max(consecutivo) as max from  cfc_spt_tipo_solicitud;";

      
        #endregion

        /// <summary>
        /// Agrega a la tabla cfc_spt_tipo_solicitud toda la información requerida para la solicitud Telas. 
        /// </summary>
        /// <param name="prmIdsolicitud">Identificador de Esayo o Referencia</param>
        /// <param name="prmIdtipo">Identificador de la solicitud, ya sea Unicolor, Estampado, Plano Preteñido, Cuellos-Puños-Tiras</param>
        /// <param name="tipo">Nombre del tipo de solocicitud, ya sea Unicolor, Estampado, Plano Preteñido, Cuellos-Puños-Tiras</param>
        /// <param name="prmConsecutivo">Consecutivo de Solicitud.</param>
        /// <param name="fechaSolicitud">Fecha en la cual fue confirmada la solicitud de telas.</param>
        /// <returns>Retorna un string de verificación indicando si la consulta guardo o no la información entregada por parámetros.</returns>
        public string Agregar(int prmIdsolicitud, int prmIdtipo, string tipo, int prmConsecutivo, string fechaSolicitud, string estado, string fechaEstado,string identificador)
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
                    con.Parametros.Add(new IfxParameter("@fecha_solicitud", fechaSolicitud));
                    con.Parametros.Add(new IfxParameter("@estado", estado));
                    con.Parametros.Add(new IfxParameter("@fecha_estado", fechaEstado));
                    con.Parametros.Add(new IfxParameter("@identificador", identificador));


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

        /// <summary>
        /// Consulta si el parámetro que llega tien consecutivo. 
        /// </summary>
        /// <param name="prmIdentificador">Identificador de ensayo o Refencia.</param>
        /// <returns></returns>
        public int consultarConsecutivo(int prmIdentificador)
        {
            int id = 0;
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_tipo", prmIdentificador));
                    var datos = con.EjecutarConsulta(consConsecutivo);
                    datos.Read();
                    id = int.Parse(datos["consecutivo"].ToString());
                    con.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return id;
        }

       
        /*public bool consultarConsecutivo(int prmIdentificador)
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
        }*/

        /// <summary>
        /// Consultar el máximo consecutivo.
        /// </summary>
        /// <returns>Retorna un int que representa el número mayor de los consecutivos registrados.</returns>
        public int consultarMaximo()
        {
            int max = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    var datos = conexion.EjecutarConsulta(consultaMax);
                    datos.Read();
                    //max = int.Parse(datos.ToString().Trim());
                    max = int.Parse(datos["max"].ToString());
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
