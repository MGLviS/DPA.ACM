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
    public class DetFacturaService : IDetFacturaService
    {
        private readonly IDetFacturaRepository _detFacRepository;

        public DetFacturaService(IDetFacturaRepository detFacRepository)
        {
            _detFacRepository = detFacRepository;
        }

        public async Task<bool> Insert(CrearDetFacturaDTO detFactFTO)
        {
            var detalle = new DetallesFactura()
            {
                DescripcionServicio = detFactFTO.DescripcionServicio,
                PrecioServicio = detFactFTO.PrecioServicio,
                FacturaId = detFactFTO.FacturaId,
                ReparacionMantenimientoId = detFactFTO.ReparacionMantenimientoId
            };

            var result = await _detFacRepository.Insert(detalle);
            return result;
        }

        public async Task<IEnumerable<ListarDetFacturaDTO>> GetById(int id)
        {
            var detalle = await _detFacRepository.GetByID(id);

            if (detalle == null)
                return null;

            var detalleDTO = detalle.Select(item => new ListarDetFacturaDTO()
            {
                DetalleFacturaId = item.DetalleFacturaId,
                DescripcionServicio = item.DescripcionServicio,
                PrecioServicio = item.PrecioServicio,
                FacturaId = item.FacturaId,
                RepMantenimiento = new RepMLista
                {
                    ReparacionMantenimientoId = item.ReparacionMantenimiento.ReparacionMantenimientoId,
                    Descripcion = item.ReparacionMantenimiento.Descripcion
                }
            }).ToList();

            return detalleDTO;
        }

        public async Task<IEnumerable<ListarDetFacturaDTO>> GetByFactura(int id)
        {
            var detalle = await _detFacRepository.GetByFactura(id);

            if (detalle == null)
                return null;

            var detalleDTO = detalle.Select(item => new ListarDetFacturaDTO()
            {
                DetalleFacturaId = item.DetalleFacturaId,
                DescripcionServicio = item.DescripcionServicio,
                PrecioServicio = item.PrecioServicio,
                FacturaId = item.FacturaId,
                RepMantenimiento = new RepMLista
                {
                    ReparacionMantenimientoId = item.ReparacionMantenimiento.ReparacionMantenimientoId,
                    Descripcion = item.ReparacionMantenimiento.Descripcion
                }
            }).ToList();

            return detalleDTO;
        }

    }
}
