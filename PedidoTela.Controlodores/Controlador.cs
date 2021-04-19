using PedidoTela.Data.Acceso;
using PedidoTela.Entidades;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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
        #region Métodos de la clase DetalleConsumo
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
        public bool GuardarListaDetalleConsumo(List<EditarDetalleconsumo> detalle)
        {
            D_EditarDetalleConsumo d_Detalle = new D_EditarDetalleConsumo();
            return (d_Detalle.Agregar(detalle) == "ok") ? true : false;
        }


        /// <summary>
        /// Realiza un UPDATE en la tabla cfc_spt_sol_tela.
        /// </summary>
        /// <param name="editarDetalle"></param>
        /// <returns></returns>
        public bool ActualizarSolicitudTela(EditarDetalleconsumo editarDetalle, string idEditar)
        {
            D_EditarDetalleConsumo objDetalleEditado = new D_EditarDetalleConsumo();
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
        public List<Objeto> getTipoSocitud()
        {
            D_TipoPedido d_tejido = new D_TipoPedido();
            return d_tejido.ConsultarTipoSolicitud();
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
            return d_Unicolor.ConsultarIdUnicolor(identificador);
        }
        public int getIdUni(int idSolTela)
        {
            D_Unicolor d_Unicolor = new D_Unicolor();
            return d_Unicolor.ConsultarIdUni(idSolTela);
        }
        public int getIdSoltela(int idUnicolor)
        {
            D_Unicolor d_Unicolor = new D_Unicolor();
            return d_Unicolor.ConsultarIdSolTela(idUnicolor);
        }
        public Unicolor getUnicolor(int idSolTelas)
        {
            D_Unicolor d_Unicolor = new D_Unicolor();
            return d_Unicolor.Consultar(idSolTelas);
        }
        public List<DetalleUnicolor> getDetalleUnicolor(int idUnicolor)
        {
            D_DetalleUnicolor d_Unicolor = new D_DetalleUnicolor();
            return d_Unicolor.Consultar(idUnicolor);
        }
        public bool consultarIdentificadorUni(int idSolTela)
        {
            D_Unicolor objDetalleEditado = new D_Unicolor();
            return objDetalleEditado.consultarIdentificador(idSolTela);
        }
        public bool addUnicolor(Unicolor unicolor)
        {
            D_Unicolor d_Unicolor = new D_Unicolor();
            return (d_Unicolor.Agregar(unicolor) == "ok") ? true : false;
        }

        public bool addDetalleUnicolor(DetalleUnicolor detalle)
        {
            D_DetalleUnicolor d_DetalleUnicolor = new D_DetalleUnicolor();
            return (d_DetalleUnicolor.Agregar(detalle) == "ok") ? true : false;
        }
        public bool ActualizarDetalle(DetalleUnicolor detalleUnicolor, int idDetalle)
        {
            D_DetalleUnicolor objDetalleEditado = new D_DetalleUnicolor();
            return (objDetalleEditado.Actualizar(detalleUnicolor, idDetalle) == "ok") ? true : false;
        }
        public bool Actualizar(Unicolor unicolor)
        {
            D_Unicolor objDetalleEditado = new D_Unicolor();
            return (objDetalleEditado.Actualizar(unicolor) == "ok") ? true : false;
        }
        public List<int> getIdDetalle(int idUnicolor)
        {
            D_DetalleUnicolor d_Unicolor = new D_DetalleUnicolor();
            return d_Unicolor.ConsultarId(idUnicolor);
        }
        #endregion

        #region Métodos Solicitud Estampado
        public bool addEstampado(Estampado estampado)
        {
            D_Estampado d_estamapdo = new D_Estampado();
            return (d_estamapdo.Agregar(estampado) == "ok") ? true : false;
        }
        public int getIdSoltelaEst(int idEstamapdo)
        {
            D_Estampado d_Unicolor = new D_Estampado();
            return d_Unicolor.ConsultarIdSolTela(idEstamapdo);
        }
        public bool ActualizarEstampado(Estampado estampado)
        {
            D_Estampado actuEstampado = new D_Estampado();
            return (actuEstampado.Actualizar(estampado) == "ok") ? true : false;
        }
        public bool ActualizarDetalleEstampado(DetalleEstampado detalleEstampado, int idDetalle)
        {
            D_DetalleEstampado objDetalleEditado = new D_DetalleEstampado();
            return (objDetalleEditado.Actualizar(detalleEstampado, idDetalle) == "ok") ? true : false;
        }
       
        
        public List<int> getIdDetalleEst(int idEstampado)
        {
            D_DetalleEstampado d_Unicolor = new D_DetalleEstampado();
            return d_Unicolor.ConsultarId(idEstampado);
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
        public int consultarIdEst(int idSolTelas)
        {
            D_Estampado estampado = new D_Estampado();
            return estampado.consultarIdEst(idSolTelas);
        }
        //public bool consultarIdentificadorEst(string prmIdentificador)
        //{
        //    D_Estampado estampado = new D_Estampado();
        //    return (estampado.consultarIdentificador(prmIdentificador)== "ok")?true :false;
        //}
        public bool consultarIdentificadorEst(int idSolTela)
        {
            D_Estampado objDetalleEditado = new D_Estampado();
            return objDetalleEditado.consultarIdentificador(idSolTela);
        }
        public List<DetalleEstampado> getDetalleEstampado(int idEstampado)
        {
            D_DetalleEstampado d_Estampado = new D_DetalleEstampado();
            return d_Estampado.getDetalleEstampado(idEstampado);
        }
        public Estampado getEstampado(int idSolTela)
        {
            D_Estampado d_Estampado = new D_Estampado();
            return d_Estampado.Consultar(idSolTela);
        }
        public bool agregarConsecutivo(int prmIdsolicitud, int prmIdtipo, string prmTipo, int prmConsecutivo,string fechaSolicitud,string estado, string fechaEstado,string identificador)
        {
            D_TipoSolicitud d_solicitud = new D_TipoSolicitud();
            return (d_solicitud.Agregar(prmIdsolicitud, prmIdtipo, prmTipo, prmConsecutivo, fechaSolicitud,estado,fechaEstado, identificador) == "ok") ? true : false;
        }
        /*Consultar si el Estampado ya tiene un consecutivo */
        public int consultarConsecutivo(int prmIdentificador)
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
        public int getIdPlano(int  idSolTela)
        {
            D_PlanoPretenido d_PlanoPretenido = new D_PlanoPretenido();
            return d_PlanoPretenido.ConsultarIdPla(idSolTela);
        }
        public bool consultarIdentificadorPla(int idSolTela)
        {
            D_PlanoPretenido objDetalleEditado = new D_PlanoPretenido();
            return objDetalleEditado.consultarIdentificador(idSolTela);
        }
        public int getIdSoltelaPla(int idPlano)
        {
            D_PlanoPretenido d_plano = new D_PlanoPretenido();
            return d_plano.ConsultarIdSolTela(idPlano);
        }

        public bool ActualizarPlano(PlanoPretenido platoPretenido)
        {
            D_PlanoPretenido actuPlanoPre = new D_PlanoPretenido();
            return (actuPlanoPre.Actualizar(platoPretenido) == "ok") ? true : false;
        }
        public bool ActualizarDetallePlano(DetallePlanoPretenido detallePlano, int idDetalle)
        {
            D_DetallePlanoPretenido detalleEditado = new D_DetallePlanoPretenido();
            return (detalleEditado.Actualizar(detallePlano, idDetalle) == "ok") ? true : false;
        }
         public List<int> getIdDetallePlano(int idPlano)
        {
            D_DetallePlanoPretenido d_plano = new D_DetallePlanoPretenido();
            return d_plano.ConsultarId(idPlano);
        }
        public PlanoPretenido getPlanoPretenido(int idSolTela)
        {
            D_PlanoPretenido d_PlanoPretenido = new D_PlanoPretenido();
            return d_PlanoPretenido.Consultar(idSolTela);
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

        #region Métodos Solicitud Cuellos-Puños-Tiras

        public int getIdCuellos(int idSolTela)
        {
            D_CuellosTiras d_CuelloId = new D_CuellosTiras();
            return d_CuelloId.ConsultarId(idSolTela);
        }
        
        public CuellosTiras getCuellosTiras(int idSolTela)
        {
            D_CuellosTiras d_CuellosT = new D_CuellosTiras();
            return d_CuellosT.Consultar(idSolTela);
        }
        public int getIdSoltelaCue(int idPlano)
        {
            D_CuellosTiras d_plano = new D_CuellosTiras();
            return d_plano.ConsultarIdSolCuel(idPlano);
        }
        public bool ActualizarCuellos(CuellosTiras cuellosTiras)
        {
            D_CuellosTiras actuCuellos = new D_CuellosTiras();
            return (actuCuellos.Actualizar(cuellosTiras) == "ok") ? true : false;
        }
        public List<int> getIdDetallecuellosUno(int idCuellos)
        {
            D_DetalleCuelloUno d_CuelloUno = new D_DetalleCuelloUno();
            return d_CuelloUno.ConsultarId(idCuellos);
        }
        public List<int> getIdDetallecuellosDos(int idCuellos)
        {
            D_DetalleCuelloDos d_CuelloDos = new D_DetalleCuelloDos();
            return d_CuelloDos.ConsultarId(idCuellos);
        }

        public bool ActualizarDetalleCuelloUno(DetalleCuelloUno detalleCuellosUno, int idDetalle)
        {
            D_DetalleCuelloUno objDetalleEditado = new D_DetalleCuelloUno();
            return (objDetalleEditado.Actualizar(detalleCuellosUno, idDetalle) == "ok") ? true : false;
        }
        public bool ActualizarDetalleCuelloDos(DetalleCuelloDos detalleCuelloDos, int idDetalle)
        {
           D_DetalleCuelloDos objDetalleEditado = new D_DetalleCuelloDos();
            return (objDetalleEditado.Actualizar(detalleCuelloDos, idDetalle) == "ok") ? true : false;
        }
        public bool addCuellosTiras(CuellosTiras cuellosTiras)
        {
            D_CuellosTiras d_CuellosT = new D_CuellosTiras();
            return (d_CuellosT.Agregar(cuellosTiras) == "ok") ? true : false;
        }
        public bool consultarIdentificadorCuel(int idSolTelas)
        {
            D_CuellosTiras cuellos = new D_CuellosTiras();
            return cuellos.consultarIdentificador(idSolTelas);
        }

        public List<DetalleCuelloUno> getDetalleCuellosUno(int idCuellos)
        {
            D_DetalleCuelloUno d_DetalleCuelloUno = new D_DetalleCuelloUno();
            return d_DetalleCuelloUno.Consultar(idCuellos);
        }
        public List<DetalleCuelloDos> getDetalleCuellosDos(int idCuellos)
        {
            D_DetalleCuelloDos d_DetalleCuelloDos = new D_DetalleCuelloDos();
            return d_DetalleCuelloDos.Consultar(idCuellos);
        }
        public void addDetalleCuelloUno(DetalleCuelloUno detalle)
        {
            D_DetalleCuelloUno d_DetalleCuelloUno = new D_DetalleCuelloUno();
            d_DetalleCuelloUno.Agregar(detalle);
        }
        public void addDetalleCuelloDos(DetalleCuelloDos detalle)
        {
            D_DetalleCuelloDos d_DetalleCuelloDos = new D_DetalleCuelloDos();
            d_DetalleCuelloDos.Agregar(detalle);
        }

        public void guardarImagen(string ruta, Image imagen, string nombre, string tipo)
        {
            if (!Directory.Exists(ruta))
            {
                DirectoryInfo di = Directory.CreateDirectory(ruta);
            }
            ImageFormat formato = ImageFormat.Jpeg;
            if (tipo.ToLower().Equals("png"))
            {
                formato = ImageFormat.Png;
            }
            imagen.Save(ruta + nombre, formato);
        }


        #endregion

        #region Métodos de Solicitud lista telas
        public List<DetalleListaTela> consultarListaTelas(ListaTela lista)
        {
            D_DetalleListaTela d_detalle = new D_DetalleListaTela();
            return d_detalle.Consultar(lista);
        }
        public List<Objeto> getNomTelas()
        {
            D_DetalleListaTela objNomTelas = new D_DetalleListaTela();

            return objNomTelas.consultarNomTela();
        }
        public List<Objeto> getRefTelas()
        {
            D_DetalleListaTela objRefTelas = new D_DetalleListaTela();

            return objRefTelas.consultarRefTela();
        }
        public List<Objeto> getColoresT()
        {
            D_DetalleListaTela objColores = new D_DetalleListaTela();

            return objColores.consultarColoresT();
        }
        public List<Objeto> getTipoSol()
        {
            D_DetalleListaTela objTipo = new D_DetalleListaTela();

            return objTipo.getTipoSol();
        }
        public bool setMCalculados(int  idSolTela, string mCalculados)
        {
            D_DetalleListaTela objDetalleEditado = new D_DetalleListaTela();
            // return (d_Detalle.Agregar(detalle) == "ok") ? true : false;
            return (objDetalleEditado.setMCalculados(idSolTela, mCalculados) == "ok") ? true : false;

        }
        #endregion
        
        #region Métodos Analizar inventario
        public bool setEstado(int idSolTela,string estado,string fechaEstado )
        {
            D_AnalizarInventario objDetalleEditado = new D_AnalizarInventario();
            // return (d_Detalle.Agregar(detalle) == "ok") ? true : false;
            return (objDetalleEditado.setEstadoSolicitud(idSolTela, estado,fechaEstado) == "ok") ? true : false;

        }
        public bool setMaReservar(int idSolTela, string maReservar, string cantidadReservada)
        {
            D_AnalizarInventario objDetalleEditado = new D_AnalizarInventario();
            // return (d_Detalle.Agregar(detalle) == "ok") ? true : false;
            return (objDetalleEditado.setMaReservar(idSolTela, maReservar, cantidadReservada) == "ok") ? true : false;

        }
        public bool AtualizarCalculados(int idSolTela, string mCalculados,string maReservar, string maSolicitar)
        {
            D_AnalizarInventario objDetalleEditado = new D_AnalizarInventario();
            // return (d_Detalle.Agregar(detalle) == "ok") ? true : false;
            return (objDetalleEditado.Actualizar(idSolTela, mCalculados, maReservar, maSolicitar) == "ok") ? true : false;

        }
        public List<AnalizarInventario> consultarInvertario(int idSolTela)
        {
            D_AnalizarInventario d_analizar = new D_AnalizarInventario();
            return d_analizar.Consultar(idSolTela);
        }
        #endregion

        #region Métodos Disponible para Reserva
        public DisponibleParaReserva consultarPedido(string identificador, string codigoTela, string CodigoColor)
        {
            D_DisponibleParaReserva d_Unicolor = new D_DisponibleParaReserva();
            return d_Unicolor.Consultar(identificador, codigoTela, CodigoColor);
        }
        #endregion
    }
}
