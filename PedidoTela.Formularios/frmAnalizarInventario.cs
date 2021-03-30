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
        Controlador control = new Controlador();
        List<DetalleListaTela> detalleSeleccionado = new List<DetalleListaTela>();
        Utilidades utilidades = new Utilidades();
        private int mReservar;

        public List<DetalleListaTela> DetalleSeleccionado { get => detalleSeleccionado; set => detalleSeleccionado = value; }

        public int MReservar { get => mReservar; set => mReservar = value; }
        public frmAnalizarInventario(Controlador controlador, List<DetalleListaTela> listaSeleccionada)
        {
            InitializeComponent();
            DetalleSeleccionado = listaSeleccionada;
            control = controlador;
            cargarDataGridView(DetalleSeleccionado);

            dgvAnalizarInventario.Columns["mCalculados"].HeaderCell.ToolTipText = "(Total Unidades * Consumo)*1.10";
            dgvAnalizarInventario.Columns["mReservados"].HeaderCell.ToolTipText = "Metros reservados para cada item.";
            dgvAnalizarInventario.Columns["maSolicitar"].HeaderCell.ToolTipText = "(mCalculados - mReservados)";

        }

        public frmAnalizarInventario(){}

        private void frmReservaTela_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
         
            dgvAnalizarInventario.CellContentClick += new DataGridViewCellEventHandler(dgvAnalizarInventario_CellClick);

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
                prmLista[i].Masolicitar.ToString()
                ); 
                }
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            int conChecked = utilidades.ContarChecked(dgvAnalizarInventario);
            if (conChecked == 1)
            {
                foreach (DataGridViewRow row in dgvAnalizarInventario.Rows)
                {
                    if (row.Cells[0].Value.Equals(true))//Columna de checks
                    {
                        if (control.AtualizarCalculados(row.Cells[2].Value.ToString(), row.Cells[14].Value.ToString(), row.Cells[15].Value.ToString(), row.Cells[16].Value.ToString()))
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
                        //for (int i = row.Index; i <= dgvAnalizarInventario.RowCount - 1; i++)
                        // {
                        if (dgvAnalizarInventario.Rows[row.Index].Cells[16].Value.ToString() != "0")
                        {
                            if (control.setEstado(DetalleSeleccionado[row.Index].RefSimilar.ToString(), estado1, fechaAtualizada))
                            {
                                MessageBox.Show("Estado actualizado a Reserva Parcial.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else if (dgvAnalizarInventario.Rows[row.Index].Cells[16].Value.ToString() == "0")
                        {
                            if (control.setEstado(DetalleSeleccionado[row.Index].RefSimilar.ToString(), estado2, fechaAtualizada))
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
            bool b = false;
            if (contador >= 1 && contador <= 1)
            {
                for (int i = 0; i <= dgvAnalizarInventario.RowCount - 1; i++)
                {
                    DisponibleParaReserva objInfo = new DisponibleParaReserva();

                    if (Convert.ToBoolean(dgvAnalizarInventario.Rows[i].Cells["sel"].Value) == true)
                    {
                        if (dgvAnalizarInventario.Rows[i].Cells["mReservados"].Value.ToString() == "" || dgvAnalizarInventario.Rows[i].Cells["mReservados"].Value == null)
                        {
                            objInfo.Disenadora = DetalleSeleccionado[i].Disenador.ToString();
                            objInfo.Pedido = "";
                            //objInfo.Ensayo = dgvAnalizarInventario.Rows[i].Cells[1].Value.ToString();
                            objInfo.Referencia = dgvAnalizarInventario.Rows[i].Cells[2].Value.ToString();
                            objInfo.NomTela = DetalleSeleccionado[i].DesTela.ToString();
                            objInfo.Color = dgvAnalizarInventario.Rows[i].Cells[3].Value.ToString();
                            objInfo.Estado = DetalleSeleccionado[i].Estado.ToString();
                            objInfo.Disponible = "";
                            objInfo.CantidadReservado = DetalleSeleccionado[i].Masolicitar.ToString();
                            objInfo.DiponibleTeorico = "";
                            
                            // objInfo.MetrosaReservar = "";

                            b = true;
                            listaSeleccionadas.Add(objInfo);
                        }
                        else
                        {
                            MessageBox.Show("Gracias, ya se ha guardado una Reserva.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            b = false;
                        }
                    }

                }
                if (b)
                {
                   frmDisponibleParaReserva frmDisponible = new frmDisponibleParaReserva(control, listaSeleccionadas);
                    if (frmDisponible.ShowDialog() == DialogResult.OK)
                    {
                        
                            
                    for (int i = 0; i <= dgvAnalizarInventario.RowCount - 1; i++)
                    {
                        if (dgvAnalizarInventario.Rows[i].Cells[0].Value.Equals(true))//Columna de checks
                        {

                            Actualizar(control.consultarInvertario(DetalleSeleccionado[i].RefSimilar.ToString()));
                        }
                    }
                        
                       
                    }
                }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar una única fila para realizar la reserva.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
