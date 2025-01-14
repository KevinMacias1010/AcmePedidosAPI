using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace AcmePedidosAPI.Services;

public class SoapService : ISoapService
{
    private readonly HttpClient _httpClient;

    public SoapService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> EnviarPedidoAsync(string xmlRequest)
    {
        var content = new StringContent(xmlRequest, Encoding.UTF8, "text/xml");

        var response = await _httpClient.PostAsync("https://run.mocky.io/v3/19217075-6d4e-4818-98bc-416d1feb7b84", content);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }
}
