namespace WindowsFormsApp1.Components
{
    partial class ModalEditarRol
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.nombreRol = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guardarRol = new System.Windows.Forms.Button();
            this.nameRol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nombreRol
            // 
            this.nombreRol.AutoSize = true;
            this.nombreRol.Location = new System.Drawing.Point(119, 84);
            this.nombreRol.Name = "nombreRol";
            this.nombreRol.Size = new System.Drawing.Size(44, 13);
            this.nombreRol.TabIndex = 4;
            this.nombreRol.Text = "Nombre";
            // 
            // panel1
            // 
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.guardarRol);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.nombreRol);
            this.panel1.Location = new System.Drawing.Point(49, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(191, 268);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Controls.Add(this.nameRol);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(31, 61);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(132, 137);
            this.panel2.TabIndex = 7;
            // 
            // guardarRol
            // 
            this.guardarRol.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.guardarRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guardarRol.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.guardarRol.Location = new System.Drawing.Point(0, 227);
            this.guardarRol.Name = "guardarRol";
            this.guardarRol.Size = new System.Drawing.Size(191, 41);
            this.guardarRol.TabIndex = 3;
            this.guardarRol.Text = "Guardar";
            this.guardarRol.UseVisualStyleBackColor = false;
            this.guardarRol.Click += new System.EventHandler(this.guardarRol_Click);
            // 
            // nameRol
            // 
            this.nameRol.Location = new System.Drawing.Point(18, 79);
            this.nameRol.Name = "nameRol";
            this.nameRol.Size = new System.Drawing.Size(100, 20);
            this.nameRol.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nombre";
            // 
            // ModalEditarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ModalEditarRol";
            this.Size = new System.Drawing.Size(295, 315);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label nombreRol;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button guardarRol;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox nameRol;
        private System.Windows.Forms.Label label1;
    }
}
