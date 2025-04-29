namespace WindowsFormsApp1.View
{
    partial class UC_Usuarios
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
            this.crearUsuario = new System.Windows.Forms.Button();
            this.dataUsuarios = new System.Windows.Forms.DataGridView();
            this.id_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correo_electronico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rol_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // crearUsuario
            // 
            this.crearUsuario.BackColor = System.Drawing.Color.LimeGreen;
            this.crearUsuario.Location = new System.Drawing.Point(12, 21);
            this.crearUsuario.Name = "crearUsuario";
            this.crearUsuario.Size = new System.Drawing.Size(102, 42);
            this.crearUsuario.TabIndex = 7;
            this.crearUsuario.Text = "Crear usuario";
            this.crearUsuario.UseVisualStyleBackColor = false;
            this.crearUsuario.Click += new System.EventHandler(this.crearUsuario_Click);
            // 
            // dataUsuarios
            // 
            this.dataUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_usuario,
            this.nombre_usuario,
            this.correo_electronico,
            this.estado,
            this.rol_usuario,
            this.acciones});
            this.dataUsuarios.Location = new System.Drawing.Point(12, 69);
            this.dataUsuarios.Name = "dataUsuarios";
            this.dataUsuarios.Size = new System.Drawing.Size(643, 247);
            this.dataUsuarios.TabIndex = 6;
            this.dataUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataUsuarios_CellClick);
            this.dataUsuarios.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataUsuarios_CellMouseMove);
            this.dataUsuarios.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataUsuarios_CellPainting);
            this.dataUsuarios.MouseLeave += new System.EventHandler(this.dataUsuarios_MouseLeave);
            // 
            // id_usuario
            // 
            this.id_usuario.HeaderText = "Id usuario";
            this.id_usuario.Name = "id_usuario";
            // 
            // nombre_usuario
            // 
            this.nombre_usuario.HeaderText = "Nombre de usuario";
            this.nombre_usuario.Name = "nombre_usuario";
            // 
            // correo_electronico
            // 
            this.correo_electronico.HeaderText = "Correo electronico";
            this.correo_electronico.Name = "correo_electronico";
            this.correo_electronico.ReadOnly = true;
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            // 
            // rol_usuario
            // 
            this.rol_usuario.HeaderText = "Rol de usuario";
            this.rol_usuario.Name = "rol_usuario";
            // 
            // acciones
            // 
            this.acciones.HeaderText = "Acciones";
            this.acciones.Name = "acciones";
            // 
            // UC_Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.crearUsuario);
            this.Controls.Add(this.dataUsuarios);
            this.Name = "UC_Usuarios";
            this.Size = new System.Drawing.Size(687, 346);
            ((System.ComponentModel.ISupportInitialize)(this.dataUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button crearUsuario;
        private System.Windows.Forms.DataGridView dataUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo_electronico;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn rol_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn acciones;
    }
}
