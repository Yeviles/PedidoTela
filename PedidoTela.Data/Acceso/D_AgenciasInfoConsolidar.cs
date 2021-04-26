using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_AgenciasInfoConsolidar
    {
        #region Consultas
        private readonly string consultaId = "SELECT id_infoconsolidar FROM cfc_spt_agen_infoconsolidar WHERE  idAgencias =?;";

        private readonly string actualizar = "UPDATE cfc_spt_agen_infoconsolidar SET codigo_color=?, desc_color=?, tiendas=?, exito=?," +
            " cencosud=?, sao=?, comercio=?,rosado=?, otros=?, total=?, consumo=?, m_calculados=?, m_solicitar=?, m_reservar=? WHERE id_infoconsolidar =?;";

        private readonly string consultaInsert = "INSERT INTO cfc_spt_agen_infoconsolidar (idAgencias,codigo_color,desc_color,tiendas,exito,cencosud,sao,comercio,rosado,otros,total,consumo,m_calculados,m_solicitar,m_reservar)" +
            " VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

        private readonly string consultarTodo = "SELECT codigo_color,desc_color,tiendas,exito,cencosud,sao,comercio,rosado,otros,total,consumo,m_calculados,m_solicitar,m_reservar FROM cfc_spt_agen_infoconsolidar WHERE idAgencias =?; ";
        #endregion
        public List<int> ConsultarId(int idCuellos)
        {
            int id = 0;
            List<int> lista = new List<int>();
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@idAgencias", idCuellos));
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

        public string Actualizar(AgenciasInfoConsolidar elemento, int idDetalle)
        {
            string respuesta = "";
            try
            {
                //UPDATE 
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@codigo_color", elemento.CodColor));
                    con.Parametros.Add(new IfxParameter("@desc_color", elemento.DesColor));
                    con.Parametros.Add(new IfxParameter("@tiendas", elemento.Tiendas));
                    con.Parametros.Add(new IfxParameter("@exito", elemento.Exito));
                    con.Parametros.Add(new IfxParameter("@cencosud", elemento.Cencosud));
                    con.Parametros.Add(new IfxParameter("@sao", elemento.Sao));
                    con.Parametros.Add(new IfxParameter("@comercio", elemento.ComercioOrg));
                    con.Parametros.Add(new IfxParameter("@rosado", elemento.Rosado));
                    con.Parametros.Add(new IfxParameter("@otros", elemento.Otros));
                    con.Parametros.Add(new IfxParameter("@total", elemento.TotalUnidades));
                    con.Parametros.Add(new IfxParameter("@consumo", elemento.Consumo));
                    con.Parametros.Add(new IfxParameter("@m_calculados", elemento.MCalculados));
                    con.Parametros.Add(new IfxParameter("@m_solicitar", elemento.MaSolicitar));
                    con.Parametros.Add(new IfxParameter("@m_reservar", elemento.MReservados));

                    con.Parametros.Add(new IfxParameter("@id_infoconsolidar", idDetalle));
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

        public string Agregar(AgenciasInfoConsolidar elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@idAgencias", elemento.IdAgencias));
                    con.Parametros.Add(new IfxParameter("@codigo_color", elemento.CodColor));
                    con.Parametros.Add(new IfxParameter("@desc_color", elemento.DesColor));
                    con.Parametros.Add(new IfxParameter("@tiendas", elemento.Tiendas));
                    con.Parametros.Add(new IfxParameter("@exito", elemento.Exito));
                    con.Parametros.Add(new IfxParameter("@cencosud", elemento.Cencosud));
                    con.Parametros.Add(new IfxParameter("@sao", elemento.Sao));
                    con.Parametros.Add(new IfxParameter("@comercio", elemento.ComercioOrg));
                    con.Parametros.Add(new IfxParameter("@rosado", elemento.Rosado));
                    con.Parametros.Add(new IfxParameter("@otros", elemento.Otros));
                    con.Parametros.Add(new IfxParameter("@total", elemento.TotalUnidades));
                    con.Parametros.Add(new IfxParameter("@consumo", elemento.Consumo));
                    con.Parametros.Add(new IfxParameter("@m_calculados", elemento.MCalculados));
                    con.Parametros.Add(new IfxParameter("@m_solicitar", elemento.MaSolicitar));
                    con.Parametros.Add(new IfxParameter("@m_reservar", elemento.MReservados));

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
       
        public List<AgenciasInfoConsolidar> getDetalleInfoConsolidar(int prmIdAgencias)
        {
            List<AgenciasInfoConsolidar> lista = new List<AgenciasInfoConsolidar>();
            try
            {
                using (var con = new clsConexion())
                {

                    con.Parametros.Add(new IfxParameter("@idAgencias ", prmIdAgencias));
                    var datos = con.EjecutarConsulta(this.consultarTodo);
                    while (datos.Read())
                    {
                          AgenciasInfoConsolidar detalle = new AgenciasInfoConsolidar();
                        detalle.CodColor = datos["codigo_color"].ToString();
                        detalle.DesColor = datos["desc_color"].ToString().Trim();
                        detalle.Tiendas = int.Parse(datos["tiendas"].ToString().Trim());
                        detalle.Exito = int.Parse(datos["exito"].ToString());
                        detalle.Cencosud = int.Parse(datos["cencosud"].ToString());
                        detalle.Sao = int.Parse(datos["sao"].ToString());
                        detalle.ComercioOrg = int.Parse(datos["comercio"].ToString());
                        detalle.Rosado = int.Parse(datos["rosado"].ToString());
                        detalle.Otros = int.Parse(datos["otros"].ToString());
                        detalle.TotalUnidades = int.Parse(datos["total"].ToString());
                        detalle.Consumo = decimal.Parse(datos["consumo"].ToString());
                        detalle.MCalculados = decimal.Parse(datos["m_calculados"].ToString());
                        detalle.MaSolicitar = decimal.Parse(datos["m_solicitar"].ToString());
                        detalle.MReservados = decimal.Parse(datos["m_reservar"].ToString());

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
    }
}
