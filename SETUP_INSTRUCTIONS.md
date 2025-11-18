# ERP5 Local Setup - Quick Start Guide

## Prerequisites
- SQL Server (Express or any version) installed and running
- .NET 8 SDK installed
- Visual Studio or VS Code with C# extension

## Step 1: Update Connection String
The project uses SQL Server Express. Update the connection string in `appsettings.json` if needed:

**Current connection string:**
```
Server=LAPTOP-HCE61UTB\SQLEXPRESS;Database=ERP6;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;MultipleActiveResultSets=true
```

**To use your local SQL Server:**
1. Open `ERP5/appsettings.json`
2. Replace `LAPTOP-HCE61UTB\SQLEXPRESS` with your SQL Server instance name
   - For local SQL Express: `.\SQLEXPRESS` or `(local)\SQLEXPRESS`
   - For local SQL Server: `.\` or `(local)`

## Step 2: Create Database and Apply Migrations

Open Command Prompt/PowerShell in the `ERP5` folder and run:

```bash
# Navigate to project folder
cd ERP5

# Build the project
dotnet build

# Apply migrations to create database
dotnet ef database update
```

This will:
- Create the `ERP6` database automatically
- Create all tables from the migrations
- Initialize the database schema

## Step 3: Run the Application

```bash
# Run the application
dotnet run
```

The app will start on `https://localhost:5001` or `http://localhost:5000`

## Step 4: Access the Application

1. Open browser: `https://localhost:5001`
2. Register a new account
3. Log in and start using the ERP system

## Troubleshooting

### Database Connection Error
- Check SQL Server is running: Open SQL Server Management Studio
- Verify connection string matches your SQL Server instance
- Check Windows Authentication is enabled for SQL Server

### Migration Error
- Ensure you're in the `ERP5` folder
- Check .NET 8 SDK is installed: `dotnet --version`
- Clear: `dotnet clean` then retry `dotnet ef database update`

### Port Already in Use
- Modify `Properties/launchSettings.json` to use different ports

## Email Configuration
The app uses Gmail SMTP. Current settings in `appsettings.json`:
- Update the email/password in appsettings.json if needed
- Or disable email features in code if not needed

---

That's it! No Docker, no complex setup - just SQL Server + .NET CLI.
