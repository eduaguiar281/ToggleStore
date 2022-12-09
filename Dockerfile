FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ToggleStore.Web/ToggleStore.Web.csproj", "ToggleStore.Web/"]
# Restore Application
RUN dotnet restore "ToggleStore.Web/ToggleStore.Web.csproj"
COPY . .
# Build Application
WORKDIR "/src/ToggleStore.Web"
RUN dotnet build "ToggleStore.Web.csproj" -c Release -o /app/build
#Publish Application
FROM build AS publish
RUN dotnet publish "ToggleStore.Web.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToggleStore.Web.dll"]