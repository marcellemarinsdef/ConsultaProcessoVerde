using GatewayConsultaApiVerde.Exceptions;
using GatewayConsultaApiVerde.Models;
using GatewayConsultaApiVerde.Services.Apenado;
using Microsoft.AspNetCore.Mvc;
using Polly.Timeout;

namespace GatewayConsultaApiVerde.Controllers
{
    // Consulta dados de pessoa presa (apenado) pelo RG — usado pelo node de
    // fluxo "Pessoa Presa" da Maria pra achar o assistido preso a partir do
    // RG informado por quem busca ajuda. Espelha POST /integra/apenado do
    // Verde real (confirmado no Swagger oficial), que por sua vez consulta
    // e atualiza os dados via SIPEN.
    [Route("api/apenado")]
    public class ApenadoController : ApiControllerBase
    {
        private readonly IApenadoService _client;

        public ApenadoController(IApenadoService apenadoService)
        {
            _client = apenadoService;
        }

        ///<summary>
        ///Consulta os dados de um apenado (pessoa presa) pelo RG.
        ///</summary>
        ///<remarks>
        ///Consulta e atualiza os dados do apenado via SIPEN. Se o campo "dados"
        ///vier vazio na resposta, o apenado não foi encontrado pra esse RG.
        /// </remarks>
        ///<param name="dados">RG do apenado a consultar</param>
        [HttpPost("consultar")]
        [ProducesResponseType(typeof(ApenadoResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status503ServiceUnavailable)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status504GatewayTimeout)]
        public async Task<IActionResult> Consultar([FromBody] ConsultarApenadoRequestDTO dados)
        {
            if (string.IsNullOrWhiteSpace(dados?.Rg))
            {
                return ErroParametroInvalido("RG do apenado obrigatório");
            }

            try
            {
                var (statusCode, body) = await _client.ConsultarAsync(dados);
                return StatusCode(statusCode, body);
            }
            catch (TimeoutRejectedException)
            {
                return ErroTimeout("Tempo limite excedido ao consultar o apenado.");
            }
            catch (ApiException ex)
            {
                return ErroApi(ex);
            }
        }
    }
}
