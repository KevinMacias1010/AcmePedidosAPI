
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080 8081


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AcmePedidosAPI/AcmePedidosAPI.csproj", "AcmePedidosAPI/"]
RUN dotnet restore "AcmePedidosAPI/AcmePedidosAPI.csproj"
COPY . . 
WORKDIR "/src/AcmePedidosAPI"
RUN dotnet build "AcmePedidosAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AcmePedidosAPI.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AcmePedidosAPI.dll"]
