using GatewayConsultaApiVerde.Models;
using GatewayConsultaApiVerde.Services.ConsultasBase;
using System.Text.Json;

namespace GatewayConsultaApiVerde.Services.Apenado
{
    public class ApenadoService : IApenadoService
    {
        private readonly IConsultaVerdeClient _consultaVerdeClient;

        public ApenadoService(IConsultaVerdeClient consultaVerdeClient)
        {
            _consultaVerdeClient = consultaVerdeClient;
        }

        // POST /integra/apenado no Verde real. Body raw (JsonDocument) repassado
        // como veio — não desserializa/reserializa em ApenadoResponseDTO aqui pra
        // não arriscar perder campo se o shape real do Verde divergir do
        // documentado no Swagger oficial (padrão já visto: doc erra, resposta
        // real é diferente). ApenadoResponseDTO existe só pra anotar o contrato
        // esperado no Swagger deste gateway (ProducesResponseType).
        public Task<(int StatusCode, JsonDocument? Body)> ConsultarAsync(ConsultarApenadoRequestDTO dados) =>
            _consultaVerdeClient.PostAsync("apenado", dados);
    }
}
