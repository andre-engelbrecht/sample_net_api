#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#
## Copy the project file and restore dependencies
#COPY ["Sample_API.API.csproj", "Sample_API.API/"]
#RUN dotnet restore "Sample_API.API/Sample_API.API.csproj"
#
## Copy the remaining source code and build the project
#COPY . .
#WORKDIR "/src/Sample_API.API"
#RUN dotnet build "Sample_API.API.csproj" -c Release -o /app/build
#
## Publish the application
#FROM build AS publish
#RUN dotnet publish "Sample_API.API.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
## Create the final runtime image
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Sample_API.API.dll"]
#






#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["Sample_API/Sample_API.API/Sample_API.API.csproj", "Sample_API.API/"]
#RUN dotnet restore "Sample_API.API/Sample_API.API.csproj"
#COPY . .
#WORKDIR "/src/Sample_API.API"
#RUN ls -a
#RUN dotnet build "Sample_API.API.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Sample_API.API.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Sample_API.API.dll"]




FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Sample_API/Sample_API.API/Sample_API.API.csproj", "Sample_API.API/"]
COPY ["Sample_API/Sample_API.API/", "Sample_API.API/"]
RUN dotnet restore "Sample_API.API/Sample_API.API.csproj"
WORKDIR "/src/Sample_API.API"
RUN ls -a
RUN dotnet build "Sample_API.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sample_API.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample_API.API.dll"]
