FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY . .
RUN dotnet restore LojaOnlineFLF.sln
RUN dotnet build --no-restore -c Release -o /app LojaOnlineFLF.sln

FROM build AS publish
RUN dotnet publish --no-restore -c Release -o /app LojaOnlineFLF.sln

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
# Padrão de container ASP.NET
#ENTRYPOINT ["dotnet", "LojaOnlineFLF.WebAPI.dll"]
# Opção utilizada pelo Heroku
CMD ASPNETCORE_URLS=http://*:$PORT dotnet LojaOnlineFLF.WebAPI.dll