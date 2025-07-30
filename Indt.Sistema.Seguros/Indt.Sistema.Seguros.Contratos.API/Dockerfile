#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Indt.Sistema.Seguros.Contratos.API/Indt.Sistema.Seguros.Contratos.API.csproj", "Indt.Sistema.Seguros.Contratos.API/"]
RUN dotnet restore "./Indt.Sistema.Seguros.Contratos.API/./Indt.Sistema.Seguros.Contratos.API.csproj"
COPY . .
WORKDIR "/src/Indt.Sistema.Seguros.Contratos.API"
RUN dotnet build "./Indt.Sistema.Seguros.Contratos.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Indt.Sistema.Seguros.Contratos.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Indt.Sistema.Seguros.Contratos.API.dll"]