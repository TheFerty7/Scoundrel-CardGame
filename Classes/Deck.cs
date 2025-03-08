using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoundrelCards.Classes
{
    internal class Deck
    {
        public List<Card> cards;
        public Deck() 
        {
            cards = new List<Card>();
            GenerateCards();
            Shuffle();
        }

        private void GenerateCards()
        {
            //aces are 14 so our lowest card is 2 
            for(int i = 2; i <= 14; i++)
            {
                foreach(String s in Card.Suits)
                {
                    Card c = new Card(i, s);
                    if (i >= 11 && c.color == 1)
                    {
                        continue; //dont add red aces and face cards
                    }
                    cards.Add(c);
                }
            }
        }
        public void Shuffle()
        {
            Random r = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                Card value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }
        }
    }
}
