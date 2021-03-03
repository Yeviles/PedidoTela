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
        private readonly string consultarAll = "select trim(codi_color) codi_color,upper(trim(desc_color)) desc_color,trim(codi_color) || ' - ' ||upper(trim(desc_color)) _codigonombre " +
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
