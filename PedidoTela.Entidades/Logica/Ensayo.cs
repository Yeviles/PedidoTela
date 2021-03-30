﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Entidades.Logica
{
    public class Ensayo
    {
        private string ensayo_referencia;
        private string idprogramador;
        private string idensayo;
        private string idrepeticion;
        private string idmundo; // id de la tabla cfc_e_mundo se utuliza para sacar la Ocasion de uso
        private string codi_capsula; // id tabla cfc_m_capsulas el cual se utiliza para dato Tema,
        private string anio_muestrario;
        private string nmro_muestrario;
        private string codi_entrada; // id de la tabla cfc_e_entrada  se utiliza para la Entrada.
        private string ocasion_uso;
        private string tema;
        private string entrada;
        private string programador;
        private string id_disenador;
        private string codi_linea;//id para sacar la marca 

     
        public Ensayo() { }

        public Ensayo(string ensayo_referencia, string idprogramador, string idensayo, string idrepeticion, string idmundo, string codi_capsula, string anio_muestrario, string nmro_muestrario, string codi_entrada, string ocasion_uso, string tema, string entrada, string programador, string id_disenador, string codi_linea)
        {
            this.Ensayo_referencia = ensayo_referencia;
            this.Idprogramador = idprogramador;
            this.Idensayo = idensayo;
            this.Idrepeticion = idrepeticion;
            this.Idmundo = idmundo;
            this.Codi_capsula = codi_capsula;
            this.Anio_muestrario = anio_muestrario;
            this.Nmro_muestrario = nmro_muestrario;
            this.Codi_entrada = codi_entrada;
            this.Ocasion_uso = ocasion_uso;
            this.Tema = tema;
            this.Entrada = entrada;
            this.Programador = programador;
            this.Id_disenador = id_disenador;
            this.Codi_linea = codi_linea;
        }

        public string Ensayo_referencia { get => ensayo_referencia; set => ensayo_referencia = value; }
        public string Idprogramador { get => idprogramador; set => idprogramador = value; }
        public string Idensayo { get => idensayo; set => idensayo = value; }
        public string Idrepeticion { get => idrepeticion; set => idrepeticion = value; }
        public string Idmundo { get => idmundo; set => idmundo = value; }
        public string Codi_capsula { get => codi_capsula; set => codi_capsula = value; }
        public string Anio_muestrario { get => anio_muestrario; set => anio_muestrario = value; }
        public string Nmro_muestrario { get => nmro_muestrario; set => nmro_muestrario = value; }
        public string Codi_entrada { get => codi_entrada; set => codi_entrada = value; }
        public string Ocasion_uso { get => ocasion_uso; set => ocasion_uso = value; }
        public string Tema { get => tema; set => tema = value; }
        public string Entrada { get => entrada; set => entrada = value; }
        public string Programador { get => programador; set => programador = value; }
        public string Id_disenador { get => id_disenador; set => id_disenador = value; }
        public string Codi_linea { get => codi_linea; set => codi_linea = value; }
    }
}
