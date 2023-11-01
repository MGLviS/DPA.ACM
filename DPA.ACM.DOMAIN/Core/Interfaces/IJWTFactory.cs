using DPA.ACM.DOMAIN.Core.Entities;

namespace DPA.ACM.DOMAIN.Core.Interfaces
{
    public interface IJWTFactory
    {
        //JWTSettings _settings { get; }

        string GenerateJWToken(Cliente cliente);
    }
}
