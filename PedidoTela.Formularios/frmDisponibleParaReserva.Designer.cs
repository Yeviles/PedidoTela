
namespace PedidoTela.Formularios
{
    partial class frmDisponibleParaReserva
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
            this.dgvDisponibleReservar = new System.Windows.Forms.DataGridView();
            this.lbDisponible = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnDetalleReserva = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.diseñadora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreTela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disponible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadReservado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disponibleTeorico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.metrosaReservar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisponibleReservar)).BeginInit();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDisponibleReservar
            // 
            this.dgvDisponibleReservar.AllowUserToAddRows = false;
            this.dgvDisponibleReservar.AllowUserToDeleteRows = false;
            this.dgvDisponibleReservar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDisponibleReservar.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDisponibleReservar.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDisponibleReservar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDisponibleReservar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisponibleReservar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.diseñadora,
            this.pedido,
            this.referencia,
            this.nombreTela,
            this.color,
            this.estado,
            this.disponible,
            this.cantidadReservado,
            this.disponibleTeorico,
            this.metrosaReservar});
            this.dgvDisponibleReservar.EnableHeadersVisualStyles = false;
            this.dgvDisponibleReservar.Location = new System.Drawing.Point(12, 220);
            this.dgvDisponibleReservar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDisponibleReservar.MultiSelect = false;
            this.dgvDisponibleReservar.Name = "dgvDisponibleReservar";
            this.dgvDisponibleReservar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvDisponibleReservar.RowHeadersWidth = 62;
            this.dgvDisponibleReservar.RowTemplate.Height = 28;
            this.dgvDisponibleReservar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDisponibleReservar.Size = new System.Drawing.Size(1359, 546);
            this.dgvDisponibleReservar.TabIndex = 28;
            this.dgvDisponibleReservar.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDisponibleReservar_CellEndEdit);
            // 
            // lbDisponible
            // 
            this.lbDisponible.AutoSize = true;
            this.lbDisponible.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDisponible.Location = new System.Drawing.Point(12, 182);
            this.lbDisponible.Name = "lbDisponible";
            this.lbDisponible.Size = new System.Drawing.Size(179, 19);
            this.lbDisponible.TabIndex = 29;
            this.lbDisponible.Text = "Disponible para Reserva";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.btnDetalleReserva);
            this.panel9.Controls.Add(this.btnGrabar);
            this.panel9.Controls.Add(this.btnSalir);
            this.panel9.Location = new System.Drawing.Point(12, 87);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1359, 56);
            this.panel9.TabIndex = 137;
            // 
            // btnDetalleReserva
            // 
            this.btnDetalleReserva.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleReserva.Image = global::PedidoTela.Formularios.Properties.Resources._1492790860_8check_84164;
            this.btnDetalleReserva.Location = new System.Drawing.Point(4, 2);
            this.btnDetalleReserva.Name = "btnDetalleReserva";
            this.btnDetalleReserva.Size = new System.Drawing.Size(209, 50);
            this.btnDetalleReserva.TabIndex = 96;
            this.btnDetalleReserva.Text = "Detalle Reserva";
            this.btnDetalleReserva.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDetalleReserva.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDetalleReserva.UseVisualStyleBackColor = true;
            this.btnDetalleReserva.Click += new System.EventHandler(this.btnDetalleReserva_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.BackColor = System.Drawing.Color.LightGray;
            this.btnGrabar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGrabar.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrabar.Image = global::PedidoTela.Formularios.Properties.Resources.record_icon_icons_com_64775__1_;
            this.btnGrabar.Location = new System.Drawing.Point(214, 2);
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
            this.btnSalir.Location = new System.Drawing.Point(388, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(174, 50);
            this.btnSalir.TabIndex = 97;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // diseñadora
            // 
            this.diseñadora.HeaderText = "Diseñadora";
            this.diseñadora.MinimumWidth = 8;
            this.diseñadora.Name = "diseñadora";
            // 
            // pedido
            // 
            this.pedido.HeaderText = "Pedido";
            this.pedido.MinimumWidth = 8;
            this.pedido.Name = "pedido";
            // 
            // referencia
            // 
            this.referencia.HeaderText = "Ensayo / Ref";
            this.referencia.MinimumWidth = 8;
            this.referencia.Name = "referencia";
            // 
            // nombreTela
            // 
            this.nombreTela.HeaderText = "Nombre Tela";
            this.nombreTela.MinimumWidth = 8;
            this.nombreTela.Name = "nombreTela";
            // 
            // color
            // 
            this.color.HeaderText = "Color";
            this.color.MinimumWidth = 8;
            this.color.Name = "color";
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.MinimumWidth = 8;
            this.estado.Name = "estado";
            // 
            // disponible
            // 
            this.disponible.HeaderText = "Disponible";
            this.disponible.MinimumWidth = 8;
            this.disponible.Name = "disponible";
            // 
            // cantidadReservado
            // 
            this.cantidadReservado.HeaderText = "Cantidad Reservado";
            this.cantidadReservado.MinimumWidth = 8;
            this.cantidadReservado.Name = "cantidadReservado";
            // 
            // disponibleTeorico
            // 
            this.disponibleTeorico.HeaderText = "Disponible Teórico";
            this.disponibleTeorico.MinimumWidth = 8;
            this.disponibleTeorico.Name = "disponibleTeorico";
            // 
            // metrosaReservar
            // 
            this.metrosaReservar.HeaderText = "Metros a Reservar";
            this.metrosaReservar.MinimumWidth = 8;
            this.metrosaReservar.Name = "metrosaReservar";
            // 
            // frmDisponibleParaReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 788);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.lbDisponible);
            this.Controls.Add(this.dgvDisponibleReservar);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmDisponibleParaReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Disponible Para Reserva";
            this.Load += new System.EventHandler(this.frmDisponibleParaReserva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisponibleReservar)).EndInit();
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDisponibleReservar;
        private System.Windows.Forms.Label lbDisponible;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button btnDetalleReserva;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn diseñadora;
        private System.Windows.Forms.DataGridViewTextBoxColumn pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreTela;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn disponible;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadReservado;
        private System.Windows.Forms.DataGridViewTextBoxColumn disponibleTeorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn metrosaReservar;
    }
}