module Components.Footer

open Fable.Helpers.React
open Fable.Helpers.React.Props

let view model dispatch =
    footer [] [
        small [] [
            str "Powered by Life"
            str "- Theme: "
            a [ Href "https://github.com/m3xm/hikari-for-Jekyll" ] [ str "hikari" ]
            str " - © Jeff Boek"
        ]
    ]