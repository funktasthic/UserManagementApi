FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER root
WORKDIR /app
EXPOSE 8080

RUN mkdir -p /app && chown -R 1000 /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["UserManagementApi/UserManagementApi.csproj", "UserManagementApi/"]
RUN dotnet restore "UserManagementApi/UserManagementApi.csproj"
COPY . .
WORKDIR "/src/UserManagementApi"
RUN dotnet build "UserManagementApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "UserManagementApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
RUN mkdir -p /app && chown -R 1000 /app
ENTRYPOINT ["dotnet", "UserManagementApi.dll"]