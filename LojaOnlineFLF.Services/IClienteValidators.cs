using System.Threading.Tasks;

namespace LojaOnlineFLF.Services
{
    public interface IClienteValidators
    {
        Task ValidateAndThrowAsync(ClienteCadastro cliente);
    }
}