﻿
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
            this.pnlSolicitudColor = new System.Windows.Forms.Panel();
            this.cbxTipoTela = new System.Windows.Forms.ComboBox();
            this.cbxTipoEst = new System.Windows.Forms.ComboBox();
            this.lbTipoTela = new System.Windows.Forms.Label();
            this.txbNomTela = new System.Windows.Forms.TextBox();
            this.txbNcilindro = new System.Windows.Forms.TextBox();
            this.lbNumeroCilindros = new System.Windows.Forms.Label();
            this.txbNdibujo = new System.Windows.Forms.TextBox();
            this.cbxSiCoordinadoEst = new System.Windows.Forms.CheckBox();
            this.cbxNoCoordinadoEst = new System.Windows.Forms.CheckBox();
            this.lbNDibujos = new System.Windows.Forms.Label();
            this.lbCoordinado = new System.Windows.Forms.Label();
            this.lbReferenciaTela = new System.Windows.Forms.Label();
            this.lbNombreTela = new System.Windows.Forms.Label();
            this.lbTipoestampado = new System.Windows.Forms.Label();
            this.txbCoordinaCon = new System.Windows.Forms.TextBox();
            this.lbCoordinaCon = new System.Windows.Forms.Label();
            this.txbRefTela = new System.Windows.Forms.TextBox();
            this.dtgEstampado = new System.Windows.Forms.DataGridView();
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
            this.txtObsEstampado = new System.Windows.Forms.RichTextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAddColorCuellos = new System.Windows.Forms.Button();
            this.pnlSolicitudColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstampado)).BeginInit();
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
            this.pnlSolicitudColor.Controls.Add(this.txbNdibujo);
            this.pnlSolicitudColor.Controls.Add(this.cbxSiCoordinadoEst);
            this.pnlSolicitudColor.Controls.Add(this.cbxNoCoordinadoEst);
            this.pnlSolicitudColor.Controls.Add(this.lbNDibujos);
            this.pnlSolicitudColor.Controls.Add(this.lbCoordinado);
            this.pnlSolicitudColor.Controls.Add(this.lbReferenciaTela);
            this.pnlSolicitudColor.Controls.Add(this.lbNombreTela);
            this.pnlSolicitudColor.Controls.Add(this.lbTipoestampado);
            this.pnlSolicitudColor.Controls.Add(this.txbCoordinaCon);
            this.pnlSolicitudColor.Controls.Add(this.lbCoordinaCon);
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
            this.cbxTipoTela.Items.AddRange(new object[] {
            "Plano",
            "Preteñido",
            "Punto"});
            this.cbxTipoTela.Location = new System.Drawing.Point(965, 63);
            this.cbxTipoTela.Name = "cbxTipoTela";
            this.cbxTipoTela.Size = new System.Drawing.Size(267, 24);
            this.cbxTipoTela.TabIndex = 22;
            // 
            // cbxTipoEst
            // 
            this.cbxTipoEst.FormattingEnabled = true;
            this.cbxTipoEst.Items.AddRange(new object[] {
            "Rotativo",
            "Digital"});
            this.cbxTipoEst.Location = new System.Drawing.Point(965, 16);
            this.cbxTipoEst.Name = "cbxTipoEst";
            this.cbxTipoEst.Size = new System.Drawing.Size(267, 24);
            this.cbxTipoEst.TabIndex = 21;
            // 
            // lbTipoTela
            // 
            this.lbTipoTela.AutoSize = true;
            this.lbTipoTela.Location = new System.Drawing.Point(830, 65);
            this.lbTipoTela.Name = "lbTipoTela";
            this.lbTipoTela.Size = new System.Drawing.Size(97, 17);
            this.lbTipoTela.TabIndex = 19;
            this.lbTipoTela.Text = "Tipo de Tela:";
            // 
            // txbNomTela
            // 
            this.txbNomTela.BackColor = System.Drawing.SystemColors.Window;
            this.txbNomTela.Location = new System.Drawing.Point(546, 15);
            this.txbNomTela.Name = "txbNomTela";
            this.txbNomTela.ReadOnly = true;
            this.txbNomTela.Size = new System.Drawing.Size(268, 23);
            this.txbNomTela.TabIndex = 18;
            // 
            // txbNcilindro
            // 
            this.txbNcilindro.Location = new System.Drawing.Point(737, 64);
            this.txbNcilindro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbNcilindro.Name = "txbNcilindro";
            this.txbNcilindro.Size = new System.Drawing.Size(77, 23);
            this.txbNcilindro.TabIndex = 17;
            this.txbNcilindro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbNcilindro_KeyPress);
            // 
            // lbNumeroCilindros
            // 
            this.lbNumeroCilindros.AutoSize = true;
            this.lbNumeroCilindros.Location = new System.Drawing.Point(634, 67);
            this.lbNumeroCilindros.Name = "lbNumeroCilindros";
            this.lbNumeroCilindros.Size = new System.Drawing.Size(89, 17);
            this.lbNumeroCilindros.TabIndex = 16;
            this.lbNumeroCilindros.Text = "N° Cilindro:";
            // 
            // txbNdibujo
            // 
            this.txbNdibujo.Location = new System.Drawing.Point(549, 65);
            this.txbNdibujo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbNdibujo.Name = "txbNdibujo";
            this.txbNdibujo.Size = new System.Drawing.Size(79, 23);
            this.txbNdibujo.TabIndex = 15;
            this.txbNdibujo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbNdibujo_KeyPress);
            // 
            // cbxSiCoordinadoEst
            // 
            this.cbxSiCoordinadoEst.AutoSize = true;
            this.cbxSiCoordinadoEst.Location = new System.Drawing.Point(1408, 67);
            this.cbxSiCoordinadoEst.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxSiCoordinadoEst.Name = "cbxSiCoordinadoEst";
            this.cbxSiCoordinadoEst.Size = new System.Drawing.Size(43, 21);
            this.cbxSiCoordinadoEst.TabIndex = 13;
            this.cbxSiCoordinadoEst.Text = "Si";
            this.cbxSiCoordinadoEst.UseVisualStyleBackColor = true;
            // 
            // cbxNoCoordinadoEst
            // 
            this.cbxNoCoordinadoEst.AutoSize = true;
            this.cbxNoCoordinadoEst.Location = new System.Drawing.Point(1350, 67);
            this.cbxNoCoordinadoEst.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxNoCoordinadoEst.Name = "cbxNoCoordinadoEst";
            this.cbxNoCoordinadoEst.Size = new System.Drawing.Size(49, 21);
            this.cbxNoCoordinadoEst.TabIndex = 12;
            this.cbxNoCoordinadoEst.Text = "No";
            this.cbxNoCoordinadoEst.UseVisualStyleBackColor = true;
            // 
            // lbNDibujos
            // 
            this.lbNDibujos.AutoSize = true;
            this.lbNDibujos.Location = new System.Drawing.Point(419, 66);
            this.lbNDibujos.Name = "lbNDibujos";
            this.lbNDibujos.Size = new System.Drawing.Size(91, 17);
            this.lbNDibujos.TabIndex = 14;
            this.lbNDibujos.Text = "N° Dibujos:";
            // 
            // lbCoordinado
            // 
            this.lbCoordinado.AutoSize = true;
            this.lbCoordinado.Location = new System.Drawing.Point(1245, 68);
            this.lbCoordinado.Name = "lbCoordinado";
            this.lbCoordinado.Size = new System.Drawing.Size(95, 17);
            this.lbCoordinado.TabIndex = 6;
            this.lbCoordinado.Text = "Coordinado:";
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
            this.lbNombreTela.Location = new System.Drawing.Point(419, 19);
            this.lbNombreTela.Name = "lbNombreTela";
            this.lbNombreTela.Size = new System.Drawing.Size(122, 17);
            this.lbNombreTela.TabIndex = 4;
            this.lbNombreTela.Text = "Nombre de Tela:";
            // 
            // lbTipoestampado
            // 
            this.lbTipoestampado.AutoSize = true;
            this.lbTipoestampado.Location = new System.Drawing.Point(826, 15);
            this.lbTipoestampado.Name = "lbTipoestampado";
            this.lbTipoestampado.Size = new System.Drawing.Size(128, 17);
            this.lbTipoestampado.TabIndex = 5;
            this.lbTipoestampado.Text = "Tipo Estampado:";
            // 
            // txbCoordinaCon
            // 
            this.txbCoordinaCon.Location = new System.Drawing.Point(145, 63);
            this.txbCoordinaCon.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbCoordinaCon.Name = "txbCoordinaCon";
            this.txbCoordinaCon.Size = new System.Drawing.Size(268, 23);
            this.txbCoordinaCon.TabIndex = 11;
            // 
            // lbCoordinaCon
            // 
            this.lbCoordinaCon.AutoSize = true;
            this.lbCoordinaCon.Location = new System.Drawing.Point(14, 66);
            this.lbCoordinaCon.Name = "lbCoordinaCon";
            this.lbCoordinaCon.Size = new System.Drawing.Size(107, 17);
            this.lbCoordinaCon.TabIndex = 7;
            this.lbCoordinaCon.Text = "Coordina con:";
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
            // dtgEstampado
            // 
            this.dtgEstampado.AllowUserToAddRows = false;
            this.dtgEstampado.AllowUserToDeleteRows = false;
            this.dtgEstampado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgEstampado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtgEstampado.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgEstampado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgEstampado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgEstampado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dtgEstampado.EnableHeadersVisualStyles = false;
            this.dtgEstampado.Location = new System.Drawing.Point(15, 355);
            this.dtgEstampado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtgEstampado.MultiSelect = false;
            this.dtgEstampado.Name = "dtgEstampado";
            this.dtgEstampado.ReadOnly = true;
            this.dtgEstampado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtgEstampado.RowHeadersWidth = 62;
            this.dtgEstampado.RowTemplate.Height = 28;
            this.dtgEstampado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgEstampado.Size = new System.Drawing.Size(1461, 310);
            this.dtgEstampado.TabIndex = 27;
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
            this.tiendas.ReadOnly = true;
            // 
            // exito
            // 
            this.exito.HeaderText = "Éxito";
            this.exito.MinimumWidth = 8;
            this.exito.Name = "exito";
            this.exito.ReadOnly = true;
            // 
            // cencosud
            // 
            this.cencosud.HeaderText = "Cencosud";
            this.cencosud.MinimumWidth = 8;
            this.cencosud.Name = "cencosud";
            this.cencosud.ReadOnly = true;
            // 
            // sao
            // 
            this.sao.HeaderText = "SAO";
            this.sao.MinimumWidth = 8;
            this.sao.Name = "sao";
            this.sao.ReadOnly = true;
            // 
            // comercioOrg
            // 
            this.comercioOrg.HeaderText = "Comercio Org.";
            this.comercioOrg.MinimumWidth = 8;
            this.comercioOrg.Name = "comercioOrg";
            this.comercioOrg.ReadOnly = true;
            // 
            // rosado
            // 
            this.rosado.HeaderText = "Rosado";
            this.rosado.MinimumWidth = 8;
            this.rosado.Name = "rosado";
            this.rosado.ReadOnly = true;
            // 
            // otros
            // 
            this.otros.HeaderText = "Otros";
            this.otros.MinimumWidth = 8;
            this.otros.Name = "otros";
            this.otros.ReadOnly = true;
            // 
            // totalUnidades
            // 
            this.totalUnidades.HeaderText = "Total Unidades";
            this.totalUnidades.MinimumWidth = 8;
            this.totalUnidades.Name = "totalUnidades";
            this.totalUnidades.ReadOnly = true;
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
            // txtObsEstampado
            // 
            this.txtObsEstampado.Location = new System.Drawing.Point(14, 702);
            this.txtObsEstampado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObsEstampado.Name = "txtObsEstampado";
            this.txtObsEstampado.Size = new System.Drawing.Size(1462, 76);
            this.txtObsEstampado.TabIndex = 28;
            this.txtObsEstampado.Text = "";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.button1);
            this.panel9.Controls.Add(this.button2);
            this.panel9.Controls.Add(this.btnSalir);
            this.panel9.Location = new System.Drawing.Point(15, 86);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1461, 56);
            this.panel9.TabIndex = 134;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::PedidoTela.Formularios.Properties.Resources._1492790860_8check_84164;
            this.button1.Location = new System.Drawing.Point(173, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 50);
            this.button1.TabIndex = 96;
            this.button1.Text = "Confirmar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGray;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::PedidoTela.Formularios.Properties.Resources.record_icon_icons_com_64775__1_;
            this.button2.Location = new System.Drawing.Point(2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 50);
            this.button2.TabIndex = 95;
            this.button2.Text = "Grabar";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
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
            // btnAddColorCuellos
            // 
            this.btnAddColorCuellos.Image = global::PedidoTela.Formularios.Properties.Resources._1492790881_6add_84227;
            this.btnAddColorCuellos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddColorCuellos.Location = new System.Drawing.Point(15, 272);
            this.btnAddColorCuellos.Name = "btnAddColorCuellos";
            this.btnAddColorCuellos.Size = new System.Drawing.Size(303, 69);
            this.btnAddColorCuellos.TabIndex = 129;
            this.btnAddColorCuellos.Text = "Adicionar Color";
            this.btnAddColorCuellos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddColorCuellos.UseVisualStyleBackColor = true;
            // 
            // frmSolicitudEstampado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1488, 803);
            this.Controls.Add(this.btnAddColorCuellos);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.lbObservaciones);
            this.Controls.Add(this.txtObsEstampado);
            this.Controls.Add(this.dtgEstampado);
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
            ((System.ComponentModel.ISupportInitialize)(this.dtgEstampado)).EndInit();
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSolicitudColor;
        private System.Windows.Forms.Label lbReferenciaTela;
        private System.Windows.Forms.Label lbNombreTela;
        private System.Windows.Forms.CheckBox cbxSiCoordinadoEst;
        private System.Windows.Forms.Label lbTipoestampado;
        private System.Windows.Forms.CheckBox cbxNoCoordinadoEst;
        private System.Windows.Forms.Label lbCoordinado;
        private System.Windows.Forms.TextBox txbCoordinaCon;
        private System.Windows.Forms.Label lbCoordinaCon;
        private System.Windows.Forms.TextBox txbRefTela;
        private System.Windows.Forms.TextBox txbNdibujo;
        private System.Windows.Forms.Label lbNDibujos;
        private System.Windows.Forms.TextBox txbNcilindro;
        private System.Windows.Forms.Label lbNumeroCilindros;
        private System.Windows.Forms.DataGridView dtgEstampado;
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
        private System.Windows.Forms.Label lbObservaciones;
        private System.Windows.Forms.RichTextBox txtObsEstampado;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAddColorCuellos;
        private System.Windows.Forms.TextBox txbNomTela;
        private System.Windows.Forms.ComboBox cbxTipoTela;
        private System.Windows.Forms.ComboBox cbxTipoEst;
        private System.Windows.Forms.Label lbTipoTela;
    }
}