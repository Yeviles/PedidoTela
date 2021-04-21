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
        private readonly string consultaIdentificador = "SELECT ensayo_ref FROM cfc_spt_agencias_externos WHERE id_sol_tela = ?;";

        private readonly string actualizar = "UPDATE cfc_spt_agencias_externos SET solicitado_por=?, cargo=?, departamento=?, telefono=?, extencion=?, ref_tela=?, tipo_tejido=?, " +
                                             "fondo=?, nom_tela=?, ancho_tela=?, rendimiento=?, composicion=?, muestrario=?, ocasion_uso=?, tema=?, entrada=?, ensayo_ref =?, fecha_tienda=?, " +
                                             " disenadora=?, desc_prenda=?, proveedor=?, nit=?, contacto=?, pedi_agencia=?, orden_compra=?, fecha_llegadatienda=? WHERE id_sol_tela =?;";

        private readonly string consultaInsert = "INSERT INTO cfc_spt_agencias_externos (solicitado_por,cargo,departamento,telefono,extencion,ref_tela, tipo_tejido," +
            "fondo,nom_tela,ancho_tela,rendimiento,composicion,muestrario,ocasion_uso,tema, entrada, ensayo_ref,fecha_tienda,disenadora, desc_prenda,proveedor, nit,contacto, pedi_agencia, orden_compra,fecha_llegadatienda, id_sol_tela)" +
            " VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
       
        private readonly string consultaId = "SELECT idAgencias FROM cfc_spt_agencias_externos WHERE id_sol_tela = ?;";

        private readonly string consutarTodo = "SELECT idAgencias,solicitado_por,cargo,departamento,telefono,extencion,ref_tela,tipo_tejido,fondo, nom_tela, ancho_tela,rendimiento,composicion,muestrario,ocasion_uso,tema, entrada, ensayo_ref,fecha_tienda,disenadora, desc_prenda, proveedor,nit,contacto,pedi_agencia,orden_compra,fecha_llegadatienda FROM cfc_spt_agencias_externos WHERE id_sol_tela =?; ";
        #endregion
        public bool consultarIdentificador(int idSolTela)
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

        public string Actualizar(AgenciasExternos elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@solicitado_por", elemento.SolicitadoPor));
                    con.Parametros.Add(new IfxParameter("@cargo", elemento.Cargo));
                    con.Parametros.Add(new IfxParameter("@departamento", elemento.Departamento));
                    con.Parametros.Add(new IfxParameter("@telefono", elemento.Telefono));
                    con.Parametros.Add(new IfxParameter("@extencion", elemento.Extencion));
                    con.Parametros.Add(new IfxParameter("@ref_tela", elemento.ReferenciaTela));
                    con.Parametros.Add(new IfxParameter("@tipo_tejido", elemento.TipoTejido));
                    con.Parametros.Add(new IfxParameter("@fondo", elemento.Fondo));
                    con.Parametros.Add(new IfxParameter("@nom_tela", elemento.NombreTela));
                    con.Parametros.Add(new IfxParameter("@ancho_tela", elemento.AnchoTela));
                    con.Parametros.Add(new IfxParameter("@rendimiento", elemento.Rendimiento));
                    con.Parametros.Add(new IfxParameter("@composicion", elemento.Composicion));  
                    con.Parametros.Add(new IfxParameter("@muestrario", elemento.Muestrario));
                    con.Parametros.Add(new IfxParameter("@ocasion_uso", elemento.OcasionUso));
                    con.Parametros.Add(new IfxParameter("@tema", elemento.Tema));
                    con.Parametros.Add(new IfxParameter("@entrada", elemento.Entrada));
                    con.Parametros.Add(new IfxParameter("@ensayo_ref", elemento.EnsayoRef));
                    con.Parametros.Add(new IfxParameter("@fecha_tienda", elemento.FechaTienda));
                    con.Parametros.Add(new IfxParameter("@disenadora", elemento.Disenadora));
                    con.Parametros.Add(new IfxParameter("@desc_prenda", elemento.DescPrenda));
                    con.Parametros.Add(new IfxParameter("@proveedor", elemento.Proveedor));
                    con.Parametros.Add(new IfxParameter("@nit", elemento.Nit));
                    con.Parametros.Add(new IfxParameter("@contacto", elemento.Contacto));
                    con.Parametros.Add(new IfxParameter("@pedi_agencia", elemento.PedidoAgencia));
                    con.Parametros.Add(new IfxParameter("@orden_compra", elemento.OrdenCompra));
                    con.Parametros.Add(new IfxParameter("@fecha_llegadatienda", elemento.FechaLlegadaTela));

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
        
        public string Agregar(AgenciasExternos elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                   
                    con.Parametros.Add(new IfxParameter("@solicitado_por", elemento.SolicitadoPor));
                    con.Parametros.Add(new IfxParameter("@cargo", elemento.Cargo));
                    con.Parametros.Add(new IfxParameter("@departamento", elemento.Departamento));
                    con.Parametros.Add(new IfxParameter("@telefono", elemento.Telefono));
                    con.Parametros.Add(new IfxParameter("@extencion", elemento.Extencion));
                    con.Parametros.Add(new IfxParameter("@ref_tela", elemento.ReferenciaTela));
                    con.Parametros.Add(new IfxParameter("@tipo_tejido", elemento.TipoTejido));
                    con.Parametros.Add(new IfxParameter("@fondo", elemento.Fondo));
                    con.Parametros.Add(new IfxParameter("@nom_tela", elemento.NombreTela));
                    con.Parametros.Add(new IfxParameter("@ancho_tela", elemento.AnchoTela));
                    con.Parametros.Add(new IfxParameter("@rendimiento", elemento.Rendimiento));
                    con.Parametros.Add(new IfxParameter("@composicion", elemento.Composicion));
                    con.Parametros.Add(new IfxParameter("@muestrario", elemento.Muestrario));
                    con.Parametros.Add(new IfxParameter("@ocasion_uso", elemento.OcasionUso));
                    con.Parametros.Add(new IfxParameter("@tema", elemento.Tema));
                    con.Parametros.Add(new IfxParameter("@entrada", elemento.Entrada));
                    con.Parametros.Add(new IfxParameter("@ensayo_ref", elemento.EnsayoRef));
                    con.Parametros.Add(new IfxParameter("@fecha_tienda", elemento.FechaTienda));
                    con.Parametros.Add(new IfxParameter("@disenadora", elemento.Disenadora));
                    con.Parametros.Add(new IfxParameter("@desc_prenda", elemento.DescPrenda));
                    con.Parametros.Add(new IfxParameter("@proveedor", elemento.Proveedor));
                    con.Parametros.Add(new IfxParameter("@nit", elemento.Nit));
                    con.Parametros.Add(new IfxParameter("@contacto", elemento.Contacto));
                    con.Parametros.Add(new IfxParameter("@pedi_agencia", elemento.PedidoAgencia));
                    con.Parametros.Add(new IfxParameter("@orden_compra", elemento.OrdenCompra));
                    con.Parametros.Add(new IfxParameter("@fecha_llegadatienda", elemento.FechaLlegadaTela));
                    con.Parametros.Add(new IfxParameter("@id_sol_tela", elemento.IdSolTela));

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
                    id = int.Parse(datos["idAgencias"].ToString());

                    conexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return id;
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
                        agencias.IdAgencias = int.Parse(datos["idAgencias"].ToString());
                        agencias.SolicitadoPor = datos["solicitado_por"].ToString();
                        agencias.Cargo = datos["cargo"].ToString();
                        agencias.Departamento = datos["departamento"].ToString();
                        agencias.Telefono = datos["telefono"].ToString();
                        agencias.Extencion = datos["extencion"].ToString();
                        agencias.ReferenciaTela = datos["ref_tela"].ToString();
                        agencias.TipoTejido = datos["tipo_tejido"].ToString();
                        agencias.Fondo = datos["fondo"].ToString();
                        agencias.NombreTela = datos["nom_tela"].ToString();
                        agencias.AnchoTela = decimal.Parse(datos["ancho_tela"].ToString());
                        agencias.Rendimiento = decimal.Parse(datos["rendimiento"].ToString());
                        agencias.Composicion = datos["composicion"].ToString();
                        agencias.Muestrario = datos["muestrario"].ToString();
                        agencias.OcasionUso = datos["ocasion_uso"].ToString();
                        agencias.Tema = datos["tema"].ToString();
                        agencias.Entrada = datos["entrada"].ToString();
                        agencias.EnsayoRef = datos["ensayo_ref"].ToString();
                        agencias.FechaTienda = datos["fecha_tienda"].ToString();
                        agencias.Disenadora = datos["disenadora"].ToString();
                        agencias.DescPrenda = datos["desc_prenda"].ToString();
                        agencias.Proveedor = datos["proveedor"].ToString();
                        agencias.Nit = datos["nit"].ToString();
                        agencias.Contacto = (datos["contacto"].ToString().Trim().Length > 0) ? datos["contacto"].ToString().Trim() : "";
                        agencias.PedidoAgencia = (datos["pedi_agencia"].ToString().Trim().Length > 0) ? datos["pedi_agencia"].ToString().Trim() : "";
                        agencias.OrdenCompra = (datos["orden_compra"].ToString().Trim().Length > 0) ? datos["pedi_agencia"].ToString().Trim() : "";
                        agencias.FechaLlegadaTela = datos["fecha_llegadatienda"].ToString();
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


    }
}
