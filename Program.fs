open Browser
open Fable.Core
open Scene

type Card =
    | JOKER
    | KING 
    | QUEEN
    | ACE
    | JACK



let myScene = new Scene()
let extScene = new SceneExtension()



let div = document.createElement "div"
div.innerHTML <- "Hello world!"
document.body.appendChild div |> ignore