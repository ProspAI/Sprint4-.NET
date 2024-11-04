Aqui está o README completo atualizado com as seções sobre testes, práticas de Clean Code e funcionalidades de IA generativa:

---

# ProspAI - Versão .NET

**ProspAI** é uma aplicação de inteligência artificial desenvolvida para otimizar estratégias de vendas através da análise de dados de clientes. A aplicação oferece uma API RESTful robusta e uma interface MVC baseada em ASP.NET Core, facilitando a navegação e a utilização dos recursos disponíveis.

## Índice

1. [Visão Geral do Projeto](#visão-geral-do-projeto)
2. [Arquitetura](#arquitetura)
3. [Recursos Principais](#recursos-principais)
4. [Tecnologias Utilizadas](#tecnologias-utilizadas)
5. [Padrões de Projeto Implementados](#padrões-de-projeto-implementados)
6. [Testes Implementados](#testes-implementados)
7. [Práticas de Clean Code e SOLID](#práticas-de-clean-code-e-solid)
8. [Funcionalidades de IA Generativa](#funcionalidades-de-ia-generativa)
9. [Endpoints da API](#endpoints-da-api)
10. [Documentação Swagger](#documentação-swagger)
11. [Instalação e Configuração](#instalação-e-configuração)
12. [Como Contribuir](#como-contribuir)
13. [Licença](#licença)
14. [Autores](#autores)

## Visão Geral do Projeto

**ProspAI** é uma plataforma que combina inteligência artificial e análise de dados para melhorar a tomada de decisão em vendas. Através da integração com fontes de dados externas, como Reclame Aqui e Procon, a aplicação consegue analisar feedbacks de clientes e oferecer predições e relatórios detalhados para otimização de estratégias de vendas.

## Arquitetura

A aplicação ProspAI é composta de duas partes principais:

1. **API RESTful**: Construída utilizando ASP.NET Core, oferecendo endpoints para operações CRUD sobre funcionários, reclamações, desempenhos, entre outros.
   
2. **Interface MVC**: Baseada em Razor Pages, a interface MVC proporciona uma experiência de usuário intuitiva e permite a visualização e manipulação dos dados de forma amigável.

A aplicação utiliza os padrões de Repositório e Serviço para manter uma separação clara de responsabilidades e facilitar a realização de testes unitários.

## Recursos Principais

- **Gestão de Funcionários**: Criação, edição, visualização e remoção de funcionários.
- **Gestão de Reclamações**: Manipulação de reclamações associadas a funcionários.
- **Análise de Desempenho**: Geração de relatórios de desempenho com base nos dados das reclamações e respostas dos funcionários.
- **Automação de Estratégias de Vendas**: Definição e implementação de estratégias automáticas para otimização de vendas.
- **Gestão de Usuários**: Controle de acesso e gerenciamento de usuários da plataforma.

## Tecnologias Utilizadas

- .NET 6
- ASP.NET Core Web API e MVC
- Entity Framework Core com integração ao Oracle
- AutoMapper para mapeamento de objetos
- Swagger/OpenAPI para documentação da API
- JavaScript e Bootstrap para interatividade e design responsivo

## Padrões de Projeto Implementados

- **DTO (Data Transfer Object)**: Utilizados para transferir dados entre a camada de serviço e a camada de apresentação.
- **Padrão de Repositório**: Fornece uma API limpa para a lógica de acesso a dados.
- **Padrão de Serviço**: Separa a lógica de negócios dos controladores e repositórios.
- **Injeção de Dependência**: Implementada para gerenciar dependências e promover testabilidade.

## Testes Implementados

O projeto utiliza o framework **xUnit** para implementação de testes unitários e **Moq** para mockar dependências, permitindo a verificação do comportamento isolado dos serviços.

### Tipos de Testes

1. **Testes Unitários**:
   - Verificam a lógica de cada método individualmente, garantindo que cada operação funcione conforme esperado.
   - Exemplos: `FuncionarioServiceTests`, `DesempenhoServiceTests`, e `ReclamacaoServiceTests` incluem testes para métodos como `ObterTodosAsync`, `ObterPorIdAsync`, `AdicionarAsync`, `AtualizarAsync`, e `ExcluirAsync`.

2. **Testes de Integração**:
   - Podem ser incluídos para testar a interação entre serviços e o banco de dados, garantindo que os dados são manipulados corretamente.
   - Recomenda-se a implementação de testes de integração para validar as consultas e operações de CRUD diretamente no contexto do banco de dados, usando o `ApplicationDbContext`.

3. **Testes de Sistema**:
   - Simulam fluxos completos de utilização da API, desde a criação até a exclusão de registros.
   - Recomendamos o uso de ferramentas como Postman ou Cypress para criar uma suíte de testes de sistema automatizados.

## Práticas de Clean Code e SOLID

O código do projeto foi desenvolvido aplicando **práticas de Clean Code** e **princípios SOLID** para melhorar a legibilidade, manutenibilidade e testabilidade.

### Clean Code
- **Nomenclatura Clara**: Nomes de variáveis e métodos são intuitivos e descritivos, facilitando o entendimento do código.
- **Separação de Responsabilidades**: A lógica de negócio foi segregada em serviços e repositórios, enquanto os controladores são responsáveis apenas por lidar com as requisições HTTP.
- **Comentários e Documentação**: Cada classe e método principal possui comentários e documentação XML para facilitar a compreensão e manutenção.

### Princípios SOLID

1. **Single Responsibility Principle (SRP)**: 
   - Cada classe tem uma única responsabilidade. Por exemplo, `FuncionarioService` é responsável apenas pela lógica de negócios de funcionários, enquanto `FuncionarioRepository` lida com o acesso aos dados.

2. **Open/Closed Principle (OCP)**: 
   - As classes foram projetadas para serem estendidas sem modificações. Por exemplo, os serviços podem ser expandidos com novas funcionalidades sem alterar o código existente.

3. **Liskov Substitution Principle (LSP)**:
   - Todas as interfaces e classes base podem ser substituídas por suas implementações sem quebrar o código. Os serviços e repositórios implementam interfaces que seguem esse princípio.

4. **Interface Segregation Principle (ISP)**:
   - Interfaces específicas para cada entidade (`IRepository` e `IService`) asseguram que cada serviço ou repositório usa apenas os métodos necessários.

5. **Dependency Inversion Principle (DIP)**:
   - As dependências são injetadas nas classes, facilitando a troca de implementações e a realização de testes, com todos os serviços e repositórios sendo injetados via construtor.

## Funcionalidades de IA Generativa

O ProspAI integra um modelo de Machine Learning desenvolvido com **ML.NET** para fornecer insights baseados nos dados de desempenho dos funcionários.

### Modelos Implementados

- **Previsão de Reclamações Solucionadas**:
   - Utilizando um modelo de regressão, a aplicação prediz o número de reclamações que um funcionário pode resolver com base em seu histórico de desempenho, ajudando a identificar colaboradores que precisam de suporte adicional para melhorar sua performance.


## Endpoints da API

Abaixo está a lista de principais endpoints da API RESTful disponíveis:

### Funcionários (/api/funcionarios)
- `GET /api/funcionarios` - Retorna todos os funcionários.
- `GET /api/funcionarios/{id}` - Retorna um funcionário específico por ID.
- `POST /api/funcionarios` - Cria um novo funcionário.
- `PUT /api/funcionarios/{id}` - Atualiza um funcionário existente.
- `DELETE /api/funcionarios/{id}` - Deleta um funcionário.

### Reclamações (/api/reclamacoes)
- `GET /api/reclamacoes` - Retorna todas as reclamações.
- `GET /api/reclamacoes/{id}` - Retorna uma reclamação específica por ID.
- `POST /api/reclamacoes` - Cria uma nova reclamação.
- `PUT /api/reclamacoes/{id}` - Atualiza uma reclamação existente.
- `DELETE /api/reclamacoes/{id}` - Deleta uma reclamação.

### Desempenho (/api/desempenho)
- `GET /api/desempenho` - Retorna todos os registros de desempenho.
- `GET /api/desempenho/{id}` - Retorna um registro de desempenho específico por ID.
- `POST /api/desempenho` - Cria um novo registro de desempenho.
- `PUT /api/desempenho/{id}` - Atualiza um registro de desempenho existente.
- `DELETE /api/desempenho/{id}` - Deleta um registro de desempenho.

## Documentação Swagger

Para testar e visualizar a documentação dos endpoints da API, acesse:

- **Ambiente Local:** [http://localhost:5000/swagger](http://localhost:5000/swagger)

## Instalação e Configuração

1. **Clone o Repositório:**
   ```bash
   git clone https://github.com/seu-usuario/prospai-dotnet

.git
   cd prospai-dotnet
   ```

2. **Configure o Banco de Dados:**
   - A aplicação utiliza Oracle. Atualize as configurações do banco de dados no arquivo `appsettings.json` conforme necessário.

3. **Execute a Aplicação:**
   - Utilize o .NET CLI ou qualquer IDE (como Visual Studio ou Rider) para compilar e executar o projeto:
   ```bash
   dotnet run
   ```

4. **Acesse a Aplicação:**
   - Acesse a aplicação através do navegador: [http://localhost:5000/api/funcionarios](http://localhost:5000/api/funcionarios).

## Como Contribuir

1. **Fork o Projeto**
2. **Crie um Branch de Funcionalidade**
   ```bash
   git checkout -b nova-funcionalidade
   ```
3. **Commit suas Alterações**
   ```bash
   git commit -m 'Adiciona nova funcionalidade'
   ```
4. **Envie o Branch**
   ```bash
   git push origin nova-funcionalidade
   ```
5. **Abra um Pull Request**

## Licença

Este projeto é licenciado sob os termos da MIT License.

## Autores

Este projeto foi desenvolvido por:

- **AGATHA PIRES** – RM552247 – (2TDSPH)
- **DAVID BRYAN VIANA** – RM551236 – (2TDSPM)
- **GABRIEL LIMA** – RM99743 – (2TDSPM)
- **GIOVANNA ALVAREZ** – RM98892 – (2TDSPM)
- **MURILO MATOS** – RM552525 – (2TDSPM)

---

Sinta-se à vontade para contribuir com melhorias e novas funcionalidades para o ProspAI!

--- 
