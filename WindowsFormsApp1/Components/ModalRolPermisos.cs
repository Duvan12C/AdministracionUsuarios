using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Entities;

namespace WindowsFormsApp1.Components
{
    public partial class ModalRolPermisos : UserControl
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRolPermisoRepository _rolPermisoRepository;
        private readonly IPermisoRepository _permisoRepository;
        private IEnumerable<Permiso> permisos = new List<Permiso>(); // Para almacenar los permisos disponibles

        public ModalRolPermisos()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;
            _roleRepository = new RoleRepository(connectionString);
            _rolPermisoRepository = new RolPermisoRepository(connectionString);
            _permisoRepository = new PermisoRepository(connectionString);

            CargarRoles();
            CargarPermisos();
        }

        // Cargar roles en el ComboBox
        private async Task CargarRoles()
        {
            var roles = (await _roleRepository.ObtenerRoles()).ToList();
            roles.Insert(0, new Rol { Id = 0, Nombre = "-- Seleccione un rol --" });

            comboRoles.DataSource = roles;
            comboRoles.DisplayMember = "Nombre";
            comboRoles.ValueMember = "Id";
            comboRoles.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        // Cargar permisos en el CheckedListBox
        private async void CargarPermisos()
        {
            permisos = await _permisoRepository.ObtenerPermisos(); // Obtener todos los permisos
            checkedListPermisos.Items.Clear(); // Limpiar el CheckedListBox

            foreach (var permiso in permisos)
            {
                checkedListPermisos.Items.Add(permiso.Nombre, false); // Agregar permisos, todos inicialmente desmarcados
            }
        }

        private async void comboRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rolSeleccionado = (Rol)comboRoles.SelectedItem;

            if (rolSeleccionado != null && rolSeleccionado.Id > 0) // Asegúrate de que se haya seleccionado un rol válido
            {
                var permisosDelRol = await _rolPermisoRepository.ObtenerPermisosPorRol(rolSeleccionado.Id); // Obtener permisos del rol

                // Itera sobre los items del CheckedListBox
                for (int i = 0; i < checkedListPermisos.Items.Count; i++)
                {
                    var permisoNombre = checkedListPermisos.Items[i].ToString();
                    var permiso = permisosDelRol.FirstOrDefault(p => p.Nombre == permisoNombre);

                    // Marca el permiso si está asignado a este rol
                    checkedListPermisos.SetItemChecked(i, permiso != null);
                }
            }
        }

        // Guardar los permisos seleccionados en la base de datos
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var rolSeleccionado = (Rol)comboRoles.SelectedItem;

            if (rolSeleccionado != null && rolSeleccionado.Id > 0)
            {
                var permisosSeleccionados = new List<int>();

                // Itera sobre los items seleccionados
                foreach (var item in checkedListPermisos.CheckedItems)
                {
                    // Encuentra el permiso correspondiente al nombre
                    var permiso = permisos.FirstOrDefault(p => p.Nombre == item.ToString());
                    if (permiso != null)
                    {
                        permisosSeleccionados.Add(permiso.Id);
                    }
                }

                // Guarda los permisos seleccionados en la base de datos
                await _rolPermisoRepository.ActualizarPermisos(rolSeleccionado.Id, permisosSeleccionados);

                MessageBox.Show("Permisos asignados correctamente.");
            }
        }
    }
}
