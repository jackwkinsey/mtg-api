FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /api

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /api
COPY --from=build-env /api/out .
ENTRYPOINT ["dotnet", "mtg-api.dll"]