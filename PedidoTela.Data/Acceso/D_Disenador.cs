using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_Disenador
    {
        private readonly string consultarAll = "SELECT p.idusuario, u.nombre " +
            "FROM cfc_m_prgrmdor p inner join cfc_m_usuarios u ON p.idusuario = u.idusuario " +
            "WHERE p.activo ='t';";


        public void Actualizar(Objeto elemento)
        {
            throw new NotImplementedException();
        }

        public List<Objeto> consultarDiseñadores()
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var con = new clsConexion())
            {
                var datosDataReader = con.EjecutarConsulta(consultarAll);
                while (datosDataReader.Read())
                {
                    Objeto disenador = new Objeto();
                    disenador.Id = datosDataReader["idUsuario"].ToString();
                    disenador.Nombre = datosDataReader["nombre"].ToString();
                    respuesta.Add(disenador);
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
