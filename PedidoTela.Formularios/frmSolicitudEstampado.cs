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
    public partial class frmSolicitudEstampado : MaterialSkin.Controls.MaterialForm
    {
        Controlador controlador = new Controlador();
        Validar validacion = new Validar();
        public frmSolicitudEstampado()
        {
            InitializeComponent();
        }

        private void frmSolicitudEstampado_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
            //El tamaño máximo de carácteres
            txbCoordinaCon.MaxLength = 40;
            txtObsEstampado.MaxLength = 120;

            cargarCombobox(cbxTipoTela, controlador.getTipoTejido());


        }
        public void recibirInfoTela(string prmRefTela, string nomTela)
        {
            txbRefTela.Text= prmRefTela;
            txbNomTela.Text = nomTela;
        }
        /// <summary>
        /// Muestra lista de tipo de pedido encontrados en la BD.
        /// </summary>
        /// <param name="prmCombo">ComobBox de Seleccón. </param>
        /// <param name="prmLista">Contien Tipo Pedido.</param>
        private void cargarCombobox(ComboBox prmCombo, List<TipoPedido> prmLista)
        {
            prmCombo.DataSource = prmLista;
            prmCombo.DisplayMember = "Descripcion";
            prmCombo.ValueMember = "Tipo";
            prmCombo.SelectedIndex = -1;
            prmCombo.AutoCompleteCustomSource = cargarCombobox(prmLista);
            prmCombo.AutoCompleteMode = AutoCompleteMode.Suggest;
            prmCombo.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }
        /// <summary>
        /// Autocompleta la lista desplegable del ComboBox.
        /// </summary>
        /// <param name="prmLista">Lista de Ensayos-Referencias</param>
        /// <returns></returns>
        private AutoCompleteStringCollection cargarCombobox(List<TipoPedido> prmLista)
        {
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            foreach (TipoPedido obj in prmLista)
            {
                datos.Add(obj.Descripcion);
            }
            return datos;
        }

        private void txbNdibujo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);

        }

        private void txbNcilindro_KeyPress(object sender, KeyPressEventArgs e)
        {
            validacion.SoloNumeros(e);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmTipoSolicitud frmTsolicitud = new frmTipoSolicitud();
            frmTsolicitud.Show();
        }

        private void cbxSiCoordinadoEst_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxSiCoordinadoEst.Checked)
            {
                txbCoordinaCon.ReadOnly = false;
                txbCoordinaCon.Focus();
                txbCoordinaCon.BackColor = Color.LightGoldenrodYellow;
                cbxNoCoordinadoEst.Checked = false;
            }
           
        }

        private void cbxNoCoordinadoEst_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxNoCoordinadoEst.Checked)
            {
                txbCoordinaCon.ReadOnly = true;
                txbCoordinaCon.BackColor = Color.White;
                cbxSiCoordinadoEst.Checked = false;

            }
        }

        private void btnAddColor_Click(object sender, EventArgs e)
        {
            frmBuscarColor buscarColor = new frmBuscarColor(controlador);
            buscarColor.StartPosition = FormStartPosition.CenterScreen;
            if (buscarColor.ShowDialog() == DialogResult.OK)
            {
                Objeto obj = buscarColor.Elemento;
                dvgEstampado.Rows.Add();
                dvgEstampado.Rows[dvgEstampado.Rows.Count - 1].Cells[0].Value = obj.Id;
                dvgEstampado.Rows[dvgEstampado.Rows.Count - 1].Cells[1].Value = obj.Nombre;
            }
        }

        private void dvgEstampado_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dvgEstampado.CurrentCell.Value != null)
                {
                    int ultimaColumna = dvgEstampado.ColumnCount - 1;

                    if (e.ColumnIndex > 1 && e.ColumnIndex < ultimaColumna)
                    {
                        dvgEstampado.CurrentCell.Value = Regex.Replace(dvgEstampado.CurrentCell.Value.ToString().Trim(), @"[^0-9]", "");
                        if (dvgEstampado.CurrentCell.Value.ToString() != "")
                        {
                            int total = 0;
                            for (int i = 2; i < ultimaColumna; i++)
                            {
                                if (dvgEstampado.Rows[e.RowIndex].Cells[i].Value != null && dvgEstampado.Rows[e.RowIndex].Cells[i].Value.ToString() != "")
                                {
                                    total += int.Parse(dvgEstampado.Rows[e.RowIndex].Cells[i].Value.ToString());
                                }
                            }
                            dvgEstampado.Rows[e.RowIndex].Cells[ultimaColumna].Value = total;
                        }
                    }
                }
            }
            catch (ArgumentException aex)
            {
                dvgEstampado.CurrentCell.Value = "";
                MessageBox.Show("Unicamente se permiten valores numéricos", "Tipo de dato no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dvgEstampado_SelectionChanged(object sender, EventArgs e)
        {
            //if (dvgEstampado.CurrentCell == dvgEstampado.CurrentRow.Cells["Fondo"])
            //{
            //    dvgEstampado.BeginEdit(true);
            //    string tien = dvgEstampado.Rows[0].Cells[2].Value.ToString();
            //    Console.WriteLine("jjgjg", tien);

            //}
         

        }
    }
}
