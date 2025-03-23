FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project file and restore dependencies
COPY ScaleAPI.csproj .
RUN dotnet restore "ScaleAPI.csproj"

# Copy the rest of the application files
COPY . .
RUN dotnet build "ScaleAPI.csproj" -c Debug -o /app/build

# Use the build output directly for development
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=build /app/build .

EXPOSE 8080
EXPOSE 8081

ENTRYPOINT ["dotnet", "ScaleAPI.dll"]