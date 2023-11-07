using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IClienteRepository
    {
        Task<bool> Delete(int id);
        Task<bool> RegisterCliente(Cliente Cliente);
        Task<IEnumerable<Cliente>> GetAll();
        Task<bool> Update(int id, Cliente cliente);
        Task<bool> IsEmailRegistered(string CorreoElectronico);
        Task <Cliente> SignIn(string correoElectronico, string password);
    }
}