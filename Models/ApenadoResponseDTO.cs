using System.Text.Json.Serialization;

namespace GatewayConsultaApiVerde.Models
{
    // Espelha ApenadoResponseDTO/ApenadoDTO/UnidadePrisionalDTO do Verde real
    // (resposta de POST /integra/apenado, confirmado no Swagger oficial).
    // "dados" vazio (todos os campos default/null) = apenado não encontrado,
    // conforme a doc do Verde ("Se o campo dados vier vazio...").
    public class ApenadoResponseDTO
    {
        [JsonPropertyName("codigo")]
        public string? Codigo { get; set; }

        [JsonPropertyName("mensagem")]
        public string? Mensagem { get; set; }

        [JsonPropertyName("dados")]
        public ApenadoDTO? Dados { get; set; }
    }

    public class ApenadoDTO
    {
        [JsonPropertyName("idSeap")]
        public int IdSeap { get; set; }

        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("cpf")]
        public string? Cpf { get; set; }

        [JsonPropertyName("regime")]
        public string? Regime { get; set; }

        [JsonPropertyName("situacao")]
        public string? Situacao { get; set; }

        [JsonPropertyName("unidadePrisional")]
        public UnidadePrisionalDTO? UnidadePrisional { get; set; }

        [JsonPropertyName("unidadeDeBaixa")]
        public string? UnidadeDeBaixa { get; set; }

        [JsonPropertyName("tipoPreso")]
        public string? TipoPreso { get; set; }

        [JsonPropertyName("idPessoa")]
        public int IdPessoa { get; set; }
    }

    // Não documentado no Swagger local do Verde além do shape básico —
    // confirmado via `docs/verde-original.json` (definitions/UnidadePrisionalDTO).
    public class UnidadePrisionalDTO
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("noUnidade")]
        public string? NoUnidade { get; set; }

        [JsonPropertyName("sgUnidade")]
        public string? SgUnidade { get; set; }
    }
}
