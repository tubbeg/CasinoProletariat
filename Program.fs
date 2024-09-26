open Browser
open Fable.Core
open Scene
open Fable.Core.JsInterop

type Card =
    | JOKER
    | KING 
    | QUEEN
    | ACE
    | JACK

[<Import("AUTO","phaser")>]
let auto : int = jsNative

let arcade = {|gravity={|y=200|}|}

let physics =
    createObj [
        "default","arcade";
        "arcade", arcade
    ]

let conf c p =
    createObj [
        "type", auto
        "width", 800
        "height", 600
        "scene", c
        "physics",p
    ]


let myScene = new Scene()
let extScene = new SceneExtension()

[<Import("Game","phaser")>]
type Game (conf) =
    class
    end

let g =
    let c = conf extScene physics
    new Game (c)
    

let div = document.createElement "div"
div.innerHTML <- "Hello world!"
document.body.appendChild div |> ignore