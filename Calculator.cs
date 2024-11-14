using System;
namespace test
{
    public class Kalkulator
    {
        static void Main()
        {
            double wynik = 0;

            while (true)
            {

            
                //tu trycatch powinien być


                    Console.Write("Podaj pierwszą liczbę: ");

                    double a = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Podaj drugą liczbę: ");

                    double b = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Podaj operację (+, -, *, /): ");
                    string operacja = Console.ReadLine();
                

             

                switch (operacja)
                {
                    case "+":
                        wynik = a + b;
                        break;
                    case "-":
                        wynik = a - b;
                        break;
                    case "*":
                        wynik = a * b;
                        break;
                    case "/":
                        wynik = a / b;
                        break;
                    default:
                        Console.WriteLine("Nieznana operacja.");
                        break;
                }




                Console.WriteLine("Wynik: " + wynik);


                while (true)

                {
                    Console.Write("Kontynuuj operację (+, -, *, /) lub wpisz c, żeby zacząć od nowa: ");

                    operacja = Console.ReadLine();

                    if (operacja == "c") break;

                    Console.Write("Podaj liczbę: ");
                    b = Convert.ToDouble(Console.ReadLine());

                    switch (operacja)
                    {
                        case "+":
                            wynik += b;
                            break;
                        case "-":
                            wynik -= b;
                            break;
                        case "*":
                            wynik *= b;
                            break;
                        case "/":
                            wynik /= b;
                            break;
                        default: Console.WriteLine("Nieznana operacja.");

                            continue;
                    }


                    Console.WriteLine("Wynik: " + wynik);


                }
            }
        }
    }
}
