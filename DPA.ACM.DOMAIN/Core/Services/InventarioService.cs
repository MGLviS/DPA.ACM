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
    public class InventarioService : IInventarioService
    {
        private readonly IInventarioRepository _inventarioRepository;

        public InventarioService(IInventarioRepository inventarioRepository)
        {
            _inventarioRepository = inventarioRepository;
        }


        public async Task<IEnumerable<InventarioTablaDTO>> ShowTable()
        {
            var inventario = await _inventarioRepository.GetAll();

            var tablaDTO = inventario.Select(item => new InventarioTablaDTO
            {
                InventarioId = item.InventarioId,
                Nombre = item.Nombre,
                Descripcion = item.Descripcion,
                VehiculoCompatible = item.VehiculoCompatible,
                CantidadStock = item.CantidadStock,
                PrecioUnitario = item.PrecioUnitario,
            }).ToList();
                       
            return tablaDTO;
        }

        public async Task<IEnumerable<InventarioTablaDTO>> GetByName(string name)
        {
            var inventario = await _inventarioRepository.GetByName(name);

            if (inventario == null)
                return null;

            var tablaDTO = inventario.Select(item => new InventarioTablaDTO
            {
                InventarioId = item.InventarioId,
                Nombre = item.Nombre,
                Descripcion = item.Descripcion,
                VehiculoCompatible = item.VehiculoCompatible,
                CantidadStock = item.CantidadStock,
                PrecioUnitario = item.PrecioUnitario,
            }).ToList();


            return tablaDTO;
        }


    }
}
