FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

COPY . .

RUN dotnet restore "APIPortal/APIPortal.csproj"

RUN dotnet publish "APIPortal/APIPortal.csproj" \
-c Release \
-o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS final

WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet","APIPortal.dll"]