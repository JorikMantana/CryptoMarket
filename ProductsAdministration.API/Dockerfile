FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProductsAdministration.API/ProductsAdministration.API.csproj", "ProductsAdministration.API/"]
COPY ["JwtAuthenticationManager/JwtAuthenticationManager.csproj", "JwtAuthenticationManager/"]
COPY ["ProductsAdministration.BLL/ProductsAdministration.BLL.csproj", "ProductsAdministration.BLL/"]
COPY ["ProductsAdministration.DAL/ProductsAdministration.DAL.csproj", "ProductsAdministration.DAL/"]
RUN dotnet restore "ProductsAdministration.API/ProductsAdministration.API.csproj"
COPY . .
WORKDIR "/src/ProductsAdministration.API"
RUN dotnet build "ProductsAdministration.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ProductsAdministration.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductsAdministration.API.dll"]
