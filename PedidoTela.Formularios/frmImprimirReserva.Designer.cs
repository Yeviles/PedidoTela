
namespace PedidoTela.Formularios
{
    partial class frmImprimirReserva
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ReporteReservaTelaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlInicial = new System.Windows.Forms.Panel();
            this.cbxEntrada = new System.Windows.Forms.ComboBox();
            this.cbxTema = new System.Windows.Forms.ComboBox();
            this.cbxMuestrario = new System.Windows.Forms.ComboBox();
            this.cbxTipoSolicitud = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.lbMuestrario = new System.Windows.Forms.Label();
            this.txbEnsayoRef = new System.Windows.Forms.TextBox();
            this.lbTema = new System.Windows.Forms.Label();
            this.lbEntrada = new System.Windows.Forms.Label();
            this.lbEnsayo = new System.Windows.Forms.Label();
            this.lbTipoSolicitud = new System.Windows.Forms.Label();
            this.dgvReserva = new System.Windows.Forms.DataGridView();
            this.ensayoReferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Muestrario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tema = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ReporteReservaTelaBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlInicial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReserva)).BeginInit();
            this.SuspendLayout();
            // 
            // ReporteReservaTelaBindingSource
            // 
            this.ReporteReservaTelaBindingSource.DataSource = typeof(PedidoTela.Entidades.Logica.ReporteReservaTela);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Location = new System.Drawing.Point(0, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1366, 49);
            this.panel1.TabIndex = 26;
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Image = global::PedidoTela.Formularios.Properties.Resources.logout_exit_icon_176185;
            this.btnSalir.Location = new System.Drawing.Point(3, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(174, 42);
            this.btnSalir.TabIndex = 98;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlInicial
            // 
            this.pnlInicial.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pnlInicial.Controls.Add(this.cbxEntrada);
            this.pnlInicial.Controls.Add(this.cbxTema);
            this.pnlInicial.Controls.Add(this.cbxMuestrario);
            this.pnlInicial.Controls.Add(this.cbxTipoSolicitud);
            this.pnlInicial.Controls.Add(this.btnConsultar);
            this.pnlInicial.Controls.Add(this.lbMuestrario);
            this.pnlInicial.Controls.Add(this.txbEnsayoRef);
            this.pnlInicial.Controls.Add(this.lbTema);
            this.pnlInicial.Controls.Add(this.lbEntrada);
            this.pnlInicial.Controls.Add(this.lbEnsayo);
            this.pnlInicial.Controls.Add(this.lbTipoSolicitud);
            this.pnlInicial.Location = new System.Drawing.Point(4, 119);
            this.pnlInicial.Name = "pnlInicial";
            this.pnlInicial.Size = new System.Drawing.Size(1358, 80);
            this.pnlInicial.TabIndex = 61;
            // 
            // cbxEntrada
            // 
            this.cbxEntrada.FormattingEnabled = true;
            this.cbxEntrada.Location = new System.Drawing.Point(927, 10);
            this.cbxEntrada.Name = "cbxEntrada";
            this.cbxEntrada.Size = new System.Drawing.Size(224, 21);
            this.cbxEntrada.TabIndex = 65;
            // 
            // cbxTema
            // 
            this.cbxTema.FormattingEnabled = true;
            this.cbxTema.Location = new System.Drawing.Point(533, 41);
            this.cbxTema.Name = "cbxTema";
            this.cbxTema.Size = new System.Drawing.Size(224, 21);
            this.cbxTema.TabIndex = 64;
            // 
            // cbxMuestrario
            // 
            this.cbxMuestrario.FormattingEnabled = true;
            this.cbxMuestrario.Location = new System.Drawing.Point(533, 10);
            this.cbxMuestrario.Name = "cbxMuestrario";
            this.cbxMuestrario.Size = new System.Drawing.Size(224, 21);
            this.cbxMuestrario.TabIndex = 62;
            // 
            // cbxTipoSolicitud
            // 
            this.cbxTipoSolicitud.FormattingEnabled = true;
            this.cbxTipoSolicitud.Location = new System.Drawing.Point(150, 9);
            this.cbxTipoSolicitud.Name = "cbxTipoSolicitud";
            this.cbxTipoSolicitud.Size = new System.Drawing.Size(224, 21);
            this.cbxTipoSolicitud.TabIndex = 60;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = global::PedidoTela.Formularios.Properties.Resources.finger_hand_5531;
            this.btnConsultar.Location = new System.Drawing.Point(1173, 9);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(167, 58);
            this.btnConsultar.TabIndex = 59;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // lbMuestrario
            // 
            this.lbMuestrario.AutoSize = true;
            this.lbMuestrario.Location = new System.Drawing.Point(417, 13);
            this.lbMuestrario.Name = "lbMuestrario";
            this.lbMuestrario.Size = new System.Drawing.Size(59, 13);
            this.lbMuestrario.TabIndex = 26;
            this.lbMuestrario.Text = "Muestrario:";
            // 
            // txbEnsayoRef
            // 
            this.txbEnsayoRef.Location = new System.Drawing.Point(150, 41);
            this.txbEnsayoRef.Name = "txbEnsayoRef";
            this.txbEnsayoRef.Size = new System.Drawing.Size(224, 20);
            this.txbEnsayoRef.TabIndex = 57;
            // 
            // lbTema
            // 
            this.lbTema.AutoSize = true;
            this.lbTema.Location = new System.Drawing.Point(417, 44);
            this.lbTema.Name = "lbTema";
            this.lbTema.Size = new System.Drawing.Size(37, 13);
            this.lbTema.TabIndex = 28;
            this.lbTema.Text = "Tema:";
            // 
            // lbEntrada
            // 
            this.lbEntrada.AutoSize = true;
            this.lbEntrada.Location = new System.Drawing.Point(811, 13);
            this.lbEntrada.Name = "lbEntrada";
            this.lbEntrada.Size = new System.Drawing.Size(47, 13);
            this.lbEntrada.TabIndex = 29;
            this.lbEntrada.Text = "Entrada:";
            // 
            // lbEnsayo
            // 
            this.lbEnsayo.AutoSize = true;
            this.lbEnsayo.Location = new System.Drawing.Point(34, 45);
            this.lbEnsayo.Name = "lbEnsayo";
            this.lbEnsayo.Size = new System.Drawing.Size(102, 13);
            this.lbEnsayo.TabIndex = 30;
            this.lbEnsayo.Text = "Ensayo/Referencia:";
            // 
            // lbTipoSolicitud
            // 
            this.lbTipoSolicitud.AutoSize = true;
            this.lbTipoSolicitud.Location = new System.Drawing.Point(34, 17);
            this.lbTipoSolicitud.Name = "lbTipoSolicitud";
            this.lbTipoSolicitud.Size = new System.Drawing.Size(74, 13);
            this.lbTipoSolicitud.TabIndex = 40;
            this.lbTipoSolicitud.Text = "Tipo Solicitud:";
            // 
            // dgvReserva
            // 
            this.dgvReserva.AllowUserToAddRows = false;
            this.dgvReserva.AllowUserToDeleteRows = false;
            this.dgvReserva.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReserva.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReserva.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReserva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReserva.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ensayoReferencia,
            this.Muestrario,
            this.tema,
            this.entrada,
            this.pedido,
            this.codigoColor,
            this.cantidad});
            this.dgvReserva.EnableHeadersVisualStyles = false;
            this.dgvReserva.Location = new System.Drawing.Point(3, 204);
            this.dgvReserva.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvReserva.MultiSelect = false;
            this.dgvReserva.Name = "dgvReserva";
            this.dgvReserva.ReadOnly = true;
            this.dgvReserva.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvReserva.RowHeadersVisible = false;
            this.dgvReserva.RowHeadersWidth = 62;
            this.dgvReserva.RowTemplate.Height = 28;
            this.dgvReserva.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReserva.Size = new System.Drawing.Size(560, 534);
            this.dgvReserva.TabIndex = 62;
            // 
            // ensayoReferencia
            // 
            this.ensayoReferencia.HeaderText = "Referencia / Ensayo";
            this.ensayoReferencia.MinimumWidth = 8;
            this.ensayoReferencia.Name = "ensayoReferencia";
            this.ensayoReferencia.ReadOnly = true;
            // 
            // Muestrario
            // 
            this.Muestrario.HeaderText = "Muestrario";
            this.Muestrario.MinimumWidth = 8;
            this.Muestrario.Name = "Muestrario";
            this.Muestrario.ReadOnly = true;
            // 
            // tema
            // 
            this.tema.HeaderText = "Tema";
            this.tema.MinimumWidth = 8;
            this.tema.Name = "tema";
            this.tema.ReadOnly = true;
            // 
            // entrada
            // 
            this.entrada.HeaderText = "Entrada";
            this.entrada.MinimumWidth = 8;
            this.entrada.Name = "entrada";
            this.entrada.ReadOnly = true;
            // 
            // pedido
            // 
            this.pedido.HeaderText = "No de pedido reservado";
            this.pedido.MinimumWidth = 8;
            this.pedido.Name = "pedido";
            this.pedido.ReadOnly = true;
            // 
            // codigoColor
            // 
            this.codigoColor.HeaderText = "Color pedido";
            this.codigoColor.MinimumWidth = 8;
            this.codigoColor.Name = "codigoColor";
            this.codigoColor.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad reservada";
            this.cantidad.MinimumWidth = 8;
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.ReporteReservaTelaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PedidoTela.Formularios.PDFReporteReserva.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(569, 204);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(793, 534);
            this.reportViewer1.TabIndex = 63;
            // 
            // frmImprimirReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 749);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.dgvReserva);
            this.Controls.Add(this.pnlInicial);
            this.Controls.Add(this.panel1);
            this.Name = "frmImprimirReserva";
            this.Text = "Imprimir reserva";
            this.Load += new System.EventHandler(this.frmImprimirSIP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ReporteReservaTelaBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlInicial.ResumeLayout(false);
            this.pnlInicial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReserva)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlInicial;
        private System.Windows.Forms.ComboBox cbxEntrada;
        private System.Windows.Forms.ComboBox cbxTema;
        private System.Windows.Forms.ComboBox cbxMuestrario;
        private System.Windows.Forms.ComboBox cbxTipoSolicitud;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Label lbMuestrario;
        private System.Windows.Forms.TextBox txbEnsayoRef;
        private System.Windows.Forms.Label lbTema;
        private System.Windows.Forms.Label lbEntrada;
        private System.Windows.Forms.Label lbEnsayo;
        private System.Windows.Forms.Label lbTipoSolicitud;
        private System.Windows.Forms.DataGridView dgvReserva;
        private System.Windows.Forms.DataGridViewTextBoxColumn ensayoReferencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Muestrario;
        private System.Windows.Forms.DataGridViewTextBoxColumn tema;
        private System.Windows.Forms.DataGridViewTextBoxColumn entrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReporteReservaTelaBindingSource;
    }
}