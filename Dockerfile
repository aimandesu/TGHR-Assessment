# Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy .csproj and restore first (for caching)
COPY tg.api/*.csproj tg.api/
COPY tg.application/*.csproj tg.application/
COPY tg.infrastructure/*.csproj tg.infrastructure/
COPY tg.domain/*.csproj tg.domain/
RUN dotnet restore tg.api/tg.api.csproj

# Copy the rest and build
COPY . .
WORKDIR /src/tg.api
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "tg.api.dll"]
