// File: StudyNotes.cs
// Comprehensive example covering basics of C#

// Base class (parent class) for inheritance example
public class Animal
{
    // Properties
    public string Name { get; set; }
    public int Age { get; set; }

    // Constructor
    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Method
    public virtual void MakeSound()
    {
        Console.WriteLine("Some animal sound");
    }
}

// Derived class (child class) - inheritance example
public class Dog : Animal
{
    public string Breed { get; set; }

    // Constructor using base class constructor
    public Dog(string name, int age, string breed) : base(name, age)
    {
        Breed = breed;
    }

    // Override method from parent class
    public override void MakeSound()
    {
        Console.WriteLine("Woof! Woof!");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Example of creating objects using constructors
        Dog myDog = new Dog("Rex", 3, "German Shepherd");
        
        // Example of if statement
        if (myDog.Age > 2)
        {
            Console.WriteLine($"{myDog.Name} is an adult dog");
        }
        else
        {
            Console.WriteLine($"{myDog.Name} is a puppy");
        }

        // Example of array for foreach
        string[] fruits = { "Apple", "Banana", "Orange", "Grape" };

        // Example of foreach loop
        Console.WriteLine("\nList of fruits:");
        foreach (string fruit in fruits)
        {
            Console.WriteLine(fruit);
        }

        // Example of switch and case
        int dayNumber = 3;
        switch (dayNumber)
        {
            case 1:
                Console.WriteLine("Monday");
                break;
            case 2:
                Console.WriteLine("Tuesday");
                break;
            case 3:
                Console.WriteLine("Wednesday");
                break;
            case 4:
                Console.WriteLine("Thursday");
                break;
            case 5:
                Console.WriteLine("Friday");
                break;
            default:
                Console.WriteLine("Weekend");
                break;
        }

        // Example calling methods
        myDog.MakeSound();
    }

    // Example of a simple method
    public static int AddNumbers(int a, int b)
    {
        return a + b;
    }
}
