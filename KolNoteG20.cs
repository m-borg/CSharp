using System;

public class NotatkiKolokwium
{
    public static void Main(string[] args)
    {
        // --------------------------------------------------------------------
        // Foreach
        // --------------------------------------------------------------------
        Console.WriteLine("--- Foreach ---");
        string[] owoce = { "jabłko", "banan", "gruszka", "śliwka" };

        // Iteracja po tablicy za pomocą foreach
        foreach (string owoc in owoce)
        {
            Console.WriteLine($"Owoc: {owoc}");
        }

        Console.WriteLine();

        // --------------------------------------------------------------------
        // Switch i case
        // --------------------------------------------------------------------
        Console.WriteLine("--- Switch i Case ---");
        int numerDnia = 3;
        string dzienTygodnia;

        switch (numerDnia)
        {
            case 1:
                dzienTygodnia = "Poniedziałek";
                break;
            case 2:
                dzienTygodnia = "Wtorek";
                break;
            case 3:
                dzienTygodnia = "Środa";
                break;
            case 4:
                dzienTygodnia = "Czwartek";
                break;
            case 5:
                dzienTygodnia = "Piątek";
                break;
            case 6:
            case 7:
                dzienTygodnia = "Weekend";
                break;
            default:
                dzienTygodnia = "Nieznany dzień";
                break;
        }
        Console.WriteLine($"Dzień tygodnia: {dzienTygodnia}");
        Console.WriteLine();

        // --------------------------------------------------------------------
        // If
        // --------------------------------------------------------------------
        Console.WriteLine("--- If ---");
        int wiek = 20;

        if (wiek >= 18)
        {
            Console.WriteLine("Jesteś pełnoletni.");
        }
        else
        {
            Console.WriteLine("Jesteś niepełnoletni.");
        }

        Console.WriteLine();

        // --------------------------------------------------------------------
        // Klasa i konstruktor
        // --------------------------------------------------------------------
        Console.WriteLine("--- Klasa i Konstruktor ---");
        // Tworzenie obiektu klasy Samochod
        Samochod mojSamochod = new Samochod("Toyota", "Corolla", 2020);
        mojSamochod.WyswietlInformacje();

        Console.WriteLine();

        // --------------------------------------------------------------------
        // Metoda
        // --------------------------------------------------------------------
        Console.WriteLine("--- Metoda ---");
        int a = 10;
        int b = 5;

        int suma = ObliczSume(a, b);
        Console.WriteLine($"Suma {a} i {b} wynosi: {suma}");
        Console.WriteLine();

        // --------------------------------------------------------------------
        // Dziedziczenie
        // --------------------------------------------------------------------
        Console.WriteLine("--- Dziedziczenie ---");
        // Tworzenie obiektów klas dziedziczących
        Pies mojPies = new Pies("Burek", "Owczarek");
        mojPies.DajGlos();
        mojPies.WyswietlInformacje();
        Console.WriteLine();
        Kot mojKot = new Kot("Mruczek", "Dachowiec");
        mojKot.DajGlos();
        mojKot.WyswietlInformacje();

    }
    
    // Prosta metoda dodająca dwie liczby
    static int ObliczSume(int x, int y)
    {
        return x + y;
    }

}
// --------------------------------------------------------------------
// Definicja klasy Samochod
// --------------------------------------------------------------------
public class Samochod
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public int RokProdukcji { get; set; }

    // Konstruktor klasy Samochod
    public Samochod(string marka, string model, int rokProdukcji)
    {
        Marka = marka;
        Model = model;
        RokProdukcji = rokProdukcji;
    }

    // Metoda wyświetlająca informacje o samochodzie
    public void WyswietlInformacje()
    {
        Console.WriteLine($"Samochód: {Marka} {Model}, rok produkcji: {RokProdukcji}");
    }
}
// --------------------------------------------------------------------
// Dziedziczenie - Klasa Bazowa
// --------------------------------------------------------------------
public class Zwierze
{
    public string Imie { get; set; }

    public Zwierze(string imie)
    {
        Imie = imie;
    }

    public virtual void DajGlos()
    {
        Console.WriteLine("Nieznany dźwięk zwierzęcia");
    }

    public virtual void WyswietlInformacje()
    {
        Console.WriteLine($"Zwierzę: {Imie}");
    }
}
// --------------------------------------------------------------------
// Dziedziczenie - Klasa Pochodna (Pies)
// --------------------------------------------------------------------
public class Pies : Zwierze
{
    public string Rasa { get; set; }

    public Pies(string imie, string rasa) : base(imie)
    {
        Rasa = rasa;
    }

    public override void DajGlos()
    {
        Console.WriteLine("Hau hau!");
    }
    public override void WyswietlInformacje()
    {
       Console.WriteLine($"Pies {Imie}, rasy {Rasa}");
    }

}
// --------------------------------------------------------------------
// Dziedziczenie - Klasa Pochodna (Kot)
// --------------------------------------------------------------------
public class Kot : Zwierze
{
    public string Rasa { get; set; }
    public Kot(string imie, string rasa) : base (imie)
    {
      Rasa = rasa;
    }
    public override void DajGlos()
    {
        Console.WriteLine("Miau!");
    }
    public override void WyswietlInformacje()
    {
       Console.WriteLine($"Kot {Imie}, rasy {Rasa}");
    }
}
