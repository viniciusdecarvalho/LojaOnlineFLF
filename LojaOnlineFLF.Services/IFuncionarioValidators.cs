using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Services
{
    public interface IFuncionarioValidators
    {
        Task ValidateAndThrowAsync(FuncionarioCadastro funcionario);
    }
}
