﻿using MaterialSkin;
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
        private string identificador;
        Validar validacion = new Validar();
        private int id = 0, consecutivo = 0, idSolTelas;


        public string Identificador { get => identificador; set => identificador = value; }

        public frmSolicitudEstampado(Controlador controlador, string identificador, string refTela, string desTela, int idTelas)
        {
            this.controlador = controlador;
            this.identificador = identificador;
            this.idSolTelas = idTelas;
            InitializeComponent();
            txbRefTela.Text = refTela;
            txbNomTela.Text = desTela;
            lbIdentificador.Text = identificador;
            cargarCombobox(cbxTipoTela, controlador.getTipoTejido());
            cargarEstampado();
            //if (dvgEstampado.RowCount > 0)
            //{
            //    btnGrabar.Enabled = false;
            //    dvgEstampado.ReadOnly = true;
            //}
            //else
            //{
            //    btnConfirmar.Enabled = false;
            //}
        }

        private void frmSolicitudEstampado_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
            //El tamaño máximo de carácteres
            txbCoordinaCon.MaxLength = 40;
            txtObservaciones.MaxLength = 120;
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
            prmCombo.ValueMember = "Descripcion";
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
            this.Close();
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
                    int ultimaColumna = dvgEstampado.ColumnCount - 2;

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

        private void dvgEstampado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgEstampado.Columns[e.ColumnIndex].Name == "fondo" || dvgEstampado.Columns[e.ColumnIndex].Name == "descripcionFondo")
            {
                frmBuscarColor buscarColor = new frmBuscarColor(controlador);
                buscarColor.StartPosition = FormStartPosition.CenterScreen;
                if (buscarColor.ShowDialog() == DialogResult.OK)
                {
                    Objeto obj = buscarColor.Elemento;
                    dvgEstampado.Rows[dvgEstampado.Rows.Count - 1].Cells[2].Value = obj.Id;
                    dvgEstampado.Rows[dvgEstampado.Rows.Count - 1].Cells[3].Value = obj.Nombre;
                }

            }
            if (dvgEstampado.Columns[e.ColumnIndex].Name == "eliminar")
            {
                dvgEstampado.Rows.Remove(dvgEstampado.CurrentRow);
            }
        }
        
        /// <summary>
        /// Guarda infomación en dos tablas difrente que estan relacionadas entre si, las cuales son cfc_spt_sol_estampado, cfc_spt_sol_detalleEstampado
        /// y formando asi la infomación completa de la solicitud Estampado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            bool b = false;
            List<int> listaIdDetalles = new List<int>();
            if (!cbxSiCoordinado.Checked && !cbxNoCoordinado.Checked)
            {
                MessageBox.Show("Por favor, seleccione un valor para coordinado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtObservaciones.Text.Trim().Length > 0)
                {
                    if (cbxTipoEst.SelectedIndex != -1)
                    {
                        if (cbxTipoTela.SelectedIndex != -1)
                        {

                            if (dvgEstampado.RowCount > 0)
                            {
                                bool vacio = false;
                                foreach (DataGridViewRow row in dvgEstampado.Rows)
                                {
                                    if (row.Cells[2].Value == null || row.Cells[3].Value == null) {
                                        vacio = true;
                                    }
                                }
                                if (!vacio)
                                {
                                    Estampado elemento = new Estampado();
                                    elemento.Esayo_ref = lbIdentificador.Text;
                                    elemento.Referencia_tela = txbRefTela.Text.ToString();
                                    elemento.Nombre_tela = txbNomTela.Text.Trim();
                                    elemento.Tipo_estampado = cbxTipoEst.SelectedItem.ToString();
                                    elemento.Tipo_tejido = cbxTipoTela.SelectedValue.ToString();
                                    elemento.N_dibujos = int.Parse(txbNdibujo.Text.Trim());
                                    elemento.N_cilindros = int.Parse(txbNcilindro.Text.Trim());
                                    elemento.Coordinado_con = (txbCoordinaCon.Text.Trim().Length > 0) ? txbCoordinaCon.Text.Trim() : "";
                                    elemento.Coordinado = (cbxSiCoordinado.Checked) ? true : false;
                                    elemento.Observaciones = (txtObservaciones.Text.Trim().Length > 0) ? txtObservaciones.Text.Trim() : "";
                                    elemento.IdSolTela = idSolTelas;
                                    
                                    if (controlador.consultarIdentificadorEst(idSolTelas))
                                    {
                                        controlador.ActualizarEstampado(elemento);
                                       
                                        b = true;
                                    }
                                    else
                                    {
                                        controlador.addEstampado(elemento);
                                    }
                                  
                                    id = controlador.consultarIdEst(idSolTelas);
                                    listaIdDetalles = controlador.getIdDetalleEst(id);
                                    try
                                    {

                                        for (int i = 0; i < dvgEstampado.RowCount; i++)
                                        {
                                            DetalleEstampado detalle = new DetalleEstampado();
                                            detalle.CodigoColor = dvgEstampado.Rows[i].Cells[0].Value.ToString();
                                            detalle.Desc_color = dvgEstampado.Rows[i].Cells[1].Value.ToString();
                                            detalle.Fondo = dvgEstampado.Rows[i].Cells[2].Value.ToString();
                                            detalle.Des_fondo = dvgEstampado.Rows[i].Cells[3].Value.ToString();
                                            detalle.Tiendas = (dvgEstampado.Rows[i].Cells[4].Value != null && dvgEstampado.Rows[i].Cells[4].Value.ToString() != "") ? int.Parse(dvgEstampado.Rows[i].Cells[4].Value.ToString()) : 0;
                                            detalle.Exito = (dvgEstampado.Rows[i].Cells[5].Value != null && dvgEstampado.Rows[i].Cells[5].Value.ToString() != "") ? int.Parse(dvgEstampado.Rows[i].Cells[5].Value.ToString()) : 0;
                                            detalle.Cencosud = (dvgEstampado.Rows[i].Cells[6].Value != null && dvgEstampado.Rows[i].Cells[6].Value.ToString() != "") ? int.Parse(dvgEstampado.Rows[i].Cells[6].Value.ToString()) : 0;
                                            detalle.Sao = (dvgEstampado.Rows[i].Cells[7].Value != null && dvgEstampado.Rows[i].Cells[7].Value.ToString() != "") ? int.Parse(dvgEstampado.Rows[i].Cells[7].Value.ToString()) : 0;
                                            detalle.Comercio = (dvgEstampado.Rows[i].Cells[8].Value != null && dvgEstampado.Rows[i].Cells[8].Value.ToString() != "") ? int.Parse(dvgEstampado.Rows[i].Cells[8].Value.ToString()) : 0;
                                            detalle.Rosado = (dvgEstampado.Rows[i].Cells[9].Value != null && dvgEstampado.Rows[i].Cells[9].Value.ToString() != "") ? int.Parse(dvgEstampado.Rows[i].Cells[9].Value.ToString()) : 0;
                                            detalle.Otros = (dvgEstampado.Rows[i].Cells[10].Value != null && dvgEstampado.Rows[i].Cells[10].Value.ToString() != "") ? int.Parse(dvgEstampado.Rows[i].Cells[10].Value.ToString()) : 0;
                                            detalle.Total = (dvgEstampado.Rows[i].Cells[11].Value != null && dvgEstampado.Rows[i].Cells[11].Value.ToString() != "") ? int.Parse(dvgEstampado.Rows[i].Cells[11].Value.ToString()) : 0;
                                            detalle.IdEstampado = id;

                                            //btnGrabar.Enabled = false;
                                            //btnAddColor.Enabled = false;
                                            //btnConfirmar.Enabled = true;
                                            if (b)
                                            {
                                                if (i < listaIdDetalles.Count)
                                                {
                                                    controlador.ActualizarDetalleEstampado(detalle, listaIdDetalles[i]);
                                                }
                                                else
                                                {
                                                    controlador.addDetalleEstampado(detalle);
                                                }
                                            }
                                            else
                                            {
                                                controlador.addDetalleEstampado(detalle);
                                            }
                                        }

                                        MessageBox.Show("Estampado se guardó con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    catch
                                    {
                                        MessageBox.Show("Detalle Estampado no se pudo guardar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Los campos fondo y descripción de fondo están vacíos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                              else
                            {
                                MessageBox.Show("Por favor, adicione al menos un color.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                         else
                        {
                            MessageBox.Show("Por favor,Seleccione un tipo de tejido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor,Seleccione un tipo de estampado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese las observaciones de diseño.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        
        private void cargarEstampado()
        {
            //int idEstampado = (controlador.consultarIdEstampado(identificador).ToString() != null && controlador.consultarIdEstampado(identificador).ToString() != "") ? int.Parse(controlador.consultarIdEstampado(identificador).ToString()) : 0;

            Estampado objEstampado = controlador.getEstampado(idSolTelas);
            id = objEstampado.IdEstampado;
            if (objEstampado.Coordinado)
            {
                cbxSiCoordinado.Checked = true;
                txbCoordinaCon.Text = objEstampado.Coordinado_con;
            }
            else
            {
                cbxNoCoordinado.Checked = true;
            }
            consecutivo = controlador.consultarConsecutivo(id);
            if (id != 0 && consecutivo != 0) {
                lblConsecutivo.Text = "Consecutivo: " + consecutivo;
                dvgEstampado.ReadOnly = true;
                btnConfirmar.Enabled = false;
                btnAddColor.Enabled = false;
                btnGrabar.Enabled = false;
           
            }
            cbxTipoEst.Text = objEstampado.Tipo_estampado;
            //cbxTipoTela.Text = objEstampado.Tipo_tejido;
            TipoPedido item = new TipoPedido();
            foreach (TipoPedido obj in cbxTipoTela.Items) {
                if (obj.Descripcion == objEstampado.Tipo_tejido) {
                    item = obj;
                }
            }
            cbxTipoTela.SelectedItem = item;
            txbNdibujo.Text = objEstampado.N_dibujos.ToString();
            txbNcilindro.Text = objEstampado.N_cilindros.ToString();
            txtObservaciones.Text = objEstampado.Observaciones;

            /*Carga detalle objEstampado*/
            List<DetalleEstampado> lista = controlador.getDetalleEstampado(objEstampado.IdEstampado);
            if (lista.Count > 0)
            {
                foreach (DetalleEstampado obj in lista)
                {
                    dvgEstampado.Rows.Add(obj.CodigoColor, obj.Desc_color, obj.Fondo, obj.Des_fondo, obj.Tiendas, obj.Exito,
                        obj.Cencosud, obj.Sao, obj.Comercio, obj.Rosado, obj.Otros, obj.Total);
                }
               // btnAddColor.Enabled = false;
               // dvgEstampado.ReadOnly = true;
                //btnGrabar.Enabled = false;
                //txtObservaciones.Enabled = false;
            }
        }

        private void txbCoordinaCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void dvgEstampado_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dvgEstampado.Columns[e.ColumnIndex].Name == "eliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = dvgEstampado.Rows[e.RowIndex].Cells["eliminar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(@"eliminar.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 25, e.CellBounds.Top + 3);

                dvgEstampado.Rows[e.RowIndex].Height = icoAtomico.Height + 50;
                dvgEstampado.Columns[e.ColumnIndex].Width = icoAtomico.Width + 50;

                e.Handled = true;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            //Estampado objEstampado = controlador.getEstampado(id);
            //id = objEstampado.IdEstampado;
            //int idSolicitud = controlador.consultarIdsolicitud(identificador);
            
            int maxConsecutivo = controlador.consultarMaximo();
            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            string estado = "Por Analizar";
            if (id != 0)
            {
               
              
                    controlador.agregarConsecutivo(idSolTelas, id, "ESTAMPADO", maxConsecutivo + 1, fechaActual, estado, fechaActual, Identificador);
                    MessageBox.Show("El consecutivo se guardó con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnConfirmar.Enabled = false;
                    btnGrabar.Enabled = false;
                    txtObservaciones.Enabled = false;
                    btnAddColor.Enabled = false;
                    dvgEstampado.ReadOnly = true;
                    consecutivo = controlador.consultarConsecutivo(id);
                    lblConsecutivo.Text = "Consecutivo: " + consecutivo;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Por favor, Grabe la Información.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    
    }
}
