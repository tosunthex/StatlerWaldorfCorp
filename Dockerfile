FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY src/StatlerWaldorfCorp.TeamService/*.csproj ./src/StatlerWaldorfCorp.TeamService/
COPY test/StatlerWaldorfCorp.TeamService.Tests/*.csproj ./test/StatlerWaldorfCorp.TeamService.Tests/
RUN dotnet restore

# copy everything else and build app
COPY . .
WORKDIR /app/src/StatlerWaldorfCorp.TeamService
RUN dotnet build

FROM build AS testrunner
WORKDIR /app/test/StatlerWaldorfCorp.TeamService.Test
ENTRYPOINT ["dotnet", "test", "--logger:trx"]

FROM build AS test
WORKDIR /app/test/StatlerWaldorfCorp.TeamService.Tests
RUN dotnet test

FROM build AS publish
WORKDIR /app/src/StatlerWaldorfCorp.TeamService
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=publish /app/src/StatlerWaldorfCorp.TeamService/out ./
ENTRYPOINT ["dotnet", "StatlerWaldorfCorp.TeamService.dll"]
