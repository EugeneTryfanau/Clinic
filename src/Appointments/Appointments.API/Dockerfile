FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 92
EXPOSE 93

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Debug
WORKDIR /src
COPY ["common/StandartCRUD/StandartCRUD.csproj", "common/StandartCRUD/"]
COPY ["src/Appointments/Appointments.DAL/Appointments.DAL.csproj", "src/Appointments/Appointments.DAL/"]
COPY ["src/Appointments/Appointments.BLL/Clinic.BLL.csproj", "src/Appointments/Appointments.BLL/"]
COPY ["src/Appointments/Appointments.API/Clinic.API.csproj", "src/Appointments/Appointments.API/"]
RUN dotnet restore "./src/Appointments/Appointments.API/Appointments.API.csproj"
COPY . .
WORKDIR "/src/src/Appointments/Appointments.API"
RUN dotnet build "./Appointments.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Debug
RUN dotnet publish "./Appointments.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN apt-get update && apt-get install -y wget

COPY wait-for-it.sh /wait-for-it.sh
RUN chmod +x /wait-for-it.sh

ENTRYPOINT ["/wait-for-it.sh", "rabbitmq", "5672", "dotnet", "Notifications.API.dll"]
