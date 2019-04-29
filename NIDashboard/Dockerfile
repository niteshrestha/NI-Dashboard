FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["NIDashboard/NIDashboard.csproj", "NIDashboard/"]
COPY ["NIDashboard.Data/NIDashboard.Data.csproj", "NIDashboard.Data/"]
COPY ["NIDashboard.Service/NIDashboard.Service.csproj", "NIDashboard.Service/"]
RUN dotnet restore "NIDashboard/NIDashboard.csproj"
COPY . .
WORKDIR "/src/NIDashboard"
RUN dotnet build "NIDashboard.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "NIDashboard.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "NIDashboard.dll"]