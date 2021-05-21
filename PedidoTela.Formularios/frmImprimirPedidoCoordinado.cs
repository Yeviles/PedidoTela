using PedidoTela.Controlodores;
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
    public partial class frmImprimirPedidoCoordinado : Form
    {
        public frmImprimirPedidoCoordinado(Controlador control, int idSolicitud)
        {
            InitializeComponent();
        }
    }
}
