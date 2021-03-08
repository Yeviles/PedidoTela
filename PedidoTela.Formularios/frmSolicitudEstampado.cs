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
        private Controlador controlador;
        //Controlador controlador = new Controlador();
        Validar validacion = new Validar();
        public frmSolicitudEstampado(Controlador controlador)
        {
            this.controlador = controlador;
            InitializeComponent();
        }

        private void frmSolicitudEstampado_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
            //El tamaño máximo de carácteres
            txbCoordinaCon.MaxLength = 40;
            txtObservaciones.MaxLength = 120;

            cargarCombobox(cbxTipoTela, controlador.getTipoTejido());


        }
        public void recibirInfoTela(string prmRefTela, string nomTela, string identificador)
        {
            txbRefTela.Text= prmRefTela;
            txbNomTela.Text = nomTela;
            lbIdentificador.Text = identificador;
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
            if(cbxSiCoordinado.Checked)
            {
                txbCoordinaCon.ReadOnly = false;
                txbCoordinaCon.Focus();
                txbCoordinaCon.BackColor = Color.LightGoldenrodYellow;
                cbxNoCoordinado.Checked = false;
            }
           
        }

        private void cbxNoCoordinadoEst_CheckedChanged(object sender, EventArgs e)
        {
            if(cbxNoCoordinado.Checked)
            {
                txbCoordinaCon.ReadOnly = true;
                txbCoordinaCon.BackColor = Color.White;
                cbxSiCoordinado.Checked = false;

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
                            for (int i = 4; i < ultimaColumna; i++)
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

        private void dvgEstampado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgEstampado.Columns[e.ColumnIndex].Name == "fondo" || dvgEstampado.Columns[e.ColumnIndex].Name == "descripcionFondo")
            {
                frmBuscarColor buscarColor = new frmBuscarColor(controlador);
                buscarColor.StartPosition = FormStartPosition.CenterScreen;
                if (buscarColor.ShowDialog() == DialogResult.OK)
                {
                    Objeto obj = buscarColor.Elemento;
                    //dvgEstampado.Rows.Add();
                    dvgEstampado.Rows[dvgEstampado.Rows.Count - 1].Cells[2].Value = obj.Id;
                    dvgEstampado.Rows[dvgEstampado.Rows.Count - 1].Cells[3].Value = obj.Nombre;
                }

            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (!cbxSiCoordinado.Checked && !cbxNoCoordinado.Checked)
            {
                MessageBox.Show("Por favor, seleccione un valor para coordinado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtObservaciones.Text.Trim().Length > 0)
                {
                    if (dvgEstampado.RowCount > 0)
                    {
                        Estampado elemento = new Estampado();
                        elemento.Esayo_ref = lbIdentificador.Text;
                        elemento.Referencia_tela = txbRefTela.ToString();
                        elemento.Nombre_tela = txbNomTela.Text.Trim();
                        elemento.Tipo_estampado = cbxTipoEst.SelectedItem.ToString();
                        elemento.Tipo_tejido = cbxTipoTela.SelectedItem.ToString();
                        elemento.N_dibujos = int.Parse(txbNdibujo.Text.Trim());
                        elemento.N_cilindors = int.Parse(txbNcilindro.Text.Trim());
                        elemento.Coordinado_con = (txbCoordinaCon.Text.Trim().Length > 0) ? txbCoordinaCon.Text.Trim() : ""; ;
                        elemento.Coordinado = (cbxSiCoordinado.Checked) ? true : false; ;
                        elemento.Observaciones = (txtObservaciones.Text.Trim().Length > 0) ? txtObservaciones.Text.Trim() : ""; ;
                        if (controlador.addEstampado(elemento))
                        {
                            //int id = controlador.getIdUnicolor(idEnsayo.ToString());
                            try
                            {
                                foreach (DataGridViewRow row in dvgEstampado.Rows)
                                {
                                    DetalleEstampado detalle = new DetalleEstampado();
                                    detalle.CodigoColor = row.Cells[0].Value.ToString();
                                    detalle.Desc_color = row.Cells[1].Value.ToString();
                                    detalle.Fondo = row.Cells[2].Value.ToString();
                                    detalle.Des_fondo = row.Cells[3].Value.ToString();
                                    detalle.Tiendas = (row.Cells[4].Value != null && row.Cells[4].Value.ToString() != "") ? int.Parse(row.Cells[4].Value.ToString()) : 0;
                                    detalle.Exito = (row.Cells[5].Value != null && row.Cells[5].Value.ToString() != "") ? int.Parse(row.Cells[5].Value.ToString()) : 0;
                                    detalle.Cencosud = (row.Cells[6].Value != null && row.Cells[6].Value.ToString() != "") ? int.Parse(row.Cells[6].Value.ToString()) : 0;
                                    detalle.Sao = (row.Cells[7].Value != null && row.Cells[7].Value.ToString() != "") ? int.Parse(row.Cells[7].Value.ToString()) : 0;
                                    detalle.Comercio = (row.Cells[8].Value != null && row.Cells[8].Value.ToString() != "") ? int.Parse(row.Cells[8].Value.ToString()) : 0;
                                    detalle.Rosado = (row.Cells[9].Value != null && row.Cells[9].Value.ToString() != "") ? int.Parse(row.Cells[9].Value.ToString()) : 0;
                                    detalle.Otros = (row.Cells[10].Value != null && row.Cells[10].Value.ToString() != "") ? int.Parse(row.Cells[10].Value.ToString()) : 0;
                                    detalle.Total = (row.Cells[11].Value != null && row.Cells[11].Value.ToString() != "") ? int.Parse(row.Cells[11].Value.ToString()) : 0;
                                    detalle.IdEstampado = int.Parse(lbIdentificador.Text);
                                    controlador.addDetalleEstampado(detalle);
                                }
                                MessageBox.Show("Estampado se guardó con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Detalle Estampado no se pudo guardar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, adicione al menos un color", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese las observaciones de diseño", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


    }
}
