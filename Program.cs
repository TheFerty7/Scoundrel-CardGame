using System;
using ScoundrelCards.Classes;

Deck d = new Deck();
Room r = new Room(d);
Player p = new Player();
Card lastCard = new Card(1, "Hearts");

while (r.cards.Count > 0)
{
    Console.WriteLine(r.DisplayRoom());
    Console.WriteLine(p.DisplayPlayer());
    var i = Console.ReadLine();
    Card choice;
    switch (i){
        case "end":
            return 0;

        case "take":
            Console.WriteLine("Which card?");
            var num = Int32.Parse(Console.ReadLine());
            choice = r.cards[num-1];
            lastCard = choice;
            r.cards.Remove(choice);
            if (ParseCard(choice))
            {
                return 0;
            }
            break;

        case "run":
            if (!r.run)
            {
                Console.WriteLine("Running");
                r.Run(d);
            }
            else
            {
                Console.WriteLine("Can't run");
            }
            break;

        default: 
            break;
    }
    if(r.cards.Count == 1)
    {
        Console.WriteLine("Reloading Room");
        r.LoadRoom();
    }
    Console.WriteLine();
}
CalculateScore(false);
return 0;

void CalculateScore(bool dead)
{
    int score = p.hp;
    if (dead)
    {
        foreach (Card c in d.cards)
        {
            if (c.suit == "Spades" || c.suit == "Clubs")
            {
                score -= c.value;
            }
        }
        Console.WriteLine("You lost. Final score:");
    }
    else
    {
        if (lastCard.suit == "Hearts")
        {
            score += lastCard.value;
        }
        Console.WriteLine("You win! Final score: ");
    }
    Console.WriteLine(score);
    Console.ReadLine();
}

bool ParseCard(Card c)
{
    switch (c.suit)
    {
        case "Spades": case "Clubs":
            //fight
            p.Fight(c);
            if (p.HpCheck())
            {
                Console.WriteLine("You're dead");
                CalculateScore(true);
                return true;
            }
            break;
        case "Hearts":
            //heal
            p.Heal(c.value);
            break;
        case "Diamonds":
            //weapon
            p.EquipWeapon(c);
            break;
    }
    return false;
}

