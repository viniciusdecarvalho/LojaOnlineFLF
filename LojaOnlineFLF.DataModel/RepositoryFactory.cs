using System;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.DataModel.Providers;
using Microsoft.AspNetCore.Identity;

namespace LojaOnlineFLF.DataModel
{
    public class RepositoryFactory: IRepositoryFactory
    {
        private readonly LojaEFContext context;
        private readonly SignInManager<Acesso> signInManager;
        private readonly UserManager<Acesso> userManager;

        public RepositoryFactory(LojaEFContext context, SignInManager<Acesso> signInManager, UserManager<Acesso> userManager)
        {
            this.context = context;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IFuncionariosRepository CreateFuncionarios()
        {
            return new FuncionariosRepository(this.context);
        }

        public IAcessosRepository CreateAcessos()
        {
            var acessos = new AcessosRepository(this.context, this.signInManager, this.userManager);

            return new AcessoAdminRepository(acessos);
        }
    }
}
