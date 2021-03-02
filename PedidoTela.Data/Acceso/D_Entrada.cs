using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_Entrada
    {
        private readonly string consultarAll = "SELECT codi_entrada, trim(desc_entrada) as desc_entrada " +
            "FROM cfc_e_entrada WHERE activo='t';";


        public void Actualizar(Objeto elemento)
        {
            throw new NotImplementedException();
        }

        public List<Objeto> consultarEntrada()
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var con = new clsConexion())
            {
                var datosDataReader = con.EjecutarConsulta(consultarAll);
                while (datosDataReader.Read())
                {
                    Objeto entrada = new Objeto();
                    entrada.Id = datosDataReader["codi_entrada"].ToString();
                    entrada.Nombre = datosDataReader["desc_entrada"].ToString();
                    respuesta.Add(entrada);
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
