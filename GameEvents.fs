module GameEvents

type Reorder =
    | SUIT
    | RANK

type CardEvent =
    | PLAY
    | DISCARD
    | REORDER of Reorder 