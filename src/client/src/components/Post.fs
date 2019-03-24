module Components.Post

open Types
open Fable.Helpers.React
open Fable.Helpers.React.Props

let private previousPostButton link =
    a [ Rel "prev" ; Href link ; Id "prev" ] [
        str "←"
        span [ ClassName "nav-title nav-title-prev" ] [ str "older" ]
    ]

let private nextPostButton link =
    a [ Rel "next" ; Href link ; Id "next" ] [
        str "→"
        span [ ClassName "nav-title nav-title-next" ] [ str "newer" ]
    ]

let view model =
    article [ ClassName "single-content" ; ItemScope true ; ItemType "http://schema.org/BlogPosting" ] [
        div [ ClassName "feat" ] [
            h5 [ ClassName "page-date" ] [
                time [ Props.DateTime(model.CreatedAt.ToShortDateString()) ; ItemProp "datePublished" ] [ str <| model.CreatedAt.ToShortDateString() ]
            ]
        ]
        h1 [ ClassName "page-title" ; ItemProp "name headline" ] [ str <| model.Title ]
        div [ ItemProp "articleBody" ] [ str <| model.Body ]
        div [ ClassName "feat share" ] [
            a [ Href "http://twitter.com/share" ; ClassName "popup" ] [
                span [ ClassName "icon-twitter" ] []
            ]
        ]
    ]
