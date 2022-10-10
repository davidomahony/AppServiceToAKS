#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AirportFlightFinder.API/AirportFlightFinder.API.csproj", "AirportFlightFinder.API/"]
RUN dotnet restore "AirportFlightFinder.API/AirportFlightFinder.API.csproj"
COPY . .
WORKDIR "/src/AirportFlightFinder.API"
RUN dotnet build "AirportFlightFinder.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AirportFlightFinder.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AirportFlightFinder.API.dll"]