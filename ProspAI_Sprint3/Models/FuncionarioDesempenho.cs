using Microsoft.ML.Data;
using Swashbuckle.AspNetCore.Annotations;

public class FuncionarioDesempenho
{
    [LoadColumn(0)]
    [SwaggerSchema("Identificador do funcionário.")]
    public string FuncionarioId { get; set; }

    [LoadColumn(1)]
    [SwaggerSchema("Mês referente ao desempenho.")]
    public string Mes { get; set; }

    [LoadColumn(2)]
    [SwaggerSchema("Número de reclamações respondidas pelo funcionário.")]
    public float ReclamacoesResp { get; set; }

    [LoadColumn(3)]
    [SwaggerSchema("Número de reclamações solucionadas pelo funcionário.")]
    public float ReclamacoesSolu { get; set; }

    [LoadColumn(4)]
    [SwaggerSchema("Desempenho geral do funcionário.")]
    public float DesempenhoGeral { get; set; }
}
