using ProspAI_Sprint3.Models;
using ProspAI_Sprint3.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProspAI_Sprint3.Services
{
    /// <summary>
    /// Serviço responsável pela gestão dos funcionários.
    /// </summary>
    public class FuncionarioService : IService<Funcionario>
    {
        private readonly IRepository<Funcionario> _funcionarioRepository;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="FuncionarioService"/> com o repositório de funcionários especificado.
        /// </summary>
        /// <param name="funcionarioRepository">O repositório de funcionários.</param>
        public FuncionarioService(IRepository<Funcionario> funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        /// <summary>
        /// Obtém todos os funcionários.
        /// </summary>
        /// <returns>Uma lista de todos os funcionários.</returns>
        public async Task<IEnumerable<Funcionario>> ObterTodosAsync()
        {
            return await _funcionarioRepository.ObterTodosAsync();
        }

        /// <summary>
        /// Obtém um funcionário específico pelo ID.
        /// </summary>
        /// <param name="id">O ID do funcionário.</param>
        /// <returns>O funcionário correspondente ao ID fornecido.</returns>
        public async Task<Funcionario> ObterPorIdAsync(int id)
        {
            return await _funcionarioRepository.ObterPorIdAsync(id);
        }

        /// <summary>
        /// Adiciona um novo funcionário.
        /// </summary>
        /// <param name="funcionario">O funcionário a ser adicionado.</param>
        /// <returns>O funcionário adicionado.</returns>
        public async Task<Funcionario> AdicionarAsync(Funcionario funcionario)
        {
            return await _funcionarioRepository.AdicionarAsync(funcionario);
        }

        /// <summary>
        /// Atualiza um funcionário existente.
        /// </summary>
        /// <param name="funcionario">O funcionário a ser atualizado.</param>
        public async Task AtualizarAsync(Funcionario funcionario)
        {
            await _funcionarioRepository.AtualizarAsync(funcionario);
        }

        /// <summary>
        /// Exclui um funcionário pelo ID.
        /// </summary>
        /// <param name="id">O ID do funcionário a ser excluído.</param>
        public async Task ExcluirAsync(int id)
        {
            await _funcionarioRepository.ExcluirAsync(id);
        }
    }
}
