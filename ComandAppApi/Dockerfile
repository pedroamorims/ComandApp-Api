#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ComandAppApi/ComandApp.Api.csproj", "ComandAppApi/"]
COPY ["ComandAppModels/ComandApp.Domain.csproj", "ComandAppModels/"]
COPY ["ComandApp.Infra/ComandApp.Infra.csproj", "ComandApp.Infra/"]
RUN dotnet restore "ComandAppApi/ComandApp.Api.csproj"
COPY . .
WORKDIR "/src/ComandAppApi"
RUN dotnet build "ComandApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ComandApp.Api.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ComandApp.Api.dll"]