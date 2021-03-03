using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_TipoTejido
    {
        private readonly string consultar = "select codi_item codigo_tela, trim(desc_item) nombre_tela, " +
            "cfc_m_tipo_tela.idtipo_tela, cfc_m_tipo_tela.nombre from items " +
            "inner join cfc_m_tipo_tela on items.tipo_tela=cfc_m_tipo_tela.tipo_tela where codi_item=?;";


        public void Actualizar(Objeto elemento)
        {
            throw new NotImplementedException();
        }

        public TipoTejido obtenerTipoTejido(string codigoTela) {
            TipoTejido obj = new TipoTejido();
            using (var con = new clsConexion())
            {
                con.Parametros.Add(new IfxParameter("@codi_item", codigoTela));
                var datosDataReader = con.EjecutarConsulta(consultar);
                while (datosDataReader.Read())
                {
                    obj.CodigoTela = datosDataReader["codigo_tela"].ToString();
                    obj.NombreTela = datosDataReader["nombre_tela"].ToString();
                    obj.IdTipoTela = datosDataReader["idtipo_tela"].ToString();
                    obj.NombreTipoTela = datosDataReader["nombre"].ToString();
                };
                con.cerrarConexion();
            }
            return obj;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
