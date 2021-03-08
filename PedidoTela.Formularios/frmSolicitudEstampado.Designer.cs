
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSolicitudColor = new System.Windows.Forms.Panel();
            this.cbxTipoTela = new System.Windows.Forms.ComboBox();
            this.cbxTipoEst = new System.Windows.Forms.ComboBox();
            this.lbTipoTela = new System.Windows.Forms.Label();
            this.txbNomTela = new System.Windows.Forms.TextBox();
            this.txbNcilindro = new System.Windows.Forms.TextBox();
            this.lbNumeroCilindros = new System.Windows.Forms.Label();
            this.txbCoordinaCon = new System.Windows.Forms.TextBox();
            this.txbNdibujo = new System.Windows.Forms.TextBox();
            this.lbCoordinaCon = new System.Windows.Forms.Label();
            this.lbCoordinado = new System.Windows.Forms.Label();
            this.cbxSiCoordinado = new System.Windows.Forms.CheckBox();
            this.cbxNoCoordinado = new System.Windows.Forms.CheckBox();
            this.lbNDibujos = new System.Windows.Forms.Label();
            this.lbReferenciaTela = new System.Windows.Forms.Label();
            this.lbNombreTela = new System.Windows.Forms.Label();
            this.lbTipoestampado = new System.Windows.Forms.Label();
            this.txbRefTela = new System.Windows.Forms.TextBox();
            this.dvgEstampado = new System.Windows.Forms.DataGridView();
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
            this.lbObservaciones = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.RichTextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAddColor = new System.Windows.Forms.Button();
            this.lbIdentificador = new System.Windows.Forms.Label();
            this.pnlSolicitudColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEstampado)).BeginInit();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSolicitudColor
            // 
            this.pnlSolicitudColor.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlSolicitudColor.Controls.Add(this.cbxTipoTela);
            this.pnlSolicitudColor.Controls.Add(this.cbxTipoEst);
            this.pnlSolicitudColor.Controls.Add(this.lbTipoTela);
            this.pnlSolicitudColor.Controls.Add(this.txbNomTela);
            this.pnlSolicitudColor.Controls.Add(this.txbNcilindro);
            this.pnlSolicitudColor.Controls.Add(this.lbNumeroCilindros);
            this.pnlSolicitudColor.Controls.Add(this.txbCoordinaCon);
            this.pnlSolicitudColor.Controls.Add(this.txbNdibujo);
            this.pnlSolicitudColor.Controls.Add(this.lbCoordinaCon);
            this.pnlSolicitudColor.Controls.Add(this.lbCoordinado);
            this.pnlSolicitudColor.Controls.Add(this.cbxSiCoordinado);
            this.pnlSolicitudColor.Controls.Add(this.cbxNoCoordinado);
            this.pnlSolicitudColor.Controls.Add(this.lbNDibujos);
            this.pnlSolicitudColor.Controls.Add(this.lbReferenciaTela);
            this.pnlSolicitudColor.Controls.Add(this.lbNombreTela);
            this.pnlSolicitudColor.Controls.Add(this.lbTipoestampado);
            this.pnlSolicitudColor.Controls.Add(this.txbRefTela);
            this.pnlSolicitudColor.Location = new System.Drawing.Point(15, 149);
            this.pnlSolicitudColor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSolicitudColor.Name = "pnlSolicitudColor";
            this.pnlSolicitudColor.Size = new System.Drawing.Size(1461, 107);
            this.pnlSolicitudColor.TabIndex = 22;
            // 
            // cbxTipoTela
            // 
            this.cbxTipoTela.FormattingEnabled = true;
            this.cbxTipoTela.Location = new System.Drawing.Point(569, 66);
            this.cbxTipoTela.Name = "cbxTipoTela";
            this.cbxTipoTela.Size = new System.Drawing.Size(267, 24);
            this.cbxTipoTela.TabIndex = 22;
            // 
            // cbxTipoEst
            // 
            this.cbxTipoEst.FormattingEnabled = true;
            this.cbxTipoEst.Items.AddRange(new object[] {
            "ROTATIVO",
            "DIGITAL"});
            this.cbxTipoEst.Location = new System.Drawing.Point(569, 20);
            this.cbxTipoEst.Name = "cbxTipoEst";
            this.cbxTipoEst.Size = new System.Drawing.Size(267, 24);
            this.cbxTipoEst.TabIndex = 21;
            // 
            // lbTipoTela
            // 
            this.lbTipoTela.AutoSize = true;
            this.lbTipoTela.Location = new System.Drawing.Point(435, 69);
            this.lbTipoTela.Name = "lbTipoTela";
            this.lbTipoTela.Size = new System.Drawing.Size(112, 17);
            this.lbTipoTela.TabIndex = 19;
            this.lbTipoTela.Text = "Tipo de Tejido:";
            // 
            // txbNomTela
            // 
            this.txbNomTela.BackColor = System.Drawing.SystemColors.Window;
            this.txbNomTela.Location = new System.Drawing.Point(144, 63);
            this.txbNomTela.Name = "txbNomTela";
            this.txbNomTela.ReadOnly = true;
            this.txbNomTela.Size = new System.Drawing.Size(268, 23);
            this.txbNomTela.TabIndex = 18;
            // 
            // txbNcilindro
            // 
            this.txbNcilindro.Location = new System.Drawing.Point(1185, 24);
            this.txbNcilindro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbNcilindro.Name = "txbNcilindro";
            this.txbNcilindro.Size = new System.Drawing.Size(77, 23);
            this.txbNcilindro.TabIndex = 17;
            this.txbNcilindro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbNcilindro_KeyPress);
            // 
            // lbNumeroCilindros
            // 
            this.lbNumeroCilindros.AutoSize = true;
            this.lbNumeroCilindros.Location = new System.Drawing.Point(1072, 24);
            this.lbNumeroCilindros.Name = "lbNumeroCilindros";
            this.lbNumeroCilindros.Size = new System.Drawing.Size(89, 17);
            this.lbNumeroCilindros.TabIndex = 16;
            this.lbNumeroCilindros.Text = "N° Cilindro:";
            // 
            // txbCoordinaCon
            // 
            this.txbCoordinaCon.BackColor = System.Drawing.SystemColors.Window;
            this.txbCoordinaCon.Location = new System.Drawing.Point(1185, 69);
            this.txbCoordinaCon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbCoordinaCon.Name = "txbCoordinaCon";
            this.txbCoordinaCon.ReadOnly = true;
            this.txbCoordinaCon.Size = new System.Drawing.Size(268, 23);
            this.txbCoordinaCon.TabIndex = 11;
            // 
            // txbNdibujo
            // 
            this.txbNdibujo.Location = new System.Drawing.Point(967, 22);
            this.txbNdibujo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbNdibujo.Name = "txbNdibujo";
            this.txbNdibujo.Size = new System.Drawing.Size(79, 23);
            this.txbNdibujo.TabIndex = 15;
            this.txbNdibujo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbNdibujo_KeyPress);
            // 
            // lbCoordinaCon
            // 
            this.lbCoordinaCon.AutoSize = true;
            this.lbCoordinaCon.Location = new System.Drawing.Point(1072, 71);
            this.lbCoordinaCon.Name = "lbCoordinaCon";
            this.lbCoordinaCon.Size = new System.Drawing.Size(107, 17);
            this.lbCoordinaCon.TabIndex = 7;
            this.lbCoordinaCon.Text = "Coordina con:";
            // 
            // lbCoordinado
            // 
            this.lbCoordinado.AutoSize = true;
            this.lbCoordinado.Location = new System.Drawing.Point(857, 70);
            this.lbCoordinado.Name = "lbCoordinado";
            this.lbCoordinado.Size = new System.Drawing.Size(95, 17);
            this.lbCoordinado.TabIndex = 6;
            this.lbCoordinado.Text = "Coordinado:";
            // 
            // cbxSiCoordinado
            // 
            this.cbxSiCoordinado.AutoSize = true;
            this.cbxSiCoordinado.Location = new System.Drawing.Point(1023, 71);
            this.cbxSiCoordinado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxSiCoordinado.Name = "cbxSiCoordinado";
            this.cbxSiCoordinado.Size = new System.Drawing.Size(43, 21);
            this.cbxSiCoordinado.TabIndex = 13;
            this.cbxSiCoordinado.Text = "Si";
            this.cbxSiCoordinado.UseVisualStyleBackColor = true;
            this.cbxSiCoordinado.CheckedChanged += new System.EventHandler(this.cbxSiCoordinadoEst_CheckedChanged);
            // 
            // cbxNoCoordinado
            // 
            this.cbxNoCoordinado.AutoSize = true;
            this.cbxNoCoordinado.Location = new System.Drawing.Point(968, 71);
            this.cbxNoCoordinado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxNoCoordinado.Name = "cbxNoCoordinado";
            this.cbxNoCoordinado.Size = new System.Drawing.Size(49, 21);
            this.cbxNoCoordinado.TabIndex = 12;
            this.cbxNoCoordinado.Text = "No";
            this.cbxNoCoordinado.UseVisualStyleBackColor = true;
            this.cbxNoCoordinado.CheckedChanged += new System.EventHandler(this.cbxNoCoordinadoEst_CheckedChanged);
            // 
            // lbNDibujos
            // 
            this.lbNDibujos.AutoSize = true;
            this.lbNDibujos.Location = new System.Drawing.Point(854, 24);
            this.lbNDibujos.Name = "lbNDibujos";
            this.lbNDibujos.Size = new System.Drawing.Size(91, 17);
            this.lbNDibujos.TabIndex = 14;
            this.lbNDibujos.Text = "N° Dibujos:";
            // 
            // lbReferenciaTela
            // 
            this.lbReferenciaTela.AutoSize = true;
            this.lbReferenciaTela.Location = new System.Drawing.Point(14, 21);
            this.lbReferenciaTela.Name = "lbReferenciaTela";
            this.lbReferenciaTela.Size = new System.Drawing.Size(117, 17);
            this.lbReferenciaTela.TabIndex = 3;
            this.lbReferenciaTela.Text = "Referencia Tela:";
            // 
            // lbNombreTela
            // 
            this.lbNombreTela.AutoSize = true;
            this.lbNombreTela.Location = new System.Drawing.Point(13, 67);
            this.lbNombreTela.Name = "lbNombreTela";
            this.lbNombreTela.Size = new System.Drawing.Size(122, 17);
            this.lbNombreTela.TabIndex = 4;
            this.lbNombreTela.Text = "Nombre de Tela:";
            // 
            // lbTipoestampado
            // 
            this.lbTipoestampado.AutoSize = true;
            this.lbTipoestampado.Location = new System.Drawing.Point(435, 24);
            this.lbTipoestampado.Name = "lbTipoestampado";
            this.lbTipoestampado.Size = new System.Drawing.Size(128, 17);
            this.lbTipoestampado.TabIndex = 5;
            this.lbTipoestampado.Text = "Tipo Estampado:";
            // 
            // txbRefTela
            // 
            this.txbRefTela.BackColor = System.Drawing.SystemColors.Window;
            this.txbRefTela.Location = new System.Drawing.Point(145, 18);
            this.txbRefTela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbRefTela.Name = "txbRefTela";
            this.txbRefTela.ReadOnly = true;
            this.txbRefTela.Size = new System.Drawing.Size(267, 23);
            this.txbRefTela.TabIndex = 8;
            // 
            // dvgEstampado
            // 
            this.dvgEstampado.AllowUserToAddRows = false;
            this.dvgEstampado.AllowUserToDeleteRows = false;
            this.dvgEstampado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dvgEstampado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dvgEstampado.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgEstampado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.totalUnidades});
            this.dvgEstampado.EnableHeadersVisualStyles = false;
            this.dvgEstampado.Location = new System.Drawing.Point(15, 355);
            this.dvgEstampado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dvgEstampado.MultiSelect = false;
            this.dvgEstampado.Name = "dvgEstampado";
            this.dvgEstampado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dvgEstampado.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dvgEstampado.RowHeadersWidth = 62;
            this.dvgEstampado.RowTemplate.Height = 28;
            this.dvgEstampado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dvgEstampado.Size = new System.Drawing.Size(1461, 310);
            this.dvgEstampado.TabIndex = 27;
            this.dvgEstampado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgEstampado_CellClick);
            this.dvgEstampado.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgEstampado_CellEndEdit);
            this.dvgEstampado.SelectionChanged += new System.EventHandler(this.dvgEstampado_SelectionChanged);
            // 
            // codColor
            // 
            this.codColor.HeaderText = "Cod Color";
            this.codColor.MinimumWidth = 8;
            this.codColor.Name = "codColor";
            // 
            // descripColor
            // 
            this.descripColor.HeaderText = "Descripción Color";
            this.descripColor.MinimumWidth = 8;
            this.descripColor.Name = "descripColor";
            // 
            // fondo
            // 
            this.fondo.HeaderText = "Fondo";
            this.fondo.MinimumWidth = 8;
            this.fondo.Name = "fondo";
            // 
            // descripcionFondo
            // 
            this.descripcionFondo.HeaderText = "Descripción Fondo";
            this.descripcionFondo.MinimumWidth = 8;
            this.descripcionFondo.Name = "descripcionFondo";
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
            // lbObservaciones
            // 
            this.lbObservaciones.AutoSize = true;
            this.lbObservaciones.Location = new System.Drawing.Point(15, 683);
            this.lbObservaciones.Name = "lbObservaciones";
            this.lbObservaciones.Size = new System.Drawing.Size(163, 17);
            this.lbObservaciones.TabIndex = 29;
            this.lbObservaciones.Text = "Observaciones Diseño";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(14, 702);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(1462, 76);
            this.txtObservaciones.TabIndex = 28;
            this.txtObservaciones.Text = "";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.lbIdentificador);
            this.panel9.Controls.Add(this.btnConfirmar);
            this.panel9.Controls.Add(this.btnGrabar);
            this.panel9.Controls.Add(this.btnSalir);
            this.panel9.Location = new System.Drawing.Point(15, 86);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1461, 56);
            this.panel9.TabIndex = 134;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Image = global::PedidoTela.Formularios.Properties.Resources._1492790860_8check_84164;
            this.btnConfirmar.Location = new System.Drawing.Point(173, 2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(174, 50);
            this.btnConfirmar.TabIndex = 96;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.LightGray;
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGrabar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = global::PedidoTela.Formularios.Properties.Resources.record_icon_icons_com_64775__1_;
            this.btnGrabar.Location = new System.Drawing.Point(2, 2);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(174, 50);
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
            this.btnSalir.Image = global::PedidoTela.Formularios.Properties.Resources.logout_exit_icon_176185;
            this.btnSalir.Location = new System.Drawing.Point(343, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(174, 50);
            this.btnSalir.TabIndex = 97;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAddColor
            // 
            this.btnAddColor.Image = global::PedidoTela.Formularios.Properties.Resources._1492790881_6add_84227;
            this.btnAddColor.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddColor.Location = new System.Drawing.Point(15, 272);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(303, 69);
            this.btnAddColor.TabIndex = 129;
            this.btnAddColor.Text = "Adicionar Color";
            this.btnAddColor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddColor.UseVisualStyleBackColor = true;
            this.btnAddColor.Click += new System.EventHandler(this.btnAddColor_Click);
            // 
            // lbIdentificador
            // 
            this.lbIdentificador.AutoSize = true;
            this.lbIdentificador.BackColor = System.Drawing.Color.White;
            this.lbIdentificador.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIdentificador.Location = new System.Drawing.Point(1280, 2);
            this.lbIdentificador.Name = "lbIdentificador";
            this.lbIdentificador.Size = new System.Drawing.Size(15, 17);
            this.lbIdentificador.TabIndex = 98;
            this.lbIdentificador.Text = "-";
            // 
            // frmSolicitudEstampado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1488, 803);
            this.Controls.Add(this.btnAddColor);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.lbObservaciones);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.dvgEstampado);
            this.Controls.Add(this.pnlSolicitudColor);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimizeBox = false;
            this.Name = "frmSolicitudEstampado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitud Estampado";
            this.Load += new System.EventHandler(this.frmSolicitudEstampado_Load);
            this.pnlSolicitudColor.ResumeLayout(false);
            this.pnlSolicitudColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dvgEstampado)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
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
        private System.Windows.Forms.Label lbIdentificador;
    }
}