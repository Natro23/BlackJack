namespace BlackJack;

public class Deck
{
    private List<Card> cards = new List<Card>();
    
    private string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
    private string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

    public Deck()
    {
        foreach (string suit in suits)
        {
            foreach (string rank in ranks)
            {
                cards.Add(new Card(suit, rank));
            }
        }
    }

    public void Shuffle()
    {
        Random random = new Random();

        for (int i = cards.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            Card temp = cards[j];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }
    
    public Card Deal()
    {
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
    
}