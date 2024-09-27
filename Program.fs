open Browser
open Fable.Core
open Bindings
open Scene
open Fable.Core.JsInterop
open Config
open HandScene
open Cards


let emitter = new EventEmitter()

let addCards () =
    0

let prel (load : Loader) =
    printfn "Preloading!"
    //load.setBaseURL "https://labs.phaser.io"
    //load.image "sky" "assets/skies/space3.png"
    load.image "card" "./KINS/All.png"

let creat (adder : ObjFactory) =
    //adder.image 400 300 "sky"
    adder.image 400 300 "card"
    ()

let updte () =
    //printfn "Updating!"
    ()

let m () = 0

let testCard = (KING,CLUBS, (Score 10))

let extScene =
    let c = {active=Some true;key=Some "SceneExtension"}
    new SceneExtension (c,creat,updte,prel)
let handScene =
    let c = {active=Some true;key=Some "HandScene"}
    new HandScene(c,[testCard])

let g =
    let c = conf [|handScene;extScene|] physics
    new Game (c)
    

let div = document.createElement "div"
div.innerHTML <- "Hello world!"
document.body.appendChild div |> ignore