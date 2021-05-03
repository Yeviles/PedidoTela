using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
   public  class MontajeTela
    {
        private string tipoSolicitud;
        private string muestrario;
        private string ocasionUso;
        private string tema;
        private string entrada;
        private string disenador;
        private string ensayoRefSimilar;
        private string estado;
        private string fechaTienda;
        private string refTela;
        private string nomTela;
        private string solicitud;
        private string color;
        private string clase;
        private string coordinado;
        private string numDibujo;


        public MontajeTela() { }
        public MontajeTela(string tipoSolicitud, string muestrario, string ocasionUso, string tema, string entrada, string disenador, string ensayoRefSimilar, string estado, string fechaTienda, string refTela, string nomTela, string solicitud, string color, string clase, string coordinado, string numDibujo)
        {
            this.TipoSolicitud = tipoSolicitud;
            this.Muestrario = muestrario;
            this.OcasionUso = ocasionUso;
            this.Tema = tema;
            this.Entrada = entrada;
            this.Disenador = disenador;
            this.EnsayoRefSimilar = ensayoRefSimilar;
            this.Estado = estado;
            this.FechaTienda = fechaTienda;
            this.RefTela = refTela;
            this.NomTela = nomTela;
            this.Solicitud = solicitud;
            this.Color = color;
            this.Clase = clase;
            this.Coordinado = coordinado;
            this.NumDibujo = numDibujo;
        }

        public string TipoSolicitud { get => tipoSolicitud; set => tipoSolicitud = value; }
        public string Muestrario { get => muestrario; set => muestrario = value; }
        public string OcasionUso { get => ocasionUso; set => ocasionUso = value; }
        public string Tema { get => tema; set => tema = value; }
        public string Entrada { get => entrada; set => entrada = value; }
        public string Disenador { get => disenador; set => disenador = value; }
        public string EnsayoRefSimilar { get => ensayoRefSimilar; set => ensayoRefSimilar = value; }
        public string Estado { get => estado; set => estado = value; }
        public string FechaTienda { get => fechaTienda; set => fechaTienda = value; }
        public string RefTela { get => refTela; set => refTela = value; }
        public string NomTela { get => nomTela; set => nomTela = value; }
        public string Solicitud { get => solicitud; set => solicitud = value; }
        public string Color { get => color; set => color = value; }
        public string Clase { get => clase; set => clase = value; }
        public string Coordinado { get => coordinado; set => coordinado = value; }
        public string NumDibujo { get => numDibujo; set => numDibujo = value; }
    }
}
