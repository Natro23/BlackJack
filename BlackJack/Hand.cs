namespace BlackJack;

public class Hand
{
    private List<Card> cards = new List<Card>();

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public int GetTotal()
    {
        int total = 0;
        int aces = 0;

        foreach (Card card in cards)
        {
            total += card.Value;
            if (card.Rank == "Ace") aces++;
        }

        while (total > 21 && aces > 0)
        {
            total -= 10;
            aces--;
        }

        return total;
    }

    public bool IsBust()
    {
        return GetTotal() > 21;
    }

    public void DisplayHand(string ownerName)
    {
        Console.WriteLine($"{ownerName}'s hand:");
        foreach (Card card in cards)
        {
            Console.WriteLine($"  {card}");
        }
        Console.WriteLine($"  Total: {GetTotal()}");
    }
    
    public List<Card> GetCards()
    {
        return cards;
    }
}