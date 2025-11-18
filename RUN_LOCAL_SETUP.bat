@echo off
REM ERP5 Local Setup - Windows Batch Script

echo ========================================
echo ERP5 Local Development Setup
echo ========================================
echo.

REM Check if .NET SDK is installed
dotnet --version >nul 2>&1
if errorlevel 1 (
    echo ERROR: .NET SDK not found. Please install .NET 8 SDK first.
    pause
    exit /b 1
)

echo [1/4] Navigating to project folder...
cd /d "%~dp0nhuy\ERP5"
if errorlevel 1 (
    echo ERROR: Could not navigate to project folder
    pause
    exit /b 1
)

echo [2/4] Cleaning previous builds...
dotnet clean >nul 2>&1

echo [3/4] Building project...
dotnet build
if errorlevel 1 (
    echo ERROR: Build failed
    pause
    exit /b 1
)

echo [4/4] Applying database migrations...
dotnet ef database update
if errorlevel 1 (
    echo ERROR: Migration failed. Check SQL Server connection string in appsettings.json
    pause
    exit /b 1
)

echo.
echo ========================================
echo Setup Complete!
echo ========================================
echo.
echo Starting application...
echo The app will open on https://localhost:5001
echo.
pause

dotnet run
