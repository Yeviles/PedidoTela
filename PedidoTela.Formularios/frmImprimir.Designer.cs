
namespace PedidoTela.Formularios
{
    partial class frmImprimir
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbTitulosolicitudTelas = new System.Windows.Forms.Label();
            this.cbxTipoSolicitud = new System.Windows.Forms.ComboBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.lblConsecutivo = new System.Windows.Forms.Label();
            this.btnSolicitudInventario = new System.Windows.Forms.Button();
            this.btnSolicitudTelas = new System.Windows.Forms.Button();
            this.btnPedidoTela = new System.Windows.Forms.Button();
            this.pnlSolicitudTelas = new System.Windows.Forms.Panel();
            this.btnBuscarSolTelas = new System.Windows.Forms.Button();
            this.txtEnsayoRef = new System.Windows.Forms.TextBox();
            this.lbEnsayoRef = new System.Windows.Forms.Label();
            this.lbTiposolicitud = new System.Windows.Forms.Label();
            this.pnlSolicitudInventario = new System.Windows.Forms.Panel();
            this.lbInventario = new System.Windows.Forms.Label();
            this.btnBuscarSolInventario = new System.Windows.Forms.Button();
            this.pnlPedidoTela = new System.Windows.Forms.Panel();
            this.lbPedidos = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnbuscarPedidoTela = new System.Windows.Forms.Button();
            this.cbxTipoPedido = new System.Windows.Forms.ComboBox();
            this.txtConsecutivoPedido = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.lbEnsaRef = new System.Windows.Forms.Label();
            this.txtEnsayoRefInventario = new System.Windows.Forms.TextBox();
            this.dgvSolicitudInventario = new System.Windows.Forms.DataGridView();
            this.ensayoRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel9.SuspendLayout();
            this.pnlSolicitudTelas.SuspendLayout();
            this.pnlSolicitudInventario.SuspendLayout();
            this.pnlPedidoTela.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulosolicitudTelas
            // 
            this.lbTitulosolicitudTelas.AutoSize = true;
            this.lbTitulosolicitudTelas.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulosolicitudTelas.Location = new System.Drawing.Point(410, 11);
            this.lbTitulosolicitudTelas.Name = "lbTitulosolicitudTelas";
            this.lbTitulosolicitudTelas.Size = new System.Drawing.Size(168, 20);
            this.lbTitulosolicitudTelas.TabIndex = 0;
            this.lbTitulosolicitudTelas.Text = "Solicitudes de tela";
            // 
            // cbxTipoSolicitud
            // 
            this.cbxTipoSolicitud.FormattingEnabled = true;
            this.cbxTipoSolicitud.Items.AddRange(new object[] {
            "UNICOLOR",
            "ESTAMPADO",
            "PLANO PRETEÑIDO",
            "CUELLOS PUÑOS TIRAS"});
            this.cbxTipoSolicitud.Location = new System.Drawing.Point(138, 44);
            this.cbxTipoSolicitud.Name = "cbxTipoSolicitud";
            this.cbxTipoSolicitud.Size = new System.Drawing.Size(226, 24);
            this.cbxTipoSolicitud.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.btnSalir);
            this.panel9.Controls.Add(this.lblConsecutivo);
            this.panel9.Controls.Add(this.btnSolicitudInventario);
            this.panel9.Controls.Add(this.btnSolicitudTelas);
            this.panel9.Controls.Add(this.btnPedidoTela);
            this.panel9.Location = new System.Drawing.Point(4, 72);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(954, 47);
            this.panel9.TabIndex = 137;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::PedidoTela.Formularios.Properties.Resources.volver;
            this.btnSalir.Location = new System.Drawing.Point(718, 3);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(126, 41);
            this.btnSalir.TabIndex = 98;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // lblConsecutivo
            // 
            this.lblConsecutivo.AutoSize = true;
            this.lblConsecutivo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsecutivo.Location = new System.Drawing.Point(610, 13);
            this.lblConsecutivo.Name = "lblConsecutivo";
            this.lblConsecutivo.Size = new System.Drawing.Size(0, 20);
            this.lblConsecutivo.TabIndex = 99;
            // 
            // btnSolicitudInventario
            // 
            this.btnSolicitudInventario.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolicitudInventario.Image = global::PedidoTela.Formularios.Properties.Resources.imprimir;
            this.btnSolicitudInventario.Location = new System.Drawing.Point(217, 3);
            this.btnSolicitudInventario.Name = "btnSolicitudInventario";
            this.btnSolicitudInventario.Size = new System.Drawing.Size(245, 41);
            this.btnSolicitudInventario.TabIndex = 96;
            this.btnSolicitudInventario.Text = "Solicitud Inventario";
            this.btnSolicitudInventario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSolicitudInventario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSolicitudInventario.UseVisualStyleBackColor = true;
            this.btnSolicitudInventario.Click += new System.EventHandler(this.btnSolicitudInventario_Click);
            // 
            // btnSolicitudTelas
            // 
            this.btnSolicitudTelas.BackColor = System.Drawing.Color.LightGray;
            this.btnSolicitudTelas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSolicitudTelas.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolicitudTelas.Image = global::PedidoTela.Formularios.Properties.Resources.imprimir;
            this.btnSolicitudTelas.Location = new System.Drawing.Point(3, 3);
            this.btnSolicitudTelas.Name = "btnSolicitudTelas";
            this.btnSolicitudTelas.Size = new System.Drawing.Size(215, 41);
            this.btnSolicitudTelas.TabIndex = 95;
            this.btnSolicitudTelas.Text = "Solicitud Telas";
            this.btnSolicitudTelas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSolicitudTelas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSolicitudTelas.UseVisualStyleBackColor = false;
            this.btnSolicitudTelas.Click += new System.EventHandler(this.btnSolicitudTelas_Click);
            // 
            // btnPedidoTela
            // 
            this.btnPedidoTela.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPedidoTela.Image = global::PedidoTela.Formularios.Properties.Resources.imprimir;
            this.btnPedidoTela.Location = new System.Drawing.Point(461, 3);
            this.btnPedidoTela.Name = "btnPedidoTela";
            this.btnPedidoTela.Size = new System.Drawing.Size(258, 41);
            this.btnPedidoTela.TabIndex = 97;
            this.btnPedidoTela.Text = "Pedido Tela";
            this.btnPedidoTela.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPedidoTela.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPedidoTela.UseVisualStyleBackColor = true;
            this.btnPedidoTela.Click += new System.EventHandler(this.btnPedidoTela_Click);
            // 
            // pnlSolicitudTelas
            // 
            this.pnlSolicitudTelas.Controls.Add(this.btnBuscarSolTelas);
            this.pnlSolicitudTelas.Controls.Add(this.txtEnsayoRef);
            this.pnlSolicitudTelas.Controls.Add(this.lbEnsayoRef);
            this.pnlSolicitudTelas.Controls.Add(this.lbTiposolicitud);
            this.pnlSolicitudTelas.Controls.Add(this.lbTitulosolicitudTelas);
            this.pnlSolicitudTelas.Controls.Add(this.cbxTipoSolicitud);
            this.pnlSolicitudTelas.Location = new System.Drawing.Point(8, 125);
            this.pnlSolicitudTelas.Name = "pnlSolicitudTelas";
            this.pnlSolicitudTelas.Size = new System.Drawing.Size(950, 100);
            this.pnlSolicitudTelas.TabIndex = 138;
            this.pnlSolicitudTelas.Visible = false;
            // 
            // btnBuscarSolTelas
            // 
            this.btnBuscarSolTelas.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarSolTelas.Image = global::PedidoTela.Formularios.Properties.Resources.buscar;
            this.btnBuscarSolTelas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarSolTelas.Location = new System.Drawing.Point(774, 37);
            this.btnBuscarSolTelas.Name = "btnBuscarSolTelas";
            this.btnBuscarSolTelas.Size = new System.Drawing.Size(131, 36);
            this.btnBuscarSolTelas.TabIndex = 6;
            this.btnBuscarSolTelas.Text = "Buscar";
            this.btnBuscarSolTelas.UseVisualStyleBackColor = true;
            this.btnBuscarSolTelas.Click += new System.EventHandler(this.btnBuscarSolTelas_Click);
            // 
            // txtEnsayoRef
            // 
            this.txtEnsayoRef.Location = new System.Drawing.Point(532, 48);
            this.txtEnsayoRef.Name = "txtEnsayoRef";
            this.txtEnsayoRef.Size = new System.Drawing.Size(167, 23);
            this.txtEnsayoRef.TabIndex = 5;
            // 
            // lbEnsayoRef
            // 
            this.lbEnsayoRef.AutoSize = true;
            this.lbEnsayoRef.Location = new System.Drawing.Point(373, 51);
            this.lbEnsayoRef.Name = "lbEnsayoRef";
            this.lbEnsayoRef.Size = new System.Drawing.Size(153, 17);
            this.lbEnsayoRef.TabIndex = 4;
            this.lbEnsayoRef.Text = "Ensayo / Referencia:";
            // 
            // lbTiposolicitud
            // 
            this.lbTiposolicitud.AutoSize = true;
            this.lbTiposolicitud.Location = new System.Drawing.Point(24, 49);
            this.lbTiposolicitud.Name = "lbTiposolicitud";
            this.lbTiposolicitud.Size = new System.Drawing.Size(108, 17);
            this.lbTiposolicitud.TabIndex = 3;
            this.lbTiposolicitud.Text = "Tipo Solicitud:";
            // 
            // pnlSolicitudInventario
            // 
            this.pnlSolicitudInventario.Controls.Add(this.dgvSolicitudInventario);
            this.pnlSolicitudInventario.Controls.Add(this.txtEnsayoRefInventario);
            this.pnlSolicitudInventario.Controls.Add(this.lbEnsaRef);
            this.pnlSolicitudInventario.Controls.Add(this.lbInventario);
            this.pnlSolicitudInventario.Controls.Add(this.btnBuscarSolInventario);
            this.pnlSolicitudInventario.Location = new System.Drawing.Point(8, 123);
            this.pnlSolicitudInventario.Name = "pnlSolicitudInventario";
            this.pnlSolicitudInventario.Size = new System.Drawing.Size(950, 180);
            this.pnlSolicitudInventario.TabIndex = 139;
            this.pnlSolicitudInventario.Visible = false;
            // 
            // lbInventario
            // 
            this.lbInventario.AutoSize = true;
            this.lbInventario.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInventario.Location = new System.Drawing.Point(399, 10);
            this.lbInventario.Name = "lbInventario";
            this.lbInventario.Size = new System.Drawing.Size(179, 20);
            this.lbInventario.TabIndex = 8;
            this.lbInventario.Text = "Solicitud Inventario";
            // 
            // btnBuscarSolInventario
            // 
            this.btnBuscarSolInventario.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarSolInventario.Image = global::PedidoTela.Formularios.Properties.Resources.buscar;
            this.btnBuscarSolInventario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscarSolInventario.Location = new System.Drawing.Point(461, 136);
            this.btnBuscarSolInventario.Name = "btnBuscarSolInventario";
            this.btnBuscarSolInventario.Size = new System.Drawing.Size(131, 36);
            this.btnBuscarSolInventario.TabIndex = 7;
            this.btnBuscarSolInventario.Text = "Buscar";
            this.btnBuscarSolInventario.UseVisualStyleBackColor = true;
            this.btnBuscarSolInventario.Click += new System.EventHandler(this.btnBuscarSolInventario_Click);
            // 
            // pnlPedidoTela
            // 
            this.pnlPedidoTela.Controls.Add(this.lbPedidos);
            this.pnlPedidoTela.Controls.Add(this.label2);
            this.pnlPedidoTela.Controls.Add(this.btnbuscarPedidoTela);
            this.pnlPedidoTela.Controls.Add(this.cbxTipoPedido);
            this.pnlPedidoTela.Controls.Add(this.txtConsecutivoPedido);
            this.pnlPedidoTela.Controls.Add(this.label1);
            this.pnlPedidoTela.Location = new System.Drawing.Point(4, 123);
            this.pnlPedidoTela.Name = "pnlPedidoTela";
            this.pnlPedidoTela.Size = new System.Drawing.Size(958, 100);
            this.pnlPedidoTela.TabIndex = 140;
            this.pnlPedidoTela.Visible = false;
            // 
            // lbPedidos
            // 
            this.lbPedidos.AutoSize = true;
            this.lbPedidos.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPedidos.Location = new System.Drawing.Point(434, 9);
            this.lbPedidos.Name = "lbPedidos";
            this.lbPedidos.Size = new System.Drawing.Size(114, 20);
            this.lbPedidos.TabIndex = 9;
            this.lbPedidos.Text = "Pedidos Tela";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tipo Solicitud:";
            // 
            // btnbuscarPedidoTela
            // 
            this.btnbuscarPedidoTela.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuscarPedidoTela.Image = global::PedidoTela.Formularios.Properties.Resources.buscar;
            this.btnbuscarPedidoTela.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbuscarPedidoTela.Location = new System.Drawing.Point(774, 30);
            this.btnbuscarPedidoTela.Name = "btnbuscarPedidoTela";
            this.btnbuscarPedidoTela.Size = new System.Drawing.Size(131, 39);
            this.btnbuscarPedidoTela.TabIndex = 7;
            this.btnbuscarPedidoTela.Text = "Buscar";
            this.btnbuscarPedidoTela.UseVisualStyleBackColor = true;
            this.btnbuscarPedidoTela.Click += new System.EventHandler(this.btnbuscarPedidoTela_Click);
            // 
            // cbxTipoPedido
            // 
            this.cbxTipoPedido.FormattingEnabled = true;
            this.cbxTipoPedido.Items.AddRange(new object[] {
            "UNICOLOR",
            "ESTAMPADO",
            "CUELLOS PUÑOS TIRAS",
            "PLANO PRETEÑIDO",
            "COODINADO 3 EN 1",
            "AGENCIAS EXTERNOS"});
            this.cbxTipoPedido.Location = new System.Drawing.Point(138, 42);
            this.cbxTipoPedido.Name = "cbxTipoPedido";
            this.cbxTipoPedido.Size = new System.Drawing.Size(208, 24);
            this.cbxTipoPedido.TabIndex = 7;
            // 
            // txtConsecutivoPedido
            // 
            this.txtConsecutivoPedido.Location = new System.Drawing.Point(470, 43);
            this.txtConsecutivoPedido.Name = "txtConsecutivoPedido";
            this.txtConsecutivoPedido.Size = new System.Drawing.Size(211, 23);
            this.txtConsecutivoPedido.TabIndex = 1;
            this.txtConsecutivoPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsecutivoPedido_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(355, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consecutivo:";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Location = new System.Drawing.Point(8, 229);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(954, 547);
            this.reportViewer1.TabIndex = 141;
            // 
            // lbEnsaRef
            // 
            this.lbEnsaRef.AutoSize = true;
            this.lbEnsaRef.Location = new System.Drawing.Point(27, 151);
            this.lbEnsaRef.Name = "lbEnsaRef";
            this.lbEnsaRef.Size = new System.Drawing.Size(143, 17);
            this.lbEnsaRef.TabIndex = 9;
            this.lbEnsaRef.Text = "Ensayo/Referencia:";
            // 
            // txtEnsayoRefInventario
            // 
            this.txtEnsayoRefInventario.Location = new System.Drawing.Point(200, 148);
            this.txtEnsayoRefInventario.Name = "txtEnsayoRefInventario";
            this.txtEnsayoRefInventario.Size = new System.Drawing.Size(218, 23);
            this.txtEnsayoRefInventario.TabIndex = 10;
            // 
            // dgvSolicitudInventario
            // 
            this.dgvSolicitudInventario.AllowUserToAddRows = false;
            this.dgvSolicitudInventario.AllowUserToDeleteRows = false;
            this.dgvSolicitudInventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSolicitudInventario.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvSolicitudInventario.BackgroundColor = System.Drawing.Color.White;
            this.dgvSolicitudInventario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSolicitudInventario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSolicitudInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSolicitudInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ensayoRef,
            this.estados});
            this.dgvSolicitudInventario.EnableHeadersVisualStyles = false;
            this.dgvSolicitudInventario.Location = new System.Drawing.Point(3, 44);
            this.dgvSolicitudInventario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSolicitudInventario.MultiSelect = false;
            this.dgvSolicitudInventario.Name = "dgvSolicitudInventario";
            this.dgvSolicitudInventario.ReadOnly = true;
            this.dgvSolicitudInventario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvSolicitudInventario.RowHeadersWidth = 62;
            this.dgvSolicitudInventario.RowTemplate.Height = 28;
            this.dgvSolicitudInventario.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSolicitudInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSolicitudInventario.Size = new System.Drawing.Size(944, 87);
            this.dgvSolicitudInventario.TabIndex = 147;
            this.dgvSolicitudInventario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSolicitudInventario_CellClick);
            // 
            // ensayoRef
            // 
            this.ensayoRef.HeaderText = "Ensayo/Referencia";
            this.ensayoRef.MinimumWidth = 8;
            this.ensayoRef.Name = "ensayoRef";
            this.ensayoRef.ReadOnly = true;
            // 
            // estados
            // 
            this.estados.HeaderText = "estado";
            this.estados.MinimumWidth = 6;
            this.estados.Name = "estados";
            this.estados.ReadOnly = true;
            // 
            // frmImprimir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 788);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.pnlPedidoTela);
            this.Controls.Add(this.pnlSolicitudInventario);
            this.Controls.Add(this.pnlSolicitudTelas);
            this.Controls.Add(this.panel9);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmImprimir";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Imprimir";
            this.Load += new System.EventHandler(this.frmImprimir_Load);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.pnlSolicitudTelas.ResumeLayout(false);
            this.pnlSolicitudTelas.PerformLayout();
            this.pnlSolicitudInventario.ResumeLayout(false);
            this.pnlSolicitudInventario.PerformLayout();
            this.pnlPedidoTela.ResumeLayout(false);
            this.pnlPedidoTela.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSolicitudInventario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTitulosolicitudTelas;
        private System.Windows.Forms.ComboBox cbxTipoSolicitud;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label lblConsecutivo;
        private System.Windows.Forms.Button btnSolicitudInventario;
        private System.Windows.Forms.Button btnSolicitudTelas;
        private System.Windows.Forms.Button btnPedidoTela;
        private System.Windows.Forms.Panel pnlSolicitudTelas;
        private System.Windows.Forms.Label lbTiposolicitud;
        private System.Windows.Forms.TextBox txtEnsayoRef;
        private System.Windows.Forms.Label lbEnsayoRef;
        private System.Windows.Forms.Button btnBuscarSolTelas;
        private System.Windows.Forms.Panel pnlSolicitudInventario;
        private System.Windows.Forms.Button btnBuscarSolInventario;
        private System.Windows.Forms.Panel pnlPedidoTela;
        private System.Windows.Forms.Button btnbuscarPedidoTela;
        private System.Windows.Forms.TextBox txtConsecutivoPedido;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxTipoPedido;
        private System.Windows.Forms.Button btnSalir;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label lbInventario;
        private System.Windows.Forms.Label lbPedidos;
        private System.Windows.Forms.TextBox txtEnsayoRefInventario;
        private System.Windows.Forms.Label lbEnsaRef;
        private System.Windows.Forms.DataGridView dgvSolicitudInventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ensayoRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn estados;
    }
}