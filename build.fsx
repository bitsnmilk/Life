#r "paket:
nuget Fake.Core.Target
nuget Fake.DotNet.Cli //"
#load "./.fake/build.fsx/intellisense.fsx"

open Fake.Core
open Fake.DotNet

// Default target
Target.create "Default" (fun _ ->
  Trace.trace "Hello World from FAKE")

Target.create "Migrate" (fun _ ->
  (DotNet.exec (DotNet.Options.withWorkingDirectory "./db") "run" "") |> ignore)

// start build
Target.runOrDefault "Default"