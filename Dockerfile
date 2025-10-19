FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia todos os arquivos primeiro
COPY . .

# Restaura usando a solução
RUN dotnet restore backend.sln

# Publica o projeto
RUN dotnet publish backend.csproj -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out ./

EXPOSE 5000
ENTRYPOINT ["dotnet", "backend.dll"]
