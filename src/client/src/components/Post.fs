module Components.Post

open Domain
open Fable.Helpers.React
open Fable.Helpers.React.Props

let view (model : Post) dispatch =
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
        a [ Rel "prev" ; Href "/" ; Id "prev" ] [
            str "&larr;"
            span [ ClassName "nav-title nav-title-prev" ] [ str "older" ]
        ]
    ]
