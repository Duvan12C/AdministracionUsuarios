namespace WindowsFormsApp1.Components
{
    partial class ModalUsuario
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lista_roles = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.estado_usuario = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.correo_usuario = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.nombre_Usuario = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guardarUsuario = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lista_roles);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.estado_usuario);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 404);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(191, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Roles";
            // 
            // lista_roles
            // 
            this.lista_roles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lista_roles.FormattingEnabled = true;
            this.lista_roles.Location = new System.Drawing.Point(194, 153);
            this.lista_roles.Name = "lista_roles";
            this.lista_roles.Size = new System.Drawing.Size(155, 21);
            this.lista_roles.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Correo electronico";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre";
            // 
            // estado_usuario
            // 
            this.estado_usuario.AutoSize = true;
            this.estado_usuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.estado_usuario.Location = new System.Drawing.Point(16, 157);
            this.estado_usuario.Name = "estado_usuario";
            this.estado_usuario.Size = new System.Drawing.Size(111, 17);
            this.estado_usuario.TabIndex = 4;
            this.estado_usuario.Text = "Estado de usuario";
            this.estado_usuario.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.correo_usuario);
            this.panel4.Location = new System.Drawing.Point(194, 85);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(155, 30);
            this.panel4.TabIndex = 3;
            // 
            // correo_usuario
            // 
            this.correo_usuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.correo_usuario.Location = new System.Drawing.Point(0, 0);
            this.correo_usuario.Name = "correo_usuario";
            this.correo_usuario.Size = new System.Drawing.Size(155, 20);
            this.correo_usuario.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.nombre_Usuario);
            this.panel3.Location = new System.Drawing.Point(14, 85);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(155, 30);
            this.panel3.TabIndex = 2;
            // 
            // nombre_Usuario
            // 
            this.nombre_Usuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nombre_Usuario.Location = new System.Drawing.Point(0, 0);
            this.nombre_Usuario.Name = "nombre_Usuario";
            this.nombre_Usuario.Size = new System.Drawing.Size(155, 20);
            this.nombre_Usuario.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.guardarUsuario);
            this.panel2.Location = new System.Drawing.Point(98, 360);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 41);
            this.panel2.TabIndex = 1;
            // 
            // guardarUsuario
            // 
            this.guardarUsuario.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.guardarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guardarUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guardarUsuario.Location = new System.Drawing.Point(0, 0);
            this.guardarUsuario.Name = "guardarUsuario";
            this.guardarUsuario.Size = new System.Drawing.Size(150, 41);
            this.guardarUsuario.TabIndex = 2;
            this.guardarUsuario.Text = "Guardar usuario";
            this.guardarUsuario.UseVisualStyleBackColor = false;
            this.guardarUsuario.Click += new System.EventHandler(this.guardarUsuario_Click);
            // 
            // ModalUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ModalUsuario";
            this.Size = new System.Drawing.Size(368, 410);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox nombre_Usuario;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button guardarUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox lista_roles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox estado_usuario;
        private System.Windows.Forms.TextBox correo_usuario;
    }
}
