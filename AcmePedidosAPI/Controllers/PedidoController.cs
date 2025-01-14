using AcmePedidosAPI.Helpers;
using AcmePedidosAPI.Models;
using AcmePedidosAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AcmePedidosAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidoController : ControllerBase
{
    private readonly ISoapService _soapService;

    public PedidoController(ISoapService soapService)
    {
        _soapService = soapService;
    }

    [HttpPost("enviarPedido")]
    public async Task<IActionResult> EnviarPedido([FromBody] PedidoRequest request)
    {
        try
        {
            // Convertir JSON a XML
            var xmlRequest = SoapHelper.JsonToXml(request);

            // Consumir el servicio SOAP
            var xmlResponse = await _soapService.EnviarPedidoAsync(xmlRequest);

            // Convertir XML a JSON
            var response = SoapHelper.XmlToJson<PedidoResponse>(xmlResponse);

            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }
}