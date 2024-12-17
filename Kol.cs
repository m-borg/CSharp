using System;


//1. Wyjaśnij klasę abststrakcyjną




// w abstrakcyjnej nie można tworzyć instancji i nie da się jej utworzyć za za pomocą operatora new
// jej celem jest służenie jako baza dla innych klas, które dziedziczą po niej.
// może zawierać abstrakcyjne metody




// 2. Stwórz klasę abstrakcyjną Human

public abstract class Human
{


    // 3. W klasie abstrakcyjnej stwórz metodę Test, która przyjmuje argumenty, int age, bool luck, bool knowledge

    // W przypadku gdy ((Wartość age jest większa niż 20 oraz wartość knowledge jest prawdą) lub (wartość luck jest różna od false)

    // Metoda wyświetli wiadomość "Student passedexam" i zwróci wartość true.

    // W innym przypadku Metoda wyświetlni wiadomość "Student failedexam" i zwróci false



    public bool Test(int age, bool luck, bool knowledge)
    {
        if ((age > 20 && knowledge) || luck)
        {
            Console.WriteLine("Student passedexam");
            return true;
        }

        else
        {
            Console.WriteLine("Student failedexam");
            return false;
        }
    }




    // 4. W klasie abstrakcyjnej stwórz metodę WhatToSay która wyświetli wiadomość "I dont know what to say"



    public void WhatToSay()
    {

        Console.WriteLine("I dont know what to say");
    }




    // 5. W klasie abstrakcyjnej stwórz metodę do nadpisania SayMyName która wyświetla wiadomość "I have no name"

    public virtual void SayMyName()

    {
        Console.WriteLine("I have no name");
    }
}



// 6. Stwórz klasę Student która będzie dziedziczyć z klasy Human


public class Student : Human
{
    // 7. Stwórz w klasie Student 3 Właściowości/Akcesory string Name boolLuck, intAge
    // z dostępem odczytu public i dostępem ustawienia private


    public string Name { get; private set; }
    public bool Luck { get; private set; }
    public int Age { get; private set; }

    //  8. Dla klasy student Utwórz konstruktor (dwa) i go przeciąż tak aby zainicjalizować wartości
    // 1 (string name, boolluck, intage) i 2 (boolluck, intage)

    public Student(string name, bool luck, int age)
    {
        Name = name;
        Luck = luck;
        Age = age;
    }

    public Student(bool luck, int age)
    {
        Luck = luck;
        Age = age;
        Name = "No Name";
    }

    //9.  W klasie Student nadpisz dzidziczoną metodę SayMyName z klasy Human tak aby wyświetlić wartość Name (punkt 7.)

    public override void SayMyName()
    {
        Console.WriteLine($"My name is {Name}");
    }
}

public class Program
{

    public static void Main(string[] args)

    {
        //10. Stwórz instancje klasy Student-Teacher wywołując jej konstruktor z parametrami ("Teacher", false, 32)

        Student teacher = new Student("Teacher", false, 32);

        // Stówrz instancje klasy Student-Alex wywołując jej konstruktor z parametrami (true, 19)

        Student alex = new Student(true, 19);

        //Stwórz zmienną string teacherKnowledge=true

        bool teacherKnowledge = true; //dałem bool bo true false

        //Stwórz zmienną string alexKnowledge=false

        bool alexKnowledge = false;

        //Wywołaj z instancji Teacher Metodę Test z paramentrami (Age, Luck, teacherKnowledge);

        bool teacherTestResult = teacher.Test(teacher.Age, teacher.Luck, teacherKnowledge);

        //Wywołaj z instancji Alex Metodę Test z parametrami (Age, Luck, alexKnowledge);


        bool alexTestResult = alex.Test(alex.Age, alex.Luck, alexKnowledge);

        //11. Stwórz instrukcję warunkową switch dla wyników działania metody Test (zapisz wynik działania dla obu instancji_
        // case 1 jeżeli Teacher.Test=true i Alex.Test=true to wyświetli "Knowledge and luck matters"
        // case 2 jeżeli Teacher.Test=false i Alex.Test=false to wyświetli "Nothing Matters"
        // case 3 jeżeli Teahcer.Test=true i Alex.Test=false to wyświetli "Only knowledge matters"
        // case 4 jeżeli Teacher.Test=false i Alex.Test=true to wyświetli "Only luck matetrs"

        switch ((teacherTestResult, alexTestResult))
        {
            case (true, true):
                Console.WriteLine("Knowledge and luck matters");
                break;
            case (false, false):
                Console.WriteLine("Nothing Matters");
                break;
            case (true, false):
                Console.WriteLine("Only knowledge matters");
                break;
            case (false, true):
                Console.WriteLine("Only luck matters");
                break;

        }




    }
}
