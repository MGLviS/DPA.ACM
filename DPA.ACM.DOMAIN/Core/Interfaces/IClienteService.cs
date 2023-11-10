using DPA.ACM.DOMAIN.Core.DTO;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> ShowClients();
        Task<ClienteReponseDTO> SignIn(ClienteAuthDTO clienteAuthDTO);
        Task<bool> CreateClient(ClienteRegisterDTO clientDTO);
        Task<bool> Delete(int id);
        Task<bool> UpdateClient(int id, ClienteUpdateDTO clienteDTO);
        Task<IEnumerable<ClienteDTO>> GetByNaApDniRuc(string inputSearch);
        Task<ClienteFactDTO> GetFactxClient(int idClient);

    }
}