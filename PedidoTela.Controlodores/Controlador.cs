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
        public List<MontajeTelaDetalle> consultarListaTelas(MontajeTela lista)
        {
            D_DetalleListaTela d_detalle = new D_DetalleListaTela();
            return d_detalle.ConsultarPedido(lista);
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

            return objTipo.ConsultarTipoSolocitud();
        }
        public bool setMCalculados(int  idSolTela, string mCalculados)
        {
            D_DetalleListaTela objDetalleEditado = new D_DetalleListaTela();
            // return (d_Detalle.Agregar(detalle) == "ok") ? true : false;
            return (objDetalleEditado.ActualizarMCalculados(idSolTela, mCalculados) == "ok") ? true : false;

        }
        #endregion
        
        #region Métodos Analizar inventario
        public bool actualizarEstado(int idSolTela,string estado,string fechaEstado )
        {
            D_AnalizarInventario objDetalleEditado = new D_AnalizarInventario();
            return (objDetalleEditado.setEstadoSolicitud(idSolTela, estado,fechaEstado) == "ok") ? true : false;

        }
        public bool setMaReservar(int idSolTela, string maReservar, string cantidadReservada)
        {
            D_AnalizarInventario objDetalleEditado = new D_AnalizarInventario();
            return (objDetalleEditado.setMaReservar(idSolTela, maReservar, cantidadReservada) == "ok") ? true : false;

        }
        public bool AtualizarCalculados(int idSolTela, string mCalculados,string maReservar, string maSolicitar)
        {
            D_AnalizarInventario objDetalleEditado = new D_AnalizarInventario();
            return (objDetalleEditado.Actualizar(idSolTela, mCalculados, maReservar, maSolicitar) == "ok") ? true : false;

        }
        public List<AnalizarInventario> consultarInvertario(int idSolTela)
        {
            D_AnalizarInventario d_analizar = new D_AnalizarInventario();
            return d_analizar.Consultar(idSolTela);
        }
        #endregion

        #region Métodos Disponible para Reserva
        public DisponibleParaReserva consultarPedido(int idProgramador, string codigoTela, string CodigoColor)
        {
            D_DisponibleParaReserva d_disponibleParaReseva = new D_DisponibleParaReserva();
            return d_disponibleParaReseva.Consultar(idProgramador, codigoTela, CodigoColor);
        }
        #endregion

        #region Métodos Agencias Externos

        public bool ExisteAgenciasExterno(int idSolTelas)
        {
            D_AgenciasExterno d_agenciasExterno = new D_AgenciasExterno();
            return d_agenciasExterno.consultarExisteAgencias(idSolTelas);
        }

        public bool ActualizarAgenciasExterno(AgenciasExternos agenciasExternos)
        {
           D_AgenciasExterno d_agenciasExterno = new D_AgenciasExterno();
            return (d_agenciasExterno.Actualizar(agenciasExternos) == "ok") ? true : false;
        }
        
        public bool addAgenciaExterno(AgenciasExternos agenciasExternos)
        {
            D_AgenciasExterno d_agenciasExterno = new D_AgenciasExterno();
            return (d_agenciasExterno.Agregar(agenciasExternos) == "ok") ? true : false;
        }

        public int getIdAgenciasExterno(int idSolTela)
        {
            D_AgenciasExterno d_agencias = new D_AgenciasExterno();
            return d_agencias.ConsultarId(idSolTela);
        }
        
        public AgenciasExternos getAgenciasExterno(int idSolTela)
        {
            D_AgenciasExterno d_agencias = new D_AgenciasExterno();
            return d_agencias.Consultar(idSolTela);
        }
        
        public List<Objeto> getComposicion()
        {
            D_Composicion objTipo = new D_Composicion();

            return objTipo.getComposicion();
        }
        
        /* INFROMACIÓN A CONSOLIDAR */
       
        public void addInfoConsolidar(AgenciasInfoConsolidar detalle)
        {
            D_AgenciasInfoConsolidar d_agenciasExternoInfo = new D_AgenciasInfoConsolidar();
            d_agenciasExternoInfo.Agregar(detalle);
        }
        
        public List<AgenciasInfoConsolidar> getInfoConsolidar(int idAgencias)
        {
           D_AgenciasInfoConsolidar d_agenciasExternoInfo = new D_AgenciasInfoConsolidar();
            return d_agenciasExternoInfo.getDetalleInfoConsolidar(idAgencias);
        }

        public void eliminarAgenciasExternoInformacion(int idAgencias)
        {
            D_AgenciasInfoConsolidar d_agenciasExternoInfo = new D_AgenciasInfoConsolidar();
            d_agenciasExternoInfo.EliminarAgenciasExternoInfo(idAgencias);
        }

        /* TOTAL A CONSOLIDAR */

        public void addTotalConsolidar(AgenciaTotalConsolidar detalle)
        {
            D_AgenciasTotalConsolidado d_agenciasExternoTotal = new D_AgenciasTotalConsolidado();
            d_agenciasExternoTotal.Agregar(detalle);
        }

        public List<AgenciaTotalConsolidar> getTotalConsolidado(int idAgencias)
        {
            D_AgenciasTotalConsolidado d_agenciasExternoTotal = new D_AgenciasTotalConsolidado();
            return d_agenciasExternoTotal.getDetalleTotalConsolidado(idAgencias);
        }
       
        public void eliminarAgenciasExternoTotal(int idAgencias)
        {
            D_AgenciasTotalConsolidado d_agenciasExternoTotal = new D_AgenciasTotalConsolidado();
            d_agenciasExternoTotal.EliminarAgenciasExternoInfo(idAgencias);
        }
        #endregion

        #region Pedido Unicolor

        public bool existePedidoUnicolor(int idSolTelas)
        {
            D_PedidoUnicolor d_pedUnicolor = new D_PedidoUnicolor();
            return d_pedUnicolor.consultarExistePedido(idSolTelas);
        }
       
        public PedidoAMontar getPedUnicolor(int idSolTela)
        {
           D_PedidoUnicolor d_pedUnicolor = new D_PedidoUnicolor();
            return d_pedUnicolor.Consultar(idSolTela);
        }

        public bool addPedUnicolor(PedidoAMontar pedUnicolor)
        {
           D_PedidoUnicolor d_pedUnicolor = new D_PedidoUnicolor();
            return (d_pedUnicolor.Agregar(pedUnicolor) == "ok") ? true : false;
        }

        public int getIdPedUnicolor(int idSolTela)
        {
            D_PedidoUnicolor d_pedUnicolor = new D_PedidoUnicolor();
            return d_pedUnicolor.ConsultarId(idSolTela);
        }
        
        public bool actualizarPedidoUnicolor(PedidoAMontar pedUnicolor)
        {
            D_PedidoUnicolor actuPedUnicolor = new D_PedidoUnicolor();
            return (actuPedUnicolor.Actualizar(pedUnicolor) == "ok") ? true : false;
        }

        /* INFROMACIÓN A CONSOLIDAR */

        public void addPedUnicolorInfoCon(PedidoMontarInformacion detalle)
        {
            D_PedidoUnicolorInfomacion d_infoConsolidar = new D_PedidoUnicolorInfomacion();
            d_infoConsolidar.Agregar(detalle);
        }
        
        public List<PedidoMontarInformacion> getPedUnicolorInfoCon(int idPedUnicolor)
        {
            D_PedidoUnicolorInfomacion d_pedUniInfoCon = new D_PedidoUnicolorInfomacion();
            return d_pedUniInfoCon.ConsultarInfoConsolidar(idPedUnicolor);
        }
       
        public void eliminarPedidoUnicolorInformacion(int idPedido)
        {
            D_PedidoUnicolorInfomacion d_PedidoUnicolorInfomacion = new D_PedidoUnicolorInfomacion();
            d_PedidoUnicolorInfomacion.EliminarPorPedido(idPedido);
        }

        /* TOTAL CONSOLIDAR */

        public void addPedUnicolorTotalCons(PedidoMontarTotal detalle)
        {
            D_PedidoUnicolorTotal d_totalConsolidar = new D_PedidoUnicolorTotal();
            d_totalConsolidar.Agregar(detalle);
        }
              
        public List<PedidoMontarTotal> getPedUnicolorTotalCon(int idPedUnicolor)
        {
            D_PedidoUnicolorTotal d_pedUniTotalcon = new D_PedidoUnicolorTotal();
            return d_pedUniTotalcon.ConsultarTotalConsolidado(idPedUnicolor);
        }
        
        public void eliminarPedidoUnicolorTotal(int idPedido)
        {
            D_PedidoUnicolorTotal d_PedidoUnicolorTotal = new D_PedidoUnicolorTotal();
            d_PedidoUnicolorTotal.EliminarPorPedido(idPedido);
        }

        #endregion

        #region Pedido Estampado
        public PedidoAMontar getPedidoEstampado(int idSolicitud)
        {
            D_PedidoEstampado d_PedidoEstampado = new D_PedidoEstampado();
            return d_PedidoEstampado.Consultar(idSolicitud);
        }

        public int getIdPedidoEstampado(int idSolicitud)
        {
            D_PedidoEstampado d_PedidoEstampado = new D_PedidoEstampado();
            return d_PedidoEstampado.ConsultarId(idSolicitud);
        }

        public bool existePedidoEstampado(int idSolicitud)
        {
            D_PedidoEstampado d_PedidoEstampado = new D_PedidoEstampado();
            return d_PedidoEstampado.consultarExistePedido(idSolicitud);
        }
        public bool addPedidoEstampado(PedidoAMontar pedido)
        {
            D_PedidoEstampado d_PedidoEstampado = new D_PedidoEstampado();
            return (d_PedidoEstampado.Agregar(pedido) == "ok") ? true : false;
        }
        public bool actualizarPedidoEstampado(PedidoAMontar pedido)
        {
            D_PedidoEstampado d_PedidoEstampado = new D_PedidoEstampado();
            return (d_PedidoEstampado.Actualizar(pedido) == "ok") ? true : false;
        }
        

        //Información
        public List<int> getIdPedidoEstampadoInformacion(int idPedido)
        {
            D_PedidoEstampadoInfomacion d_PedidoEstampadoInfomacion = new D_PedidoEstampadoInfomacion();
            return d_PedidoEstampadoInfomacion.ConsultarId(idPedido);
        }
        public void addPedidoEstampadoInformacion(PedidoMontarInformacion detalle)
        {
            D_PedidoEstampadoInfomacion d_PedidoEstampadoInfomacion = new D_PedidoEstampadoInfomacion();
            d_PedidoEstampadoInfomacion.Agregar(detalle);
        }
        public bool actualizarPedidoEstampadoInformacion(PedidoMontarInformacion informacion, int idDetalle)
        {
            D_PedidoEstampadoInfomacion d_PedidoEstampadoInfomacion = new D_PedidoEstampadoInfomacion();
            return (d_PedidoEstampadoInfomacion.Actualizar(informacion, idDetalle) == "ok") ? true : false;
        }
        public List<PedidoMontarInformacion> getPedidoEstampadoInformacion(int idPedido)
        {
            D_PedidoEstampadoInfomacion d_PedidoEstampadoInfomacion = new D_PedidoEstampadoInfomacion();
            return d_PedidoEstampadoInfomacion.Consultar(idPedido);
        }
        public void eliminarPedidoEstampadoInformacion(int idPedido)
        {
            D_PedidoEstampadoInfomacion d_PedidoEstampadoInfomacion = new D_PedidoEstampadoInfomacion();
            d_PedidoEstampadoInfomacion.EliminarPorPedido(idPedido);
        }

        //Total
        public List<int> getIdPedidoEstampadoTotal(int idPedUnicolor)
        {
            D_PedidoEstampadoTotal d_PedidoEstampadoTotal = new D_PedidoEstampadoTotal();
            return d_PedidoEstampadoTotal.ConsultarId(idPedUnicolor);
        }
        public List<PedidoMontarTotal> getPedidoEstampadoTotal(int idPedUnicolor)
        {
            D_PedidoEstampadoTotal d_PedidoEstampadoTotal = new D_PedidoEstampadoTotal();
            return d_PedidoEstampadoTotal.ConsultarTotalConsolidado(idPedUnicolor);
        }

        public void addPedidoEstampadoTotal(PedidoMontarTotal detalle)
        {
            D_PedidoEstampadoTotal d_PedidoEstampadoTotal = new D_PedidoEstampadoTotal();
            d_PedidoEstampadoTotal.Agregar(detalle);
        }
        public bool actualizarPedidoEstampadoTotal(PedidoMontarTotal totalConsolidar, int idDetalle)
        {
            D_PedidoEstampadoTotal d_PedidoEstampadoTotal = new D_PedidoEstampadoTotal();
            return (d_PedidoEstampadoTotal.Actualizar(totalConsolidar, idDetalle) == "ok") ? true : false;
        }

        public void eliminarPedidoEstampadoTotal(int idPedido)
        {
            D_PedidoEstampadoTotal d_PedidoEstampadoTotal = new D_PedidoEstampadoTotal();
            d_PedidoEstampadoTotal.EliminarPorPedido(idPedido);
        }
        #endregion

        #region Pedido Plano Preteñido

        /// <summary>
        /// Obtiene la información almacenada referente a la vista frmPedidoMontarPreteñido
        /// </summary>
        /// <param name="idSolTela">Id de la solicitud de telas.</param>
        /// <returns>Retorna un objeto de tipo PedidoAMontar.</returns>
        public PedidoAMontar getPedidoPlano(int idSolTela)
        {
            D_PedidoPlanoPretenido d_pedidoPlano = new D_PedidoPlanoPretenido();
            return d_pedidoPlano.Consultar(idSolTela);
        }

        /// <summary>
        /// Permite consultar si el ensayo o referencia ya se encuentra alamacenado.
        /// </summary>
        /// <param name="prmIdSolicitudTelas">Id de la solitud de tela,</param>
        /// <returns>Retor True si ya está alamcenado, False de los contrario</returns>
        public bool existePedidoPlano(int prmIdSolicitudTelas)
        {
            D_PedidoPlanoPretenido d_pedidoPlano = new D_PedidoPlanoPretenido();
            return d_pedidoPlano.ExistePedido(prmIdSolicitudTelas);
        }
        
        public int getIdPedplano(int idSolTela)
        {
            D_PedidoPlanoPretenido d_pedPlano = new D_PedidoPlanoPretenido();
            return d_pedPlano.ConsultarId(idSolTela);
        }

        /// <summary>
        /// Permite Actualizar los campos de la entidad cfc_spt_ped_plano
        /// </summary>
        /// <param name="prmPedidoPlano">Objeto de Tipo PedidoAMontar, el cual representa el encabezado de la vista pedido a Montar Plano Preteñido.</param>
        /// <returns>Retorn True si ha Actualizado la información, False de lo contrario.</returns>
        public bool actualizarPedidoPlano(PedidoAMontar prmPedidoPlano)
        {
            D_PedidoPlanoPretenido d_pedidoPlano = new D_PedidoPlanoPretenido();
            return (d_pedidoPlano.Actualizar(prmPedidoPlano) == "ok") ? true : false;
        }

        /// <summary>
        /// Almacena la información en la entidad cfc_spt_ped_plano
        /// </summary>
        /// <param name="prmPedidoPlano">Objeto de tipo PedidoAMontar, el cual representa el encabezado de la vista Pedido a Montar Unicolor.</param>
        /// <returns>Retorna True si se ha guardado correctamente la información, False de lo contrario.</returns>
        public bool agregarPedidoPlano(PedidoAMontar prmPedidoPlano)
        {
            D_PedidoPlanoPretenido d_pedidoPlano = new D_PedidoPlanoPretenido();
            return (d_pedidoPlano.Agregar(prmPedidoPlano) == "ok") ? true : false;
        }

        /* INNFORMACIÓN A CONSOLIDAR */

        /// <summary>
        /// Agrega cada una de las filas de DatagridView (dgvInfoConsolidar) 
        /// </summary>
        /// <param name="detalle">Objeto de tipo PedidoMontarTotal que representa la fial actual.</param>
        public void addPedidoPlanoInfo(PedidoMontarInformacion detalle)
        {
            D_PedidoPlanoInformacion d_infoConsolidar = new D_PedidoPlanoInformacion();
            d_infoConsolidar.Agregar(detalle);
        }

        public List<PedidoMontarInformacion> getPedidoPlanoInfo(int idPedUnicolor)
        {
            D_PedidoPlanoInformacion d_pedUniInfoCon = new D_PedidoPlanoInformacion();
            return d_pedUniInfoCon.ConsultarInfoConsolidar(idPedUnicolor);
        }
       
        public void eliminarPedidoPlanoInformacion(int idPedido)
        {
            D_PedidoPlanoInformacion d_PedidoPlanoTotal = new D_PedidoPlanoInformacion();
            d_PedidoPlanoTotal.EliminarPorPedido(idPedido);
        }

        /*TOTAL A CONSOLIDAR*/ 

        /// <summary>
        /// Agrega cada una de las filas de DatagridView (dgvTotalConsolidar) 
        /// </summary>
        /// <param name="detalle">Objeto de tipo PedidoMontarTotal que representa la fila actual.</param>
        public void addPedPlanoTotal(PedidoMontarTotal detalle)
        {
            D_PedidoPlanoTotal d_totalConsolidar = new D_PedidoPlanoTotal();
            d_totalConsolidar.Agregar(detalle);
        }

        public List<PedidoMontarTotal> getPedidoPlanoTotal(int idPedUnicolor)
        {
            D_PedidoPlanoTotal d_pedUniTotalcon = new D_PedidoPlanoTotal();
            return d_pedUniTotalcon.ConsultarTotalConsolidado(idPedUnicolor);
        }

        public void eliminarPedidoPlanoTotal(int idPedido)
        {
            D_PedidoPlanoTotal d_PedidoPnanoTotal = new D_PedidoPlanoTotal();
            d_PedidoPnanoTotal.EliminarPorPedido(idPedido);
        }

        #endregion

        #region Pedido Cuellos-Puños-Tiras

        /* ENCABEZADO */
        public bool existePedidoCuellos(int idSolTelas)
        {
            D_PedidoCuellos d_pedUnicolor = new D_PedidoCuellos();
            return d_pedUnicolor.consultarExistePedido(idSolTelas);
        }
        public bool addPedidoCuellos(PedidoAMontar pedidoCuellos)
        {
            D_PedidoCuellos d_pedidoCuellos = new D_PedidoCuellos();
            return (d_pedidoCuellos.Agregar(pedidoCuellos) == "ok") ? true : false;
        }
        public int getIdPedidoCuellos(int idSolTela)
        {
            D_PedidoCuellos d_pedidoCuellos = new D_PedidoCuellos();
            return d_pedidoCuellos.ConsultarId(idSolTela);
        }
        public bool actualizarPedidoCuellos(PedidoAMontar pedUnicolor)
        {
            D_PedidoCuellos actualizarPedidoCuellos = new D_PedidoCuellos();
            return (actualizarPedidoCuellos.Actualizar(pedUnicolor) == "ok") ? true : false;
        }
        public PedidoAMontar getPedidoCuellos(int idSolTela)
        {
            D_PedidoCuellos d_pedidoCuellos = new D_PedidoCuellos();
            return d_pedidoCuellos.Consultar(idSolTela);
        }
        /* INFROMACIÓN A CONSOLIDAR */

        public void addPedidoCuellosInfo(PedidoMontarInformacion detalle)
        {
            D_PedidoCuellosInformacion d_infoConsolidar = new D_PedidoCuellosInformacion();
            d_infoConsolidar.Agregar(detalle);
        }
        public void eliminarPedidoCuellosInformacion(int idPedido)
        {
            D_PedidoCuellosInformacion d_PedidoCuellosInfomacion = new D_PedidoCuellosInformacion();
            d_PedidoCuellosInfomacion.EliminarPorPedido(idPedido);
        }

        public List<PedidoMontarInformacion> getPedidoCuellosInfo(int idPedidoCuellos)
        {
            D_PedidoCuellosInformacion d_pedUniInfoCon = new D_PedidoCuellosInformacion();
            return d_pedUniInfoCon.ConsultarInformacion(idPedidoCuellos);
        }

        /* PROPORCIÓN */
        public void addPedidoCuellosProporcion(PedidoCuellos detalle)
        {
            D_PedidoCuellosProporcion d_pedidoCuellosProporcion = new D_PedidoCuellosProporcion();
            d_pedidoCuellosProporcion.Agregar(detalle);
        }
        public void eliminarPedidoCuellosProporcion(int idPedido)
        {
            D_PedidoCuellosProporcion d_PedidoCuellosProporcion = new D_PedidoCuellosProporcion();
            d_PedidoCuellosProporcion.EliminarPorPedido(idPedido);
        }
        public List<PedidoCuellos> getPedidoCuellosProporcion(int idPedidoCuellos)
        {
            D_PedidoCuellosProporcion d_pedidoCuellosproporcion = new D_PedidoCuellosProporcion();
            return d_pedidoCuellosproporcion.Consultar(idPedidoCuellos);
        }
        #endregion

        #region Pedido Coordinado Tres en Uno

        #endregion

        #region Pedido Agencias-Externos

        #endregion

        #region Métodos Consolidar
        public List<Objeto> getTipoMarcacion() {
            D_TipoMarcacion tm = new D_TipoMarcacion();
            return tm.consultar();
        }
        
        public int consultarMaxConsolidado()
        {
            D_Consolidado d_consolidado = new D_Consolidado();
            return d_consolidado.ConsultarMaxConsolidado();
        }
        
        public int consultarMaxConsecutivoPedido()
        {
            D_Consolidado d_solicitud = new D_Consolidado();
            return d_solicitud.consultarMaxconsecutivo();
        }
        
        public bool agregarConsecutivo(int prmIdsolicitud,  int prmConsecutivo, string prmFecha, string prmEstado)
        {
            D_Consolidado d_consolidado = new D_Consolidado();
            return (d_consolidado.AgregarConsecutivo(prmIdsolicitud, prmConsecutivo, prmFecha, prmEstado) == "ok") ? true : false;
        }
        
        public bool agregarConsolidado(int prmIdsolicitud, int prmConsolidado,string prmTipoPedido)
        {
            D_Consolidado d_consolidado = new D_Consolidado();
            return (d_consolidado.ActualizarConsolidado(prmIdsolicitud, prmConsolidado, prmTipoPedido) == "ok") ? true : false;
        }
        public int consultarConsecutivoPedido(int prmIdSolicitud)
        {
            D_Consolidado d_solicitud = new D_Consolidado();
            return (d_solicitud.consultarConsecutivoPedido(prmIdSolicitud));
        }

        #endregion

        #region Tomar del Pedido
        public List<TomarDelPedido> consultarPedidoPorDisenador(int disenador)
        {
            D_TomarDelPedido d_tomarDelPedido = new D_TomarDelPedido();
            return d_tomarDelPedido.Consultar(disenador);
        }
        public List<TomarDelPedido> consultarPorNumeroPedido(int disenador, string numeroPedido)
        {
            D_TomarDelPedido d_tomarDelPedido = new D_TomarDelPedido();
            return d_tomarDelPedido.ConsultarPorNumeroPedido(disenador, numeroPedido);
        }
        public List<TomarDelPedido> consultarPorCodigoColor(int disenador, string codigoColor)
        {
            D_TomarDelPedido d_tomarDelPedido = new D_TomarDelPedido();
            return d_tomarDelPedido.ConsultarPorCodigoColor(disenador, codigoColor);
        }

        public void addPedido(TomarDelPedido detalle)
        {
            D_TomarDelPedido d_tomarDelPedido = new D_TomarDelPedido();
            d_tomarDelPedido.Agregar(detalle);
        }
        public void eliminarPedido(int idPedido)
        {
            D_TomarDelPedido d_tomarDelPedido = new D_TomarDelPedido();
            d_tomarDelPedido.EliminarPedido(idPedido);
        }
        public List<TomarDelPedido> getPedido(int idPedido)
        {
            D_TomarDelPedido d_tomarDelPedido = new D_TomarDelPedido();
            return d_tomarDelPedido.ConsultarPedido(idPedido);
        }

        #endregion
    }
}
