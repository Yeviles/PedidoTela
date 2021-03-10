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
        #region Métodos de búsqueda
        #region Métodos de Color
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

        public List<Objeto> getColoresComboBox()
        {
            D_Color d_color = new D_Color();
            return d_color.obtenerColores();
        }
        #endregion

        #region Métodos de Tela
        public List<Objeto> buscarTelaPorReferencia(string prmRefTela)
        {
            D_Tela d_Tela = new D_Tela();
            return d_Tela.buscarTelaPorReferEncia(prmRefTela);
        }
        public List<Objeto> buscarTelaPorDescripcion(string prmDescripcion)
        {
            D_Tela d_Tela = new D_Tela();
            return d_Tela.buscarTelaPorDescripcion(prmDescripcion);
        }
        public List<Objeto> getTela()
        {
            D_Tela d_Tela = new D_Tela();
            return d_Tela.consultarTelas();
        }
        #endregion
        #endregion

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
            return d_detalle.ConsultarDetalleConsumo(prmIdensayo);
        }
        public List<DetalleConsumo> getDetalleConsumoReferencia(string prmIdReferencia)
        {
            D_DetalleConsumo d_detalle = new D_DetalleConsumo();
            return d_detalle.ConsulatDetalleReferencia(prmIdReferencia);
        }
        public bool consultarIdentificador(string prmIdentificador)
        {
            D_EditarDetalleConsumo objDetalleEditado = new D_EditarDetalleConsumo();
            return objDetalleEditado.consultarIdentificador(prmIdentificador);
        }
        public List<EditarDetalleconsumo> getDcEditadoPorEnsayo(string prmIdensayo)
        {
            D_EditarDetalleConsumo objDetalleEditado = new D_EditarDetalleConsumo();
            return objDetalleEditado.ConsultarDCEditadoPorEnsayo(prmIdensayo);
        }

        /// <summary>
        /// Realiza un UPDATE en la tabla cfc_spt_sol_tela.
        /// </summary>
        /// <param name="editarDetalle"></param>
        /// <returns></returns>
        public bool setDcEditadoPorEnsayo(EditarDetalleconsumo editarDetalle, string idEditar)
        {
            D_EditarDetalleConsumo objDetalleEditado = new D_EditarDetalleConsumo();
            // return (d_Unicolor.Agregar(unicolor) == "ok") ? true : false;
            return (objDetalleEditado.setDcEditadoPorEnsayo(editarDetalle, idEditar) == "ok") ? true : false;
        }

        public List<EditarDetalleconsumo> getDetalleEditadoPorRef(string prmReferencia)
        {
            D_EditarDetalleConsumo objDetalleEditado = new D_EditarDetalleConsumo();
            return objDetalleEditado.ConsultarDtEditadoPorRef(prmReferencia);
        }

        #endregion
        #region Métodos Editar Detalle Consumo
        public bool addDetalleConsumo(EditarDetalleconsumo prmDetalleCon)
        {
            D_EditarDetalleConsumo detalleCon = new D_EditarDetalleConsumo();
            return (detalleCon.addDetalleConsumo(prmDetalleCon) == "ok") ? true : false;
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
        public TipoTejido getTipoTejido(string codigoTela)
        {
            D_TipoTejido d_TipoTejido = new D_TipoTejido();
            return d_TipoTejido.obtenerTipoTejido(codigoTela);
        }

        public int getIdUnicolor(string identificador)
        {
            D_Unicolor d_Unicolor = new D_Unicolor();
            return d_Unicolor.ConsultarId(identificador);
        }

        public Unicolor getUnicolor(string identificador)
        {
            D_Unicolor d_Unicolor = new D_Unicolor();
            return d_Unicolor.Consultar(identificador);
        }
        public List<DetalleUnicolor> getDetalleUnicolor(int idUnicolor)
        {
            D_DetalleUnicolor d_Unicolor = new D_DetalleUnicolor();
            return d_Unicolor.Consultar(idUnicolor);
        }

        public bool addUnicolor(Unicolor unicolor)
        {
            D_Unicolor d_Unicolor = new D_Unicolor();
            return (d_Unicolor.Agregar(unicolor) == "ok") ? true : false;
        }

        public void addDetalleUnicolor(DetalleUnicolor detalle)
        {
            D_DetalleUnicolor d_DetalleUnicolor = new D_DetalleUnicolor();
            d_DetalleUnicolor.Agregar(detalle);
        }
        #endregion

        #region Métodos Solicitud Estampado
        public bool addEstampado(Estampado estampado)
        {
            D_Estampado d_Unicolor = new D_Estampado();
            return (d_Unicolor.Agregar(estampado) == "ok") ? true : false;
        }
        public void addDetalleEstampado(DetalleEstampado detalle)
        {
            D_DetalleEstampado d_DetalleUnicolor = new D_DetalleEstampado();
            d_DetalleUnicolor.Agregar(detalle);
        }
        public int consultarIdEstampado(string prmIdentificador)
        {
            D_Estampado estampado = new D_Estampado();
            return estampado.consultarIdEstampado(prmIdentificador);
        }
        public List<DetalleEstampado> getDetalleEstampado(int idEstampado)
        {
            D_DetalleEstampado d_Estampado = new D_DetalleEstampado();
            return d_Estampado.getDetalleEstampado(idEstampado);
        }
        public Estampado getEstampado(string idEstampado)
        {
            D_Estampado d_Estampado = new D_Estampado();
            return d_Estampado.Consultar(idEstampado);
        }
        public bool agregarConsecutivo(int prmIdsolicitud, int prmIdtipo, string prmTipo, int prmConsecutivo)
        {
            D_TipoSolicitud d_solicitud = new D_TipoSolicitud();
            return (d_solicitud.Agregar(prmIdsolicitud, prmIdtipo, prmTipo, prmConsecutivo) == "ok") ? true : false;
        }
        /*Consultar si el Estampado ya tiene un consecutivo */
        public bool consultarConsecutivo(int prmIdentificador)
        {
            D_TipoSolicitud d_solicitud = new D_TipoSolicitud();
            return (d_solicitud.consultarConsecutivo(prmIdentificador));
        }

        public int consultarMaximo()
        {
            D_TipoSolicitud d_solicitud = new D_TipoSolicitud();
            return d_solicitud.consultarMaximo();
        }
        public int consultarIdsolicitud(string prmIdSolicitud)
        {
            D_SolicitudTela d_estamapdo = new D_SolicitudTela();
            return d_estamapdo.consultarIdSolicitud(prmIdSolicitud);
        }



        #endregion

        #region Métodos Solicitud Plano Preteñido
        public int getIdPlanoPretenido(string identificador)
        {
            D_PlanoPretenido d_PlanoPretenido = new D_PlanoPretenido();
            return d_PlanoPretenido.ConsultarId(identificador);
        }

        public PlanoPretenido getPlanoPretenido(string identificador)
        {
            D_PlanoPretenido d_PlanoPretenido = new D_PlanoPretenido();
            return d_PlanoPretenido.Consultar(identificador);
        }
        public List<DetallePlanoPretenido> getDetallePlanoPretenido(int idPlano)
        {
            D_DetallePlanoPretenido d_DetallePlanoPretenido = new D_DetallePlanoPretenido();
            return d_DetallePlanoPretenido.Consultar(idPlano);
        }

        public bool addPlanoPretenido(PlanoPretenido planoPretenido)
        {
            D_PlanoPretenido d_PlanoPretenido = new D_PlanoPretenido();
            return (d_PlanoPretenido.Agregar(planoPretenido) == "ok") ? true : false;
        }

        public void addDetallePlanoPretenido(DetallePlanoPretenido detalle)
        {
            D_DetallePlanoPretenido d_DetallePlanoPretenido = new D_DetallePlanoPretenido();
            d_DetallePlanoPretenido.Agregar(detalle);
        }

        public string getConsecutivoPlanoPretenido(int idPlano)
        {
            D_PlanoPretenido d_PlanoPretenido = new D_PlanoPretenido();
            int anterior = d_PlanoPretenido.Consultarconsecutivo();
            return d_PlanoPretenido.AgregarConsecutivo(anterior + 1, idPlano);
        }

        #endregion
    }
}
