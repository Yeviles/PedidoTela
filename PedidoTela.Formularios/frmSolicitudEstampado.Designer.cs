
namespace PedidoTela.Formularios
{
    partial class frmSolicitudEstampado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSolicitudColor = new System.Windows.Forms.Panel();
            this.cbxTipoTela = new System.Windows.Forms.ComboBox();
            this.cbxTipoEst = new System.Windows.Forms.ComboBox();
            this.lbTipoTela = new System.Windows.Forms.Label();
            this.txbNomTela = new System.Windows.Forms.TextBox();
            this.txbNcilindro = new System.Windows.Forms.TextBox();
            this.txbCoordinaCon = new System.Windows.Forms.TextBox();
            this.lbNumeroCilindros = new System.Windows.Forms.Label();
            this.lbCoordinaCon = new System.Windows.Forms.Label();
            this.lbCoordinado = new System.Windows.Forms.Label();
            this.txbNdibujo = new System.Windows.Forms.TextBox();
            this.cbxSiCoordinado = new System.Windows.Forms.CheckBox();
            this.cbxNoCoordinado = new System.Windows.Forms.CheckBox();
            this.lbReferenciaTela = new System.Windows.Forms.Label();
            this.lbNombreTela = new System.Windows.Forms.Label();
            this.lbNDibujos = new System.Windows.Forms.Label();
            this.lbTipoestampado = new System.Windows.Forms.Label();
            this.txbRefTela = new System.Windows.Forms.TextBox();
            this.dvgEstampado = new System.Windows.Forms.DataGridView();
            this.lbObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.RichTextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblConsecutivo = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAddColor = new System.Windows.Forms.Button();
            this.lbIdentificador = new System.Windows.Forms.Label();
            this.lbSolicitud = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.codColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fondo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionFondo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiendas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comercioOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rosado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalUnidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSolicitudColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEstampado)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSolicitudColor
            // 
            this.pnlSolicitudColor.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlSolicitudColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSolicitudColor.Controls.Add(this.cbxTipoTela);
            this.pnlSolicitudColor.Controls.Add(this.cbxTipoEst);
            this.pnlSolicitudColor.Controls.Add(this.lbTipoTela);
            this.pnlSolicitudColor.Controls.Add(this.txbNomTela);
            this.pnlSolicitudColor.Controls.Add(this.txbNcilindro);
            this.pnlSolicitudColor.Controls.Add(this.txbCoordinaCon);
            this.pnlSolicitudColor.Controls.Add(this.lbNumeroCilindros);
            this.pnlSolicitudColor.Controls.Add(this.lbCoordinaCon);
            this.pnlSolicitudColor.Controls.Add(this.lbCoordinado);
            this.pnlSolicitudColor.Controls.Add(this.txbNdibujo);
            this.pnlSolicitudColor.Controls.Add(this.cbxSiCoordinado);
            this.pnlSolicitudColor.Controls.Add(this.cbxNoCoordinado);
            this.pnlSolicitudColor.Controls.Add(this.lbReferenciaTela);
            this.pnlSolicitudColor.Controls.Add(this.lbNombreTela);
            this.pnlSolicitudColor.Controls.Add(this.lbNDibujos);
            this.pnlSolicitudColor.Controls.Add(this.lbTipoestampado);
            this.pnlSolicitudColor.Controls.Add(this.txbRefTela);
            this.pnlSolicitudColor.Location = new System.Drawing.Point(15, 149);
            this.pnlSolicitudColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSolicitudColor.Name = "pnlSolicitudColor";
            this.pnlSolicitudColor.Size = new System.Drawing.Size(1356, 107);
            this.pnlSolicitudColor.TabIndex = 22;
            // 
            // cbxTipoTela
            // 
            this.cbxTipoTela.FormattingEnabled = true;
            this.cbxTipoTela.Items.AddRange(new object[] {
            "PLANO",
            "PUNTO",
            "PRETEÑIDO"});
            this.cbxTipoTela.Location = new System.Drawing.Point(507, 59);
            this.cbxTipoTela.Name = "cbxTipoTela";
            this.cbxTipoTela.Size = new System.Drawing.Size(222, 20);
            this.cbxTipoTela.TabIndex = 22;
            // 
            // cbxTipoEst
            // 
            this.cbxTipoEst.FormattingEnabled = true;
            this.cbxTipoEst.Items.AddRange(new object[] {
            "ROTATIVO",
            "DIGITAL"});
            this.cbxTipoEst.Location = new System.Drawing.Point(507, 18);
            this.cbxTipoEst.Name = "cbxTipoEst";
            this.cbxTipoEst.Size = new System.Drawing.Size(222, 20);
            this.cbxTipoEst.TabIndex = 21;
            // 
            // lbTipoTela
            // 
            this.lbTipoTela.AutoSize = true;
            this.lbTipoTela.Location = new System.Drawing.Point(373, 66);
            this.lbTipoTela.Name = "lbTipoTela";
            this.lbTipoTela.Size = new System.Drawing.Size(92, 13);
            this.lbTipoTela.TabIndex = 19;
            this.lbTipoTela.Text = "Tipo de Tejido:";
            // 
            // txbNomTela
            // 
            this.txbNomTela.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txbNomTela.Location = new System.Drawing.Point(144, 63);
            this.txbNomTela.Name = "txbNomTela";
            this.txbNomTela.ReadOnly = true;
            this.txbNomTela.Size = new System.Drawing.Size(223, 20);
            this.txbNomTela.TabIndex = 18;
            // 
            // txbNcilindro
            // 
            this.txbNcilindro.Location = new System.Drawing.Point(1076, 63);
            this.txbNcilindro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbNcilindro.Name = "txbNcilindro";
            this.txbNcilindro.Size = new System.Drawing.Size(102, 20);
            this.txbNcilindro.TabIndex = 17;
            this.txbNcilindro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbNcilindro_KeyPress);
            // 
            // txbCoordinaCon
            // 
            this.txbCoordinaCon.BackColor = System.Drawing.SystemColors.Window;
            this.txbCoordinaCon.Location = new System.Drawing.Point(1076, 23);
            this.txbCoordinaCon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbCoordinaCon.Name = "txbCoordinaCon";
            this.txbCoordinaCon.ReadOnly = true;
            this.txbCoordinaCon.Size = new System.Drawing.Size(222, 20);
            this.txbCoordinaCon.TabIndex = 11;
            this.txbCoordinaCon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCoordinaCon_KeyPress);
            // 
            // lbNumeroCilindros
            // 
            this.lbNumeroCilindros.AutoSize = true;
            this.lbNumeroCilindros.Location = new System.Drawing.Point(963, 63);
            this.lbNumeroCilindros.Name = "lbNumeroCilindros";
            this.lbNumeroCilindros.Size = new System.Drawing.Size(74, 13);
            this.lbNumeroCilindros.TabIndex = 16;
            this.lbNumeroCilindros.Text = "N° Cilindro:";
            // 
            // lbCoordinaCon
            // 
            this.lbCoordinaCon.AutoSize = true;
            this.lbCoordinaCon.Location = new System.Drawing.Point(963, 25);
            this.lbCoordinaCon.Name = "lbCoordinaCon";
            this.lbCoordinaCon.Size = new System.Drawing.Size(88, 13);
            this.lbCoordinaCon.TabIndex = 7;
            this.lbCoordinaCon.Text = "Coordina con:";
            // 
            // lbCoordinado
            // 
            this.lbCoordinado.AutoSize = true;
            this.lbCoordinado.Location = new System.Drawing.Point(748, 24);
            this.lbCoordinado.Name = "lbCoordinado";
            this.lbCoordinado.Size = new System.Drawing.Size(78, 13);
            this.lbCoordinado.TabIndex = 6;
            this.lbCoordinado.Text = "Coordinado:";
            // 
            // txbNdibujo
            // 
            this.txbNdibujo.Location = new System.Drawing.Point(858, 61);
            this.txbNdibujo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbNdibujo.Name = "txbNdibujo";
            this.txbNdibujo.Size = new System.Drawing.Size(79, 20);
            this.txbNdibujo.TabIndex = 15;
            this.txbNdibujo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbNdibujo_KeyPress);
            // 
            // cbxSiCoordinado
            // 
            this.cbxSiCoordinado.AutoSize = true;
            this.cbxSiCoordinado.Location = new System.Drawing.Point(914, 25);
            this.cbxSiCoordinado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxSiCoordinado.Name = "cbxSiCoordinado";
            this.cbxSiCoordinado.Size = new System.Drawing.Size(37, 17);
            this.cbxSiCoordinado.TabIndex = 13;
            this.cbxSiCoordinado.Text = "Si";
            this.cbxSiCoordinado.UseVisualStyleBackColor = true;
            this.cbxSiCoordinado.CheckedChanged += new System.EventHandler(this.cbxSiCoordinadoEst_CheckedChanged);
            // 
            // cbxNoCoordinado
            // 
            this.cbxNoCoordinado.AutoSize = true;
            this.cbxNoCoordinado.Location = new System.Drawing.Point(859, 25);
            this.cbxNoCoordinado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxNoCoordinado.Name = "cbxNoCoordinado";
            this.cbxNoCoordinado.Size = new System.Drawing.Size(41, 17);
            this.cbxNoCoordinado.TabIndex = 12;
            this.cbxNoCoordinado.Text = "No";
            this.cbxNoCoordinado.UseVisualStyleBackColor = true;
            this.cbxNoCoordinado.CheckedChanged += new System.EventHandler(this.cbxNoCoordinadoEst_CheckedChanged);
            // 
            // lbReferenciaTela
            // 
            this.lbReferenciaTela.AutoSize = true;
            this.lbReferenciaTela.Location = new System.Drawing.Point(14, 21);
            this.lbReferenciaTela.Name = "lbReferenciaTela";
            this.lbReferenciaTela.Size = new System.Drawing.Size(100, 13);
            this.lbReferenciaTela.TabIndex = 3;
            this.lbReferenciaTela.Text = "Referencia Tela:";
            // 
            // lbNombreTela
            // 
            this.lbNombreTela.AutoSize = true;
            this.lbNombreTela.Location = new System.Drawing.Point(13, 67);
            this.lbNombreTela.Name = "lbNombreTela";
            this.lbNombreTela.Size = new System.Drawing.Size(102, 13);
            this.lbNombreTela.TabIndex = 4;
            this.lbNombreTela.Text = "Nombre de Tela:";
            // 
            // lbNDibujos
            // 
            this.lbNDibujos.AutoSize = true;
            this.lbNDibujos.Location = new System.Drawing.Point(745, 63);
            this.lbNDibujos.Name = "lbNDibujos";
            this.lbNDibujos.Size = new System.Drawing.Size(73, 13);
            this.lbNDibujos.TabIndex = 14;
            this.lbNDibujos.Text = "N° Dibujos:";
            // 
            // lbTipoestampado
            // 
            this.lbTipoestampado.AutoSize = true;
            this.lbTipoestampado.Location = new System.Drawing.Point(373, 23);
            this.lbTipoestampado.Name = "lbTipoestampado";
            this.lbTipoestampado.Size = new System.Drawing.Size(103, 13);
            this.lbTipoestampado.TabIndex = 5;
            this.lbTipoestampado.Text = "Tipo Estampado:";
            // 
            // txbRefTela
            // 
            this.txbRefTela.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txbRefTela.Location = new System.Drawing.Point(145, 18);
            this.txbRefTela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbRefTela.Name = "txbRefTela";
            this.txbRefTela.ReadOnly = true;
            this.txbRefTela.Size = new System.Drawing.Size(222, 20);
            this.txbRefTela.TabIndex = 8;
            // 
            // dvgEstampado
            // 
            this.dvgEstampado.AllowUserToAddRows = false;
            this.dvgEstampado.AllowUserToDeleteRows = false;
            this.dvgEstampado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgEstampado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dvgEstampado.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgEstampado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dvgEstampado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgEstampado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codColor,
            this.descripColor,
            this.fondo,
            this.descripcionFondo,
            this.tiendas,
            this.exito,
            this.cencosud,
            this.sao,
            this.comercioOrg,
            this.rosado,
            this.otros,
            this.totalUnidades,
            this.eliminar});
            this.dvgEstampado.EnableHeadersVisualStyles = false;
            this.dvgEstampado.Location = new System.Drawing.Point(12, 377);
            this.dvgEstampado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dvgEstampado.MultiSelect = false;
            this.dvgEstampado.Name = "dvgEstampado";
            this.dvgEstampado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.CornflowerBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgEstampado.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dvgEstampado.RowHeadersVisible = false;
            this.dvgEstampado.RowHeadersWidth = 62;
            this.dvgEstampado.RowTemplate.Height = 28;
            this.dvgEstampado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dvgEstampado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dvgEstampado.Size = new System.Drawing.Size(1359, 294);
            this.dvgEstampado.TabIndex = 27;
            this.dvgEstampado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgEstampado_CellClick);
            this.dvgEstampado.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgEstampado_CellEndEdit);
            this.dvgEstampado.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dvgEstampado_CellPainting);
            // 
            // lbObservaciones
            // 
            this.lbObservaciones.AutoSize = true;
            this.lbObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbObservaciones.Location = new System.Drawing.Point(15, 683);
            this.lbObservaciones.Name = "lbObservaciones";
            this.lbObservaciones.Size = new System.Drawing.Size(136, 15);
            this.lbObservaciones.TabIndex = 29;
            this.lbObservaciones.Text = "Observaciones Diseño";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(14, 702);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(1357, 75);
            this.txtObservaciones.TabIndex = 28;
            this.txtObservaciones.Text = "";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.lblConsecutivo);
            this.panel9.Controls.Add(this.btnConfirmar);
            this.panel9.Controls.Add(this.btnGrabar);
            this.panel9.Controls.Add(this.btnSalir);
            this.panel9.Location = new System.Drawing.Point(12, 73);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1359, 47);
            this.panel9.TabIndex = 134;
            // 
            // lblConsecutivo
            // 
            this.lblConsecutivo.AutoSize = true;
            this.lblConsecutivo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsecutivo.Location = new System.Drawing.Point(545, 15);
            this.lblConsecutivo.Name = "lblConsecutivo";
            this.lblConsecutivo.Size = new System.Drawing.Size(0, 16);
            this.lblConsecutivo.TabIndex = 99;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Image = global::PedidoTela.Formularios.Properties.Resources.confirmar1;
            this.btnConfirmar.Location = new System.Drawing.Point(128, 3);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(126, 41);
            this.btnConfirmar.TabIndex = 96;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.LightGray;
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGrabar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = global::PedidoTela.Formularios.Properties.Resources.guardar2;
            this.btnGrabar.Location = new System.Drawing.Point(2, 3);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(126, 41);
            this.btnGrabar.TabIndex = 95;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGrabar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGrabar.UseVisualStyleBackColor = false;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::PedidoTela.Formularios.Properties.Resources.salir2;
            this.btnSalir.Location = new System.Drawing.Point(251, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(126, 41);
            this.btnSalir.TabIndex = 97;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAddColor
            // 
            this.btnAddColor.Image = global::PedidoTela.Formularios.Properties.Resources.addColor;
            this.btnAddColor.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddColor.Location = new System.Drawing.Point(15, 300);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(181, 50);
            this.btnAddColor.TabIndex = 129;
            this.btnAddColor.Text = "Adicionar Color";
            this.btnAddColor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddColor.UseVisualStyleBackColor = true;
            this.btnAddColor.Click += new System.EventHandler(this.btnAddColor_Click);
            // 
            // lbIdentificador
            // 
            this.lbIdentificador.AutoSize = true;
            this.lbIdentificador.BackColor = System.Drawing.Color.Transparent;
            this.lbIdentificador.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIdentificador.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbIdentificador.Location = new System.Drawing.Point(210, 34);
            this.lbIdentificador.Name = "lbIdentificador";
            this.lbIdentificador.Size = new System.Drawing.Size(15, 18);
            this.lbIdentificador.TabIndex = 135;
            this.lbIdentificador.Text = "-";
            // 
            // lbSolicitud
            // 
            this.lbSolicitud.AutoSize = true;
            this.lbSolicitud.BackColor = System.Drawing.SystemColors.Window;
            this.lbSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbSolicitud.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSolicitud.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbSolicitud.Location = new System.Drawing.Point(641, 300);
            this.lbSolicitud.Name = "lbSolicitud";
            this.lbSolicitud.Size = new System.Drawing.Size(182, 19);
            this.lbSolicitud.TabIndex = 150;
            this.lbSolicitud.Text = "SOLICITUD ESTAMPADO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Image = global::PedidoTela.Formularios.Properties.Resources.seleccion4;
            this.pictureBox1.Location = new System.Drawing.Point(613, 295);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 33);
            this.pictureBox1.TabIndex = 151;
            this.pictureBox1.TabStop = false;
            // 
            // codColor
            // 
            this.codColor.HeaderText = "Cod Color";
            this.codColor.MinimumWidth = 8;
            this.codColor.Name = "codColor";
            this.codColor.ReadOnly = true;
            // 
            // descripColor
            // 
            this.descripColor.HeaderText = "Descripción Color";
            this.descripColor.MinimumWidth = 8;
            this.descripColor.Name = "descripColor";
            this.descripColor.ReadOnly = true;
            // 
            // fondo
            // 
            this.fondo.HeaderText = "Fondo";
            this.fondo.MinimumWidth = 8;
            this.fondo.Name = "fondo";
            this.fondo.ReadOnly = true;
            // 
            // descripcionFondo
            // 
            this.descripcionFondo.HeaderText = "Descripción Fondo";
            this.descripcionFondo.MinimumWidth = 8;
            this.descripcionFondo.Name = "descripcionFondo";
            this.descripcionFondo.ReadOnly = true;
            // 
            // tiendas
            // 
            this.tiendas.HeaderText = "Tiendas";
            this.tiendas.MinimumWidth = 8;
            this.tiendas.Name = "tiendas";
            // 
            // exito
            // 
            this.exito.HeaderText = "Éxito";
            this.exito.MinimumWidth = 8;
            this.exito.Name = "exito";
            // 
            // cencosud
            // 
            this.cencosud.HeaderText = "Cencosud";
            this.cencosud.MinimumWidth = 8;
            this.cencosud.Name = "cencosud";
            // 
            // sao
            // 
            this.sao.HeaderText = "SAO";
            this.sao.MinimumWidth = 8;
            this.sao.Name = "sao";
            // 
            // comercioOrg
            // 
            this.comercioOrg.HeaderText = "Comercio Org.";
            this.comercioOrg.MinimumWidth = 8;
            this.comercioOrg.Name = "comercioOrg";
            // 
            // rosado
            // 
            this.rosado.HeaderText = "Rosado";
            this.rosado.MinimumWidth = 8;
            this.rosado.Name = "rosado";
            // 
            // otros
            // 
            this.otros.HeaderText = "Otros";
            this.otros.MinimumWidth = 8;
            this.otros.Name = "otros";
            // 
            // totalUnidades
            // 
            this.totalUnidades.HeaderText = "Total Unidades";
            this.totalUnidades.MinimumWidth = 8;
            this.totalUnidades.Name = "totalUnidades";
            // 
            // eliminar
            // 
            this.eliminar.HeaderText = "Eliminar";
            this.eliminar.MinimumWidth = 6;
            this.eliminar.Name = "eliminar";
            // 
            // frmSolicitudEstampado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 788);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbSolicitud);
            this.Controls.Add(this.lbIdentificador);
            this.Controls.Add(this.btnAddColor);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.lbObservaciones);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.dvgEstampado);
            this.Controls.Add(this.pnlSolicitudColor);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmSolicitudEstampado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitud Estampado";
            this.Load += new System.EventHandler(this.frmSolicitudEstampado_Load);
            this.pnlSolicitudColor.ResumeLayout(false);
            this.pnlSolicitudColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEstampado)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSolicitudColor;
        private System.Windows.Forms.Label lbReferenciaTela;
        private System.Windows.Forms.Label lbNombreTela;
        private System.Windows.Forms.CheckBox cbxSiCoordinado;
        private System.Windows.Forms.Label lbTipoestampado;
        private System.Windows.Forms.CheckBox cbxNoCoordinado;
        private System.Windows.Forms.Label lbCoordinado;
        private System.Windows.Forms.TextBox txbCoordinaCon;
        private System.Windows.Forms.Label lbCoordinaCon;
        private System.Windows.Forms.TextBox txbRefTela;
        private System.Windows.Forms.TextBox txbNdibujo;
        private System.Windows.Forms.Label lbNDibujos;
        private System.Windows.Forms.TextBox txbNcilindro;
        private System.Windows.Forms.Label lbNumeroCilindros;
        private System.Windows.Forms.DataGridView dvgEstampado;
        private System.Windows.Forms.Label lbObservaciones;
        private System.Windows.Forms.RichTextBox txtObservaciones;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAddColor;
        private System.Windows.Forms.TextBox txbNomTela;
        private System.Windows.Forms.ComboBox cbxTipoTela;
        private System.Windows.Forms.ComboBox cbxTipoEst;
        private System.Windows.Forms.Label lbTipoTela;
        private System.Windows.Forms.Label lblConsecutivo;
        private System.Windows.Forms.Label lbIdentificador;
        private System.Windows.Forms.Label lbSolicitud;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn fondo;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionFondo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiendas;
        private System.Windows.Forms.DataGridViewTextBoxColumn exito;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosud;
        private System.Windows.Forms.DataGridViewTextBoxColumn sao;
        private System.Windows.Forms.DataGridViewTextBoxColumn comercioOrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn rosado;
        private System.Windows.Forms.DataGridViewTextBoxColumn otros;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalUnidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn eliminar;
    }
}