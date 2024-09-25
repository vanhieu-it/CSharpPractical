```
dotnet new webapi -n MyDockerApp
cd MyDockerApp
```
```
dotnet run
```
### Dockerfile 
```
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
```
```
docker build -t mydockerapp .
```
```
docker run -d -p 8080:80 --name myappcontainer mydockerapp
```

+ -d: Chạy container ở chế độ nền (detached mode).
+ -p 8080:80: Ánh xạ cổng 8080 trên host với cổng 80 của container.
+ --name: Đặt tên cho container là myappcontainer.

```
curl --location 'http://localhost:8080/WeatherForecast' \
--data ''
```
