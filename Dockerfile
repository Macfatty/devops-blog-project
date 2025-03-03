# Step 1: Build Stage - Use .NET SDK to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy project files & restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# Step 2: Runtime Stage - Use lightweight .NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy published files from the build stage
COPY --from=build /app/publish /app

# Set environment variables
ENV ASPNETCORE_URLS=http://+:5163

# Expose port 5163
EXPOSE 5163

# Start the application
ENTRYPOINT ["dotnet", "/app/DevOpsApp.dll"]
