module Cards

type Rank =
    | ACE
    | KING
    | QUEEN
    | JACK
    | TEN
    | NINE
    | EIGHT
    | SEVEN
    | SIX
    | FIVE
    | FOUR
    | THREE
    | TWO

type Points = Score of int
type Suit = CLUBS | SPADES | DIAMONDS | HEARTS
type Card = Rank * Suit * Points

type Id = Name of string
type Path = Path of string
type SceneCard =
    Card * Id * Path 
