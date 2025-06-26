#!/bin/sh
set -e
echo "=== Running entrypoint.sh ==="
dotnet ef --version
# Применить миграции
dotnet ef database update --no-build --project DataAccess/DataAccess.csproj --startup-project WebApi/WebApi.csproj

# Запустить приложение
dotnet WebApi.dll