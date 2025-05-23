# 🧙 Etapa base para ejecución
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS pokedex-base
WORKDIR /app
EXPOSE 8080

# 🔨 Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS pokedex-build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Pokedex-Api.csproj", "./"]
RUN dotnet restore "Pokedex-Api.csproj"
COPY . .
RUN dotnet build "Pokedex-Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# ⚔️ Etapa de publicación
FROM pokedex-build AS pokedex-publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Pokedex-Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# 🏁 Etapa final
FROM pokedex-base AS final
WORKDIR /app
COPY --from=pokedex-publish /app/publish .
ENTRYPOINT ["dotnet", "Pokedex-Api.dll"]
