FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Appointments/Appointments.API.csproj", "Appointments.API/"]
COPY ["Appointments/Appointments.BLL.csproj", "Appointments.BLL/"]
COPY ["Appointments/Appointments.DAL.csproj", "Appointments.DAL/"]
COPY ["StandartCRUD/StandartCRUD.csproj", "././common/"]
RUN dotnet restore "./Appointments/./Appointments.API.csproj"
COPY . .
WORKDIR "/src/Appointments/Appointments.API"
RUN dotnet build "./Appointments.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Appointments.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Appointments.API.dll"]
