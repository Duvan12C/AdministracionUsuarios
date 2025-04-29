using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Entities;
using Microsoft.Extensions.Logging;

namespace WindowsFormsApp1.Components
{
    public partial class ModalUsuario : UserControl
    {
        private readonly RoleRepository _rolRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ILogger<ModalUsuario> _logger;

        private int? _idUsuarioSeleccionado = null;
        private string _nombreUsuario = "";
        private string _correoUsuario = "";
        private bool _estadoUsuario = false;
        private string _rolNombreSeleccionado = null;

        public ModalUsuario()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["MiConexionSQL"].ConnectionString;
            _rolRepository = new RoleRepository(connectionString);
            _usuarioRepository = new UsuarioRepository(connectionString); // Instanciamos también usuarioRepository
            this.Load += ModalUsuario_Load;
        }

        // Constructor para edición
        public ModalUsuario(int idUsuario, string nombreUsuario, string correoUsuario, bool estadoUsuario, string rolNombre) : this()
        {
            _idUsuarioSeleccionado = idUsuario;
            _nombreUsuario = nombreUsuario;
            _correoUsuario = correoUsuario;
            _estadoUsuario = estadoUsuario;
            _rolNombreSeleccionado = rolNombre;
        }

        private async void ModalUsuario_Load(object sender, EventArgs e)
        {
            await CargarRoles();

            if (_idUsuarioSeleccionado != null)
            {
                // Modo edición
                nombre_Usuario.Text = _nombreUsuario;
                correo_usuario.Text = _correoUsuario;
                estado_usuario.Checked = _estadoUsuario;

                if (!string.IsNullOrEmpty(_rolNombreSeleccionado))
                {
                    var rolEncontrado = ((List<Rol>)lista_roles.DataSource).FirstOrDefault(r => r.Nombre == _rolNombreSeleccionado);
                    if (rolEncontrado != null)
                    {
                        lista_roles.SelectedValue = rolEncontrado.Id;
                    }
                }
            }

            else
            {
                nombre_Usuario.Text = "";
                correo_usuario.Text = "";
                estado_usuario.Checked = false;
                lista_roles.SelectedIndex = 0;
            }
        }

        private async Task CargarRoles()
        {
            var roles = (await _rolRepository.ObtenerRoles()).ToList();
            roles.Insert(0, new Rol { Id = 0, Nombre = "-- Seleccione un rol --" });

            lista_roles.DataSource = roles;
            lista_roles.DisplayMember = "Nombre";
            lista_roles.ValueMember = "Id";
            lista_roles.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private async void guardarUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(nombre_Usuario.Text) || string.IsNullOrWhiteSpace(correo_usuario.Text) || lista_roles.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor complete todos los campos y seleccione un rol.");
                return;
            }

            var usuario = new Usuario
            {
                Nombre = nombre_Usuario.Text.Trim(),
                CorreoElectronico = correo_usuario.Text.Trim(),
                Estado = estado_usuario.Checked,
                RolId = (int)lista_roles.SelectedValue
            };

            try
            {
                if (_idUsuarioSeleccionado == null)
                {
                    await _usuarioRepository.CrearUsuario(usuario);
                    MessageBox.Show("Usuario creado correctamente.");
                }
                else
                {
                    usuario.Id = _idUsuarioSeleccionado.Value;
                    await _usuarioRepository.ActualizarUsuario(usuario);
                    MessageBox.Show("Usuario actualizado correctamente.");
                }

                CerrarFormularioPadre();
            }
            catch (Exception ex)
            {
                string mensaje;

                if (ex.InnerException != null)
                    mensaje = ex.InnerException.Message;
                else
                    mensaje = ex.Message;

                MessageBox.Show(mensaje);
            }


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
