FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["DockerWebAPI/DockerWebAPI.csproj", "DockerWebAPI/"]
RUN dotnet restore "DockerWebAPI/DockerWebAPI.csproj"
COPY . .
WORKDIR "/src/DockerWebAPI"
RUN dotnet build "DockerWebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DockerWebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DockerWebAPI.dll"]