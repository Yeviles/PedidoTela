
namespace PedidoTela.Formularios
{
    partial class frmAnalizarInventario
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
            this.dgvAnalizarInventario = new System.Windows.Forms.DataGridView();
            this.sel = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ensayo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.similar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tiendas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exito = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cencosoud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comercioOrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rosado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.otros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalUnidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consumo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mCalculados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mReservados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maSolicitar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSolTela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDetalleSolicitud = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnReservar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalizarInventario)).BeginInit();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAnalizarInventario
            // 
            this.dgvAnalizarInventario.AllowUserToAddRows = false;
            this.dgvAnalizarInventario.AllowUserToDeleteRows = false;
            this.dgvAnalizarInventario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnalizarInventario.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvAnalizarInventario.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAnalizarInventario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAnalizarInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnalizarInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sel,
            this.ensayo,
            this.similar,
            this.codColor,
            this.descripcionColor,
            this.tiendas,
            this.exito,
            this.cencosoud,
            this.sao,
            this.comercioOrg,
            this.rosado,
            this.otros,
            this.totalUnidades,
            this.consumo,
            this.mCalculados,
            this.mReservados,
            this.maSolicitar,
            this.idSolTela,
            this.idDetalleSolicitud});
            this.dgvAnalizarInventario.EnableHeadersVisualStyles = false;
            this.dgvAnalizarInventario.Location = new System.Drawing.Point(12, 160);
            this.dgvAnalizarInventario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvAnalizarInventario.MultiSelect = false;
            this.dgvAnalizarInventario.Name = "dgvAnalizarInventario";
            this.dgvAnalizarInventario.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvAnalizarInventario.RowHeadersVisible = false;
            this.dgvAnalizarInventario.RowHeadersWidth = 62;
            this.dgvAnalizarInventario.RowTemplate.Height = 28;
            this.dgvAnalizarInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnalizarInventario.Size = new System.Drawing.Size(1359, 551);
            this.dgvAnalizarInventario.TabIndex = 27;
            this.dgvAnalizarInventario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnalizarInventario_CellClick);
            // 
            // sel
            // 
            this.sel.HeaderText = "Sel";
            this.sel.MinimumWidth = 6;
            this.sel.Name = "sel";
            // 
            // ensayo
            // 
            this.ensayo.HeaderText = "Solicitud por";
            this.ensayo.MinimumWidth = 8;
            this.ensayo.Name = "ensayo";
            // 
            // similar
            // 
            this.similar.HeaderText = "Referencia / Ensayo";
            this.similar.MinimumWidth = 8;
            this.similar.Name = "similar";
            // 
            // codColor
            // 
            this.codColor.HeaderText = "Cod Color";
            this.codColor.MinimumWidth = 8;
            this.codColor.Name = "codColor";
            // 
            // descripcionColor
            // 
            this.descripcionColor.HeaderText = "Descripcion Color";
            this.descripcionColor.MinimumWidth = 8;
            this.descripcionColor.Name = "descripcionColor";
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
            // cencosoud
            // 
            this.cencosoud.HeaderText = "Cencosoud";
            this.cencosoud.MinimumWidth = 8;
            this.cencosoud.Name = "cencosoud";
            // 
            // sao
            // 
            this.sao.HeaderText = "SAO";
            this.sao.MinimumWidth = 8;
            this.sao.Name = "sao";
            // 
            // comercioOrg
            // 
            this.comercioOrg.HeaderText = "Comercio Org";
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
            // consumo
            // 
            this.consumo.HeaderText = "Consumo";
            this.consumo.MinimumWidth = 8;
            this.consumo.Name = "consumo";
            // 
            // mCalculados
            // 
            this.mCalculados.HeaderText = "M Calculados";
            this.mCalculados.MinimumWidth = 8;
            this.mCalculados.Name = "mCalculados";
            // 
            // mReservados
            // 
            this.mReservados.HeaderText = "M Reservados";
            this.mReservados.MinimumWidth = 8;
            this.mReservados.Name = "mReservados";
            // 
            // maSolicitar
            // 
            this.maSolicitar.HeaderText = "M A Solicitar";
            this.maSolicitar.MinimumWidth = 8;
            this.maSolicitar.Name = "maSolicitar";
            // 
            // idSolTela
            // 
            this.idSolTela.HeaderText = "idSolTela";
            this.idSolTela.MinimumWidth = 6;
            this.idSolTela.Name = "idSolTela";
            this.idSolTela.Visible = false;
            // 
            // idDetalleSolicitud
            // 
            this.idDetalleSolicitud.HeaderText = "idDetalleSolicitud";
            this.idDetalleSolicitud.MinimumWidth = 6;
            this.idDetalleSolicitud.Name = "idDetalleSolicitud";
            this.idDetalleSolicitud.Visible = false;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.btnImprimir);
            this.panel9.Controls.Add(this.btnConfirmar);
            this.panel9.Controls.Add(this.btnGrabar);
            this.panel9.Controls.Add(this.btnSalir);
            this.panel9.Controls.Add(this.btnReservar);
            this.panel9.Location = new System.Drawing.Point(12, 80);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1359, 47);
            this.panel9.TabIndex = 136;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::PedidoTela.Formularios.Properties.Resources.imprimir;
            this.btnImprimir.Location = new System.Drawing.Point(381, 2);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(126, 41);
            this.btnImprimir.TabIndex = 98;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Image = global::PedidoTela.Formularios.Properties.Resources.confirmar1;
            this.btnConfirmar.Location = new System.Drawing.Point(129, 2);
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
            this.btnGrabar.Location = new System.Drawing.Point(2, 2);
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
            this.btnSalir.Location = new System.Drawing.Point(507, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(126, 41);
            this.btnSalir.TabIndex = 97;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnReservar
            // 
            this.btnReservar.Image = global::PedidoTela.Formularios.Properties.Resources.reservar;
            this.btnReservar.Location = new System.Drawing.Point(255, 2);
            this.btnReservar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReservar.Name = "btnReservar";
            this.btnReservar.Size = new System.Drawing.Size(126, 41);
            this.btnReservar.TabIndex = 2;
            this.btnReservar.Text = "Reservar";
            this.btnReservar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReservar.UseVisualStyleBackColor = true;
            this.btnReservar.Click += new System.EventHandler(this.btnReservar_Click);
            // 
            // frmAnalizarInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 788);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.dgvAnalizarInventario);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmAnalizarInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reserva Tela";
            this.Load += new System.EventHandler(this.frmReservaTela_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnalizarInventario)).EndInit();
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.DataGridView dgvAnalizarInventario;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ensayo;
        private System.Windows.Forms.DataGridViewTextBoxColumn similar;
        private System.Windows.Forms.DataGridViewTextBoxColumn codColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn tiendas;
        private System.Windows.Forms.DataGridViewTextBoxColumn exito;
        private System.Windows.Forms.DataGridViewTextBoxColumn cencosoud;
        private System.Windows.Forms.DataGridViewTextBoxColumn sao;
        private System.Windows.Forms.DataGridViewTextBoxColumn comercioOrg;
        private System.Windows.Forms.DataGridViewTextBoxColumn rosado;
        private System.Windows.Forms.DataGridViewTextBoxColumn otros;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalUnidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn consumo;
        private System.Windows.Forms.DataGridViewTextBoxColumn mCalculados;
        private System.Windows.Forms.DataGridViewTextBoxColumn mReservados;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSolicitar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolTela;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDetalleSolicitud;
        private System.Windows.Forms.Button btnImprimir;
    }
}