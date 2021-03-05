using System.Configuration;
using IBM.Data.Informix;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;


namespace PedidoTela.Data
{
    public class clsConexion : IDisposable
    {
        private readonly IfxConnection conexion;
        private IfxCommand comando;
        private IfxDataReader lectorDatos;
        private IfxTransaction transaccion;
        private string database;
        private string host;
        private string protocol;
        private string password;
        private string server;
        private string service;
        private string userID;
        private string conexionString;
      
        
        public clsConexion()
        {
            Database = ConfigurationManager.AppSettings["Database"];
            Host = ConfigurationManager.AppSettings["Host"];
            Protocol = ConfigurationManager.AppSettings["Protocol"];
            Password = ConfigurationManager.AppSettings["Password"];
            Server = ConfigurationManager.AppSettings["Server"];
            Service = ConfigurationManager.AppSettings["Service"];
            UserID = ConfigurationManager.AppSettings["userID"];
            conexionString = "Database=" + Database + ";Host=" + Host + ";Protocol=" + Protocol + ";Password=" + Password + ";Server=" + Server + 
                ";Service="+Service+";User ID="+UserID+";" ;
            conexion = new IfxConnection();
            comando = new IfxCommand();
            comando.CommandTimeout = 3600;
            Parametros = new List<DbParameter>();

        }
        public void abrirConexion()
        {
            conexion.ConnectionString = conexionString;
            conexion.Open();
        }
        public void cerrarConexion()
        {
            conexion.Close();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                comando?.Dispose();
                lectorDatos?.Close();
                lectorDatos?.Dispose();
                transaccion?.Dispose();
                Parametros = null;
            }
        }
        public string EjecutarConsultaEscalar(string consultaSql)
        {
            comando = new IfxCommand(consultaSql, ConexionAbierta);
            comando.CommandTimeout = 3600;
            foreach (var parametro in Parametros)
            {
                comando.Parameters.Add(parametro.ParameterName, parametro.Value);
            }
            return comando.ExecuteScalar().ToString();
        }

        public IfxDataReader EjecutarConsulta(string consultaSql)
        {
            comando = new IfxCommand(consultaSql, ConexionAbierta);
            Console.WriteLine(consultaSql);
            comando.CommandTimeout = 3600;
            foreach (var parametro in Parametros)
            {
                Console.WriteLine("Name: " + parametro.ParameterName + " Value: " + parametro.Value);
                comando.Parameters.Add(parametro.ParameterName, parametro.Value);
            }
            lectorDatos = comando.ExecuteReader();
            return lectorDatos;
        }

        public void Ejecutar(string consultaSql)
        {
            abrirConexion();
            transaccion = conexion.BeginTransaction();
            comando = new IfxCommand(consultaSql, conexion);
            comando.CommandTimeout = 3600;
            try
            {
                if (Parametros.Count <= 0) throw new Exception("No se asignaron parámetros");

                foreach (var parametro in Parametros)
                {
                    comando.Parameters.Add(parametro.ParameterName, parametro.Value);
                    //Console.WriteLine("Valor: " + parametro.Value);
                }
                //Console.WriteLine(comando.CommandText);
                comando.Transaction = transaccion;
                comando.ExecuteNonQuery();
                transaccion.Commit();
            }
            catch (Exception e)
            {
                transaccion.Rollback();
                throw new Exception($"Ocurrio un error: {e.Message}");

            }
            conexion.Close();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IfxConnection ConexionAbierta
        {
            get
            {
                if (conexion != null && conexion.State == ConnectionState.Closed) abrirConexion();
                return conexion;
            }
        }

        public string Database { get => database; set => database = value; }
        public string Host { get => host; set => host = value; }
        public string Protocol { get => protocol; set => protocol = value; }
        public string Password { get => password; set => password = value; }
        public string Server { get => server; set => server = value; }
        public string Service { get => service; set => service = value; }
        public string UserID { get => userID; set => userID = value; }
        public List<DbParameter> Parametros { get; private set; }

    }
}
