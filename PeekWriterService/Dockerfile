
# BASE
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
ENV ASPNETCORE_URLS=http://+:15025
EXPOSE 25015
WORKDIR /app

# BUILD
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

USER root
WORKDIR /source

COPY . ./

RUN dotnet restore ./PeekWriterService.sln
RUN dotnet build ./PeekWriterService.sln -c Release --no-restore
RUN dotnet pack ./PeekWriterService.sln -c Release --no-build --output /source/packages

# PUBLISH
RUN echo "Starting publish"
FROM build AS publish
RUN dotnet publish "./PeekWriterService.API/PeekWriterService.API.csproj" -c Release --no-build -o /publish
RUN echo "End publish"

# PACKAGES
FROM scratch AS packages
COPY --from=build /source/packages .
CMD [""]

# FINAL
FROM base AS final
COPY --chown=ffuser:ffuser --from=publish /publish .
ENTRYPOINT ["dotnet", "PeekWriterService.API.dll"]
