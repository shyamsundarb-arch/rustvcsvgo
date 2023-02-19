# Use the latest LTS version of the .NET Core SDK image
FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build

# Set the working directory to /src
WORKDIR /src

# Copy all the source code files to the image
COPY . .

# Build the API using the dotnet CLI
RUN dotnet build cs-app.csproj -c Release

# Publish the API using the dotnet CLI
RUN dotnet publish cs-app.csproj -c Release -o /app

# Use the latest LTS version of the .NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine

# Copy the published files of the API to the image
COPY --from=build /app/ /app

# Set the working directory to /app
WORKDIR /app

ENV ASPNETCORE_URLS="http://0.0.0.0:8002"
# Expose port 80 for incoming traffic to the API
EXPOSE 8002

# Set the startup command to run the API
CMD ["dotnet", "cs-app.dll"]


