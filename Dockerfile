# Stage 1: Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /source

# Копіюємо проект і відновлюємо залежності
COPY ["Droids/Droids.csproj", "Droids/"]
RUN dotnet restore "Droids/Droids.csproj"

# Копіюємо всі файли і будуємо додаток
COPY . .
WORKDIR /source/Droids
RUN dotnet publish -c Release -o /app

# Stage 2: Final image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0

WORKDIR /app

# Копіюємо додаток з етапу побудови
COPY --from=build /app .

# Запускаємо додаток
ENTRYPOINT ["dotnet", "Droids.dll"]
 
