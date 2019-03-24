open System

open FluentMigrator.Runner

open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open System.Reflection


let connString = "User ID=postgres;Host=localhost;Port=32772;Database=Life.Dev;"

let configurationRunner (builder : IMigrationRunnerBuilder) =
    builder
        .AddPostgres()
        .WithGlobalConnectionString(connString)
        .ScanIn(Assembly.GetExecutingAssembly())
        .For.Migrations |> ignore

[<EntryPoint>]
let main argv =

    let serviceProvider =
        ServiceCollection()
            .AddLogging(fun lb -> lb.AddDebug().AddFluentMigratorConsole() |> ignore)
            .AddFluentMigratorCore()
            .ConfigureRunner(Action<IMigrationRunnerBuilder>(configurationRunner))
            .BuildServiceProvider()

    use scope = serviceProvider.CreateScope()
    let runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>()
    runner.MigrateUp()

    0 // return an integer exit code
