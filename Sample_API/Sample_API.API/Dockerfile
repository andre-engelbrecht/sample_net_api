# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
# Copy all files to /src directory
COPY ["Sample_API/", "Sample_API/"] 
# "Navigate" to main project directory
WORKDIR "/src/Sample_API/Sample_API.API"
# Define the build argument to receive the connection string
ARG _CONNECTION_STRING
RUN echo $_CONNECTION_STRING
ENV ConnectionStrings__DefaultConnection=$_CONNECTION_STRING
# Restore and build
RUN dotnet restore "Sample_API.API.csproj"
RUN dotnet build "Sample_API.API.csproj" -c Release -o /app/build

# Stage 2: Publish
FROM build AS publish
# Publish
RUN dotnet publish "Sample_API.API.csproj" -c Release -o /app/publish /p:UseAppHost=true
# Run DB migrations
RUN dotnet tool restore
RUN dotnet ef database update

# Stage 3: Final
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
# Set the environment variable to listen on the specified port
# Only used in load Docker test deployments - not used in Cloud Run
# ENV ASPNETCORE_URLS=http://*:$PORT  
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample_API.API.dll"]
