using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.Repositories;
using LojaOnlineFLF.Utils;
using System;
using System.Threading.Tasks;

namespace LojaOnlineFLF.Services
{
    ///<summary>
    /// servicos de funcionarios padrao
    ///</summary>
    internal class AcessosService: IAcessosService
    {
        private readonly IAcessosRepository acessosRepository;
        private readonly IRefreshTokenService refreshTokenManager;
        private readonly IMapperService mapper;

        ///<summary>
        /// Construtor
        ///</summary>
        public AcessosService(
            IAcessosRepository acessosRepository,
            IRefreshTokenService refreshTokenManager,
            IMapperService mapper)
        {
            this.acessosRepository = acessosRepository;
            this.refreshTokenManager = refreshTokenManager;
            this.mapper = mapper;
        }

        public async Task IncluirAcessoAsync(Funcionario funcionario, Login login)
        {
            try
            {
                Objects.CheckArgumentNonNull(funcionario, nameof(funcionario), "funcionario invalido");
                Objects.CheckArgumentNonNull(login, nameof(login), "login invalido");

                var acesso = new Acesso()
                {
                    Funcionario = new DataModel.Models.Funcionario { Id = funcionario.Id.Value },
                    UserName = login.Usuario
                };

                await this.acessosRepository.RegistrarAsync(acesso, login.Senha);
            }
            catch (Exception e)
            {
                throw new ServiceException($"falha ao registrar acesso", e);
            }
        }

        public async Task AlterarAcessoAsync(Funcionario funcionario, LoginAlteracao login)
        {
            try
            {
                Objects.CheckArgumentNonNull(funcionario, nameof(funcionario), "funcionario invalido");
                Objects.CheckArgumentNonNull(login, nameof(login), "login invalido");

                var acesso = new Acesso()
                {
                    Funcionario = new DataModel.Models.Funcionario { Id = funcionario.Id.Value},
                    UserName = login.Usuario
                };

                await this.acessosRepository.AlterarAsync(acesso, login.SenhaAtual, login.NovaSenha);
            }
            catch(Exception e)
            {
                throw new ServiceException($"falha ao alterar acesso", e);
            }
        }

        public async Task<Funcionario> ValidarAcessoAsync(Login login)
        {
            try
            {
                Objects.CheckArgumentNonNull(login, nameof(login), "login invalido");

                DataModel.Models.Funcionario funcionario = await this.acessosRepository.LoginAsync(login.Usuario, login.Senha);

                if (funcionario is null)
                {
                    throw new InvalidOperationException("funcionario nao encontrado");
                }

                return mapper.Convert<Funcionario>(funcionario);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao validar acesso", e);
            }
        }

        public async Task<Funcionario> ValidarTokenAsync(RefreshToken refreshToken)
        {
            try
            {
                Objects.CheckArgumentNonNull(refreshToken, nameof(refreshToken), "refreshToken invalido");

                string userName = await this.refreshTokenManager.GetUserNameAsync(refreshToken.Token);

                if (string.IsNullOrEmpty(userName))
                {
                    throw new InvalidOperationException("usuario nao encontrado para o token informado");
                }

                if (!userName.Equals(refreshToken.Usuario))
                {
                    throw new InvalidOperationException("usuario invalido pra o token informado");
                }

                DataModel.Models.Funcionario funcionario = await this.acessosRepository.ObterFuncionarioAsync(userName);

                return this.mapper.Convert<Funcionario>(funcionario);
            }
            catch (Exception e)
            {
                throw new ServiceException("falha ao validar acesso", e);
            }
        }
    }
}