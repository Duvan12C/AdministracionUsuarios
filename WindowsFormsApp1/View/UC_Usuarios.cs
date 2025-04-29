using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using WindowsFormsApp1.Components;

namespace WindowsFormsApp1.View
{
    public partial class UC_Usuarios : UserControl
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private int _hoveredRowIndex = -1;
        private int _hoveredColumnIndex = -1;
        public UC_Usuarios()
        {

            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;
            _usuarioRepository = new UsuarioRepository(connectionString);
            CargarUsuario();

        }



        private void crearUsuario_Click(object sender, EventArgs e)
        {
            var modalCrear = new ModalUsuario();
            var formModal = new FormModalUsuario(modalCrear, "Crear usuario");
            formModal.ShowDialog();
            CargarUsuario();
        }

        private async Task CargarUsuario()
        {
            var usuarios = await _usuarioRepository.ObtenerUsuarios();

            dataUsuarios.Rows.Clear();

            foreach (var usuario in usuarios)
            {
                dataUsuarios.Rows.Add(usuario.Id, usuario.Nombre, usuario.CorreoElectronico, usuario.Estado, usuario.Rol.Nombre);
            }
        }


        // <<<<< Eventos del DataGridView >>>>>

        private async void dataUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataUsuarios.Columns["acciones"].Index)
            {
                int idUsuario = Convert.ToInt32(dataUsuarios.Rows[e.RowIndex].Cells["id_usuario"].Value);
                string nombreUsuario = Convert.ToString(dataUsuarios.Rows[e.RowIndex].Cells["nombre_usuario"].Value);
                string correoUsuario = Convert.ToString(dataUsuarios.Rows[e.RowIndex].Cells["correo_electronico"].Value);
                bool estado = Convert.ToBoolean(dataUsuarios.Rows[e.RowIndex].Cells["estado"].Value);
                string rolUsuario = Convert.ToString(dataUsuarios.Rows[e.RowIndex].Cells["rol_usuario"].Value);

                 

                var mousePosition = dataUsuarios.PointToClient(Cursor.Position);
                var cellRect = dataUsuarios.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                int buttonWidth = cellRect.Width / 2;

                if (mousePosition.X - cellRect.X < buttonWidth)
                {
                    await EditarUsuario(idUsuario, nombreUsuario, correoUsuario, estado, rolUsuario);
                }
                else
                {
                    await EliminarUsuario(idUsuario);
                }
            }
        }

        private void dataUsuarios_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataUsuarios.Columns["acciones"].Index)
            {
                e.PaintBackground(e.CellBounds, true);

                int buttonWidth = e.CellBounds.Width / 2;
                int buttonHeight = e.CellBounds.Height - 4;
                int padding = 2;

                var editRect = new System.Drawing.Rectangle(e.CellBounds.X + padding, e.CellBounds.Y + padding, buttonWidth - padding * 2, buttonHeight);
                var deleteRect = new System.Drawing.Rectangle(e.CellBounds.X + buttonWidth + padding, e.CellBounds.Y + padding, buttonWidth - padding * 2, buttonHeight);

                ButtonRenderer.DrawButton(e.Graphics, editRect, "Editar", this.Font, false, System.Windows.Forms.VisualStyles.PushButtonState.Default);
                ButtonRenderer.DrawButton(e.Graphics, deleteRect, "Eliminar", this.Font, false, System.Windows.Forms.VisualStyles.PushButtonState.Default);

                e.Handled = true;
            }
        }


        private void dataUsuarios_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            _hoveredRowIndex = e.RowIndex;
            _hoveredColumnIndex = e.ColumnIndex;
            dataUsuarios.Invalidate(); // Redibuja el DataGridView
        }

        private void dataUsuarios_MouseLeave(object sender, EventArgs e)
        {
            _hoveredRowIndex = -1;
            _hoveredColumnIndex = -1;
            dataUsuarios.Invalidate();
        }


        private async Task EditarUsuario(int idUsuario, string nombreUsuario, string correoUsuario, bool estado, string rolUsuario)
        {
            var modalEditar = new ModalUsuario(idUsuario, nombreUsuario, correoUsuario, estado, rolUsuario);
            var formModal = new FormModalUsuario(modalEditar, "Editar Rol");
            formModal.ShowDialog();
            await CargarUsuario();
        }

        private async Task EliminarUsuario(int idUsuario)
        {
            var confirmResult = MessageBox.Show("¿Estás seguro de eliminar este usuario?",
                                                 "Confirmar Eliminación",
                                                 MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                await _usuarioRepository.EliminarUsuario(idUsuario);
                MessageBox.Show("Usuario eliminado correctamente.");
                await CargarUsuario();
            }
        }
    }
}
