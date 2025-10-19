FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Corrigido o nome do arquivo .sln
COPY backend.sln ./

RUN dotnet restore

COPY . .

WORKDIR /src
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out ./

EXPOSE 5000

ENTRYPOINT ["dotnet", "backend.dll"]
