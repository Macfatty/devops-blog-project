#  Step 1: Use official .NET SDK to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy project files & restore dependencies
COPY . ./
RUN dotnet restore

#  Build and publish the app
RUN dotnet publish -c Release -o /publish

#  Step 2: Use lightweight .NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

#  Copy published files from the build stage
COPY --from=build /publish .

#  Set environment variables
ENV ASPNETCORE_URLS=http://+:5163

#  Expose port 5163 for the web app
EXPOSE 5163

#  Start the application
ENTRYPOINT ["dotnet", "DevOpsApp.dll"]
