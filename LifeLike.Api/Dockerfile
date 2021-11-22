FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS cache

WORKDIR /src
COPY "NuGet.config" "NuGet.config"
COPY *.ruleset ./DockerRestoreProjectFiles.tar ./
RUN tar -xvf DockerRestoreProjectFiles.tar > /dev/null
RUN dotnet restore "Api/Api.csproj"

FROM cache as build
WORKDIR /src
ENV SolutionDir "/src"

COPY ./Api ./Api
COPY ./Commons ./Commons
COPY ./Database ./Database
COPY ./Services ./Services

RUN dotnet build "Api/Api.csproj" --no-restore -c Release

FROM build AS publish
WORKDIR /src
RUN dotnet publish "Api/Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Api.dll"]
