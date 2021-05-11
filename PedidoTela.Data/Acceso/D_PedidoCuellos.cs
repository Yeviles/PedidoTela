using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_PedidoCuellos
    {
        #region consultas

        private readonly string consultarIdCuellos = "SELECT idcuellos from cfc_spt_sol_cuellos WHERE id_sol_tela =?;";

        private readonly string consultarTodo = "SELECT codigo,xs,s,m,l,xl,dosxl,cuatro,seis,ocho,diez,doce,catorce,dieciseis,dieciocho,veinte,veintidos,veinticuatro,ancho,nombre FROM cfc_spt_sol_detalle_cuello_uno WHERE idCuellos = ?;";

        #endregion
        #region Métodos Consulta
        public List<int> ConsultarIdDetalles(List<int> prmIdSolicitud)
        {
            List<int> lista = new List<int>();
            try
            {                
                for (int i = 0; i < prmIdSolicitud.Count; i++)
                {
                    using (var con = new clsConexion())
                    {
                        con.Parametros.Add(new IfxParameter("@id_sol_tela", prmIdSolicitud[i]));
                        var datos = con.EjecutarConsulta(this.consultarIdCuellos);
                        while (datos.Read())
                        {
                            int id = int.Parse(datos["idcuellos"].ToString());
                            lista.Add(id);
                        }
                        con.cerrarConexion();
                    }
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return lista;
        }
        
        public List<PedidoCuellos> Consultar(List<int> prmIdCuellos)
        {
            List<PedidoCuellos> lista = new List<PedidoCuellos>();
            try
            {              
                for (int i = 0; i < prmIdCuellos.Count; i++)
                {
                    using (var con = new clsConexion())
                    {
                        con.Parametros.Add(new IfxParameter("@idcuellos", prmIdCuellos[i]));
                        var datos = con.EjecutarConsulta(this.consultarTodo);
                        while (datos.Read())
                        {
                            PedidoCuellos detalle = new PedidoCuellos();
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
                            detalle.TipoTejido = datos["nombre"].ToString().Trim();

                            lista.Add(detalle);
                        }
                        con.cerrarConexion();
                    }
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
