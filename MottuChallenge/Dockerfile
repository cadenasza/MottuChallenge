
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

COPY *.sln .
COPY MottuChallenge/*.csproj ./MottuChallenge/
RUN dotnet restore

COPY . .
WORKDIR /app/MottuChallenge
RUN dotnet publish -c Release -o out

# Imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/MottuChallenge/out ./
ENTRYPOINT ["dotnet", "MottuChallenge.dll"]
