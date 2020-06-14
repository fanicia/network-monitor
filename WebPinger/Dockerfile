#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_ENVIRONMENT="Development"

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY "WebPinger/WebPinger.csproj" .
RUN dotnet restore "WebPinger.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "WebPinger.csproj" -c Release -o /app/build --no-restore

FROM build AS publish
RUN dotnet publish "WebPinger.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebPingerApp.dll"]