namespace BlackJack;

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(" ____  _            _      _            _    ");
        Console.WriteLine("|  _ \\| |          | |    (_)          | |   ");
        Console.WriteLine("| |_) | | __ _  ___| | __  _  __ _  ___| | __");
        Console.WriteLine("|  _ <| |/ _` |/ __| |/ / | |/ _` |/ __| |/ /");
        Console.WriteLine("| |_) | | (_| | (__|   <  | | (_| | (__|   < ");
        Console.WriteLine("|____/|_|\\__,_|\\___|_|\\_\\ | |\\__,_|\\___|_|\\_\\");
        Console.WriteLine("                             _/ |                ");
        Console.WriteLine("                             |__/                 ");
        Console.ResetColor();
        Console.WriteLine("");
        Console.Title = "BlackJack";
        
        Game game = new Game();
        game.Start();
        
    }
}