# Common Issues & Quick Fixes

## Issue 1: "Cannot connect to SQL Server"

**Error:** `A network-related or instance-specific error occurred while establishing a connection to SQL Server`

**Fix:**
1. Open SQL Server Management Studio
2. Verify SQL Server is running (should see green arrow icon)
3. Check instance name: Connect to check the server name
4. Update connection string in `appsettings.json`
5. Run: `dotnet ef database update` again

---

## Issue 2: "Cannot find installed .NET 8"

**Error:** `Could not find a matching framework`

**Fix:**
```cmd
dotnet --version
```
If not 8.x.x, download from: https://dotnet.microsoft.com/download/dotnet/8.0

---

## Issue 3: "Entity Framework Core tools not found"

**Error:** `No Entity Framework Core command found`

**Fix:**
```cmd
dotnet tool install --global dotnet-ef
```

---

## Issue 4: "Migration failed"

**Error:** `The entity type 'IdentityUserLogin' cannot be added to the model`

**Fix:**
```cmd
# Clean everything
dotnet clean

# Restore packages
dotnet restore

# Try migration again
dotnet ef database update
```

---

## Issue 5: "Port 5001 already in use"

**Error:** `Address already in use`

**Fix:**
1. Find process using port:
```cmd
netstat -ano | findstr :5001
```

2. Either:
   - Kill the process: `taskkill /PID [PID] /F`
   - Or change port in `Properties\launchSettings.json`

---

## Issue 6: "SSL certificate error"

**Error:** `The SSL connection could not be established`

**Fix:**
In `appsettings.json`, ensure:
```json
"Encrypt": "False",
"TrustServerCertificate": "True"
```

---

## Quick Diagnostics

Run these commands to check everything:

```cmd
# Check .NET version
dotnet --version

# Check SQL Server connectivity (update with your connection string)
sqlcmd -S .\SQLEXPRESS -d ERP6 -E -Q "SELECT 1"

# Check project builds
dotnet build

# Check migrations exist
dotnet ef migrations list
```

---

## Still Having Issues?

1. Delete `bin` and `obj` folders
2. Run: `dotnet clean`
3. Run: `dotnet restore`
4. Run: `dotnet build`
5. Run: `dotnet ef database update`

If error persists, check:
- Is SQL Server running?
- Is connection string correct?
- Does database exist?
- Run in administrator mode?
