using Microsoft.AspNetCore.Mvc;
using ProspAI_Sprint3.Models;
using ProspAI_Sprint3.Persistencia.Services;

namespace ProspAI_Sprint3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PredicaoReclamacaoController : ControllerBase
    {
        private readonly ReclamacaoPredictionService _predictionService;

        public PredicaoReclamacaoController(ReclamacaoPredictionService predictionService)
        {
            _predictionService = predictionService;
        }

        /// <summary>
        /// Realiza uma predição do número de reclamações solucionadas com base em dados de desempenho.
        /// </summary>
        /// <param name="input">Dados de entrada para a predição.</param>
        /// <returns>Retorna o número previsto de reclamações solucionadas.</returns>
        [HttpPost("prever")]
        public ActionResult<float> PreverReclamacoesSolu([FromBody] FuncionarioDesempenho input)
        {
            if (input == null)
                return BadRequest("Dados de entrada inválidos");

            var resultado = _predictionService.PredictReclamacoesSolu(input.FuncionarioId, input.ReclamacoesResp, input.DesempenhoGeral);

            return Ok(resultado);
        }
    }
}
