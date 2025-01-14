using AcmePedidosAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient<ISoapService, SoapService>();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

app.Run();
