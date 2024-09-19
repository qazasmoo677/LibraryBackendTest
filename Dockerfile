FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.sln .
COPY TestLibraryBackend/*.csproj ./TestLibraryBackend/
RUN dotnet restore

COPY TestLibraryBackend/. ./TestLibraryBackend/
WORKDIR /app/TestLibraryBackend
RUN dotnet publish -c release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/TestLibraryBackend/out .
ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE 80
CMD ["dotnet", "TestLibraryBackend.dll"]