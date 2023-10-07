using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.ACM.DOMAIN.Infrastructure.Repositories
{
    public class PropietarioRepository : IPropietarioRepository
    {
        private readonly AutoCareManagerContext _dbContext;

        public PropietarioRepository(AutoCareManagerContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> RegPropietario(Propetario prop)
        {
            await _dbContext.Propetario.AddAsync(prop);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> IsEmailRegistered(string correoElectronico)
        {
            return await _dbContext.Propetario.Where(x => x.CorreoElectronico == correoElectronico).AnyAsync();
        }
    }
}
