using System;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    ///<summary>
    /// servicos de funcionarios padrao
    ///</summary>
    internal class AcessosService: IAcessosService
    {
        private readonly IAcessosRepository acessosRepository;
        private readonly IRefreshTokenManager refreshTokenManager;
        private readonly IMapperService mapper;

        ///<summary>
        /// Construtor
        ///</summary>
        public AcessosService(
            IAcessosRepository acessosRepository,
            IRefreshTokenManager refreshTokenManager,
            IMapperService mapper)
        {
            this.acessosRepository = acessosRepository;
            this.refreshTokenManager = refreshTokenManager;
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
                    Funcionario = new Funcionario { Id = funcionario.Id.Value },
                    UserName = login.Usuario
                };

                await this.acessosRepository.RegistrarAsync(acesso, login.Senha);
            }
            catch (Exception e)
            {
                throw new ServiceException($"falha ao registrar acesso", e);
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
                    Funcionario = new Funcionario { Id = funcionario.Id.Value},
                    UserName = login.Usuario
                };

                await this.acessosRepository.AlterarAsync(acesso, login.SenhaAtual, login.NovaSenha);
            }
            catch(Exception e)
            {
                throw new ServiceException($"falha ao alterar acesso", e);
            }
        }

        public async Task<FuncionarioTO> ValidarAcessoAsync(Login acessoTO)
        {
            if (acessoTO is null)
            {
                throw new ArgumentNullException("informacoes de acesso nao informados", nameof(acessoTO));
            }

            try
            {
                Funcionario funcionario = await this.acessosRepository.LoginAsync(acessoTO.Usuario, acessoTO.Senha);

                if (funcionario is null)
                {
                    throw new InvalidOperationException("funcionario nao encontrado");
                }

                return mapper.Map<FuncionarioTO>(funcionario);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao validar acesso", e);
            }
        }

        public async Task<FuncionarioTO> ValidarTokenAsync(RefreshToken refreshToken)
        {
            string userName = await this.refreshTokenManager.GetUserNameAsync(refreshToken.Token);

            if (string.IsNullOrEmpty(userName))
            {
                throw new InvalidOperationException("usuario nao encontrado para o token informado");
            }

            if (!userName.Equals(refreshToken.Usuario))
            {
                throw new InvalidOperationException("usuario invalido pra o token informado");
            }

            Funcionario funcionario = await this.acessosRepository.ObterFuncionarioAsync(userName);

            return this.mapper.Map<FuncionarioTO>(funcionario);
        }
    }
}