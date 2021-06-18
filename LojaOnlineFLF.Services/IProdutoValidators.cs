using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Services
{
    public interface IProdutoValidators
    {
        Task ValidateAndThrowAsync(ProdutoCadastro produto);

        Task ValidateAndThrowAsync(Produto produto);
    }
}
