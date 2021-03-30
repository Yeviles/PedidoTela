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
        private Controlador controlador;
        private string identificador;
        private int id = 0, consecutivo = 0;

        private Image imgCuellos, imgPunos, imgTiras;
        Boolean swImgCuellos = false, swImgPunos = false, swImgTiras = false;
        string tipoImgCuellos, tipoImgPunos, tipoImgTiras;

        public string Identificador { get => identificador; set => identificador = value; }

        public Image ImgCuellos { get => imgCuellos; set => imgCuellos = value; }
        public Image ImgPunos { get => imgPunos; set => imgPunos = value; }
        public Image ImgTiras { get => imgTiras; set => imgTiras = value; }

        public frmSolicitudCuellosTiras(Controlador controlador, string identificador)
        {
            this.controlador = controlador;
            this.identificador = identificador;

            InitializeComponent();
            lbIdentificador.Text = identificador;
            CargarCuellosTiras();


            if (dgvCuellos1.RowCount > 0 && dgvCuellos2.RowCount > 0)
            {
                btnGrabar.Enabled = false;
                dgvCuellos1.ReadOnly = true;
                dgvCuellos2.ReadOnly = true;
            }
            else
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
            dgvCuellos1.RowCount = 3;
            dgvCuellos1.Rows[0].HeaderCell.Value = "Cuellos";
            dgvCuellos1.Rows[1].HeaderCell.Value = "Puños";
            dgvCuellos1.Rows[2].HeaderCell.Value = "Tiras";


        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            
       
            if (!cbxTiras.Checked && !cbxCuellos.Checked && !cbxPunos.Checked)
            {
                MessageBox.Show("Por favor, Seleccione un Tipo Tela.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!cbxSiCoordinado.Checked && !cbxNoCoordinado.Checked)
            {
                MessageBox.Show("Por favor, seleccione un valor para coordinado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ptbCuellos.Image == null && ptbPunos.Image == null &&ptbCuellos.Image == null)
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
                            if (row.Cells[2].Value == null || row.Cells[4].Value == null || row.Cells[6].Value == null ||
                                row.Cells[8].Value == null || row.Cells[10].Value == null)
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
                            if (controlador.addCuellosTiras(elemento))
                            {
                                id = controlador.getIdCuellos(identificador);
                                //Console.WriteLine("ID: " + id);
                                try
                                {
                                    foreach (DataGridViewRow row in dgvCuellos1.Rows)
                                    {
                                        DetalleCuelloUno detalle = new DetalleCuelloUno();
                                        detalle.IdCuellos = id;
                                        detalle.Codigo = (row.Cells[0].Value != null  && row.Cells[0].Value.ToString() != "") ? row.Cells[0].Value.ToString(): "";
                                        detalle.Xs = (row.Cells[1].Value != null && row.Cells[1].Value.ToString() != "") ? int.Parse(row.Cells[1].Value.ToString()) : 0;
                                        detalle.S = (row.Cells[2].Value != null && row.Cells[2].Value.ToString() != "") ? int.Parse(row.Cells[2].Value.ToString()) : 0;
                                        detalle.M = (row.Cells[3].Value != null && row.Cells[3].Value.ToString() != "") ? int.Parse(row.Cells[3].Value.ToString()) : 0;
                                        detalle.L = (row.Cells[4].Value != null && row.Cells[4].Value.ToString() != "") ? int.Parse(row.Cells[4].Value.ToString()) : 0;
                                        detalle.Xl = (row.Cells[5].Value != null && row.Cells[5].Value.ToString() != "") ? int.Parse(row.Cells[5].Value.ToString()) : 0;
                                        detalle.Dosxl = (row.Cells[6].Value != null && row.Cells[6].Value.ToString() != "") ? int.Parse(row.Cells[6].Value.ToString()) : 0;
                                        detalle.Cuatro = (row.Cells[7].Value != null && row.Cells[7].Value.ToString() != "") ? int.Parse(row.Cells[7].Value.ToString()) : 0;
                                        detalle.Seis = (row.Cells[8].Value != null && row.Cells[8].Value.ToString() != "") ? int.Parse(row.Cells[8].Value.ToString()) : 0;
                                        detalle.Ocho = (row.Cells[9].Value != null && row.Cells[9].Value.ToString() != "") ? int.Parse(row.Cells[9].Value.ToString()) : 0;
                                        detalle.Diez = (row.Cells[10].Value != null && row.Cells[10].Value.ToString() != "") ? int.Parse(row.Cells[10].Value.ToString()) : 0;
                                        detalle.Doce = (row.Cells[11].Value != null && row.Cells[11].Value.ToString() != "") ? int.Parse(row.Cells[11].Value.ToString()) : 0;
                                        detalle.Catorce = (row.Cells[12].Value != null && row.Cells[12].Value.ToString() != "") ? int.Parse(row.Cells[12].Value.ToString()) : 0;
                                        detalle.Dieciseis = (row.Cells[13].Value != null && row.Cells[13].Value.ToString() != "") ? int.Parse(row.Cells[13].Value.ToString()) : 0;
                                        detalle.Dieciocho = (row.Cells[14].Value != null && row.Cells[14].Value.ToString() != "") ? int.Parse(row.Cells[14].Value.ToString()) : 0;
                                        detalle.Veinte = (row.Cells[15].Value != null && row.Cells[15].Value.ToString() != "") ? int.Parse(row.Cells[15].Value.ToString()) : 0;
                                        detalle.Veintidos = (row.Cells[16].Value != null && row.Cells[16].Value.ToString() != "") ? int.Parse(row.Cells[16].Value.ToString()) : 0;
                                        detalle.Veinticuatro = (row.Cells[17].Value != null && row.Cells[17].Value.ToString() != "") ? int.Parse(row.Cells[17].Value.ToString()) : 0;
                                        detalle.Ancho = (row.Cells[18].Value != null && row.Cells[18].Value.ToString() != "") ? row.Cells[18].Value.ToString() : "0";

                                        // (dgvDetalleConsumo.Rows[e.RowIndex].Cells[5].Value != null) ? dgvDetalleConsumo.Rows[e.RowIndex].Cells[5].Value.ToString() : "0"
                                        //detalle.Total = (row.Cells[12].Value != null && row.Cells[12].Value.ToString() != "") ? int.Parse(row.Cells[12].Value.ToString()) : 0;
                                        controlador.addDetalleCuelloUno(detalle);
                                        //btnConfirmar.Enabled = true;
                                    }
                                    foreach (DataGridViewRow row in dgvCuellos2.Rows)
                                    {
                                        DetalleCuelloDos detalle = new DetalleCuelloDos();
                                        detalle.IdCuellos = id;
                                        detalle.CodigoVte = row.Cells[0].Value.ToString();
                                        detalle.DescripcionVte = row.Cells[1].Value.ToString().Trim();
                                        detalle.CodigoH1 = row.Cells[2].Value.ToString();
                                        detalle.DescripcionH1 = row.Cells[3].Value.ToString().Trim();
                                        detalle.CodigoH2 = row.Cells[4].Value.ToString();
                                        detalle.DescripcionH2 = row.Cells[5].Value.ToString().Trim();
                                        detalle.CodigoH3 = row.Cells[6].Value.ToString();
                                        detalle.DescripcionH3 = row.Cells[7].Value.ToString().Trim();
                                        detalle.CodigoH4 = row.Cells[8].Value.ToString();
                                        detalle.DescripcionH4 = row.Cells[9].Value.ToString().Trim();
                                        detalle.CodigoH5 = row.Cells[10].Value.ToString();
                                        detalle.DescripcionH5 = row.Cells[11].Value.ToString().Trim();
                                        detalle.Total = (row.Cells[12].Value != null && row.Cells[12].Value.ToString() != "") ? int.Parse(row.Cells[12].Value.ToString()) : 0;
                                        controlador.addDetalleCuelloDos(detalle);
                                        btnConfirmar.Enabled = true;
                                    }
                                    guardarImagen();
                                    txtObservaciones.Enabled = false;
                                    MessageBox.Show("Cuellos-Puños-Tiras se guardó con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dgvCuellos2.ReadOnly = true;
                                    btnGrabar.Enabled = false;
                                    btnAddColor.Enabled = false;
                                }
                                catch
                                {
                                    MessageBox.Show("Detalle Cuellos-Puños-Tiras no se pudo guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Los colores H1 - H5 están vacíos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            CuellosTiras objCuellos = controlador.getCuellosTiras(identificador);
            id = objCuellos.IdCuellos;
            int idSolicitud = controlador.consultarIdsolicitud(identificador);
            int maxConsecutivo = controlador.consultarMaximo();
            string fechaSolicitud = DateTime.Now.ToString("dd/MM/yyyy");
            string fechaEstado = DateTime.Now.ToString("dd/MM/yyyy");
            string estado = "Por Analizar";
            if (id != 0)
            {
                if (idSolicitud == 0)
                {
                    /* quiere decir que ese idSolicitud no está en la tabla cfc_spt_sol_tela
                     * hay que ingreser el identificador como parámetro  para id_solicitu*/
                    if (controlador.consultarConsecutivo(id) == 0)
                    {

                        controlador.agregarConsecutivo(identificador, id, "TIRAS/CUELLOS/PUÑOS", maxConsecutivo + 1,fechaSolicitud,estado,fechaEstado);
                        MessageBox.Show("El consecutivo se guardó con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnConfirmar.Enabled = false;
                        consecutivo = controlador.consultarConsecutivo(id);
                        lblConsecutivo.Text = "Consecutivo: " + consecutivo;
                    }
                }
                else
                {
                    controlador.agregarConsecutivo(identificador, id, "TIRAS/CUELLOS/PUÑOS", maxConsecutivo + 1,fechaSolicitud, estado, fechaEstado);
                    MessageBox.Show("El consecutivo se guardó con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnConfirmar.Enabled = false;
                    consecutivo = controlador.consultarConsecutivo(id);
                    lblConsecutivo.Text = "Consecutivo: " + consecutivo;
                }
            }
            else
            {
                MessageBox.Show("Por favor, Grabe la Información.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

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
                    //pbxImagenFrente.Image = imgCuellos;
                    ptbCuellos.Image = ImgCuellos;
                    ImgCuellos = ImgCuellos.GetThumbnailImage(300, 300, delegate { return false; }, System.IntPtr.Zero);
                    //btnAddImgFrente.Visible = false;
                    //btnDelImgFrente.Visible = true;
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxSiCoordinado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSiCoordinado.Checked)
            {
                txbCoordinaCon.ReadOnly = false;
                txbCoordinaCon.Focus();
                txbCoordinaCon.BackColor = Color.LightGoldenrodYellow;
                cbxNoCoordinado.Checked = false;
            }
        }

        private void cbxNoCoordinado_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNoCoordinado.Checked)
            {
                txbCoordinaCon.ReadOnly = true;
                txbCoordinaCon.BackColor = Color.White;
                cbxSiCoordinado.Checked = false;

            }
        }

        private void cbxCuellos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCuellos.Checked)
            {
                pnlCuellos.Enabled = true;
                pnlPunos.Enabled = false;
                pnlTiras.Enabled = false;

                cbxPunos.Checked = false;
                cbxTiras.Checked = false;
            }
        }

        private void cbxPunos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPunos.Checked)
            {
                pnlPunos.Enabled = true;
                pnlCuellos.Enabled = false;
                pnlTiras.Enabled = false;

                cbxTiras.Checked = false;
                cbxCuellos.Checked = false;
            }
        }

        private void cbxTiras_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTiras.Checked)
            {
                pnlTiras.Enabled = true;
                pnlCuellos.Enabled = false;
                pnlPunos.Enabled = false;

                cbxCuellos.Checked = false;
                cbxPunos.Checked = false;
            }
        }

        private void txbCoordinaCon_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
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

        private void dgvCuellos2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex < 12)
            {
                frmBuscarColor buscarColor = new frmBuscarColor(controlador);
                buscarColor.StartPosition = FormStartPosition.CenterScreen;

                if (buscarColor.ShowDialog() == DialogResult.OK)
                {
                    Objeto obj = buscarColor.Elemento;
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
        }

        private void dgvCuellos2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
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
            if (e.ColumnIndex >= 1 && e.ColumnIndex <= 17)
            {
                dgvCuellos1.CurrentCell.Value = Regex.Replace(dgvCuellos1.CurrentCell.Value.ToString().Trim(), @"[^0-9,]", "");
                if (dgvCuellos1.CurrentCell.Value != null && dgvCuellos1.CurrentCell.Value.ToString().Trim() != "") 
                {
                  
                    int valor = int.Parse(dgvCuellos1.CurrentCell.Value.ToString());
                    dgvCuellos1.CurrentCell.Value = valor;
                 } 
                
            }
            if (e.ColumnIndex == 18)
            {
                if (dgvCuellos1.CurrentCell.Value != null && dgvCuellos1.CurrentCell.Value.ToString().Trim() != "")
                {
                    dgvCuellos1.CurrentCell.Value = dgvCuellos1.CurrentCell.Value.ToString().Trim().Replace(".", ",");
                    dgvCuellos1.CurrentCell.Value = Regex.Replace(dgvCuellos1.CurrentCell.Value.ToString().Trim(), @"[^0-9,]", "");
                    if (dgvCuellos1.CurrentCell.Value != null && dgvCuellos1.CurrentCell.Value.ToString().Trim() != "")
                    {
                        decimal valor = Decimal.Parse(dgvCuellos1.CurrentCell.Value.ToString());
                        decimal vfinal = Decimal.Round(valor, 2);
                        dgvCuellos1.CurrentCell.Value = vfinal;
                    }
                }
            }
            if (e.ColumnIndex == 0)
            {
                if (dgvCuellos1.CurrentCell.Value != null && dgvCuellos1.CurrentCell.Value.ToString().Trim() != "")
                {
                    string valor = dgvCuellos1.CurrentCell.Value.ToString();
                    dgvCuellos1.CurrentCell.Value = valor;
                }

            }
        }

        private void CargarCuellosTiras()
        {
            CuellosTiras cuellosT = controlador.getCuellosTiras(identificador);
            id = cuellosT.IdCuellos;
            /* Carga las imagenes si ya estan guardadas */

            cargarImagen();

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

            /* Verificacion del Cheked del tipo de Tela */

            if (cuellosT.Cuellos)
            {
                cbxCuellos.Checked = true;
            }
            else if (cuellosT.Punos)
            {
                cbxPunos.Checked = true;
            }
            else if (cuellosT.Tiras)
            {
                cbxTiras.Checked = true;
            }

            txtObservaciones.Text = cuellosT.Observacion;
            consecutivo = controlador.consultarConsecutivo(id);
            if (id != 0 && consecutivo != 0)
            {
                lblConsecutivo.Text = "Consecutivo: " + consecutivo;
                btnConfirmar.Enabled = false;
                dgvCuellos1.ReadOnly = true;
                dgvCuellos2.ReadOnly = true;
            }

            /*Carga detalle Cuellos-Puños-Tiras*/
            List<DetalleCuelloUno> listaUno = controlador.getDetalleCuellosUno(cuellosT.IdCuellos);
            if (listaUno.Count > 0)
            {
                foreach (DetalleCuelloUno obj in listaUno)
                {
                    dgvCuellos1.Rows.Add(obj.Codigo, obj.Xs, obj.S, obj.M, obj.L, obj.Xl, obj.Dosxl,
                        obj.Cuatro, obj.Seis, obj.Ocho, obj.Diez, obj.Doce, obj.Catorce, obj.Dieciseis,
                        obj.Dieciocho, obj.Veinte, obj.Veintidos, obj.Veinticuatro,obj.Ancho);
                }
                btnAddColor.Enabled = false;
                dgvCuellos1.ReadOnly = true;
                btnGrabar.Enabled = false;
                txtObservaciones.Enabled = false;
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
                btnAddColor.Enabled = false;
                dgvCuellos2.ReadOnly = true;
                btnGrabar.Enabled = false;
                txtObservaciones.Enabled = false;
            }
        }

        private void cargarImagen()
        {
            try
            {
                string ruta = Application.StartupPath + "\\Imagenes\\" + identificador + "\\imagen\\";
                string rutaCuellos =ruta + identificador + "_imagen_cuello.jpeg";
                string rutaPunos =ruta + identificador + "_imagen_punos.jpeg";
                string rutaTiras =ruta + identificador + "_imagen_tiras.jpeg";

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
            string ruta = Application.StartupPath + "\\Imagenes\\" + identificador + "\\imagen\\";
            bool directoryExists = Directory.Exists(ruta);
            /*if (directoryExists)
            {
                Directory.Delete(ruta, true);
            }*/
            if (ptbCuellos.Image != null && swImgCuellos == true)
            {
                string nombre = identificador + "_imagen_cuello.jpeg";
                //File.Delete(ruta + nombre);
                controlador.guardarImagen(ruta, ImgCuellos, nombre, tipoImgCuellos);
            }
            if (ptbPunos.Image != null && swImgPunos == true)
            {
                string nombre = identificador + "_imagen_punos.jpeg";
                //File.Delete(ruta + nombre);
                controlador.guardarImagen(ruta, ImgPunos, nombre, tipoImgPunos);
            }
            if (ptbTiras.Image != null && swImgTiras == true)
            {
                string nombre = identificador + "_imagen_tiras.jpeg";
                ///File.Delete(ruta + nombre);
                controlador.guardarImagen(ruta, ImgTiras, nombre, tipoImgTiras);
            }
        }
       
    
    } 
}
