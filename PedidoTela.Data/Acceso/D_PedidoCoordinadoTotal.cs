using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_PedidoCoordinadoTotal
    {
        #region Consultas
        
        private readonly string consultaInsert = "INSERT INTO cfc_spt_ped_coordinado_total (id_ped_coordinado,cod_color,desc_color,tiendas,exito,cencosud,sao,comercio,rosado,otros,total_uni,m_calculados,kg_calculados,total_pedir,uni_medidatela) " +
          " VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ? )";


        private readonly string consultarTodo = "SELECT cod_color,desc_color,tiendas,exito,cencosud,sao,comercio,rosado,otros,total_uni,m_calculados,kg_calculados,total_pedir,uni_medidatela " +
            "FROM cfc_spt_ped_coordinado_total WHERE id_ped_coordinado =?; ";

        private readonly string consultaEliminar = "DELETE cfc_spt_ped_coordinado_total WHERE id_ped_coordinado = ?;";
        #endregion

        #region Métodos Agregar
        public string Agregar(PedidoMontarTotal elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_ped_coordinado", elemento.IdPedidoAmontar));
                    con.Parametros.Add(new IfxParameter("@cod_color", elemento.CodidoColor));
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
                    con.Parametros.Add(new IfxParameter("@id_ped_coordinado", idPedidoPlano));
                    var datos = con.EjecutarConsulta(this.consultarTodo);
                    while (datos.Read())
                    {
                        PedidoMontarTotal detalle = new PedidoMontarTotal();
                        detalle.CodidoColor = datos["cod_color"].ToString();
                        detalle.DescripcionColor = datos["desc_color"].ToString().Trim();
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
                con.Parametros.Add(new IfxParameter("@id_ped_coordinado", idPedido));
                con.Ejecutar(this.consultaEliminar);
            }
        }
        #endregion
    }
}
