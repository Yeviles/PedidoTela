using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_Estampado
    {
        #region Consultas
        private readonly string consultaInsert = "INSERT INTO cfc_spt_sol_estampado (ensayo_ref,referencia_tela,nombre_tela,tipo_estampado,tipo_tejido,n_dibujos,n_cilindros,coordinado_con,coordinado,observaciones,id_sol_tela) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";
        
        private readonly string consultaId = "select idEstampado from cfc_spt_sol_estampado where ensayo_ref = ?;";
        
        private readonly string consultaIdEst = "select idEstampado from cfc_spt_sol_estampado where id_sol_tela = ?;";
        
        private readonly string consultaIdentificador = "select ensayo_ref from cfc_spt_sol_estampado where id_sol_tela = ?;";
        
        private readonly string consultaIdSolTela = "select id_sol_tela from cfc_spt_sol_estampado where idEstampado = ?; ";
        //private readonly string consultarTodo = "SELECT idEstampado,tipo_estampado,tipo_tejido,n_dibujos,n_cilindros, NVL(coordinado_con, '') AS coordinado_con,coordinado, observaciones FROM cfc_spt_sol_estampado WHERE ensayo_ref = ?;";
        
        private readonly string consultarTodo = "SELECT idEstampado,tipo_estampado,tipo_tejido,n_dibujos,n_cilindros, NVL(coordinado_con, '') AS coordinado_con,coordinado, observaciones FROM cfc_spt_sol_estampado WHERE id_sol_tela = ?;";
        
        private readonly string actualizar = "update cfc_spt_sol_estampado set tipo_estampado =?,  tipo_tejido=?, n_dibujos=?, n_cilindros=?, coordinado_con=?, coordinado=?, observaciones=?,ensayo_ref=? where id_sol_tela =?;";
        #endregion
        #region Métodos
        public string Agregar(Estampado elemento)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
   
                    con.Parametros.Add(new IfxParameter("@esayo_ref", elemento.Esayo_ref));
                    con.Parametros.Add(new IfxParameter("@referencia_tela", elemento.Referencia_tela));
                    con.Parametros.Add(new IfxParameter("@nombre_tela", elemento.Nombre_tela));
                    con.Parametros.Add(new IfxParameter("@tipo_estampado", elemento.Tipo_estampado));
                    con.Parametros.Add(new IfxParameter("@tipo_tejido", elemento.Tipo_tejido));
                    con.Parametros.Add(new IfxParameter("@n_dibujos", elemento.N_dibujos));
                    con.Parametros.Add(new IfxParameter("@n_cilindros", elemento.N_cilindros));
                    con.Parametros.Add(new IfxParameter("@coordinado_con", elemento.Coordinado_con));
                    con.Parametros.Add(new IfxParameter("@coordinado", elemento.Coordinado));
                    con.Parametros.Add(new IfxParameter("@observaciones", elemento.Observaciones));
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
        
        public int consultarIdEstampado(string prmIdentificador)
        {
            int id = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    conexion.Parametros.Add(new IfxParameter("@idestampado", prmIdentificador));
                    var datos = conexion.EjecutarConsulta(consultaId);
                    datos.Read();
                    id = int.Parse(datos["idEstampado"].ToString());

                    conexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return id;
            }

        /// <summary>
        /// Se utiliza en fromSolTelas método validarTipoSolocitudGuardada
        /// </summary>
        /// <param name="idSolTela">Id de la tabla cfc_spt_sol_tela</param>
        /// <returns></returns>
        public int consultarIdEst(int idSolTela)
        {
            int id = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    conexion.Parametros.Add(new IfxParameter("@id_sol_tela", idSolTela));
                    var datos = conexion.EjecutarConsulta(consultaIdEst);
                    datos.Read();
                    id = int.Parse(datos["idEstampado"].ToString());

                    conexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return id;
        }


        public int ConsultarIdSolTela(int idEstamapdo)
        {
            int id = 0;
            try
            {
                using (var conexion = new clsConexion())
                {
                    conexion.Parametros.Add(new IfxParameter("@idEstampado", idEstamapdo));
                    var datos = conexion.EjecutarConsulta(consultaIdSolTela);
                    datos.Read();
                    id = int.Parse(datos["id_sol_tela"].ToString());

                    conexion.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return id;
        }
        
        //public string consultarIdentificador(string prmIdentificador)
        //{
        //    string respuesta = "";
        //    try
        //    {
        //        using (var conexion = new clsConexion())
        //        {
        //            conexion.Parametros.Add(new IfxParameter("@ensayo_ref", prmIdentificador));
        //            var datos = conexion.EjecutarConsulta(consultaIdentificador);
        //            datos.Read();
        //            //id = datos["@ensayo_ref"].ToString();
        //            conexion.cerrarConexion();

        //        }
        //        respuesta = "ok";

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error: " + ex.Message);
        //    }
        //    return respuesta;
        //}
        
        public bool consultarIdentificador(int dSolTela)
        {
            string ensayo;
            using (var administrador = new clsConexion())
            {
                try
                {
                    administrador.Parametros.Add(new IfxParameter("@id_sol_tela", dSolTela));
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


        public Estampado Consultar(int idDolTela)
        {
            Estampado estampado = new Estampado();
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@id_sol_tela", idDolTela));
                    var datos = con.EjecutarConsulta(consultarTodo);
                    while (datos.Read())
                    {
                 
                        estampado.IdEstampado = int.Parse(datos["idEstampado"].ToString());
                        //estampado.Referencia_tela = datos["referencia_tela"].ToString();
                        //estampado.Nombre_tela = datos["nombre_tela"].ToString();
                        estampado.Tipo_estampado = datos["tipo_estampado"].ToString();
                        estampado.Tipo_tejido = datos["tipo_tejido"].ToString();
                        estampado.N_dibujos = int.Parse(datos["n_dibujos"].ToString());
                        estampado.N_cilindros = int.Parse(datos["n_cilindros"].ToString());
                        estampado.Coordinado_con = (datos["coordinado_con"].ToString().Trim().Length > 0) ? datos["coordinado_con"].ToString().Trim() : "";
                        bool so = false;
                        if (datos["coordinado"].ToString() == "t") { so = true; }
                        estampado.Coordinado = so;
                        estampado.Observaciones = datos["observaciones"].ToString();
                    }
                    con.cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return estampado;
        }

        public string Actualizar(Estampado prmEstampado)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {
                    con.Parametros.Add(new IfxParameter("@tipo_estampado", prmEstampado.Tipo_estampado));
                    con.Parametros.Add(new IfxParameter("@tipo_tejido", prmEstampado.Tipo_tejido));
                    con.Parametros.Add(new IfxParameter("@n_dibujos", prmEstampado.N_dibujos));
                    con.Parametros.Add(new IfxParameter("@n_cilindros", prmEstampado.N_cilindros));
                    con.Parametros.Add(new IfxParameter("@coordinado_con", prmEstampado.Coordinado_con));
                    con.Parametros.Add(new IfxParameter("@coordinado", prmEstampado.Coordinado));
                    con.Parametros.Add(new IfxParameter("@observaciones", prmEstampado.Observaciones));
                    con.Parametros.Add(new IfxParameter("@ensayo_ref", prmEstampado.Esayo_ref));
                    con.Parametros.Add(new IfxParameter("@id_sol_tela", prmEstampado.IdSolTela));
                    var datos = con.EjecutarConsulta(actualizar);

                    con.cerrarConexion();
                }
                respuesta = "ok";
            }
            catch (Exception ex)
            {
                respuesta = "Error: " + ex.Message;
            }
            //if (datos == 0)
            //{

            //}

            return respuesta;
        }
       

        #endregion
    }
}
