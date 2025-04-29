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
    public partial class FormModalUsuario : Form
    {
        public FormModalUsuario(ModalUsuario userControl, string titulo)
        {
            InitializeComponent();
            this.Controls.Add(userControl); 
            userControl.Dock = DockStyle.Fill;
            this.Text = titulo;
        }
    }
}
