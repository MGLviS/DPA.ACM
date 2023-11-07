using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA.ACM.DOMAIN.Infrastructure.Repositories;

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

        public async Task<bool> CreateClient(ClienteRegisterDTO clientDTO)
        {
            var existClient = await _clienteRepository.IsEmailRegistered(clientDTO.CorreoElectronico);
            if (existClient) return false;

            var cliente = new Cliente()
            {
                Nombre = clientDTO.Nombre,
                Apellido = clientDTO.Apellido,
                CorreoElectronico = clientDTO.CorreoElectronico,
                Telefono = clientDTO.Telefono,
                Direccion = clientDTO.Direccion,
                Dni = clientDTO.Dni,
                Ruc = clientDTO.Ruc,
                Password = clientDTO.Password
            };
            var result = await _clienteRepository.RegisterCliente(cliente);
            return result;
        }

        public async Task<bool> Delete(int id)
        {
            var cliente = await _clienteRepository.Delete(id);
            if (cliente == false)
                return false;
            return cliente;
        }

        public async Task<bool> UpdateClient(int id, ClienteUpdateDTO clienteDTO)
        {

            var cliente = new Cliente()
            {
                Nombre = clienteDTO.Nombre,
                Apellido = clienteDTO.Apellido,
                CorreoElectronico = clienteDTO.CorreoElectronico,
                Telefono = clienteDTO.Telefono,
                Direccion = clienteDTO.Direccion,
                Password = clienteDTO.Password
            };

            var isCliente = await _clienteRepository.Update(id, cliente);

            if (isCliente == null)
                return false;
            return isCliente;

        }

        public async Task<IEnumerable<ClienteDTO>> GetByNaApDniRuc(string inputSearch)
        {
            var cliente = await _clienteRepository.GetByNaApDniRuc(inputSearch);
            //Convert cliente to ClienteDTO

                // Si cliente no es nulo, puedes continuar con la conversión a ClienteDTO.
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

        



    }
}
