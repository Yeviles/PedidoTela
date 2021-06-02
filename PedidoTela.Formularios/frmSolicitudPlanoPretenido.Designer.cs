
namespace PedidoTela.Formularios
{
    partial class frmSolicitudPlanoPretenido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSolicitudColor = new System.Windows.Forms.Panel();
            this.cbxTipoTejido = new System.Windows.Forms.ComboBox();
            this.lbTipoTejido = new System.Windows.Forms.Label();
            this.txbNomTela = new System.Windows.Forms.TextBox();
            this.lbReferenciaTela = new System.Windows.Forms.Label();
            this.lbNombreTela = new System.Windows.Forms.Label();
            this.cbxSiCoordinado = new System.Windows.Forms.CheckBox();
            this.cbxNoCoordinado = new System.Windows.Forms.CheckBox();
            this.lbCoordinado = new System.Windows.Forms.Label();
            this.txbCoordinaCon = new System.Windows.Forms.TextBox();
            this.lbCoordinaCon = new System.Windows.Forms.Label();
            this.txbRefTela = new System.Windows.Forms.TextBox();
            this.dgvPlano = new System.Windows.Forms.DataGridView();
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
            this.vte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorVte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codH1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descH1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codH2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descH2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codH3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descH3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codH4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descH4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codH5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descH5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlano)).BeginInit();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSolicitudColor
            // 
            this.pnlSolicitudColor.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlSolicitudColor.Controls.Add(this.cbxTipoTejido);
            this.pnlSolicitudColor.Controls.Add(this.lbTipoTejido);
            this.pnlSolicitudColor.Controls.Add(this.txbNomTela);
            this.pnlSolicitudColor.Controls.Add(this.lbReferenciaTela);
            this.pnlSolicitudColor.Controls.Add(this.lbNombreTela);
            this.pnlSolicitudColor.Controls.Add(this.cbxSiCoordinado);
            this.pnlSolicitudColor.Controls.Add(this.cbxNoCoordinado);
            this.pnlSolicitudColor.Controls.Add(this.lbCoordinado);
            this.pnlSolicitudColor.Controls.Add(this.txbCoordinaCon);
            this.pnlSolicitudColor.Controls.Add(this.lbCoordinaCon);
            this.pnlSolicitudColor.Controls.Add(this.txbRefTela);
            this.pnlSolicitudColor.Location = new System.Drawing.Point(12, 145);
            this.pnlSolicitudColor.Name = "pnlSolicitudColor";
            this.pnlSolicitudColor.Size = new System.Drawing.Size(1359, 77);
            this.pnlSolicitudColor.TabIndex = 23;
            // 
            // cbxTipoTejido
            // 
            this.cbxTipoTejido.FormattingEnabled = true;
            this.cbxTipoTejido.Items.AddRange(new object[] {
            "PLANO",
            "PUNTO",
            "PRETEÑIDO"});
            this.cbxTipoTejido.Location = new System.Drawing.Point(169, 42);
            this.cbxTipoTejido.Name = "cbxTipoTejido";
            this.cbxTipoTejido.Size = new System.Drawing.Size(211, 21);
            this.cbxTipoTejido.TabIndex = 16;
            // 
            // lbTipoTejido
            // 
            this.lbTipoTejido.AutoSize = true;
            this.lbTipoTejido.Location = new System.Drawing.Point(26, 45);
            this.lbTipoTejido.Name = "lbTipoTejido";
            this.lbTipoTejido.Size = new System.Drawing.Size(74, 13);
            this.lbTipoTejido.TabIndex = 15;
            this.lbTipoTejido.Text = "Tipo Tejido:";
            // 
            // txbNomTela
            // 
            this.txbNomTela.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txbNomTela.Location = new System.Drawing.Point(546, 10);
            this.txbNomTela.Name = "txbNomTela";
            this.txbNomTela.ReadOnly = true;
            this.txbNomTela.Size = new System.Drawing.Size(211, 20);
            this.txbNomTela.TabIndex = 9;
            // 
            // lbReferenciaTela
            // 
            this.lbReferenciaTela.AutoSize = true;
            this.lbReferenciaTela.Location = new System.Drawing.Point(25, 15);
            this.lbReferenciaTela.Name = "lbReferenciaTela";
            this.lbReferenciaTela.Size = new System.Drawing.Size(100, 13);
            this.lbReferenciaTela.TabIndex = 3;
            this.lbReferenciaTela.Text = "Referencia Tela:";
            // 
            // lbNombreTela
            // 
            this.lbNombreTela.AutoSize = true;
            this.lbNombreTela.Location = new System.Drawing.Point(401, 16);
            this.lbNombreTela.Name = "lbNombreTela";
            this.lbNombreTela.Size = new System.Drawing.Size(102, 13);
            this.lbNombreTela.TabIndex = 4;
            this.lbNombreTela.Text = "Nombre de Tela:";
            // 
            // cbxSiCoordinado
            // 
            this.cbxSiCoordinado.AutoSize = true;
            this.cbxSiCoordinado.Location = new System.Drawing.Point(965, 13);
            this.cbxSiCoordinado.Name = "cbxSiCoordinado";
            this.cbxSiCoordinado.Size = new System.Drawing.Size(37, 17);
            this.cbxSiCoordinado.TabIndex = 13;
            this.cbxSiCoordinado.Text = "Si";
            this.cbxSiCoordinado.UseVisualStyleBackColor = true;
            this.cbxSiCoordinado.CheckedChanged += new System.EventHandler(this.cbxSiCoordinado_CheckedChanged);
            // 
            // cbxNoCoordinado
            // 
            this.cbxNoCoordinado.AutoSize = true;
            this.cbxNoCoordinado.Location = new System.Drawing.Point(894, 12);
            this.cbxNoCoordinado.Name = "cbxNoCoordinado";
            this.cbxNoCoordinado.Size = new System.Drawing.Size(41, 17);
            this.cbxNoCoordinado.TabIndex = 12;
            this.cbxNoCoordinado.Text = "No";
            this.cbxNoCoordinado.UseVisualStyleBackColor = true;
            this.cbxNoCoordinado.CheckedChanged += new System.EventHandler(this.cbxNoCoordinado_CheckedChanged);
            // 
            // lbCoordinado
            // 
            this.lbCoordinado.AutoSize = true;
            this.lbCoordinado.Location = new System.Drawing.Point(777, 14);
            this.lbCoordinado.Name = "lbCoordinado";
            this.lbCoordinado.Size = new System.Drawing.Size(78, 13);
            this.lbCoordinado.TabIndex = 6;
            this.lbCoordinado.Text = "Coordinado:";
            // 
            // txbCoordinaCon
            // 
            this.txbCoordinaCon.Location = new System.Drawing.Point(1129, 11);
            this.txbCoordinaCon.Name = "txbCoordinaCon";
            this.txbCoordinaCon.Size = new System.Drawing.Size(211, 20);
            this.txbCoordinaCon.TabIndex = 11;
            this.txbCoordinaCon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCoordinaCon_KeyPress);
            // 
            // lbCoordinaCon
            // 
            this.lbCoordinaCon.AutoSize = true;
            this.lbCoordinaCon.Location = new System.Drawing.Point(1016, 14);
            this.lbCoordinaCon.Name = "lbCoordinaCon";
            this.lbCoordinaCon.Size = new System.Drawing.Size(88, 13);
            this.lbCoordinaCon.TabIndex = 7;
            this.lbCoordinaCon.Text = "Coordina con:";
            // 
            // txbRefTela
            // 
            this.txbRefTela.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txbRefTela.Location = new System.Drawing.Point(169, 12);
            this.txbRefTela.Name = "txbRefTela";
            this.txbRefTela.ReadOnly = true;
            this.txbRefTela.Size = new System.Drawing.Size(211, 20);
            this.txbRefTela.TabIndex = 8;
            // 
            // dgvPlano
            // 
            this.dgvPlano.AllowUserToAddRows = false;
            this.dgvPlano.AllowUserToDeleteRows = false;
            this.dgvPlano.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlano.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvPlano.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlano.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPlano.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlano.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vte,
            this.colorVte,
            this.codH1,
            this.descH1,
            this.codH2,
            this.descH2,
            this.codH3,
            this.descH3,
            this.codH4,
            this.descH4,
            this.codH5,
            this.descH5,
            this.tiendas,
            this.exito,
            this.cencosud,
            this.sao,
            this.comercioOrg,
            this.rosado,
            this.otros,
            this.totalUnidades,
            this.eliminar});
            this.dgvPlano.EnableHeadersVisualStyles = false;
            this.dgvPlano.Location = new System.Drawing.Point(14, 327);
            this.dgvPlano.MultiSelect = false;
            this.dgvPlano.Name = "dgvPlano";
            this.dgvPlano.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvPlano.RowHeadersVisible = false;
            this.dgvPlano.RowHeadersWidth = 62;
            this.dgvPlano.RowTemplate.Height = 28;
            this.dgvPlano.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPlano.Size = new System.Drawing.Size(1357, 280);
            this.dgvPlano.TabIndex = 29;
            this.dgvPlano.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlano_CellClick);
            this.dgvPlano.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlano_CellContentClick);
            this.dgvPlano.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlano_CellEndEdit);
            this.dgvPlano.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvPlano_CellPainting);
            this.dgvPlano.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvPlano_KeyPress);
            // 
            // lbObservaciones
            // 
            this.lbObservaciones.AutoSize = true;
            this.lbObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbObservaciones.Location = new System.Drawing.Point(14, 642);
            this.lbObservaciones.Name = "lbObservaciones";
            this.lbObservaciones.Size = new System.Drawing.Size(136, 15);
            this.lbObservaciones.TabIndex = 31;
            this.lbObservaciones.Text = "Observaciones Diseño";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(14, 680);
            this.txtObservaciones.MaxLength = 120;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(1357, 96);
            this.txtObservaciones.TabIndex = 30;
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
            this.panel9.Location = new System.Drawing.Point(11, 77);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1360, 47);
            this.panel9.TabIndex = 133;
            // 
            // lblConsecutivo
            // 
            this.lblConsecutivo.AutoSize = true;
            this.lblConsecutivo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsecutivo.Location = new System.Drawing.Point(545, 15);
            this.lblConsecutivo.Name = "lblConsecutivo";
            this.lblConsecutivo.Size = new System.Drawing.Size(0, 16);
            this.lblConsecutivo.TabIndex = 98;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Image = global::PedidoTela.Formularios.Properties.Resources.confirmar1;
            this.btnConfirmar.Location = new System.Drawing.Point(126, 1);
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
            this.btnGrabar.Location = new System.Drawing.Point(2, 1);
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
            this.btnSalir.Location = new System.Drawing.Point(251, 1);
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
            this.btnAddColor.Location = new System.Drawing.Point(11, 238);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(181, 50);
            this.btnAddColor.TabIndex = 128;
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
            this.lbIdentificador.Location = new System.Drawing.Point(212, 34);
            this.lbIdentificador.Name = "lbIdentificador";
            this.lbIdentificador.Size = new System.Drawing.Size(15, 18);
            this.lbIdentificador.TabIndex = 136;
            this.lbIdentificador.Text = "-";
            // 
            // lbSolicitud
            // 
            this.lbSolicitud.AutoSize = true;
            this.lbSolicitud.BackColor = System.Drawing.SystemColors.Window;
            this.lbSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbSolicitud.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSolicitud.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbSolicitud.Location = new System.Drawing.Point(625, 251);
            this.lbSolicitud.Name = "lbSolicitud";
            this.lbSolicitud.Size = new System.Drawing.Size(228, 19);
            this.lbSolicitud.TabIndex = 150;
            this.lbSolicitud.Text = "SOLICITUD PLANO PRETEÑIDO";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.Image = global::PedidoTela.Formularios.Properties.Resources.seleccion4;
            this.pictureBox1.Location = new System.Drawing.Point(598, 246);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 33);
            this.pictureBox1.TabIndex = 151;
            this.pictureBox1.TabStop = false;
            // 
            // vte
            // 
            this.vte.HeaderText = "Vte";
            this.vte.MinimumWidth = 8;
            this.vte.Name = "vte";
            this.vte.ReadOnly = true;
            // 
            // colorVte
            // 
            this.colorVte.HeaderText = "Color Vte";
            this.colorVte.MinimumWidth = 8;
            this.colorVte.Name = "colorVte";
            this.colorVte.ReadOnly = true;
            this.colorVte.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // codH1
            // 
            this.codH1.HeaderText = "Cod H1";
            this.codH1.MinimumWidth = 8;
            this.codH1.Name = "codH1";
            this.codH1.ReadOnly = true;
            // 
            // descH1
            // 
            this.descH1.HeaderText = "Desc H1";
            this.descH1.MinimumWidth = 8;
            this.descH1.Name = "descH1";
            this.descH1.ReadOnly = true;
            // 
            // codH2
            // 
            this.codH2.HeaderText = "Cod H2";
            this.codH2.MinimumWidth = 8;
            this.codH2.Name = "codH2";
            this.codH2.ReadOnly = true;
            // 
            // descH2
            // 
            this.descH2.HeaderText = "Desc H2";
            this.descH2.MinimumWidth = 8;
            this.descH2.Name = "descH2";
            this.descH2.ReadOnly = true;
            // 
            // codH3
            // 
            this.codH3.HeaderText = "Cod H3";
            this.codH3.MinimumWidth = 8;
            this.codH3.Name = "codH3";
            this.codH3.ReadOnly = true;
            // 
            // descH3
            // 
            this.descH3.HeaderText = "Desc H3";
            this.descH3.MinimumWidth = 8;
            this.descH3.Name = "descH3";
            this.descH3.ReadOnly = true;
            // 
            // codH4
            // 
            this.codH4.HeaderText = "Cod H4";
            this.codH4.MinimumWidth = 8;
            this.codH4.Name = "codH4";
            this.codH4.ReadOnly = true;
            // 
            // descH4
            // 
            this.descH4.HeaderText = "Desc H4";
            this.descH4.MinimumWidth = 8;
            this.descH4.Name = "descH4";
            this.descH4.ReadOnly = true;
            // 
            // codH5
            // 
            this.codH5.HeaderText = "Cod H5";
            this.codH5.MinimumWidth = 8;
            this.codH5.Name = "codH5";
            this.codH5.ReadOnly = true;
            // 
            // descH5
            // 
            this.descH5.HeaderText = "Desc H5";
            this.descH5.MinimumWidth = 8;
            this.descH5.Name = "descH5";
            this.descH5.ReadOnly = true;
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
            // frmSolicitudPlanoPretenido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 788);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbSolicitud);
            this.Controls.Add(this.lbIdentificador);
            this.Controls.Add(this.btnAddColor);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.lbObservaciones);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.dgvPlano);
            this.Controls.Add(this.pnlSolicitudColor);
            this.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmSolicitudPlanoPretenido";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitud Plano/Preteñido";
            this.Load += new System.EventHandler(this.frmSolicitudPlanoPretenido_Load);
            this.pnlSolicitudColor.ResumeLayout(false);
            this.pnlSolicitudColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlano)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel pnlSolicitudColor;
        private System.Windows.Forms.TextBox txbNomTela;
        private System.Windows.Forms.Label lbReferenciaTela;
        private System.Windows.Forms.Label lbNombreTela;
        private System.Windows.Forms.CheckBox cbxSiCoordinado;
        private System.Windows.Forms.CheckBox cbxNoCoordinado;
        private System.Windows.Forms.Label lbCoordinado;
        private System.Windows.Forms.TextBox txbCoordinaCon;
        private System.Windows.Forms.Label lbCoordinaCon;
        private System.Windows.Forms.TextBox txbRefTela;
        private System.Windows.Forms.DataGridView dgvPlano;
        private System.Windows.Forms.Label lbObservaciones;
        private System.Windows.Forms.RichTextBox txtObservaciones;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAddColor;
        private System.Windows.Forms.Label lblConsecutivo;
        private System.Windows.Forms.Label lbIdentificador;
        private System.Windows.Forms.Label lbSolicitud;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbxTipoTejido;
        private System.Windows.Forms.Label lbTipoTejido;
        private System.Windows.Forms.DataGridViewTextBoxColumn vte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorVte;
        private System.Windows.Forms.DataGridViewTextBoxColumn codH1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descH1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codH2;
        private System.Windows.Forms.DataGridViewTextBoxColumn descH2;
        private System.Windows.Forms.DataGridViewTextBoxColumn codH3;
        private System.Windows.Forms.DataGridViewTextBoxColumn descH3;
        private System.Windows.Forms.DataGridViewTextBoxColumn codH4;
        private System.Windows.Forms.DataGridViewTextBoxColumn descH4;
        private System.Windows.Forms.DataGridViewTextBoxColumn codH5;
        private System.Windows.Forms.DataGridViewTextBoxColumn descH5;
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