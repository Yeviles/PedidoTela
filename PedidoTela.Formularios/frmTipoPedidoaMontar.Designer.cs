
namespace PedidoTela.Formularios
{
    partial class frmTipoPedidoaMontar
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
            this.lbSelecciontipo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbxAgencias = new System.Windows.Forms.CheckBox();
            this.cbxCdoTresUno = new System.Windows.Forms.CheckBox();
            this.cbxCuePunTiras = new System.Windows.Forms.CheckBox();
            this.cbxPlanoPretenido = new System.Windows.Forms.CheckBox();
            this.cbxestampado = new System.Windows.Forms.CheckBox();
            this.cbxUnicolor = new System.Windows.Forms.CheckBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSelecciontipo
            // 
            this.lbSelecciontipo.AutoSize = true;
            this.lbSelecciontipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSelecciontipo.ForeColor = System.Drawing.Color.White;
            this.lbSelecciontipo.Location = new System.Drawing.Point(3, 0);
            this.lbSelecciontipo.Name = "lbSelecciontipo";
            this.lbSelecciontipo.Size = new System.Drawing.Size(280, 20);
            this.lbSelecciontipo.TabIndex = 13;
            this.lbSelecciontipo.Text = "Selecione el tipo de pedido a Montar";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.lbSelecciontipo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 31);
            this.panel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.cbxAgencias);
            this.panel2.Controls.Add(this.cbxCdoTresUno);
            this.panel2.Controls.Add(this.cbxCuePunTiras);
            this.panel2.Controls.Add(this.cbxPlanoPretenido);
            this.panel2.Controls.Add(this.cbxestampado);
            this.panel2.Controls.Add(this.cbxUnicolor);
            this.panel2.Location = new System.Drawing.Point(38, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(314, 237);
            this.panel2.TabIndex = 17;
            // 
            // cbxAgencias
            // 
            this.cbxAgencias.AutoSize = true;
            this.cbxAgencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxAgencias.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxAgencias.Location = new System.Drawing.Point(58, 184);
            this.cbxAgencias.Name = "cbxAgencias";
            this.cbxAgencias.Size = new System.Drawing.Size(193, 24);
            this.cbxAgencias.TabIndex = 9;
            this.cbxAgencias.Text = "Agencias- Externos";
            this.cbxAgencias.UseVisualStyleBackColor = true;
            this.cbxAgencias.CheckedChanged += new System.EventHandler(this.cbxAgencias_CheckedChanged);
            // 
            // cbxCdoTresUno
            // 
            this.cbxCdoTresUno.AutoSize = true;
            this.cbxCdoTresUno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCdoTresUno.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCdoTresUno.Location = new System.Drawing.Point(58, 154);
            this.cbxCdoTresUno.Name = "cbxCdoTresUno";
            this.cbxCdoTresUno.Size = new System.Drawing.Size(185, 24);
            this.cbxCdoTresUno.TabIndex = 8;
            this.cbxCdoTresUno.Text = "Coordinado 3 en 1";
            this.cbxCdoTresUno.UseVisualStyleBackColor = true;
            this.cbxCdoTresUno.CheckedChanged += new System.EventHandler(this.cbxCdoTresUno_CheckedChanged);
            // 
            // cbxCuePunTiras
            // 
            this.cbxCuePunTiras.AutoSize = true;
            this.cbxCuePunTiras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCuePunTiras.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCuePunTiras.Location = new System.Drawing.Point(58, 124);
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
            this.cbxPlanoPretenido.Location = new System.Drawing.Point(58, 94);
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
            this.cbxestampado.Location = new System.Drawing.Point(58, 64);
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
            this.cbxUnicolor.Location = new System.Drawing.Point(58, 34);
            this.cbxUnicolor.Name = "cbxUnicolor";
            this.cbxUnicolor.Size = new System.Drawing.Size(96, 24);
            this.cbxUnicolor.TabIndex = 4;
            this.cbxUnicolor.Text = "Unicolor";
            this.cbxUnicolor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbxUnicolor.UseVisualStyleBackColor = true;
            this.cbxUnicolor.CheckedChanged += new System.EventHandler(this.cbxUnicolor_CheckedChanged);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Image = global::PedidoTela.Formularios.Properties.Resources.aceptar;
            this.btnAceptar.Location = new System.Drawing.Point(229, 315);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(123, 44);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Image = global::PedidoTela.Formularios.Properties.Resources.volver;
            this.btnCancelar.Location = new System.Drawing.Point(38, 315);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(123, 44);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmTipoPedidoaMontar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(381, 390);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmTipoPedidoaMontar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo Pedido a Montar";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbSelecciontipo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbxAgencias;
        private System.Windows.Forms.CheckBox cbxCdoTresUno;
        private System.Windows.Forms.CheckBox cbxCuePunTiras;
        private System.Windows.Forms.CheckBox cbxPlanoPretenido;
        private System.Windows.Forms.CheckBox cbxestampado;
        private System.Windows.Forms.CheckBox cbxUnicolor;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
    }
}