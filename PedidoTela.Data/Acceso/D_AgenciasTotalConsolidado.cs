using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_AgenciasTotalConsolidado
    {
        #region Consultas
        private readonly string consultaInsert = "INSERT INTO cfc_spt_agen_externos_total (id_agencias,codigo_color,desc_color,tiendas,exito,cencosud,sao,comercio,rosado,otros,total,m_calculados,kg_calculados,total_pedir,uni_medidatela) " +
          " VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ? )";

        private readonly string consultarTodo = "SELECT codigo_color,desc_color,tiendas,exito,cencosud,sao,comercio,rosado,otros,total,m_calculados,kg_calculados,total_pedir,uni_medidatela FROM cfc_spt_agen_externos_total WHERE id_agencias =?; ";

        private readonly string consultaEliminar = "DELETE cfc_spt_agen_externos_total WHERE id_agencias = ?;";

        #endregion

        #region Métodos Agregar
        public string Agregar(AgenciaTotalConsolidar elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_agencias", elemento.IdAgencias));
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
                    con.Parametros.Add(new IfxParameter("@m_calculados", elemento.MCalculados));
                    con.Parametros.Add(new IfxParameter("@kg_calculados", elemento.KgCalculados));
                    con.Parametros.Add(new IfxParameter("@total_pedir", elemento.TotalaPedir));
                    con.Parametros.Add(new IfxParameter("@uni_medidatela", elemento.UniMedidaTela));


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
        public List<AgenciaTotalConsolidar> getDetalleTotalConsolidado(int prmIdAgencias)
        {
            List<AgenciaTotalConsolidar> lista = new List<AgenciaTotalConsolidar>();
            try
            {
                using (var con = new clsConexion())
                {

                    con.Parametros.Add(new IfxParameter("@id_agencias", prmIdAgencias));
                    var datos = con.EjecutarConsulta(this.consultarTodo);
                    while (datos.Read())
                    {
                        AgenciaTotalConsolidar detalle = new AgenciaTotalConsolidar();
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
                        detalle.MCalculados = decimal.Parse(datos["m_calculados"].ToString());
                        detalle.KgCalculados = decimal.Parse(datos["kg_calculados"].ToString());
                        detalle.TotalaPedir = decimal.Parse(datos["total_pedir"].ToString());
                        detalle.UniMedidaTela = datos["uni_medidatela"].ToString();

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
        public void EliminarAgenciasExternoInfo(int prmIdAgencias)
        {
            using (var con = new clsConexion())
            {
                con.Parametros.Add(new IfxParameter("@id_agencias", prmIdAgencias));
                con.Ejecutar(this.consultaEliminar);
            }
        }
        #endregion
    }
}
