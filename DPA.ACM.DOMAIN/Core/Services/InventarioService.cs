using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Interfaces;

namespace DPA.ACM.DOMAIN.Core.Services
{
    public class InventarioService : IInventarioService
    {
        private readonly IInventarioRepository _inventarioRepository;

        public InventarioService(IInventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }

        public async Task<InventarioResponseDTO> InventarioRespuesta(InventarioResponseDTO inventarioResponseDTO)
        {
            var inventario = await _inventarioRepository.GetAll();

            var inventarioDTO = new InventarioResponseDTO()
            {
                Nombre = inventarioResponseDTO.Nombre,
                Descripcion = inventarioResponseDTO.Descripcion,
                VehiculoCompatible = inventarioResponseDTO.VehiculoCompatible,
                CantidadStock = inventarioResponseDTO.CantidadStock,
                PrecioUnitario = inventarioResponseDTO.PrecioUnitario
            };
            return inventarioDTO;
        }
    }
}
