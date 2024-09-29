open Browser
open Fable.Core
open PhaserInterop
open Scene
open Fable.Core.JsInterop
open Config
open HandScene
open Cards

let gameSize = 800, 600
let center =
    let x,y = gameSize
    (x/2),(y/2)
let handCenter = 0

let emitter = new EventEmitter()

let addCards () =
    0

let prel (load : Loader) =
    printfn "Preloading!"
    //load.setBaseURL "https://labs.phaser.io"
    //load.image "sky" "assets/skies/space3.png"
    load.image "card" "./KINS/All.png"
    load.image "background" "./background.png"

let creat (adder : ObjFactory) =
    let centerX, centerY = center
    adder.image  centerX centerY "background"
    //adder.image 400 300 "card"
    ()

let updte () =
    //printfn "Updating!"
    ()

let m () = 0

let testCard = (KING,CLUBS, (Score 10))
let testCard2 = (TEN,HEARTS, (Score 5))
let testCard3 = (JACK,SPADES, (Score 10))
let testCard4 = (ACE,DIAMONDS, (Score 11))
let testCard5 = (TWO,CLUBS, (Score 2))

let testArr = [|testCard;testCard2;testCard3;testCard4;testCard5|]


let extScene =
    let c = {active=Some true;key=Some "SceneExtension"}
    new SceneExtension (c,creat,updte,prel)
let handScene =
    let c = {active=Some true;key=Some "HandScene"}
    new HandScene(c,testArr)

let g =
    let c = conf gameSize [|extScene;handScene|] physics
    new Game (c)
    

let div = document.createElement "div"
div.innerHTML <- "Hello world!"
document.body.appendChild div |> ignore