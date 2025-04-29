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
using DataAccess.Repositories;
using Entities;

namespace WindowsFormsApp1.Components
{
    public partial class ModalEditarRol : UserControl
    {

        private readonly RoleRepository _rolRepository;
        private int? _idRolSeleccionado = null; // Para manejar si es crear o editar

        public ModalEditarRol()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;
            _rolRepository = new RoleRepository(connectionString);
        }

        public ModalEditarRol(int idRol, string nombreRol) : this() 
        {
            _idRolSeleccionado = idRol;
            nameRol.Text = nombreRol;
        }

        private void guardarRol_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nameRol.Text))
            {
                MessageBox.Show("Por favor ingresa un nombre de rol.");
                return;
            }

            if (_idRolSeleccionado == null)
            {
                var nuevoRol = new Rol
                {
                    Nombre = nameRol.Text.Trim()
                };

                _rolRepository.CrearRol(nuevoRol);
                MessageBox.Show("Rol guardado correctamente.");
            }
            else
            {
                var rolActualizado = new Rol
                {
                    Id = _idRolSeleccionado.Value,
                    Nombre = nameRol.Text.Trim()
                };

                _rolRepository.ActualizarRol(rolActualizado);
                MessageBox.Show("Rol actualizado correctamente.");
            }

            nameRol.Clear();
            CerrarFormularioPadre();

        }

        private void CerrarFormularioPadre()
        {
            Form formularioPadre = this.FindForm();
            if (formularioPadre != null)
            {
                formularioPadre.Close();
            }
        }

    }
}
