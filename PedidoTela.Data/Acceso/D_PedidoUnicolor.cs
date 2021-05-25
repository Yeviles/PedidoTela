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
    public class D_PedidoUnicolor
    {
        #region Consultas

        private readonly string consultaInsert = "INSERT INTO cfc_spt_ped_unicolor (nom_tela,disenador,ensayo_ref,desc_prenda,clase,tipo_marcacion,rendimiento,analista_corteb,fecha_llegada,id_sol_tela) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";

        private readonly string consultaId = "SELECT id_ped_unicolor FROM cfc_spt_ped_unicolor WHERE id_sol_tela = ?;";

        private readonly string consultaIdentificador = "SELECT ensayo_ref FROM cfc_spt_ped_unicolor WHERE id_sol_tela = ?;";

        private readonly string actualizar = "UPDATE cfc_spt_ped_unicolor SET nom_tela=?,disenador=?, ensayo_ref=?, desc_prenda=?,clase=?, tipo_marcacion=?, rendimiento=?, analista_corteb=?, fecha_llegada=? WHERE id_sol_tela =?; ";

        private readonly string consutarTodo = "SELECT id_ped_unicolor,nom_tela, disenador, ensayo_ref, desc_prenda, clase, tipo_marcacion, rendimiento, analista_corteb, fecha_llegada FROM cfc_spt_ped_unicolor WHERE id_sol_tela =?;";
        
       
        #endregion

        #region Métodos Agregar
        public string Agregar(PedidoAMontar elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {

                    con.Parametros.Add(new IfxParameter("@nom_tela", elemento.Tela));
                    con.Parametros.Add(new IfxParameter("@disenador", elemento.Disenador));
                    con.Parametros.Add(new IfxParameter("@ensayo_ref", elemento.EnsayoReferencia));
                    con.Parametros.Add(new IfxParameter("@desc_prenda", elemento.DescripcionPrenda));
                    con.Parametros.Add(new IfxParameter("@clase", elemento.Clase));
                    con.Parametros.Add(new IfxParameter("@tipo_marcacion", elemento.TipoMarcacion));
                    con.Parametros.Add(new IfxParameter("@rendimiento", elemento.Rendimiento));
                    con.Parametros.Add(new IfxParameter("@analista_corteb", elemento.AnalistasCortesB));
                    con.Parametros.Add(new IfxParameter("@fecha_llegada", elemento.FechaLlegada));
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

        #region Métodos Consultar
       
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
                    id = int.Parse(datos["id_ped_unicolor"].ToString());

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

        public PedidoAMontar Consultar(int idDolTela)
        {
            PedidoAMontar pedUnicolor = new PedidoAMontar();
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_sol_tela", idDolTela));
                    var datos = con.EjecutarConsulta(consutarTodo);
                    while (datos.Read())
                    {
                        pedUnicolor.Id = int.Parse(datos["id_ped_unicolor"].ToString());
                        pedUnicolor.Tela = datos["nom_tela"].ToString();
                        pedUnicolor.Disenador = datos["disenador"].ToString();
                        pedUnicolor.EnsayoReferencia = datos["ensayo_ref"].ToString();
                        pedUnicolor.DescripcionPrenda = datos["desc_prenda"].ToString();
                        pedUnicolor.Clase = datos["clase"].ToString();
                        pedUnicolor.TipoMarcacion = datos["tipo_marcacion"].ToString();
                        pedUnicolor.Rendimiento = decimal.Parse(datos["rendimiento"].ToString());
                        pedUnicolor.AnalistasCortesB = datos["analista_corteb"].ToString();
                        pedUnicolor.FechaLlegada = datos["fecha_llegada"].ToString();

                    }
                    con.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return pedUnicolor;
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
                    con.Parametros.Add(new IfxParameter("@nom_tela", elemento.Tela));
                    con.Parametros.Add(new IfxParameter("@disenador", elemento.Disenador));
                    con.Parametros.Add(new IfxParameter("@ensayo_ref", elemento.EnsayoReferencia));
                    con.Parametros.Add(new IfxParameter("@desc_prenda", elemento.DescripcionPrenda));
                    con.Parametros.Add(new IfxParameter("@clase", elemento.Clase));
                    con.Parametros.Add(new IfxParameter("@tipo_marcacion", elemento.TipoMarcacion));
                    con.Parametros.Add(new IfxParameter("@rendimiento", elemento.Rendimiento));
                    con.Parametros.Add(new IfxParameter("@analista_corteb", elemento.AnalistasCortesB));
                    con.Parametros.Add(new IfxParameter("@fecha_llegada", elemento.FechaLlegada));

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
