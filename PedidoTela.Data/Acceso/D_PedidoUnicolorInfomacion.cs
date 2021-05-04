using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_PedidoUnicolorInfomacion
    {
        #region Consultas
        private readonly string consultaInsert = "INSERT INTO cfc_spt_ped_unicolor_info (id_ped_unicolor,cod_color,desc_color,tiendas,exito,cencosud,sao,comercio,rosado,otros,total_uni,consumo,m_calculados,m_reservar,m_solicitar,kg_calculados) VALUES  " +
            " (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?) ; ";

        private readonly string consultaId = "SELECT id_infoconsolidar FROM cfc_spt_ped_unicolor_info WHERE  id_ped_unicolor =?;";

        private readonly string actualizar = "UPDATE cfc_spt_ped_unicolor_info SET cod_color =?, desc_color =?, tiendas =?, exito =?," +
            " cencosud=?, sao=?, comercio=?,rosado=?, otros=?, total_uni=?, consumo=?, m_calculados=?,  m_reservar=?, m_solicitar=?, kg_calculados=? WHERE id_infoconsolidar =?;";

        private readonly string consultarTodo = "SELECT cod_color,desc_color,tiendas,exito,cencosud,sao,comercio,rosado,otros,total_uni,consumo,m_calculados,m_reservar,m_solicitar,kg_calculados FROM cfc_spt_ped_unicolor_info WHERE id_ped_unicolor =?; ";

        #endregion

        #region Métodos Agregar
        public string Agregar(PedidoUnicolorInformacion elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_ped_unicolor", elemento.IdPedUnicolor));
                    con.Parametros.Add(new IfxParameter("@cod_color", elemento.CodColor));
                    con.Parametros.Add(new IfxParameter("@desc_color", elemento.DescColor));
                    con.Parametros.Add(new IfxParameter("@tiendas", elemento.Tiendas));
                    con.Parametros.Add(new IfxParameter("@exito", elemento.Exito));
                    con.Parametros.Add(new IfxParameter("@cencosud", elemento.Cencosud));
                    con.Parametros.Add(new IfxParameter("@sao", elemento.Sao));
                    con.Parametros.Add(new IfxParameter("@comercio", elemento.ComercioOrg));
                    con.Parametros.Add(new IfxParameter("@rosado", elemento.Rosado));
                    con.Parametros.Add(new IfxParameter("@otros", elemento.Otros));
                    con.Parametros.Add(new IfxParameter("@total_uni", elemento.TotalUnidades));
                    con.Parametros.Add(new IfxParameter("@consumo", elemento.Consumo));
                    con.Parametros.Add(new IfxParameter("@m_calculados", elemento.MCalculados));
                    con.Parametros.Add(new IfxParameter("@m_reservar", elemento.MReservados));
                    con.Parametros.Add(new IfxParameter("@m_solicitar", elemento.MSolicitar));
                   con.Parametros.Add(new IfxParameter("@kg_calculados", elemento.MReservados));

                    var datos = con.EjecutarConsulta(this.consultaInsert);
                    con.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                respuesta = "Error: " + ex.Message;
            }
            return respuesta;
        }
        #endregion

        #region Métodos Consultar
        public List<int> ConsultarId(int prmIdPedUnicolor)
        {
            int id = 0;
            List<int> lista = new List<int>();
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_ped_unicolor", prmIdPedUnicolor));
                    var datos = con.EjecutarConsulta(this.consultaId);
                    while (datos.Read())
                    {
                        id = int.Parse(datos["id_infoconsolidar"].ToString());
                        lista.Add(id);
                    }
                    con.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lista;
        }
      
        public List<PedidoUnicolorInformacion> ConsultarInfoConsolidar(int prmIdPedunicolor)
        {
            List<PedidoUnicolorInformacion> lista = new List<PedidoUnicolorInformacion>();
            try
            {
                using (var con = new clsConexion())
                {

                    con.Parametros.Add(new IfxParameter("@idAgencias ", prmIdPedunicolor));
                    var datos = con.EjecutarConsulta(this.consultarTodo);
                    while (datos.Read())
                    {
                        PedidoUnicolorInformacion detalle = new PedidoUnicolorInformacion();
                        detalle.CodColor = datos["cod_color"].ToString();
                        detalle.DescColor = datos["desc_color"].ToString().Trim();
                        detalle.Tiendas = int.Parse(datos["tiendas"].ToString().Trim());
                        detalle.Exito = int.Parse(datos["exito"].ToString());
                        detalle.Cencosud = int.Parse(datos["cencosud"].ToString());
                        detalle.Sao = int.Parse(datos["sao"].ToString());
                        detalle.ComercioOrg = int.Parse(datos["comercio"].ToString());
                        detalle.Rosado = int.Parse(datos["rosado"].ToString());
                        detalle.Otros = int.Parse(datos["otros"].ToString());
                        detalle.TotalUnidades = int.Parse(datos["total_uni"].ToString());
                        detalle.Consumo = decimal.Parse(datos["consumo"].ToString());
                        detalle.MCalculados = decimal.Parse(datos["m_calculados"].ToString());
                        detalle.MReservados = decimal.Parse(datos["m_reservar"].ToString());
                        detalle.MSolicitar = decimal.Parse(datos["m_solicitar"].ToString());
                        detalle.KgCalculados = decimal.Parse(datos["kg_calculados"].ToString());

                        lista.Add(detalle);
                    }
                    con.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lista;
        }
        #endregion

        #region Métodos Actualizar
        public string Actualizar(PedidoUnicolorInformacion elemento, int prmIdDetalle)
        {
            string respuesta = "";
            try
            {
                //UPDATE 
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@cod_color", elemento.CodColor));
                    con.Parametros.Add(new IfxParameter("@desc_color", elemento.DescColor));
                    con.Parametros.Add(new IfxParameter("@tiendas", elemento.Tiendas));
                    con.Parametros.Add(new IfxParameter("@exito", elemento.Exito));
                    con.Parametros.Add(new IfxParameter("@cencosud", elemento.Cencosud));
                    con.Parametros.Add(new IfxParameter("@sao", elemento.Sao));
                    con.Parametros.Add(new IfxParameter("@comercio", elemento.ComercioOrg));
                    con.Parametros.Add(new IfxParameter("@rosado", elemento.Rosado));
                    con.Parametros.Add(new IfxParameter("@otros", elemento.Otros));
                    con.Parametros.Add(new IfxParameter("@total_uni", elemento.TotalUnidades));
                    con.Parametros.Add(new IfxParameter("@consumo", elemento.Consumo));
                    con.Parametros.Add(new IfxParameter("@m_calculados", elemento.MCalculados));
                    con.Parametros.Add(new IfxParameter("@m_reservar", elemento.MReservados));
                    con.Parametros.Add(new IfxParameter("@m_solicitar", elemento.MSolicitar));
                    con.Parametros.Add(new IfxParameter("@kg_calculados", elemento.KgCalculados));

                    con.Parametros.Add(new IfxParameter("@id_infoconsolidar", prmIdDetalle));
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
        #endregion
    }
}
