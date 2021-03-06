#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

# For deploy, only this two lines. Must be in publish folder
#COPY . .
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet URLShortener.Api.dll

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["URLShortener.Api/URLShortener.Api.csproj", "URLShortener.Api/"]
RUN dotnet restore "URLShortener.Api/URLShortener.Api.csproj"
COPY . .
WORKDIR "/src/URLShortener.Api"
RUN dotnet build "URLShortener.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "URLShortener.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "URLShortener.Api.dll"]