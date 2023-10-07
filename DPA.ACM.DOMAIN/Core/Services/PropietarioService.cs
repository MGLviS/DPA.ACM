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
        private readonly IPropietarioRepository _propRespository;

        public PropietarioService(IPropietarioRepository propRespository)
        {
            _propRespository = propRespository;
        }

        public async Task<bool> RegPropietario(PropRegisterDTO propDTO)
        {
            var existuser = await _propRespository.IsEmailRegistered(propDTO.CorreoElectronico);
            if (existuser) return false;

            var prop = new Propetario()
            {
                Nombre = propDTO.Nombre,
                Apellido = propDTO.Apellido,
                CorreoElectronico = propDTO.CorreoElectronico,
                Telefono = propDTO.Telefono,
                Direccion = propDTO.Direccion,
                Dni = propDTO.Dni,
                Password = propDTO.Password,
                Taller = propDTO.Taller
            };

            var result = await _propRespository.RegPropietario(prop);
            return result;
        }
    }
}
