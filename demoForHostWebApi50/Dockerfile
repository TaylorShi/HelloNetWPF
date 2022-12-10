#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["demoForHostWebApi50/demoForHostWebApi50.csproj", "demoForHostWebApi50/"]
RUN dotnet restore "demoForHostWebApi50/demoForHostWebApi50.csproj"
COPY . .
WORKDIR "/src/demoForHostWebApi50"
RUN dotnet build "demoForHostWebApi50.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "demoForHostWebApi50.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "demoForHostWebApi50.dll"]