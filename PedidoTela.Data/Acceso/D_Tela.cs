using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_Tela
    {
        private readonly string consultaGen = "select distinct codi_item, desc_item  from items;";
        private readonly string consultarPorRefTela = "select codi_item, desc_item  from items where codi_item LIKE ?;";
        private readonly string consultarPorDescTela = "select codi_item, desc_item  from items where desc_item  LIKE ?;";

        public List<Objeto> buscarTelaPorReferEncia(string prmRefTela)
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var con = new clsConexion())
            {
                con.Parametros.Add(new IfxParameter("@codi_item", prmRefTela + "%"));
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
                con.Parametros.Add(new IfxParameter("@desc_item", prmDescripcion + "%"));
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
    }
}
