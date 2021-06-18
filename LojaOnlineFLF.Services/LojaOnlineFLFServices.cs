using FluentValidation;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LojaOnlineFLF.Services
{
    public static class LojaOnlineFLFServices
    {        
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMapperService, MapperService>();

            services.AddScoped<IAcessosService, AcessosService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenEncriptService, TokenEncriptService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();

            services.AddScoped<IFuncionariosService, FuncionariosService>();
            services.AddScoped<IFuncionarioValidators, FuncionarioValidators>();

            services.AddScoped<IProdutosService, ProdutosService>();
            services.AddScoped<IProdutoValidators, ProdutoValidators>();

            services.AddScoped<IClientesService, ClientesService>();
            services.AddScoped<IClienteValidators, ClienteValidators>();

            services.AddScoped<IVendasService, VendasService>();
            services.AddScoped<IVendaValidators, VendaValidators>();

            services.AddScoped<IValidator<Funcionario>, FuncionarioValidator>();
            services.AddScoped<IValidator<FuncionarioCadastro>, FuncionarioValidator>();
            services.AddScoped<IValidator<Login>, AcessoValidator>();
            services.AddScoped<IValidator<ProdutoCadastro>, ProdutoCadastroValidator>();
            services.AddScoped<IValidator<Produto>, ProdutoValidator>();
            services.AddScoped<IValidator<ClienteCadastro>, ClienteValidator>();
            services.AddScoped<IValidator<VendaCadastro>, VendaCadastroValidator>();
            services.AddScoped<IValidator<VendaCadastrada>, VendaCadastroValidator>();
            services.AddScoped<IValidator<Venda>, VendaValidator>();
            services.AddScoped<IValidator<Venda.ItemTO>, VendaValidator.ItemValidator>();
            services.AddScoped<IValidator<VendaItem>, VendaItemValidator>();

            services.AddRepositoriesDependencies();

            return services;
        }
    }
}
