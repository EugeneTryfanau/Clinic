FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Services.API.csproj", "Services.API/"]
COPY ["Services/Services.BLL.csproj", "Services.BLL/"]
COPY ["Services/Services.DAL.csproj", "Services.DAL/"]
COPY ["StandartCRUD/StandartCRUD.csproj", "./common/"]
RUN dotnet restore "./Services/./Services.API.csproj"
COPY . .
WORKDIR "/src/Services/Services.API"
RUN dotnet build "./Services.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Services.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Services.API.dll"]
