
namespace PedidoTela.Formularios
{
    partial class frmSolicitudUnicolor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbReferenciaTela = new System.Windows.Forms.Label();
            this.lbNombreTela = new System.Windows.Forms.Label();
            this.lbTipoTejido = new System.Windows.Forms.Label();
            this.lbCoordinado = new System.Windows.Forms.Label();
            this.lbCoordinaCon = new System.Windows.Forms.Label();
            this.txbRefTela = new System.Windows.Forms.TextBox();
            this.txbNomTela = new System.Windows.Forms.TextBox();
            this.txbTipoTejido = new System.Windows.Forms.TextBox();
            this.txbCoordinaCon = new System.Windows.Forms.TextBox();
            this.cbxNoCoordinado = new System.Windows.Forms.CheckBox();
            this.cbxSiCoordinado = new System.Windows.Forms.CheckBox();
            this.dgvUnicolor = new System.Windows.Forms.DataGridView();
            this.codColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiendas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comercioOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rosado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalUnidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eliminar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSolicitudColor = new System.Windows.Forms.Panel();
            this.txbObservaciones = new System.Windows.Forms.RichTextBox();
            this.lbObservaciones = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.lblConsecutivo = new System.Windows.Forms.Label();
            this.lbIdentificador = new System.Windows.Forms.Label();
            this.btnAddColor = new System.Windows.Forms.Button();
            this.lbSolicitud = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnicolor)).BeginInit();
            this.pnlSolicitudColor.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbReferenciaTela
            // 
            this.lbReferenciaTela.AutoSize = true;
            this.lbReferenciaTela.Location = new System.Drawing.Point(26, 26);
            this.lbReferenciaTela.Name = "lbReferenciaTela";
            this.lbReferenciaTela.Size = new System.Drawing.Size(117, 17);
            this.lbReferenciaTela.TabIndex = 3;
            this.lbReferenciaTela.Text = "Referencia Tela:";
            // 
            // lbNombreTela
            // 
            this.lbNombreTela.AutoSize = true;
            this.lbNombreTela.Location = new System.Drawing.Point(442, 29);
            this.lbNombreTela.Name = "lbNombreTela";
            this.lbNombreTela.Size = new System.Drawing.Size(122, 17);
            this.lbNombreTela.TabIndex = 4;
            this.lbNombreTela.Text = "Nombre de Tela:";
            // 
            // lbTipoTejido
            // 
            this.lbTipoTejido.AutoSize = true;
            this.lbTipoTejido.Location = new System.Drawing.Point(923, 27);
            this.lbTipoTejido.Name = "lbTipoTejido";
            this.lbTipoTejido.Size = new System.Drawing.Size(90, 17);
            this.lbTipoTejido.TabIndex = 5;
            this.lbTipoTejido.Text = "Tipo Tejido:";
            // 
            // lbCoordinado
            // 
            this.lbCoordinado.AutoSize = true;
            this.lbCoordinado.Location = new System.Drawing.Point(26, 76);
            this.lbCoordinado.Name = "lbCoordinado";
            this.lbCoordinado.Size = new System.Drawing.Size(95, 17);
            this.lbCoordinado.TabIndex = 6;
            this.lbCoordinado.Text = "Coordinado:";
            // 
            // lbCoordinaCon
            // 
            this.lbCoordinaCon.AutoSize = true;
            this.lbCoordinaCon.Location = new System.Drawing.Point(442, 76);
            this.lbCoordinaCon.Name = "lbCoordinaCon";
            this.lbCoordinaCon.Size = new System.Drawing.Size(107, 17);
            this.lbCoordinaCon.TabIndex = 7;
            this.lbCoordinaCon.Text = "Coordina con:";
            // 
            // txbRefTela
            // 
            this.txbRefTela.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txbRefTela.ForeColor = System.Drawing.Color.Black;
            this.txbRefTela.Location = new System.Drawing.Point(154, 23);
            this.txbRefTela.Name = "txbRefTela";
            this.txbRefTela.ReadOnly = true;
            this.txbRefTela.Size = new System.Drawing.Size(272, 24);
            this.txbRefTela.TabIndex = 8;
            // 
            // txbNomTela
            // 
            this.txbNomTela.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txbNomTela.ForeColor = System.Drawing.Color.Black;
            this.txbNomTela.Location = new System.Drawing.Point(587, 24);
            this.txbNomTela.Name = "txbNomTela";
            this.txbNomTela.ReadOnly = true;
            this.txbNomTela.Size = new System.Drawing.Size(276, 24);
            this.txbNomTela.TabIndex = 9;
            // 
            // txbTipoTejido
            // 
            this.txbTipoTejido.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txbTipoTejido.ForeColor = System.Drawing.Color.Black;
            this.txbTipoTejido.Location = new System.Drawing.Point(1078, 22);
            this.txbTipoTejido.Name = "txbTipoTejido";
            this.txbTipoTejido.ReadOnly = true;
            this.txbTipoTejido.Size = new System.Drawing.Size(271, 24);
            this.txbTipoTejido.TabIndex = 10;
            // 
            // txbCoordinaCon
            // 
            this.txbCoordinaCon.Location = new System.Drawing.Point(587, 69);
            this.txbCoordinaCon.Name = "txbCoordinaCon";
            this.txbCoordinaCon.Size = new System.Drawing.Size(276, 24);
            this.txbCoordinaCon.TabIndex = 11;
            this.txbCoordinaCon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbCoordinaCon_KeyPress);
            // 
            // cbxNoCoordinado
            // 
            this.cbxNoCoordinado.AutoSize = true;
            this.cbxNoCoordinado.Location = new System.Drawing.Point(155, 75);
            this.cbxNoCoordinado.Name = "cbxNoCoordinado";
            this.cbxNoCoordinado.Size = new System.Drawing.Size(49, 21);
            this.cbxNoCoordinado.TabIndex = 12;
            this.cbxNoCoordinado.Text = "No";
            this.cbxNoCoordinado.UseVisualStyleBackColor = true;
            this.cbxNoCoordinado.CheckedChanged += new System.EventHandler(this.cbxNoCoordinado_CheckedChanged);
            // 
            // cbxSiCoordinado
            // 
            this.cbxSiCoordinado.AutoSize = true;
            this.cbxSiCoordinado.Location = new System.Drawing.Point(210, 76);
            this.cbxSiCoordinado.Name = "cbxSiCoordinado";
            this.cbxSiCoordinado.Size = new System.Drawing.Size(43, 21);
            this.cbxSiCoordinado.TabIndex = 13;
            this.cbxSiCoordinado.Text = "Si";
            this.cbxSiCoordinado.UseVisualStyleBackColor = true;
            this.cbxSiCoordinado.CheckedChanged += new System.EventHandler(this.cbxSiCoordinado_CheckedChanged);
            // 
            // dgvUnicolor
            // 
            this.dgvUnicolor.AllowUserToAddRows = false;
            this.dgvUnicolor.AllowUserToDeleteRows = false;
            this.dgvUnicolor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnicolor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvUnicolor.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUnicolor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvUnicolor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnicolor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codColor,
            this.descripColor,
            this.tiendas,
            this.exito,
            this.cencosud,
            this.sao,
            this.comercioOrg,
            this.rosado,
            this.otros,
            this.totalUnidades,
            this.eliminar});
            this.dgvUnicolor.EnableHeadersVisualStyles = false;
            this.dgvUnicolor.Location = new System.Drawing.Point(13, 375);
            this.dgvUnicolor.MultiSelect = false;
            this.dgvUnicolor.Name = "dgvUnicolor";
            this.dgvUnicolor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvUnicolor.RowHeadersWidth = 62;
            this.dgvUnicolor.RowTemplate.Height = 28;
            this.dgvUnicolor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvUnicolor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvUnicolor.Size = new System.Drawing.Size(1361, 281);
            this.dgvUnicolor.TabIndex = 20;
            this.dgvUnicolor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnicolor_CellClick);
            this.dgvUnicolor.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUnicolor_CellEndEdit);
            this.dgvUnicolor.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvUnicolor_CellPainting);
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
            this.totalUnidades.ReadOnly = true;
            // 
            // eliminar
            // 
            this.eliminar.HeaderText = "Eliminar";
            this.eliminar.MinimumWidth = 6;
            this.eliminar.Name = "eliminar";
            // 
            // pnlSolicitudColor
            // 
            this.pnlSolicitudColor.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlSolicitudColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSolicitudColor.Controls.Add(this.txbNomTela);
            this.pnlSolicitudColor.Controls.Add(this.lbReferenciaTela);
            this.pnlSolicitudColor.Controls.Add(this.lbNombreTela);
            this.pnlSolicitudColor.Controls.Add(this.cbxSiCoordinado);
            this.pnlSolicitudColor.Controls.Add(this.lbTipoTejido);
            this.pnlSolicitudColor.Controls.Add(this.cbxNoCoordinado);
            this.pnlSolicitudColor.Controls.Add(this.lbCoordinado);
            this.pnlSolicitudColor.Controls.Add(this.txbCoordinaCon);
            this.pnlSolicitudColor.Controls.Add(this.lbCoordinaCon);
            this.pnlSolicitudColor.Controls.Add(this.txbTipoTejido);
            this.pnlSolicitudColor.Controls.Add(this.txbRefTela);
            this.pnlSolicitudColor.Location = new System.Drawing.Point(12, 155);
            this.pnlSolicitudColor.Name = "pnlSolicitudColor";
            this.pnlSolicitudColor.Size = new System.Drawing.Size(1365, 114);
            this.pnlSolicitudColor.TabIndex = 21;
            // 
            // txbObservaciones
            // 
            this.txbObservaciones.Location = new System.Drawing.Point(12, 699);
            this.txbObservaciones.MaxLength = 120;
            this.txbObservaciones.Name = "txbObservaciones";
            this.txbObservaciones.Size = new System.Drawing.Size(1362, 77);
            this.txbObservaciones.TabIndex = 22;
            this.txbObservaciones.Text = "";
            // 
            // lbObservaciones
            // 
            this.lbObservaciones.AutoSize = true;
            this.lbObservaciones.Location = new System.Drawing.Point(13, 668);
            this.lbObservaciones.Name = "lbObservaciones";
            this.lbObservaciones.Size = new System.Drawing.Size(163, 17);
            this.lbObservaciones.TabIndex = 23;
            this.lbObservaciones.Text = "Observaciones Diseño";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.lblConsecutivo);
            this.panel9.Controls.Add(this.btnConfirmar);
            this.panel9.Controls.Add(this.btnGrabar);
            this.panel9.Controls.Add(this.btnSalir);
            this.panel9.Location = new System.Drawing.Point(12, 90);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1362, 49);
            this.panel9.TabIndex = 134;
            // 
            // lblConsecutivo
            // 
            this.lblConsecutivo.AutoSize = true;
            this.lblConsecutivo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsecutivo.Location = new System.Drawing.Point(545, 15);
            this.lblConsecutivo.Name = "lblConsecutivo";
            this.lblConsecutivo.Size = new System.Drawing.Size(0, 20);
            this.lblConsecutivo.TabIndex = 98;
            // 
            // lbIdentificador
            // 
            this.lbIdentificador.AutoSize = true;
            this.lbIdentificador.BackColor = System.Drawing.Color.Transparent;
            this.lbIdentificador.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIdentificador.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbIdentificador.Location = new System.Drawing.Point(174, 33);
            this.lbIdentificador.Name = "lbIdentificador";
            this.lbIdentificador.Size = new System.Drawing.Size(19, 23);
            this.lbIdentificador.TabIndex = 99;
            this.lbIdentificador.Text = "-";
            // 
            // btnAddColor
            // 
            this.btnAddColor.Image = global::PedidoTela.Formularios.Properties.Resources._1492790881_6add_84227;
            this.btnAddColor.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddColor.Location = new System.Drawing.Point(12, 288);
            this.btnAddColor.Name = "btnAddColor";
            this.btnAddColor.Size = new System.Drawing.Size(303, 69);
            this.btnAddColor.TabIndex = 129;
            this.btnAddColor.Text = "Adicionar Color";
            this.btnAddColor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddColor.UseVisualStyleBackColor = true;
            this.btnAddColor.Click += new System.EventHandler(this.btnAddColor_Click);
            // 
            // lbSolicitud
            // 
            this.lbSolicitud.AutoSize = true;
            this.lbSolicitud.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lbSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbSolicitud.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSolicitud.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbSolicitud.Location = new System.Drawing.Point(44, 5);
            this.lbSolicitud.Name = "lbSolicitud";
            this.lbSolicitud.Size = new System.Drawing.Size(161, 22);
            this.lbSolicitud.TabIndex = 150;
            this.lbSolicitud.Text = "Solicitud Unicolor";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Image = global::PedidoTela.Formularios.Properties.Resources._1492790860_8check_84164;
            this.btnConfirmar.Location = new System.Drawing.Point(176, 3);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(174, 43);
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
            this.btnGrabar.Image = global::PedidoTela.Formularios.Properties.Resources.record_icon_icons_com_64775__1_;
            this.btnGrabar.Location = new System.Drawing.Point(2, 3);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(174, 43);
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
            this.btnSalir.Location = new System.Drawing.Point(351, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(174, 43);
            this.btnSalir.TabIndex = 97;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pictureBox1.Image = global::PedidoTela.Formularios.Properties.Resources.seleccion4;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 33);
            this.pictureBox1.TabIndex = 151;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lbSolicitud);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(321, 320);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(205, 37);
            this.panel1.TabIndex = 152;
            // 
            // frmSolicitudUnicolor
            // 
            this.AcceptButton = this.btnAddColor;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 788);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbIdentificador);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.btnAddColor);
            this.Controls.Add(this.lbObservaciones);
            this.Controls.Add(this.txbObservaciones);
            this.Controls.Add(this.pnlSolicitudColor);
            this.Controls.Add(this.dgvUnicolor);
            this.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmSolicitudUnicolor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitud Unicolor";
            this.Load += new System.EventHandler(this.frmSolicitudUnicolor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnicolor)).EndInit();
            this.pnlSolicitudColor.ResumeLayout(false);
            this.pnlSolicitudColor.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbReferenciaTela;
        private System.Windows.Forms.Label lbNombreTela;
        private System.Windows.Forms.Label lbTipoTejido;
        private System.Windows.Forms.Label lbCoordinado;
        private System.Windows.Forms.Label lbCoordinaCon;
        private System.Windows.Forms.TextBox txbRefTela;
        private System.Windows.Forms.TextBox txbNomTela;
        private System.Windows.Forms.TextBox txbTipoTejido;
        private System.Windows.Forms.TextBox txbCoordinaCon;
        private System.Windows.Forms.CheckBox cbxNoCoordinado;
        private System.Windows.Forms.CheckBox cbxSiCoordinado;
        private System.Windows.Forms.DataGridView dgvUnicolor;
        private System.Windows.Forms.Panel pnlSolicitudColor;
        private System.Windows.Forms.RichTextBox txbObservaciones;
        private System.Windows.Forms.Label lbObservaciones;
        private System.Windows.Forms.Button btnAddColor;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lblConsecutivo;
        private System.Windows.Forms.Label lbIdentificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn codColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiendas;
        private System.Windows.Forms.DataGridViewTextBoxColumn exito;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosud;
        private System.Windows.Forms.DataGridViewTextBoxColumn sao;
        private System.Windows.Forms.DataGridViewTextBoxColumn comercioOrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn rosado;
        private System.Windows.Forms.DataGridViewTextBoxColumn otros;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalUnidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn eliminar;
        private System.Windows.Forms.Label lbSolicitud;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}