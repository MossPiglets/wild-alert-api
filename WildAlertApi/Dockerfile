FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WildAlertApi/WildAlertApi.csproj", "WildAlertApi/"]
RUN dotnet restore "WildAlertApi/WildAlertApi.csproj"
COPY . .
WORKDIR "/src/WildAlertApi"
RUN dotnet build "WildAlertApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WildAlertApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WildAlertApi.dll"]
