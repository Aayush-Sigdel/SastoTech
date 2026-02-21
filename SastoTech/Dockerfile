FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# 1. We removed the "SastoTech/" prefix here since the file is in the same folder
COPY ["SastoTech.csproj", "./"]
RUN dotnet restore "SastoTech.csproj"

# 2. Copy the rest of the files
COPY . .

# 3. Build and Publish using the updated path
WORKDIR "/src"
RUN dotnet build "SastoTech.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SastoTech.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SastoTech.dll"]