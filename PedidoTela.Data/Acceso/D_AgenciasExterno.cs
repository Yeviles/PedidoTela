using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
   public  class D_AgenciasExterno
    {
        #region Consultas 
        private readonly string consultaInsert = "INSERT INTO cfc_spt_agencias_externos (solicitado_por, id_sol_tela, nombre_tela, disenador, cargo, telefono, ensayo_ref, departamento, ancho_tela, proveedor, orden_compra, extencion, desc_prenda, rendimiento, contacto, pedido_agencia, composicion, tipo_marcacion, nit, fecha_llegada_tela)  VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ? );";

        private readonly string consultaIdentificador = "SELECT ensayo_ref FROM cfc_spt_agencias_externos WHERE id_sol_tela = ?;";

        private readonly string actualizar = "UPDATE cfc_spt_agencias_externos SET solicitado_por=?, nombre_tela=?, disenador=?, cargo=?, telefono=?, ensayo_ref=?, departamento=?, ancho_tela=?, proveedor=?, orden_compra=?, extencion=?, desc_prenda=?, rendimiento=?, contacto=?, pedido_agencia=?, composicion=?, tipo_marcacion=?, nit=?, fecha_llegada_tela=? WHERE id_sol_tela =?;";

        private readonly string consultaId = "SELECT id_agencias FROM cfc_spt_agencias_externos WHERE id_sol_tela = ?;";

        private readonly string consutarTodo = "SELECT solicitado_por,id_agencias, nombre_tela, disenador, cargo, telefono, ensayo_ref, departamento, ancho_tela, proveedor, orden_compra, extencion, desc_prenda, rendimiento, contacto, pedido_agencia, composicion, tipo_marcacion, nit, fecha_llegada_tela, id_sol_tela FROM cfc_spt_agencias_externos WHERE id_sol_tela =?; ";
        #endregion
       
        #region Métodos Agregar
        public string Agregar(AgenciasExternos elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                   
                    con.Parametros.Add(new IfxParameter("@solicitado_por", elemento.SolicitadoPor));
                    con.Parametros.Add(new IfxParameter("@id_sol_tela", elemento.IdSolTela));
                    con.Parametros.Add(new IfxParameter("@nombre_tela", elemento.NombreTela));
                    con.Parametros.Add(new IfxParameter("@disenador", elemento.Disenadora));
                    con.Parametros.Add(new IfxParameter("@cargo", elemento.Cargo));
                    con.Parametros.Add(new IfxParameter("@telefono", elemento.Telefono));
                    con.Parametros.Add(new IfxParameter("@ensayo_ref", elemento.EnsayoRef));
                    con.Parametros.Add(new IfxParameter("@departamento", elemento.Departamento));
                    con.Parametros.Add(new IfxParameter("@ancho_tela", elemento.AnchoTela));
                    con.Parametros.Add(new IfxParameter("@proveedor", elemento.Proveedor));
                    con.Parametros.Add(new IfxParameter("@orden_compra", elemento.OrdenCompra));
                    con.Parametros.Add(new IfxParameter("@extencion", elemento.Extencion));
                    con.Parametros.Add(new IfxParameter("@desc_prenda", elemento.DescPrenda));
                    con.Parametros.Add(new IfxParameter("@rendimiento", elemento.Rendimiento));
                    con.Parametros.Add(new IfxParameter("@contacto", elemento.Contacto));
                    con.Parametros.Add(new IfxParameter("@pedido_agencia", elemento.PedidoAgencia));
                    con.Parametros.Add(new IfxParameter("@composicion", elemento.Composicion));
                    con.Parametros.Add(new IfxParameter("@tipo_marcacion", elemento.TipoMarcacion));
                    con.Parametros.Add(new IfxParameter("@nit", elemento.Nit));
                    con.Parametros.Add(new IfxParameter("@fecha_llegada_tela", elemento.FechaLlegadaTela));

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
       
        #region Métodos ColsuLta
        public bool consultarExisteAgencias(int idSolTela)
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
        
        public AgenciasExternos Consultar(int idDolTela)
        {
            AgenciasExternos agencias = new AgenciasExternos();
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_sol_tela", idDolTela));
                    var datos = con.EjecutarConsulta(consutarTodo);
                    while (datos.Read())
                    {                   
                        agencias.IdAgencias = int.Parse(datos["id_agencias"].ToString());
                        agencias.SolicitadoPor = datos["solicitado_por"].ToString();
                        agencias.NombreTela = datos["nombre_tela"].ToString();
                        agencias.Disenadora = datos["disenador"].ToString();
                        agencias.Cargo = datos["cargo"].ToString();
                        agencias.Telefono = datos["telefono"].ToString();
                        agencias.EnsayoRef = datos["ensayo_ref"].ToString();
                        agencias.Departamento = datos["departamento"].ToString();
                        agencias.AnchoTela = decimal.Parse(datos["ancho_tela"].ToString());
                        agencias.Proveedor = datos["proveedor"].ToString();
                        agencias.OrdenCompra = datos["orden_compra"].ToString();
                        agencias.Extencion = datos["extencion"].ToString();
                        agencias.DescPrenda = datos["desc_prenda"].ToString();
                        agencias.Rendimiento = decimal.Parse(datos["rendimiento"].ToString());
                        agencias.Contacto = datos["contacto"].ToString().Trim();
                        agencias.PedidoAgencia = datos["pedido_agencia"].ToString();
                        agencias.Composicion = datos["composicion"].ToString();
                        agencias.TipoMarcacion = datos["tipo_marcacion"].ToString();
                        agencias.Nit = datos["nit"].ToString();
                        agencias.FechaLlegadaTela = datos["fecha_llegada_tela"].ToString();     
                          
                    }
                    con.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return agencias;
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
                    id = int.Parse(datos["id_agencias"].ToString());

                    conexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return id;
        }

        #endregion

        #region Métodos Actualizar
        public string Actualizar(AgenciasExternos elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@solicitado_por", elemento.SolicitadoPor));
                    con.Parametros.Add(new IfxParameter("@nombre_tela", elemento.NombreTela));
                    con.Parametros.Add(new IfxParameter("@disenador", elemento.Disenadora));
                    con.Parametros.Add(new IfxParameter("@cargo", elemento.Cargo));
                    con.Parametros.Add(new IfxParameter("@telefono", elemento.Telefono));
                    con.Parametros.Add(new IfxParameter("@ensayo_ref", elemento.EnsayoRef));
                    con.Parametros.Add(new IfxParameter("@departamento", elemento.Departamento));
                    con.Parametros.Add(new IfxParameter("@ancho_tela", elemento.AnchoTela));
                    con.Parametros.Add(new IfxParameter("@proveedor", elemento.Proveedor));
                    con.Parametros.Add(new IfxParameter("@orden_compra", elemento.OrdenCompra));
                    con.Parametros.Add(new IfxParameter("@extencion", elemento.Extencion));
                    con.Parametros.Add(new IfxParameter("@desc_prenda", elemento.DescPrenda));
                    con.Parametros.Add(new IfxParameter("@rendimiento", elemento.Rendimiento));
                    con.Parametros.Add(new IfxParameter("@contacto", elemento.Contacto));
                    con.Parametros.Add(new IfxParameter("@pedido_agencia", elemento.PedidoAgencia));
                    con.Parametros.Add(new IfxParameter("@composicion", elemento.Composicion));  
                    con.Parametros.Add(new IfxParameter("@tipo_marcacion", elemento.TipoMarcacion));  
                    con.Parametros.Add(new IfxParameter("@nit", elemento.Nit));
                    con.Parametros.Add(new IfxParameter("@fecha_llegada_tela", elemento.FechaLlegadaTela));

                    con.Parametros.Add(new IfxParameter("@id_sol_tela", elemento.IdSolTela));
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
