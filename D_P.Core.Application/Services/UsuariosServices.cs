using D_B.Core.Domain.Entities;
using D_P.Core.Application.Interfaces.Repository;
using D_P.Core.Application.Interfaces.Services;
using D_P.Core.Application.VieiwModels.Resultados_Laboral;
using D_P.Core.Application.VieiwModels.Usuarios;
using D_P.Infrastucture.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_P.Core.Application.Services
{
    public class UsuariosServices : IUsuariosServices
    {
        private readonly IUsuariosRepository _usuariosRepository;

        //Inyeccion de dependencia
        public UsuariosServices(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        public async Task Update(SaveUsuariosViewmodel vm)
        {
            Usuarios usuarios = await _usuariosRepository.GetByIdAsync(vm.Id);
            usuarios.Id = vm.Id;
            usuarios.Nombre = vm.Nombre;
            usuarios.Apellido = vm.Apellido;
            usuarios.Correo = vm.Correo;
            usuarios.Usuario = vm.Usuario;
            usuarios.Contraseña = vm.Contraseña;
            usuarios.Rol = vm.Rol;

            await _usuariosRepository.UpdateAsync(usuarios);
        }

        public async Task<SaveUsuariosViewmodel> Add(SaveUsuariosViewmodel vm)
        {
            Usuarios usuarios = new();
            usuarios.Id = vm.Id;
            usuarios.Nombre = vm.Nombre;
            usuarios.Apellido = vm.Apellido;
            usuarios.Correo = vm.Correo;
            usuarios.Usuario = vm.Usuario;
            usuarios.Contraseña = vm.Contraseña;
            usuarios.Rol = vm.Rol;

            usuarios = await _usuariosRepository.AddAsync(usuarios);
           
            SaveUsuariosViewmodel usuariosvm = new();
            usuariosvm.Id = vm.Id;
            usuariosvm.Nombre = vm.Nombre;
            usuariosvm.Apellido = vm.Apellido;
            usuariosvm.Correo = vm.Correo;
            usuariosvm.Usuario = vm.Usuario;
            usuariosvm.Contraseña = vm.Contraseña;
            usuariosvm.Rol = vm.Rol;

            return usuariosvm;
        }

        public async Task Delete(int id)
        {
            var usuarios = await _usuariosRepository.GetByIdAsync(id);
            await _usuariosRepository.DeleteAsync(usuarios);
        }

        public async Task<SaveUsuariosViewmodel> GetByIdSaveViewModel(int id)
        {
            var resulT = await _usuariosRepository.GetByIdAsync(id);

            SaveUsuariosViewmodel vm = new();
            Usuarios usuarios = new();
            vm.Id = usuarios.Id;
            vm.Nombre = usuarios.Nombre;
            vm.Apellido = usuarios.Apellido;
            vm.Correo = usuarios.Correo;
            vm.Usuario = usuarios.Usuario;
            vm.Contraseña = usuarios.Contraseña;
            vm.Rol = usuarios.Rol;  

            return vm;
        }

        /*Documentacion de lo donde me quedo
        Entendi de que manera se toman y se muestran en un view y su logica, hay que cambiar los tomadores como Medicos desde 
        un Icollection a un namevariable? y en los que dan como los doctores y pacientes, dejarlos como IColletion SEGUIR CON LEONARDO*/
        public async Task<List<UsuariosViewModel>> GetAllViewModel()
        {
            var UsersList = await _usuariosRepository.GetAllAsync();

            return UsersList.Select(usuarios => new UsuariosViewModel
            {
             Id = usuarios.Id,
            Nombre = usuarios.Nombre,
            Apellido = usuarios.Apellido,
            Correo = usuarios.Correo,
            Usuario = usuarios.Usuario,
            Contraseña = usuarios.Contraseña,
            Rol = usuarios.Rol,
        }).ToList();
        }


    }
}
