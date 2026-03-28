namespace BlackJack;

public class Game
{
    private Deck deck;
    private Player player;
    private Player dealer;

    public Game()
    {
        deck = new Deck();
        deck.Shuffle();
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        player = new Player(name, 1000);
        dealer = new Player("Dealer", 0);
    }

    public void Start()
    {
        Console.WriteLine($"Welcome {player.Name}! You have {player.Chips} chips.");

        while (player.Chips > 0)
        {
            PlayRound();
            Console.WriteLine("Play again? (y/n)");
            string answer = Console.ReadLine();
            if (answer != "y") break;
        }

        Console.WriteLine("Thanks for playing!");
    }

    private void PlayRound()
    {
        player.Hand = new Hand();
        dealer.Hand = new Hand();

        // place bet
        Console.WriteLine($"You have {player.Chips} chips. Place your bet: ");
        int bet = int.Parse(Console.ReadLine());
        player.PlaceBet(bet);

        // deal starting cards
        player.Hand.AddCard(deck.Deal());
        dealer.Hand.AddCard(deck.Deal());
        player.Hand.AddCard(deck.Deal());
        dealer.Hand.AddCard(deck.Deal());

        // show hands
        player.Hand.DisplayHand(player.Name);
        Console.WriteLine($"Dealer shows: {dealer.Hand.GetCards()[0]}");

        // check for blackjack
        if (player.Hand.GetTotal() == 21)
        {
            Console.WriteLine("BLACKJACK! You win 1.5x your bet!");
            player.BlackJackWin();
            dealer.Hand.DisplayHand("Dealer");
            return;
        }


        
        // player turn
        while (true)
        {
            if (player.Hand.IsBust()) break;
            Console.WriteLine("Hit or Stand? (h/s): ");
            string action = Console.ReadLine();
            if (action == "h")
            {
                player.Hand.AddCard(deck.Deal());
                player.Hand.DisplayHand(player.Name);
            }
            else break;
        }

        // dealer turn
        while (dealer.Hand.GetTotal() < 17)
        {
            dealer.Hand.AddCard(deck.Deal());
        }

        // show final hands
        dealer.Hand.DisplayHand("Dealer");

        // determine winner
        DetermineWinner();
    }

    private void DetermineWinner()
    {
        int playerTotal = player.Hand.GetTotal();
        int dealerTotal = dealer.Hand.GetTotal();

        if (player.Hand.IsBust())
        {
            Console.WriteLine("You bust! Dealer wins!");
        }
        else if (dealer.Hand.IsBust())
        {
            Console.WriteLine("Dealer busts! You win!");
            player.WinBet();
        }
        else if (playerTotal > dealerTotal)
        {
            Console.WriteLine("You win!");
            player.WinBet();
        }
        else if (playerTotal < dealerTotal)
        {
            Console.WriteLine("Dealer wins!");
        }
        else
        {
            Console.WriteLine("Its a tie!");
            player.TieBet();
        }
    }
}