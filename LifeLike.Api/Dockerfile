FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

COPY *.sln .

COPY LifeLike.Web/*.csproj ./LifeLike.Web/
COPY LifeLike.Test/*.csproj ./LifeLike.Test/
COPY LifeLike.Data/*.csproj ./LifeLike.Data/
COPY LifeLike.Services/*.csproj ./LifeLike.Services/

RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /app/LifeLike.Web
RUN dotnet publish -c Release -o /out


FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /out
COPY --from=build /out .

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "LifeLike.Web.dll"]