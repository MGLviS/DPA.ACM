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
    public class DetInvService : IDetInvService
    {
        private readonly IDetalleInvRepository _detInvRepository;
        public DetInvService(IDetalleInvRepository detalleInvRepository)
        {
            _detInvRepository = detalleInvRepository;
        }

        public async Task<IEnumerable<DIListarDTO>> GetAll()
        {
            var detalle = await _detInvRepository.GetAll();

            var detalleDTO = detalle.Select(item => new DIListarDTO
            {
                DetalleInventarioId = item.DetalleInventarioId,
                CantidadUtilizada = item.CantidadUtilizada,
                PrecioTotal = item.PrecioTotal,
                Inventario = new DetInvDTO()
                {
                    Nombre = item.Inventario.Nombre
                }
            }).ToList();

            return detalleDTO;
        }

        public async Task<IEnumerable<DIListarDTO>> GetById(int id)
        {
            var detalle = await _detInvRepository.GetById(id);

            if (detalle == null)
                return null;

            var detallesDTO = detalle.Select(item => new DIListarDTO()
            {
                DetalleInventarioId = item.DetalleInventarioId,
                CantidadUtilizada = item.CantidadUtilizada,
                PrecioTotal = item.PrecioTotal,
                Inventario = new DetInvDTO()
                {
                    Nombre = item.Inventario.Nombre
                }
            }).ToList();

            return detallesDTO;
        }

        public async Task<bool> Insert(int idrepuesto, int cantidad, DICrearDTO detalleDTO)
        {
            var detalle = new DetalleInventario()
            {
                CantidadUtilizada = cantidad,
                ReparacionMantenimientoId = detalleDTO.ReparacionMantenimientoId,
                InventarioId = idrepuesto,
                PrecioTotal = detalleDTO.PrecioTotal
            };

            var result = await _detInvRepository.Insert(idrepuesto, cantidad, detalle);
            return result;
        }

        public async Task<bool> Update(int id, DIActualizarDTO detalleDTO)
        {
            var detalle = new DetalleInventario()
            {
                DetalleInventarioId = id,
                CantidadUtilizada = detalleDTO.CantidadUtilizada,
                ReparacionMantenimientoId = detalleDTO.ReparacionMantenimientoId,
                PrecioTotal = detalleDTO.PrecioTotal
            };

            var isDetalle = await _detInvRepository.Update(id, detalle);
            if (isDetalle == false)
                return false;
            return isDetalle;
        }

        public async Task<bool> Delete(int id)
        {
            var detalle = await _detInvRepository.Delete(id);
            if (detalle == false)
                return false;
            return detalle;
        }
    }
}
