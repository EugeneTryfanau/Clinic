FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 92
EXPOSE 93

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["common/StandartCRUD/StandartCRUD.csproj", "common/StandartCRUD/"]
COPY ["src/Appointments/Appointments.DAL/Appointments.DAL.csproj", "src/Appointments/Appointments.DAL/"]
COPY ["src/Appointments/Appointments.BLL/Appointments.BLL.csproj", "src/Appointments/Appointments.BLL/"]
COPY ["src/Appointments/Appointments.API/Appointments.API.csproj", "src/Appointments/Appointments.API/"]
RUN dotnet restore "./src/Appointments/Appointments.API/Appointments.API.csproj"
COPY . .
WORKDIR "/src/src/Appointments/Appointments.API"
RUN dotnet build "./Appointments.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Appointments.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY src/Appointments/Appointments.API/secrets.json /app/secrets.json
RUN apt-get update && apt-get install -y netcat-openbsd
COPY wait-for-it.sh /app/wait-for-it.sh
RUN chmod +x /app/wait-for-it.sh
ENTRYPOINT ["/app/wait-for-it.sh", "rabbitmq", "5672", "dotnet", "Appointments.API.dll"]
