FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["GraphQLDemo/GraphQLDemo.csproj", "GraphQLDemo/"]
RUN dotnet restore "GraphQLDemo/GraphQLDemo.csproj"
COPY . .
WORKDIR "/src/GraphQLDemo"
RUN dotnet build "GraphQLDemo.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GraphQLDemo.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GraphQLDemo.dll"]