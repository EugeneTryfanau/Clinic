FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

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
RUN dotnet dev-certs https --trust
RUN dotnet publish "./Appointments.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Appointments.API.dll"]
