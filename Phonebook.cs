using System;
using System.Collections.Generic;
using System.Linq;

// klasa kontakt

public class Contact

{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public Contact(string name, string phoneNumber)

    {
        Name = name;
        PhoneNumber = phoneNumber;
    }

    public override string ToString()

    {

        return $"nazwa: {Name}, numer: {PhoneNumber}";

    }
}


// klasa książki telefonicznej z wszystkimi metodami

public class Phonebook
{


    private List<Contact> contacts { get; set; } = new List<Contact>(); // to najważniejsze



    // metoda 1 nowy kontakt

    public void AddContact(string name, string phoneNumber)
    {
        Contact newContact = new Contact(name, phoneNumber);
        contacts.Add(newContact);
        Console.WriteLine("kontakt dodany!");
    }


    // metoda 2 pokaż kontakt po numerze

    public void DisplayByNumber(string phoneNumber)
    {
        Contact contact = contacts.FirstOrDefault(c => c.PhoneNumber == phoneNumber);
        if (contact != null)
        {
            Console.WriteLine(contact);
        }
        else
        {
            Console.WriteLine("kontaktu nie znaleziono!");
        }
    }


    // metoda 3 pokaż wszystkie

    public void DisplayAllContacts()
    {
        if (contacts.Count == 0) //sprawdza czy nie ma 0 kontaktów
        {
            Console.WriteLine("książka telefoniczna jest pusta!");
            return;
        }

        Console.WriteLine("wszystkie kontakty:");
        foreach (var contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }


    // metoda 4 szukaj kontakty po imieniu

    public void SearchByName(string name)
    {
        var matchingContacts = contacts.Where(c => c.Name.ToLower().Contains(name.ToLower())).ToList();

        if (matchingContacts.Any())
        {
            Console.WriteLine($"kontakty znalezione dla nazwy '{name}':");
            foreach (var contact in matchingContacts)
            {
                Console.WriteLine(contact);
            }
        }
        else
        {
            Console.WriteLine($"brak kontaktów o nazie '{name}'");
        }
    }
}


// loop

class Program
{
    static void Main(string[] args)
    {
        Phonebook phonebook = new Phonebook();
        bool running = true;

        while (running)
        {

            Console.WriteLine("\nksiążka telefoniczna menu:");
            Console.WriteLine("1. dodaj nowy kontakt");
            Console.WriteLine("2. szukajka numer");
            Console.WriteLine("3. pokaż wszystkie kontakty");
            Console.WriteLine("4. szukajka nazwa");
            Console.WriteLine("5. zakończ");
            Console.Write("wybierz opcję: ");

            string choice = Console.ReadLine();


            switch (choice) // tu wszystkie kejsy 
            {
                case "1":
                    Console.Write("podaj nazwę: ");
                    string name = Console.ReadLine();
                    Console.Write("podaj numer: ");
                    string number = Console.ReadLine();
                    phonebook.AddContact(name, number);
                    break;

                case "2":
                    Console.Write("podaj numer do wyszukania: ");
                    string searchNumber = Console.ReadLine();
                    phonebook.DisplayByNumber(searchNumber);
                    break;

                case "3":
                    phonebook.DisplayAllContacts();
                    break;

                case "4":
                    Console.Write("podaj nazwę do wyszukania: ");
                    string searchName = Console.ReadLine();
                    phonebook.SearchByName(searchName);
                    break;

                case "5":
                    running = false;
                    break;

                default: // wywalenie komunikatu i kręci się dalej
                    Console.WriteLine("error! nie ma takiej opcji");
                    break;
            }

        }
    }
}
