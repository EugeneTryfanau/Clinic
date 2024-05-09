FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["src/Gateway/Gateway.API/Gateway.API.csproj", "src/Gateway/Gateway.API/"]
RUN dotnet restore "./src/Gateway/Gateway.API/Gateway.API.csproj"
COPY . .
WORKDIR "/src/src/Gateway/Gateway.API"
RUN dotnet build "./Gateway.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet dev-certs https --trust
RUN dotnet publish "./Gateway.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gateway.API.dll"]