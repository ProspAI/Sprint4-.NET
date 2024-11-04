using ProspAI_Sprint3.Models;
using ProspAI_Sprint3.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProspAI_Sprint3.Services
{
    /// <summary>
    /// Serviço responsável pela gestão dos desempenhos dos funcionários.
    /// </summary>
    public class DesempenhoService : IService<Desempenho>
    {
        private readonly IRepository<Desempenho> _desempenhoRepository;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="DesempenhoService"/> com o repositório de desempenho especificado.
        /// </summary>
        /// <param name="desempenhoRepository">O repositório de desempenhos.</param>
        public DesempenhoService(IRepository<Desempenho> desempenhoRepository)
        {
            _desempenhoRepository = desempenhoRepository;
        }

        /// <summary>
        /// Obtém todos os desempenhos.
        /// </summary>
        /// <returns>Uma lista de todos os desempenhos.</returns>
        public async Task<IEnumerable<Desempenho>> ObterTodosAsync()
        {
            return await _desempenhoRepository.ObterTodosAsync();
        }

        /// <summary>
        /// Obtém um desempenho específico pelo ID.
        /// </summary>
        /// <param name="id">O ID do desempenho.</param>
        /// <returns>O desempenho correspondente ao ID fornecido.</returns>
        public async Task<Desempenho> ObterPorIdAsync(int id)
        {
            return await _desempenhoRepository.ObterPorIdAsync(id);
        }

        /// <summary>
        /// Adiciona um novo desempenho.
        /// </summary>
        /// <param name="desempenho">O desempenho a ser adicionado.</param>
        /// <returns>O desempenho adicionado.</returns>
        public async Task<Desempenho> AdicionarAsync(Desempenho desempenho)
        {
            return await _desempenhoRepository.AdicionarAsync(desempenho);
        }

        /// <summary>
        /// Atualiza um desempenho existente.
        /// </summary>
        /// <param name="desempenho">O desempenho a ser atualizado.</param>
        public async Task AtualizarAsync(Desempenho desempenho)
        {
            await _desempenhoRepository.AtualizarAsync(desempenho);
        }

        /// <summary>
        /// Exclui um desempenho pelo ID.
        /// </summary>
        /// <param name="id">O ID do desempenho a ser excluído.</param>
        public async Task ExcluirAsync(int id)
        {
            await _desempenhoRepository.ExcluirAsync(id);
        }
    }
}
