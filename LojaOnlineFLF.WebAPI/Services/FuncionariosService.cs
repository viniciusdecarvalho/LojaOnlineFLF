using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaOnlineFLF.DataModel;
using LojaOnlineFLF.DataModel.Models;
using LojaOnlineFLF.WebAPI.Services.Models;

namespace LojaOnlineFLF.WebAPI.Services
{
    ///<summary>
    /// servicos de funcionarios padrao
    ///</summary>
    public class FuncionariosService: IFuncionariosService
    {
        private readonly IFuncionariosRepository funcionariosProvider;
        private readonly IMapperService mapper;

        ///<summary>
        /// Construtor
        ///</summary>
        public FuncionariosService(
            IFuncionariosRepository funcionariosRepository,
            IMapperService mapper)
        {
            this.funcionariosProvider = funcionariosRepository;
            this.mapper = mapper;
        }

        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        public async Task<FuncionarioTO> AdicionarAsync(FuncionarioTO funcionario)
        {
            try
            {
                VerificarFuncionarioNaoNulo(funcionario);
                await VerificarFuncionarioJaExistePorIdAsync(funcionario);
                await VerificarFuncionarioJaExistePorCpf(funcionario);

                var entity = this.mapper.Map<Funcionario>(funcionario);

                await this.funcionariosProvider.IncluirAsync(entity);

                return this.mapper.Map<FuncionarioTO>(entity);
            }
            catch (Exception e)
            {
                throw new ServiceException("falha ao tentar adicionar novo funcionario", e);
            }
        }

        private static void VerificarFuncionarioNaoNulo(FuncionarioTO funcionario)
        {
            if (funcionario is null)
            {
                throw new ArgumentNullException("dados do funcionario nao informado", nameof(funcionario));
            }
        }

        private async Task VerificarFuncionarioJaExistePorCpf(FuncionarioTO funcionario)
        {
            var existe = await this.funcionariosProvider.ObterPorCpfAsync(funcionario.Cpf);

            if (existe != null)
            {
                throw new InvalidOperationException($"funcionario informado ja possui cadastro para identificador informado. {existe.Id}: {existe.Nome}");
            }
        }

        private async Task VerificarFuncionarioJaExistePorIdAsync(FuncionarioTO funcionario)
        {
            var existe = await this.funcionariosProvider.ObterAsync(funcionario.Id ?? Guid.Empty);

            if (existe != null)
            {
                throw new InvalidOperationException($"funcionario informado ja possui cadastro para cpf informado");
            }
        }

        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        public async Task AtualizarAsync(FuncionarioTO funcionario) 
        {
            try
            {
                VerificarFuncionarioNaoNulo(funcionario);

                var entity = this.mapper.Map<Funcionario>(funcionario);

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
        public async Task<FuncionarioTO> ObterPorIdAsync(Guid id) 
        {
            try
            {
                var funcionario = await this.funcionariosProvider.ObterAsync(id);

                return this.mapper.Map<FuncionarioTO>(funcionario);
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar obter funcionario por id", e);
            }
        }

        ///<summary>
        /// Buscar todos os funcionarios
        ///</summary>
        public async Task<IEnumerable<FuncionarioTO>> ObterTodosAsync() 
        {
            try
            {

                var funcionarios = await this.funcionariosProvider.ListarTodosAsync();

                return funcionarios.Select(this.mapper.Map<FuncionarioTO>).ToList();
            }
            catch(Exception e)
            {
                throw new ServiceException("falha ao tentar obter os funcionarios", e);
            }
        }

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