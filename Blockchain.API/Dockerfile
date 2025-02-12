FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5006

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Blockchain.API/Blockchain.API.csproj", "Blockchain.API/"]
COPY ["BlockchainManager/BlockchainManager.csproj", "BlockchainManager/"]
RUN dotnet restore "Blockchain.API/Blockchain.API.csproj"
COPY . .
WORKDIR "/src/Blockchain.API"
RUN dotnet build "Blockchain.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Blockchain.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Blockchain.API.dll"]
