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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidoTela.Formularios
{
    public partial class frmDetalleReserva : MaterialSkin.Controls.MaterialForm
    {
        Controlador controlador = new Controlador();
        List<DisponibleParaReserva> listDetalle = new List<DisponibleParaReserva>();
        public List<DisponibleParaReserva> ListDetalle { get => listDetalle; set => listDetalle = value; }

        public frmDetalleReserva(Controlador control, List<DisponibleParaReserva> listaSeleccionada)
        {
            InitializeComponent();
            controlador = control;
            listDetalle = listaSeleccionada;
        }

        private void frmDetalleReserva_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
            cargarDataGridView(ListDetalle);

        }
        private void cargarDataGridView(List<DisponibleParaReserva> prmLista)
        {
            if (prmLista.Count != 0)
            {
                for (int i = 0; i < prmLista.Count; i++)
                {
                   // if(prmLista[i])

                    dgvDetalle.Rows.Add(
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
                }
            }
            else
            {
                MessageBox.Show("No existe información sobre su consulta", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDetalle_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvDetalle.CurrentRow != null && dgvDetalle.CurrentRow.Index > -1)
            {
                string value1 = dgvDetalle.CurrentRow.Cells[7].Value != null ? dgvDetalle.CurrentRow.Cells[7].Value.ToString() : "";
                txbTotal.Text = value1;

                //string value2 = dgvDetalle.CurrentRow.Cells[1].Value != null ? dataGridView1.CurrentRow.Cells[1].Value.ToString() : "";
                //textBox2.Text = value2;
       
            }
        }
    }
}
