using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Entities;
using WindowsFormsApp1.Components;

namespace WindowsFormsApp1.View
{
    public partial class UC_Roles : UserControl
    {
        private readonly IRoleRepository _rolRepository;
        private int _hoveredRowIndex = -1;
        private int _hoveredColumnIndex = -1;

        public UC_Roles()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;
            _rolRepository = new RoleRepository(connectionString);

            CargarRoles();
        }

        private async Task CargarRoles()
        {
            var roles = await _rolRepository.ObtenerRoles();

            dataGridView1.Rows.Clear();

            foreach (var rol in roles)
            {
                dataGridView1.Rows.Add(rol.Id, rol.Nombre);
            }
        }


        private async Task EditarRol(int idRol, string nombreRol)
        {
            var modalEditar = new ModalEditarRol(idRol, nombreRol); // Crear el modal con los datos
            var formModal = new FormModal(modalEditar, "Editar Rol"); // Crear el FormModal con el UserControl
            formModal.ShowDialog();
            await CargarRoles();
        }

        private async Task EliminarRol(int idRol)
        {
            var confirmResult = MessageBox.Show("¿Estás seguro de eliminar este rol?",
                                                 "Confirmar Eliminación",
                                                 MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                await _rolRepository.EliminarRol(idRol);
                MessageBox.Show("Rol eliminado correctamente.");
                await CargarRoles();
            }
        }

        // <<<<< Eventos del DataGridView >>>>>

        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["acciones"].Index)
            {
                int idRol = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["id_rol"].Value);
                string nombreRol = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["nombre"].Value);

                // Calcula si hicieron click en Editar o Eliminar
                var mousePosition = dataGridView1.PointToClient(Cursor.Position);
                var cellRect = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                int buttonWidth = cellRect.Width / 2;

                if (mousePosition.X - cellRect.X < buttonWidth)
                {
                   await EditarRol(idRol, nombreRol);
                }
                else
                {
                   await EliminarRol(idRol);
                }
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["acciones"].Index)
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


        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            _hoveredRowIndex = e.RowIndex;
            _hoveredColumnIndex = e.ColumnIndex;
            dataGridView1.Invalidate(); // Redibuja el DataGridView
        }

        private void dataGridView1_MouseLeave(object sender, EventArgs e)
        {
            _hoveredRowIndex = -1;
            _hoveredColumnIndex = -1;
            dataGridView1.Invalidate();
        }

        private async void crearRol_Click_1(object sender, EventArgs e)
        {
            var modalCrear = new ModalEditarRol(); // Crear el modal con los datos
            var formModal = new FormModal(modalCrear, "Crear Rol");
            formModal.ShowDialog();
            await CargarRoles();
        }
    }
}
