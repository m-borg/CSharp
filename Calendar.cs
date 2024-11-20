using System;
using System.Collections.Generic;

public class Calendar //klasa kalendarza
{
    //lista z rezerwacjami
    private List<(DateTime Start, DateTime End)> reservations;

    public Calendar() //konstruktor
    {

        //hardkodowane rezerwacje
        reservations = new List<(DateTime Start, DateTime End)>

        {
            (DateTime.Parse("2021-06-10"), DateTime.Parse("2021-06-12")),
            (DateTime.Parse("2021-02-10"), DateTime.Parse("2021-06-12"))
        };
    }




    public bool TryAddReservation(DateTime start, DateTime end)
    {
        if (start >= end) //czy daty się zgadzają (nie jest koniec przed początkiem)
        {
            return false;
        }


        foreach (var reservation in reservations)
        {
            //wszystkie możliwe scenariusze
            bool overlaps =
                //rezerwacja zaczyna się kiedy inna już tam jest
                (start >= reservation.Start && start < reservation.End) ||
                //rezerwacja kończy się kiedy inna już tam jest
                (end > reservation.Start && end <= reservation.End) ||
                //rezerwacja kompletnie zajmuje istniejącą rezerwację
                (start <= reservation.Start && end >= reservation.End) ||
                //rezerwacja jest kompletnie w istniejącej
                (start >= reservation.Start && end <= reservation.End) ||
            // start jest równy end istniejącej rezerwacji
            (start == reservation.End) ||
            // end jest równy start istniejącej rezerwacji
            (end == reservation.Start);

            if (overlaps)
            {
                return false;
            }
        }

        reservations.Add((start, end));
        return true;
    }

    public void ShowAllReservations()
    {
        Console.WriteLine("\nObecne rezerwacje:");
        foreach (var reservation in reservations)
        {
            Console.WriteLine($"Od: {reservation.Start:yyyy-MM-dd}, Do: {reservation.End:yyyy-MM-dd}");
        }
    }
}


//interfejs bo czemu nie
class Program
{
    static void Main(string[] args)
    {
        var calendar = new Calendar();
        bool running = true;

        //loop
        while (running)
        {
            Console.Clear();
            calendar.ShowAllReservations(); //rezerwacje u góry
            Console.WriteLine("\nsuper kalendarz");
            Console.WriteLine("1. DODAJ NOWĄ REZERWACJĘ");
            Console.WriteLine("2. ZAKOŃCZ");
            Console.Write("\nWybierz opcję (1-2): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TryMakeReservation(calendar);
                    break;
                case "2":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Naciśnij przycisk...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void TryMakeReservation(Calendar calendar) //dodawanie rezerwacji
    {
        DateTime startDate, endDate;

        while (true)
        {
            Console.Write("\nPodaj datę początkową (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine("Nieprawidłowy format daty.");
                continue;
            }

            Console.Write("Podaj datę końcową (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out endDate))
            {
                Console.WriteLine("Nieprawidłowy format daty.");
                continue;
            }

            break;
        }

        bool success = calendar.TryAddReservation(startDate, endDate);
        Console.WriteLine(success ?
            "\nREZERWACJA DODANA!" :
            "\nNIE MOŻNA DODAĆ, NAKŁADA SIĘ Z OBECNĄ REZERWACJĄ");
        Console.WriteLine("\nNaciśnij przycisk...");
        Console.ReadKey();

    }
}
