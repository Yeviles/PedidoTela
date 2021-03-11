using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidoTela.Data.Acceso
{

    public class D_EditarDetalleConsumo
    {
        #region Consultas

        private readonly string consultaInsert = "INSERT INTO cfc_spt_sol_tela (identificador, tipo, desc_prenda, referencia_tela, desc_tela, consumo, sku, fecha_tienda) VALUES(?, ?, ?, ?, ?, ?, ?, ?);";

        private readonly string consultaPorIdEnsayo = "SELECT identificador, st.tipo, desc_prenda, referencia_tela, desc_tela, NVL(ts.tipo, '') as tipo_solicitud, NVL(consumo, '0') AS consumo, sku, fecha_tienda FROM cfc_spt_sol_tela st left join cfc_spt_tipo_solicitud ts on st.identificador = ts.id_solicitud WHERE st.tipo ='Ensayo' and identificador =  ?;";

        private readonly string consultaPorReferencia = "SELECT identificador, st.tipo, desc_prenda, referencia_tela, desc_tela, NVL(ts.tipo, '') as tipo_solicitud, NVL(consumo, '0') AS consumo, sku, fecha_tienda FROM cfc_spt_sol_tela st left join cfc_spt_tipo_solicitud ts on st.identificador = ts.id_solicitud WHERE st.tipo = 'Referencia' and identificador = ?;";

        private readonly string consultarId = "select identificador from cfc_spt_sol_tela where identificador =?;";

        private readonly string UpdatePorId = "update cfc_spt_sol_tela set referencia_tela=?, desc_tela=?, consumo=?, sku=?, fecha_tienda=? where identificador = ?;";
        #endregion

        #region Métodos
        public void Actualizar(Objeto elemento)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string addDetalleConsumo(EditarDetalleconsumo prmDetalleCon)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {

                    con.Parametros.Add(new IfxParameter("@identificador", prmDetalleCon.Identificador));
                    con.Parametros.Add(new IfxParameter("@tipo", prmDetalleCon.Tipo));
                    con.Parametros.Add(new IfxParameter("@desc_prenda", prmDetalleCon.DescripcionPrenda));
                    con.Parametros.Add(new IfxParameter("@referencia_tela", prmDetalleCon.ReferenciaTela));
                    con.Parametros.Add(new IfxParameter("@desc_tela", prmDetalleCon.DescripcionTela));
                    con.Parametros.Add(new IfxParameter("@consumo", prmDetalleCon.Consumo.Replace(",", ".")));
                    con.Parametros.Add(new IfxParameter("@sku", prmDetalleCon.Sku));
                    con.Parametros.Add(new IfxParameter("@fecha_tienda", prmDetalleCon.FechaTienda));
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

        public string setDcEditadoPorEnsayo(EditarDetalleconsumo prmDetalleCon, string prmEditar)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@referencia_tela", prmDetalleCon.ReferenciaTela));
                    con.Parametros.Add(new IfxParameter("@desc_tela", prmDetalleCon.DescripcionTela));
                    con.Parametros.Add(new IfxParameter("@consumo", prmDetalleCon.Consumo.Replace(",", ".")));
                    con.Parametros.Add(new IfxParameter("@sku", prmDetalleCon.Sku));
                    con.Parametros.Add(new IfxParameter("@fecha_tienda", prmDetalleCon.FechaTienda));

                    con.Parametros.Add(new IfxParameter("@identificador", prmEditar));
                    var datos = con.EjecutarConsulta(UpdatePorId);

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

        public List<EditarDetalleconsumo> ConsultarDCEditadoPorEnsayo(string prmIdensayo)
        {
            bool b;
            List<EditarDetalleconsumo> respuesta = new List<EditarDetalleconsumo>();
            try
            {
                using (var administrador = new clsConexion())
                {
                    administrador.Parametros.Add(new IfxParameter("@identificador", prmIdensayo));
                    var datos = administrador.EjecutarConsulta(consultaPorIdEnsayo);
                    while (datos.Read())
                    {
                        EditarDetalleconsumo objDetalle = new EditarDetalleconsumo();

                        objDetalle.Identificador = datos["identificador"].ToString().Trim();
                        objDetalle.Tipo = datos["tipo"].ToString().Trim();
                        objDetalle.DescripcionPrenda = datos["desc_prenda"].ToString().Trim();
                        objDetalle.ReferenciaTela = datos["referencia_tela"].ToString().Trim();
                        objDetalle.DescripcionTela = datos["desc_tela"].ToString().Trim();
                        objDetalle.TipoSolicitud = datos["tipo_solicitud"].ToString().Trim();
                        objDetalle.Consumo = datos["consumo"].ToString().Trim();
                        objDetalle.Sku = datos["sku"].ToString().Trim();
                        objDetalle.FechaTienda = datos["fecha_tienda"].ToString().Trim();

                        respuesta.Add(objDetalle);

                    }
                    administrador.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return respuesta;
        }

        public List<EditarDetalleconsumo> ConsultarDtEditadoPorRef(string prmIdReferencia)
        {

            List<EditarDetalleconsumo> respuesta = new List<EditarDetalleconsumo>();
            try
            {
                using (var administrador = new clsConexion())
                {
                    administrador.Parametros.Add(new IfxParameter("@identificador", prmIdReferencia));
                    var datos = administrador.EjecutarConsulta(consultaPorReferencia);
                    while (datos.Read())
                    {
                        EditarDetalleconsumo objDetalle = new EditarDetalleconsumo();

                        objDetalle.Identificador = datos["identificador"].ToString().Trim();
                        objDetalle.Tipo = datos["tipo"].ToString().Trim();
                        objDetalle.DescripcionPrenda = datos["desc_prenda"].ToString().Trim();
                        objDetalle.ReferenciaTela = datos["referencia_tela"].ToString().Trim();
                        objDetalle.DescripcionTela = datos["desc_tela"].ToString().Trim();
                        objDetalle.TipoSolicitud = datos["tipo_solicitud"].ToString().Trim();
                        objDetalle.Consumo = datos["consumo"].ToString().Trim();
                        objDetalle.Sku = datos["sku"].ToString().Trim();
                        objDetalle.FechaTienda = datos["fecha_tienda"].ToString().Trim();

                        respuesta.Add(objDetalle);
                    }
                    administrador.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return respuesta;
        }

        public bool consultarIdentificador(string prmIdentificador)
        {
            string ensayo;
            using (var administrador = new clsConexion())
            {
                try
                {
                    administrador.Parametros.Add(new IfxParameter("@identificador", prmIdentificador));
                    var datos = administrador.EjecutarConsulta(consultarId);
                    datos.Read();
                    ensayo = datos["identificador"].ToString().Trim();
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

    }
}
