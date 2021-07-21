  
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY "dotnetGrafana.csproj" .
RUN dotnet restore "dotnetGrafana.csproj"
COPY . .
#RUN ls
#RUN dotnet build . -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "dotnetGrafana.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY myapp.log /app/logs
ENTRYPOINT ["dotnet", "dotnetGrafana.dll"]