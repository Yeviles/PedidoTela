using IBM.Data.Informix;

using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_PedidoPlanoInformacion
    {
        #region Consultas
        private readonly string consultaInsert = "INSERT INTO cfc_spt_ped_plano_info (id_ped_plano,cod_color,desc_color,codigo_h1,descripcion_h1, codigo_h2,descripcion_h2,codigo_h3, descripcion_h3, codigo_h4, descripcion_h4, codigo_h5,descripcion_h5, tiendas,exito,cencosud,sao,comercio,rosado,otros,total_uni,consumo,m_calculados,m_reservar,m_solicitar,kg_calculados) VALUES  " +
            " (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?) ;";

        private readonly string consultaId = "SELECT id_plano_info FROM cfc_spt_ped_plano_info WHERE  id_ped_plano =?;";

        private readonly string consultarTodo = "SELECT cod_color,desc_color,codigo_h1,descripcion_h1, codigo_h2,descripcion_h2,codigo_h3, descripcion_h3, codigo_h4, descripcion_h4, codigo_h5,descripcion_h5,tiendas,exito,cencosud,sao,comercio,rosado,otros,total_uni,consumo,m_calculados,m_reservar,m_solicitar,kg_calculados FROM cfc_spt_ped_plano_info WHERE id_ped_plano =?; ";

        private readonly string actualizar = "UPDATE cfc_spt_ped_plano_info SET cod_color =?, desc_color =?, codigo_h1=?, descripcion_h1=?, codigo_h2=?, descripcion_h2=?, codigo_h3=?, descripcion_h3=?,codigo_h4=?, descripcion_h4=?, codigo_h5=?, descripcion_h5=?, tiendas =?, exito =?," +
           " cencosud=?, sao=?, comercio=?,rosado=?, otros=?, total_uni=?, consumo=?, m_calculados=?,  m_reservar=?, m_solicitar=?, kg_calculados=? WHERE id_plano_info =?;";

        #endregion

        #region Métodos Agregar
        public string Agregar(PedidoMontarInformacion elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_ped_plano", elemento.IdPedidoAMontar));
                    con.Parametros.Add(new IfxParameter("@cod_color", elemento.CodigoColor));
                    con.Parametros.Add(new IfxParameter("@desc_color", elemento.DescripcionColor));
                    con.Parametros.Add(new IfxParameter("@codigo_h1", elemento.CodigoH1));
                    con.Parametros.Add(new IfxParameter("@descripcion_h1", elemento.DescripcionH1));
                    con.Parametros.Add(new IfxParameter("@codigo_h2", elemento.CodigoH2));
                    con.Parametros.Add(new IfxParameter("@descripcion_h2", elemento.DescripcionH2));
                    con.Parametros.Add(new IfxParameter("@codigo_h3", elemento.CodigoH3));
                    con.Parametros.Add(new IfxParameter("@descripcion_h3", elemento.DescripcionH3));
                    con.Parametros.Add(new IfxParameter("@codigo_h4", elemento.CodigoH4));
                    con.Parametros.Add(new IfxParameter("@descripcion_h4", elemento.DescripcionH4));
                    con.Parametros.Add(new IfxParameter("@codigo_h5", elemento.CodigoH5));
                    con.Parametros.Add(new IfxParameter("@descripcion_h5", elemento.DescripcionH5));
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

        #region Métodos Consulta
        public List<int> ConsultarId(int prmIdPedidoPlano)
        {
            int id = 0;
            List<int> lista = new List<int>();
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_ped_plano", prmIdPedidoPlano));
                    var datos = con.EjecutarConsulta(this.consultaId);
                    while (datos.Read())
                    {
                        id = int.Parse(datos["id_plano_info"].ToString());
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

        public List<PedidoMontarInformacion> ConsultarInfoConsolidar(int prmIdPedidoPlano)
        {
            List<PedidoMontarInformacion> lista = new List<PedidoMontarInformacion>();
            try
            {
                using (var con = new clsConexion())
                {

                    con.Parametros.Add(new IfxParameter("@id_ped_plano", prmIdPedidoPlano));
                    var datos = con.EjecutarConsulta(this.consultarTodo);
                    while (datos.Read())
                    {
                        PedidoMontarInformacion detalle = new PedidoMontarInformacion();
                        detalle.CodigoColor = datos["cod_color"].ToString();
                        detalle.DescripcionColor = datos["desc_color"].ToString().Trim();
                        detalle.CodigoH1 = int.Parse(datos["codigo_h1"].ToString());
                        detalle.DescripcionH1 = datos["descripcion_h1"].ToString().Trim();
                        detalle.CodigoH2 = int.Parse(datos["codigo_h2"].ToString());
                        detalle.DescripcionH2 = datos["descripcion_h2"].ToString().Trim();
                        detalle.CodigoH3 = int.Parse(datos["codigo_h3"].ToString());
                        detalle.DescripcionH3 = datos["descripcion_h3"].ToString().Trim();
                        detalle.CodigoH4 = int.Parse(datos["codigo_h4"].ToString());
                        detalle.DescripcionH4 = datos["descripcion_h4"].ToString().Trim();
                        detalle.CodigoH5 = int.Parse(datos["codigo_h5"].ToString());
                        detalle.DescripcionH5 = datos["descripcion_h5"].ToString().Trim();
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

        public string Actualizar(PedidoMontarInformacion elemento, int prmIdDetalle)
        {
            string respuesta = "";
            try
            {
                //UPDATE 
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@cod_color", elemento.CodigoColor));
                    con.Parametros.Add(new IfxParameter("@desc_color", elemento.DescripcionColor));
                    con.Parametros.Add(new IfxParameter("@codigo_h1", elemento.CodigoH1));
                    con.Parametros.Add(new IfxParameter("@descripcion_h1", elemento.DescripcionH1));
                    con.Parametros.Add(new IfxParameter("@codigo_h2", elemento.CodigoH2));
                    con.Parametros.Add(new IfxParameter("@descripcion_h2", elemento.DescripcionH2));
                    con.Parametros.Add(new IfxParameter("@codigo_h3", elemento.CodigoH3));
                    con.Parametros.Add(new IfxParameter("@descripcion_h3", elemento.DescripcionH3));
                    con.Parametros.Add(new IfxParameter("@codigo_h4", elemento.CodigoH4));
                    con.Parametros.Add(new IfxParameter("@descripcion_h4", elemento.DescripcionH4));
                    con.Parametros.Add(new IfxParameter("@codigo_h5", elemento.CodigoH5));
                    con.Parametros.Add(new IfxParameter("@descripcion_h5", elemento.DescripcionH5));
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

                    con.Parametros.Add(new IfxParameter("@id_plano_info", prmIdDetalle));
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
