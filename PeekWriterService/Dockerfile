
# BASE
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
ENV ASPNETCORE_URLS=http://+:15025
EXPOSE 25015
WORKDIR /app

# BUILD
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

USER root

COPY . ./src

RUN pwd		
RUN ls ./src


RUN dotnet restore ./src/PeekWriterService/PeekWriterService.sln
RUN dotnet build ./src/PeekWriterService/PeekWriterService.sln -c Release --no-restore
RUN dotnet pack ./src/PeekWriterService/PeekWriterService.sln -c Release --no-build --output /source/packages

# PUBLISH
RUN echo "Starting publish"
FROM build AS publish
RUN dotnet publish "./src/PeekWriterService/PeekWriterService.API/PeekWriterService.API.csproj" -c Release --no-build -o /publish
RUN echo "End publish"

# PACKAGES
FROM scratch AS packages
COPY --from=build /source/packages .
CMD [""]

# FINAL
FROM base AS final
COPY --chown=ffuser:ffuser --from=publish /publish .
ENTRYPOINT ["dotnet", "PeekWriterService.API.dll"]
