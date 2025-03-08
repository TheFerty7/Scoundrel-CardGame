using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScoundrelCards.Classes
{
    internal class Room
    {
        public List<Card> cards;
        public bool run;

        private Deck d;
        
        public Room(Deck d)
        {
            cards = new List<Card>();
            this.d = d;
            LoadRoom();
        }

        public void LoadRoom()
        {
            while (cards.Count < 4 && d.cards.Count > 0)
            {
                Card next = d.cards.First();
                d.cards.RemoveAt(0);
                this.cards.Add(next);
            }
            this.run = false;
        }

        public String DisplayRoom()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("| ");
            foreach (Card card in this.cards)
            {
                sb.Append(card.Display() + " | ");
            }
            return sb.ToString();
        }

        public void Run(Deck d)
        {
            foreach(Card card in this.cards)
            {
                d.cards.Add(card);
            }
            this.cards.RemoveAll(x => x != null);
            this.LoadRoom();
            this.run = true;

        }
    }
}
