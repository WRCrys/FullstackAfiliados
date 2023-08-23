FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/FullstackAfiliados.Api/FullstackAfiliados.Api.csproj", "src/FullstackAfiliados.Api/"]
RUN dotnet restore "src/FullstackAfiliados.Api/FullstackAfiliados.Api.csproj"
COPY . .
WORKDIR "/src/src/FullstackAfiliados.Api"
RUN dotnet build "FullstackAfiliados.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FullstackAfiliados.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FullstackAfiliados.Api.dll"]
