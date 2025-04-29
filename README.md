# Proyecto: Administración de Usuarios

## Descripción

El proyecto **Administración de Usuarios** es una aplicación de escritorio en C# Windows Forms que permite gestionar usuarios, roles y permisos dentro de una plataforma. El sistema está diseñado para asignar y modificar permisos de los usuarios mediante una interfaz sencilla y accesible. Los usuarios pueden ser organizados en roles, y a cada rol se le pueden asignar permisos específicos que afectan las funcionalidades disponibles dentro de la plataforma.

## Funcionalidades

1. **Gestión de Roles:**
   - Crear, editar y eliminar roles dentro del sistema.
   - Asignar permisos a cada rol.
   - Asociar roles con usuarios.

2. **Gestión de Permisos:**
   - Visualizar todos los permisos disponibles en el sistema.
   - Asignar permisos a los roles mediante un `CheckedListBox`.
   - Guardar los permisos seleccionados en la base de datos.

3. **Interfaz de Usuario:**
   - Uso de controles como `ComboBox`, `CheckedListBox`, y `Button` para facilitar la gestión de usuarios, roles y permisos.
   - Visualización de roles y permisos asociados a los mismos mediante una interfaz clara y organizada.

4. **Base de Datos:**
   - Conexión a una base de datos SQL para almacenar roles, usuarios y permisos.
   - Actualización y consulta de datos en tiempo real con la base de datos.

5. **Proceso de Asignación de Permisos:**
   - Cuando se selecciona un rol, se cargan los permisos previamente asignados a ese rol.
   - El usuario puede modificar los permisos seleccionados y, al guardar, se actualizan los cambios en la base de datos.

## Requisitos

- **.NET Framework**: Este proyecto está desarrollado en **.NET Framework 4.8** o superior.
- **SQL Server**: El proyecto está vinculado a una base de datos SQL Server para almacenar la información de roles, usuarios y permisos.

## Instalación

1. Clona este repositorio en tu máquina local:

   git clone https://github.com/tuusuario/AdministracionUsuarios.git
