module Scene
open Fable.Core

[<Import("GameObjectFactory","phaser")>]
type ObjFactory () =
    class
        member this.image x y id  : unit = jsNative
    end

[<Import("LoaderPlugin","phaser")>]
type Loader () =
    class
        member this.setBaseURL url : unit = jsNative
        member this.image id url : unit = jsNative
    end

[<Import("Scene","phaser")>]
type Scene () =
    class
        member this.add : ObjFactory = jsNative
        member this.load : Loader = jsNative
    end

type SceneExtension () =
    inherit Scene()
    member this.preload () : unit =
        printfn "Preloading!"
        this.load.setBaseURL "https://labs.phaser.io"
        this.load.image "sky" "assets/skies/space3.png"
    member this.create a =
        this.add.image 400 300 "sky"
    member this.update a = ()
