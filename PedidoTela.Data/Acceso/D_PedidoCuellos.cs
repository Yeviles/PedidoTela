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
    public class D_PedidoCuellos
    {
        #region consultas
        private readonly string consultaInsert = "INSERT INTO cfc_spt_ped_cuellos (ensayo_ref,disenador,analista_corteb,fecha_llegada,tipo_marcacion,desc_prenda,id_sol_tela)VALUES(?, ?, ?, ?, ?, ?, ?);";
         
        private readonly string consultaId = "SELECT id_ped_cuellos FROM cfc_spt_ped_cuellos WHERE id_sol_tela = ?;";

        private readonly string consultarTodo = "SELECT id_ped_cuellos,ensayo_ref,disenador,analista_corteb,fecha_llegada,tipo_marcacion,desc_prenda FROM cfc_spt_ped_cuellos WHERE id_sol_tela=?;";

        private readonly string actualizar = "UPDATE cfc_spt_ped_cuellos SET ensayo_ref=?, disenador=?, analista_corteb=?,fecha_llegada=?, tipo_marcacion=?,desc_prenda=? WHERE id_sol_tela =?; ";

        private readonly string consultaIdentificador = "SELECT ensayo_ref FROM cfc_spt_ped_cuellos WHERE id_sol_tela = ?;";

        #endregion
        #region Métodos Agregar
        public string Agregar(PedidoAMontar elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {

                    con.Parametros.Add(new IfxParameter("@ensayo_ref", elemento.EnsayoReferencia));
                    con.Parametros.Add(new IfxParameter("@disenador", elemento.Disenador));
                    con.Parametros.Add(new IfxParameter("@analista_corteb", elemento.AnalistasCortesB));
                    con.Parametros.Add(new IfxParameter("@fecha_llegada", elemento.FechaLlegada));
                    con.Parametros.Add(new IfxParameter("@tipo_marcacion", elemento.TipoMarcacion));
                    con.Parametros.Add(new IfxParameter("@desc_prenda", elemento.DescripcionPrenda));
                    con.Parametros.Add(new IfxParameter("@id_sol_tela", elemento.IdSolicitud));

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
        #endregion

        #region Métodos Consulta
        
        public PedidoAMontar Consultar(int prmIdSolicitud)
        {
            PedidoAMontar pedidoCuellos = new PedidoAMontar();
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_sol_tela", prmIdSolicitud));
                    var datos = con.EjecutarConsulta(consultarTodo);
                    while (datos.Read())
                    {
                        pedidoCuellos.Id = int.Parse(datos["id_ped_cuellos"].ToString());
                        pedidoCuellos.EnsayoReferencia = datos["ensayo_ref"].ToString();
                        pedidoCuellos.Disenador = datos["disenador"].ToString();
                        pedidoCuellos.AnalistasCortesB = datos["analista_corteb"].ToString();
                        pedidoCuellos.FechaLlegada = datos["fecha_llegada"].ToString();
                        pedidoCuellos.TipoMarcacion = datos["tipo_marcacion"].ToString();
                        pedidoCuellos.DescripcionPrenda = datos["desc_prenda"].ToString();
                       
                    }
                    con.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return pedidoCuellos;
        }

        public int ConsultarId(int idSolTela)
        {
            int id = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    conexion.Parametros.Add(new IfxParameter("@id_sol_tela", idSolTela));
                    var datos = conexion.EjecutarConsulta(consultaId);
                    datos.Read();
                    id = int.Parse(datos["id_ped_cuellos"].ToString());

                    conexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return id;
        }

        public bool consultarExistePedido(int idSolTela)
        {
            string ensayo;
            using (var administrador = new clsConexion())
            {
                try
                {
                    administrador.Parametros.Add(new IfxParameter("@id_sol_tela", idSolTela));
                    var datos = administrador.EjecutarConsulta(consultaIdentificador);
                    datos.Read();
                    ensayo = datos["ensayo_ref"].ToString().Trim();
                    administrador.cerrarConexion();

                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        #endregion

        #region Métodos Actualizar
        public string Actualizar(PedidoAMontar elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@ensayo_ref", elemento.EnsayoReferencia));
                    con.Parametros.Add(new IfxParameter("@disenador", elemento.Disenador));
                    con.Parametros.Add(new IfxParameter("@analista_corteb", elemento.AnalistasCortesB));
                    con.Parametros.Add(new IfxParameter("@fecha_llegada", elemento.FechaLlegada));
                    con.Parametros.Add(new IfxParameter("@tipo_marcacion", elemento.TipoMarcacion));
                    con.Parametros.Add(new IfxParameter("@desc_prenda", elemento.DescripcionPrenda));

                    con.Parametros.Add(new IfxParameter("@id_sol_tela", elemento.IdSolicitud));
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
