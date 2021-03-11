
namespace PedidoTela.Formularios
{
    partial class frmEditarDsolicitudTela
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbDescripcion = new System.Windows.Forms.TextBox();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txbRefTela = new System.Windows.Forms.TextBox();
            this.lbRefTela = new System.Windows.Forms.Label();
            this.dgvRefTelas = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefTelas)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txbDescripcion);
            this.panel1.Controls.Add(this.lbDescripcion);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.txbRefTela);
            this.panel1.Controls.Add(this.lbRefTela);
            this.panel1.Location = new System.Drawing.Point(12, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(722, 56);
            this.panel1.TabIndex = 0;
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Location = new System.Drawing.Point(434, 14);
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.Size = new System.Drawing.Size(111, 22);
            this.txbDescripcion.TabIndex = 4;
            this.txbDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbDescripcion_KeyPress);
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.AutoSize = true;
            this.lbDescripcion.Location = new System.Drawing.Point(309, 20);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(118, 17);
            this.lbDescripcion.TabIndex = 3;
            this.lbDescripcion.Text = "Descripción Tela:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(551, 8);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(113, 36);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txbRefTela
            // 
            this.txbRefTela.Location = new System.Drawing.Point(154, 15);
            this.txbRefTela.Name = "txbRefTela";
            this.txbRefTela.Size = new System.Drawing.Size(134, 22);
            this.txbRefTela.TabIndex = 1;
            this.txbRefTela.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbRefTela_KeyPress);
            // 
            // lbRefTela
            // 
            this.lbRefTela.AutoSize = true;
            this.lbRefTela.Location = new System.Drawing.Point(23, 20);
            this.lbRefTela.Name = "lbRefTela";
            this.lbRefTela.Size = new System.Drawing.Size(113, 17);
            this.lbRefTela.TabIndex = 0;
            this.lbRefTela.Text = "Referencia Tela:";
            // 
            // dgvRefTelas
            // 
            this.dgvRefTelas.AllowUserToAddRows = false;
            this.dgvRefTelas.AllowUserToDeleteRows = false;
            this.dgvRefTelas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRefTelas.Location = new System.Drawing.Point(12, 145);
            this.dgvRefTelas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvRefTelas.Name = "dgvRefTelas";
            this.dgvRefTelas.ReadOnly = true;
            this.dgvRefTelas.RowHeadersWidth = 51;
            this.dgvRefTelas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRefTelas.Size = new System.Drawing.Size(722, 382);
            this.dgvRefTelas.TabIndex = 1;
            this.dgvRefTelas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRefTelas_CellDoubleClick);
            // 
            // frmEditarDsolicitudTela
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 544);
            this.Controls.Add(this.dgvRefTelas);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmEditarDsolicitudTela";
            this.Text = "Editar Solicitud Tela";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRefTelas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txbRefTela;
        private System.Windows.Forms.Label lbRefTela;
        private System.Windows.Forms.DataGridView dgvRefTelas;
        private System.Windows.Forms.TextBox txbDescripcion;
        private System.Windows.Forms.Label lbDescripcion;
    }
}