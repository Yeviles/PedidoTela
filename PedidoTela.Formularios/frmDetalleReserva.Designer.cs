
namespace PedidoTela.Formularios
{
    partial class frmDetalleReserva
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
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.lbTotal = new System.Windows.Forms.Label();
            this.txbTotal = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.diseñadora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreTela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ensayo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referencia2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantReservado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idSolTela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.panel9.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.diseñadora,
            this.pedido,
            this.referencia,
            this.nombreTela,
            this.color,
            this.ensayo,
            this.referencia2,
            this.cantReservado,
            this.idSolTela});
            this.dgvDetalle.EnableHeadersVisualStyles = false;
            this.dgvDetalle.Location = new System.Drawing.Point(22, 187);
            this.dgvDetalle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvDetalle.RowHeadersWidth = 62;
            this.dgvDetalle.RowTemplate.Height = 28;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(1349, 511);
            this.dgvDetalle.TabIndex = 28;
            this.dgvDetalle.CurrentCellChanged += new System.EventHandler(this.dgvDetalle_CurrentCellChanged);
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(1172, 730);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(41, 17);
            this.lbTotal.TabIndex = 29;
            this.lbTotal.Text = "Total";
            // 
            // txbTotal
            // 
            this.txbTotal.Location = new System.Drawing.Point(1245, 725);
            this.txbTotal.Name = "txbTotal";
            this.txbTotal.Size = new System.Drawing.Size(112, 23);
            this.txbTotal.TabIndex = 30;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.button1);
            this.panel9.Location = new System.Drawing.Point(12, 81);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(1359, 56);
            this.panel9.TabIndex = 137;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::PedidoTela.Formularios.Properties.Resources.logout_exit_icon_176185;
            this.button1.Location = new System.Drawing.Point(4, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(174, 50);
            this.button1.TabIndex = 97;
            this.button1.Text = "Salir";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // diseñadora
            // 
            this.diseñadora.HeaderText = "Diseñadora";
            this.diseñadora.MinimumWidth = 8;
            this.diseñadora.Name = "diseñadora";
            this.diseñadora.ReadOnly = true;
            // 
            // pedido
            // 
            this.pedido.HeaderText = "Pedido";
            this.pedido.MinimumWidth = 8;
            this.pedido.Name = "pedido";
            this.pedido.ReadOnly = true;
            // 
            // referencia
            // 
            this.referencia.HeaderText = "Referencia / Ensayo";
            this.referencia.MinimumWidth = 8;
            this.referencia.Name = "referencia";
            this.referencia.ReadOnly = true;
            // 
            // nombreTela
            // 
            this.nombreTela.HeaderText = "Nombre Tela";
            this.nombreTela.MinimumWidth = 8;
            this.nombreTela.Name = "nombreTela";
            this.nombreTela.ReadOnly = true;
            // 
            // color
            // 
            this.color.HeaderText = "Color";
            this.color.MinimumWidth = 8;
            this.color.Name = "color";
            this.color.ReadOnly = true;
            // 
            // ensayo
            // 
            this.ensayo.HeaderText = "Ensayo";
            this.ensayo.MinimumWidth = 8;
            this.ensayo.Name = "ensayo";
            this.ensayo.ReadOnly = true;
            // 
            // referencia2
            // 
            this.referencia2.HeaderText = "Referencia 2";
            this.referencia2.MinimumWidth = 8;
            this.referencia2.Name = "referencia2";
            this.referencia2.ReadOnly = true;
            // 
            // cantReservado
            // 
            this.cantReservado.HeaderText = "Cantidad Reservado";
            this.cantReservado.MinimumWidth = 6;
            this.cantReservado.Name = "cantReservado";
            this.cantReservado.ReadOnly = true;
            // 
            // idSolTela
            // 
            this.idSolTela.HeaderText = "idSolTela";
            this.idSolTela.MinimumWidth = 6;
            this.idSolTela.Name = "idSolTela";
            this.idSolTela.ReadOnly = true;
            this.idSolTela.Visible = false;
            // 
            // frmDetalleReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 788);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.txbTotal);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.dgvDetalle);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDetalleReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle Reserva";
            this.Load += new System.EventHandler(this.frmDetalleReserva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.panel9.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.TextBox txbTotal;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn diseñadora;
        private System.Windows.Forms.DataGridViewTextBoxColumn pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreTela;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn ensayo;
        private System.Windows.Forms.DataGridViewTextBoxColumn referencia2;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantReservado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSolTela;
    }
}