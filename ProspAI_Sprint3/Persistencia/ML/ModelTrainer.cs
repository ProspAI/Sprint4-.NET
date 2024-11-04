using Microsoft.ML;
using ProspAI_Sprint3.Models;

public class MLModelTrainer
{
    /// <summary>
    /// Treina um modelo de Machine Learning com base nos dados de desempenho dos funcionários.
    /// </summary>
    /// <remarks>
    /// Este método inicializa um contexto de ML, carrega os dados de treinamento a partir de um arquivo CSV,
    /// e cria uma pipeline de treinamento que utiliza o algoritmo SDCA para regressão.
    /// O modelo treinado é salvo em um arquivo ZIP para uso futuro.
    /// </remarks>
    /// <exception cref="FileNotFoundException">Lançado quando o arquivo CSV especificado não é encontrado.</exception>
    public void TreinarModelo()
    {
        // Inicializa o contexto de ML
        MLContext mlContext = new MLContext();

        // Caminho para o arquivo CSV contendo dados de desempenho dos funcionários
        string dataPath = "Data/funcionario_desempenho.csv";

        // Verifica se o arquivo CSV existe
        if (!File.Exists(dataPath))
        {
            throw new FileNotFoundException($"Arquivo CSV não encontrado: {dataPath}");
        }

        // Carrega os dados de treinamento a partir do CSV
        IDataView dataView = mlContext.Data.LoadFromTextFile<FuncionarioDesempenho>(
            dataPath,
            hasHeader: true,
            separatorChar: ',');

        // Cria a pipeline de treinamento
        var pipeline = mlContext.Transforms.Concatenate("Features", new[] { "FuncionarioId", "ReclamacoesResp", "DesempenhoGeral" })
            .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "ReclamacoesSolu", featureColumnName: "Features"));

        // Treina o modelo
        var model = pipeline.Fit(dataView);

        // Caminho para salvar o modelo treinado
        string modelPath = "Data/ModeloReclamacoes.zip";

        // Salva o modelo treinado em um arquivo ZIP
        mlContext.Model.Save(model, dataView.Schema, modelPath);
    }
}
