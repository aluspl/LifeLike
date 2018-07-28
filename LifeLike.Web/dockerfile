FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY LifeLike.Web/*.csproj ./Web/
COPY LifeLike.Data/*.csproj ./Web/
COPY LifeLike.Repositories/*.csproj ./Web/
COPY LifeLike.Data/*.csproj ./Web/

RUN dotnet restore

# copy everything else and build app
COPY LifeLike.Web/. ./Web/
WORKDIR /app/Web
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/aspnetapp/out ./
ENTRYPOINT ["dotnet", "LifeLike.Web.dll"]