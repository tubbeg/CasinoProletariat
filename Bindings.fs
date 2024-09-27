module Bindings
open Fable.Core

[<Import("Events.EventEmitter","phaser")>]
type EventEmitter () =
    class
    end


[<Import("Sprite","phaser")>]
type Sprite () =
    class
        member this.setOrigin x y  = jsNative
    end

[<Import("GameObjectFactory","phaser")>]
type ObjFactory () =
    class
        member this.image x y id  : unit = jsNative
        member this.sprite x y id : Sprite = jsNative
    end

[<Import("AUTO","phaser")>]
let auto : int = jsNative


[<Import("LoaderPlugin","phaser")>]
type Loader () =
    class
        member this.setBaseURL url : unit = jsNative
        member this.image id url : unit = jsNative
    end

type SceneConfig = {key:string option;active:bool option;}

[<Import("Scene","phaser")>]
type Scene (config : SceneConfig) =
    class
        member this.add : ObjFactory = jsNative
        member this.load : Loader = jsNative
        abstract preload : unit -> unit 
        abstract create : unit -> unit 
        abstract update : unit -> unit 
        default this.preload () : unit = jsNative
        default this.create () : unit = jsNative
        default this.update () : unit = jsNative
    end



[<Import("Game","phaser")>]
type Game (conf) =
    class
    end