#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Zencareservice.csproj", "."]
RUN dotnet restore "./Zencareservice.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Zencareservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Zencareservice.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Set environment variables
ENV ConnectionStrings__DefaultConnection="Server=GOPI\SQLEXPRESS;Database=zencareservice;User=sa;Password=Devops@22;"

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Zencareservice.dll"]