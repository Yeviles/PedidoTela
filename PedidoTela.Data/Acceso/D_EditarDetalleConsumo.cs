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

        private readonly string consultaInsert = "INSERT INTO cfc_spt_sol_tela (identificador,idmundo,codi_capsula,codi_entrada, tipo, desc_prenda, referencia_tela, desc_tela, consumo, sku, fecha_tienda,muestrario,idusuario,codi_linea) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?);";

        private readonly string consultaPorIdEnsayo = " SELECT st.identificador, st.tipo, desc_prenda, referencia_tela, desc_tela, NVL(ts.tipo, '') as tipo_solicitud, NVL(consumo, '0') AS consumo, sku, fecha_tienda, muestrario, st.idsolicitud " +
                                                      "  FROM cfc_spt_sol_tela st " +
                                                      "  left join cfc_spt_tipo_solicitud ts " +
                                                      "  on st.idsolicitud = ts.id_solicitud " +
                                                      "  WHERE st.tipo = 'Ensayo' and st.identificador = ?;";
        
        private readonly string consultaPorReferencia = "SELECT st.identificador, st.tipo, desc_prenda, referencia_tela, desc_tela, NVL(ts.tipo, '') as tipo_solicitud, NVL(consumo, '0') AS consumo, sku, fecha_tienda,muestrario,st.idsolicitud " +
                                                        "FROM cfc_spt_sol_tela st " +
                                                        "left join cfc_spt_tipo_solicitud ts " +
                                                        "on st.idsolicitud = ts.id_solicitud " +
                                                        "WHERE st.tipo = 'Referencia' and st.identificador = ?;";

        private readonly string consultarId = "select identificador from cfc_spt_sol_tela where identificador =?;";

        private readonly string UpdatePorId = "update cfc_spt_sol_tela set referencia_tela=?, desc_tela=?, consumo=?, sku=?, fecha_tienda=? where identificador = ? and idsolicitud = ?;";
        
        private readonly string iserttodo = "INSERT INTO cfc_spt_sol_tela (identificador,idmundo,codi_capsula,codi_entrada, tipo, desc_prenda, referencia_tela, desc_tela, consumo, sku, fecha_tienda,muestrario,idusuario,codi_linea) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?,?,?,?);";

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
                    con.Parametros.Add(new IfxParameter("@idmundo",prmDetalleCon.Idmundo));
                    con.Parametros.Add(new IfxParameter("@codi_capsula", prmDetalleCon.Codi_capsula));
                    con.Parametros.Add(new IfxParameter("@codi_entrada", prmDetalleCon.Codi_entrada));
                    con.Parametros.Add(new IfxParameter("@tipo", prmDetalleCon.Tipo));
                    con.Parametros.Add(new IfxParameter("@desc_prenda", prmDetalleCon.DescripcionPrenda));
                    con.Parametros.Add(new IfxParameter("@referencia_tela", prmDetalleCon.ReferenciaTela));
                    con.Parametros.Add(new IfxParameter("@desc_tela", prmDetalleCon.DescripcionTela));
                    con.Parametros.Add(new IfxParameter("@consumo", prmDetalleCon.Consumo.Replace(",", ".")));
                    con.Parametros.Add(new IfxParameter("@sku", prmDetalleCon.Sku));
                    con.Parametros.Add(new IfxParameter("@fecha_tienda", prmDetalleCon.FechaTienda));
                    con.Parametros.Add(new IfxParameter("@muestrario", prmDetalleCon.Muestrario));
                    con.Parametros.Add(new IfxParameter("@idusuario", prmDetalleCon.Id_disenador));
                    con.Parametros.Add(new IfxParameter("@codi_linea", prmDetalleCon.Codi_linea));

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

        //public string setDcEditadoPorEnsayo(EditarDetalleconsumo prmDetalleCon, string prmEditar)
        // {
        //     string respuesta = "";
        //     try
        //     {
        //         using (var con = new clsConexion())
        //         {
        //             con.Parametros.Add(new IfxParameter("@idmundo", prmDetalleCon.Idmundo));
        //             con.Parametros.Add(new IfxParameter("@codi_capsula", prmDetalleCon.Codi_capsula));
        //             con.Parametros.Add(new IfxParameter("@codi_entrada", prmDetalleCon.Codi_entrada));
        //             con.Parametros.Add(new IfxParameter("@referencia_tela", prmDetalleCon.ReferenciaTela));
        //             con.Parametros.Add(new IfxParameter("@desc_tela", prmDetalleCon.DescripcionTela));
        //             con.Parametros.Add(new IfxParameter("@consumo", prmDetalleCon.Consumo.Replace(",", ".")));
        //             con.Parametros.Add(new IfxParameter("@sku", prmDetalleCon.Sku));
        //             con.Parametros.Add(new IfxParameter("@fecha_tienda", prmDetalleCon.FechaTienda));
        //             con.Parametros.Add(new IfxParameter("@muestrario", prmDetalleCon.Muestrario));
        //             con.Parametros.Add(new IfxParameter("@idusuario", prmDetalleCon.Id_disenador));
        //             con.Parametros.Add(new IfxParameter("@codi_linea", prmDetalleCon.Codi_linea));

        //             con.Parametros.Add(new IfxParameter("@identificador", prmEditar));
        //             var datos = con.EjecutarConsulta(UpdatePorId);

        //             con.cerrarConexion();
        //         }
        //         respuesta = "ok";
        //     }
        //     catch (Exception ex)
        //     {
        //         respuesta = "Error: " + ex.Message;
        //     }
        //     return respuesta;
        // }
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
                    con.Parametros.Add(new IfxParameter("@idsolicitud", prmDetalleCon.Idsolicitud));
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
            //bool b;
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
                        objDetalle.Muestrario = datos["muestrario"].ToString().Trim();
                        objDetalle.Idsolicitud =int.Parse(datos["idsolicitud"].ToString().Trim());

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
                        objDetalle.Muestrario = datos["muestrario"].ToString().Trim();
                        objDetalle.Idsolicitud = int.Parse(datos["idsolicitud"].ToString().Trim());

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

        /// <summary>
        /// Método encargado de Agregar a la tabla cfc_spt_sol_tela, cuando es consultada la informacion en la vista frmSolicitudLista. 
        /// </summary>
        /// <param name="prmDetalleCon"> Lista la cual contiene la infomacion ya sea por ensayo o por referencia.</param>
        /// <returns></returns>
        public string Agregar(List<EditarDetalleconsumo> prmDetalleCon)
        {
            string respuesta = "";
            try
            {
              
            for (int i = 0; i < prmDetalleCon.Count; i++)
            {
                using (var con = new clsConexion())
                {
                        con.Parametros.Add(new IfxParameter("@identificador", prmDetalleCon[i].Identificador.ToString()));
                    con.Parametros.Add(new IfxParameter("@idmundo", prmDetalleCon[i].Idmundo.ToString()));
                    con.Parametros.Add(new IfxParameter("@codi_capsula", prmDetalleCon[i].Codi_capsula.ToString()));
                    con.Parametros.Add(new IfxParameter("@codi_entrada", prmDetalleCon[i].Codi_entrada.ToString()));
                    con.Parametros.Add(new IfxParameter("@tipo", prmDetalleCon[i].Tipo.ToString()));
                    con.Parametros.Add(new IfxParameter("@desc_prenda", prmDetalleCon[i].DescripcionPrenda.ToString()));
                    con.Parametros.Add(new IfxParameter("@referencia_tela", prmDetalleCon[i].ReferenciaTela.ToString()));
                    con.Parametros.Add(new IfxParameter("@desc_tela", prmDetalleCon[i].DescripcionTela.ToString()));
                    con.Parametros.Add(new IfxParameter("@consumo", prmDetalleCon[i].Consumo.Replace(",", ".")));
                    con.Parametros.Add(new IfxParameter("@sku", prmDetalleCon[i].Sku.ToString()));
                    con.Parametros.Add(new IfxParameter("@fecha_tienda", prmDetalleCon[i].FechaTienda.ToString()));
                    con.Parametros.Add(new IfxParameter("@muestrario", prmDetalleCon[i].Muestrario.ToString()));
                    con.Parametros.Add(new IfxParameter("@idusuario", prmDetalleCon[i].Id_disenador.ToString()));
                    con.Parametros.Add(new IfxParameter("@codi_linea", prmDetalleCon[i].Codi_linea.ToString()));

                    var datos = con.EjecutarConsulta(iserttodo);
                    con.cerrarConexion();
                }
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
