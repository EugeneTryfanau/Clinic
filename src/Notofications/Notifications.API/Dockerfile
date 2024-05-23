FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 90
EXPOSE 91

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["common/StandartCRUD/StandartCRUD.csproj", "common/StandartCRUD/"]
COPY ["src/Notofications/Notifications.BLL/Notifications.BLL.csproj", "src/Notofications/Notifications.BLL/"]
COPY ["src/Notofications/Notifications.API/Notifications.API.csproj", "src/Notofications/Notifications.API/"]
RUN dotnet restore "./src/Notofications/Notifications.API/Notifications.API.csproj"
COPY . .
WORKDIR "/src/src/Notofications/Notifications.API"
RUN dotnet build "./Notifications.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Notifications.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN apt-get update && apt-get install -y wget

COPY wait-for-it.sh /wait-for-it.sh
RUN chmod +x /wait-for-it.sh

ENTRYPOINT ["/wait-for-it.sh", "rabbitmq", "5672", "dotnet", "Notifications.API.dll"]
