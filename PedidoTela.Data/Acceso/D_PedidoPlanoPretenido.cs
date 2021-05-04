using IBM.Data.Informix;
using PedidoTela.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_PedidoPlanoPretenido
    {
        #region Consultas
        private readonly string consultaInsert = "INSERT INTO cfc_spt_ped_plano (nom_tela,disenador,ensayo_ref,desc_prenda,clase,tipo_marcacion,rendimiento,analista_corteb,fecha_llegada,id_sol_tela) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";

        private readonly string consultaIdentificador = "SELECT ensayo_ref FROM cfc_spt_ped_plano WHERE id_sol_tela = ?;";

        private readonly string actualizar = "UPDATE cfc_spt_ped_plano SET nom_tela=?,disenador=?, ensayo_ref=?, desc_prenda=?,clase=?, tipo_marcacion=?, rendimiento=?, analista_corteb=?, fecha_llegada=? WHERE id_sol_tela =?; ";

        #endregion
        #region Método Agregar
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
        #region Métodos Consulta
        public bool consultarIdentificador(int prmIdSolicitudTela)
        {
            string ensayo;
            using (var administrador = new clsConexion())
            {
                try
                {
                    administrador.Parametros.Add(new IfxParameter("@id_sol_tela", prmIdSolicitudTela));
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

        #region Métodos actualizar
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
