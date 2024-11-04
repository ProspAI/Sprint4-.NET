using Moq;
using ProspAI_Sprint3.Models;
using ProspAI_Sprint3.Repositories;
using ProspAI_Sprint3.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ProspAI.Tests
{
	public class FuncionarioServiceTests
	{
		private readonly Mock<IRepository<Funcionario>> _mockRepository;
		private readonly FuncionarioService _service;

		public FuncionarioServiceTests()
		{
			_mockRepository = new Mock<IRepository<Funcionario>>();
			_service = new FuncionarioService(_mockRepository.Object);
		}

		// Teste existente para obter todos os funcionários
		[Fact]
		public async Task ObterTodosAsync_DeveRetornarFuncionarios()
		{
			// Arrange
			var funcionarios = new List<Funcionario>
			{
				new Funcionario { Id_fun = 1, Nome_fun = "Funcionario 1" },
				new Funcionario { Id_fun = 2, Nome_fun = "Funcionario 2" }
			};

			_mockRepository.Setup(repo => repo.ObterTodosAsync())
				.ReturnsAsync(funcionarios);

			// Act
			var result = await _service.ObterTodosAsync();

			// Assert
			Assert.Equal(2, ((List<Funcionario>)result).Count);
		}

		
		[Fact]
		public async Task ObterPorIdAsync_DeveRetornarNullParaFuncionarioInexistente()
		{
			// Arrange
			_mockRepository.Setup(repo => repo.ObterPorIdAsync(It.IsAny<int>()))
				.ReturnsAsync((Funcionario)null);

			// Act
			var result = await _service.ObterPorIdAsync(999);

			// Assert
			Assert.Null(result);
		}

		
		[Fact]
		public async Task AdicionarAsync_DeveLancarExcecaoParaFuncionarioNulo()
		{
			// Arrange
			Funcionario funcionario = null;

			// Act & Assert
			await Assert.ThrowsAsync<ArgumentNullException>(() => _service.AdicionarAsync(funcionario));
		}

		// Teste para atualizar um funcionário inexistente ou nulo
		[Fact]
		public async Task AtualizarAsync_DeveLancarExcecaoParaFuncionarioNulo()
		{
			// Arrange
			Funcionario funcionario = null;

			// Act & Assert
			await Assert.ThrowsAsync<ArgumentNullException>(() => _service.AtualizarAsync(funcionario));
		}

		
		[Fact]
		public async Task ExcluirAsync_DeveLancarExcecaoParaFuncionarioInexistente()
		{
			// Arrange
			int idInexistente = 999;
			_mockRepository.Setup(repo => repo.ExcluirAsync(idInexistente))
				.ThrowsAsync(new KeyNotFoundException("Funcionário não encontrado"));

			// Act & Assert
			await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.ExcluirAsync(idInexistente));
		}
	}
}
