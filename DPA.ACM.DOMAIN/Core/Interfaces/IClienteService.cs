using DPA.ACM.DOMAIN.Core.DTO;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> ShowClients();
        Task<ClienteReponseDTO> SignIn(ClienteAuthDTO clienteAuthDTO);
    }
}