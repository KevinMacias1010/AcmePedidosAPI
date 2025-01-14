using System.IO;
using System.Xml.Serialization;
using AcmePedidosAPI.Models;

namespace AcmePedidosAPI.Helpers;

public static class SoapHelper
{
    public static string JsonToXml(PedidoRequest request)
    {
        var xmlSerializer = new XmlSerializer(typeof(PedidoRequest));
        using var stringWriter = new StringWriter();
        xmlSerializer.Serialize(stringWriter, request);
        return stringWriter.ToString();
    }

    public static T XmlToJson<T>(string xml)
    {
        var xmlSerializer = new XmlSerializer(typeof(T));
        using var stringReader = new StringReader(xml);
        return (T)xmlSerializer.Deserialize(stringReader);
    }
}
