using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ScoundrelCards.Classes
{

    internal class Card
    {
        public static List<String> Suits = new List<String>(["Hearts", "Diamonds", "Clubs", "Spades"]);

        public int value
        { get; set; } // ace value is 14
        public String suit
        { get; set; }
        public int color 
        { get; set; } //black = 0, red = 1
        
        public Card(int value, String suit) 
        { 
            this.value = value;
            this.suit = suit;
            if (suit == "Hearts" || suit == "Diamonds")
            {
                color = 1;
            }
            else
            {
                color = 0;
            }
            
        }

        public string Display()
        {
            return value + suit;
        }
        public override string ToString()
        {
            return "Card: " + value + ", " + suit + ", " + color;
        }

    }
}
