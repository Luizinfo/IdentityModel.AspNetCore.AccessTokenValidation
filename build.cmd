@echo off
setlocal

if defined ACCESSTOKENVALIDATION_NUGET_CONFIG (
    dotnet restore build/build.csproj --configfile "%ACCESSTOKENVALIDATION_NUGET_CONFIG%"
) else (
    dotnet restore build/build.csproj
)

if errorlevel 1 exit /b %errorlevel%

dotnet run --project build --no-restore -- %*
exit /b %errorlevel%
