using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_DetallePlanoPretenido
    {
        private readonly string consultaInsert = "INSERT INTO cfc_spt_sol_plano_pretenido_detalle (idplano, codigo_vte, descripcion_vte, codigo_h1, descripcion_h1, codigo_h2, descripcion_h2, codigo_h3, descripcion_h3, codigo_h4, descripcion_h4, codigo_h5, descripcion_h5, tiendas, exito, cencosud, sao, comercio, rosado, otros, total) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";
        private readonly string consultaAll = "SELECT id, idplano, codigo_vte, descripcion_vte, codigo_h1, descripcion_h1, codigo_h2, descripcion_h2, codigo_h3, descripcion_h3, codigo_h4, descripcion_h4, codigo_h5, descripcion_h5, tiendas, exito, cencosud, sao, comercio, rosado, otros, total FROM cfc_spt_sol_plano_pretenido_detalle WHERE idplano = ?;";
        public List<DetallePlanoPretenido> Consultar(int idPlano)
        {
            List<DetallePlanoPretenido> lista = new List<DetallePlanoPretenido>();
            try
            {
                using (var con = new clsConexion())
                {
                    DetallePlanoPretenido detalle = new DetallePlanoPretenido();
                    con.Parametros.Add(new IfxParameter("@idplano", idPlano));
                    var datos = con.EjecutarConsulta(this.consultaAll);
                    while (datos.Read())
                    {
                        detalle.Id = int.Parse(datos["id"].ToString());
                        detalle.IdPlano = int.Parse(datos["idplano"].ToString());
                        detalle.CodigoVte = datos["codigo_vte"].ToString();
                        detalle.DescripcionVte = datos["descripcion_vte"].ToString().Trim();
                        detalle.CodigoH1 = datos["codigo_h1"].ToString();
                        detalle.DescripcionH1 = datos["descripcion_h1"].ToString().Trim();
                        detalle.CodigoH2 = datos["codigo_h2"].ToString();
                        detalle.DescripcionH2 = datos["descripcion_h2"].ToString().Trim();
                        detalle.CodigoH3 = datos["codigo_h3"].ToString();
                        detalle.DescripcionH3 = datos["descripcion_h3"].ToString().Trim();
                        detalle.CodigoH4 = datos["codigo_h4"].ToString();
                        detalle.DescripcionH4 = datos["descripcion_h4"].ToString().Trim();
                        detalle.CodigoH5 = datos["codigo_h5"].ToString();
                        detalle.DescripcionH5 = datos["descripcion_h5"].ToString().Trim();
                        detalle.Exito = int.Parse(datos["exito"].ToString());
                        detalle.Cencosud = int.Parse(datos["cencosud"].ToString());
                        detalle.Sao = int.Parse(datos["sao"].ToString());
                        detalle.Comercio = int.Parse(datos["comercio"].ToString());
                        detalle.Rosado = int.Parse(datos["rosado"].ToString());
                        detalle.Otros = int.Parse(datos["otros"].ToString());
                        detalle.Total = int.Parse(datos["total"].ToString());
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

        public string Agregar(DetallePlanoPretenido elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@idplano", elemento.IdPlano));
                    con.Parametros.Add(new IfxParameter("@codigo_vte", elemento.CodigoVte));
                    con.Parametros.Add(new IfxParameter("@descripcion_vte", elemento.DescripcionVte));
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
                    con.Parametros.Add(new IfxParameter("@comercio", elemento.Comercio));
                    con.Parametros.Add(new IfxParameter("@rosado", elemento.Rosado));
                    con.Parametros.Add(new IfxParameter("@otros", elemento.Otros));
                    con.Parametros.Add(new IfxParameter("@total", elemento.Total));
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
    }
}
