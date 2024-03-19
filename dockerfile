FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /WEB.API
COPY ["C:/Users/elian/ProveedoresAPI/ProveedoresAPI.sln", "."]
RUN dotnet restore "ProveedoresAPI.csproj"
COPY . .
WORKDIR "/WEB.API"
RUN dotnet build "ProveedoresAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProveedoresAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProveedoresAPI.dll"]