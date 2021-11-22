FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["users_app/users_app.csproj", "users_app/"]
RUN dotnet restore "users_app/users_app.csproj"
COPY . .
WORKDIR "/src/users_app"
RUN dotnet build "users_app.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "users_app.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "users_app.dll"]
