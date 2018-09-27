#FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM microsoft/dotnet:2.1-sdk AS build
#WORKDIR /src
#COPY ["DockerWeb.csproj", "."]
#COPY ["DockerWeb/DockerWeb.csproj", "DockerWeb/"]
#RUN dotnet restore "DockerWeb.csproj"
#COPY . .
##WORKDIR "/src/DockeDockerWebrWeb"
#RUN dotnet build "DockerWeb.csproj" -c Release -o /app
#
#FROM build AS publish
#RUN dotnet publish "DockerWeb.csproj" -c Release -o /app
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "DockerWeb.dll"]

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["DockerWeb/DockerWeb.csproj", "DockerWeb/"]
RUN dotnet restore "DockerWeb/DockerWeb.csproj"
COPY . .
WORKDIR "/src/DockerWeb"
RUN dotnet build "DockerWeb.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DockerWeb.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DockerWeb.dll"]