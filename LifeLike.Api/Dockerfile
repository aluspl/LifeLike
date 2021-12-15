FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS cache

WORKDIR /src
COPY "NuGet.config" "NuGet.config"
RUN dotnet restore "LifeLike/LifeLike.csproj"

FROM cache as build
WORKDIR /src
ENV SolutionDir "/src"

COPY * *

RUN dotnet build "LifeLike/LifeLike.csproj" --no-restore -c Release

FROM build AS publish
WORKDIR /src
RUN dotnet publish "LifeLike/LifeLike.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LifeLike.dll"]
