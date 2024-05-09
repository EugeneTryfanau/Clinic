FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["common/StandartCRUD/StandartCRUD.csproj", "common/StandartCRUD/"]
COPY ["src/Documents/Documents.DAL/Documents.DAL.csproj", "src/Documents/Documents.DAL/"]
COPY ["src/Documents/Documents.BLL/Documents.BLL.csproj", "src/Documents/Documents.BLL/"]
COPY ["src/Documents/Documents.API/Documents.API.csproj", "src/Documents/Documents.API/"]
RUN dotnet restore "./src/Documents/Documents.API/Documents.API.csproj"
COPY . .
WORKDIR "/src/src/Documents/Documents.API"
RUN dotnet build "./Documents.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet dev-certs https --trust
RUN dotnet publish "./Documents.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Documents.API.dll"]
