using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using ProspAI_Sprint3.Models;
using ProspAI_Sprint3.Repositories;
using ProspAI_Sprint3.Services;

namespace ProspAI_Sprint3.Tests.Services
{
    public class DesempenhoServiceTests
    {
        private readonly Mock<IRepository<Desempenho>> _desempenhoRepositoryMock;
        private readonly DesempenhoService _desempenhoService;

        public DesempenhoServiceTests()
        {
            _desempenhoRepositoryMock = new Mock<IRepository<Desempenho>>();
            _desempenhoService = new DesempenhoService(_desempenhoRepositoryMock.Object);
        }

        [Fact]
        public async Task ObterTodosAsync_DeveRetornarTodosDesempenhos()
        {
            // Arrange
            var desempenhosEsperados = new List<Desempenho>
            {
                new Desempenho { Id_desem = 1, Mes_desem = "Janeiro", Reclamacoes_resp = 5, Reclamacoes_solu = 3, Id_fun = 1 },
                new Desempenho { Id_desem = 2, Mes_desem = "Fevereiro", Reclamacoes_resp = 8, Reclamacoes_solu = 6, Id_fun = 2 }
            };
            _desempenhoRepositoryMock.Setup(repo => repo.ObterTodosAsync()).ReturnsAsync(desempenhosEsperados);

            // Act
            var desempenhos = await _desempenhoService.ObterTodosAsync();

            // Assert
            Assert.Equal(desempenhosEsperados, desempenhos);
        }

        [Fact]
        public async Task ObterPorIdAsync_DeveRetornarDesempenhoCorreto()
        {
            // Arrange
            var desempenhoEsperado = new Desempenho { Id_desem = 1, Mes_desem = "Janeiro", Reclamacoes_resp = 5, Reclamacoes_solu = 3, Id_fun = 1 };
            _desempenhoRepositoryMock.Setup(repo => repo.ObterPorIdAsync(1)).ReturnsAsync(desempenhoEsperado);

            // Act
            var desempenho = await _desempenhoService.ObterPorIdAsync(1);

            // Assert
            Assert.Equal(desempenhoEsperado, desempenho);
        }

        [Fact]
        public async Task AdicionarAsync_DeveAdicionarDesempenho()
        {
            // Arrange
            var novoDesempenho = new Desempenho { Id_desem = 3, Mes_desem = "Março", Reclamacoes_resp = 10, Reclamacoes_solu = 8, Id_fun = 3 };
            _desempenhoRepositoryMock.Setup(repo => repo.AdicionarAsync(novoDesempenho)).ReturnsAsync(novoDesempenho);

            // Act
            var desempenhoAdicionado = await _desempenhoService.AdicionarAsync(novoDesempenho);

            // Assert
            Assert.Equal(novoDesempenho, desempenhoAdicionado);
        }

        [Fact]
        public async Task AtualizarAsync_DeveAtualizarDesempenho()
        {
            // Arrange
            var desempenhoExistente = new Desempenho { Id_desem = 1, Mes_desem = "Janeiro", Reclamacoes_resp = 5, Reclamacoes_solu = 3, Id_fun = 1 };
            _desempenhoRepositoryMock.Setup(repo => repo.AtualizarAsync(desempenhoExistente)).Returns(Task.CompletedTask);

            // Act
            await _desempenhoService.AtualizarAsync(desempenhoExistente);

            // Assert
            _desempenhoRepositoryMock.Verify(repo => repo.AtualizarAsync(desempenhoExistente), Times.Once);
        }

        [Fact]
        public async Task ExcluirAsync_DeveExcluirDesempenho()
        {
            // Arrange
            var desempenhoId = 1;
            _desempenhoRepositoryMock.Setup(repo => repo.ExcluirAsync(desempenhoId)).Returns(Task.CompletedTask);

            // Act
            await _desempenhoService.ExcluirAsync(desempenhoId);

            // Assert
            _desempenhoRepositoryMock.Verify(repo => repo.ExcluirAsync(desempenhoId), Times.Once);
        }
    }
}
