#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
# copy csproj and restore as distinct layers
COPY *.sln .
COPY LojaOnlineFLF.Utils/*.csproj LojaOnlineFLF.Utils/
COPY LojaOnlineFLF.DataModel/*.csproj LojaOnlineFLF.DataModel/
COPY *.csproj LojaOnlineFLF.WebAPI/
#
RUN dotnet restore
COPY . .
WORKDIR /src/LojaOnlineFLF.WebAPI
RUN dotnet build  -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LojaOnlineFLF.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LojaOnlineFLF.WebAPI.dll"]