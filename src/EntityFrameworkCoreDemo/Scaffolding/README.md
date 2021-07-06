```shell
# .NET CLI
dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Scaffold-Test" Microsoft.EntityFrameworkCore.SqlServer
```

```shell
# PowerShell
Scaffold-DbContext 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Scaffold-Test' Microsoft.EntityFrameworkCore.SqlServer
```