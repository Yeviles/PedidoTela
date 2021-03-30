
namespace PedidoTela.Formularios
{
    partial class frmInicial
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
            this.btnSolicitudTelas = new System.Windows.Forms.Button();
            this.btnMontajePedidoTelas = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSolicitudTelas
            // 
            this.btnSolicitudTelas.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolicitudTelas.Location = new System.Drawing.Point(63, 140);
            this.btnSolicitudTelas.Name = "btnSolicitudTelas";
            this.btnSolicitudTelas.Size = new System.Drawing.Size(225, 65);
            this.btnSolicitudTelas.TabIndex = 1;
            this.btnSolicitudTelas.Text = "Solicitud Telas";
            this.btnSolicitudTelas.UseVisualStyleBackColor = true;
            this.btnSolicitudTelas.Click += new System.EventHandler(this.btnSolicitudTelas_Click);
            // 
            // btnMontajePedidoTelas
            // 
            this.btnMontajePedidoTelas.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMontajePedidoTelas.Location = new System.Drawing.Point(431, 140);
            this.btnMontajePedidoTelas.Name = "btnMontajePedidoTelas";
            this.btnMontajePedidoTelas.Size = new System.Drawing.Size(257, 65);
            this.btnMontajePedidoTelas.TabIndex = 2;
            this.btnMontajePedidoTelas.Text = "Montaje Pedido Telas";
            this.btnMontajePedidoTelas.UseVisualStyleBackColor = true;
            this.btnMontajePedidoTelas.Click += new System.EventHandler(this.btnMontajePedidoTelas_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(252, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Por favor seleccione una opción:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnMontajePedidoTelas);
            this.panel2.Controls.Add(this.btnSolicitudTelas);
            this.panel2.Location = new System.Drawing.Point(12, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 291);
            this.panel2.TabIndex = 4;
            // 
            // frmInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 385);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "frmInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.frmInicial_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSolicitudTelas;
        private System.Windows.Forms.Button btnMontajePedidoTelas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
    }
}