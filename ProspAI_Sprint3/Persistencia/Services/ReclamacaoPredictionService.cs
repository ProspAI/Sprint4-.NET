using Microsoft.ML;
using Microsoft.ML.Data;
using ProspAI_Sprint3.Models;

namespace ProspAI_Sprint3.Persistencia.Services
{
    public class ReclamacaoPredictionService
    {
        private readonly MLContext _mlContext;
        private ITransformer _model;

        public ReclamacaoPredictionService()
        {
            _mlContext = new MLContext();
            TrainModel();
        }

        // Método para treinar o modelo
        private void TrainModel()
        {
            // Carregar os dados do CSV
            IDataView dataView = _mlContext.Data.LoadFromTextFile<FuncionarioDesempenho>(
                path: "Data/funcionario_desempenho.csv",
                hasHeader: true,
                separatorChar: ','
            );

            // Definir o pipeline de aprendizado
            var pipeline = _mlContext.Transforms.Conversion.MapValueToKey("FuncionarioId")
                .Append(_mlContext.Transforms.Concatenate("Features", "ReclamacoesResp", "DesempenhoGeral")) // Não inclui FuncionarioId aqui
                .Append(_mlContext.Regression.Trainers.Sdca(labelColumnName: "ReclamacoesSolu"));

            // Treinar o modelo
            _model = pipeline.Fit(dataView);
        }

        // Método para fazer a previsão
        public float PredictReclamacoesSolu(string funcionarioId, float reclamacoesResp, float desempenhoGeral)
        {
            // Cria o PredictionEngine com o modelo treinado
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<FuncionarioDesempenho, ReclamacaoPrediction>(_model);

            // Cria a entrada para a previsão
            var input = new FuncionarioDesempenho
            {
                FuncionarioId = funcionarioId,
                ReclamacoesResp = reclamacoesResp,
                DesempenhoGeral = desempenhoGeral
            };

            // Realiza a previsão
            var prediction = predictionEngine.Predict(input);
            return prediction.ReclamacoesSoluPrevistas;
        }
    }
}
