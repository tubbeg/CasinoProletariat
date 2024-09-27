module Config
open Fable.Core.JsInterop
open Bindings

let arcade = {|gravity={|y=200|}|}

let physics =
    createObj [
        "default","arcade";
        "arcade", arcade
    ]

let conf (c : array<Scene>) p =
    createObj [
        "type", auto
        "width", 800
        "height", 600
        "scene", c
        "physics",p
    ]
