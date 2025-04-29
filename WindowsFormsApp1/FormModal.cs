using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Components;

namespace WindowsFormsApp1
{
    public partial class FormModal : Form
    {
        public FormModal(ModalEditarRol userControl, string titulo)
        {
            InitializeComponent();
            this.Controls.Add(userControl); // Añadimos el UserControl al formulario
            userControl.Dock = DockStyle.Fill; // Asegúrate de que ocupe todo el espacio
            this.Text = titulo; // <<< Cambia el título del encabezado de la ventana

        }
    }
}
