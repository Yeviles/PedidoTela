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
using MaterialSkin;

namespace PedidoTela.Formularios
{
    public partial class frmBuscarColor : MaterialSkin.Controls.MaterialForm
    {
        Controlador control;
        private Objeto elemento;

        public Objeto Elemento { get => elemento; set => elemento = value; }

        public frmBuscarColor(Controlador control)
        {
            this.control = control;
            elemento = new Objeto();
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Objeto> lista = new List<Objeto>();
            if (txbCodigo.Text.Trim().Length > 0)
            {
                lista = control.buscarColorPorCodigo(txbCodigo.Text.Trim());
            }
            else if (txbDescripcion.Text.Trim().Length > 0)
            {
                lista = control.buscarColorPorDescripcion(txbDescripcion.Text.Trim().ToUpper());
            }
            else
            {
                lista = control.getColores();
            }
            listar(lista);
        }

        private void txbCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) {
                btnBuscar_Click(sender, e);
            }
        }

        private void txbDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar_Click(sender, e);
            }
        }

        private void dgvColores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            elemento.Id = dgvColores.CurrentRow.Cells[0].Value.ToString();
            elemento.Nombre = dgvColores.CurrentRow.Cells[1].Value.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void listar(List<Objeto> lista)
        {
            dgvColores.Rows.Clear();
            dgvColores.Columns.Clear();
            dgvColores.DataSource = null;
            dgvColores.Columns.Add("Column0", "Código");
            dgvColores.Columns.Add("Column1", "Descripción");

            foreach (Objeto elemento in lista)
            {
                dgvColores.Rows.Add(elemento.Id, elemento.Nombre);
            }
            dgvColores.Columns[0].ReadOnly = true;
            dgvColores.Columns[1].ReadOnly = true;
            dgvColores.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvColores.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void frmBuscarColor_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
            listar(control.getColores());
        }
    }
}
