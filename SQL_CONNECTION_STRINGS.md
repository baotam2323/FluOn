# SQL Server Connection String Reference

## For Your Local Setup - Choose ONE

### Option 1: SQL Server Express (Default - Most Common)
```
Server=.\SQLEXPRESS;Database=ERP6;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;MultipleActiveResultSets=true
```

### Option 2: SQL Server LocalDB (Windows only)
```
Server=(localdb)\mssqllocaldb;Database=ERP6;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;MultipleActiveResultSets=true
```

### Option 3: Local SQL Server (Default Instance)
```
Server=.;Database=ERP6;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;MultipleActiveResultSets=true
```

### Option 4: Named Instance (if you have custom name)
```
Server=.\YourInstanceName;Database=ERP6;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;MultipleActiveResultSets=true
```

### Option 5: With Username/Password
```
Server=.\SQLEXPRESS;Database=ERP6;User Id=sa;Password=YourPassword;Encrypt=False;TrustServerCertificate=True;MultipleActiveResultSets=true
```

## How to Update appsettings.json

1. Open `ERP5\appsettings.json`
2. Find the section:
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=LAPTOP-HCE61UTB\\SQLEXPRESS;Database=ERP6;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;MultipleActiveResultSets=true"
}
```

3. Replace the connection string with one from above
4. Save the file

## How to Find Your SQL Server Instance Name

Run this in Command Prompt:
```cmd
sqlcmd -L
```

This will list all SQL Server instances on your computer.

## Verify Connection

Run this to test the connection (replace with your connection string):
```cmd
sqlcmd -S .\SQLEXPRESS -d ERP6 -E -Q "SELECT @@VERSION"
```

If it works, you'll see the SQL Server version. If it fails, update your connection string.
