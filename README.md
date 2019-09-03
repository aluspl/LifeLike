# LifeLike 

Portfolio CMS running on .Net Core 2.1   and Angular. 
- Working perfect with Docker.
- Working on SQLite, MS SQL and Azure CosmosDB
- Working with BlobStorage to keep photos 
- Admin Panel after login 
- Authorization is using SQLite or MS Sql (depends of DB value in configuration)

# Build
If you have more than 1 GB Memory you can use docker-compose build on production machine, but I suggest to use  my image from docker and use own config :) or build your image in cloud
https://hub.docker.com/r/aluspl/lifelike/ 

## Run

-   Net Core 2.2: dotnet run
-   Docker: docker build
-   Docker-Compose: docker-compose up (best option)

# Build Status

[![Build status](https://ci.appveyor.com/api/projects/status/sodo2b5y68naru2m/branch/master?svg=true)](https://ci.appveyor.com/project/aluspl/lifelike/branch/master)
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2Faluspl%2FLifeLike.svg?type=shield)](https://app.fossa.io/projects/git%2Bgithub.com%2Faluspl%2FLifeLike?ref=badge_shield)


## License
[![FOSSA Status](https://app.fossa.io/api/projects/git%2Bgithub.com%2Faluspl%2FLifeLike.svg?type=large)](https://app.fossa.io/projects/git%2Bgithub.com%2Faluspl%2FLifeLike?ref=badge_large)