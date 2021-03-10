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
    public partial class frmEditarDsolicitudTela : MaterialSkin.Controls.MaterialForm
    {
        Controlador control;
        private Objeto elemento;
        public Objeto Elemento { get => elemento; set => elemento = value; } 
        public frmEditarDsolicitudTela(Controlador controlador)
        {
            this.control = controlador;
            Elemento = new Objeto();
            InitializeComponent();
        }

       

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Objeto> lista = new List<Objeto>();
            if (txbRefTela.Text.Trim().Length > 0)
            {
                
                //txbRefTela.Clear();
                lista = control.buscarTelaPorReferencia(txbRefTela.Text.Trim());
                
            }
            else if (txbDescripcion.Text.Trim().Length > 0)
            {
               // txbDescripcion.Clear();
                lista = control.buscarTelaPorDescripcion(txbDescripcion.Text.Trim().ToUpper());
            }
            //else
            //{
            //    lista = control.getTela();
            //}
            listar(lista);
        }
        private void listar(List<Objeto> lista)
        {
            dgvRefTelas.Rows.Clear();
            dgvRefTelas.Columns.Clear();
            dgvRefTelas.DataSource = null;
            dgvRefTelas.Columns.Add("Column0", "Referencia Tela");
            dgvRefTelas.Columns.Add("Column1", "Descripción Tela");
        
            foreach (Objeto elemento in lista)
            {
                dgvRefTelas.Rows.Add(elemento.Id, elemento.Nombre);
            }
            dgvRefTelas.Columns[0].ReadOnly = true;
            dgvRefTelas.Columns[1].ReadOnly = true;
   
            dgvRefTelas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvRefTelas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    
        }

        private void dgvRefTelas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            elemento.Id = dgvRefTelas.CurrentRow.Cells[0].Value.ToString();
            elemento.Nombre = dgvRefTelas.CurrentRow.Cells[1].Value.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txbDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                string descripcion = txbDescripcion.Text.Trim().ToUpper();
                if (descripcion.Length > 0)
                {
                    listar(control.buscarTelaPorDescripcion(descripcion));
                }
            }
            //else
            //{
            //    listar(control.getTela());
            //}
        }

        private void txbRefTela_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                string refTela = txbRefTela.Text.Trim().ToUpper();
                if (refTela.Length > 0)
                {
                    listar(control.buscarTelaPorReferencia(refTela));
                }
            }
            //else
            //{
            //    listar(control.getTela());
            //}
        }
    }
}
