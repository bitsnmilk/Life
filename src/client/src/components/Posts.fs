module Components.Posts

open Types
open Fable.Helpers.React
open Fable.Helpers.React.Props


let postView post =
    let humanDate = post.UpdatedAt.ToShortTimeString()
    let postLink = sprintf "#post/%d" post.Id

    li [ ItemScope true ; ItemType "http://schema.org/BlogPosting"]  [
        a [ Href postLink ; ItemProp "url" ] [
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

let view posts =
    ul [ ClassName "posts" ] [
        yield! posts |> List.map postView
    ]
