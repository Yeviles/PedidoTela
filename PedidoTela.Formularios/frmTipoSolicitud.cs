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
    public partial class frmTipoSolicitud : Form
    {
        private String  seleccion;

        public string Seleccion { get => seleccion; set => seleccion = value; }

        public frmTipoSolicitud()
        {
            InitializeComponent();
        }

        #region Region Eventos CheckedChanged para Seleccion del tipo de solicitud
        /*
         * Nota Comprensiva: Prefijo utilizado para los CheckBox cbxNombre.
         * Eventos CheckedChanged para los checkBox (cbxCuePunTiras, cbxUnicolor,cbxestampado y cbxPlanoPretenido) verifican el evento de marcado para
         * seleccion del tipo de solicitud.
         */

        private void cbxUnicolor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxUnicolor.Checked)
            {
 
                cbxestampado.Checked = false;
                cbxPlanoPretenido.Checked = false;
                cbxCuePunTiras.Checked = false;
                Seleccion = "unicolor";
            }
        }

        private void cbxestampado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxestampado.Checked)
            {
                cbxUnicolor.Checked = false;
                cbxPlanoPretenido.Checked = false;
                cbxCuePunTiras.Checked = false;
                Seleccion = "estampado";
            }

        }

        private void cbxPlanoPretenido_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPlanoPretenido.Checked)
            {
                cbxUnicolor.Checked = false;
                cbxestampado.Checked = false;
                cbxCuePunTiras.Checked = false;
                Seleccion = "planoPre";
            }

        }
        
        private void cbxCuePunTiras_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCuePunTiras.Checked)
            {
                cbxUnicolor.Checked = false;
                cbxestampado.Checked = false;
                cbxPlanoPretenido.Checked = false;
                Seleccion = "cuelloPun";
            }

        }
        #endregion
        #region Botones Aceptar-Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Cancel;
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if ( cbxUnicolor.Checked || cbxestampado.Checked || cbxCuePunTiras.Checked||cbxPlanoPretenido.Checked) {
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor seleccione un tipo de solicitud","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }
        #endregion
    }
}
