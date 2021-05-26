using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    ///<summary>
    /// servicos de funcionarios padrao
    ///</summary>
    public class AcessosService: IAcessosService
    {
        private readonly IAcessosRepository acessosRepository;
        private readonly IMapper mapper;

        ///<summary>
        /// Construtor
        ///</summary>
        public AcessosService(
            IAcessosRepository acessosRepository,
            IMapper mapper)
        {
            this.acessosRepository = acessosRepository;
            this.mapper = mapper;
        }

        public async Task IncluirAcessoAsync(FuncionarioTO funcionario, Login login)
        {
            if (funcionario is null)
            {
                throw new ArgumentNullException(nameof(funcionario));
            }

            if (login is null)
            {
                throw new ArgumentNullException(nameof(login));
            }

            try
            {
                var acesso = new Acesso()
                {
                    Funcionario = new Funcionario { Id = funcionario.Id },
                    UserName = login.Usuario
                };

                await this.acessosRepository.RegistrarAsync(acesso, login.Senha);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"falha ao registrar acesso. {e.Message}");
            }
        }

        public async Task AlterarAcessoAsync(FuncionarioTO funcionario, LoginAlteracao login)
        {
            if (funcionario is null)
            {
                throw new ArgumentNullException(nameof(funcionario));
            }

            if (login is null)
            {
                throw new ArgumentNullException(nameof(login));
            }

            try
            {
                var acesso = new Acesso()
                {
                    Funcionario = new Funcionario { Id = funcionario.Id},
                    UserName = login.Usuario
                };

                await this.acessosRepository.AlterarAsync(acesso, login.SenhaAtual, login.NovaSenha);
            }
            catch(Exception e)
            {
                throw new InvalidOperationException($"falha ao registrar acesso. {e.Message}");
            }
        }

        public async Task<FuncionarioTO> ValidarAcessoAsync(Login acessoTO)
        {
            if (acessoTO is null)
            {
                throw new ArgumentNullException("informacoes de acesso nao informados", nameof(acessoTO));
            }            

            Funcionario funcionario = await this.acessosRepository.LoginAsync(acessoTO.Usuario, acessoTO.Senha);

            if (funcionario is null)
            {
                throw new InvalidOperationException("funcionario nao encontrado");
            }

            return mapper.Map<FuncionarioTO>(funcionario);
        }
    }
}