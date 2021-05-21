using IBM.Data.Informix;
using PedidoTela.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_PedidoCoordinado
    {
        #region consultas
        private readonly string consultaInsert = "INSERT INTO cfc_spt_ped_coordinado (id_solicitud, nom_tela, disenador, " +
            "ensayo_ref, desc_prenda, clase, tipo_marcacion, rendimiento, analista_corteb, fecha_llegada) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";

        private readonly string consultaId = "SELECT id_ped_coordinado FROM cfc_spt_ped_coordinado WHERE id_solicitud = ?;";

        private readonly string consultaPorId = "SELECT ensayo_ref FROM cfc_spt_ped_coordinado WHERE id_solicitud = ?;";

        private readonly string actualizar = "UPDATE cfc_spt_ped_coordinado SET nom_tela=?, disenador=?, ensayo_ref=?, " +
            "desc_prenda=?,clase=?, tipo_marcacion=?, rendimiento=?, analista_corteb=?, fecha_llegada=? WHERE id_solicitud = ?; ";

        private readonly string consutarTodo = "SELECT id_ped_coordinado, nom_tela, disenador, ensayo_ref, desc_prenda, clase, tipo_marcacion, rendimiento, analista_corteb, fecha_llegada " +
            "FROM cfc_spt_ped_coordinado WHERE id_solicitud =?;";
        #endregion

        public PedidoAMontar Consultar(int idSolicitud)
        {
            PedidoAMontar pedido = new PedidoAMontar();
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_solicitud", idSolicitud));
                    var datos = con.EjecutarConsulta(consutarTodo);
                    while (datos.Read())
                    {
                        pedido.Id = int.Parse(datos["id_ped_coordinado"].ToString());
                        pedido.Tela = datos["nom_tela"].ToString();
                        pedido.Disenador = datos["disenador"].ToString();
                        pedido.EnsayoReferencia = datos["ensayo_ref"].ToString();
                        pedido.DescripcionPrenda = datos["desc_prenda"].ToString();
                        pedido.Clase = datos["clase"].ToString();
                        pedido.TipoMarcacion = datos["tipo_marcacion"].ToString();
                        pedido.Rendimiento = decimal.Parse(datos["rendimiento"].ToString());
                        pedido.AnalistasCortesB = datos["analista_corteb"].ToString();
                        pedido.FechaLlegada = datos["fecha_llegada"].ToString();

                    }
                    con.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return pedido;
        }

        public int ConsultarId(int idSolicitud)
        {
            int id = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    conexion.Parametros.Add(new IfxParameter("@id_solicitud", idSolicitud));
                    var datos = conexion.EjecutarConsulta(consultaId);
                    datos.Read();
                    id = int.Parse(datos["id_ped_coordinado"].ToString());

                    conexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return id;
        }

        public bool consultarExistePedido(int idSolicitud)
        {
            string ensayo;
            using (var administrador = new clsConexion())
            {
                try
                {
                    administrador.Parametros.Add(new IfxParameter("@id_solicitud", idSolicitud));
                    var datos = administrador.EjecutarConsulta(consultaPorId);
                    datos.Read();
                    ensayo = datos["ensayo_ref"].ToString().Trim();
                    administrador.cerrarConexion();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public string Agregar(PedidoAMontar elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_solicitud", elemento.IdSolicitud));
                    con.Parametros.Add(new IfxParameter("@nom_tela", elemento.Tela));
                    con.Parametros.Add(new IfxParameter("@disenador", elemento.Disenador));
                    con.Parametros.Add(new IfxParameter("@ensayo_ref", elemento.EnsayoReferencia));
                    con.Parametros.Add(new IfxParameter("@desc_prenda", elemento.DescripcionPrenda));
                    con.Parametros.Add(new IfxParameter("@clase", elemento.Clase));
                    con.Parametros.Add(new IfxParameter("@tipo_marcacion", elemento.TipoMarcacion));
                    con.Parametros.Add(new IfxParameter("@rendimiento", elemento.Rendimiento));
                    con.Parametros.Add(new IfxParameter("@analista_corteb", elemento.AnalistasCortesB));
                    con.Parametros.Add(new IfxParameter("@fecha_llegada", elemento.FechaLlegada));

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

                    con.Parametros.Add(new IfxParameter("@id_solicitud", elemento.IdSolicitud));
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
    }
}
