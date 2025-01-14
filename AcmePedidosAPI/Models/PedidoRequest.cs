namespace AcmePedidosAPI.Models;

public class PedidoRequest
{
    public string NumPedido { get; set; }
    public int CantidadPedido { get; set; }
    public string CodigoEAN { get; set; }
    public string NombreProducto { get; set; }
    public string NumDocumento { get; set; }
    public string Direccion { get; set; }
}

public class PedidoResponse
{
    public string CodigoEnvio { get; set; }
    public string Estado { get; set; }
}
