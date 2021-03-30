using MaterialSkin;
using PedidoTela.Controlodores;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidoTela.Formularios
{
  
    public partial class frmDisponibleParaReserva : MaterialSkin.Controls.MaterialForm
    {
        Controlador controlador = new Controlador();
        List<DisponibleParaReserva> listDetalle = new List<DisponibleParaReserva>();
        private int metrosReservar;

        public List<DisponibleParaReserva> ListDetalle { get => listDetalle; set => listDetalle = value; }
        public int MetrosReservar { get => metrosReservar; set => metrosReservar = value; }

        public frmDisponibleParaReserva(Controlador control, List<DisponibleParaReserva> listaSeleccionada)
        { 
            
            InitializeComponent();
            controlador = control;
            ListDetalle = listaSeleccionada;
            
        }
       
        private void frmDisponibleParaReserva_Load(object sender, EventArgs e)
        {
            cargarDataGridView(ListDetalle);
        }

        private void cargarDataGridView(List<DisponibleParaReserva> prmLista)
        {
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {

                    dgvDisponibleReservar.Rows.Add(
                        prmLista[i].Disenadora.ToString(),
                        prmLista[i].Pedido.ToString(),
                        prmLista[i].Referencia.ToString(),
                        prmLista[i].NomTela.ToString(),
                        prmLista[i].Color.ToString(),
                        prmLista[i].Estado.ToString(),
                        prmLista[i].Disponible.ToString(),
                        prmLista[i].CantidadReservado.ToString());
                    //prmLista[i].DiponibleTeorico.ToString();
                    // prmLista[i].MetrosaReservar.ToString());
                    btnDetalleReserva.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvDisponibleReservar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ///dgvDisponibleReservar.ReadOnly = true;
            if (e.ColumnIndex >= 0 && e.ColumnIndex <= 8)
            {
                dgvDisponibleReservar.CurrentRow.Cells[0].ReadOnly = true;
                dgvDisponibleReservar.CurrentRow.Cells[1].ReadOnly = true;
                dgvDisponibleReservar.CurrentRow.Cells[2].ReadOnly = true;
                dgvDisponibleReservar.CurrentRow.Cells[3].ReadOnly = true;
                dgvDisponibleReservar.CurrentRow.Cells[4].ReadOnly = true;
                dgvDisponibleReservar.CurrentRow.Cells[5].ReadOnly = true;
                dgvDisponibleReservar.CurrentRow.Cells[6].ReadOnly = true;
                dgvDisponibleReservar.CurrentRow.Cells[7].ReadOnly = true;
                dgvDisponibleReservar.CurrentRow.Cells[8].ReadOnly = true;
            }
            else
            {
                if (e.ColumnIndex == 9)
                {
                    if (dgvDisponibleReservar.CurrentCell.Value != null && dgvDisponibleReservar.CurrentCell.Value.ToString().Trim() != "")
                    {
                        dgvDisponibleReservar.CurrentCell.Value = dgvDisponibleReservar.CurrentCell.Value.ToString().Trim().Replace(".", ",");
                        dgvDisponibleReservar.CurrentCell.Value = Regex.Replace(dgvDisponibleReservar.CurrentCell.Value.ToString().Trim(), @"[^0-9,]", "");
                        if (dgvDisponibleReservar.CurrentCell.Value != null && dgvDisponibleReservar.CurrentCell.Value.ToString().Trim() != "")
                        {
                            int valor = int.Parse(dgvDisponibleReservar.CurrentCell.Value.ToString());
                            dgvDisponibleReservar.CurrentCell.Value = valor;
                            MetrosReservar = valor;
                        }
                    }
                }

            }
            }
    
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDisponibleReservar.Rows)
            {
               if( controlador.setMaReservar(row.Cells[2].Value.ToString(), row.Cells[9].Value.ToString()))
                {
                    MessageBox.Show("Información Actualizada con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }

              } 
        }

        private void btnDetalleReserva_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= dgvDisponibleReservar.RowCount - 1; i++)
            {
                if (dgvDisponibleReservar.Rows[i].Cells[9].Value == null)
                    {

                    MessageBox.Show("Por favor, ingrese un valor para Metros a Reservar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    {
                    frmDetalleReserva frmDetalle = new frmDetalleReserva(controlador, ListDetalle);
                    frmDetalle.Show();
            }

                
            }
        }
    }
}
