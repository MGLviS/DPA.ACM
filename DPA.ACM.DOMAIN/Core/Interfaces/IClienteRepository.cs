using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IClienteRepository
    {
        Task<bool> Eliminar(int id);
        Task<bool> RegisterCliente(Cliente Cliente);
        Task<IEnumerable<Cliente>> GetAll();
        Task<bool> Actualizar(int id, Cliente cliente);
        Task <Cliente> SignIn(string correoElectronico, string password);
    }
}