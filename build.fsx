#r "paket:
nuget Fake.Core.Target
nuget Fake.DotNet.Cli //"
#load "./.fake/build.fsx/intellisense.fsx"


open Fake.Core
open Fake.IO
open Fake.DotNet

let serverPath = Path.getFullName "./src/server"
let clientPath = Path.getFullName "./src/client"

let run cmd args dir =
    Shell.Exec(cmd, args, dir) |> ignore

// Default target
Target.create "Default" (fun _ ->
  Trace.trace "Hello World from FAKE")

Target.create "Migrate" (fun _ ->
  (DotNet.exec (DotNet.Options.withWorkingDirectory "./db") "run" "") |> ignore)

Target.create "NPMInstall" (fun _ ->
  run "npm" "install" clientPath)

Target.create "RunClient" (fun _ ->
  run "npm" "start" clientPath)

// start build
Target.runOrDefault "Default"