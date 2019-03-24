module Router

open Elmish.Browser.UrlParser

type Page =
| Home
| Post of int
| Login

let toHash page =
    match page with
    | Home -> "#home"
    | Post id -> sprintf "#post/%i" id
    | Login -> "#login"

let pageParser : Parser<Page -> Page, Page> =
    oneOf [ map Home (s "home")
            map Post (s "post" </> i32)
            map Login (s "login") ]
