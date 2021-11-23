FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS sdk
WORKDIR /app

COPY ./UserApi.csproj ./
RUN dotnet restore -r alpine-x64 UserApi.csproj

COPY . ./
RUN dotnet publish ./UserApi.csproj -r alpine-x64 -c Release -o ./publish --no-restore 

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine 
WORKDIR /app
COPY --from=sdk /app/publish .
ENTRYPOINT ["dotnet", "./UserApi.dll"]
