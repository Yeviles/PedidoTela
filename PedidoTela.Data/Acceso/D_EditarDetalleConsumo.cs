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
        private readonly string consultaGen = "select distinct codi_item, desc_item  from items;";
        private readonly string consultarPorRefTela = "select codi_item, desc_item  from items where codi_item =?;";
        private readonly string consultarPorDescTela = "select codi_item, desc_item  from items where desc_item =?;";

        private readonly string consultaInsert = "INSERT INTO cfc_spt_sol_tela (identificador, tipo, desc_prenda, referencia_tela, desc_tela, consumo, sku, fecha_tienda) VALUES(?, ?, ?, ?, ?, ?, ?, ?);";

        private readonly string consultaPorIdEnsayo = "select identificador, tipo, desc_prenda, referencia_tela, desc_tela, NVL(consumo, '0') AS consumo, sku, fecha_tienda from cfc_spt_sol_tela where tipo ='Ensayo' and identificador = ?;";
        
        private readonly string consultaPorReferencia = "select identificador, tipo, desc_prenda, referencia_tela, desc_tela, consumo, sku, fecha_tienda from cfc_spt_sol_tela where tipo ='Referencia' and identificador = ?;";

        private readonly string consultarId = "select identificador from cfc_spt_sol_tela where identificador =?;";
        
        private readonly string UpdatePorId = "update cfc_spt_sol_tela set referencia_tela=?, desc_tela=?, consumo=?, sku=?, fecha_tienda=? where identificador = ?;";
        #endregion

        #region Métodos
        public void Actualizar(Objeto elemento)
        {
            throw new NotImplementedException();
        }
        
        public List<Objeto> buscarTelaPorReferncia(string prmRefTela)
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var con = new clsConexion())
            {
                con.Parametros.Add(new IfxParameter("@codi_item", prmRefTela));
                var datosDataReader = con.EjecutarConsulta(consultarPorRefTela);
                while (datosDataReader.Read())
                {
                    Objeto obj = new Objeto();
                    obj.Id = datosDataReader["codi_item"].ToString().Trim();
                    obj.Nombre = datosDataReader["desc_item"].ToString().Trim();
                    respuesta.Add(obj);
                };
                con.cerrarConexion();
            }
            return respuesta;
        }
        
        public List<Objeto> buscarTelaPorDescripcion(string prmDescripcion)
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var con = new clsConexion())
            {
                con.Parametros.Add(new IfxParameter("@desc_item", prmDescripcion));
                var datosDataReader = con.EjecutarConsulta(consultarPorDescTela);
                while (datosDataReader.Read())
                {
                    Objeto obj = new Objeto();
                    obj.Id = datosDataReader["codi_item"].ToString().Trim();
                    obj.Nombre = datosDataReader["desc_item"].ToString().Trim();
                    respuesta.Add(obj);
                };
                con.cerrarConexion();
            }
            return respuesta;
        }

        public List<Objeto> consultarTelas()
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var con = new clsConexion())
            {
                var datosDataReader = con.EjecutarConsulta(consultaGen);
                while (datosDataReader.Read())
                {
                    Objeto obj = new Objeto();
                    obj.Id = datosDataReader["codi_item"].ToString().Trim();
                    obj.Nombre = datosDataReader["desc_item"].ToString().Trim();
                    respuesta.Add(obj);
                };
                con.cerrarConexion();
            }
            return respuesta;
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
                    con.Parametros.Add(new IfxParameter("@desc_prenda", prmDetalleCon.Desc_prenda));
                    con.Parametros.Add(new IfxParameter("@referencia_tela", prmDetalleCon.Referencia_tela));
                    con.Parametros.Add(new IfxParameter("@desc_tela", prmDetalleCon.Desc_tela));
                    con.Parametros.Add(new IfxParameter("@consumo", prmDetalleCon.Consumo));
                    con.Parametros.Add(new IfxParameter("@sku", prmDetalleCon.Sku));
                    con.Parametros.Add(new IfxParameter("@fecha_tienda", prmDetalleCon.Fecha_tienda));
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
        
        public string setDcEditadoPorEnsayo(EditarDetalleconsumo prmDetalleCon,string prmEditar)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@ referencia_tela", prmDetalleCon.Referencia_tela));
                    con.Parametros.Add(new IfxParameter("@desc_tela", prmDetalleCon.Desc_tela));
                    con.Parametros.Add(new IfxParameter("@consumo", decimal.Parse(prmDetalleCon.Consumo)));
                    con.Parametros.Add(new IfxParameter("@sku", prmDetalleCon.Sku));
                    con.Parametros.Add(new IfxParameter("@fecha_tienda", prmDetalleCon.Fecha_tienda));
                    
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
            using (var administrador = new clsConexion())
            {
                administrador.Parametros.Add(new IfxParameter("@identificador", prmIdensayo));
                var datos = administrador.EjecutarConsulta(consultaPorIdEnsayo);
                while (datos.Read())
                {
                    EditarDetalleconsumo objDetalle = new EditarDetalleconsumo();

                    objDetalle.Identificador = datos["identificador"].ToString().Trim();
                    objDetalle.Tipo = datos["tipo"].ToString().Trim();
                    objDetalle.Desc_prenda = datos["desc_prenda"].ToString().Trim();
                    objDetalle.Referencia_tela = datos["referencia_tela"].ToString().Trim();
                    objDetalle.Desc_tela = datos["desc_tela"].ToString().Trim();
                    objDetalle.Consumo = datos["consumo"].ToString().Trim();
                    objDetalle.Sku = datos["sku"].ToString().Trim();
                    objDetalle.Fecha_tienda = datos["fecha_tienda"].ToString().Trim();

                    respuesta.Add(objDetalle);
             
                };
                administrador.cerrarConexion();
            }
            return respuesta;
            #endregion
        }
        
        public List<EditarDetalleconsumo> ConsultarDtEditadoPorRef(string prmIdReferencia)
        {

            List<EditarDetalleconsumo> respuesta = new List<EditarDetalleconsumo>();
            using (var administrador = new clsConexion())
            {
                administrador.Parametros.Add(new IfxParameter("@identificador", prmIdReferencia));
                var datos = administrador.EjecutarConsulta(consultaPorReferencia);
                while (datos.Read())
                {
                    EditarDetalleconsumo objDetalle = new EditarDetalleconsumo();

                    objDetalle.Identificador = datos["identificador"].ToString().Trim();
                    objDetalle.Tipo = datos["tipo"].ToString().Trim();
                    objDetalle.Desc_prenda = datos["desc_prenda"].ToString().Trim();
                    objDetalle.Referencia_tela = datos["referencia_tela"].ToString().Trim();
                    objDetalle.Desc_tela = datos["desc_tela"].ToString().Trim();
                    objDetalle.Consumo = datos["consumo"].ToString().Trim();
                    objDetalle.Sku = datos["sku"].ToString().Trim();
                    objDetalle.Fecha_tienda = datos["fecha_tienda"].ToString().Trim();

                    respuesta.Add(objDetalle);
                };
                administrador.cerrarConexion();
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

    }
}
