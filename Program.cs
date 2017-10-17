using System;
using System.Collections.Generic;

namespace cardDeck
{
    public class Card {
        public string stringVal;
        public string suit;
        public int val;

        private Dictionary<int, string> cardTranslate = new Dictionary<int, string>{
            {1, "1"},
            {2, "2"},
            {3, "3"},
            {4, "4"},
            {5, "5"},
            {6, "6"},
            {7, "7"},
            {8, "8"},
            {9, "9"},
            {10, "10"},
            {11, "Jack"},
            {12, "Queen"},
            {13, "King"},
        };
        public Card(int initVal, string initSuit){
            suit = initSuit;
            val = initVal;
            stringVal = cardTranslate[initVal];
        }
    }
    public class Deck {
        public List<Card> cards = new List<Card>();

        public Deck(){
            reset();
        }

        public Card Deal() {
            Card dealt = cards[0];
            cards.RemoveAt(0);
            return dealt;
        }
        public void reset(){
            string[] suits = {"Clubs", "Spades", "Hearts", "Diamonds"};
            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    cards.Add(new Card(i + 1, suits[j]));
                }
            }
            shuffle();
        }
        public void shuffle(){
            Random rand = new Random();
            int cardsLeft = cards.Count;
            while (cardsLeft > 1){
                cardsLeft --;
                int swapPoint = rand.Next(cardsLeft+1);
                Card swapValue = cards[swapPoint];
                cards[swapPoint] = cards[cardsLeft];
                cards[cardsLeft] = swapValue;
            }
        }
    }
    public class Player
    {
        public string name;
        public List<Card> hand = new List<Card>();

        public Player(string initName){
            name = initName;

        }
        public void draw(Deck playingDeck){
            hand.Add(playingDeck.Deal());
        }
        public Card discard(int cardIndex){
            if (cardIndex < hand.Count)
            {
                Card temp = hand[cardIndex];
                hand.RemoveAt(cardIndex);
                return temp;
            }
            else
            {
                return null;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Deck deck = new Deck();
            Player player = new Player("John");
            player.draw(deck);
            System.Console.WriteLine(player.discard(0).val);
        }
    }
}
