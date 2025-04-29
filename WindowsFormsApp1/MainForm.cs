using System;
using System.Windows.Forms;
using WindowsFormsApp1.Components;
using WindowsFormsApp1.View;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void usuarios_Click(object sender, EventArgs e)
        {
            CargarControl(new UC_Usuarios());

        }

        private void roles_Click(object sender, EventArgs e)
        {
            CargarControl(new UC_Roles());

        }

        private void permisos_Click(object sender, EventArgs e)
        {
            CargarControl(new ModalRolPermisos());

        }
        private void CargarControl(UserControl control)
        {
            foreach (Control c in panelContenido.Controls)
            {
                c.Dispose(); 
            }

            panelContenido.Controls.Clear();

            control.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(control);
        }


    }
}
