FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Fitness.API/Fitness.API.csproj", "Fitness.API/"]
COPY ["Fitness.Application/Fitness.Application.csproj", "Fitness.Application/"]
COPY ["Fitness.Core/Fitness.Core.csproj", "Fitness.Core/"]
COPY ["Fitness.DataAccess/Fitness.DataAccess.csproj", "Fitness.DataAccess/"]

RUN dotnet restore "Fitness.API/Fitness.API.csproj"

COPY . .

WORKDIR "/src/Fitness.API"
RUN dotnet build "Fitness.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fitness.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Fitness.API.dll"]