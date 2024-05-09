FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["common/StandartCRUD/StandartCRUD.csproj", "common/StandartCRUD/"]
COPY ["src/Services/Services.DAL/Services.DAL.csproj", "src/Services/Services.DAL/"]
COPY ["src/Services/Services.BLL/Services.BLL.csproj", "src/Services/Services.BLL/"]
COPY ["src/Services/Services.API/Services.API.csproj", "src/Services/Services.API/"]
RUN dotnet restore "./src/Services/Services.API/Services.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Services.API"
RUN dotnet build "./Services.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet dev-certs https --trust
RUN dotnet publish "./Services.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Services.API.dll"]
