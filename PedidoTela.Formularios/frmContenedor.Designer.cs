
namespace PedidoTela.Formularios
{
    partial class frmContenedor
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
            this.tabCoordinado = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlContenido2 = new System.Windows.Forms.Panel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.pnlContenido3 = new System.Windows.Forms.Panel();
            this.tabCoordinado.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCoordinado
            // 
            this.tabCoordinado.Controls.Add(this.tabPage1);
            this.tabCoordinado.Controls.Add(this.tabPage2);
            this.tabCoordinado.Controls.Add(this.tabPage3);
            this.tabCoordinado.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCoordinado.Location = new System.Drawing.Point(2, 68);
            this.tabCoordinado.Name = "tabCoordinado";
            this.tabCoordinado.SelectedIndex = 0;
            this.tabCoordinado.Size = new System.Drawing.Size(1365, 680);
            this.tabCoordinado.TabIndex = 32;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pnlContenido);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1357, 650);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Unicolor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pnlContenido
            // 
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(3, 3);
            this.pnlContenido.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1351, 644);
            this.pnlContenido.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pnlContenido2);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1357, 650);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Estampado";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlContenido2
            // 
            this.pnlContenido2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido2.Location = new System.Drawing.Point(0, 0);
            this.pnlContenido2.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContenido2.Name = "pnlContenido2";
            this.pnlContenido2.Size = new System.Drawing.Size(1357, 650);
            this.pnlContenido2.TabIndex = 4;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.pnlContenido3);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1357, 650);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Text = "Plano preteñido";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // pnlContenido3
            // 
            this.pnlContenido3.Location = new System.Drawing.Point(0, 2);
            this.pnlContenido3.Name = "pnlContenido3";
            this.pnlContenido3.Size = new System.Drawing.Size(1357, 645);
            this.pnlContenido3.TabIndex = 0;
            // 
            // frmContenedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 749);
            this.Controls.Add(this.tabCoordinado);
            this.Name = "frmContenedor";
            this.Text = "Coordinado 3 en 1";
            this.tabCoordinado.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCoordinado;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnlContenido2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel pnlContenido3;
    }
}