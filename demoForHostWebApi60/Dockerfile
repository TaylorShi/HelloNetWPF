#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["demoForHostWebApi60/demoForHostWebApi60.csproj", "demoForHostWebApi60/"]
RUN dotnet restore "demoForHostWebApi60/demoForHostWebApi60.csproj"
COPY . .
WORKDIR "/src/demoForHostWebApi60"
RUN dotnet build "demoForHostWebApi60.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "demoForHostWebApi60.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "demoForHostWebApi60.dll"]