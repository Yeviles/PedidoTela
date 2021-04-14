using IBM.Data.Informix;
using PedidoTela.Entidades;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_DetalleCuelloDos
    {
        #region Consultas
        private readonly string colsultarTodo = "SELECT idDetalleCuelloDos, idCuellos, codigo_vte, descripcion_vte, codigo_h1, descripcion_h1, codigo_h2, descripcion_h2, codigo_h3, descripcion_h3, codigo_h4, descripcion_h4, codigo_h5, descripcion_h5, total FROM cfc_spt_sol_detalle_cuello_dos WHERE idCuellos = ?;";
        
        private readonly string consultaInsert = "insert into cfc_spt_sol_detalle_cuello_dos (idCuellos, codigo_vte, descripcion_vte, codigo_h1, descripcion_h1, codigo_h2, descripcion_h2, codigo_h3, descripcion_h3, codigo_h4, descripcion_h4, codigo_h5, descripcion_h5, total) values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";

        private readonly string consultaId = "SELECT idDetalleCuelloDos FROM cfc_spt_sol_detalle_cuello_dos WHERE idCuellos =?;";

        private readonly string actualizar = "UPDATE cfc_spt_sol_detalle_cuello_dos SET codigo_vte=?, descripcion_vte=?, codigo_h1=?, descripcion_h1=?, codigo_h2=?, descripcion_h2=?,codigo_h3=?,descripcion_h3=?, codigo_h4=?, descripcion_h4=?, codigo_h5=?, descripcion_h5=?, total=? WHERE idDetalleCuelloDos = ?; ";
        #endregion
        #region Métodos
        public List<DetalleCuelloDos> Consultar(int idCuelloDos)
        {
            List<DetalleCuelloDos> lista = new List<DetalleCuelloDos>();
            try
            {
                using (var con = new clsConexion())
                {
                   
                    con.Parametros.Add(new IfxParameter("@idCuellos", idCuelloDos));
                    var datos = con.EjecutarConsulta(this.colsultarTodo);
                    while (datos.Read())
                    {
                        DetalleCuelloDos detalle = new DetalleCuelloDos();
                        detalle.IdDetalleCuelloDos = int.Parse(datos["idDetalleCuelloDos"].ToString());
                        detalle.IdCuellos = int.Parse(datos["idCuellos"].ToString());
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
       
        public string Agregar(DetalleCuelloDos elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@idCuellos", elemento.IdCuellos));
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

        public List<int> ConsultarId(int idCuellos)
        {
            int id = 0;
            List<int> lista = new List<int>();
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@idCuellos", idCuellos));
                    var datos = con.EjecutarConsulta(this.consultaId);
                    while (datos.Read())
                    {
                        id = int.Parse(datos["idDetalleCuelloDos"].ToString());
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

        public string Actualizar(DetalleCuelloDos elemento, int idDetalle)
        {
            string respuesta = "";
            try
            {
                //UPDATE 
                using (var con = new clsConexion())
                {
                    //con.Parametros.Add(new IfxParameter("@idCuellos", elemento.IdCuellos));
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
                    con.Parametros.Add(new IfxParameter("@total", elemento.Total));

                    //con.Parametros.Add(new IfxParameter("@idunicolor", prmDEttalleEstampado.IdUnicolor));
                    con.Parametros.Add(new IfxParameter("@idDetalleCuelloDos", idDetalle));
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
