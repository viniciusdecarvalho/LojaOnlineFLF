using System;
using System.Collections.Generic;
using System.Linq;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.DataModel.Providers;
using Microsoft.AspNetCore.Identity;

namespace LojaOnlineFLF.DataModel.Repositories
{
    public class RepositoryFactory: IRepositoryFactory
    {
        private readonly LojaEFContext context;
        private readonly SignInManager<Acesso> signInManager;
        private readonly UserManager<Acesso> userManager;
        private Dictionary<Type, Func<LojaEFContext, SignInManager<Acesso>, UserManager<Acesso>, object>> providers = new Dictionary<Type, Func<LojaEFContext, SignInManager<Acesso>, UserManager<Acesso>, object>>();

        public RepositoryFactory(LojaEFContext context, SignInManager<Acesso> signInManager, UserManager<Acesso> userManager)
        {
            this.context = context;
            this.signInManager = signInManager;
            this.userManager = userManager;

            this.Register<IAcessosRepository>((ctx, sign, user) => new AcessoAdminRepository(new AcessosRepository(ctx, sign, user)));
            this.Register<IFuncionariosRepository>((ctx) => new FuncionariosRepository(ctx));
            this.Register<IProdutosRepository>((ctx) => new ProdutosRepository(ctx));
            this.Register<IClientesRepository>((ctx) => new ClientesRepository(ctx));
        }

        internal RepositoryFactory Register<T>(Func<LojaEFContext, T> provider) where T : class
        {
            T c(LojaEFContext ctx, SignInManager<Acesso> sign, UserManager<Acesso> user) => provider.Invoke(ctx);
            return this.Register<T>(c);
        }

        internal RepositoryFactory Register<T>(Func<LojaEFContext, SignInManager<Acesso>, UserManager<Acesso>, T> provider) where T: class
        {
            this.providers.Add(typeof(T), provider);

            return this;
        }

        public T Create<T>() where T: class
        {
            var type = typeof(T);

            var provider = this.providers.LastOrDefault(p => type.IsAssignableFrom(p.Key));

            var repository = provider.Value.Invoke(this.context, this.signInManager, this.userManager);

            if (repository is null)
            {
                throw new InvalidOperationException($"instancia de {type.Name} nao encontrada");
            }

            return (T)repository;
        }
    }
}
