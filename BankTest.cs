using System;
using System.Collections.Generic;


class Client
{
    public int ID { get; set; }
    public string FullName { get; set; }
    public decimal Balance { get; set; }

    public Client(int id, string fullName, decimal balance)
    {
        ID = id;
        FullName = fullName;
        Balance = balance;
    }
}



class Bank
{
    private List<Client> clients = new List<Client>();

    public void AddClient(int id, string fullName, decimal initialBalance)
    {
        clients.Add(new Client(id, fullName, initialBalance));
        Console.WriteLine($"Dodano klienta: {fullName} (ID: {id})");
    }

    public void RemoveClient(int id)
    {
        Client client = clients.Find(c => c.ID == id);
        if (client != null)
        {
            clients.Remove(client);
            Console.WriteLine($"Usunięto klienta: {client.FullName} (ID: {id})");
        }
        else
        {
            Console.WriteLine($"Nie znaleziono klienta o ID: {id}");
        }
    }

    public void Transfer(int fromId, int toId, decimal amount)
    {
        Client fromClient = clients.Find(c => c.ID == fromId);
        Client toClient = clients.Find(c => c.ID == toId);

        if (fromClient == null || toClient == null)
        {
            Console.WriteLine("Nie znaleziono jednego lub obu klientów.");
            return;
        }

        if (fromClient.Balance < amount)
        {
            Console.WriteLine("Niewystarczające środki na koncie.");
            return;
        }

        fromClient.Balance -= amount;
        toClient.Balance += amount;

        Console.WriteLine($"Przelew wykonany: {amount} od {fromClient.FullName} do {toClient.FullName}");
    }

    public void DisplayClients()
    {
        Console.WriteLine("Lista klientów:");
        foreach (var client in clients)
        {
            Console.WriteLine($"ID: {client.ID}, Imię i nazwisko: {client.FullName}, Saldo: {client.Balance}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();

        while (true)
        {
            Console.WriteLine("\nWybierz operację:");
            Console.WriteLine("1. Dodaj klienta");
            Console.WriteLine("2. Usuń klienta");
            Console.WriteLine("3. Wykonaj przelew");
            Console.WriteLine("4. Wyświetl listę klientów");
            Console.WriteLine("5. Wyjście");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Podaj ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Podaj imię i nazwisko: ");
                    string fullName = Console.ReadLine();
                    Console.Write("Podaj saldo początkowe: ");
                    decimal balance = decimal.Parse(Console.ReadLine());
                    bank.AddClient(id, fullName, balance);
                    break;
                case "2":
                    Console.Write("Podaj ID klienta do usunięcia: ");
                    int removeId = int.Parse(Console.ReadLine());
                    bank.RemoveClient(removeId);
                    break;
                case "3":
                    Console.Write("Podaj ID klienta wykonującego przelew: ");
                    int fromId = int.Parse(Console.ReadLine());
                    Console.Write("Podaj ID klienta otrzymującego przelew: ");
                    int toId = int.Parse(Console.ReadLine());
                    Console.Write("Podaj kwotę przelewu: ");
                    decimal amount = decimal.Parse(Console.ReadLine());
                    bank.Transfer(fromId, toId, amount);
                    break;
                case "4":
                    bank.DisplayClients();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                    break;
            }
        }
    }
}
