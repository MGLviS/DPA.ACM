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
            return await _dbContext.Factura.ToListAsync();
        }
    }
}

