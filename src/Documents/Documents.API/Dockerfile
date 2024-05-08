FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Documents/Documents.API.csproj", "Documents.API/"]
COPY ["Documents/Documents.BLL.csproj", "Documents.BLL/"]
COPY ["Documents/Documents.DAL.csproj", "Documents.DAL/"]
COPY ["StandartCRUD/StandartCRUD.csproj", "./common/"]
RUN dotnet restore "./Documents/./Documents.API.csproj"
COPY . .
WORKDIR "/src/Documents/Documents.API"
RUN dotnet build "./Documents.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Documents.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Documents.API.dll"]
