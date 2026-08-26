using System.Text.Json.Serialization;

namespace GatewayConsultaApiVerde.Models
{
    // Espelha ConsultarApenadoDTO do Verde real (POST /integra/apenado,
    // confirmado no Swagger oficial). "rg" é obrigatório no Verde (400 se
    // ausente) — string (não-nullable) de propósito, pra ASP.NET já barrar
    // com 400 de validação antes de sequer chamar o Verde.
    public class ConsultarApenadoRequestDTO
    {
        [JsonPropertyName("rg")]
        public string Rg { get; set; } = string.Empty;
    }
}
