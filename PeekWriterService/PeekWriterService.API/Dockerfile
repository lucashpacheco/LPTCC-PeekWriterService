#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR ./
COPY ["PeekWriterService.API/PeekWriterService.API.csproj", "PeekWriterService.API/"]
RUN dotnet restore "PeekWriterService.API/PeekWriterService.API.csproj"
COPY . .
WORKDIR "/src/PeekWriterService.API"
RUN dotnet build "PeekWriterService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PeekWriterService.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PeekWriterService.API.dll"]