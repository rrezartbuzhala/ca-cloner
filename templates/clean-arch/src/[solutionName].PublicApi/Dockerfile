FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["[solutionName].PublicApi/[solutionName].PublicApi.csproj", "[solutionName].PublicApi/"]
RUN dotnet restore "[solutionName].PublicApi/[solutionName].PublicApi.csproj"
COPY . .
WORKDIR "/src/[solutionName].PublicApi"
RUN dotnet build "[solutionName].PublicApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "[solutionName].PublicApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "[solutionName].PublicApi.dll"]
