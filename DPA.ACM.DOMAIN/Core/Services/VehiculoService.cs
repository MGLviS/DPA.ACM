using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;

namespace DPA.ACM.DOMAIN.Core.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;

        public VehiculoService(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }

        public async Task<bool> RegistroVehiculo(CrearVehiculoDTO vehiculoDTO)
        {
            var vehiculo = new Vehiculo()
            {
                Marca = vehiculoDTO.Marca,
                Modelo = vehiculoDTO.Modelo,
                Anio = vehiculoDTO.Anio,
                NumeroPlaca = vehiculoDTO.NumeroPlaca,
                ClienteId = vehiculoDTO.ClienteId,
            };

            var result = await _vehiculoRepository.InsertV(vehiculo);
            return result;
        }

        public async Task<IEnumerable<ListarVehiculoDTO>> ListaVehiculo()
        {
            var vehiculo = await _vehiculoRepository.GetAll();

            var vehiculoDTO = vehiculo.Select(item => new ListarVehiculoDTO()
            {
                VehiculoId = item.VehiculoId,
                Marca = item.Marca,
                Modelo = item.Modelo,
                Anio = item.Anio,
                NumeroPlaca = item.NumeroPlaca,
                ClienteId= item.ClienteId,
                Cliente = new ClienteListaDTO() 
                { 
                    Nombre = item.Cliente.Nombre, 
                    Apellido = item.Cliente.Apellido,
                }
            }).ToList();

            return vehiculoDTO;
        }

        public async Task<IEnumerable<ListarVehiculoDTO>> GetById(int id)
        {
            var vehiculo = await _vehiculoRepository.GetById(id);

            if (vehiculo == null)
                return null;

            var vehiculoDTO = vehiculo.Select(x => new ListarVehiculoDTO()
            {
                VehiculoId = x.VehiculoId,
                Marca = x.Marca,
                Modelo = x.Modelo,
                Anio = x.Anio,
                NumeroPlaca = x.NumeroPlaca,
                ClienteId = x.ClienteId,
                Cliente= new ClienteListaDTO()
                {
                    Nombre = x.Cliente.Nombre,
                    Apellido = x.Cliente.Apellido,
                }
            }).ToList();

            return vehiculoDTO;
        }

        public async Task<bool> ActualizarVehiculo(int id, ActualizarVehiculoDTO vehiculoDTO)
        {
            var vehiculo = new Vehiculo()
            {
                VehiculoId = id,
                Marca = vehiculoDTO.Marca,
                Modelo = vehiculoDTO.Modelo,
                Anio = vehiculoDTO.Anio,
                NumeroPlaca = vehiculoDTO.NumeroPlaca,
                ClienteId = vehiculoDTO.ClienteId,
            };

            var isVehiculo = await _vehiculoRepository.Update(id, vehiculo);

            if (isVehiculo == null)
                return false;
            return isVehiculo;
        }

        public async Task<bool> EliminarVehiculo(int id)
        {
            var vehiculo = await _vehiculoRepository.Delete(id);
            if (vehiculo == false)
                return false;
            return vehiculo;
        }
    }
}
