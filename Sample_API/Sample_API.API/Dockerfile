FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
# Copy all files to /src directory
COPY ["Sample_API/", "Sample_API/"] 
# "Navigate" to main project directory
WORKDIR "/src/Sample_API/Sample_API.API"
# Restore and build
RUN dotnet restore "Sample_API.API.csproj"
RUN dotnet build "Sample_API.API.csproj" -c Release -o /app/build

FROM build AS publish
# Publish
RUN dotnet publish "Sample_API.API.csproj" -c Release -o /app/publish /p:UseAppHost=true
# Run DB migrations
RUN echo "Just testing..."
RUN echo $ConnectionStrings__DefaultConnection
RUN dotnet tool restore
RUN dotnet ef database update

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
# Set the environment variable to listen on the specified port
# Only used in load Docker test deployments - not used in Cloud Run
# ENV ASPNETCORE_URLS=http://*:$PORT  
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample_API.API.dll"]
