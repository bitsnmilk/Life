module Components.Posts

open Domain
open Fable.Helpers.React

type PostsModel = { Posts : Post list }
let initModel = { Posts = [] }

type PostAction =
| Refresh of Post list

let update model command =
    match command with
    | Refresh posts -> { model with Posts = posts }

let view model dispatch =
    div [] [
        str "this is the posts view"
    ]
