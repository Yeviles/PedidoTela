
namespace PedidoTela.Formularios
{
    partial class frmTipoSolicitud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoSolicitud));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lbSelecciontipo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxCuePunTiras = new System.Windows.Forms.CheckBox();
            this.cbxPlanoPretenido = new System.Windows.Forms.CheckBox();
            this.cbxestampado = new System.Windows.Forms.CheckBox();
            this.cbxUnicolor = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("btnAceptar.Image")));
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(266, 297);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(133, 56);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Image = global::PedidoTela.Formularios.Properties.Resources.mbrilogout_99583;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(25, 297);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(133, 56);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lbSelecciontipo
            // 
            this.lbSelecciontipo.AutoSize = true;
            this.lbSelecciontipo.BackColor = System.Drawing.Color.Transparent;
            this.lbSelecciontipo.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelecciontipo.ForeColor = System.Drawing.Color.White;
            this.lbSelecciontipo.Location = new System.Drawing.Point(3, 0);
            this.lbSelecciontipo.Name = "lbSelecciontipo";
            this.lbSelecciontipo.Size = new System.Drawing.Size(256, 20);
            this.lbSelecciontipo.TabIndex = 6;
            this.lbSelecciontipo.Text = "Selecione el tipo de solicitud";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.cbxCuePunTiras);
            this.panel1.Controls.Add(this.cbxPlanoPretenido);
            this.panel1.Controls.Add(this.cbxestampado);
            this.panel1.Controls.Add(this.cbxUnicolor);
            this.panel1.Location = new System.Drawing.Point(25, 50);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(375, 229);
            this.panel1.TabIndex = 7;
            // 
            // cbxCuePunTiras
            // 
            this.cbxCuePunTiras.AutoSize = true;
            this.cbxCuePunTiras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCuePunTiras.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCuePunTiras.Location = new System.Drawing.Point(93, 150);
            this.cbxCuePunTiras.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxCuePunTiras.Name = "cbxCuePunTiras";
            this.cbxCuePunTiras.Size = new System.Drawing.Size(196, 24);
            this.cbxCuePunTiras.TabIndex = 7;
            this.cbxCuePunTiras.Text = "Cuellos-Puños-Tiras";
            this.cbxCuePunTiras.UseVisualStyleBackColor = true;
            this.cbxCuePunTiras.CheckedChanged += new System.EventHandler(this.cbxCuePunTiras_CheckedChanged);
            // 
            // cbxPlanoPretenido
            // 
            this.cbxPlanoPretenido.AutoSize = true;
            this.cbxPlanoPretenido.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPlanoPretenido.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxPlanoPretenido.Location = new System.Drawing.Point(93, 110);
            this.cbxPlanoPretenido.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxPlanoPretenido.Name = "cbxPlanoPretenido";
            this.cbxPlanoPretenido.Size = new System.Drawing.Size(168, 24);
            this.cbxPlanoPretenido.TabIndex = 6;
            this.cbxPlanoPretenido.Text = "Plano- Preteñido";
            this.cbxPlanoPretenido.UseVisualStyleBackColor = true;
            this.cbxPlanoPretenido.CheckedChanged += new System.EventHandler(this.cbxPlanoPretenido_CheckedChanged);
            // 
            // cbxestampado
            // 
            this.cbxestampado.AutoSize = true;
            this.cbxestampado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxestampado.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxestampado.Location = new System.Drawing.Point(93, 69);
            this.cbxestampado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxestampado.Name = "cbxestampado";
            this.cbxestampado.Size = new System.Drawing.Size(123, 24);
            this.cbxestampado.TabIndex = 5;
            this.cbxestampado.Text = "Estampado";
            this.cbxestampado.UseVisualStyleBackColor = true;
            this.cbxestampado.CheckedChanged += new System.EventHandler(this.cbxestampado_CheckedChanged);
            // 
            // cbxUnicolor
            // 
            this.cbxUnicolor.AutoSize = true;
            this.cbxUnicolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxUnicolor.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxUnicolor.Location = new System.Drawing.Point(93, 26);
            this.cbxUnicolor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxUnicolor.Name = "cbxUnicolor";
            this.cbxUnicolor.Size = new System.Drawing.Size(96, 24);
            this.cbxUnicolor.TabIndex = 4;
            this.cbxUnicolor.Text = "Unicolor";
            this.cbxUnicolor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbxUnicolor.UseVisualStyleBackColor = true;
            this.cbxUnicolor.CheckedChanged += new System.EventHandler(this.cbxUnicolor_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Navy;
            this.panel2.Controls.Add(this.lbSelecciontipo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 26);
            this.panel2.TabIndex = 8;
            // 
            // frmTipoSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(420, 376);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmTipoSolicitud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo Solicitud";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lbSelecciontipo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.CheckBox cbxUnicolor;
        public System.Windows.Forms.CheckBox cbxCuePunTiras;
        public System.Windows.Forms.CheckBox cbxPlanoPretenido;
        public System.Windows.Forms.CheckBox cbxestampado;
    }
}