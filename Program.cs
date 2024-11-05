// Pola

// Deklaracja pól:
// Pola są zmiennymi, które przechowują dane wewnątrz klasy lub struktury.
// Możemy je zadeklarować na początku klasy, tak jak tutaj:

public class Osoba
{
    // To jest pole publiczne, dostępne z każdego miejsca w programie
    public string Imie;

    // To jest pole prywatne, dostępne tylko wewnątrz klasy Osoba
    private int Wiek;
}

// W tym przykładzie mamy dwa pola: Imie(publiczne) i Wiek(prywatne).
// Publiczne pola mogą być używane w całym programie,
// a prywatne pola są dostępne tylko wewnątrz klasy, w której zostały zdefiniowane.



// Modyfikatory dostępu:

// Modyfikatory dostępu określają, kto może odczytywać i modyfikować wartości pól.
// Najczęściej używane to:

// public - pole jest dostępne wszędzie
// private - pole jest dostępne tylko wewnątrz klasy
// protected - pole jest dostępne w klasie i jej podklasach

public class Pracownik
{
    public string Imie; // Dostępne wszędzie
    private double Wynagrodzenie; // Dostępne tylko wewnątrz klasy Pracownik
    protected string Stanowisko; // Dostępne w klasie Pracownik i jej podklasach
}


//Inicjalizacja pól

// Pola mogą być inicjalizowane w momencie deklaracji lub w konstruktorze klasy.
// Inicjalizacja w deklaracji jest wygodniejsza,
// jeśli pole ma stałą wartość dla wszystkich obiektów.

public class Konto
{
    public string NumerKonta = "12345678"; // Inicjalizacja w deklaracji
    public double Saldo;

    public Konto(double saldomin)
    {
        Saldo = saldomin; // Inicjalizacja w konstruktorze
    }
}

// W tym przykładzie pole NumerKonta jest inicjalizowane od razu,
// a pole Saldo jest inicjalizowane w konstruktorze klasy Konto.



// Dostęp do pól

// Aby uzyskać dostęp do pola i odczytać lub zmienić jego wartość, u
// żywamy składni kropkowej. Najpierw podajemy nazwę obiektu,
// a następnie nazwę pola, oddzielone kropką.


Osoba os = new Osoba();
os.Imie = "Jan"; // Ustawiamy wartość publicznego pola Imie
int wiek = os.Wiek; // Odczytujemy wartość prywatnego pola Wiek

// dostęp do pól prywatnych jest możliwy tylko wewnątrz klasy, w której zostały zdefiniowane.



// Pola statyczne

// Pola statyczne należą do całej klasy,
// a nie do poszczególnych obiektów.
// Oznacza to, że wszystkie obiekty danej klasy współdzielą tę samą wartość pola statycznego.

public class LicznikObiektow
{
    public static int LiczbaObiektow = 0; // Pole statyczne

    public LicznikObiektow()
    {
        LiczbaObiektow++; // Zwiększamy wartość pola statycznego
    }
}

var obj1 = new LicznikObiektow(); // LiczbaObiektow = 1
var obj2 = new LicznikObiektow(); // LiczbaObiektow = 2


// W tym przykładzie pole LiczbaObiektow jest statyczne,
// co oznacza, że jest wspólne dla wszystkich obiektów klasy LicznikObiektow.
// Przy tworzeniu nowych obiektów, wartość tego pola jest automatycznie aktualizowana.


