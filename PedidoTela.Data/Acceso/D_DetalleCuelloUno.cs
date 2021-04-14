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
        private readonly string colsultarTodo = "SELECT idDetalleCuelloUno, idCuellos,codigo,xs,s,m,l,xl,dosxl,cuatro,seis,ocho,diez,doce,catorce,dieciseis,dieciocho,veinte,veintidos,veinticuatro,ancho,nombre FROM cfc_spt_sol_detalle_cuello_uno WHERE idCuellos = ?;";
        
        private readonly string consultaInsert = "insert into  cfc_spt_sol_detalle_cuello_uno (idCuellos,codigo,xs,s,m,l,xl,dosxl,cuatro,seis,ocho,diez,doce,catorce,dieciseis,dieciocho,veinte,veintidos,veinticuatro,ancho,nombre)  values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";

        private readonly string consultaId = " SELECT idDetalleCuelloUno FROM cfc_spt_sol_detalle_cuello_uno WHERE  idCuellos =?;";

        private readonly string actualizar = "UPDATE cfc_spt_sol_detalle_cuello_uno SET codigo=?, xs=?, s=?, m=?, l=?, xl=?, dosxl=?, cuatro=?, seis=?, ocho=?, diez=?, doce=?, catorce=?, dieciseis=?, dieciocho=?, veinte=?, veintidos=?, veinticuatro=?, ancho=?, nombre = ? WHERE idDetalleCuelloUno =?;";
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
                            detalle.Xs = datos["xs"].ToString().Trim();
                            detalle.S = datos["s"].ToString().Trim();
                            detalle.M = datos["m"].ToString().Trim();
                            detalle.L = datos["l"].ToString().Trim();
                            detalle.Xl = datos["xl"].ToString().Trim();
                            detalle.Dosxl = datos["dosxl"].ToString().Trim();
                            detalle.Cuatro = datos["cuatro"].ToString();
                            detalle.Seis = datos["seis"].ToString().Trim();
                            detalle.Ocho = datos["ocho"].ToString().Trim();
                            detalle.Diez = datos["diez"].ToString().Trim();
                            detalle.Doce = datos["doce"].ToString().Trim();
                            detalle.Catorce = datos["catorce"].ToString().Trim();
                            detalle.Dieciseis = datos["dieciseis"].ToString().Trim();
                            detalle.Dieciocho = datos["dieciocho"].ToString().Trim();
                            detalle.Veinte = datos["veinte"].ToString().Trim();
                            detalle.Veintidos = datos["Veintidos"].ToString().Trim();
                            detalle.Veinticuatro = datos["veinticuatro"].ToString().Trim();
                            detalle.Ancho = datos["ancho"].ToString().Trim();
                            detalle.NombreChechSel = datos["nombre"].ToString().Trim();
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
                    con.Parametros.Add(new IfxParameter("@nombre", elemento.NombreChechSel));
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
                        id = int.Parse(datos["idDetalleCuelloUno"].ToString());
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

        public string Actualizar(DetalleCuelloUno elemento, int idDetalle)
        {
            string respuesta = "";
            try
            {
                //UPDATE 
                using (var con = new clsConexion())
                {
                    //con.Parametros.Add(new IfxParameter("@idCuellos", elemento.IdCuellos));
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
                    con.Parametros.Add(new IfxParameter("@nombre", elemento.NombreChechSel));

                    //con.Parametros.Add(new IfxParameter("@idunicolor", prmDEttalleEstampado.IdUnicolor));
                    con.Parametros.Add(new IfxParameter("@idDetalleCuelloUno", idDetalle));
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
