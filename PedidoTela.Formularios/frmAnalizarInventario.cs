using MaterialSkin;
using PedidoTela.Controlodores;
using PedidoTela.Entidades;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidoTela.Formularios
{
    public partial class frmAnalizarInventario : MaterialSkin.Controls.MaterialForm
    {
        #region variables
        Controlador control = new Controlador();
        List<DetalleListaTela> detalleSeleccionado = new List<DetalleListaTela>();
        Utilidades utilidades = new Utilidades();
        private int mReservar;
        #endregion
        #region Getter && Setter
        public List<DetalleListaTela> DetalleSeleccionado { get => detalleSeleccionado; set => detalleSeleccionado = value; }

        public int MReservar { get => mReservar; set => mReservar = value; }
        #endregion

        #region Constructor
        public frmAnalizarInventario(Controlador controlador, List<DetalleListaTela> listaSeleccionada, int contador)
        {
            InitializeComponent();
            DetalleSeleccionado = listaSeleccionada;
            control = controlador;
            //Validación de las condiciones para mostrar las filas seleccionadas en esta vista.
            validacionesDatosIguales(DetalleSeleccionado, contador);
        }
        
        public frmAnalizarInventario() { }
        #endregion
        private void frmReservaTela_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);

            dgvAnalizarInventario.CellContentClick += new DataGridViewCellEventHandler(dgvAnalizarInventario_CellClick);

            dgvAnalizarInventario.Columns["mCalculados"].HeaderCell.ToolTipText = "(Total Unidades * Consumo)*1.10";
            dgvAnalizarInventario.Columns["mReservados"].HeaderCell.ToolTipText = "Metros reservados para cada item.";
            dgvAnalizarInventario.Columns["maSolicitar"].HeaderCell.ToolTipText = "(mCalculados - mReservados)";

        }

        #region Eventos
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int conChecked = utilidades.ContarChecked(dgvAnalizarInventario);
            if (conChecked == 1)
            {
                foreach (DataGridViewRow row in dgvAnalizarInventario.Rows)
                {
                    if (row.Cells[0].Value.Equals(true))//Columna de checks
                    {
                        //Actualiza segun el idsolicutud almacenado en la tabla cfc_spt_sol_tela, el método recibe idSolTela, mCalculados, mReservados, maSolicitar
                        if (control.AtualizarCalculados(int.Parse(row.Cells[17].Value.ToString()), row.Cells[14].Value.ToString(), row.Cells[15].Value.ToString(), row.Cells[16].Value.ToString()))
                        {
                            MessageBox.Show("Información Actualizada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                        }
                    }

                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string estado1 = "Reserva parcial";
            string estado2 = "Reserva Total";
        
            string fechaAtualizada = DateTime.Now.ToString("dd/MM/yyyy");
            int contador= utilidades.ContarChecked(dgvAnalizarInventario);

            if (contador ==1)
            {
                foreach (DataGridViewRow row in dgvAnalizarInventario.Rows)
                {
                    if (row.Cells[0].Value.Equals(true))//Columna de checks
                    {
                        /// Si es diferente de 0, entonces debe actualizar el estado a Reserva Parcial, y la fecha de estado 
                        if (dgvAnalizarInventario.Rows[row.Index].Cells[16].Value.ToString() != "0")
                        {
                            if (control.setEstado(int.Parse(DetalleSeleccionado[row.Index].IdSolTela.ToString()), estado1, fechaAtualizada))
                            {
                                MessageBox.Show("Estado actualizado a Reserva Parcial.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        // Si es igual a 0, entonces debe actualizar el estado a Reserva Total, y la fecha de estado 
                        else if (dgvAnalizarInventario.Rows[row.Index].Cells[16].Value.ToString() == "0")
                        {
                            if (control.setEstado(int.Parse(DetalleSeleccionado[row.Index].IdSolTela.ToString()), estado2, fechaAtualizada))
                            {
                                MessageBox.Show("Estado actualizado a Reserva Total.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        
                    }
                }

            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
      
        private void btnReservar_Click(object sender, EventArgs e)
        {
            List<DisponibleParaReserva> listaSeleccionadas = new List<DisponibleParaReserva>();
            int contador = utilidades.ContarChecked(dgvAnalizarInventario);
            DisponibleParaReserva pedido = new DisponibleParaReserva();
            bool b = false, p = false;
            if (contador >= 1 && contador <= 1)
            {
                for (int i = 0; i <= dgvAnalizarInventario.RowCount - 1; i++)
                {
                    DisponibleParaReserva objInfo = new DisponibleParaReserva();

                    if (Convert.ToBoolean(dgvAnalizarInventario.Rows[i].Cells["sel"].Value) == true)
                    {
                    // método para consultar pedido
                        pedido = control.consultarPedido(DetalleSeleccionado[i].IdProgramador, DetalleSeleccionado[i].RefTela, DetalleSeleccionado[i].Vte);
                        
                        if (dgvAnalizarInventario.Rows[i].Cells["mReservados"].Value.ToString() == "" || dgvAnalizarInventario.Rows[i].Cells["mReservados"].Value == null)
                        {
                            objInfo.Disenadora = DetalleSeleccionado[i].Disenador.ToString();
                            if(pedido.Pedido == null)
                            {
                                objInfo.Pedido = "0";
                                p = true;
                            }
                            else
                            {
                                objInfo.Pedido = pedido.Pedido.ToString();
                            }

                            //objInfo.Pedido = "";
                            //objInfo.Ensayo = dgvAnalizarInventario.Rows[i].Cells[1].Value.ToString();
                            objInfo.Referencia = dgvAnalizarInventario.Rows[i].Cells[2].Value.ToString();
                            objInfo.NomTela = DetalleSeleccionado[i].DesTela.ToString();
                            objInfo.CodiTela = DetalleSeleccionado[i].RefTela.ToString();
                            objInfo.Color = dgvAnalizarInventario.Rows[i].Cells[3].Value.ToString();
                            objInfo.Estado = DetalleSeleccionado[i].Estado.ToString();
                            objInfo.Disponible = pedido.Disponible;                    
                            objInfo.CantidadReservado = DetalleSeleccionado[i].CantidadReservado.ToString();
                            objInfo.DiponibleTeorico = utilidades.DisponibleTeorico(pedido.Disponible.ToString(), DetalleSeleccionado[i].CantidadReservado.ToString());
                            objInfo.IdsolTela = int.Parse(DetalleSeleccionado[i].IdSolTela.ToString());
                            objInfo.IdDetalleSolicitud = DetalleSeleccionado[i].IdDetalleSolicitud;
                            b = true;
                            listaSeleccionadas.Add(objInfo);
                        }
                        else
                        {
                            MessageBox.Show("Ya se ha guardado una Reserva.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            b = false;
                        }
                    }
                }
                if (b)
                {
                    if (!p)
                    {
                        frmDisponibleParaReserva frmDisponible = new frmDisponibleParaReserva(control, listaSeleccionadas);

                        if (frmDisponible.ShowDialog() == DialogResult.OK)
                        {
                            for (int i = 0; i <= dgvAnalizarInventario.RowCount - 1; i++)
                            {
                                if (dgvAnalizarInventario.Rows[i].Cells[0].Value.Equals(true))//Columna de checks
                                {

                                    Actualizar(control.consultarInvertario(int.Parse(DetalleSeleccionado[i].IdSolTela.ToString())));
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede realizar la reserva. \nEl item seleccionado no tiene disponible de pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una única fila para realizar la reserva.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmImprimirReserva imprimir = new frmImprimirReserva(control);
            imprimir.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvAnalizarInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvAnalizarInventario.EndEdit();
            //Comprobar que se ha hecho clic en el CheckBox de la fila.
            if (e.RowIndex >= 0 && e.ColumnIndex == 0)
            {
                // Bucle para verificar si todas las casillas de verificación de las filas están marcadas o no.
                foreach (DataGridViewRow row in dgvAnalizarInventario.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["sel"].EditedFormattedValue) == false)
                    {
                        dgvAnalizarInventario.Rows[e.RowIndex].Cells["sel"].Value = true;

                        //break;
                    }
                    dgvAnalizarInventario.RefreshEdit();

                }
            }

        }
        #endregion

        #region métodos

        /// <summary>
        /// Válida que La  referencia   y /o  descripción de  la   tela  debe  ser  igual, además realiza un llamado al método validarDatosDiferentes
        /// cuando dicha condición no se cumple.
        /// </summary>
        /// <param name="prmLista">Lista de la todas filas seleccionadas en el frmSolicitudListas.</param>
        /// <param name="cont">Número de filas seleccionadas.</param>
        public void validacionesDatosIguales(List<DetalleListaTela> prmLista, int cont)
        {
            int b = 0;
            string desTela = prmLista[0].DesTela;
            if (cont >= 2)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {
                    if (prmLista[i].DesTela.ToString() == desTela && prmLista[i].Estado == "Por Analizar" || prmLista[i].Estado == "Reserva parcial")
                    {
                        b += 1;
                    }
                }
                if (b == prmLista.Count)
                {
                    this.Show();
                    cargarDataGridView(prmLista);
                    // DialogResult = DialogResult.OK;
                }
                else
                {
                    //MessageBox.Show("La  referencia   y /o  descripción de  la   tela  debe  ser  igual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    validarDatosDiferentes(prmLista, cont);
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar mínimo dos filas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        /// <summary>
        /// Válida que  Descripción de tela diferentes solo en el caso que el campo cordinado este marcado como Si.
        /// Imprime un solo mensaje indicando que la condición del método validacionesDatosIguales no se cumplio tanto como la condición propia.
        /// </summary>
        /// <param name="prmLista">Lista de la todas filas seleccionadas en el frmSolicitudListas.</param>
        /// <param name="cont">Número de filas seleccionadas.</param>
        public void validarDatosDiferentes(List<DetalleListaTela> prmLista, int cont)
        {
            string desTela = prmLista[0].DesTela;
            int b = 0;
            if (cont >= 2 && cont <= 3)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {
                    if (prmLista[i].Estado == "Por Analizar" || prmLista[i].Estado == "Reserva parcial" && prmLista[i].Coordinado == "SI")
                    {
                        b += 1;
                    }
                }
                if (b == prmLista.Count)
                {
                    this.Show();
                    cargarDataGridView(prmLista);
                }
                else
                {
                    MessageBox.Show("No se cumple alguna de estas dos condiciones: \n 1. Descripción de tela diferentes solo en el caso que el campo cordinado este marcado como Si. \n 2. La  referencia   y /o  descripción de  la   tela  debe  ser  igual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //MessageBox.Show("La  referencia   y /o  descripción de  la   tela  debe  ser  igual", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Descripción de tela Diferentes, solo se permite seleccionar máximo 3 filas mínimo 2 filas. ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void cargarDataGridView(List<DetalleListaTela> prmLista)
        {

            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {

                    dgvAnalizarInventario.Rows.Add(prmLista[i].Sel.ToString(),
                    prmLista[i].Ensayo.ToString(),
                    prmLista[i].RefSimilar.ToString(),
                    prmLista[i].Vte.ToString(),
                    prmLista[i].DesColor.ToString(),
                    prmLista[i].Tiendas.ToString(),
                    prmLista[i].Exito.ToString(),
                    prmLista[i].Cencosud.ToString(),
                    prmLista[i].Sao.ToString(),
                    prmLista[i].Comercio.ToString(),
                    prmLista[i].Rosado.ToString(),
                    prmLista[i].Otros.ToString(),
                    prmLista[i].TotaUnidades.ToString(),
                    prmLista[i].Consumo.ToString(),
                    prmLista[i].MCalculados.ToString(),
                    prmLista[i].MReservados.ToString(),
                    prmLista[i].Masolicitar.ToString(),
                    prmLista[i].IdSolTela.ToString(),
                    prmLista[i].IdDetalleSolicitud.ToString()
                    );
                }
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Actualizar(List<AnalizarInventario> objAtualizar)
        {
            foreach (DataGridViewRow row in dgvAnalizarInventario.Rows)
            {
                if (row.Cells[0].Value.Equals(true))//Columna de checks
                {
                    for (int i = 0; i <= objAtualizar.Count -1; i++)
                    {
                        //dgvAnalizarInventario.Rows[row.Index].Cells[14].Value = utilidades.mCalculados2(objAtualizar[0].MCalculados.ToString().Trim(), objAtualizar[0].Consumo.ToString().Trim());
                        dgvAnalizarInventario.Rows[row.Index].Cells[15].Value = objAtualizar[0].MReservados.ToString().Trim();
                        dgvAnalizarInventario.Rows[row.Index].Cells[16].Value = utilidades.mSolicitar(objAtualizar[0].MCalculados.ToString().Trim(), objAtualizar[0].MReservados.ToString().Trim());
                    }
                }
            }
           
        }
        #endregion
    }
}
