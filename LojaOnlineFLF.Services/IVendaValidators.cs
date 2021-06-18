using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Services
{
    public interface IVendaValidators
    {
        Task ValidateAndThrowAsync(VendaCadastro venda);

        Task ValidateAndThrowAsync(VendaCadastrada venda);

        Task ValidateAndThrowAsync(Venda venda);

        Task ValidateAndThrowAsync(params VendaItem[] items);
    }
}
