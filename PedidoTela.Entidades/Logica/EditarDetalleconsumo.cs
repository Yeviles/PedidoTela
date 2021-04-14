using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class EditarDetalleconsumo
    {
        //private int idsolicitud; es Atoincrementable 
        private string identificador;
        private string tipo;
        private string idmundo;
        private string codi_capsula;
        private string codi_entrada;
        private string descripcionPrenda;
        private string referenciaTela;
        private string descripcionTela;
        private string tipoSolicitud;
        private string consumo;
        private string sku;
        private string fechaTienda;
        private string muestrario;
        private string id_disenador;
        private string codi_linea;
        private int idsolicitud;

        public EditarDetalleconsumo() { }

        public EditarDetalleconsumo(string identificador, string tipo, string idmundo, string codi_capsula, string codi_entrada, string descripcionPrenda, string referenciaTela, string descripcionTela, string tipoSolicitud, string consumo, string sku, string fechaTienda, string muestrario, string id_disenador, string codi_linea, int idsolicitud)
        {
            this.Identificador = identificador;
            this.Tipo = tipo;
            this.Idmundo = idmundo;
            this.Codi_capsula = codi_capsula;
            this.Codi_entrada = codi_entrada;
            this.DescripcionPrenda = descripcionPrenda;
            this.ReferenciaTela = referenciaTela;
            this.DescripcionTela = descripcionTela;
            this.TipoSolicitud = tipoSolicitud;
            this.Consumo = consumo;
            this.Sku = sku;
            this.FechaTienda = fechaTienda;
            this.Muestrario = muestrario;
            this.Id_disenador = id_disenador;
            this.Codi_linea = codi_linea;
            this.Idsolicitud = idsolicitud;
        }

        public string Identificador { get => identificador; set => identificador = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Idmundo { get => idmundo; set => idmundo = value; }
        public string Codi_capsula { get => codi_capsula; set => codi_capsula = value; }
        public string Codi_entrada { get => codi_entrada; set => codi_entrada = value; }
        public string DescripcionPrenda { get => descripcionPrenda; set => descripcionPrenda = value; }
        public string ReferenciaTela { get => referenciaTela; set => referenciaTela = value; }
        public string DescripcionTela { get => descripcionTela; set => descripcionTela = value; }
        public string TipoSolicitud { get => tipoSolicitud; set => tipoSolicitud = value; }
        public string Consumo { get => consumo; set => consumo = value; }
        public string Sku { get => sku; set => sku = value; }
        public string FechaTienda { get => fechaTienda; set => fechaTienda = value; }
        public string Muestrario { get => muestrario; set => muestrario = value; }
        public string Id_disenador { get => id_disenador; set => id_disenador = value; }
        public string Codi_linea { get => codi_linea; set => codi_linea = value; }
        public int Idsolicitud { get => idsolicitud; set => idsolicitud = value; }
    }
}
