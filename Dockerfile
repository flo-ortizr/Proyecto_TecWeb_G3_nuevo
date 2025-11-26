# Base image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy just the csproj first for better layer caching
COPY elearning2/*.csproj ./elearning2/
RUN dotnet restore "elearning2/elearning2.csproj"

# Copy everything else
COPY . .

# Build and publish
WORKDIR "/src/elearning2"
RUN dotnet publish "elearning2.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Run the DLL
ENTRYPOINT ["dotnet", "elearning2.dll"]