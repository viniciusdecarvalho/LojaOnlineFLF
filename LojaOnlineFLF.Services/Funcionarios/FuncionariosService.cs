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
    internal class FuncionariosService: IFuncionariosService
    {
        private readonly IFuncionariosRepository funcionariosProvider;
        private readonly IFuncionarioValidators funcionarioValidatos;
        private readonly IMapperService mapper;

        ///<summary>
        /// Construtor
        ///</summary>
        public FuncionariosService(
            IFuncionariosRepository funcionariosRepository,
            IFuncionarioValidators funcionarioValidatos,
            IMapperService mapper)
        {
            this.funcionariosProvider = funcionariosRepository;
            this.funcionarioValidatos = funcionarioValidatos;
            this.mapper = mapper;
        }

        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        public async Task<Funcionario> AdicionarAsync(FuncionarioCadastro funcionario)
        {
            try
            {
                Objects.CheckArgumentNonNull(funcionario, nameof(funcionario), "funcionario invalido");

                await this.funcionarioValidatos.ValidateAndThrowAsync(funcionario);

                await VerificarFuncionarioJaExistePorCpf(funcionario);

                var entity = this.mapper.Convert<DataModel.Models.Funcionario>(funcionario);

                await this.funcionariosProvider.IncluirAsync(entity);

                return this.mapper.Convert<Funcionario>(entity);
            }
            catch (Exception e)
            {
                throw new ServiceException("falha ao tentar adicionar novo funcionario", e);
            }
        }

        private async Task VerificarFuncionarioJaExistePorCpf(FuncionarioCadastro funcionario)
        {
            var existe = await this.funcionariosProvider.ObterPorCpfAsync(funcionario.Cpf);

            if (existe != null)
            {
                throw new InvalidOperationException($"funcionario informado ja possui cadastro para identificador informado. {existe.Id}: {existe.Nome}");
            }
        }

        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        public async Task AtualizarAsync(Funcionario funcionario) 
        {
            try
            {
                Objects.CheckArgumentNonNull(funcionario, nameof(funcionario), "funcionario invalido");

                await this.funcionarioValidatos.ValidateAndThrowAsync(funcionario);

                var entity = this.mapper.Convert<DataModel.Models.Funcionario>(funcionario);

                await this.funcionariosProvider.AtualizarAsync(entity);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar atualizar funcionario", e);
            }
        }

        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        public async Task RemoverAsync(Guid id)
        {
            try
            {
                await this.funcionariosProvider.RemoverAsync(id);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar remover funcionario", e);
            }
        }

        ///<summary>
        /// Buscar funcionario por id
        ///</summary>
        public async Task<Funcionario> ObterPorIdAsync(Guid id) 
        {
            try
            {
                var funcionario = await this.funcionariosProvider.ObterAsync(id);

                return this.mapper.Convert<Funcionario>(funcionario);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar obter funcionario por id", e);
            }
        }

        ///<summary>
        /// Buscar todos os funcionarios
        ///</summary>
        public async Task<IPagedList<Funcionario>> ObterTodosAsync(IPageParameters paginacao) 
        {
            try
            {
                var funcionarios = await this.funcionariosProvider.ListarTodosAsync(paginacao.ToPageSet());

                return funcionarios.Transform((f) => this.mapper.Convert<Funcionario>(f));
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar obter os funcionarios", e);
            }
        }

        /// <summary>
        /// Verifica se registro com id informado na existe
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true caso identificador seja encontrado, false caso contrario</returns>
        public async Task<bool> ContemAsync(Guid id)
        {
            try
            {
                return await this.funcionariosProvider.ContemAsync(id);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar recuperar funcionario", e);
            }
        }
    }
}