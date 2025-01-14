using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace BankApp
{
    class Client //klasa klient tu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }

        public Client(int id, string name, decimal balance)
        {
            Id = id;
            Name = name;
            Balance = balance;
        }
    }


    class Program  //główna logika
    {
        static List<Client> clients = new List<Client>();
        static string connectionString = "Data Source=BankDB.db"; // ścieżka do pliku bazy danych SQLite

        static void Main(string[] args)
        {
            InitializeDatabase();  //baza danych

            while (true)
            {
                Console.WriteLine("\n--- Aplikacja Bankowa ---");
                Console.WriteLine("1. Dodaj klienta");
                Console.WriteLine("2. Usuń klienta");
                Console.WriteLine("3. Wykonaj przelew");
                Console.WriteLine("4. Wyświetl klientów");
                Console.WriteLine("5. Wyjście");

                Console.Write("Wybierz opcję: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddClient();
                        break;
                    case "2":
                        RemoveClient();
                        break;
                    case "3":
                        MakeTransfer();
                        break;
                    case "4":
                        DisplayClients();
                        break;
                    case "5":
                        Console.WriteLine("Zamykanie aplikacji...");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                        break;
                }
            }
        }

        static void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // sprawdzenie czy tabela istnieje
                    using (var checkCmd = new SqliteCommand("SELECT name FROM sqlite_master WHERE type='table' AND name='Clients';", connection))
                    {
                        var result = checkCmd.ExecuteScalar();

                        if (result == null)
                        {
                            using (var createCmd = new SqliteCommand("CREATE TABLE Clients (Id INTEGER PRIMARY KEY, Name TEXT, Balance REAL);", connection))
                            {
                                createCmd.ExecuteNonQuery();
                            }
                        }
                    }

                    // branie klientów z bazy danych przy uruchomieniu 
                    using (var command = new SqliteCommand("SELECT Id, Name, Balance FROM Clients", connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                decimal balance = reader.GetDecimal(2);

                                clients.Add(new Client(id, name, balance));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd połączenia z bazą danych: {ex.Message}");
                }
            }
        }

        static void AddClient() //metoda dodaj klienta
        {
            Console.Write("Podaj ID klienta: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Nieprawidłowe ID.");
                return;
            }

            Console.Write("Podaj imię i nazwisko klienta: ");
            string name = Console.ReadLine();

            Console.Write("Podaj saldo początkowe: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal balance))
            {
                Console.WriteLine("Nieprawidłowe saldo.");
                return;
            }


            Client newClient = new Client(id, name, balance);
            clients.Add(newClient);

            //dodawanie do SQL
            using (var connection = new SqliteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "INSERT INTO Clients (Id, Name, Balance) VALUES (@Id, @Name, @Balance)";
                    using (var cmd = new SqliteCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@Id", newClient.Id);
                        cmd.Parameters.AddWithValue("@Name", newClient.Name);
                        cmd.Parameters.AddWithValue("@Balance", newClient.Balance);

                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Klient dodany do bazy danych.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd dodawania klienta do bazy danych: {ex.Message}");
                }
            }
        }


        static void RemoveClient() //metoda usuń klienta
        {
            Console.Write("Podaj ID klienta do usunięcia: ");
            if (!int.TryParse(Console.ReadLine(), out int idToRemove))
            {
                Console.WriteLine("Nieprawidłowe ID.");
                return;
            }

            Client clientToRemove = clients.Find(client => client.Id == idToRemove);
            if (clientToRemove != null)
            {
                clients.Remove(clientToRemove);
                //usuwanie z SQL
                using (var connection = new SqliteConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string sql = "DELETE FROM Clients WHERE Id = @Id";
                        using (var cmd = new SqliteCommand(sql, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", idToRemove);

                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Klient usunięty z bazy danych.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Błąd usuwania klienta z bazy danych: {ex.Message}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Nie znaleziono klienta o podanym ID.");
            }
        }

        static void MakeTransfer() //metoda transferu
        {
            Console.Write("Podaj ID klienta, od którego chcesz przelać pieniądze: ");
            if (!int.TryParse(Console.ReadLine(), out int senderId))
            {
                Console.WriteLine("Nieprawidłowe ID.");
                return;
            }

            Console.Write("Podaj ID klienta, do którego chcesz przelać pieniądze: ");
            if (!int.TryParse(Console.ReadLine(), out int recipientId))
            {
                Console.WriteLine("Nieprawidłowe ID.");
                return;
            }

            Console.Write("Podaj kwotę przelewu: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Nieprawidłowa kwota.");
                return;
            }

            Client sender = clients.Find(client => client.Id == senderId);
            Client recipient = clients.Find(client => client.Id == recipientId);

            if (sender == null || recipient == null)
            {
                Console.WriteLine("Nieprawidłowe ID nadawcy lub odbiorcy.");
                return;
            }

            if (sender.Balance < amount)
            {
                Console.WriteLine("Niewystarczające środki na koncie nadawcy.");
                return;
            }

            sender.Balance -= amount;
            recipient.Balance += amount;

            // aktualizacja SQL
            using (var connection = new SqliteConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    //  saldo nadawcy
                    string sqlSender = "UPDATE Clients SET Balance = @Balance WHERE Id = @Id";
                    using (var cmdSender = new SqliteCommand(sqlSender, connection))
                    {
                        cmdSender.Parameters.AddWithValue("@Id", sender.Id);
                        cmdSender.Parameters.AddWithValue("@Balance", sender.Balance);
                        cmdSender.ExecuteNonQuery();
                    }
                    //  saldo odbiorcy
                    string sqlRecipient = "UPDATE Clients SET Balance = @Balance WHERE Id = @Id";
                    using (var cmdRecipient = new SqliteCommand(sqlRecipient, connection))
                    {
                        cmdRecipient.Parameters.AddWithValue("@Id", recipient.Id);
                        cmdRecipient.Parameters.AddWithValue("@Balance", recipient.Balance);
                        cmdRecipient.ExecuteNonQuery();
                    }

                    Console.WriteLine("Przelew wykonany pomyślnie.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Błąd aktualizacji przelewu w bazie danych: {ex.Message}");
                }
            }
            Console.WriteLine($"Saldo nadawcy po przelewie: {sender.Balance}");
            Console.WriteLine($"Saldo odbiorcy po przelewie: {recipient.Balance}");
        }

        static void DisplayClients() //metoda pokaż listę klientów
        {
            Console.WriteLine("--- Lista klientów ---");
            foreach (var client in clients)
            {
                Console.WriteLine($"ID: {client.Id}, Imię i nazwisko: {client.Name}, Saldo: {client.Balance}");
            }
        }
    }
}
