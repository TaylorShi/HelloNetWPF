#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["demoForHostWebApi70/demoForHostWebApi70.csproj", "demoForHostWebApi70/"]
RUN dotnet restore "demoForHostWebApi70/demoForHostWebApi70.csproj"
COPY . .
WORKDIR "/src/demoForHostWebApi70"
RUN dotnet build "demoForHostWebApi70.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "demoForHostWebApi70.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "demoForHostWebApi70.dll"]