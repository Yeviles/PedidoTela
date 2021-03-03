using PedidoTela.Data.Acceso;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Controlodores
{
    public class Controlador
    {
        #region Métodos del frmSolicitudTela
        #region  Métodos de la clase D_Muestrario
        public List<Objeto> getListaMuestrario()
        {
            D_Muestrario objMuestrario = new D_Muestrario();

            return objMuestrario.consultarMuestrario();
        }
        #endregion
        #region Métodos de la clase D_OcasionUdo
        public List<Objeto> getListaOcasionUso()
        {
            D_OcasionUso objOcasionUso = new D_OcasionUso();
            return objOcasionUso.consultarOcasionUso();
        }
        #endregion
        #region Métodos de la clase D_Tema
        public List<Objeto> getListaTema()
        {
            D_Tema objTema = new D_Tema();
            return objTema.consultarTema();
        }
        #endregion
        #region Métodos de la clase D_Entrada
        public List<Objeto> getListaEntrada()
        {
            D_Entrada objEntrada = new D_Entrada();
            return objEntrada.consultarEntrada();
        }
        #endregion
        #region Métodos de la clase D_Disenador
        public List<Objeto> getListaDisenador()
        {
            D_Disenador objDisenador = new D_Disenador();
            return objDisenador.consultarDiseñadores();
        }
        #endregion
        #region Métodos de la clase D_Ensayo /Referencia
       
        public List<Ensayo> getEnsayo(string prmidEnsayo)
        {
            D_Ensayo d_Ensayo = new D_Ensayo();
            return d_Ensayo.ConsultarEnsayo(prmidEnsayo);
        } 

        public List<Ensayo> getReferencia(string prmIdReferencia)
        {
            D_Ensayo d_Ensayo = new D_Ensayo();
            return d_Ensayo.ConsultarReferencia(prmIdReferencia);
        }

        #endregion
        #region Métodos de la clse DetalleConsumo
        public List<DetalleConsumo> getDetalleConsumoEnsayo(string prmIdensayo)
        {
            D_DetalleConsumo d_detalle = new D_DetalleConsumo();
            return d_detalle.ConsulatDetalleConsumo(prmIdensayo);
        }
        public List<DetalleConsumo> getDetalleConsumoReferencia(string prmIdReferencia)
        {
            D_DetalleConsumo d_detalle = new D_DetalleConsumo();
            return d_detalle.ConsulatDetalleReferencia(prmIdReferencia);
        }

        #endregion
        #region Métodos de la clase TipoTejido
        public List<TipoPedido> getTipoTejido()
        {
            D_TipoPedido d_tejido = new D_TipoPedido();
            return d_tejido.ConsultarTipoTejido();
        }
        #endregion
        #endregion

        #region Métodos Solicitud unicolor
        public TipoTejido getTipoTejido(string codigoTela) {
            D_TipoTejido d_TipoTejido = new D_TipoTejido();
            return d_TipoTejido.obtenerTipoTejido(codigoTela);
        }

        public List<Objeto> getColores()
        {
            D_Color d_color = new D_Color();
            return d_color.consultarColores();
        }
        public List<Objeto> buscarColorPorCodigo(string codigo)
        {
            D_Color d_color = new D_Color();
            return d_color.buscarColorPorCodigo(codigo);
        }

        public List<Objeto> buscarColorPorDescripcion(string descripcion)
        {
            D_Color d_color = new D_Color();
            return d_color.buscarColorPorDescripcion(descripcion);
        }

        public List<Objeto> getColoresComboBox() {
            D_Color d_color = new D_Color();
            return d_color.obtenerColores();
        }
        #endregion
    }
}
