FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.4-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1.201-alpine AS build
WORKDIR /src
COPY ["src/IdentityServer4Demo/IdentityServer4Demo.csproj", "src/IdentityServer4Demo/"]
RUN dotnet restore "src/IdentityServer4Demo/IdentityServer4Demo.csproj"
COPY . .
WORKDIR "/src/src/IdentityServer4Demo"
RUN dotnet build "IdentityServer4Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IdentityServer4Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IdentityServer4Demo.dll"]