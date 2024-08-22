FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV Configuration__OpenWeatherMapKey=YOUR_API_KEY

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Application/Application.csproj", "Weatherly/"]
COPY ["Config/Config.csproj", "Config/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Host/Host.csproj", "Host/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Presentation/Presentation.csproj", "Presentation/"]
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore Host/Host.csproj
COPY . .
RUN dotnet build -c $BUILD_CONFIGURATION -o Build

FROM build AS publish
ARG PUBLISH_CONFIGURATION=Release
RUN dotnet publish -c $PUBLISH_CONFIGURATION -o Publish

FROM base AS final
WORKDIR /app
COPY --from=publish src/Publish .
ENTRYPOINT ["dotnet", "Host.dll"]