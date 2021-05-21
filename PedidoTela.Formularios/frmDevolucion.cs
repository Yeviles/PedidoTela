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
    public partial class frmDevolucion : MaterialSkin.Controls.MaterialForm
    {
        Controlador control = new Controlador();
        Validar validacion = new Validar();

        public frmDevolucion(Controlador control, string consecutivo)
        {
            InitializeComponent();
            this.control = control;
            txbConsecutivo.Text = consecutivo;
        }

        private void frmDevolucion_Load(object sender, EventArgs e)
        {
        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            if (txbConsecutivo.Text != "")
            {
                if (txtMotivo.Text != "")
                {
                    string motivoDevolucion = control.existeDevolucion(int.Parse(txbConsecutivo.Text));
                    if (motivoDevolucion == "")
                    {
                        if (control.existeConsecutivoPedido(int.Parse(txbConsecutivo.Text)))
                        {
                            string fecha = DateTime.Now.ToString("dd/MM/yyyy");
                            control.actualizarConsecutivo(int.Parse(txbConsecutivo.Text), fecha, "Devolucion",txtMotivo.Text);
                            MessageBox.Show("La Devolución se ha realizado con exito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("El consecutivo ingresado no existe.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        txtMotivo.Text = motivoDevolucion;
                        lbInformacion.Visible = true;
                        btnDevolucion.Enabled = false;
                        lbInformacion.Text = "Información \n El consecutivo ya cuenta con Devolucion.";
                    }

                }
                else
                {
                    MessageBox.Show("Por favor ingrese el Motivo de la devolución.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un valor para Consecutivo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txbConsecutivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(txbConsecutivo.Text != "")
            {
                validacion.SoloNumeros(e);
                lbInformacion.Visible = false;
                btnDevolucion.Enabled = true;
            }
        }
    }
}
