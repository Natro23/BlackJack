namespace BlackJack;

public class Card
{
    public string Suit { get; }
    public string Rank { get; }
    public int Value { get; }

    public Card(string suit, string rank)
    {
        Suit = suit;
        Rank = rank;
        Value = GetValue(rank);
    }

    private int GetValue(string rank)
    {
        if (rank == "Ace") return 11;
        if (rank == "Jack" || rank == "Queen" || rank == "King") return 10;
        return int.Parse(rank);
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}