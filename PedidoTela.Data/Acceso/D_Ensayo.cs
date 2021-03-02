using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidoTela.Data.Acceso
{
    public class D_Ensayo
    {
        #region Consultas
        //Script para obtener datos cuando es ENSAYO(ejemplo:159-715-0)
        private readonly string consulta2 = "select cfc_e_ensayo.idprogramador ||'-'|| cfc_e_ensayo.idensayo ||'-'|| cfc_e_ensayo.idrepeticion ensayo_referencia "
                                            +", cfc_e_ensayo.idprogramador, cfc_e_ensayo.idensayo, cfc_e_ensayo.idrepeticion "
                                            +",cfc_d_ensayo.idmundo, cfc_d_ensayo.codi_capsula,cfc_d_ensayo.anio_muestrario, cfc_d_ensayo.nmro_muestrario,cfc_d_ensayo.codi_entrada "
                                            +",trim(cfc_e_mundo.desc_mundo) as ocasion_uso, trim(cfc_m_capsulas.nombre) as tema,trim(cfc_e_entrada.desc_entrada) as entrada "
                                            +",cfc_m_usuarios.nombre as programador "
                                            +"from cfc_e_ensayo inner join cfc_d_ensayo on cfc_e_ensayo.idempresa=cfc_d_ensayo.idempresa and cfc_e_ensayo.idprogramador= cfc_d_ensayo.idprogramador and cfc_e_ensayo.idensayo= cfc_d_ensayo.idensayo and cfc_e_ensayo.idrepeticion= cfc_d_ensayo.idrepeticion "
                                            +"inner join cfc_e_mundo on cfc_d_ensayo.idmundo= cfc_e_mundo.idmundo "
                                            +"inner join cfc_m_capsulas on cfc_d_ensayo.codi_capsula= cfc_m_capsulas.idcapsula "
                                            +"inner join cfc_e_entrada on cfc_d_ensayo.codi_entrada= cfc_e_entrada.codi_entrada "
                                            +"inner join cfc_m_prgrmdor on cfc_e_ensayo.idprogramador= cfc_m_prgrmdor.idprogramador "
                                            +"inner join cfc_m_usuarios on cfc_m_prgrmdor.idusuario= cfc_m_usuarios.idusuario "
                                            +"where cfc_e_ensayo.idprogramador= ? and cfc_e_ensayo.idensayo= ? and cfc_e_ensayo.idrepeticion= ?";
        
        //Script para obtener datos cuando es REFERENCIA(ejemplo 45160180)
        private readonly string consulta4 = "select items.codi_item ensayo_referencia, cfc_e_items.idprogramador, 0 idensayo, 0 idrepeticion "
                                            + ", items.idmundo, cfc_e_items.idcapsula, items.amue_item as anio_muestrario, items.mues_item as nmro_muestrario, cfc_e_items.codi_entrada "
                                            + ", trim(cfc_e_mundo.desc_mundo) as ocasion_uso, trim(cfc_m_capsulas.nombre) as tema, trim(cfc_e_entrada.desc_entrada) as entrada "
                                            + ", cfc_m_usuarios.nombre as programador "
                                            + "from items inner join cfc_e_items on items.codi_item= cfc_e_items.codi_item "
                                            + "inner join cfc_e_mundo on items.idmundo= cfc_e_mundo.idmundo "
                                            + "inner join cfc_m_capsulas on cfc_e_items.idcapsula= cfc_m_capsulas.idcapsula "
                                            + "inner join cfc_e_entrada on cfc_e_items.codi_entrada= cfc_e_entrada.codi_entrada "
                                            + "inner join cfc_m_prgrmdor on cfc_e_items.idprogramador= cfc_m_prgrmdor.idprogramador "
                                            + "inner join cfc_m_usuarios on cfc_m_prgrmdor.idusuario= cfc_m_usuarios.idusuario "
                                            + "where items.codi_item= ?;";

        #endregion
        #region Métodos 
        public void Actualizar(Objeto elemento)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Extrae todos los datos de la tabla cfc_e_ensayo según un idensayo recibido.
        /// </summary>
        /// <param name="idEnsayo">Dato seleccionado por en usuario en Form</param>
        /// <returns>Retorna una lista de objetos de tipo Ensayo.</returns>
        public List<Ensayo> ConsultarEnsayo(string idEnsayo)
        {
            string [] objId = idEnsayo.Split('-');
          
            List<Ensayo> respuesta = new List<Ensayo>();
            using (var administrador = new clsConexion())
            {
                administrador.Parametros.Add(new IfxParameter("@idprogramador", objId.GetValue(0)));
                administrador.Parametros.Add(new IfxParameter("@idensayo", objId.GetValue(1)));
                administrador.Parametros.Add(new IfxParameter("@idrepeticion", objId.GetValue(2)));

                var datos = administrador.EjecutarConsulta(consulta2);
                while (datos.Read())
                {
                    Ensayo objEnsayo = new Ensayo();
                    objEnsayo.Ensayo_referencia = datos["ensayo_referencia"].ToString().Trim();
                    objEnsayo.Idprogramador = datos["idprogramador"].ToString().Trim();
                    objEnsayo.Idensayo = datos["idensayo"].ToString().Trim();
                    objEnsayo.Idrepeticion = datos["idrepeticion"].ToString().Trim();
                    objEnsayo.Idmundo = datos["idmundo"].ToString().Trim();
                    objEnsayo.Codi_capsula = datos["codi_capsula"].ToString().Trim();
                    objEnsayo.Anio_muestrario = datos["anio_muestrario"].ToString().Trim();
                    objEnsayo.Nmro_muestrario = datos["nmro_muestrario"].ToString().Trim();
                    objEnsayo.Codi_entrada = datos["codi_entrada"].ToString().Trim();
                    objEnsayo.Ocasion_uso = datos["ocasion_uso"].ToString().Trim();
                    objEnsayo.Tema = datos["tema"].ToString().Trim();
                    objEnsayo.Entrada = datos["entrada"].ToString().Trim();
                    objEnsayo.Programador = datos["programador"].ToString().Trim();
                    respuesta.Add(objEnsayo);
                };
                administrador.cerrarConexion();
            }
           return respuesta;
          
        }
        
        /// <summary>
        /// Extrae todos los datos según una REFERENCIA
        /// </summary>
        /// <param name="prmReferencia">Dato ingrsado por el usuario</param>
        /// <returns>Retorna una lista de tipo Ensayo</returns>
        public List<Ensayo> ConsultarReferencia(string prmReferencia)
        {

            List<Ensayo> respuesta = new List<Ensayo>();
            using (var administrador = new clsConexion())
            {
                administrador.Parametros.Add(new IfxParameter("@codi_item", prmReferencia));

                var datos = administrador.EjecutarConsulta(consulta4);
                while (datos.Read())
                {
                    Ensayo objEnsayo = new Ensayo();
                    objEnsayo.Ensayo_referencia = datos["ensayo_referencia"].ToString().Trim();
                    objEnsayo.Idprogramador = datos["idprogramador"].ToString().Trim();
                    objEnsayo.Idensayo = datos["idensayo"].ToString().Trim();
                    objEnsayo.Idrepeticion = datos["idrepeticion"].ToString().Trim();
                    objEnsayo.Idmundo = datos["idmundo"].ToString().Trim();
                    objEnsayo.Codi_capsula = datos["idcapsula"].ToString().Trim();
                    objEnsayo.Anio_muestrario = datos["anio_muestrario"].ToString().Trim();
                    objEnsayo.Nmro_muestrario = datos["nmro_muestrario"].ToString().Trim();
                    objEnsayo.Codi_entrada = datos["codi_entrada"].ToString().Trim();
                    objEnsayo.Ocasion_uso = datos["ocasion_uso"].ToString().Trim();
                    objEnsayo.Tema = datos["tema"].ToString().Trim();
                    objEnsayo.Entrada = datos["entrada"].ToString().Trim();
                    objEnsayo.Programador = datos["programador"].ToString().Trim();
                    respuesta.Add(objEnsayo);
                };
                administrador.cerrarConexion();
            }
            return respuesta;

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
