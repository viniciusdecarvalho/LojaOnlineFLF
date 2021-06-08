using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    public interface IRefreshTokenFactory
    {
        RefreshToken Create(string usuario);
    }
}