module Utility
open PhaserInterop

let getCenter (cameras : CameraManager) =
    cameras.main.centerX,cameras.main.centerY

let reCenterSprite (s : Sprite) (x,y) : Sprite =
    s.x <- x
    s.y <- y
    s


let getContainerChildren (c : Container) : IGameObject array =
    c.list

let spriteArrayToInterface (a : Sprite array) =
    a |> Array.map (fun e -> e :> IGameObject)

let tryGetSpriteName (gobj : IGameObject) : string option =
    try gobj.getData "sprite-name" |> Some
    with | _ -> None

let spriteHasName sprite name =
    match (tryGetSpriteName sprite) with
    | Some n when (n = name) -> true
    | _ -> false

let getSprite (n : string option) (sprites : Sprite array) : Sprite option =
    match n with
    | Some name ->
        let f = sprites |> Array.filter (fun s -> spriteHasName s name)
        match (f |> Array.toList) with
        | first::_ -> Some first
        | [] -> None
    | _ -> None

let gameObjectToSpriteOption gobj sprites =
    match sprites with
    | Some s ->
         s |> getSprite (tryGetSpriteName gobj)
    | _ -> None
