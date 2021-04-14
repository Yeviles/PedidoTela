using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_DetalleUnicolor
    {
        private readonly string consultaInsert = "INSERT INTO cfc_spt_sol_unicolor_detalle (idunicolor, codigo_color, tiendas, exito, cencosud, sao, comercio, rosado, otros, total) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";
        private readonly string consultaAll = "SELECT id, idunicolor, codigo_color, c.desc_color, NVL(tiendas, '0') as tiendas, exito, cencosud, sao, comercio, rosado, otros, total "
                                            + "FROM cfc_spt_sol_unicolor_detalle ud left join  inmcolor c on  ud.codigo_color = c.codi_color WHERE idunicolor = ?;";

        private readonly string actualizar = "UPDATE cfc_spt_sol_unicolor_detalle SET codigo_color =?, tiendas=?, exito=?, cencosud=?, sao=?, comercio=?, rosado=?, otros=?, total=? WHERE id =?;";

        private readonly string consultaId = " select id from cfc_spt_sol_unicolor_detalle where idunicolor = ?;";

        public List<DetalleUnicolor> Consultar(int idUnicolor)
        {
            List<DetalleUnicolor> lista = new List<DetalleUnicolor>();
            try
            {
                using (var con = new clsConexion())
                {
                    //DetalleUnicolor detalle = new DetalleUnicolor();
                    con.Parametros.Add(new IfxParameter("@idunicolor", idUnicolor));
                    var datos = con.EjecutarConsulta(this.consultaAll);
                    while (datos.Read())
                    {
                        DetalleUnicolor detalle = new DetalleUnicolor();
                        detalle.Id = int.Parse(datos["id"].ToString());
                        detalle.IdUnicolor = int.Parse(datos["idunicolor"].ToString());
                        detalle.CodigoColor = datos["codigo_color"].ToString();
                        detalle.Descripcion = datos["desc_color"].ToString().Trim();
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

        public string Agregar(DetalleUnicolor elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@idensayo", elemento.IdUnicolor));
                    con.Parametros.Add(new IfxParameter("@codigo_color", elemento.CodigoColor));
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
                respuesta = "ok";
            }
            catch (Exception ex)
            {
                respuesta = "Error: " + ex.Message;
            }
            return respuesta;
        }

        public string Actualizar(DetalleUnicolor prmDetalleUnicolor, int idDetalle)
        {
            string respuesta = "";
            try
            {
                
                    using (var con = new clsConexion())
                    {
                        con.Parametros.Add(new IfxParameter("@codigo_color", prmDetalleUnicolor.CodigoColor));
                        con.Parametros.Add(new IfxParameter("@tiendas", prmDetalleUnicolor.Tiendas));
                        con.Parametros.Add(new IfxParameter("@exito", prmDetalleUnicolor.Exito));
                        con.Parametros.Add(new IfxParameter("@cencosud", prmDetalleUnicolor.Cencosud));
                        con.Parametros.Add(new IfxParameter("@sao", prmDetalleUnicolor.Sao));
                        con.Parametros.Add(new IfxParameter("@comercio", prmDetalleUnicolor.Comercio));
                        con.Parametros.Add(new IfxParameter("@rosado", prmDetalleUnicolor.Rosado));
                        con.Parametros.Add(new IfxParameter("@otros", prmDetalleUnicolor.Otros));
                        con.Parametros.Add(new IfxParameter("@total", prmDetalleUnicolor.Total));
                     
                        //con.Parametros.Add(new IfxParameter("@idunicolor", prmDetalleUnicolor.IdUnicolor));
                        con.Parametros.Add(new IfxParameter("@id", idDetalle));
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
        //public List<int> ConsultarId(int idUniclor)
        //{
        //    List<int> listaId = new List<int>();
        //    int id = 0;
        //    try
        //    {
        //        using (var con = new clsConexion())
        //        {
        //            con.Parametros.Add(new IfxParameter("@idunicolor", idUniclor));

        //            var datos = con.EjecutarConsultaEscalar(this.consultaId);
        //            id = int.Parse(datos.ToString());
        //            listaId.Add(id);
        //            con.cerrarConexion();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //    return listaId;
        //}
        public List<int> ConsultarId(int idUnicolor)
        {
            int id = 0;
            List<int> lista = new List<int>();
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@idunicolor", idUnicolor));
                    var datos = con.EjecutarConsulta(this.consultaId);
                    while (datos.Read())
                    {
                        id = int.Parse(datos["id"].ToString());
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
    }
}
