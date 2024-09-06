@echo off

:START
echo.
echo 1. Add Migration
echo 2. Update Database
echo 3. Remove Migration
echo 4. Exit
echo.

set /p CHOICE="Enter your choice (1-4): "

if "%CHOICE%" NEQ "4" (
	set /p MIGRATION="Enter migration name: "
)

if "%CHOICE%" == "1" (
    dotnet ef migrations add %MIGRATION% --project ProjectHub.Infrastructure --startup-project ProjectHub.Api -o Data\Migrations
    pause
    goto START
)

if "%CHOICE%" == "2" (
    dotnet ef database update %MIGRATION% --project ProjectHub.Infrastructure --startup-project ProjectHub.Api
    pause
    goto START
)

if "%CHOICE%" == "3" (
    dotnet ef migrations remove --project ProjectHub.Infrastructure --startup-project ProjectHub.Api
    pause
    goto START
)

if "%CHOICE%" == "4" (
    exit /b
)

echo.
echo Invalid choice. Please enter a number from 1 to 4.
pause
goto START

