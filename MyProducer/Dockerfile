FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MyProducer.csproj", "MyProducer/"]
RUN dotnet restore "MyProducer/MyProducer.csproj"

COPY . MyProducer/.
RUN dotnet publish -c Release -o /app MyProducer/MyProducer.csproj 

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS publish
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "MyProducer.dll"]
