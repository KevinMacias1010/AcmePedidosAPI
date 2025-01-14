namespace AcmePedidosAPI.Services;

public interface ISoapService
{
    Task<string> EnviarPedidoAsync(string xmlRequest);
}
