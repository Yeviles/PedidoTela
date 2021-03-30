using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_Tema
    {
        //private readonly string consultarAll = "SELECT idcapsula, trim(nombre) as nombre " +
        //    "FROM cfc_m_capsulas WHERE activo='t';";
        private readonly string consultarAll = "select  distinct ( cp.idcapsula),cp.nombre from cfc_spt_sol_tela st " +
                                                "left join cfc_m_capsulas cp on cp.idcapsula = st.codi_capsula;";

        public void Actualizar(Objeto elemento)
        {
            throw new NotImplementedException();
        }

        public List<Objeto> consultarTema()
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var con = new clsConexion())
            {
                var datosDataReader = con.EjecutarConsulta(consultarAll);
                while (datosDataReader.Read())
                {
                    Objeto tema = new Objeto();
                    tema.Id = datosDataReader["idcapsula"].ToString();
                    tema.Nombre = datosDataReader["nombre"].ToString();
                    respuesta.Add(tema);
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
