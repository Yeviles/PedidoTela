using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_DetalleConsumo
    {
        #region Consultas
        //Script para obtener Consumo Detalle cuando es ENSAYO  (ejemplo:159-715-0)
        private readonly string consulta1 = "select unique tel.idprogramador||'-'||tel.idensayo||'-'||tel.idrepeticion ensayo_referencia, "
                                          + "den.codi_prenda, (prendas.desc_prenda) desc_prenda, trim(tel.codi_item) as codigo_tela, case when tel.tipo = 'P' then "
                                          + "trim(telas.desc_item) else tel.codi_item end as descripcion_tela, NVL(consumo_est, '0') AS consumo_est "
                                          + "from cfc_telas_ensayo tel left join  items telas  on tel.codi_item = telas.codi_item "
                                          + "inner join cfc_d_ensayo den on tel.idprogramador= den.idprogramador and tel.idensayo = den.idensayo and tel.idrepeticion= den.idrepeticion "
                                          + "inner join cfc_e_prendas prendas on den.codi_prenda = prendas.codi_prenda "
                                          + "where tel.idprogramador = ?  and tel.idensayo = ?  and tel.idrepeticion = ? "
                                          + "and tel.activo = 'T'";
        
        //Script para obtener Consumo Detalle cuando es REFERENCIA
        private readonly string consulta2 = "select unique ficha.codi_item as ensayo_referencia "
                                            + ",prendasficha.codi_prenda, (prendas.desc_prenda) desc_prenda "
                                            + ", trim(tel.codi_item) as codigo_tela,case when tel.tipo = 'P' then trim(telas.desc_item) else tel.codi_item end as descripcion_tela, tel.consumo_est "
                                            + "from cfc_e_ficha ficha inner join cfc_prendas_ficha prendasficha on ficha.idempresa= prendasficha.idempresa and ficha.idficha= prendasficha.idficha "
                                            + "inner join cfc_telas_ensayo tel on prendasficha.idempresa= tel.idempresa and prendasficha.idprogramador= tel.idprogramador and prendasficha.idensayo= tel.idensayo and prendasficha.idrepeticion= tel.idrepeticion "
                                            + "left join  items telas  on tel.codi_item = telas.codi_item "
                                            + "inner join cfc_e_prendas prendas on prendasficha.codi_prenda = prendas.codi_prenda "
                                            + "where ficha.codi_item= ?";
        #endregion

        public List<DetalleConsumo> ConsultarDetalleConsumo(string prmIdensayo)
        {
            //string[] objConsu = new string[prmIdensayo.Length];
            string [] objConsu = prmIdensayo.Split('-'); 

            List<DetalleConsumo> respuesta = new List<DetalleConsumo>();
            using (var administrador = new clsConexion())
            {
                administrador.Parametros.Add(new IfxParameter("@idprogramador", objConsu.GetValue(0)));
                administrador.Parametros.Add(new IfxParameter("@idensayo", objConsu.GetValue(1)));
                administrador.Parametros.Add(new IfxParameter("@idrepeticion", objConsu.GetValue(2)));
                var datos = administrador.EjecutarConsulta(consulta1);
                while (datos.Read())
                {
                    DetalleConsumo objDetalle = new DetalleConsumo();
                    
                    objDetalle.Ensayo_referencia = datos["ensayo_referencia"].ToString().Trim();
                    objDetalle.Codi_prenda = datos["codi_prenda"].ToString().Trim();
                    objDetalle.Desc_prenda = datos["desc_prenda"].ToString().Trim();
                    objDetalle.Codigo_tela = datos["codigo_tela"].ToString().Trim();
                    objDetalle.Descripcion_tela = datos["descripcion_tela"].ToString().Trim();
                    objDetalle.Consumo_est = datos["consumo_est"].ToString().Trim();
             
                    respuesta.Add(objDetalle);
                };
                administrador.cerrarConexion();
            }
            return respuesta;

        }

        public List<DetalleConsumo> ConsulatDetalleReferencia(string prmIdReferencia)
        {

            List<DetalleConsumo> respuesta = new List<DetalleConsumo>();
            using (var administrador = new clsConexion())
            {
                administrador.Parametros.Add(new IfxParameter("@codi_item",prmIdReferencia ));
                var datos = administrador.EjecutarConsulta(consulta2);
                while (datos.Read())
                {
                    DetalleConsumo objDetalle = new DetalleConsumo();

                    objDetalle.Ensayo_referencia = datos["ensayo_referencia"].ToString().Trim();
                    objDetalle.Codi_prenda = datos["codi_prenda"].ToString().Trim();
                    objDetalle.Desc_prenda = datos["desc_prenda"].ToString().Trim();
                    objDetalle.Codigo_tela = datos["codigo_tela"].ToString().Trim();
                    objDetalle.Descripcion_tela = datos["descripcion_tela"].ToString().Trim();
                    objDetalle.Consumo_est = datos["consumo_est"].ToString().Trim();

                    respuesta.Add(objDetalle);
                };
                administrador.cerrarConexion();
            }
            return respuesta;

        }
    }
}
