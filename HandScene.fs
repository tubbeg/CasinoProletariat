module HandScene
open Bindings
open System



let dragFn ptr (gob : GameObject) x y =
    gob.x <- x
    gob.y <- y
    ()

//System.Func delegate
//It's a problem with currying, normally not a problem in the F# world
let handleDragDelegate =
    Func<_,_,_,_,unit>( fun p g x y -> (dragFn p g x y) )

type HandScene (config) =
    inherit Scene(config)
    override this.preload () =
        this.load.image "card2" "./KINS/Clubs_Q.png"
        ()
    override this.create () =       
        let s : Sprite = (this.add.sprite 10 10 "card2").setInteractive()
        this.input.setDraggable [|s|] true
        this.input.on"drag" handleDragDelegate 
        () 
    override this.update () = ()

