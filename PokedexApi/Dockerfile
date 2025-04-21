# 🧙 Etapa base para ejecución
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS yugioh-base
USER $APP_UID
WORKDIR /duel
EXPOSE 8080

# 🔨 Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS yugioh-build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["YuGiOhApi.csproj", "./"]
RUN dotnet restore "YuGiOhApi.csproj"
COPY . .
RUN dotnet build "YuGiOhApi.csproj" -c $BUILD_CONFIGURATION -o /duel/build

# ⚔️ Etapa de publicación
FROM yugioh-build AS yugioh-publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "YuGiOhApi.csproj" -c $BUILD_CONFIGURATION -o /duel/publish

# 🏁 Etapa final
FROM yugioh-base AS final
WORKDIR /duel
COPY --from=yugioh-publish /duel/publish .
ENTRYPOINT ["dotnet", "YuGiOhApi.dll"]
