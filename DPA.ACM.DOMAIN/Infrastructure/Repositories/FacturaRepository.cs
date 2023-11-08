using System;
using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DPA.ACM.DOMAIN.Infrastructure.Repositories
{
    public class FacturaRepository : IFacturaRepository
    {
        private readonly AutoCareManagerContext _dbContext;
        public FacturaRepository(AutoCareManagerContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<IEnumerable<Factura>> GetAll()
        {
            var factura = await _dbContext.Factura.ToListAsync();
            return factura;
        }

        public async Task<IEnumerable<Factura>> GetFactActivas()
        {

            var factura = await _dbContext
                        .Factura
                        .Where(x => x.Cancelado == false).ToListAsync();
            return factura;
        }

        public async Task<IEnumerable<Factura>> GetFactCancelas()
        {

            var factura = await _dbContext
                        .Factura
                        .Where(x => x.Cancelado == true).ToListAsync();
            return factura;
        }
        public async Task<IEnumerable<Factura>> GetCustom(string inputSearch)
        {


                var search = await _dbContext
                    .Factura
                    .Where(x => x.FacturaId.ToString().Contains(inputSearch) ||
                                x.FechaFacturacion.ToString().Contains(inputSearch) ||
                                x.ClienteId.ToString().Contains(inputSearch)).ToListAsync();

                return search;
            
        }

        public async Task<bool> SetCancelFactura(int facturaId, Factura factura)
        {

            var existFactura = await _dbContext
                        .Factura
                        .FindAsync(facturaId);
            if(existFactura != null)
            {
                existFactura.Cancelado = factura.Cancelado; //Esto actualiza el campo cancelado
                var rows = await _dbContext.SaveChangesAsync();
                return rows > 0; ; // Actualización exitosa
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> RegisterFactura(Factura factura)
        {
            await _dbContext.Factura.AddAsync(factura);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

    }
}

