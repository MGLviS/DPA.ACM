using DPA.ACM.DOMAIN.Infrastructure.Data;
using DPA.ACM.DOMAIN.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DPA.ACM.DOMAIN.Core.Interfaces;
using System.Collections;

namespace DPA.ACM.DOMAIN.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
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

        public async Task<bool> Delete(int id)
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

        public async Task<bool> Update(int id, Cliente cliente)
        {

            //verifica que el cliente que se intenta actualizar existe en la base de datos
            var existCliente = await _dbContext.Cliente.FindAsync(id);
            if (existCliente == null)
            {
                return false;
            }

            existCliente.Nombre = cliente.Nombre;
            existCliente.Apellido = cliente.Apellido;
            existCliente.CorreoElectronico = cliente.CorreoElectronico;
            existCliente.Telefono = cliente.Telefono;
            existCliente.Direccion = cliente.Direccion;
            //existCliente.Dni= cliente.Dni;
            existCliente.Password = cliente.Password; 


  
                var rows=await _dbContext.SaveChangesAsync();
                return rows > 0; ; // Actualización exitosa

        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _dbContext.Cliente.ToListAsync();
        }

        public async Task<Cliente> SignIn(string CorreoElectronico, string password)
        {
            return await _dbContext
                .Cliente
                .Where(x => x.CorreoElectronico == CorreoElectronico && x.Password == password)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsEmailRegistered(string CorreoElectronico)
        {
            return await _dbContext
                .Cliente
                .Where(x => x.CorreoElectronico == CorreoElectronico).AnyAsync();
        }

        public async Task<IEnumerable<Cliente>> GetByNaApDniRuc(string inputSearch)
        {
            
            var search = await _dbContext
                .Cliente
                .Where(x => x.Nombre.Contains(inputSearch) ||
                            x.Apellido.Contains(inputSearch) ||
                            x.Dni.Contains(inputSearch) ||
                            x.Ruc.Contains(inputSearch)).ToListAsync();

            return search;
        }
        public async Task<Cliente> GetClienteWithFacturas (int idCliente)
        {
            var cliente = await _dbContext
                                .Cliente
                                .Where(x => x.ClienteId == idCliente)
                                .Include(z => z.Factura)
                                .FirstOrDefaultAsync();
            return cliente;
        }




    }
}
