using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_PedidoCuellosInformacion
    {
        #region Consultas
        private readonly string consultaInsert = "INSERT INTO cfc_spt_ped_cuellos_info (id_ped_cuellos,cod_vte,desc_vte,codigo_h1,descripcion_h1, codigo_h2,descripcion_h2,codigo_h3, descripcion_h3, codigo_h4, descripcion_h4, codigo_h5,descripcion_h5,total_uni) VALUES  " +
            " (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";

        private readonly string consultarTodo = "SELECT cod_vte,desc_vte,codigo_h1, descripcion_h1, codigo_h2, descripcion_h2, codigo_h3, descripcion_h3, codigo_h4, descripcion_h4, codigo_h5, descripcion_h5,total_uni FROM cfc_spt_ped_cuellos_info WHERE id_ped_cuellos =?;";
        
        private readonly string consultaEliminar = "DELETE cfc_spt_ped_cuellos_info WHERE id_ped_cuellos = ?;";

        #endregion
        #region Métodos Agregar
        public string Agregar(PedidoMontarInformacion elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_ped_cuellos", elemento.IdPedidoAMontar));
                    con.Parametros.Add(new IfxParameter("@cod_vte", elemento.CodigoColor));
                    con.Parametros.Add(new IfxParameter("@desc_vte", elemento.DescripcionColor));
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
                    con.Parametros.Add(new IfxParameter("@total_uni", elemento.TotalUnidades));
                 

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

        public List<PedidoMontarInformacion> ConsultarInformacion(int prmIdPedCuellos)
        {
            List<PedidoMontarInformacion> lista = new List<PedidoMontarInformacion>();
            try
            {
                using (var con = new clsConexion())
                {

                    con.Parametros.Add(new IfxParameter("@id_ped_cuellos", prmIdPedCuellos));
                    var datos = con.EjecutarConsulta(this.consultarTodo);
                    while (datos.Read())
                    {
                        PedidoMontarInformacion detalle = new PedidoMontarInformacion();
                        detalle.CodigoColor = datos["cod_vte"].ToString();
                        detalle.DescripcionColor = datos["desc_vte"].ToString().Trim();
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
                        detalle.TotalUnidades = int.Parse(datos["total_uni"].ToString());
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
                con.Parametros.Add(new IfxParameter("@id_ped_cuellos", idPedido));
                con.Ejecutar(this.consultaEliminar);
            }
        }
        #endregion
    }
}
