﻿using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IVehiculoRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Vehiculo>> GetAll();
        Task<Vehiculo> GetById(int id);
        Task<bool> InsertV(Vehiculo vehiculo);
    }
}