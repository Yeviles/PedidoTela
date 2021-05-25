
namespace PedidoTela.Formularios
{
    partial class frmDevolucion
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbConsecutivo = new System.Windows.Forms.TextBox();
            this.txtMotivo = new System.Windows.Forms.RichTextBox();
            this.btnDevolucion = new System.Windows.Forms.Button();
            this.lbInformacion = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consecutivo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Motivo:";
            // 
            // txbConsecutivo
            // 
            this.txbConsecutivo.Location = new System.Drawing.Point(109, 141);
            this.txbConsecutivo.Name = "txbConsecutivo";
            this.txbConsecutivo.Size = new System.Drawing.Size(314, 23);
            this.txbConsecutivo.TabIndex = 2;
            this.txbConsecutivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbConsecutivo_KeyPress);
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(113, 179);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(310, 199);
            this.txtMotivo.TabIndex = 142;
            this.txtMotivo.Text = "";
            // 
            // btnDevolucion
            // 
            this.btnDevolucion.Image = global::PedidoTela.Formularios.Properties.Resources.devolver;
            this.btnDevolucion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDevolucion.Location = new System.Drawing.Point(0, 0);
            this.btnDevolucion.Name = "btnDevolucion";
            this.btnDevolucion.Size = new System.Drawing.Size(142, 36);
            this.btnDevolucion.TabIndex = 143;
            this.btnDevolucion.Text = "Devolución";
            this.btnDevolucion.UseVisualStyleBackColor = true;
            this.btnDevolucion.Click += new System.EventHandler(this.btnDevolucion_Click);
            // 
            // lbInformacion
            // 
            this.lbInformacion.AutoSize = true;
            this.lbInformacion.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lbInformacion.Location = new System.Drawing.Point(12, 372);
            this.lbInformacion.Name = "lbInformacion";
            this.lbInformacion.Size = new System.Drawing.Size(0, 17);
            this.lbInformacion.TabIndex = 144;
            this.lbInformacion.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Controls.Add(this.btnDevolucion);
            this.panel1.Location = new System.Drawing.Point(4, 78);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(440, 37);
            this.panel1.TabIndex = 145;
            // 
            // frmDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 415);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbInformacion);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.txbConsecutivo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "frmDevolucion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolución";
            this.Load += new System.EventHandler(this.frmDevolucion_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbConsecutivo;
        private System.Windows.Forms.RichTextBox txtMotivo;
        private System.Windows.Forms.Button btnDevolucion;
        private System.Windows.Forms.Label lbInformacion;
        private System.Windows.Forms.Panel panel1;
    }
}