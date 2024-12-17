// --- Przykładowe notatki z C# do kolokwium ---
using System;
using System.Collections.Generic;

// Klasa podstawowa (dziedziczenie)
class Osoba
{
    public string Imie;
    public int Wiek;

    // Konstruktor klasy Osoba
    public Osoba(string imie, int wiek)
    {
        Imie = imie;
        Wiek = wiek;
    }

    // Metoda klasy Osoba
    public void WyswietlInformacje()
    {
        Console.WriteLine($"Imię: {Imie}, Wiek: {Wiek}");
    }
}

// Klasa pochodna (dziedziczenie)
class Student : Osoba
{
    public string Kierunek;

    // Konstruktor klasy Student wywołujący konstruktor klasy bazowej
    public Student(string imie, int wiek, string kierunek) : base(imie, wiek)
    {
        Kierunek = kierunek;
    }

    // Przesłonięta metoda
    public void WyswietlInformacje()
    {
        Console.WriteLine($"Imię: {Imie}, Wiek: {Wiek}, Kierunek: {Kierunek}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // --- Przykład użycia if ---
        Console.WriteLine("Podaj liczbę:");
        int liczba = int.Parse(Console.ReadLine());

        if (liczba > 0)
        {
            Console.WriteLine("Liczba jest dodatnia.");
        }
        else if (liczba < 0)
        {
            Console.WriteLine("Liczba jest ujemna.");
        }
        else
        {
            Console.WriteLine("Liczba to zero.");
        }

        // --- Przykład użycia switch/case ---
        Console.WriteLine("Podaj dzień tygodnia (1-7):");
        int dzien = int.Parse(Console.ReadLine());

        switch (dzien)
        {
            case 1:
                Console.WriteLine("Poniedziałek");
                break;
            case 2:
                Console.WriteLine("Wtorek");
                break;
            case 3:
                Console.WriteLine("Środa");
                break;
            case 4:
                Console.WriteLine("Czwartek");
                break;
            case 5:
                Console.WriteLine("Piątek");
                break;
            case 6:
                Console.WriteLine("Sobota");
                break;
            case 7:
                Console.WriteLine("Niedziela");
                break;
            default:
                Console.WriteLine("Niepoprawny numer dnia.");
                break;
        }

        // --- Przykład foreach z listą ---
        List<string> listaImion = new List<string>() { "Anna", "Jan", "Krzysztof" };
        Console.WriteLine("Lista imion:");
        
        foreach (string imie in listaImion)
        {
            Console.WriteLine(imie);
        }

        // --- Tworzenie obiektów klas i dziedziczenie ---
        Osoba osoba = new Osoba("Kasia", 30);
        osoba.WyswietlInformacje();

        Student student = new Student("Marek", 22, "Informatyka");
        student.WyswietlInformacje();

        // --- Przykład prostej metody ---
        Console.WriteLine("Podaj dwie liczby do dodania:");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        int wynik = Dodaj(a, b);
        Console.WriteLine($"Wynik dodawania: {wynik}");
    }

    // Prosta metoda dodawania
    static int Dodaj(int x, int y)
    {
        return x + y;
    }
}
