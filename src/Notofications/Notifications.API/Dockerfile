FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 90
EXPOSE 91

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["common/StandartCRUD/StandartCRUD.csproj", "common/StandartCRUD/"]
COPY ["src/Notofications/Notifications.BLL/Notifications.BLL.csproj", "src/Notofications/Notifications.BLL/"]
COPY ["src/Notofications/Notifications.API/Notifications.API.csproj", "src/Notofications/Notifications.API/"]
RUN dotnet restore "./src/Notofications/Notifications.API/Notifications.API.csproj"
COPY . .
WORKDIR "/src/src/Notofications/Notifications.API"
RUN dotnet build "./Notifications.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Notifications.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY src/Notofications/Notifications.API/secrets.json /app/secrets.json
RUN mkdir -p /root/.aspnet/https
RUN apt-get update && apt-get install -y netcat-openbsd
COPY wait-for-it.sh /app/wait-for-it.sh
RUN chmod +x /app/wait-for-it.sh
ENTRYPOINT ["/app/wait-for-it.sh", "rabbitmq", "5672", "dotnet", "Notifications.API.dll"]
