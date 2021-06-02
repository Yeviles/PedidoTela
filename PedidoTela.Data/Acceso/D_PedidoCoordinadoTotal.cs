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

        private readonly string consultaInsertCoordinadoCuellos = "INSERT INTO cfc_spt_ped_coordinado_cuello (id_ped_coordinado, cod_vte, desc_vte, xs, s, m, l, xl, dosxl, cuatro, seis, ocho, diez, doce, catorce, dieciseis, dieciocho, veinte, veintidos, veinticuatro, total_uni)  values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";


        private readonly string consultarTodo = "SELECT cod_color,desc_color,tiendas,exito,cencosud,sao,comercio,rosado,otros,total_uni,m_calculados,kg_calculados,total_pedir,uni_medidatela " +
            "FROM cfc_spt_ped_coordinado_total WHERE id_ped_coordinado =?; ";

        private readonly string consultaEliminar = "DELETE cfc_spt_ped_coordinado_total WHERE id_ped_coordinado = ?;";
        
        private readonly string consultaEliminarCoordinadoCuellos = "DELETE cfc_spt_ped_coordinado_cuello WHERE id_ped_coordinado = ?;";
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
                    con.Parametros.Add(new IfxParameter("@desc_color", elemento.DescripcionColor));
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

        public string AgregarCoordinadoCuellosProporcion(PedidoCuellos elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_ped_coordinado", elemento.IdPedidoCuellos));
                    con.Parametros.Add(new IfxParameter("@cod_vte", elemento.CodigoVte));
                    con.Parametros.Add(new IfxParameter("@desc_vte", elemento.DescripcionVte));
                    con.Parametros.Add(new IfxParameter("@xs", elemento.Xs));
                    con.Parametros.Add(new IfxParameter("@s", elemento.S));
                    con.Parametros.Add(new IfxParameter("@m", elemento.M));
                    con.Parametros.Add(new IfxParameter("@l", elemento.L));
                    con.Parametros.Add(new IfxParameter("@xl", elemento.Xl));
                    con.Parametros.Add(new IfxParameter("@dosxl", elemento.Dosxl));
                    con.Parametros.Add(new IfxParameter("@cuatro", elemento.Cuatro));
                    con.Parametros.Add(new IfxParameter("@seis", elemento.Seis));
                    con.Parametros.Add(new IfxParameter("@ocho", elemento.Ocho));
                    con.Parametros.Add(new IfxParameter("@diez", elemento.Diez));
                    con.Parametros.Add(new IfxParameter("@doce", elemento.Doce));
                    con.Parametros.Add(new IfxParameter("@catorce", elemento.Catorce));
                    con.Parametros.Add(new IfxParameter("@dieciseis", elemento.Dieciseis));
                    con.Parametros.Add(new IfxParameter("@dieciocho", elemento.Dieciocho));
                    con.Parametros.Add(new IfxParameter("@veinte", elemento.Veinte));
                    con.Parametros.Add(new IfxParameter("@veintidos", elemento.Veintidos));
                    con.Parametros.Add(new IfxParameter("@veinticuatro", elemento.Veinticuatro));
                    con.Parametros.Add(new IfxParameter("@total_uni", elemento.TotalUnidades));
                    var datos = con.EjecutarConsulta(this.consultaInsertCoordinadoCuellos);
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
        public void EliminarCoordinadoCuellos(int idPedido)
        {
            using (var con = new clsConexion())
            {
                con.Parametros.Add(new IfxParameter("@id_ped_coordinado", idPedido));
                con.Ejecutar(this.consultaEliminarCoordinadoCuellos);
            }
        }

        #endregion
    }
}
