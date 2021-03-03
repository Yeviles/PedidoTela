using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_Color
    {
        #region Consultas
        private readonly string consultarAll = "SELECT trim(codi_color) codi_color,upper(trim(desc_color)) desc_color " +
            "FROM inmcolor;";
        private readonly string consultarLikeCodigo = "SELECT trim(codi_color) codi_color,upper(trim(desc_color)) desc_color " +
            "FROM inmcolor WHERE codi_color LIKE ?;";
        private readonly string consultarLikeDescripcion = "SELECT trim(codi_color) codi_color,upper(trim(desc_color)) desc_color " +
            "FROM inmcolor WHERE desc_color LIKE ?;";
        private readonly string consultar = "select trim(codi_color) codi_color,upper(trim(desc_color)) desc_color,trim(codi_color) || ' - ' ||upper(trim(desc_color)) _codigonombre " +
            "from inmcolor e where(select count(*) from cfc_e_nocolor where idempresa = 1 and codi_color = e.codi_color) = 0 " +
            "and desc_color is not null and desc_color<> '' " +
            "and codi_color  matches '[0-9]' " +
            "union all " +
            "select trim(codi_color) codi_color, upper(trim(desc_color)) desc_color,trim(codi_color) || ' - ' ||upper(trim(desc_color)) _codigonombre " +
            "from inmcolor e where(select count(*) from cfc_e_nocolor where idempresa = 1 and codi_color = e.codi_color) = 0 " +
            "and desc_color is not null and desc_color<> '' " +
            "and codi_color  matches '[0-9][0-9]'" +
            "union all " +
            "select trim(codi_color) codi_color, upper(trim(desc_color)) desc_color,trim(codi_color) || ' - ' ||upper(trim(desc_color)) _codigonombre " +
            "from inmcolor e where(select count(*) from cfc_e_nocolor where idempresa = 1 and codi_color = e.codi_color) = 0 " +
            "and desc_color is not null and desc_color<> '' " +
            "and codi_color  matches '[0-9][0-9][0-9]' " +
            "union all " +
            "select trim(codi_color) codi_color, upper(trim(desc_color)) desc_color,trim(codi_color) || ' - ' ||upper(trim(desc_color)) _codigonombre " +
            "from inmcolor e where(select count(*) from cfc_e_nocolor where idempresa = 1 and codi_color = e.codi_color) = 0 " +
            "and desc_color is not null and desc_color<> '' " +
            "and codi_color  matches '[0-9][0-9][0-9][0-9]' " +
            "union all " +
            "select trim(codi_color) codi_color, upper(trim(desc_color)) desc_color,trim(codi_color) || ' - ' ||upper(trim(desc_color)) _codigonombre " +
            "from inmcolor e where(select count(*) from cfc_e_nocolor where idempresa = 1 and codi_color = e.codi_color) = 0  " +
            "and desc_color is not null and desc_color<> '' " +
            "and codi_color  matches '[0-9][0-9][0-9][0-9][0-9]'";
        #endregion

        public void Actualizar(Objeto elemento)
        {
            throw new NotImplementedException();
        }

        public List<Objeto> consultarColores()
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var con = new clsConexion())
            {
                var datosDataReader = con.EjecutarConsulta(consultarAll);
                while (datosDataReader.Read())
                {
                    Objeto obj = new Objeto();
                    obj.Id = datosDataReader["codi_color"].ToString();
                    obj.Nombre = datosDataReader["desc_color"].ToString();
                    respuesta.Add(obj);
                };
                con.cerrarConexion();
            }
            return respuesta;
        }

        public List<Objeto> buscarColorPorCodigo(string codigo)
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var con = new clsConexion())
            {
                con.Parametros.Add(new IfxParameter("@codi_color", codigo + "%"));
                var datosDataReader = con.EjecutarConsulta(consultarLikeCodigo);
                while (datosDataReader.Read())
                {
                    Objeto obj = new Objeto();
                    obj.Id = datosDataReader["codi_color"].ToString();
                    obj.Nombre = datosDataReader["desc_color"].ToString();
                    respuesta.Add(obj);
                };
                con.cerrarConexion();
            }
            return respuesta;
        }

        public List<Objeto> buscarColorPorDescripcion(string descripcion)
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var con = new clsConexion())
            {
                con.Parametros.Add(new IfxParameter("@desc_color", descripcion + "%"));
                var datosDataReader = con.EjecutarConsulta(consultarLikeDescripcion);
                while (datosDataReader.Read())
                {
                    Objeto obj = new Objeto();
                    obj.Id = datosDataReader["codi_color"].ToString();
                    obj.Nombre = datosDataReader["desc_color"].ToString();
                    respuesta.Add(obj);
                };
                con.cerrarConexion();
            }
            return respuesta;
        }

        public List<Objeto> obtenerColores()
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var con = new clsConexion())
            {
                var datosDataReader = con.EjecutarConsulta(consultar);
                while (datosDataReader.Read())
                {
                    Objeto obj = new Objeto();
                    obj.Id = datosDataReader["codi_color"].ToString();
                    obj.Nombre = datosDataReader["desc_color"].ToString();
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
    }
}
