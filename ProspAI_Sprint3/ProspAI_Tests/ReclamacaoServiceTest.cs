using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using ProspAI_Sprint3.Models;
using ProspAI_Sprint3.Repositories;
using ProspAI_Sprint3.Services;

public class ReclamacaoServiceTests
{
    private readonly Mock<IRepository<Reclamacao>> _reclamacaoRepositoryMock;
    private readonly ReclamacaoService _reclamacaoService;

    public ReclamacaoServiceTests()
    {
        _reclamacaoRepositoryMock = new Mock<IRepository<Reclamacao>>();
        _reclamacaoService = new ReclamacaoService(_reclamacaoRepositoryMock.Object);
    }

    [Fact]
    public async Task ObterTodosAsync_DeveRetornarTodasReclamacoes()
    {
        // Arrange
        var reclamacoesEsperadas = new List<Reclamacao>
        {
            new Reclamacao { Id_recla = 1, Nm_clie = "Cliente A", Assunto_recla = "Problema 1" },
            new Reclamacao { Id_recla = 2, Nm_clie = "Cliente B", Assunto_recla = "Problema 2" }
        };
        _reclamacaoRepositoryMock.Setup(repo => repo.ObterTodosAsync()).ReturnsAsync(reclamacoesEsperadas);

        // Act
        var reclamacoes = await _reclamacaoService.ObterTodosAsync();

        // Assert
        Assert.Equal(reclamacoesEsperadas, reclamacoes);
    }

    [Fact]
    public async Task ObterPorIdAsync_DeveRetornarReclamacaoCorreta()
    {
        // Arrange
        var reclamacaoEsperada = new Reclamacao { Id_recla = 1, Nm_clie = "Cliente A", Assunto_recla = "Problema 1" };
        _reclamacaoRepositoryMock.Setup(repo => repo.ObterPorIdAsync(1)).ReturnsAsync(reclamacaoEsperada);

        // Act
        var reclamacao = await _reclamacaoService.ObterPorIdAsync(1);

        // Assert
        Assert.Equal(reclamacaoEsperada, reclamacao);
    }
}
