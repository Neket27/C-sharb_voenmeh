FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["zd1/zd1.csproj", "zd1/"]
RUN dotnet restore "zd1/zd1.csproj"
COPY . .
WORKDIR "/src/zd1"
RUN dotnet build "zd1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "zd1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "zd1.dll"]
