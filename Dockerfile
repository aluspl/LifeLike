# FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
# WORKDIR /out
# EXPOSE 5000

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app
 # Install Node (used for server pre-rendering)
 RUN buildDeps='gnupg' \
     && set -x \
     && apt-get update && apt-get install -y $buildDeps --no-install-recommends \
     && rm -rf /var/lib/apt/lists/* \
     && curl -sL https://deb.nodesource.com/setup_10.x | bash - \
     && apt install nodejs \
     && rm -rf /usr/lib/systemd/* \
     && apt-get purge -y --auto-remove $buildDeps \
     && ln -s /usr/local/bin/node /usr/local/bin/nodejs \
     && node -v
# copy csproj and restore as distinct layers
COPY *.sln .

COPY LifeLike.Web/*.csproj ./LifeLike.Web/
COPY LifeLike.Test/*.csproj ./LifeLike.Test/
COPY LifeLike.Data/*.csproj ./LifeLike.Data/
COPY LifeLike.Repositories/*.csproj ./LifeLike.Repositories/

RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /app/LifeLike.Web
RUN dotnet publish -c Release -o /out


FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /out
COPY --from=build /out .
ENTRYPOINT ["dotnet", "LifeLike.Web.dll"]