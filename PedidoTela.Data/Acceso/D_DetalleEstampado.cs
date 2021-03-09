using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_DetalleEstampado
    {
        #region Consultas
        private readonly string consultaInserDetalle = "INSERT INTO cfc_spt_sol_detalleEstampado (codigoColor,desc_color,fondo,des_fondo,tiendas,exito,cencosud,sao,comercio,rosado,otros,total, idEstampado) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";
        private readonly string consultarTodo = "SELECT codigoColor,desc_color,fondo, des_fondo, NVL(tiendas, '0') as tiendas, exito, cencosud, sao, comercio, rosado, otros, total FROM cfc_spt_sol_detalleEstampado WHERE idestampado = ?";

        #endregion

        #region Métodos
        /// <summary>
        /// Inserta en a la tabla cfc_spt_sol_detalleEstampado.
        /// </summary>
        /// <param name="elemento"> Parámetro de tipo DetalleConsumo</param>
        /// <returns>Retorna una respuesta de éxito o no el proceso de Inserción</returns>
        public string Agregar(DetalleEstampado elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {


                    con.Parametros.Add(new IfxParameter("@codigo_color", elemento.CodigoColor));
                    con.Parametros.Add(new IfxParameter("@desc_color", elemento.Desc_color));
                    con.Parametros.Add(new IfxParameter("@fondo", elemento.Fondo));
                    con.Parametros.Add(new IfxParameter("@des_fondo", elemento.Des_fondo));
                    con.Parametros.Add(new IfxParameter("@tiendas", elemento.Tiendas));
                    con.Parametros.Add(new IfxParameter("@exito", elemento.Exito));
                    con.Parametros.Add(new IfxParameter("@cencosud", elemento.Cencosud));
                    con.Parametros.Add(new IfxParameter("@sao", elemento.Sao));
                    con.Parametros.Add(new IfxParameter("@comercio", elemento.Comercio));
                    con.Parametros.Add(new IfxParameter("@rosado", elemento.Rosado));
                    con.Parametros.Add(new IfxParameter("@otros", elemento.Otros));
                    con.Parametros.Add(new IfxParameter("@total", elemento.Total));

                    con.Parametros.Add(new IfxParameter("@idEstampado", elemento.IdEstampado));

                    var datos = con.EjecutarConsulta(this.consultaInserDetalle);
                    con.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                respuesta = "Error: " + ex.Message;
            }
            return respuesta;
            }

        /// <summary>
        /// Lista campos de la tabla cfc_spt_sol_detalleEstampado.
        /// </summary>
        /// <param name="prmIdEstampado">Identificador de comparación</param>
        /// <returns>Lista con todos los capos según el parámetro consultado.</returns>
        public List<DetalleEstampado> getDetalleEstampado(int prmIdEstampado)
            {
                List<DetalleEstampado> lista = new List<DetalleEstampado>();
                try
                {
                    using (var con = new clsConexion())
                    {
                        DetalleEstampado detalle = new DetalleEstampado();
                        con.Parametros.Add(new IfxParameter("@idestampado ", prmIdEstampado));
                        var datos = con.EjecutarConsulta(this.consultarTodo);
                        while (datos.Read())
                        {
                            detalle.CodigoColor = datos["codigoColor"].ToString();
                            detalle.Desc_color = datos["desc_color"].ToString().Trim();
                            detalle.Fondo = datos["fondo"].ToString().Trim();
                            detalle.Des_fondo = datos["des_fondo"].ToString().Trim();
                            detalle.Tiendas =int.Parse(datos["tiendas"].ToString().Trim());
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
       
        #endregion
    }
}
