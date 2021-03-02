
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnDetalleReserva = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.diseñadora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreTela = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ensayo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referencia2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Beige;
            this.pnlMenu.Controls.Add(this.btnSalir);
            this.pnlMenu.Controls.Add(this.btnDetalleReserva);
            this.pnlMenu.Location = new System.Drawing.Point(12, 74);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1243, 43);
            this.pnlMenu.TabIndex = 27;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(214, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(124, 43);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnDetalleReserva
            // 
            this.btnDetalleReserva.Location = new System.Drawing.Point(0, 0);
            this.btnDetalleReserva.Name = "btnDetalleReserva";
            this.btnDetalleReserva.Size = new System.Drawing.Size(216, 43);
            this.btnDetalleReserva.TabIndex = 0;
            this.btnDetalleReserva.Text = "Detalle Reserva";
            this.btnDetalleReserva.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.diseñadora,
            this.pedido,
            this.referencia,
            this.nombreTela,
            this.color,
            this.ensayo,
            this.referencia2});
            this.dataGridView1.Location = new System.Drawing.Point(12, 198);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1236, 537);
            this.dataGridView1.TabIndex = 28;
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
            this.referencia.HeaderText = "Referencia";
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
            // frmDetalleReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 756);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnlMenu);
            this.Name = "frmDetalleReserva";
            this.Text = "Detalle Reserva";
            this.Load += new System.EventHandler(this.frmDetalleReserva_Load);
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnDetalleReserva;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn diseñadora;
        private System.Windows.Forms.DataGridViewTextBoxColumn pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreTela;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn ensayo;
        private System.Windows.Forms.DataGridViewTextBoxColumn referencia2;
    }
}