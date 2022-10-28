FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 8084

ENV ASPNETCORE_URLS=http://+:8084

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["MsUsers/MsUsers.csproj", "MsUsers/"]
RUN dotnet restore "MsUsers/MsUsers.csproj"
COPY . .
WORKDIR "/src/MsUsers"
RUN dotnet build "MsUsers.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MsUsers.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MsUsers.dll"]


