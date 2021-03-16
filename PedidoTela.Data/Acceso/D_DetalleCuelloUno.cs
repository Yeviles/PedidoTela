using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_DetalleCuelloUno
    {
        #region Consultas
        private readonly string colsultarTodo = "SELECT idDetalleCuelloUno, idCuellos,codigo,xs,s,m,l,xl,dosxl,cuatro,seis,ocho,diez,doce,catorce,dieciseis,dieciocho,veinte,veintidos,veinticuatro,ancho FROM cfc_spt_sol_detalle_cuello_uno WHERE idCuellos = ?;";
        private readonly string consultaInsert = "insert into  cfc_spt_sol_detalle_cuello_uno (idCuellos,codigo,xs,s,m,l,xl,dosxl,cuatro,seis,ocho,diez,doce,catorce,dieciseis,dieciocho,veinte,veintidos,veinticuatro,ancho)  values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";

            #endregion
        #region Métodos
        public List<DetalleCuelloUno> Consultar(int idCuelloUno)
        {
            List<DetalleCuelloUno> lista = new List<DetalleCuelloUno>();
            int cont = 0;
            try
            {
                using (var con = new clsConexion())
                {
                   
                    con.Parametros.Add(new IfxParameter("@idCuellos", idCuelloUno));
                    var datos = con.EjecutarConsulta(this.colsultarTodo);
                    while (datos.Read())
                    {
                            DetalleCuelloUno detalle = new DetalleCuelloUno();
                            detalle.IdDetalleCuelloUno = int.Parse(datos["idDetalleCuelloUno"].ToString());
                            detalle.IdCuellos = int.Parse(datos["idCuellos"].ToString());
                            detalle.Codigo = datos["codigo"].ToString().Trim();
                            detalle.Xs = int.Parse(datos["xs"].ToString().Trim());
                            detalle.S = int.Parse(datos["s"].ToString().Trim());
                            detalle.M = int.Parse(datos["m"].ToString().Trim());
                            detalle.L = int.Parse(datos["l"].ToString().Trim());
                            detalle.Xl = int.Parse(datos["xl"].ToString().Trim());
                            detalle.Dosxl = int.Parse(datos["dosxl"].ToString().Trim());
                            detalle.Cuatro = int.Parse(datos["cuatro"].ToString());
                            detalle.Seis = int.Parse(datos["seis"].ToString().Trim());
                            detalle.Ocho = int.Parse(datos["ocho"].ToString().Trim());
                            detalle.Diez = int.Parse(datos["diez"].ToString().Trim());
                            detalle.Doce = int.Parse(datos["doce"].ToString().Trim());
                            detalle.Catorce = int.Parse(datos["catorce"].ToString().Trim());
                            detalle.Dieciseis = int.Parse(datos["dieciseis"].ToString().Trim());
                            detalle.Dieciocho = int.Parse(datos["dieciocho"].ToString().Trim());
                            detalle.Veinte = int.Parse(datos["veinte"].ToString().Trim());
                            detalle.Veintidos = int.Parse(datos["Veintidos"].ToString().Trim());
                            detalle.Veinticuatro = int.Parse(datos["veinticuatro"].ToString().Trim());
                            detalle.Ancho = datos["ancho"].ToString().Trim();
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
        public string Agregar(DetalleCuelloUno elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@idCuellos", elemento.IdCuellos));
                    con.Parametros.Add(new IfxParameter("@codigo", elemento.Codigo));
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
                    con.Parametros.Add(new IfxParameter("@ancho", elemento.Ancho.Replace(",", ".")));
                    //con.Parametros.Add(new IfxParameter("@consumo", prmDetalleCon.Consumo.Replace(",", ".")));                    var datos = con.EjecutarConsulta(this.consultaInsert);
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
    }
}
