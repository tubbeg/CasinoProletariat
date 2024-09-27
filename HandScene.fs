module HandScene
open Bindings



type HandScene (config) =
    inherit Scene(config)
    override this.preload () =
        this.load.image "card2" "./KINS/Clubs_Q.png"
        ()
    override this.create () =       
        let s = this.add.sprite 10 10 "card2" 
        () 
    override this.update () = ()

