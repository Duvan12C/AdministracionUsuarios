namespace WindowsFormsApp1
{
    partial class MainForm
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.usuarios = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.permisos = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.roles = new System.Windows.Forms.Button();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 52);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.usuarios);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(116, 46);
            this.panel4.TabIndex = 3;
            // 
            // usuarios
            // 
            this.usuarios.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.usuarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.usuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usuarios.Location = new System.Drawing.Point(0, 0);
            this.usuarios.Name = "usuarios";
            this.usuarios.Size = new System.Drawing.Size(116, 46);
            this.usuarios.TabIndex = 2;
            this.usuarios.Text = "Usuarios";
            this.usuarios.UseVisualStyleBackColor = false;
            this.usuarios.Click += new System.EventHandler(this.usuarios_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.permisos);
            this.panel3.Location = new System.Drawing.Point(237, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(116, 46);
            this.panel3.TabIndex = 2;
            // 
            // permisos
            // 
            this.permisos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.permisos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.permisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.permisos.Location = new System.Drawing.Point(0, 0);
            this.permisos.Name = "permisos";
            this.permisos.Size = new System.Drawing.Size(116, 46);
            this.permisos.TabIndex = 1;
            this.permisos.Text = "Permisos";
            this.permisos.UseVisualStyleBackColor = false;
            this.permisos.Click += new System.EventHandler(this.permisos_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.roles);
            this.panel2.Location = new System.Drawing.Point(119, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(116, 46);
            this.panel2.TabIndex = 1;
            // 
            // roles
            // 
            this.roles.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.roles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.roles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.roles.Location = new System.Drawing.Point(0, 0);
            this.roles.Name = "roles";
            this.roles.Size = new System.Drawing.Size(116, 46);
            this.roles.TabIndex = 0;
            this.roles.Text = "Roles";
            this.roles.UseVisualStyleBackColor = false;
            this.roles.Click += new System.EventHandler(this.roles_Click);
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelContenido.Location = new System.Drawing.Point(1, 54);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(793, 348);
            this.panelContenido.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 404);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button roles;
        private System.Windows.Forms.Button permisos;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button usuarios;
        private System.Windows.Forms.Panel panelContenido;
    }
}