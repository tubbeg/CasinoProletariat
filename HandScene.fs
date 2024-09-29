module HandScene
open PhaserInterop
open System
open Cards
open Path
open Transform
open Utility
open Fable.Core

(*

Scene Functions:

 - Display Cards with slight curve
 - Drag Cards and drag back to origin
 - Reorder Cards
 - Reposition Cards based on Selection
 - Reposition Cards based on Events (Play,Discard)
    - Play Event should reposition selecteded cards to center
    - Discard Event should play animation and then remove sprites, but not data
    - Reorder Event should Reorder Cards in hand
 - Should receive event from other scenes (play, discard, reorder) (implement later)
*)

let configTweensEnd (s : Sprite) =
    {|
        targets=s
        x = s.originX
        y = s.originX
        displayWidth = s.width 
        displayHeight = s.height 
        duration = 150
    |}
(*
let addDragEndTweens =
     this.tweens.add({
                targets: gameObject,
                angle: gameObject.startPosition.angle,
                x: gameObject.startPosition.x,
                y: gameObject.startPosition.y,
                displayWidth: gameOptions.cardWidth / 2,
                displayHeight: gameOptions.cardHeight / 2,
                duration: 150
            });
*)
let updateSpritePosition (sprites : Sprite array) x y  (name : string option) =
    match getSprite name sprites with
    | Some s ->
        s.x <- x
        s.y <- y
        //this only works because sprites is mutable
        //not a functional solution
        (Some sprites)
    | _ ->
        None


let dragFn (o : IGameObject) (ptr : Pointer)  x y (sprites : Sprite array option) : (Sprite array) option =
    match sprites with
    | Some s ->
        tryGetSpriteName o |> updateSpritePosition s x y 
    | _ -> None

let loadCard (card : Card) (loader : Loader) =
    let ld (i,p) = loader.image i p
    match card |> createSceneCard with
    | _, Name i, Path p -> (i,p) |> ld

let loadCards (cards : Deck) loader  =
    let rec cardLoader (c) =
        match c with
        | card::rem ->
            loadCard card loader
            cardLoader rem
        | [] -> ()
    //there's no need to load identical cards
    //adding cards in create is a different story
    cards |> Array.distinct |> Array.toList |> cardLoader

let generateSprite card guid  x y (add : ObjFactory) : Sprite =
    let id =
        match card |> createSceneCard with
        | _, Name i, _ ->  i
    let s = add.sprite x y id
    (s :> IGameObject).setData "sprite-name" ("CardSprite" + guid) // this is not an ideal solution
    s.setInteractive()

let generateDraggableSprites (deck : Deck) (x,y) add (cm : CameraManager) (i : Input) =
    let rec generateSprtes i (s : Sprite list) l =
        match l with
        | el::rem ->
            let spr = generateSprite el (string i) x y add
            let updatedList = spr::s
            generateSprtes  (i + 1) updatedList rem
        | [] -> s
    //let sprites = deck |> Array.map (fun c -> generateSprite c x y add)
    let sprites = deck |> Array.toList |> generateSprtes 0 [] |> List.toArray
    i.setDraggable sprites true
    sprites
    

let setToContainerOrigo (sprites : Sprite array option) : Sprite array option =
    let centerSprite s = reCenterSprite s (0,0)
    match sprites with
    | Some s ->
        s |> Array.map(fun e -> (centerSprite e)) |> Some
    | _ -> None


type HandScene (config,deck) =
    inherit Scene(config)
    let mutable _deck = deck
    let mutable _center = 0,0
    let containerCenter (x,y) = (x + (x/4), y + (y/3)) 
    let mutable _container  = None
    let mutable _sprites = None
    override this.preload () =
        _center <- getCenter this.cameras
        loadCards _deck this.load
        ()
    override this.create () =       
        //let s : Sprite = (this.add.sprite 10 10 "king_clubs").setInteractive()
        //this.input.setDraggable [|s|] true
        let cX,cY = containerCenter _center
        let x,y = _center
        _sprites <-
            //make sure they are set to origo, it's relative to the container
            generateDraggableSprites _deck (0,0) this.add this.cameras this.input |> Some
        _container <- this.add.container cX cY _sprites |> Some
        //_container <- addSpritesToContainer _sprites _container
        this.input.on "drag" this.handleDragDelegate
        this.input.on "dragend" this.handleDragEndDelegate
        //this.input.on "pointerup" (handlePointerUpDelegate _center)
        () 
    override this.update () = ()
    member this.handleDrag p o x y =
        _sprites <- (_sprites |> dragFn o p x y)
    member this.handleDragEnd o =  
        match gameObjectToSpriteOption o _sprites with
        | Some s ->
            this.tweens.add (configTweensEnd s)
        | _ -> ()
        ()
    //System.Func is a delegate.
    //It's a problem with currying, normally not a problem in the F# world
    //This method is just a wrapper for the actual function
    member this. handleDragDelegate  =
        Func<_,_,_,_,unit>( fun pointer o dragX dragY  -> 
            (this.handleDrag pointer o dragX dragY))
    member this. handleDragEndDelegate  =
        Func<_,_,_,_,unit>( fun pointer o dragX dragY  -> 
            (this.handleDragEnd o))


