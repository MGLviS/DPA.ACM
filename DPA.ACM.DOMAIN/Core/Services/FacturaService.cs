using System;
using DPA.ACM.DOMAIN.Core.DTO;
using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Infrastructure.Repositories;
using DPA.ACM.DOMAIN.Infrastructure.Shared;

namespace DPA.ACM.DOMAIN.Core.Services
{
    public class FacturaService : IFacturaService

    {
        private readonly IFacturaRepository _facturaRepository;
        //private readonly GetTimeNow _getTimeNow;
        public FacturaService(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
            //_getTimeNow = getTimeNow;
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
                    Cancelado = item.Cancelado,
                }) ;
            }


            return facturalist;
        }

        public async Task<IEnumerable<FacturasStateDTO>> ShowFactActivas()
        {
            var factura = await _facturaRepository.GetFactActivas();
            //Convert factura to FacturaDTO
            var facturalist = new List<FacturasStateDTO>();
            foreach (var item in factura)
            {
                facturalist.Add(new FacturasStateDTO
                {
                    FacturaId = item.FacturaId,
                    FechaFacturacion = item.FechaFacturacion,
                    Total = item.Total,
                    ClienteId = item.ClienteId,
                    
                });
            }


            return facturalist;
        }

        public async Task<IEnumerable<FacturasStateDTO>> ShowFactCanceladas()
        {
            var factura = await _facturaRepository.GetFactCancelas();
            //Convert factura to FacturaDTO
            var facturalist = new List<FacturasStateDTO>();
            foreach (var item in factura)
            {
                facturalist.Add(new FacturasStateDTO
                {
                    FacturaId = item.FacturaId,
                    FechaFacturacion = item.FechaFacturacion,
                    Total = item.Total,
                    ClienteId = item.ClienteId,

                });
            }


            return facturalist;
        }

        public async Task<IEnumerable<FactHistorialDTO>> GetCustom(string inputSearch)
        {
            var factura = await _facturaRepository.GetCustom(inputSearch);
            //Convert cliente to FactHistorialDTO

            // Si cliente no es nulo, puedes continuar con la conversión a FactHistorialDTO.
            var facturaList = new List<FactHistorialDTO>();

            foreach (var item in factura)
            {
                facturaList.Add(new FactHistorialDTO
                {
                    FacturaId = item.FacturaId,
                    FechaFacturacion = item.FechaFacturacion,
                    Total = item.Total,
                });
            }


            return facturaList;
        }

        public async Task<bool> SetCancelFactura(int id, FactCancelDTO factCancelDTO)
        {
            //var facturad = await _facturaRepository.SetCancelFactura(id);
            var factura = new Factura()
            {
                Cancelado = factCancelDTO.Cancelado,
            };

            var isFactura = await _facturaRepository.SetCancelFactura(id, factura);
            if (isFactura == null)
                return false;
            return isFactura;
        }

        public async Task<bool> CreateFactura(FactRegisterDTO factRegisterDTO)
        {
            //GetTimeNow getTime = new GetTimeNow();
 
            var factura = new Factura()
            {
                FechaFacturacion = DateTime.Now.Date,
                Total = factRegisterDTO.Total,
                ClienteId = factRegisterDTO.ClienteId,
                Cancelado = false,
            };
            var result = await _facturaRepository.RegisterFactura(factura);
            return result;
        }
    }
}

