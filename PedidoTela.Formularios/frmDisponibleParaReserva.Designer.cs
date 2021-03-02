
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
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
            this.lbDisponible = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Beige;
            this.pnlMenu.Controls.Add(this.btnSalir);
            this.pnlMenu.Controls.Add(this.btnGrabar);
            this.pnlMenu.Controls.Add(this.btnConfirmar);
            this.pnlMenu.Location = new System.Drawing.Point(8, 70);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1218, 43);
            this.pnlMenu.TabIndex = 27;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(358, 0);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(124, 43);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(241, 0);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(124, 43);
            this.btnGrabar.TabIndex = 0;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(0, 0);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(244, 43);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "Detalle Reserva";
            this.btnConfirmar.UseVisualStyleBackColor = true;
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
            this.estado,
            this.disponible,
            this.cantidadReservado,
            this.disponibleTeorico,
            this.metrosaReservar});
            this.dataGridView1.Location = new System.Drawing.Point(12, 169);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1215, 560);
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
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.MinimumWidth = 8;
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            // 
            // disponible
            // 
            this.disponible.HeaderText = "Disponible";
            this.disponible.MinimumWidth = 8;
            this.disponible.Name = "disponible";
            this.disponible.ReadOnly = true;
            // 
            // cantidadReservado
            // 
            this.cantidadReservado.HeaderText = "Cantidad Reservado";
            this.cantidadReservado.MinimumWidth = 8;
            this.cantidadReservado.Name = "cantidadReservado";
            this.cantidadReservado.ReadOnly = true;
            // 
            // disponibleTeorico
            // 
            this.disponibleTeorico.HeaderText = "Disponible Teórico";
            this.disponibleTeorico.MinimumWidth = 8;
            this.disponibleTeorico.Name = "disponibleTeorico";
            this.disponibleTeorico.ReadOnly = true;
            // 
            // metrosaReservar
            // 
            this.metrosaReservar.HeaderText = "Metros a Reservar";
            this.metrosaReservar.MinimumWidth = 8;
            this.metrosaReservar.Name = "metrosaReservar";
            this.metrosaReservar.ReadOnly = true;
            // 
            // lbDisponible
            // 
            this.lbDisponible.AutoSize = true;
            this.lbDisponible.Location = new System.Drawing.Point(13, 143);
            this.lbDisponible.Name = "lbDisponible";
            this.lbDisponible.Size = new System.Drawing.Size(182, 20);
            this.lbDisponible.TabIndex = 29;
            this.lbDisponible.Text = "Disponible para Reserva";
            // 
            // frmDisponibleParaReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 756);
            this.Controls.Add(this.lbDisponible);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnlMenu);
            this.Name = "frmDisponibleParaReserva";
            this.Text = "Disponible Para Reserva";
            this.Load += new System.EventHandler(this.frmDisponibleParaReserva_Load);
            this.pnlMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.DataGridView dataGridView1;
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
        private System.Windows.Forms.Label lbDisponible;
    }
}