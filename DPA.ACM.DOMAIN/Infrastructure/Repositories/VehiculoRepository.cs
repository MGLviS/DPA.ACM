using DPA.ACM.DOMAIN.Core.Entities;
using DPA.ACM.DOMAIN.Core.Interfaces;
using DPA.ACM.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
namespace DPA.ACM.DOMAIN.Infrastructure.Repositories
{
    public class VehiculoRepository : IVehiculoRepository
    {
        private readonly AutoCareManagerContext _dbcontext;

        public VehiculoRepository(AutoCareManagerContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //CREATE
        public async Task<bool> InsertV(Vehiculo vehiculo)
        {
            await _dbcontext.AddAsync(vehiculo);
            var rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }

        //READ

        public async Task<IEnumerable<Vehiculo>> GetAll()
        {
            var vehiculos = await _dbcontext.Vehiculo
                .Include(z => z.Cliente)
                .ToListAsync();
            return vehiculos;
        }

        public async Task<IEnumerable<Vehiculo>> GetById(int id)
        {
            var busqueda = await _dbcontext.Vehiculo
                .Where(x => x.VehiculoId == id)
                //.Where(y => y.ClienteId == id)
                .Include(z => z.Cliente)
                .ToListAsync();
            return busqueda;
        }

        //UPDATE
        public async Task<bool> Update(int id,  Vehiculo vehiculo)
        {
            var vehiculoUpdate = await _dbcontext.Vehiculo.FindAsync(id);

            if (vehiculoUpdate == null)
                return false;

            vehiculoUpdate.Marca = vehiculo.Marca;
            vehiculoUpdate.Modelo = vehiculo.Modelo;
            vehiculoUpdate.Anio = vehiculo.Anio;
            vehiculoUpdate.NumeroPlaca = vehiculo.NumeroPlaca;
            vehiculoUpdate.ClienteId = vehiculo.ClienteId;

            var rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }

        //DELETE
        public async Task<bool> Delete(int id)
        {
            var vehiculo = await _dbcontext.Vehiculo.Where(x => x.VehiculoId == id).FirstOrDefaultAsync();
            if (vehiculo == null)
                return false;
            _dbcontext.Vehiculo.Remove(vehiculo);
            var rows = await _dbcontext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<ModeloCantidad>> GetCantidadPorMarca()
        {
            var vehiculos = await _dbcontext.Vehiculo.ToListAsync();

            // Llamada a la función para obtener la cantidad por modelo
            var cantidadPorModelo = ObtenerCantidadPorMarca(vehiculos);

            // Puedes usar o devolver la cantidad por modelo según tus necesidades
            return cantidadPorModelo;
        }

        private List<ModeloCantidad> ObtenerCantidadPorMarca(List<Vehiculo> vehiculos)
        {
            return vehiculos
                .GroupBy(v => v.Marca)
                .Select(g => new ModeloCantidad { Marca = g.Key, Cantidad = g.Count() })
                .ToList();
        }
    }
}

public class ModeloCantidad
{
    public string Marca { get; set; }
    public int Cantidad { get; set; }
}

//vehiculo