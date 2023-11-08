using System;
using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Infrastructure.Repositories;

namespace DPA.ACM.DOMAIN.Core.Services
{
    public class FacturaService : IFacturaService

    {
        private readonly IFacturaRepository _facturaRepository;
        public FacturaService(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public async Task<IEnumerable<FacturaDTO>> ShowFacturas()
        {
            var factura = await _facturaRepository.GetAll();
            //Convert factura to FacturaDTO
            var facturalist = new List<FacturaDTO>();
            foreach (var item in factura)
            {
                facturalist.Add(new FacturaDTO
                {
                    FacturaId = item.FacturaId,
                    FechaFacturacion = item.FechaFacturacion,
                    Total = item.Total,
                    ClienteId = item.ClienteId,
                });
            }


            return facturalist;
        }

    }
}

