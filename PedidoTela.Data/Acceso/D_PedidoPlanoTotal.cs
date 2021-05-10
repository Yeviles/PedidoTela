using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_PedidoPlanoTotal
    {
        #region Consultas
        private readonly string consultaInsert = "INSERT INTO cfc_spt_ped_plano_total (id_ped_plano,cod_color,desc_color,codigo_h1,descripcion_h1, codigo_h2,descripcion_h2,codigo_h3, descripcion_h3, codigo_h4, descripcion_h4, codigo_h5,descripcion_h5,tiendas,exito,cencosud,sao,comercio,rosado,otros,total_uni,m_calculados,kg_calculados,total_pedir,uni_medidatela) " +
         " VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ? )";

        private readonly string consultarTodo = "SELECT cod_color,desc_color,codigo_h1,descripcion_h1, codigo_h2,descripcion_h2,codigo_h3, descripcion_h3, codigo_h4, descripcion_h4, codigo_h5,descripcion_h5,tiendas,exito,cencosud,sao,comercio,rosado,otros,total_uni,m_calculados,kg_calculados,total_pedir,uni_medidatela FROM cfc_spt_ped_plano_total WHERE id_ped_plano =?; ";

        private readonly string consultaEliminar = "DELETE cfc_spt_ped_plano_total WHERE id_ped_plano = ?;";

        #endregion

        #region Métodos Agregar
        public string Agregar(PedidoMontarTotal elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_ped_plano", elemento.IdPedidoAmontar));
                    con.Parametros.Add(new IfxParameter("@cod_color", elemento.CodidoColor));
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
                    con.Parametros.Add(new IfxParameter("@m_calculados", elemento.MCalculados));
                    con.Parametros.Add(new IfxParameter("@kg_calculados", elemento.KgCalculados));
                    con.Parametros.Add(new IfxParameter("@total_pedir", elemento.TotalPedir));
                    con.Parametros.Add(new IfxParameter("@uni_medidatela", elemento.UnidadMedida));


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

        #region Métodos consultas      
        public List<PedidoMontarTotal> ConsultarTotalConsolidado(int idPedidoPlano)
        {
            List<PedidoMontarTotal> lista = new List<PedidoMontarTotal>();
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_ped_plano", idPedidoPlano));
                    var datos = con.EjecutarConsulta(this.consultarTodo);
                    while (datos.Read())
                    {
                        PedidoMontarTotal detalle = new PedidoMontarTotal();
                        detalle.CodidoColor = datos["cod_color"].ToString();
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
                        detalle.MCalculados = decimal.Parse(datos["m_calculados"].ToString());
                        detalle.KgCalculados = decimal.Parse(datos["kg_calculados"].ToString());
                        detalle.TotalPedir = decimal.Parse(datos["total_pedir"].ToString());
                        detalle.UnidadMedida = datos["uni_medidatela"].ToString();

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

        #region Métodos Eliminar
        public void EliminarPorPedido(int idPedido)
        {
            using (var con = new clsConexion())
            {
                con.Parametros.Add(new IfxParameter("@id_ped_plano", idPedido));
                con.Ejecutar(this.consultaEliminar);
            }
        }
        #endregion
    }
}
