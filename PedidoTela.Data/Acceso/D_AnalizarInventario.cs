using IBM.Data.Informix;
using PedidoTela.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_AnalizarInventario
    {
        #region Consultas
        private readonly string UpdateEstado = " update cfc_spt_tipo_solicitud set estado =?, fecha_estado=? where id_solicitud = ?;";
        private readonly string UpdateMaReservar = "update cfc_spt_sol_tela set m_reservar =? where idsolicitud = ?;";
        private readonly string actualizar = "update cfc_spt_sol_tela set m_calculados=?, m_reservar =?, m_solicitar=? where idsolicitud = ?;";
        private readonly string consultarTodo = "select identificador, NVL(m_calculados,'') as m_calculados,  NVL(m_reservar,'') as m_reservar,  NVL(m_solicitar,'') as m_solicitar,consumo from cfc_spt_sol_tela where idsolicitud = ? ;";
        
        #endregion
        public string setEstadoSolicitud(int idSolTela, string estado, string fechaEstado)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {

                    con.Parametros.Add(new IfxParameter("@estado", estado));
                    con.Parametros.Add(new IfxParameter("@fecha_estado", fechaEstado));
                    con.Parametros.Add(new IfxParameter("@id_solicitud", idSolTela));
                    var datos = con.EjecutarConsulta(UpdateEstado);

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

        
        public string setMaReservar(int  idSolTela, string maReservar)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {

                    con.Parametros.Add(new IfxParameter("@m_reservar", maReservar));
                    con.Parametros.Add(new IfxParameter("@idsolicitud", idSolTela));
                    var datos = con.EjecutarConsulta(UpdateMaReservar);

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
        
        public string Actualizar(int idSolTela, string mCalculados, string maReservar, string maSolicitar)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {

                    con.Parametros.Add(new IfxParameter("@m_calcular", mCalculados));
                    con.Parametros.Add(new IfxParameter("@m_reservar", maReservar));
                    con.Parametros.Add(new IfxParameter("@m_solicitar", maSolicitar));
                    con.Parametros.Add(new IfxParameter("@idsolicitud", idSolTela));
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

        public List<AnalizarInventario> Consultar(int idSolTela)
        {
            List<AnalizarInventario> lista = new List<AnalizarInventario>();
            try
            {
                using (var con = new clsConexion())
                {
                    AnalizarInventario detalle = new AnalizarInventario();
                    con.Parametros.Add(new IfxParameter("@idsolicitud ", idSolTela));
                    var datos = con.EjecutarConsulta(this.consultarTodo);
                    while (datos.Read())
                    {

                        detalle.Similar = datos["identificador"].ToString();
                        detalle.MCalculados = datos["m_calculados"].ToString();
                        detalle.MaSolicitar = datos["m_solicitar"].ToString();
                        detalle.MReservados = datos["m_reservar"].ToString();
                        detalle.Consumo = datos["consumo"].ToString();

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
    }
}

