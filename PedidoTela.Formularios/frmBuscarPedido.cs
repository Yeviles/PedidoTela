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
    public partial class frmBuscarPedido : MaterialSkin.Controls.MaterialForm
    {
        Controlador control;
        private TomarDelPedido elemento;

        public TomarDelPedido Elemento { get => elemento; set => elemento = value; }

        public frmBuscarPedido(Controlador control)
        {
            this.control = control;
            Elemento = new TomarDelPedido();
            InitializeComponent();
        }

        private void frmBuscarPedido_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<TomarDelPedido> lista = new List<TomarDelPedido>();
            if (txbPedido.Text.Trim().Length > 0)
            {
                lista = control.consultarPorNumeroPedido(txbPedido.Text.Trim());
            }
            else if (txbColor.Text.Trim().Length > 0)
            {
                lista = control.consultarPorCodigoColor(txbColor.Text.Trim());
            }

            listar(lista);
        }

        private void listar(List<TomarDelPedido> lista)
        {
            dgvPedidos.Rows.Clear();
            dgvPedidos.Columns.Clear();
            dgvPedidos.DataSource = null;
            dgvPedidos.Columns.Add("Column0", "Número Pedido");
            dgvPedidos.Columns.Add("Column1", "Codigo Color");
            dgvPedidos.Columns.Add("Column2", "Estado");
            dgvPedidos.Columns.Add("Column3", "Disponible");

            foreach (TomarDelPedido elemento in lista)
            {
                dgvPedidos.Rows.Add(elemento.NumeroPedido, elemento.CodigoColor,elemento.Estado,elemento.Disponible);
            }
            dgvPedidos.Columns[0].ReadOnly = true;
            dgvPedidos.Columns[1].ReadOnly = true;
            dgvPedidos.Columns[2].ReadOnly = true;
            dgvPedidos.Columns[3].ReadOnly = true;

            dgvPedidos.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPedidos.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPedidos.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPedidos.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void dgvPedidos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Elemento.NumeroPedido = dgvPedidos.CurrentRow.Cells[0].Value.ToString();
            Elemento.CodigoColor = int.Parse(dgvPedidos.CurrentRow.Cells[1].Value.ToString());
            Elemento.Estado = dgvPedidos.CurrentRow.Cells[2].Value.ToString();
            Elemento.Disponible = decimal.Parse(dgvPedidos.CurrentRow.Cells[3].Value.ToString());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txbPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                string codigo = txbPedido.Text.Trim().ToUpper();
                if (codigo.Length > 0)
                {
                    listar(control.consultarPorNumeroPedido(codigo));
                }
            }
        }
    }
}
