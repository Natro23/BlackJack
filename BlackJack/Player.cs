namespace BlackJack;

public class Player
{
    public string Name { get; }
    public Hand Hand { get; set; }
    public int Chips { get; set; }
    public int Bet { get; set; }

    public Player(string name, int chips)
    {
        Name = name;
        Hand = new Hand();
        Chips = chips;
        Bet = 0;
    }

    public void PlaceBet(int amount)
    {
        Bet = amount;
        Chips -= amount;
    }

    public void WinBet()
    {
        Chips += Bet * 2;
    }

    public void TieBet()
    {
        Chips += Bet;
    }

    public void BlackJackWin()
    {
        Chips += (int)(Bet * 2.5);
    }
}