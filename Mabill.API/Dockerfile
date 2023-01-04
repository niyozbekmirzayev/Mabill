#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Mabill.API/Mabill.API.csproj", "Mabill.API/"]
COPY ["Mabill.Service/Mabill.Service.csproj", "Mabill.Service/"]
COPY ["Mabill.Data/Mabill.Data.csproj", "Mabill.Data/"]
COPY ["Mabill.Domain/Mabill.Domain.csproj", "Mabill.Domain/"]
RUN dotnet restore "Mabill.API/Mabill.API.csproj"
COPY . .
WORKDIR "/src/Mabill.API"
RUN dotnet build "Mabill.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mabill.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mabill.API.dll"]