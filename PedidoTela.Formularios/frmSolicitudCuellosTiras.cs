using MaterialSkin;
using PedidoTela.Controlodores;
using PedidoTela.Entidades.Logica;
using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace PedidoTela.Formularios
{
    public partial class frmSolicitudCuellosTiras : MaterialSkin.Controls.MaterialForm
    {
        #region variables
        private Controlador controlador;
        private string identificador, cuellos, punos, tiras;
        private int id = 0, consecutivo = 0, catidadSeleccionada = 0, idSolTela;
        private Image imgCuellos, imgPunos, imgTiras;
        private Boolean swImgCuellos = false, swImgPunos = false, swImgTiras = false;
        private string tipoImgCuellos = "", tipoImgPunos = "", tipoImgTiras = "";
        #endregion

        public Image ImgCuellos { get => imgCuellos; set => imgCuellos = value; }
        public Image ImgPunos { get => imgPunos; set => imgPunos = value; }
        public Image ImgTiras { get => imgTiras; set => imgTiras = value; }

        public frmSolicitudCuellosTiras(Controlador controlador, string identificador, int idSoTelas)
        {
            this.controlador = controlador;
            this.identificador = identificador;
            this.idSolTela = idSoTelas;

            InitializeComponent();
            lbIdentificador.Text = identificador;

            btnImgCuellos.Enabled = false;
            btnImgPunos.Enabled = false;
            btnImgTiras.Enabled = false;

            //dgvCuellos1.HeadersCellVisible = false;
            dgvCuellos1.RowHeadersVisible = false;
            dgvCuellos2.Columns["codH1"].HeaderCell.ToolTipText = "Doble Clic para seleccionar Color.";
            dgvCuellos2.Columns["codH2"].HeaderCell.ToolTipText = "Doble Clic para seleccionar Color.";
            dgvCuellos2.Columns["codH3"].HeaderCell.ToolTipText = "Doble Clic para seleccionar Color.";
            dgvCuellos2.Columns["codH4"].HeaderCell.ToolTipText = "Doble Clic para seleccionar Color.";
            dgvCuellos2.Columns["codH5"].HeaderCell.ToolTipText = "Doble Clic para seleccionar Color.";



            cargarCuellosTiras();


            if (dgvCuellos1.RowCount < 0 && dgvCuellos2.RowCount < 0)
            {
                btnConfirmar.Enabled = false;
            }
        }

        private void frmSolicitudCuellosTiras_Load(object sender, EventArgs e)
        {
            SkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            SkinManager.ColorScheme = new ColorScheme(Primary.Blue900, Primary.Grey500, Primary.Grey200, Accent.Green100, TextShade.WHITE);
            txbCoordinaCon.MaxLength = 40;
            txtObservaciones.MaxLength = 120;

            //dgvCuellos1.RowCount = 3;
            //dgvCuellos1.Rows[0].HeaderCell.Value = "Cuellos";
            //dgvCuellos1.Rows[1].HeaderCell.Value = "Puños";
            //dgvCuellos1.Rows[2].HeaderCell.Value = "Tiras";


        }

        #region Botones
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            bool b = false;
            List<int> listaIdDetalles = new List<int>();

            List<int> listaIdDetalleDos = new List<int>();
            if (!cbxTiras.Checked && !cbxCuellos.Checked && !cbxPunos.Checked)
            {
                MessageBox.Show("Por favor, Seleccione un Tipo Tela.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!cbxSiCoordinado.Checked && !cbxNoCoordinado.Checked)
            {
                MessageBox.Show("Por favor, seleccione un valor para coordinado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ptbCuellos.Image == null && ptbPunos.Image == null && ptbCuellos.Image == null)
            {
                MessageBox.Show("Por favor, Seleccione almenos una imagen.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtObservaciones.Text.Trim().Length > 0)
                {
                    if (dgvCuellos2.RowCount > 0 && dgvCuellos1.RowCount > 0)
                    {
                        bool vacio = false;
                        foreach (DataGridViewRow row in dgvCuellos2.Rows)
                        {
                            if (row.Cells[2].Value == null || row.Cells[3].Value == null)
                            {
                                vacio = true;
                            }
                        }

                        if (!vacio)
                        {
                            CuellosTiras elemento = new CuellosTiras();
                            elemento.Identificador = identificador;
                            elemento.Cuellos = (cbxCuellos.Checked) ? true : false;
                            elemento.Punos = (cbxPunos.Checked) ? true : false;
                            elemento.Tiras = (cbxTiras.Checked) ? true : false;
                            elemento.Coordinado = (cbxSiCoordinado.Checked) ? true : false;
                            elemento.CoordinadoCon = (txbCoordinaCon.Text.Trim().Length > 0) ? txbCoordinaCon.Text.Trim() : "";
                            elemento.Observacion = (txtObservaciones.Text.Trim().Length > 0) ? txtObservaciones.Text.Trim() : "";
                            elemento.IdSolTela = idSolTela;
                            if (controlador.consultarIdentificadorCuel(idSolTela))
                            {
                                controlador.ActualizarCuellos(elemento);
                                b = true;
                            }
                            else
                            {
                                controlador.addCuellosTiras(elemento);
                            }
                            id = controlador.getIdCuellos(idSolTela);
                            listaIdDetalles = controlador.getIdDetallecuellosUno(id);
                            listaIdDetalleDos = controlador.getIdDetallecuellosDos(id);
                            
                            try
                            {
                                for (int i = 0; i < dgvCuellos1.RowCount; i++)
                                {

                                    DetalleCuelloUno detalle = new DetalleCuelloUno();
                                    detalle.IdCuellos = id;
                                    detalle.NombreChechSel = (dgvCuellos1.Rows[i].Cells[0].Value.ToString());
                                    detalle.Codigo = (dgvCuellos1.Rows[i].Cells[1].Value != null && dgvCuellos1.Rows[i].Cells[1].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[1].Value.ToString() : "";
                                    detalle.Xs = (dgvCuellos1.Rows[i].Cells[2].Value != null && dgvCuellos1.Rows[i].Cells[2].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[2].Value.ToString() : "0";
                                    detalle.S = (dgvCuellos1.Rows[i].Cells[3].Value != null && dgvCuellos1.Rows[i].Cells[3].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[3].Value.ToString() : "0";
                                    detalle.M = (dgvCuellos1.Rows[i].Cells[4].Value != null && dgvCuellos1.Rows[i].Cells[4].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[4].Value.ToString() : "0";
                                    detalle.L = (dgvCuellos1.Rows[i].Cells[5].Value != null && dgvCuellos1.Rows[i].Cells[5].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[5].Value.ToString() : "0";
                                    detalle.Xl = (dgvCuellos1.Rows[i].Cells[6].Value != null && dgvCuellos1.Rows[i].Cells[6].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[6].Value.ToString() : "0";
                                    detalle.Dosxl = (dgvCuellos1.Rows[i].Cells[7].Value != null && dgvCuellos1.Rows[i].Cells[7].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[7].Value.ToString() : "0";
                                    detalle.Cuatro = (dgvCuellos1.Rows[i].Cells[8].Value != null && dgvCuellos1.Rows[i].Cells[8].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[8].Value.ToString() : "0";
                                    detalle.Seis = (dgvCuellos1.Rows[i].Cells[9].Value != null && dgvCuellos1.Rows[i].Cells[9].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[9].Value.ToString() : "0";
                                    detalle.Ocho = (dgvCuellos1.Rows[i].Cells[10].Value != null && dgvCuellos1.Rows[i].Cells[10].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[10].Value.ToString() : "0";
                                    detalle.Diez = (dgvCuellos1.Rows[i].Cells[11].Value != null && dgvCuellos1.Rows[i].Cells[11].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[11].Value.ToString() : "0";
                                    detalle.Doce = (dgvCuellos1.Rows[i].Cells[12].Value != null && dgvCuellos1.Rows[i].Cells[12].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[12].Value.ToString() : "0";
                                    detalle.Catorce = (dgvCuellos1.Rows[i].Cells[13].Value != null && dgvCuellos1.Rows[i].Cells[13].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[13].Value.ToString() : "0";
                                    detalle.Dieciseis = (dgvCuellos1.Rows[i].Cells[14].Value != null && dgvCuellos1.Rows[i].Cells[14].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[14].Value.ToString() : "0";
                                    detalle.Dieciocho = (dgvCuellos1.Rows[i].Cells[15].Value != null && dgvCuellos1.Rows[i].Cells[15].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[15].Value.ToString() : "0";
                                    detalle.Veinte = (dgvCuellos1.Rows[i].Cells[16].Value != null && dgvCuellos1.Rows[i].Cells[16].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[16].Value.ToString() : "0";
                                    detalle.Veintidos = (dgvCuellos1.Rows[i].Cells[17].Value != null && dgvCuellos1.Rows[i].Cells[17].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[17].Value.ToString() : "0";
                                    detalle.Veinticuatro = (dgvCuellos1.Rows[i].Cells[18].Value != null && dgvCuellos1.Rows[i].Cells[18].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[18].Value.ToString() : "0";
                                    detalle.Ancho = (dgvCuellos1.Rows[i].Cells[19].Value != null && dgvCuellos1.Rows[i].Cells[19].Value.ToString() != "") ? dgvCuellos1.Rows[i].Cells[19].Value.ToString() : "0";


                                    if (b)
                                    {
                                        if (i < listaIdDetalles.Count)
                                        {
                                            controlador.ActualizarDetalleCuelloUno(detalle, listaIdDetalles[i]);
                                        }
                                        else
                                        {
                                            controlador.addDetalleCuelloUno(detalle);
                                        }
                                    }
                                    else
                                    {
                                        controlador.addDetalleCuelloUno(detalle);
                                    }

                                }
                                for (int i = 0; i < dgvCuellos2.RowCount; i++)
                                {
                                    DetalleCuelloDos detalle = new DetalleCuelloDos();
                                    detalle.IdCuellos = id;
                                    detalle.CodigoVte = dgvCuellos2.Rows[i].Cells[0].Value.ToString();
                                    detalle.DescripcionVte = dgvCuellos2.Rows[i].Cells[1].Value.ToString().Trim();
                                    detalle.CodigoH1 = dgvCuellos2.Rows[i].Cells[2].Value.ToString();
                                    detalle.DescripcionH1 = dgvCuellos2.Rows[i].Cells[3].Value.ToString().Trim();
                                    detalle.CodigoH2 = dgvCuellos2.Rows[i].Cells[4].Value.ToString();
                                    detalle.DescripcionH2 = dgvCuellos2.Rows[i].Cells[5].Value.ToString().Trim();
                                    detalle.CodigoH3 = dgvCuellos2.Rows[i].Cells[6].Value.ToString();
                                    detalle.DescripcionH3 = dgvCuellos2.Rows[i].Cells[7].Value.ToString().Trim();
                                    detalle.CodigoH4 = dgvCuellos2.Rows[i].Cells[8].Value.ToString();
                                    detalle.DescripcionH4 = dgvCuellos2.Rows[i].Cells[9].Value.ToString().Trim();
                                    detalle.CodigoH5 = dgvCuellos2.Rows[i].Cells[10].Value.ToString();
                                    detalle.DescripcionH5 = dgvCuellos2.Rows[i].Cells[11].Value.ToString().Trim();
                                    detalle.Total = (dgvCuellos2.Rows[i].Cells[12].Value != null && dgvCuellos2.Rows[i].Cells[12].Value.ToString() != "") ? int.Parse(dgvCuellos2.Rows[i].Cells[12].Value.ToString()) : 0;

                                    if (b)
                                    {
                                        if (i < listaIdDetalleDos.Count)
                                        {
                                            controlador.ActualizarDetalleCuelloDos(detalle, listaIdDetalleDos[i]);
                                        }
                                        else
                                        {
                                            controlador.addDetalleCuelloDos(detalle);
                                        }
                                    }
                                    else
                                    {
                                        controlador.addDetalleCuelloDos(detalle);
                                    }
                                }
                                guardarImagen();
                                MessageBox.Show("Cuellos-Puños-Tiras se guardó con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            catch
                            {
                                MessageBox.Show("Detalle Cuellos-Puños-Tiras no se pudo guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El campo color H1 está vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, adicione al menos un color.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese las observaciones de diseño.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int maxConsecutivo = controlador.consultarMaximo();

            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");

            string estado = "Por Analizar";

            if (id != 0)
            {
                controlador.agregarConsecutivo(idSolTela, id, "TIRAS/CUELLOS/PUÑOS", maxConsecutivo + 1, fechaActual, estado, fechaActual, identificador);
                MessageBox.Show("El consecutivo se guardó con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnConfirmar.Enabled = false;
                btnGrabar.Enabled = false;
                txtObservaciones.Enabled = false;
                btnAddColor.Enabled = false;
                dgvCuellos1.ReadOnly = true;
                dgvCuellos2.ReadOnly = true;
                consecutivo = controlador.consultarConsecutivo(id);
                lblConsecutivo.Text = "Consecutivo: " + consecutivo;
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Por favor, Grabe la Información.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddColor_Click(object sender, EventArgs e)
        {
            frmBuscarColor buscarColor = new frmBuscarColor(controlador);
            buscarColor.StartPosition = FormStartPosition.CenterScreen;
            if (buscarColor.ShowDialog() == DialogResult.OK)
            {
                Objeto obj = buscarColor.Elemento;
                dgvCuellos2.Rows.Add();
                dgvCuellos2.Rows[dgvCuellos2.Rows.Count - 1].Cells[0].Value = obj.Id;
                dgvCuellos2.Rows[dgvCuellos2.Rows.Count - 1].Cells[1].Value = obj.Nombre;
            }
        }

        #endregion

        #region Eventos
        private void btnImgCuellos_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imagenes|*.jpeg; *.jpg; *.png";
                ofd.Title = "Abriendo imagen";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string urlArchivo = ofd.FileName;
                    string nombre = ofd.SafeFileName;
                    ImgCuellos = Image.FromFile(urlArchivo);
                    string[] split = urlArchivo.Split('.');
                    tipoImgCuellos = split[split.Length - 1].ToLower();
                    ptbCuellos.Image = ImgCuellos;
                    ImgCuellos = ImgCuellos.GetThumbnailImage(300, 300, delegate { return false; }, System.IntPtr.Zero);
                    swImgCuellos = true;
                }
            }
        }

        private void btnImgPunos_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imagenes|*.jpeg; *.jpg; *.png";
                ofd.Title = "Abriendo imagen";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string urlArchivo = ofd.FileName;
                    string nombre = ofd.SafeFileName;
                    ImgPunos = Image.FromFile(urlArchivo);
                    string[] split = urlArchivo.Split('.');
                    tipoImgPunos = split[split.Length - 1].ToLower();
                    //pbxImagenFrente.Image = imgCuellos;
                    ptbPunos.Image = ImgPunos;
                    ImgPunos = ImgPunos.GetThumbnailImage(300, 300, delegate { return false; }, System.IntPtr.Zero);
                    //btnAddImgFrente.Visible = false;
                    //btnDelImgFrente.Visible = true;
                    swImgPunos = true;
                }
            }
        }

        private void btnImgTiras_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Imagenes|*.jpeg; *.jpg; *.png";
                ofd.Title = "Abriendo imagen";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string urlArchivo = ofd.FileName;
                    string nombre = ofd.SafeFileName;
                    ImgTiras = Image.FromFile(urlArchivo);
                    string[] split = urlArchivo.Split('.');
                    tipoImgTiras = split[split.Length - 1].ToLower();
                    //pbxImagenFrente.Image = imgCuellos;
                    ptbTiras.Image = ImgTiras;
                    ImgTiras = ImgTiras.GetThumbnailImage(300, 300, delegate { return false; }, System.IntPtr.Zero);
                    //btnAddImgFrente.Visible = false;
                    //btnDelImgFrente.Visible = true;
                    swImgTiras = true;
                }
            }
        }

        private void cbxSiCoordinado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSiCoordinado.Checked)
            {
                txbCoordinaCon.ReadOnly = false;
                txbCoordinaCon.Focus();
                txbCoordinaCon.BackColor = Color.White;
                cbxNoCoordinado.Checked = false;
            }
        }

        private void dgvCuellos2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvCuellos2.CurrentCell.ColumnIndex > 1 && dgvCuellos2.CurrentCell.ColumnIndex < 12)
            {
                if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete)
                {
                    if ((dgvCuellos2.CurrentCell.ColumnIndex % 2) == 0)
                    {
                        dgvCuellos2.CurrentRow.Cells[dgvCuellos2.CurrentCell.ColumnIndex].Value = "";
                        dgvCuellos2.CurrentRow.Cells[dgvCuellos2.CurrentCell.ColumnIndex + 1].Value = "";
                    }
                    else
                    {
                        dgvCuellos2.CurrentRow.Cells[dgvCuellos2.CurrentCell.ColumnIndex - 1].Value = "";
                        dgvCuellos2.CurrentRow.Cells[dgvCuellos2.CurrentCell.ColumnIndex].Value = "";
                    }
                }
            }
        }

        private void cbxNoCoordinado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNoCoordinado.Checked)
            {
                txbCoordinaCon.ReadOnly = true;
                txbCoordinaCon.BackColor = Color.LightGoldenrodYellow;
                cbxSiCoordinado.Checked = false;

            }
        }

        private void cbxCuellos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCuellos.Checked)
            {
                foreach (DataGridViewRow fila in dgvCuellos1.Rows)
                {

                    if (fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == "Cuellos")
                    {
                        fila.DefaultCellStyle.BackColor = Color.White;
                        fila.ReadOnly = false;
                        pnlCuellos.Enabled = true;
                        btnImgCuellos.Enabled = true;
                    }
                } 
            }
            else
            {
                foreach (DataGridViewRow fila in dgvCuellos1.Rows)
                {
                    if (fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == "Cuellos")
                    {
                        fila.DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                        fila.ReadOnly = true;
                    }

                }

                pnlCuellos.Enabled = false;
                btnImgCuellos.Enabled = false;
            }


        }

        private void cbxPunos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPunos.Checked)
            {
                foreach (DataGridViewRow fila in dgvCuellos1.Rows)
                {

                    if (fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == "Puños")
                    {
                        fila.DefaultCellStyle.BackColor = Color.White;
                        fila.ReadOnly = false;
                        pnlPunos.Enabled = true;
                        btnImgPunos.Enabled = true;
                    } 
                }             
            }
            else
            {
                foreach (DataGridViewRow fila in dgvCuellos1.Rows)
                {

                    if (fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == "Puños")
                    {
                        fila.DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                        fila.ReadOnly = true;
                    }
                }
                pnlPunos.Enabled = false;
                btnImgPunos.Enabled = false;

            }

        }

        private void cbxTiras_CheckedChanged(object sender, EventArgs e)
        {
            //dgvCuellos1.Rows.Clear();
            if (cbxTiras.Checked)
            {
                foreach (DataGridViewRow fila in dgvCuellos1.Rows)
                {

                    if (fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == "Tiras")
                    {
                        fila.DefaultCellStyle.BackColor = Color.White;
                        fila.ReadOnly = false;
                        pnlTiras.Enabled = true;
                        btnImgTiras.Enabled = true;
                        
                    }
                }

            }
            else
            {
                foreach (DataGridViewRow fila in dgvCuellos1.Rows)
                {

                    if (fila.Cells[0].Value != null && fila.Cells[0].Value.ToString() == "Tiras")
                    {
                        fila.DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                        fila.ReadOnly = true;
                    }
                }
                pnlTiras.Enabled = false;
                btnImgTiras.Enabled = false;

            }

        }

        private void txbCoordinaCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
        }

        private void dgvCuellos2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvCuellos2.Columns[e.ColumnIndex].Name == "eliminar" && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                DataGridViewButtonCell celBoton = dgvCuellos2.Rows[e.RowIndex].Cells["eliminar"] as DataGridViewButtonCell;
                Icon icoAtomico = new Icon(@"eliminar.ico");
                e.Graphics.DrawIcon(icoAtomico, e.CellBounds.Left + 25, e.CellBounds.Top + 3);

                dgvCuellos2.Rows[e.RowIndex].Height = icoAtomico.Height + 50;
                dgvCuellos2.Columns[e.ColumnIndex].Width = icoAtomico.Width + 50;

                e.Handled = true;
            }
        }

        private void dgvCuellos2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex < 12)
            {
                frmBuscarColor buscarColor = new frmBuscarColor(controlador);
                buscarColor.StartPosition = FormStartPosition.CenterScreen;

                if (buscarColor.ShowDialog() == DialogResult.OK)
                {
                    Objeto obj = buscarColor.Elemento;
                    if (e.ColumnIndex == 0 || e.ColumnIndex == 1)
                    {
                        dgvCuellos2.Rows[e.RowIndex].Cells[0].Value = obj.Id;
                        dgvCuellos2.Rows[e.RowIndex].Cells[1].Value = obj.Nombre;
                    }
                    if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
                    {
                        dgvCuellos2.Rows[e.RowIndex].Cells[2].Value = obj.Id;
                        dgvCuellos2.Rows[e.RowIndex].Cells[3].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
                    {
                        dgvCuellos2.Rows[e.RowIndex].Cells[4].Value = obj.Id;
                        dgvCuellos2.Rows[e.RowIndex].Cells[5].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 6 || e.ColumnIndex == 7)
                    {
                        dgvCuellos2.Rows[e.RowIndex].Cells[6].Value = obj.Id;
                        dgvCuellos2.Rows[e.RowIndex].Cells[7].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 8 || e.ColumnIndex == 9)
                    {
                        dgvCuellos2.Rows[e.RowIndex].Cells[8].Value = obj.Id;
                        dgvCuellos2.Rows[e.RowIndex].Cells[9].Value = obj.Nombre;
                    }
                    else if (e.ColumnIndex == 10 || e.ColumnIndex == 11)
                    {
                        dgvCuellos2.Rows[e.RowIndex].Cells[10].Value = obj.Id;
                        dgvCuellos2.Rows[e.RowIndex].Cells[11].Value = obj.Nombre;
                    }
                }
            }
            if (dgvCuellos2.Columns[e.ColumnIndex].Name == "eliminar")
            {
                dgvCuellos2.Rows.Remove(dgvCuellos2.CurrentRow);
            }
        }

        private void dgvCuellos2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvCuellos2.CurrentRow.Cells[13].ReadOnly = true;
            if (e.ColumnIndex == 12)
            {
                if (dgvCuellos2.CurrentCell.Value != null && dgvCuellos2.CurrentCell.Value.ToString().Trim() != "")
                {
                    dgvCuellos2.CurrentCell.Value = dgvCuellos2.CurrentCell.Value.ToString().Trim().Replace(".", ",");
                    dgvCuellos2.CurrentCell.Value = Regex.Replace(dgvCuellos2.CurrentCell.Value.ToString().Trim(), @"[^0-9,]", "");
                    if (dgvCuellos2.CurrentCell.Value != null && dgvCuellos2.CurrentCell.Value.ToString().Trim() != "")
                    {
                        int valor = int.Parse(dgvCuellos2.CurrentCell.Value.ToString());
                        decimal vfinal = Decimal.Round(valor, 2);
                        dgvCuellos2.CurrentCell.Value = valor;
                    }
                }
            }
           
            
        }

        private void dgvCuellos1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 2 && e.ColumnIndex <= 17)
            {
                //dgvCuellos1.CurrentCell.Value = dgvCuellos1.CurrentCell.Value.ToString().Trim().Replace(".", ",");
                //dgvCuellos1.CurrentCell.Value = Regex.Replace(dgvCuellos1.CurrentCell.Value.ToString().Trim(), @"[^0-9,]", "");
                if (dgvCuellos1.CurrentCell.Value != null && dgvCuellos1.CurrentCell.Value.ToString().Trim() != "")
                {

                    //int valor = int.Parse(dgvCuellos1.CurrentCell.Value.ToString());
                    decimal valor = Decimal.Parse(dgvCuellos1.CurrentCell.Value.ToString());
                    decimal vfinal = Decimal.Round(valor, 2);
                    dgvCuellos1.CurrentCell.Value = valor;
                }

            }
            if (e.ColumnIndex == 18)
            {
                if (dgvCuellos1.CurrentCell.Value != null && dgvCuellos1.CurrentCell.Value.ToString().Trim() != "")
                {
                    //dgvCuellos1.CurrentCell.Value = dgvCuellos1.CurrentCell.Value.ToString().Trim().Replace(".", ",");
                    //dgvCuellos1.CurrentCell.Value = Regex.Replace(dgvCuellos1.CurrentCell.Value.ToString().Trim(), @"[^0-9,]", "");
                    if (dgvCuellos1.CurrentCell.Value != null && dgvCuellos1.CurrentCell.Value.ToString().Trim() != "")
                    {
                        decimal valor = Decimal.Parse(dgvCuellos1.CurrentCell.Value.ToString());
                        decimal vfinal = Decimal.Round(valor, 2);
                        dgvCuellos1.CurrentCell.Value = vfinal;
                    }
                }
            }
            if (e.ColumnIndex == 1)
            {
                if (dgvCuellos1.CurrentCell.Value != null && dgvCuellos1.CurrentCell.Value.ToString().Trim() != "")
                {
                    string valor = dgvCuellos1.CurrentCell.Value.ToString();
                    dgvCuellos1.CurrentCell.Value = valor;
                }

            }
        }
        #endregion

        #region métodos
        private void cargarCuellosTiras()
        {
            CuellosTiras cuellosT = controlador.getCuellosTiras(idSolTela);
            id = cuellosT.IdCuellos;
            /* Carga las imagenes si ya estan guardadas */
            if (id != 0)
            {
                cargarImagen();
            }

            /* Verificación del Checked de Coordinado */
            if (cuellosT.Coordinado)
            {
                cbxSiCoordinado.Checked = true;
                txbCoordinaCon.Text = cuellosT.CoordinadoCon;
            }
            else
            {
                cbxNoCoordinado.Checked = true;
            }

            txtObservaciones.Text = cuellosT.Observacion;
            consecutivo = controlador.consultarConsecutivo(id);
            if (id != 0 && consecutivo != 0)
            {
                lblConsecutivo.Text = "Consecutivo: " + consecutivo;
                btnConfirmar.Enabled = false;
                dgvCuellos1.ReadOnly = true;
                dgvCuellos2.ReadOnly = true;
                btnAddColor.Enabled = false;
                btnGrabar.Enabled = false;
            }

            /*Carga detalle Cuellos-Puños-Tiras*/
            List<DetalleCuelloUno> listaUno = controlador.getDetalleCuellosUno(cuellosT.IdCuellos);
            if (listaUno.Count > 0)
            {

                foreach (DetalleCuelloUno obj in listaUno)
                {
                    dgvCuellos1.Rows.Add(obj.NombreChechSel, obj.Codigo, obj.Xs, obj.S, obj.M, obj.L, obj.Xl, obj.Dosxl,
                        obj.Cuatro, obj.Seis, obj.Ocho, obj.Diez, obj.Doce, obj.Catorce, obj.Dieciseis,
                        obj.Dieciocho, obj.Veinte, obj.Veintidos, obj.Veinticuatro, obj.Ancho);
                }
                dgvCuellos1.Rows[0].ReadOnly = true;
                dgvCuellos1.Rows[1].ReadOnly = true;
                dgvCuellos1.Rows[2].ReadOnly = true;

            }
            else
            {
                dgvCuellos1.DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                dgvCuellos1.RowCount = 3;
                dgvCuellos1.Rows[0].HeaderCell.Value = "Cuellos";
                dgvCuellos1.Rows[0].Cells[0].Value = "Cuellos";
                dgvCuellos1.Rows[0].ReadOnly = true;
                

                dgvCuellos1.Rows[1].HeaderCell.Value = "Puños";
                dgvCuellos1.Rows[1].Cells[0].Value = "Puños";
                dgvCuellos1.Rows[1].ReadOnly = true;

                dgvCuellos1.Rows[2].HeaderCell.Value = "Tiras";
                dgvCuellos1.Rows[2].Cells[0].Value = "Tiras";
                dgvCuellos1.Rows[2].ReadOnly = true;
            }
            /* Verificacion del Cheked del tipo de Tela */


            if (cuellosT.Cuellos)
            {
                cbxCuellos.Checked = true;
            }
            if (cuellosT.Punos)
            {
                cbxPunos.Checked = true;
            }
            if (cuellosT.Tiras)
            {
                cbxTiras.Checked = true;
            }
        

            List<DetalleCuelloDos> lista = controlador.getDetalleCuellosDos(cuellosT.IdCuellos);
            if (lista.Count > 0)
            {
                foreach (DetalleCuelloDos obj in lista)
                {
                    dgvCuellos2.Rows.Add(obj.CodigoVte, obj.DescripcionVte, obj.CodigoH1, obj.DescripcionH1, obj.CodigoH2, obj.DescripcionH2,
                        obj.CodigoH3, obj.DescripcionH3, obj.CodigoH4, obj.DescripcionH4, obj.CodigoH5, obj.DescripcionH5,
                        obj.Total);
                }
            }
        }

        private void cargarImagen()
        {
            try
            {
                string ruta = Application.StartupPath + "\\Imagenes\\" + identificador + idSolTela + "\\imagen\\";
                string rutaCuellos =ruta + identificador +idSolTela+ "_imagen_cuello.jpeg";
                string rutaPunos =ruta + identificador + idSolTela+"_imagen_punos.jpeg";
                string rutaTiras =ruta + identificador + idSolTela+"_imagen_tiras.jpeg";

                Image varImgCuellos = null, varImgPunos = null, varImgTiras = null;

                if (Directory.Exists(ruta))
                {
                    if (File.Exists(rutaCuellos))
                    {
                        varImgCuellos = Image.FromStream(new MemoryStream(File.ReadAllBytes(rutaCuellos)));
                    }
                    if (File.Exists(rutaPunos))
                    {
                        varImgPunos = Image.FromStream(new MemoryStream(File.ReadAllBytes(rutaPunos)));
                    }
                    if (File.Exists(rutaTiras))
                    {
                        varImgTiras = Image.FromStream(new MemoryStream(File.ReadAllBytes(rutaTiras)));
                    }
                }
                //else
                //{
                //    MessageBox.Show("Directorio de imagenes no encontrado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}

                if (varImgCuellos != null)
                {
                    string[] split = rutaCuellos.Split('.');
                    tipoImgCuellos = split[split.Length - 1].ToLower();
                    ptbCuellos.Image = varImgCuellos;
                }
                if (varImgPunos != null)
                {
                    string[] split = rutaPunos.Split('.');
                    tipoImgPunos = split[split.Length - 1].ToLower();
                    ptbPunos.Image = varImgPunos;
                }
                if (varImgTiras != null)
                {
                    string[] split = rutaCuellos.Split('.');
                    tipoImgTiras = split[split.Length - 1].ToLower();
                    ptbTiras.Image = varImgTiras;
                }

            }
            catch (FileNotFoundException) { }
            catch (OutOfMemoryException) { }
        }

        private void guardarImagen()
        {
            string ruta = Application.StartupPath + "\\Imagenes\\" + identificador + idSolTela + "\\imagen\\";
            bool directoryExists = Directory.Exists(ruta);
            //if (directoryExists)
            //{
            //    Directory.Delete(ruta, true);
            //}
            if (ptbCuellos.Image != null && swImgCuellos == true)
            {
                string nombre = identificador + idSolTela +"_imagen_cuello.jpeg";
               // File.Delete(ruta + nombre);
                controlador.guardarImagen(ruta, ImgCuellos, nombre, tipoImgCuellos);
            }
            if (ptbPunos.Image != null && swImgPunos == true)
            {
                string nombre = identificador + idSolTela + "_imagen_punos.jpeg";
                //File.Delete(ruta + nombre);
                controlador.guardarImagen(ruta, ImgPunos, nombre, tipoImgPunos);
            }
            if (ptbTiras.Image != null && swImgTiras == true)
            {
                string nombre = identificador + idSolTela + "_imagen_tiras.jpeg";
                //File.Delete(ruta + nombre);
                controlador.guardarImagen(ruta, ImgTiras, nombre, tipoImgTiras);
            }
        }
        #endregion
    }
}
