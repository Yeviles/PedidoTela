
namespace PedidoTela.Formularios
{
    partial class frmSolicitudTela
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbcPedidoTela = new System.Windows.Forms.TabControl();
            this.tbpAdicionarSolTela = new System.Windows.Forms.TabPage();
            this.pnlAdicionarSolicitud = new System.Windows.Forms.Panel();
            this.txbEnsRefDigitado = new System.Windows.Forms.TextBox();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.lbTipo = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.dtpFechaTienda = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txbDisenador = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbTema = new System.Windows.Forms.TextBox();
            this.txbAnio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbSku = new System.Windows.Forms.TextBox();
            this.lbSKU = new System.Windows.Forms.Label();
            this.lbTema = new System.Windows.Forms.Label();
            this.lbAyo = new System.Windows.Forms.Label();
            this.txbEntrada = new System.Windows.Forms.TextBox();
            this.txbOcasionUso = new System.Windows.Forms.TextBox();
            this.txbMuestrario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbDisenador = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvDetalleConsumo = new System.Windows.Forms.DataGridView();
            this.ensayoRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desPrenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refTela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desTela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.editar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.guardar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.lbDetalleConsumo = new System.Windows.Forms.Label();
            this.ttEnsayoRef = new System.Windows.Forms.ToolTip(this.components);
            this.ttSku = new System.Windows.Forms.ToolTip(this.components);
            this.ttTipo = new System.Windows.Forms.ToolTip(this.components);
            this.tbcPedidoTela.SuspendLayout();
            this.tbpAdicionarSolTela.SuspendLayout();
            this.pnlAdicionarSolicitud.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleConsumo)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcPedidoTela
            // 
            this.tbcPedidoTela.Controls.Add(this.tbpAdicionarSolTela);
            this.tbcPedidoTela.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbcPedidoTela.Location = new System.Drawing.Point(12, 84);
            this.tbcPedidoTela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbcPedidoTela.Name = "tbcPedidoTela";
            this.tbcPedidoTela.SelectedIndex = 0;
            this.tbcPedidoTela.Size = new System.Drawing.Size(1450, 677);
            this.tbcPedidoTela.TabIndex = 0;
            // 
            // tbpAdicionarSolTela
            // 
            this.tbpAdicionarSolTela.Controls.Add(this.pnlAdicionarSolicitud);
            this.tbpAdicionarSolTela.Controls.Add(this.dgvDetalleConsumo);
            this.tbpAdicionarSolTela.Controls.Add(this.lbDetalleConsumo);
            this.tbpAdicionarSolTela.Location = new System.Drawing.Point(4, 25);
            this.tbpAdicionarSolTela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpAdicionarSolTela.Name = "tbpAdicionarSolTela";
            this.tbpAdicionarSolTela.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpAdicionarSolTela.Size = new System.Drawing.Size(1442, 648);
            this.tbpAdicionarSolTela.TabIndex = 0;
            this.tbpAdicionarSolTela.Text = "Adicionar Solicitud Tela";
            this.tbpAdicionarSolTela.UseVisualStyleBackColor = true;
            // 
            // pnlAdicionarSolicitud
            // 
            this.pnlAdicionarSolicitud.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlAdicionarSolicitud.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAdicionarSolicitud.Controls.Add(this.txbEnsRefDigitado);
            this.pnlAdicionarSolicitud.Controls.Add(this.cbxTipo);
            this.pnlAdicionarSolicitud.Controls.Add(this.lbTipo);
            this.pnlAdicionarSolicitud.Controls.Add(this.btnConsultar);
            this.pnlAdicionarSolicitud.Controls.Add(this.dtpFechaTienda);
            this.pnlAdicionarSolicitud.Controls.Add(this.label9);
            this.pnlAdicionarSolicitud.Controls.Add(this.txbDisenador);
            this.pnlAdicionarSolicitud.Controls.Add(this.label2);
            this.pnlAdicionarSolicitud.Controls.Add(this.txbTema);
            this.pnlAdicionarSolicitud.Controls.Add(this.txbAnio);
            this.pnlAdicionarSolicitud.Controls.Add(this.label5);
            this.pnlAdicionarSolicitud.Controls.Add(this.txbSku);
            this.pnlAdicionarSolicitud.Controls.Add(this.lbSKU);
            this.pnlAdicionarSolicitud.Controls.Add(this.lbTema);
            this.pnlAdicionarSolicitud.Controls.Add(this.lbAyo);
            this.pnlAdicionarSolicitud.Controls.Add(this.txbEntrada);
            this.pnlAdicionarSolicitud.Controls.Add(this.txbOcasionUso);
            this.pnlAdicionarSolicitud.Controls.Add(this.txbMuestrario);
            this.pnlAdicionarSolicitud.Controls.Add(this.label3);
            this.pnlAdicionarSolicitud.Controls.Add(this.lbDisenador);
            this.pnlAdicionarSolicitud.Controls.Add(this.label7);
            this.pnlAdicionarSolicitud.Location = new System.Drawing.Point(13, 15);
            this.pnlAdicionarSolicitud.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlAdicionarSolicitud.Name = "pnlAdicionarSolicitud";
            this.pnlAdicionarSolicitud.Size = new System.Drawing.Size(1415, 187);
            this.pnlAdicionarSolicitud.TabIndex = 20;
            // 
            // txbEnsRefDigitado
            // 
            this.txbEnsRefDigitado.BackColor = System.Drawing.SystemColors.Window;
            this.txbEnsRefDigitado.Location = new System.Drawing.Point(202, 53);
            this.txbEnsRefDigitado.Name = "txbEnsRefDigitado";
            this.txbEnsRefDigitado.ReadOnly = true;
            this.txbEnsRefDigitado.Size = new System.Drawing.Size(254, 24);
            this.txbEnsRefDigitado.TabIndex = 63;
            this.txbEnsRefDigitado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbEnsRefDigitado_KeyPress);
            // 
            // cbxTipo
            // 
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Items.AddRange(new object[] {
            "Ensayo",
            "Referencia"});
            this.cbxTipo.Location = new System.Drawing.Point(202, 10);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(254, 24);
            this.cbxTipo.TabIndex = 62;
            this.cbxTipo.SelectionChangeCommitted += new System.EventHandler(this.cbxTipo_SelectionChangeCommitted);
            // 
            // lbTipo
            // 
            this.lbTipo.AutoSize = true;
            this.lbTipo.Location = new System.Drawing.Point(37, 15);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(44, 17);
            this.lbTipo.TabIndex = 61;
            this.lbTipo.Text = "Tipo:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = global::PedidoTela.Formularios.Properties.Resources.finger_hand_5531;
            this.btnConsultar.Location = new System.Drawing.Point(1199, 122);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(167, 58);
            this.btnConsultar.TabIndex = 60;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // dtpFechaTienda
            // 
            this.dtpFechaTienda.Location = new System.Drawing.Point(675, 102);
            this.dtpFechaTienda.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpFechaTienda.Name = "dtpFechaTienda";
            this.dtpFechaTienda.Size = new System.Drawing.Size(254, 24);
            this.dtpFechaTienda.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(556, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 17);
            this.label9.TabIndex = 7;
            this.label9.Text = "Fecha Tienda:";
            // 
            // txbDisenador
            // 
            this.txbDisenador.BackColor = System.Drawing.SystemColors.Window;
            this.txbDisenador.Location = new System.Drawing.Point(202, 95);
            this.txbDisenador.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbDisenador.Name = "txbDisenador";
            this.txbDisenador.ReadOnly = true;
            this.txbDisenador.Size = new System.Drawing.Size(254, 24);
            this.txbDisenador.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ensayo/Ref. Similiar:";
            // 
            // txbTema
            // 
            this.txbTema.BackColor = System.Drawing.SystemColors.Window;
            this.txbTema.Location = new System.Drawing.Point(1112, 52);
            this.txbTema.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbTema.Name = "txbTema";
            this.txbTema.ReadOnly = true;
            this.txbTema.Size = new System.Drawing.Size(254, 24);
            this.txbTema.TabIndex = 16;
            // 
            // txbAnio
            // 
            this.txbAnio.BackColor = System.Drawing.SystemColors.Window;
            this.txbAnio.Location = new System.Drawing.Point(1112, 16);
            this.txbAnio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbAnio.Name = "txbAnio";
            this.txbAnio.ReadOnly = true;
            this.txbAnio.Size = new System.Drawing.Size(254, 24);
            this.txbAnio.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ocasión Uso:";
            // 
            // txbSku
            // 
            this.txbSku.Location = new System.Drawing.Point(1112, 93);
            this.txbSku.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbSku.Name = "txbSku";
            this.txbSku.Size = new System.Drawing.Size(254, 24);
            this.txbSku.TabIndex = 11;
            this.txbSku.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbSku_KeyPress);
            this.txbSku.Validating += new System.ComponentModel.CancelEventHandler(this.txbSku_Validating);
            // 
            // lbSKU
            // 
            this.lbSKU.AutoSize = true;
            this.lbSKU.Location = new System.Drawing.Point(1025, 102);
            this.lbSKU.Name = "lbSKU";
            this.lbSKU.Size = new System.Drawing.Size(44, 17);
            this.lbSKU.TabIndex = 8;
            this.lbSKU.Text = "SKU:";
            // 
            // lbTema
            // 
            this.lbTema.AutoSize = true;
            this.lbTema.Location = new System.Drawing.Point(1025, 53);
            this.lbTema.Name = "lbTema";
            this.lbTema.Size = new System.Drawing.Size(50, 17);
            this.lbTema.TabIndex = 4;
            this.lbTema.Text = "Tema:";
            // 
            // lbAyo
            // 
            this.lbAyo.AutoSize = true;
            this.lbAyo.Location = new System.Drawing.Point(1029, 16);
            this.lbAyo.Name = "lbAyo";
            this.lbAyo.Size = new System.Drawing.Size(42, 17);
            this.lbAyo.TabIndex = 2;
            this.lbAyo.Text = "Año:";
            // 
            // txbEntrada
            // 
            this.txbEntrada.BackColor = System.Drawing.SystemColors.Window;
            this.txbEntrada.Location = new System.Drawing.Point(676, 54);
            this.txbEntrada.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbEntrada.Name = "txbEntrada";
            this.txbEntrada.ReadOnly = true;
            this.txbEntrada.Size = new System.Drawing.Size(254, 24);
            this.txbEntrada.TabIndex = 14;
            // 
            // txbOcasionUso
            // 
            this.txbOcasionUso.BackColor = System.Drawing.SystemColors.Window;
            this.txbOcasionUso.Location = new System.Drawing.Point(202, 139);
            this.txbOcasionUso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbOcasionUso.Name = "txbOcasionUso";
            this.txbOcasionUso.ReadOnly = true;
            this.txbOcasionUso.Size = new System.Drawing.Size(254, 24);
            this.txbOcasionUso.TabIndex = 13;
            // 
            // txbMuestrario
            // 
            this.txbMuestrario.BackColor = System.Drawing.SystemColors.Window;
            this.txbMuestrario.Location = new System.Drawing.Point(676, 12);
            this.txbMuestrario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbMuestrario.Name = "txbMuestrario";
            this.txbMuestrario.ReadOnly = true;
            this.txbMuestrario.Size = new System.Drawing.Size(254, 24);
            this.txbMuestrario.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(556, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Muestrario:";
            // 
            // lbDisenador
            // 
            this.lbDisenador.AutoSize = true;
            this.lbDisenador.Location = new System.Drawing.Point(34, 99);
            this.lbDisenador.Name = "lbDisenador";
            this.lbDisenador.Size = new System.Drawing.Size(105, 17);
            this.lbDisenador.TabIndex = 6;
            this.lbDisenador.Text = "Diseñador(a):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(556, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Entrada:";
            // 
            // dgvDetalleConsumo
            // 
            this.dgvDetalleConsumo.AllowUserToAddRows = false;
            this.dgvDetalleConsumo.AllowUserToDeleteRows = false;
            this.dgvDetalleConsumo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalleConsumo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDetalleConsumo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleConsumo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalleConsumo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleConsumo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ensayoRef,
            this.desPrenda,
            this.refTela,
            this.desTela,
            this.consumos,
            this.editar,
            this.guardar});
            this.dgvDetalleConsumo.EnableHeadersVisualStyles = false;
            this.dgvDetalleConsumo.GridColor = System.Drawing.SystemColors.ScrollBar;
            this.dgvDetalleConsumo.Location = new System.Drawing.Point(14, 252);
            this.dgvDetalleConsumo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDetalleConsumo.MultiSelect = false;
            this.dgvDetalleConsumo.Name = "dgvDetalleConsumo";
            this.dgvDetalleConsumo.ReadOnly = true;
            this.dgvDetalleConsumo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvDetalleConsumo.RowHeadersWidth = 62;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvDetalleConsumo.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalleConsumo.RowTemplate.Height = 28;
            this.dgvDetalleConsumo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDetalleConsumo.Size = new System.Drawing.Size(1415, 380);
            this.dgvDetalleConsumo.TabIndex = 19;
            this.dgvDetalleConsumo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dgvDetalleConsumo.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalleConsumo_CellEndEdit);
            this.dgvDetalleConsumo.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvDetalleConsumo_CellPainting);
            // 
            // ensayoRef
            // 
            this.ensayoRef.HeaderText = "Ensayo/Ref Similar";
            this.ensayoRef.MinimumWidth = 8;
            this.ensayoRef.Name = "ensayoRef";
            this.ensayoRef.ReadOnly = true;
            // 
            // desPrenda
            // 
            this.desPrenda.HeaderText = "Descripción Prenda";
            this.desPrenda.MinimumWidth = 8;
            this.desPrenda.Name = "desPrenda";
            this.desPrenda.ReadOnly = true;
            // 
            // refTela
            // 
            this.refTela.HeaderText = "Referencia Tela";
            this.refTela.MinimumWidth = 8;
            this.refTela.Name = "refTela";
            this.refTela.ReadOnly = true;
            // 
            // desTela
            // 
            this.desTela.HeaderText = "Descripción Tela";
            this.desTela.MinimumWidth = 8;
            this.desTela.Name = "desTela";
            this.desTela.ReadOnly = true;
            // 
            // consumos
            // 
            this.consumos.HeaderText = "Consumo";
            this.consumos.MinimumWidth = 8;
            this.consumos.Name = "consumos";
            this.consumos.ReadOnly = true;
            // 
            // editar
            // 
            this.editar.HeaderText = "Editar";
            this.editar.MinimumWidth = 6;
            this.editar.Name = "editar";
            this.editar.ReadOnly = true;
            // 
            // guardar
            // 
            this.guardar.HeaderText = "Guardar";
            this.guardar.MinimumWidth = 6;
            this.guardar.Name = "guardar";
            this.guardar.ReadOnly = true;
            // 
            // lbDetalleConsumo
            // 
            this.lbDetalleConsumo.AutoSize = true;
            this.lbDetalleConsumo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDetalleConsumo.Location = new System.Drawing.Point(13, 221);
            this.lbDetalleConsumo.Name = "lbDetalleConsumo";
            this.lbDetalleConsumo.Size = new System.Drawing.Size(129, 19);
            this.lbDetalleConsumo.TabIndex = 18;
            this.lbDetalleConsumo.Text = "Detalle Consumo";
            // 
            // frmSolicitudTela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1481, 788);
            this.Controls.Add(this.tbcPedidoTela);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmSolicitudTela";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar solicitud Tela";
            this.Load += new System.EventHandler(this.frmSolicitudTela_Load);
            this.tbcPedidoTela.ResumeLayout(false);
            this.tbpAdicionarSolTela.ResumeLayout(false);
            this.tbpAdicionarSolTela.PerformLayout();
            this.pnlAdicionarSolicitud.ResumeLayout(false);
            this.pnlAdicionarSolicitud.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleConsumo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcPedidoTela;
        private System.Windows.Forms.TabPage tbpAdicionarSolTela;
        private System.Windows.Forms.DataGridView dgvDetalleConsumo;
        private System.Windows.Forms.Label lbDetalleConsumo;
        private System.Windows.Forms.TextBox txbAnio;
        private System.Windows.Forms.TextBox txbEntrada;
        private System.Windows.Forms.TextBox txbOcasionUso;
        private System.Windows.Forms.TextBox txbSku;
        private System.Windows.Forms.TextBox txbMuestrario;
        private System.Windows.Forms.Label lbSKU;
        private System.Windows.Forms.Label lbDisenador;
        private System.Windows.Forms.Label lbTema;
        private System.Windows.Forms.Label lbAyo;
        private System.Windows.Forms.Panel pnlAdicionarSolicitud;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbDisenador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpFechaTienda;
        private System.Windows.Forms.TextBox txbTema;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.Label lbTipo;
        private System.Windows.Forms.TextBox txbEnsRefDigitado;
        private System.Windows.Forms.ToolTip ttEnsayoRef;
        private System.Windows.Forms.ToolTip ttSku;
        private System.Windows.Forms.ToolTip ttTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ensayoRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn desPrenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn refTela;
        private System.Windows.Forms.DataGridViewTextBoxColumn desTela;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumos;
        private System.Windows.Forms.DataGridViewButtonColumn editar;
        private System.Windows.Forms.DataGridViewButtonColumn guardar;
    }
}

