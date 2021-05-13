using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_PedidoCuellosProporcion
    {
        #region Consultas
        private readonly string consultaInsert = "INSERT INTO cfc_spt_ped_cuellos_prop (id_ped_cuellos, cod_vte, desc_vte, xs, s, m, l, xl, dosxl, cuatro, seis, ocho, diez, doce, catorce, dieciseis, dieciocho, veinte, veintidos, veinticuatro, total_uni)  values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";

        private readonly string colsultarTodo = "SELECT id_ped_cuellos, cod_vte,desc_vte,xs,s,m,l,xl,dosxl,cuatro,seis,ocho,diez,doce,catorce,dieciseis,dieciocho,veinte,veintidos,veinticuatro,total_uni FROM cfc_spt_ped_cuellos_prop WHERE id_ped_cuellos = ?;";

        private readonly string consultaEliminar = "DELETE cfc_spt_ped_cuellos_prop WHERE id_ped_cuellos = ?;";

        #endregion

        #region Métodos Agregar
        public string Agregar(PedidoCuellos elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_ped_cuellos", elemento.IdPedidoCuellos));
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
        public List<PedidoCuellos> Consultar(int prmIdPedidoCuellos)
        {
            List<PedidoCuellos> lista = new List<PedidoCuellos>();
            try
            {
                using (var con = new clsConexion())
                {

                    con.Parametros.Add(new IfxParameter("@id_ped_cuellos", prmIdPedidoCuellos));
                    var datos = con.EjecutarConsulta(this.colsultarTodo);
                    while (datos.Read())
                    {
                        PedidoCuellos detalle = new PedidoCuellos();
                        detalle.IdPedidoCuellos = int.Parse(datos["id_ped_cuellos"].ToString());
                        detalle.CodigoVte = datos["cod_vte"].ToString().Trim();
                        detalle.DescripcionVte = datos["desc_vte"].ToString().Trim();
                        detalle.Xs = decimal.Parse(datos["xs"].ToString().Trim());
                        detalle.S = decimal.Parse(datos["s"].ToString().Trim());
                        detalle.M = decimal.Parse(datos["m"].ToString().Trim());
                        detalle.L = decimal.Parse(datos["l"].ToString().Trim());
                        detalle.Xl = decimal.Parse(datos["xl"].ToString().Trim());
                        detalle.Dosxl = decimal.Parse(datos["dosxl"].ToString().Trim());
                        detalle.Cuatro = decimal.Parse(datos["cuatro"].ToString());
                        detalle.Seis = decimal.Parse(datos["seis"].ToString().Trim());
                        detalle.Ocho = decimal.Parse(datos["ocho"].ToString().Trim());
                        detalle.Diez = decimal.Parse(datos["diez"].ToString().Trim());
                        detalle.Doce = decimal.Parse(datos["doce"].ToString().Trim());
                        detalle.Catorce = decimal.Parse(datos["catorce"].ToString().Trim());
                        detalle.Dieciseis = decimal.Parse(datos["dieciseis"].ToString().Trim());
                        detalle.Dieciocho = decimal.Parse(datos["dieciocho"].ToString().Trim());
                        detalle.Veinte = decimal.Parse(datos["veinte"].ToString().Trim());
                        detalle.Veintidos = decimal.Parse(datos["Veintidos"].ToString().Trim());
                        detalle.Veinticuatro = decimal.Parse(datos["veinticuatro"].ToString().Trim());
                        detalle.TotalUnidades = int.Parse(datos["total_uni"].ToString().Trim());
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
