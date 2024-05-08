FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Profiles/Profiles.API.csproj", "Profiles.API/"]
COPY ["Profiles/Profiles.BLL.csproj", "Profiles.BLL/"]
COPY ["Profiles/Profiles.DAL.csproj", "Profiles.DAL/"]
COPY ["StandartCRUD/StandartCRUD.csproj", "./common/"]
RUN dotnet restore "./Profiles/./Profiles.API.csproj"
COPY . .
WORKDIR "/src/Profiles/Profiles.API"
RUN dotnet build "./Profiles.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Profiles.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Profiles.API.dll"]
