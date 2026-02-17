FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["SchoolManagerApp.csproj", "."]
RUN dotnet restore "SchoolManagerApp.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "SchoolManagerApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SchoolManagerApp.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "SchoolManagerApp.dll"]
EXPOSE 80


