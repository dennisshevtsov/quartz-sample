# Copyright (c) Dennis Shevtsov. All rights reserved.
# Licensed under the MIT License.
# See LICENSE in the project root for license information.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["QuartzSample.Web/QuartzSample.Web.csproj", "QuartzSample.Web/"]
RUN dotnet restore "./QuartzSample.Web/./QuartzSample.Web.csproj"
COPY . .
WORKDIR "/src/QuartzSample.Web"
RUN dotnet build "./QuartzSample.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./QuartzSample.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuartzSample.Web.dll"]
