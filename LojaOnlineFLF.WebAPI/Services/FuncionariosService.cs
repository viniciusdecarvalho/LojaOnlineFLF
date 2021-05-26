using System;
using System.Collections.Generic;
using System.Linq;
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
    public class FuncionariosService: IFuncionariosService
    {
        private readonly IFuncionariosRepository funcionariosProvider;
        private readonly IMapper mapper;

        ///<summary>
        /// Construtor
        ///</summary>
        public FuncionariosService(
            IFuncionariosRepository funcionariosRepository,
            IMapper mapper)
        {
            this.funcionariosProvider = funcionariosRepository;
            this.mapper = mapper;
        }

        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        public async Task<FuncionarioTO> AdicionarAsync(FuncionarioTO funcionario)
        {
            VerificarFuncionarioNaoNulo(funcionario);
            VerificarFuncionarioJaExistePorId(funcionario);
            await VerificarFuncionarioJaExistePorCpf(funcionario);

            var entity = this.mapper.Map<Funcionario>(funcionario);

            await this.funcionariosProvider.IncluirAsync(entity);

            return this.mapper.Map<FuncionarioTO>(entity);
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
            var existe = await this.funcionariosProvider.ObterAsync(funcionario.Id);

            if (existe != null)
            {
                throw new InvalidOperationException($"funcionario informado ja possui cadastro para identificador informado. {existe.Id}: {existe.Nome}");
            }
        }

        private void VerificarFuncionarioJaExistePorId(FuncionarioTO funcionario)
        {
            var existe = this.funcionariosProvider.ObterPorCpfAsync(funcionario.Cpf);

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
            VerificarFuncionarioNaoNulo(funcionario);
            VerificarFuncionarioIdValido(funcionario);

            var entity = this.mapper.Map<Funcionario>(funcionario);

            await this.funcionariosProvider.AtualizarAsync(entity);
        }

        private void VerificarFuncionarioIdValido(FuncionarioTO funcionario)
        {
            if (Guid.Empty.Equals(funcionario.Id))
            {
                throw new InvalidOperationException("identificador valido é necessario");
            }
        }

        ///<summary>
        /// Adicionar novo funcionario
        ///</summary>
        public async Task RemoverAsync(FuncionarioTO funcionario)
        {
            VerificarFuncionarioIdValido(funcionario);

            await this.funcionariosProvider.RemoverAsync(funcionario.Id);
        }

        ///<summary>
        /// Buscar funcionario por id
        ///</summary>
        public async Task<FuncionarioTO> ObterPorIdAsync(Guid id) 
        {            
            var funcionario = await this.funcionariosProvider.ObterAsync(id);

            return this.mapper.Map<FuncionarioTO>(funcionario);
        }

        ///<summary>
        /// Buscar todos os funcionarios
        ///</summary>
        public async Task<IEnumerable<FuncionarioTO>> ObterTodosAsync() 
        {            
            var funcionarios = await this.funcionariosProvider.ListarAsync();

            return funcionarios.Select(this.mapper.Map<FuncionarioTO>).ToList();
        }
    }
}