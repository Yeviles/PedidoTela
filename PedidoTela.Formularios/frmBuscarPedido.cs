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
        private Pedido elemento;

        public frmBuscarPedido()
        {
            this.control = control;
            elemento = new Pedido();
            InitializeComponent();
        }

        private void frmBuscarPedido_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            /*List<Pedido> lista = new List<Pedido>();
            if (txbPedido.Text.Trim().Length > 0)
            {
                lista = control.buscarColorPorCodigo(txbPedido.Text.Trim());
            }
            else if (txbDescripcion.Text.Trim().Length > 0)
            {
                lista = control.buscarColorPorDescripcion(txbColor.Text.Trim().ToUpper());
            }
            else
            {
                lista = control.getColores();
            }
            listar(lista);*/
        }
    }
}
