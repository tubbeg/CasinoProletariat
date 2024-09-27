module Transform
open Cards
open Path

let createSceneCard card : SceneCard =
    match card with
    | ACE, CLUBS,_  -> card, Name "ace_clubs", Path ace_clubs_path
    | KING,CLUBS,_ -> card,Name "king_clubs",Path king_clubs_path
    | QUEEN,CLUBS,_ -> card,Name "queen_clubs",Path queen_clubs_path
    | JACK, CLUBS,_ -> card,Name "jack_clubs",Path jack_clubs_path
    | TEN, CLUBS,_ -> card,Name "ten_clubs",Path ten_clubs_path
    | NINE, CLUBS,_ -> card,Name "nine_clubs",Path nine_clubs_path
    | EIGHT, CLUBS,_ -> card,Name "eight_clubs",Path eight_clubs_path
    | SEVEN, CLUBS,_ -> card,Name "seven_clubs",Path seven_clubs_path
    | SIX, CLUBS,_ -> card,Name "six_clubs",Path six_clubs_path
    | FIVE, CLUBS,_ -> card,Name "five_clubs",Path five_clubs_path
    | FOUR, CLUBS,_ -> card,Name "four_clubs",Path four_clubs_path
    | THREE, CLUBS,_ -> card,Name "three_clubs",Path three_clubs_path
    | TWO, CLUBS,_ -> card,Name "two_clubs",Path two_clubs_path
    //

    | ACE, HEARTS,_  -> card, Name "ace_hearts", Path ace_hearts_path
    | KING, HEARTS,_ -> card,Name "king_hearts",Path king_hearts_path
    | QUEEN, HEARTS,_ -> card,Name "queen_hearts",Path queen_hearts_path
    | JACK, HEARTS,_ -> card,Name "jack_hearts",Path jack_hearts_path
    | TEN, HEARTS,_ -> card,Name "ten_hearts",Path ten_hearts_path
    | NINE, HEARTS,_ -> card,Name "nine_hearts",Path nine_hearts_path
    | EIGHT, HEARTS,_ -> card,Name "eight_hearts",Path eight_hearts_path
    | SEVEN, HEARTS,_ -> card,Name "seven_hearts",Path seven_hearts_path
    | SIX, HEARTS,_ -> card,Name "six_hearts",Path six_hearts_path
    | FIVE, HEARTS,_ -> card,Name "five_hearts",Path five_hearts_path
    | FOUR, HEARTS,_ -> card,Name "four_hearts",Path four_hearts_path
    | THREE, HEARTS,_ -> card,Name "three_hearts",Path three_hearts_path
    | TWO, HEARTS,_ -> card,Name "two_hearts",Path two_hearts_path
    //

    | ACE, DIAMONDS,_  -> card, Name "ace_diamonds", Path ace_diamonds_path
    | KING, DIAMONDS,_ -> card,Name "king_diamonds",Path king_diamonds_path
    | QUEEN, DIAMONDS,_ -> card,Name "queen_diamonds",Path queen_diamonds_path
    | JACK, DIAMONDS,_ -> card,Name "jack_diamonds",Path jack_diamonds_path
    | TEN, DIAMONDS,_ -> card,Name "ten_diamonds",Path ten_diamonds_path
    | NINE, DIAMONDS,_ -> card,Name "nine_diamonds",Path nine_diamonds_path
    | EIGHT, DIAMONDS,_ -> card,Name "eight_diamonds",Path eight_diamonds_path
    | SEVEN, DIAMONDS,_ -> card,Name "seven_diamonds",Path seven_diamonds_path
    | SIX, DIAMONDS,_ -> card,Name "six_diamonds",Path six_diamonds_path
    | FIVE, DIAMONDS,_ -> card,Name "five_diamonds",Path five_diamonds_path
    | FOUR, DIAMONDS,_ -> card,Name "four_diamonds",Path four_diamonds_path
    | THREE, DIAMONDS,_ -> card,Name "three_diamonds",Path three_diamonds_path
    | TWO, DIAMONDS,_ -> card,Name "two_diamonds",Path two_diamonds_path
    //

    | ACE, SPADES,_  -> card, Name "ace_spades", Path ace_spades_path
    | KING, SPADES,_ -> card,Name "king_spades",Path king_spades_path
    | QUEEN, SPADES,_ -> card,Name "queen_spades",Path queen_spades_path
    | JACK, SPADES,_ -> card,Name "jack_spades",Path jack_spades_path
    | TEN, SPADES,_ -> card,Name "ten_spades",Path ten_spades_path
    | NINE, SPADES,_ -> card,Name "nine_spades",Path nine_spades_path
    | EIGHT, SPADES,_ -> card,Name "eight_spades",Path eight_spades_path
    | SEVEN, SPADES,_ -> card,Name "seven_spades",Path seven_spades_path
    | SIX, SPADES,_ -> card,Name "six_spades",Path six_spades_path
    | FIVE, SPADES,_ -> card,Name "five_spades",Path five_spades_path
    | FOUR, SPADES,_ -> card,Name "four_spades",Path four_spades_path
    | THREE, SPADES,_ -> card,Name "three_spades",Path three_spades_path
    | TWO, SPADES,_ -> card,Name "two_spades",Path two_spades_path

