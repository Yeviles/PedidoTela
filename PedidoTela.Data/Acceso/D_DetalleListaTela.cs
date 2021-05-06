using IBM.Data.Informix;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoTela.Data.Acceso
{
    public class D_DetalleListaTela
    {
        #region Consultas SQL

        string consultaPedido = "select  NVL(ts.consolidado,'') as consolidado, ts.consecutivo as solicitud,ts.tipo as tipo_solicitud,st.tipo as ensayo_ref, ts.identificador, NVL(es.n_dibujos,'0') as n_dibujos, " +
                           "   NVL(de.fondo,'') as cod_fondo,NVL(de.des_fondo,'')as des_fondo,CONCAT(CONCAT(NVL(es.tipo_tejido,''),NVL(un.tipo_tejido,'')),NVL(pl.tipo_tejido,'')) as tipo_tela, " +
                           "   CONCAT(CONCAT(CONCAT (NVL(pl.coordinado,''),NVL(es.coordinado,'')),NVL(un.coordinado,'')),NVL(cu.coordinado,'')) as coordinado, " +
                           "   CONCAT(CONCAT(CONCAT(NVL(un.coordinado_con,''),NVL(cu.coordinadocon,'')),NVL(es.coordinado_con,'')),NVL(pl.coordinado_con,'')) as coordinado_con, " +
                           "   st.referencia_tela,st.desc_tela, st.referencia_tela,st.desc_tela, (CONCAT(CONCAT(CONCAT(NVL(cd.codigo_vte,''),NVL(pd.codigo_vte,'')),NVL(du.codigo_color,'')),NVL(de.codigocolor,''))) as codigo_vte, " +
                           "   CONCAT(CONCAT(CONCAT(NVL(pd.descripcion_vte,''),NVL(cd.descripcion_vte, '')),NVL(de.desc_color,'')),NVL(c.desc_color,'')) as descripcion_vte, " +
                           "   CONCAT(CONCAT(CONCAT(NVL(pd.total, ''),NVL(cd.total, '')),NVL(de.total, '')),NVL(du.total, '')) as total_unidades,st.consumo,st.muestrario,me.desc_mstrrio, " +
                           "   mu.desc_mundo as ocasion_uso,cp.nombre as tema, en.desc_entrada as entrada,st.fecha_tienda,NVL((us.nombre),'') as disenador, " +
                           "   CONCAT(CONCAT (CONCAT(NVL(cu.observacion,''),NVL(es.observaciones,'')),NVL(un.observacion,'')),NVL(pl.observacion,'')) as observaciones, " +
                           "   NVL(ts.fecha_solicitud,'') as fecha_solicitud, NVL(ts.estado,'')as estado,NVL(ts.fecha_estado,'') as fecha_estado, " +
                           "   CONCAT(CONCAT(NVL(du.tiendas, ''), NVL(de.tiendas, '')), NVL(pd.tiendas, '')) as tiendas, " +
                           "   CONCAT(CONCAT(NVL(du.exito, ''), NVL(de.exito, '')), NVL(pd.exito, '')) as exito, " +
                           "   CONCAT(CONCAT(NVL(du.cencosud,''),NVL(de.cencosud,'')),NVL(pd.cencosud,'')) as cencosud, " +
                           "   CONCAT(CONCAT(NVL(du.sao,''), NVL(de.sao,'')), NVL(pd.sao,'')) as sao, " +
                           "   CONCAT(CONCAT(NVL(du.comercio,''), NVL(de.comercio,'')), NVL(pd.comercio,'')) as comercio, " +
                           "   CONCAT(CONCAT(NVL(du.rosado,''), NVL(de.rosado,'')), NVL(pd.rosado,'')) as rosado, " +
                           "   CONCAT(CONCAT(NVL(du.otros,''), NVL(de.otros,'')), NVL(pd.otros,'')) as otros, NVL(li.desc_linea,'') as desc_linea, " +
                           "   NVL(st.m_calculados,'') as m_calculados, NVL(st.m_reservar,'') as m_reservar, NVL(st.m_solicitar,'') as m_solicitar,st.idsolicitud,NVL(st.cantidad_reservado,'') as cantidad_reservado,  " +
                           "   CONCAT(CONCAT(CONCAT(NVL(du.id,''),NVL(de.iddetalleest,'')),NVL(pd.id,'')), NVL(cd.iddetallecuellodos,'')) as idDetalleSol, NVL(st.id_programador,0) as id_programador, st.desc_prenda, " +
                           "   NVL(pd.codigo_h1, 0) as codigo_h1, NVL(pd.descripcion_h1, '') as descripcion_h1, NVL(pd.codigo_h2,0) as codigo_h2, NVL(pd.descripcion_h2,'') as descripcion_h2, NVL(pd.codigo_h3,0) as codigo_h3, " +
                           "   NVL(pd.descripcion_h3,'') as descripcion_h3, NVL(pd.codigo_h4,0) as codigo_h4, NVL(pd.descripcion_h4,'') as descripcion_h4, NVL(pd.codigo_h5,0) as codigo_h5, NVL(pd.descripcion_h5,'') as descripcion_h5  "+
                           "   from  cfc_spt_tipo_solicitud ts " +
                           "   left join cfc_spt_sol_tela st " +
                           "   on ts.id_solicitud = st.idsolicitud " +
                           "   left join cfc_e_mundo mu on st.idmundo = mu.idmundo " +
                           "   left join cfc_m_capsulas cp on cp.idcapsula = st.codi_capsula " +
                           "   left join cfc_e_entrada en on en.codi_entrada = st.codi_entrada " +
                           "   left join cfc_m_usuarios us on us.idusuario = st.idusuario " +
                           "   left join m_muestrario me on st .muestrario = me.nmro_mstrrio " +
                           "   left join cfc_e_lineas li on li.codi_linea = st.codi_linea " +
                           "   left join cfc_spt_sol_unicolor un " +
                           "   on ts.id_solicitud = un.id_sol_tela " +
                           "   left join cfc_spt_sol_unicolor_detalle du on du.idunicolor = un.idunicolor " +
                           "   left join cfc_spt_sol_estampado es " +
                           "   on ts.id_solicitud = es.id_sol_tela " +
                           "   left join cfc_spt_sol_detalleestampado de on es.idestampado  = de.idestampado " +
                           "   left join cfc_spt_sol_plano_pretenido pl " +
                           "   on ts.id_solicitud = pl.id_sol_tela " +
                           "   left join cfc_spt_sol_plano_pretenido_detalle pd on pd.idplano = pl.idplano " +
                           "   left join cfc_spt_sol_Cuellos cu " +
                           "   on ts.id_solicitud = cu.id_sol_tela " +
                           "   left join cfc_spt_sol_detalle_cuello_dos cd on cu.idcuellos = cd.idcuellos " +
                           "   left join inmcolor c " +
                           "   on du.codigo_color = c.codi_color ";
        private readonly string consultaNombreTela = "select referencia_tela,desc_tela from cfc_spt_sol_tela;";

        private readonly string consultaColores = " select distinct(CONCAT(CONCAT(CONCAT(NVL(cd.codigo_vte,''),NVL(pd.codigo_vte,'')),NVL(du.codigo_color,'')),NVL(de.codigocolor,''))) as codigo_vte, " +
                                               " CONCAT(CONCAT(CONCAT(NVL(pd.descripcion_vte,''),NVL(cd.descripcion_vte, '')),NVL(de.desc_color,'')),NVL(c.desc_color,'')) as descripcion_vte " +
                                               " from  cfc_spt_tipo_solicitud ts " +
                                               " left join cfc_spt_sol_tela st " +
                                               " on ts.id_solicitud = st.idsolicitud " +
                                               " left join cfc_spt_sol_plano_pretenido pl " +
                                               " on ts.id_solicitud = pl.id_sol_tela " +
                                               " left join cfc_spt_sol_plano_pretenido_detalle pd on pd.idplano = pl.idplano " +
                                               " left join cfc_spt_sol_Cuellos cu " +
                                               " on ts.id_solicitud = cu.id_sol_tela " +
                                               " left join cfc_spt_sol_detalle_cuello_dos cd on cu.idcuellos = cd.idcuellos " +
                                               " left join cfc_spt_sol_estampado es " +
                                               " on ts.id_solicitud = es.id_sol_tela " +
                                               " left join cfc_spt_sol_detalleestampado de on es.idestampado  = de.idestampado " +
                                               " left join cfc_spt_sol_unicolor un " +
                                               " on un.id_sol_tela = ts.id_solicitud " +
                                               " left join cfc_spt_sol_unicolor_detalle du on du.idunicolor = un.idunicolor " +
                                               " left join inmcolor c " +
                                               " on du.codigo_color = c.codi_color; ";
        private readonly string actualizarMCalculados = "update cfc_spt_sol_tela set m_calculados =? where idsolicitud = ?;";

        private readonly string consultaTipoSol = "select distinct (tipo) from cfc_spt_tipo_solicitud;";

        #endregion

        #region Métodos de Consulta

        public List<MontajeTelaDetalle> ConsultarPedido(MontajeTela objTela)
        {
            List<MontajeTelaDetalle> listaTelas = new List<MontajeTelaDetalle>();
            using (var con = new clsConexion())
            {
                #region clausula where
                string clausulaWhere = "";
                if (objTela.TipoSolicitud.ToString().Trim() != "" || objTela.Muestrario.ToString().Trim() != "" || objTela.OcasionUso.ToString().Trim() != "" || objTela.Tema.ToString().Trim() != ""
                    || objTela.Entrada.ToString().Trim() != "" || objTela.Disenador.ToString().Trim() != "" || objTela.EnsayoRefSimilar.ToString().Trim() != "" || objTela.Estado.ToString().Trim() != ""
                    || objTela.FechaTienda.ToString().Trim() != "" || objTela.RefTela.ToString().Trim() != "" || objTela.NomTela.ToString().Trim() != "" || objTela.Solicitud.ToString().Trim() != ""
                    || objTela.Color.ToString().Trim() != "" || objTela.Clase.ToString().Trim() != "" || objTela.Coordinado.ToString().Trim() != "" || objTela.NumDibujo.ToString().ToString() != "")
                {
                    clausulaWhere += "WHERE ";
                }

                if (objTela.TipoSolicitud.ToString().Trim() != "")
                {
                    clausulaWhere += "ts.tipo = ? ";
                    con.Parametros.Add(new IfxParameter("@tipo_solicitud", objTela.TipoSolicitud.ToString()));

                    if (objTela.Muestrario.ToString().Trim() != "" || objTela.OcasionUso.ToString().Trim() != "" || objTela.Tema.ToString().Trim() != ""
                        || objTela.Entrada.ToString().Trim() != "" || objTela.Disenador.ToString().Trim() != "" || objTela.EnsayoRefSimilar.ToString().Trim() != "" || objTela.Estado.ToString().Trim() != ""
                        || objTela.FechaTienda.ToString().Trim() != "" || objTela.RefTela.ToString().Trim() != "" || objTela.NomTela.ToString().Trim() != "" || objTela.Solicitud.ToString().Trim() != ""
                        || objTela.Color.ToString().Trim() != "" || objTela.Clase.ToString().Trim() != "" || objTela.Coordinado.ToString().Trim() != "" || objTela.NumDibujo.ToString().ToString() != "")
                    {
                        clausulaWhere += "AND ";
                    }
                }

                if (objTela.Muestrario.ToString().Trim() != "")
                {
                    clausulaWhere += "st.muestrario = ? ";
                    con.Parametros.Add(new IfxParameter("@muestrario", objTela.Muestrario.ToString()));

                    if (objTela.OcasionUso.ToString().Trim() != "" || objTela.Tema.ToString().Trim() != ""
                        || objTela.Entrada.ToString().Trim() != "" || objTela.Disenador.ToString().Trim() != "" || objTela.EnsayoRefSimilar.ToString().Trim() != "" || objTela.Estado.ToString().Trim() != ""
                        || objTela.FechaTienda.ToString().Trim() != "" || objTela.RefTela.ToString().Trim() != "" || objTela.NomTela.ToString().Trim() != "" || objTela.Solicitud.ToString().Trim() != ""
                        || objTela.Color.ToString().Trim() != "" || objTela.Clase.ToString().Trim() != "" || objTela.Coordinado.ToString().Trim() != "" || objTela.NumDibujo.ToString().ToString() != "")
                    {
                        clausulaWhere += "AND ";
                    }
                }

                if (objTela.OcasionUso.ToString() != "")
                {
                    clausulaWhere += "mu.desc_mundo = ? ";
                    con.Parametros.Add(new IfxParameter("@ocasion_uso", objTela.OcasionUso.ToString()));
                    if (objTela.Tema.ToString().Trim() != ""
                        || objTela.Entrada.ToString().Trim() != "" || objTela.Disenador.ToString().Trim() != "" || objTela.EnsayoRefSimilar.ToString().Trim() != "" || objTela.Estado.ToString().Trim() != ""
                        || objTela.FechaTienda.ToString().Trim() != "" || objTela.RefTela.ToString().Trim() != "" || objTela.NomTela.ToString().Trim() != "" || objTela.Solicitud.ToString().Trim() != ""
                        || objTela.Color.ToString().Trim() != "" || objTela.Clase.ToString().Trim() != "" || objTela.Coordinado.ToString().Trim() != "" || objTela.NumDibujo.ToString().ToString() != "")
                    {
                        clausulaWhere += "AND ";
                    }
                }

                if (objTela.Tema.ToString() != "")
                {
                    clausulaWhere += "cp.nombre = ? ";
                    con.Parametros.Add(new IfxParameter("@tema", objTela.Tema.ToString()));

                    if (objTela.Entrada.ToString().Trim() != "" || objTela.Disenador.ToString().Trim() != "" || objTela.EnsayoRefSimilar.ToString().Trim() != "" || objTela.Estado.ToString().Trim() != ""
                        || objTela.FechaTienda.ToString().Trim() != "" || objTela.RefTela.ToString().Trim() != "" || objTela.NomTela.ToString().Trim() != "" || objTela.Solicitud.ToString().Trim() != ""
                        || objTela.Color.ToString().Trim() != "" || objTela.Clase.ToString().Trim() != "" || objTela.Coordinado.ToString().Trim() != "" || objTela.NumDibujo.ToString().ToString() != "")
                    {
                        clausulaWhere += "AND ";
                    }
                }

                if (objTela.Entrada.ToString() != "")
                {
                    clausulaWhere += "en.desc_entrada = ? ";
                    con.Parametros.Add(new IfxParameter("@entrada", objTela.Entrada.ToString()));
                    if (objTela.Disenador.ToString().Trim() != "" || objTela.EnsayoRefSimilar.ToString().Trim() != "" || objTela.Estado.ToString().Trim() != ""
                        || objTela.FechaTienda.ToString().Trim() != "" || objTela.RefTela.ToString().Trim() != "" || objTela.NomTela.ToString().Trim() != "" || objTela.Solicitud.ToString().Trim() != ""
                        || objTela.Color.ToString().Trim() != "" || objTela.Clase.ToString().Trim() != "" || objTela.Coordinado.ToString().Trim() != "" || objTela.NumDibujo.ToString().ToString() != "")
                    {
                        clausulaWhere += "AND ";
                    }
                }

                if (objTela.Disenador.ToString() != "")
                {
                    clausulaWhere += "us.nombre = ? ";
                    con.Parametros.Add(new IfxParameter("@disenador", objTela.Disenador.ToString()));
                    if (objTela.EnsayoRefSimilar.ToString().Trim() != "" || objTela.Estado.ToString().Trim() != ""
                        || objTela.FechaTienda.ToString().Trim() != "" || objTela.RefTela.ToString().Trim() != "" || objTela.NomTela.ToString().Trim() != "" || objTela.Solicitud.ToString().Trim() != ""
                        || objTela.Color.ToString().Trim() != "" || objTela.Clase.ToString().Trim() != "" || objTela.Coordinado.ToString().Trim() != "" || objTela.NumDibujo.ToString().ToString() != "")
                    {
                        clausulaWhere += "AND ";
                    }
                }

                if (objTela.EnsayoRefSimilar.ToString() != "")
                {
                    clausulaWhere += "ts.identificador = ? ";
                    con.Parametros.Add(new IfxParameter("@identificador", objTela.EnsayoRefSimilar.ToString()));
                    if (objTela.Estado.ToString().Trim() != ""
                        || objTela.FechaTienda.ToString().Trim() != "" || objTela.RefTela.ToString().Trim() != "" || objTela.NomTela.ToString().Trim() != "" || objTela.Solicitud.ToString().Trim() != ""
                        || objTela.Color.ToString().Trim() != "" || objTela.Clase.ToString().Trim() != "" || objTela.Coordinado.ToString().Trim() != "" || objTela.NumDibujo.ToString().ToString() != "")
                    {
                        clausulaWhere += "AND ";
                    }
                }

                if (objTela.Estado.ToString() != "")
                {
                    clausulaWhere += "ts.estado = ? ";
                    con.Parametros.Add(new IfxParameter("@ts.estado", objTela.Estado.ToString()));

                    if (objTela.FechaTienda.ToString().Trim() != "" || objTela.RefTela.ToString().Trim() != "" || objTela.NomTela.ToString().Trim() != "" || objTela.Solicitud.ToString().Trim() != ""
                    || objTela.Color.ToString().Trim() != "" || objTela.Clase.ToString().Trim() != "" || objTela.Coordinado.ToString().Trim() != "" || objTela.NumDibujo.ToString().ToString() != "")
                    {
                        clausulaWhere += "AND ";
                    }
                }

                if (objTela.FechaTienda.ToString() != "")
                {
                    clausulaWhere += "st.fecha_tienda = ? ";
                    con.Parametros.Add(new IfxParameter("@fecha_tienda", objTela.FechaTienda.ToString()));
                    if (objTela.RefTela.ToString().Trim() != "" || objTela.NomTela.ToString().Trim() != "" || objTela.Solicitud.ToString().Trim() != ""
                    || objTela.Color.ToString().Trim() != "" || objTela.Clase.ToString().Trim() != "" || objTela.Coordinado.ToString().Trim() != "" || objTela.NumDibujo.ToString().ToString() != "")
                    {
                        clausulaWhere += "AND ";
                    }
                }

                if (objTela.RefTela.ToString() != "")
                {
                    clausulaWhere += "upper(st.referencia_tela) = ? ";
                    con.Parametros.Add(new IfxParameter("@referencia_tela", objTela.RefTela.ToString()));
                    if (objTela.NomTela.ToString().Trim() != "" || objTela.Solicitud.ToString().Trim() != ""
                    || objTela.Color.ToString().Trim() != "" || objTela.Clase.ToString().Trim() != "" || objTela.Coordinado.ToString().Trim() != "" || objTela.NumDibujo.ToString().ToString() != "")
                    {
                        clausulaWhere += "AND ";
                    }
                }

                if (objTela.NomTela.ToString() != "")
                {
                    clausulaWhere += "upper(st.desc_tela) = ? ";
                    con.Parametros.Add(new IfxParameter("@desc_tela", objTela.NomTela.ToString()));
                    if (objTela.Solicitud.ToString().Trim() != ""
                    || objTela.Color.ToString().Trim() != "" || objTela.Clase.ToString().Trim() != "" || objTela.Coordinado.ToString().Trim() != "" || objTela.NumDibujo.ToString().ToString() != "")
                    {
                        clausulaWhere += "AND ";
                    }
                }

                if (objTela.Solicitud.ToString() != "")
                {
                    clausulaWhere += "ts.consecutivo = ? ";
                    con.Parametros.Add(new IfxParameter("@solicitud", objTela.Solicitud.ToString()));
                    if (objTela.Color.ToString().Trim() != "" || objTela.Clase.ToString().Trim() != "" || objTela.Coordinado.ToString().Trim() != "" || objTela.NumDibujo.ToString().ToString() != "")
                    {
                        clausulaWhere += "AND ";
                    }
                }

                if (objTela.Color.ToString() != "")
                {
                    clausulaWhere += "pd.descripcion_vte = ? OR cd.descripcion_vte = ? OR de.desc_color = ? OR c.desc_color = ? ";
                    con.Parametros.Add(new IfxParameter("@pd.descripcion_vte", objTela.Color.ToString()));
                    con.Parametros.Add(new IfxParameter("@cd.descripcion_vte", objTela.Color.ToString()));
                    con.Parametros.Add(new IfxParameter("@de.desc_color", objTela.Color.ToString()));
                    con.Parametros.Add(new IfxParameter("@c.desc_color", objTela.Color.ToString()));
                    if (objTela.Clase.ToString().Trim() != "" || objTela.Coordinado.ToString().Trim() != "" || objTela.NumDibujo.ToString().Trim() != "")
                    {
                        clausulaWhere += "AND ";
                    }
                }

                /*if (objTela.Clase.ToString() != "")
                {
                    clausulaWhere += "upper(f.clase) = ? ";
                    con.Parametros.Add(new IfxParameter("@f.clase", objTela.Clase.ToString()));
                    if (objTela.Clase.ToString().Trim() != "" || objTela.Coordinado.ToString().Trim() != "" || objTela.NumDibujo.ToString().ToString() != "")
                    {
                        clausulaWhere += "AND ";
                    }
                }*/
                if (objTela.Coordinado.ToString() != "")
                {
                    clausulaWhere += "pl.coordinado = ? OR es.coordinado = ?  OR un.coordinado = ? OR cu.coordinado = ? ";
                    con.Parametros.Add(new IfxParameter("@pl.coordinado", objTela.Coordinado.ToString()));
                    con.Parametros.Add(new IfxParameter("@es.coordinado", objTela.Coordinado.ToString()));
                    con.Parametros.Add(new IfxParameter("@un.coordinado", objTela.Coordinado.ToString()));
                    con.Parametros.Add(new IfxParameter("@cu.coordinado", objTela.Coordinado.ToString()));

                    if (objTela.NumDibujo.ToString() != "")
                    {
                        clausulaWhere += "AND ";
                    }
                }

                if (objTela.NumDibujo.ToString().Length > 0)
                {
                    clausulaWhere += "es.n_dibujos = ? ";
                    con.Parametros.Add(new IfxParameter("@n_dibujos", objTela.NumDibujo.ToString()));
                }

                #endregion
                clausulaWhere += "ORDER BY solicitud;";
                consultaPedido += clausulaWhere;

                var datosDataReader = con.EjecutarConsulta(consultaPedido);
                while (datosDataReader.Read())
                {
                    MontajeTelaDetalle detalle = new MontajeTelaDetalle();

                    detalle.Consolidado = datosDataReader["consolidado"].ToString().Trim();
                    detalle.Solicitud = datosDataReader["solicitud"].ToString().Trim();
                    detalle.TipoSolicitud = datosDataReader["tipo_solicitud"].ToString().Trim();
                    detalle.Tipo = datosDataReader["ensayo_ref"].ToString().Trim();
                    detalle.RefSimilar = datosDataReader["identificador"].ToString().Trim();
                    detalle.NumDibujos = int.Parse(datosDataReader["n_dibujos"].ToString().Trim());
                    detalle.CodFondo = datosDataReader["cod_fondo"].ToString().Trim();
                    detalle.Fondo = datosDataReader["des_fondo"].ToString().Trim();
                    detalle.TipoTela = datosDataReader["tipo_tela"].ToString().Trim();
                    detalle.Coordinado = datosDataReader["coordinado"].ToString().Trim();
                    detalle.CoordinadoCon = datosDataReader["coordinado_con"].ToString().Trim();
                    detalle.RefTela = datosDataReader["referencia_tela"].ToString().Trim();
                    detalle.DesTela = datosDataReader["desc_tela"].ToString().Trim();
                    detalle.Vte = datosDataReader["codigo_vte"].ToString().Trim();
                    detalle.DesColor = datosDataReader["descripcion_vte"].ToString().Trim();
                    detalle.TotaUnidades = datosDataReader["total_unidades"].ToString().Trim();
                    detalle.Consumo = datosDataReader["consumo"].ToString().Trim();
                    detalle.Marca = datosDataReader["desc_linea"].ToString().Trim();
                    detalle.Muestrario = datosDataReader["muestrario"].ToString().Trim();
                    detalle.OcasionUso = datosDataReader["ocasion_uso"].ToString().Trim();
                    detalle.Tema = datosDataReader["tema"].ToString().Trim();
                    detalle.Entrada = datosDataReader["entrada"].ToString().Trim();
                    detalle.FechaTienda = datosDataReader["fecha_tienda"].ToString().Trim();
                    detalle.Disenador = datosDataReader["disenador"].ToString().Trim();
                    detalle.ObsDiseno = datosDataReader["observaciones"].ToString().Trim();
                    detalle.FechaSolTelas = datosDataReader["fecha_solicitud"].ToString().Trim();
                    detalle.Estado = datosDataReader["estado"].ToString().Trim();
                    detalle.FechaEstado = datosDataReader["fecha_estado"].ToString().Trim();
                    detalle.Tiendas = datosDataReader["tiendas"].ToString().Trim();
                    detalle.Exito = datosDataReader["exito"].ToString().Trim();
                    detalle.Cencosud = datosDataReader["cencosud"].ToString().Trim();
                    detalle.Sao = datosDataReader["sao"].ToString().Trim();
                    detalle.Comercio = datosDataReader["comercio"].ToString().Trim();
                    detalle.Rosado = datosDataReader["rosado"].ToString().Trim();
                    detalle.Otros = datosDataReader["otros"].ToString().Trim();
                    detalle.MCalculados = datosDataReader["m_calculados"].ToString().Trim();
                    detalle.MReservados = datosDataReader["m_reservar"].ToString().Trim();
                    detalle.Masolicitar = datosDataReader["m_solicitar"].ToString().Trim();
                    detalle.IdSolTela = int.Parse(datosDataReader["idsolicitud"].ToString().Trim());
                    detalle.CantidadReservado = datosDataReader["cantidad_reservado"].ToString().Trim();
                    detalle.IdDetalleSolicitud = datosDataReader["idDetalleSol"].ToString().Trim();
                    detalle.IdProgramador = int.Parse(datosDataReader["id_programador"].ToString().Trim());
                    detalle.DescPrenda = datosDataReader["desc_prenda"].ToString().Trim();
                    detalle.CodigoH1 = int.Parse(datosDataReader["codigo_h1"].ToString());
                    detalle.DescripcionH1 = datosDataReader["descripcion_h1"].ToString().Trim();
                    detalle.CodigoH2 = int.Parse(datosDataReader["codigo_h2"].ToString());
                    detalle.DescripcionH2 = datosDataReader["descripcion_h2"].ToString().Trim();
                    detalle.CodigoH3 = int.Parse(datosDataReader["codigo_h3"].ToString());
                    detalle.DescripcionH3 = datosDataReader["descripcion_h3"].ToString().Trim();
                    detalle.CodigoH4 = int.Parse(datosDataReader["codigo_h4"].ToString());
                    detalle.DescripcionH4 = datosDataReader["descripcion_h4"].ToString().Trim();
                    detalle.CodigoH5 = int.Parse(datosDataReader["codigo_h5"].ToString());
                    detalle.DescripcionH5 = datosDataReader["descripcion_h5"].ToString().Trim();


                    listaTelas.Add(detalle);
                };
                con.cerrarConexion();
            }
            return listaTelas;
        }

        public List<Objeto> consultarNomTela()
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var administracionConexion = new clsConexion())
            {
                var datosDataReader = administracionConexion.EjecutarConsulta(consultaNombreTela);
                while (datosDataReader.Read())
                {
                    Objeto ocasionUso = new Objeto();
                    ocasionUso.Id = datosDataReader["referencia_tela"].ToString().Trim();
                    ocasionUso.Nombre = datosDataReader["desc_tela"].ToString().Trim();
                    respuesta.Add(ocasionUso);
                };
                administracionConexion.cerrarConexion();
            }
            return respuesta;
        }

        public List<Objeto> consultarRefTela()
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var administracionConexion = new clsConexion())
            {
                var datosDataReader = administracionConexion.EjecutarConsulta(consultaNombreTela);
                while (datosDataReader.Read())
                {
                    Objeto ocasionUso = new Objeto();
                    ocasionUso.Id = datosDataReader["desc_tela"].ToString().Trim();
                    ocasionUso.Nombre = datosDataReader["referencia_tela"].ToString().Trim();
                    respuesta.Add(ocasionUso);
                };
                administracionConexion.cerrarConexion();
            }
            return respuesta;
        }

        public List<Objeto> consultarColoresT()
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var administracionConexion = new clsConexion())
            {
                var datosDataReader = administracionConexion.EjecutarConsulta(consultaColores);
                while (datosDataReader.Read())
                {
                    Objeto ocasionUso = new Objeto();
                    ocasionUso.Id = datosDataReader["codigo_vte"].ToString().Trim();
                    ocasionUso.Nombre = datosDataReader["descripcion_vte"].ToString().Trim();
                    respuesta.Add(ocasionUso);
                };
                administracionConexion.cerrarConexion();
            }
            return respuesta;
        }

        public List<Objeto> ConsultarTipoSolocitud()
        {
            List<Objeto> respuesta = new List<Objeto>();
            using (var administracionConexion = new clsConexion())
            {
                var datosDataReader = administracionConexion.EjecutarConsulta(consultaTipoSol);
                while (datosDataReader.Read())
                {
                    Objeto ocasionUso = new Objeto();
                    ocasionUso.Nombre = datosDataReader["tipo"].ToString().Trim();
                    respuesta.Add(ocasionUso);
                };
                administracionConexion.cerrarConexion();
            }
            return respuesta;
        }

        #endregion

        #region Métodos de Actualización 

        public string ActualizarMCalculados(int prmIdSolTela, string prmMCalculados)
        {
            string respuesta = "";
            try
            {
                using (var con = new clsConexion())
                {

                    con.Parametros.Add(new IfxParameter("@m_calculados", prmMCalculados));
                    con.Parametros.Add(new IfxParameter("@idsolicitud", prmIdSolTela));
                    var datos = con.EjecutarConsulta(actualizarMCalculados);
                    con.cerrarConexion();
                }
                respuesta = "ok";
            }
            catch (Exception ex)
            {
                respuesta = "Error: " + ex.Message;
            }
            return respuesta;
        }
        #endregion
    }

}
    

