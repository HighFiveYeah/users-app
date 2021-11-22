FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS sdk
WORKDIR /app

COPY UserApi.csproj ./
RUN dotnet restore -r alpine-x64

RUN dotnet publish ./UserApi.csproj -r alpine-x64 -c Release -o ./publish --no-restore --self-contained true -p:PublishTrimmed=True -p:TrimMode=Link -p:PublishSingleFile=true

FROM mcr.microsoft.com/dotnet/runtime-deps:6.0-alpine AS runtime

WORKDIR /app
COPY --from=sdk /app/publish .
ENTRYPOINT ["./UserApi"]
