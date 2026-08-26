using GatewayConsultaApiVerde.Models;
using System.Text.Json;

namespace GatewayConsultaApiVerde.Services.Apenado
{
    public interface IApenadoService
    {
        Task<(int StatusCode, JsonDocument? Body)> ConsultarAsync(ConsultarApenadoRequestDTO dados);
    }
}
