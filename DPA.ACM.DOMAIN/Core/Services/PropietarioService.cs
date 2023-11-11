using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.Services
{
    public class PropietarioService : IPropietarioService
    {
        private readonly IPropietarioRepository _propRepository;

        public PropietarioService(IPropietarioRepository propRepository)
        {
            _propRepository = propRepository;
        }

        public async Task<bool> RegPropietario(PropRegisterDTO propDTO)
        {
            var existProp = await _propRepository.IsEmailRegistered(propDTO.CorreoElectronico);
            if (existProp) return false;

            var prop = new Propetario()
            {
                Nombre = propDTO.Nombre,
                Apellido = propDTO.Apellido,
                CorreoElectronico = propDTO.CorreoElectronico,
                Telefono = propDTO.Telefono,
                Direccion = propDTO.Direccion,
                Dni = propDTO.Dni,
                Password = propDTO.Password,
                TallerId = propDTO.TallerId
            };

            var result = await _propRepository.RegPropietario(prop);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var propietario = await _propRepository.Delete(id);
            if (propietario == false)
                return false;
            return propietario;
        }

        public async Task<bool> Update(int id, PropietarioUpdateDTO propUpdateDTO)
        {
            var propietario = new Propetario()
            {
                Nombre = propUpdateDTO.Nombre,
                Apellido = propUpdateDTO.Apellido,
                CorreoElectronico = propUpdateDTO.CorreoElectronico,
                Telefono = propUpdateDTO.Telefono,
                Direccion = propUpdateDTO.Direccion,
                Dni = propUpdateDTO.Dni,
                Password = propUpdateDTO.Password,
                TallerId = propUpdateDTO.TallerId
            };

            var isPropietario = await _propRepository.Update(id, propietario);
            if (isPropietario == null)
                return false;
            return isPropietario;
        }

        public async Task<PropietarioResponseDTO>SignIn(PropietarioAuthDTO propietarioAuthDTO)
        {
            var propietario = await _propRepository
                .SignIn(propietarioAuthDTO.CorreoElectronico, propietarioAuthDTO.Password);
            if (propietario == null) return null;

            var propietarioDTO = new PropietarioResponseDTO()
            {
                PropietarioId = propietario.PropietarioId,
                Nombre = propietario.Nombre,
                Apellido = propietario.Apellido,
                CorreoElectronico = propietario.CorreoElectronico,
                Telefono = propietario.Telefono,
                Direccion = propietario.Direccion,
                Dni = propietario.Dni,
                TallerId = propietario.TallerId
            };
            return propietarioDTO;
        }

        public async Task<IEnumerable<PropietarioResponseDTO>> ShowPropietario()
        {
            var propietario = await _propRepository.GetAll();
            var propietarioList = new List<PropietarioResponseDTO>();
            foreach (var item in propietario)
            {
                propietarioList.Add(new PropietarioResponseDTO()
                {
                    PropietarioId = item.PropietarioId,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    CorreoElectronico=item.CorreoElectronico,
                    Telefono = item.Telefono,
                    Direccion=item.Direccion,
                    Dni=item.Dni,
                    Password = item.Password,
                    TallerId=item.TallerId

                });
            }
            return propietarioList;
        }
    }
}
