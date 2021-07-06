```shell
# Add Migration
dotnet ef migrations add initial --context DemoDbContext --project EntityFrameworkCoreDemo.csproj -o Migrations
```

```shell
# Remove Migration 
dotnet ef migrations remove --context DemoDbContext --project EntityFrameworkCoreDemo.csproj
```

[命令行工具参考](https://docs.microsoft.com/zh-cn/ef/core/cli/dotnet#common-options)