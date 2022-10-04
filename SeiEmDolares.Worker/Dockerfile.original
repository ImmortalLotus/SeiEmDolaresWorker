#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SeiEmDolares.Worker/SeiEmDolares.Worker.csproj", "SeiEmDolares.Worker/"]
RUN dotnet restore "SeiEmDolares.Worker/SeiEmDolares.Worker.csproj"
COPY . .
WORKDIR "/src/SeiEmDolares.Worker"
RUN dotnet build "SeiEmDolares.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SeiEmDolares.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SeiEmDolares.Worker.dll"]