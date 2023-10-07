using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IClienteRepository
    {
        Task<bool> Eliminar(int id);
        Task<bool> RegisterCliente(Cliente Cliente);
    }
}