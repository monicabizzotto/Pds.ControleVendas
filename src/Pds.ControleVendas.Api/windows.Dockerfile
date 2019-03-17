FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Pds.ControleVendas.Api/Pds.ControleVendas.Api.csproj", "Pds.ControleVendas.Api/"]
COPY ["Pds.ControleVendas.Dominio/Pds.ControleVendas.Dominio.csproj", "Pds.ControleVendas.Dominio/"]
COPY ["Pds.ControleVendas.Dados/Pds.ControleVendas.Dados.csproj", "Pds.ControleVendas.Dados/"]
COPY ["Pds.ControleVendas.Negocio/Pds.ControleVendas.Negocio.csproj", "Pds.ControleVendas.Negocio/"]
RUN dotnet restore "Pds.ControleVendas.Api/Pds.ControleVendas.Api.csproj"
COPY . .
WORKDIR "/src/Pds.ControleVendas.Api"
RUN dotnet build "Pds.ControleVendas.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Pds.ControleVendas.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Pds.ControleVendas.Api.dll"]