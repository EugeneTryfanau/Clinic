FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 84
EXPOSE 85

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
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
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Services.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Services.API.dll"]
