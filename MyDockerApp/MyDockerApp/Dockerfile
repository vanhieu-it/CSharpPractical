# Sử dụng hình ảnh .NET SDK làm base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Sử dụng hình ảnh SDK để xây dựng ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "MyDockerApp.csproj"
RUN dotnet build "MyDockerApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyDockerApp.csproj" -c Release -o /app/publish

# Tạo image cuối cùng và chạy ứng dụng
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyDockerApp.dll"]
