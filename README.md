# AcmePedidosAPI

Este es un proyecto de prueba técnica donde se implementa una API RESTful que consume un servicio SOAP para enviar pedidos. La API está construida con .NET 8 y realiza una conversión de datos entre JSON y XML para interactuar con el servicio SOAP.

## Estructura del Proyecto

- **Controllers/PedidoController.cs**: Controlador encargado de manejar las solicitudes HTTP relacionadas con los pedidos.
- **Helpers/SoapHelper.cs**: Utilidad para convertir entre JSON y XML.
- **Services/SoapService.cs**: Servicio encargado de consumir el servicio SOAP externo.

## Problema con la URL Externa

Durante el desarrollo, se utilizó un servicio externo proporcionado por **Mocky.io** para simular el servicio SOAP al que se enviarán los pedidos. Sin embargo, en este momento, la URL del servicio de Mocky **(https://run.mocky.io/v3/19217075-6d4e-4818-98bc-416d1feb7b84)** no está funcionando. Por lo tanto, las solicitudes a la API para enviar pedidos pueden no devolver resultados exitosos en este entorno.


## Cómo Ejecutar el Proyecto

### Requisitos

- .NET 8 SDK o superior
- Docker (opcional, para ejecutar en contenedores)

### Ejecución en Local

1. **Clonar el repositorio**:
    ```bash
    git clone https://github.com/KevinMacias1010/AcmePedidosAPI.git
    cd AcmePedidosAPI
    ```

3. **Ejecutar la API**:
    Para ejecutar el proyecto en local:
    ```bash
    dotnet run
    ```

4. **Probar la API**:
    La API se ejecutará en `http://localhost:5000` (por defecto) o `https://localhost:5001`. Puedes probar el endpoint `POST /api/pedido/enviarPedido` enviando un cuerpo JSON con los siguientes parámetros:

    ```json
    {
        "numPedido": "75630275",
        "cantidadPedido": 1,
        "codigoEAN": "00110000765191002104587",
        "nombreProducto": "Armario INVAL",
        "numDocumento": "1113987400",
        "direccion": "CR 72B 45 12 APT 301"
    }
    ```

    **Nota**: Si el servicio de Mocky no está funcionando, la respuesta podría ser un error 500 o un mensaje indicando que la URL externa no está accesible.

### Ejecución en Docker

Si prefieres ejecutar el proyecto en Docker, puedes hacerlo usando el siguiente comando:

1. **Construir la imagen Docker**:
    ```bash
    docker build -t acmepedidosapi:dev .
    ```

2. **Ejecutar el contenedor**:
    ```bash
    docker run -p 8080:8080 -p 8081:8081 acmepedidosapi:dev
    ```

3. **Probar la API**:
    La API estará disponible en `http://localhost:8080` y `https://localhost:8081`.

### Respuesta Esperada

Si el servicio SOAP externo de Mocky estuviera funcionando, recibirías una respuesta JSON similar a esta:

```json
{
  "codigoEnvio": "12345",
  "estado": "Enviado"
}
