module HandScene
open Bindings
open System
open Cards
open Path
open Transform

(*

Scene Functions:

 - Display Cards with slight curve
 - Drag Cards
 - Reorder Cards
 - Reposition Cards based on Selection
 - Reposition Cards based on Events (Play,Discard)
    - Play Event should reposition selecteded cards to center
    - Discard Event should play animation and then remove sprites, but not data
    - Reorder Event should Reorder Cards in hand
 - Should receive event from other scenes (play, discard, reorder) (implement later)
*)

let dragFn ptr (gob : GameObject) x y =
    gob.x <- x
    gob.y <- y
    ()

//System.Func delegate
//It's a problem with currying, normally not a problem in the F# world
let handleDragDelegate =
    Func<_,_,_,_,unit>( fun p g x y -> (dragFn p g x y) )

let loadCard (card : Card) (loader : Loader) =
    let ld (i,p) = loader.image i p
    match card |> createSceneCard with
    | _, Name i, Path p -> (i,p) |> ld

let loadCards cards loader  =
    let rec cardLoader c =
        match c with
        | card::rem ->
            loadCard card loader
            cardLoader rem
        | [] -> ()
    //there's no need to load identical cards
    //adding cards in create is a different story
    cards |> List.distinct |> cardLoader

let dragCardsToHand (cards : Sprite list) = ()

type HandScene (config,deck) =
    inherit Scene(config)
    let _deck = deck
    override this.preload () =
        loadCards _deck this.load
        ()
    override this.create () =       
        let s : Sprite = (this.add.sprite 10 10 "king_clubs").setInteractive()
        this.input.setDraggable [|s|] true
        this.input.on"drag" handleDragDelegate 
        () 
    override this.update () = ()

