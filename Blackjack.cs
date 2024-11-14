using System;
using System.Collections.Generic;
class Program

{
    static void Main(string[] args)

    {

        //słownik przechowujący karty i ich wartości punktowe


        Dictionary<string, int> cardValues = new Dictionary<string, int>()

        {
            {"Walet", 2},
            {"Dama", 3},
            {"Król", 4},
            {"As", 11},
            {"2", 2}, {"3", 3}, {"4", 4}, {"5", 5},
            {"6", 6}, {"7", 7}, {"8", 8}, {"9", 9}, {"10", 10}
        };



        //lista zawierająca wszystkie możliwe karty do wylosowania

        List<string> allCards = new List<string>(cardValues.Keys);
        Random random = new Random();

        //główna pętla gry - działa dopóki gracz nie wybierze opcji wyjścia

        while (true)
        {
            Console.WriteLine("1. N E W   G A M E!");
            Console.WriteLine("2. E N D   I T   A L L!");
            Console.Write("Wybierz opcję: ");
            string choice = Console.ReadLine();

            if (choice == "2") //kończy grę
                break;

            if (choice == "1") //rozpoczyna nową grę
            {
                int playerScore = 0;
                int computerScore = 0;
                bool gameEnded = false;

                while (!gameEnded)
                {
                    Console.WriteLine($"Twój wynik: {playerScore}");
                    Console.WriteLine("1. Pociągnij kartę");
                    Console.WriteLine("2. Sprawdź wynik");
                    Console.Write("Wybierz opcję: ");
                    string gameChoice = Console.ReadLine();

                    if (gameChoice == "1") //ciągnięcie karty
                    {
                        //losowanie i dodawanie punktów dla gracza

                        string playerCard = allCards[random.Next(allCards.Count)];
                        int playerPoints = cardValues[playerCard];
                        playerScore += playerPoints;
                        Console.WriteLine($"Wylosowałeś: {playerCard} ({playerPoints} pkt)");

                        //losowanie i dodawanie punktów dla komputera (zawsze gdy gracz dobiera)

                        string computerCard = allCards[random.Next(allCards.Count)];
                        int computerPoints = cardValues[computerCard];
                        computerScore += computerPoints;

                        //sprawdzenie czy któryś z graczy przekroczył 21 punktów

                        if (playerScore > 21)
                        {
                            Console.WriteLine($"Przekroczyłeś 21 punktów! Przegrywasz!");
                            Console.WriteLine($"PC miał: {computerScore} punktów");
                            gameEnded = true;
                        }
                        else if (computerScore > 21)
                        {
                            Console.WriteLine($"PC przekroczył 21 punktów! Wygrywasz!");
                            Console.WriteLine($"PC miał: {computerScore} punktów");
                            gameEnded = true;
                        }
                    }


                    else if (gameChoice == "2") //sprawdzanie wyniku
                    {
                        //wyświetlenie końcowych wyników

                        Console.WriteLine($"Twój końcowy wynik: {playerScore}");
                        Console.WriteLine($"Wynik PC: {computerScore}");

                        //logika sprawdzania zwycięzcy

                        if (computerScore > 21)
                            Console.WriteLine("Wygrywasz! PC przekroczył 21 punktów!");
                        else if (playerScore > 21)
                            Console.WriteLine("Przegrywasz! Przekroczyłeś 21 punktów!");
                        else if (playerScore == computerScore)
                            Console.WriteLine("Remis!");
                        else if (playerScore < computerScore)
                            Console.WriteLine("Przegrywasz!");
                        else
                            Console.WriteLine("Wygrywasz!");

                        gameEnded = true;
                    }
                }
            }
        }
    }
}
