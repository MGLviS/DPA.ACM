using DPA.ACM.DOMAIN.Infrastructure.Data;
using DPA.ACM.DOMAIN.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Infrastructure.Repositories
{
    public class ClienteRepository
    {
        private readonly AutoCareManagerContext _dbContext;

        public ClienteRepository(AutoCareManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> RegisterCliente(Cliente Cliente)
        {
            await _dbContext.Cliente.AddAsync(Cliente);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }


        public async Task<bool> Eliminar(int id)
        {
            var Cliente = await _dbContext
                .Cliente
                .Where(x => x.ClienteId == id).FirstOrDefaultAsync();

            if (Cliente == null)
                return false;

            _dbContext.Cliente.Remove(Cliente);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;

        }

    }
}
