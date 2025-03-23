FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ChordAPI.csproj .
RUN dotnet restore "ChordAPI.csproj"

# Copy the rest of the application files
COPY . .
RUN dotnet build "ChordAPI.csproj" -c Debug -o /app/build

FROM build AS publish
RUN dotnet publish "ChordAPI.csproj" -c Debug -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 8080
EXPOSE 8081

ENTRYPOINT ["dotnet", "ChordAPI.dll"]