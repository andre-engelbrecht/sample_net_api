FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
#Copy all file to /src directory
#COPY ["Sample_API/Sample_API.API/Sample_API.API.csproj", "Sample_API.API/"]
#COPY ["Sample_API/Sample_API.API/", "Sample_API.API/"]
COPY ["Sample_API/", "Sample_API/"] 
RUN ls -a
RUN dotnet restore "Sample_API.API/Sample_API.API.csproj"
WORKDIR "/src/Sample_API.API"
RUN dotnet build "Sample_API.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sample_API.API.csproj" -c Release -o /app/publish /p:UseAppHost=true
#RUN ls -l /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
#Set the environment variable to listen on the specified port
#Only used in load Docker test deployments - not used in Cloud Run
#ENV ASPNETCORE_URLS=http://*:$PORT  
WORKDIR /app
COPY --from=publish /app/publish .
#RUN ls -l /app
ENTRYPOINT ["dotnet", "Sample_API.API.dll"]
