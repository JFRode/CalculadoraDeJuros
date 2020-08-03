FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/CalculadoraDeJuros.API/CalculadoraDeJuros.API.csproj", "src/CalculadoraDeJuros.API/"]
COPY ["src/CalculadoraDeJuros.Application/CalculadoraDeJuros.Application.csproj", "src/CalculadoraDeJuros.Application/"]
COPY ["src/CalculadoraDeJuros.Domain/CalculadoraDeJuros.Domain.csproj", "src/CalculadoraDeJuros.Domain/"]
RUN dotnet restore "src/CalculadoraDeJuros.API/CalculadoraDeJuros.API.csproj"
COPY . .

WORKDIR "/src/src/CalculadoraDeJuros.API"
RUN dotnet build "CalculadoraDeJuros.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculadoraDeJuros.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculadoraDeJuros.API.dll"]