module Components.Post

open Types
open Fable.Helpers.React
open Fable.Helpers.React.Props

let view post =
    article [ ClassName "single-content" ; ItemScope true ; ItemType "http://schema.org/BlogPosting" ] [
        div [ ClassName "feat" ] [
            h5 [ ClassName "page-date" ] [
                time [ Props.DateTime(post.CreatedAt.ToShortDateString()) ; ItemProp "datePublished" ] [ str <| post.CreatedAt.ToShortDateString() ]
            ]
        ]
        h1 [ ClassName "page-title" ; ItemProp "name headline" ] [ str <| post.Title ]
        div [ ItemProp "articleBody" ] [ str <| post.Body ]
        div [ ClassName "feat share" ] [
            a [ Href "http://twitter.com/share" ; ClassName "popup" ] [
                span [ ClassName "icon-twitter" ] []
            ]
        ]
        a [ Rel "prev" ; Href "/" ; Id "prev" ] [
            str "&larr;"
            span [ ClassName "nav-title nav-title-prev" ] [ str "older" ]
        ]
    ]
