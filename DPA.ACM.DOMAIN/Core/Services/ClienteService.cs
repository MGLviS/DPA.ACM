using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Core.Services
{
    public class ClienteService : IClienteService

    {
        private readonly IClienteRepository _clienteRepository;
       //private readonly IJWTFactory _jwtFactory;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
           // _jwtFactory = jwtFactory;
        }
        public async Task<IEnumerable<ClienteDTO>> ShowClients()
        {
            var cliente = await _clienteRepository.GetAll();
            //Convert cliente to ClienteDTO
            var clienteList = new List<ClienteDTO>();
            foreach (var item in cliente)
            {
                clienteList.Add(new ClienteDTO
                {
                    ClienteId = item.ClienteId,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    CorreoElectronico = item.CorreoElectronico,
                    Telefono = item.Telefono,
                    Direccion = item.Direccion,
                    Dni = item.Dni,
                    Ruc = item.Ruc
                });
            }


            return clienteList;
        }

        //este metodo requiere un objeto de tipo clienteAuthDTO y devuelve  un objeto de tipo ClienteReponseDTO
        public async Task<ClienteReponseDTO>SignIn(ClienteAuthDTO clienteAuthDTO)
        {
            var cliente = await _clienteRepository
                .SignIn(clienteAuthDTO.CorreoElectronico, clienteAuthDTO.Password);
            if (cliente == null) return null;

            //var token = _jwtFactory.GenerateJWToken(cliente);
            //Es para otorgar datos al objeto ClienteResponseDTO que esta en la clase ClienteDTO
            var clienteDTO = new ClienteReponseDTO()
            {
                ClienteId = cliente.ClienteId,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                CorreoElectronico = cliente.CorreoElectronico,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                Dni = cliente.Dni,
                Ruc = cliente.Ruc
                //Token = token
            };
            return clienteDTO;

        }
 

    }
}
