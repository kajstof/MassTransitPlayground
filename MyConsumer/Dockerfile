FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyConsumer.csproj", "MyConsumer/"]
RUN dotnet restore "MyConsumer/MyConsumer.csproj"

COPY . MyConsumer/.
RUN dotnet publish -c Release -o /app MyConsumer/MyConsumer.csproj 

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS publish
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "MyConsumer.dll"]
