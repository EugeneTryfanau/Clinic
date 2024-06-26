FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 82
EXPOSE 83

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["common/StandartCRUD/StandartCRUD.csproj", "common/StandartCRUD/"]
COPY ["src/Clinic.DAL/Clinic.DAL.csproj", "src/Clinic.DAL/"]
COPY ["src/Clinic.BLL/Clinic.BLL.csproj", "src/Clinic.BLL/"]
COPY ["src/Clinic.API/Clinic.API.csproj", "src/Clinic.API/"]
RUN dotnet restore "./src/Clinic.API/Clinic.API.csproj"
COPY . .
WORKDIR "/src/src/Clinic.API"
RUN dotnet build "./Clinic.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Clinic.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clinic.API.dll"]
