# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *kptApi.csproj ./
RUN dotnet restore 

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .

RUN useradd -m myappuser
USER myappuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet kptApi.dll

