FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 86
EXPOSE 87

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["common/StandartCRUD/StandartCRUD.csproj", "common/StandartCRUD/"]
COPY ["src/Profiles/Profiles.DAL/Profiles.DAL.csproj", "src/Profiles/Profiles.DAL/"]
COPY ["src/Profiles/Profiles.BLL/Profiles.BLL.csproj", "src/Profiles/Profiles.BLL/"]
COPY ["src/Profiles/Profiles.API/Profiles.API.csproj", "src/Profiles/Profiles.API/"]
RUN dotnet restore "./src/Profiles/Profiles.API/Profiles.API.csproj"
COPY . .
WORKDIR "/src/src/Profiles/Profiles.API"
RUN dotnet build "./Profiles.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Profiles.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Profiles.API.dll"]
