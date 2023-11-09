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

        public async Task<bool> Delete(int id)
        {
            var Propietario = await _dbContext.Propetario.Where(x => x.PropietarioId == id).FirstOrDefaultAsync();

            if (Propietario == null)
                return false;

            _dbContext.Propetario.Remove(Propietario);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(int id, Propetario propietario)
        {
            var existPropietario = await _dbContext.Propetario.FindAsync(id);
            if (existPropietario == null)
            {
                return false;
            }

            
            existPropietario.Nombre = propietario.Nombre;
            existPropietario.Apellido = propietario.Apellido;
            existPropietario.CorreoElectronico = propietario.CorreoElectronico;
            existPropietario.Telefono = propietario.Telefono;
            existPropietario.Direccion = propietario.Direccion;
            existPropietario.Dni = propietario.Dni;
            existPropietario.Password = propietario.Password;
            existPropietario.TallerId = propietario.TallerId;

            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<Propetario>> GetAll()
        {
            return await _dbContext.Propetario.ToListAsync();
        }

        public async Task<Propetario> SignIn(string CorreoElectronico, string password)
        {
            return await _dbContext
                .Propetario
                .Where(x => x.CorreoElectronico == CorreoElectronico && x.Password == password)
                .FirstOrDefaultAsync();
        }
    }
}
