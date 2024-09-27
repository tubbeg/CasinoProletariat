module Bindings
open Fable.Core
open System

[<Import("Events.EventEmitter","phaser")>]
type EventEmitter () =
    class
    end

[<Import("InputPlugin","phaser")>]
type Input () =
    class
        member this.setDraggable s b : unit = jsNative
        member this.on event (funct ) : unit = jsNative
    end


[<Import("GameObject","phaser")>]
type GameObject () =
    class
        member val x = 0 with get,set
        member val y = 0 with get,set
        member this.input : Input  = jsNative
    end

[<Import("Sprite","phaser")>]
type Sprite () =
    class
        inherit GameObject()
        member this.setOrigin x y  = jsNative
        member this.setInteractive ()  = jsNative
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
        member this.input : Input = jsNative
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