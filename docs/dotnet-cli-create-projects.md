# Create projects for Domain, Infrastructure and Application

Let's call the new application `MyApp` and that's the root of all namespaces and project names.

```shell
$ dotnet new classlib -o MyApp.Domain
```
```shell
$ dotnet new classlib -o MyApp.Application
```

```shell
$ dotnet new classlib -o MyApp.Infrastructure
```

Now add the nuget package references (version and source are required at this early stage since they're not available on nuget.org yet)

```shell
$ cd MyApp.Domain

$ dotnet add package DynamoCode.Domain --version 0.0.0-alpha.12 --source https://pkgs.dev.azure.com/dynamocode/DynamoCode/_packaging/dev-test/nuget/v3/index.json
```

```shell
$ cd MyApp.Infrastructure

$ dotnet add package DynamoCode.Infrastructure --version 0.0.0-alpha.12 --source https://pkgs.dev.azure.com/dynamocode/DynamoCode/_packaging/dev-test/nuget/v3/index.json

$ dotnet add package DynamoCode.Domain --version 0.0.0-alpha.12 --source https://pkgs.dev.azure.com/dynamocode/DynamoCode/_packaging/dev-test/nuget/v3/index.json
```

<!-- ```shell
$ cd MyApp.Application
$ dotnet add package DynamoCode.Application --version 0.0.0-alpha.12 --source https://pkgs.dev.azure.com/dynamocode/DynamoCode/_packaging/dev-test/nuget/v3/index.json
``` -->