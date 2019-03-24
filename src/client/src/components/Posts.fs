module Components.Posts

open Domain
open Fable.Helpers.React
open Fable.Helpers.React.Props

type PostsModel = { Posts : Post list }
let initModel = { Posts = [] }

type PostAction =
| Refresh of Post list

let update model command =
    match command with
    | Refresh posts -> { model with Posts = posts }

let postView (post : Post) =
    let humanDate = post.UpdatedAt.ToShortTimeString()
    li [ ItemScope true ; ItemType "http://schema.org/BlogPosting"]  [
        a [ Href "/" ; ItemProp "url" ] [
            div [ ClassName "p-wrap" ] [
                article [ ClassName "inner" ] [
                    time [ Fable.Helpers.React.Props.DateTime humanDate ; ItemProp "datePublished" ] [
                        str humanDate
                    ]
                    p [ ItemProp "name headline" ] [ str post.Title ]
                ]
            ]
        ]
    ]

let view model dispatch =
    let posts posts =
        posts |> List.map postView

    ul [ ClassName "posts" ] [
        yield! posts model.Posts
    ]
