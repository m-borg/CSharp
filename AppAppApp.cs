public class User
{
    public int ID { get; set; }
    public int ManagerID { get; set; }
    public string Name { get; set; }
    public List<int> AssignedApps { get; set; } = new List<int>(); // Aplikacje które user może G R A N T O W A Ć
    public List<int> OwnedApps { get; set; } = new List<int>(); // Aplikacje które user P O S I A D A
}

public class Application
{
    public int AppId { get; set; }
    public string AppName { get; set; }
}

public class ApprovalWorkflow
{
    private readonly Dictionary<int, User> _users = new Dictionary<int, User>();
    private readonly List<Application> _applications = new List<Application>();

    public ApprovalWorkflow()
    {
        InitializeData();
    }

    private void InitializeData()
    {
        _applications.AddRange(new[]
        {
            new Application { AppId = 1, AppName = "Viso" },
            new Application { AppId = 2, AppName = "SQL" },
            new Application { AppId = 3, AppName = "Studio" },
            new Application { AppId = 4, AppName = "Postman" },
            new Application { AppId = 5, AppName = "SOAP" },
            new Application { AppId = 6, AppName = "Jira" }
        });

        var users = new[]
              {
            new User { ID = 1, ManagerID = 0, Name = "Karolin", AssignedApps = new List<int> { 4, 5, 6 } },
            new User { ID = 2, ManagerID = 1, Name = "Ola", AssignedApps = new List<int> { 1, 2, 3 } },
            new User { ID = 3, ManagerID = 2, Name = "Artur", AssignedApps = new List<int> { 1, 2 } },
            new User { ID = 4, ManagerID = 2, Name = "Łukasz", AssignedApps = new List<int> { 1, 2 } },
            new User { ID = 5, ManagerID = 2, Name = "Andrzej", AssignedApps = new List<int> { 3, 4 } },
            new User { ID = 6, ManagerID = 2, Name = "Wiktor", AssignedApps = new List<int> { 3, 4 } },
            new User { ID = 7, ManagerID = 2, Name = "Rafał", AssignedApps = new List<int> { 5, 6 } },
            new User { ID = 8, ManagerID = 2, Name = "Michał", AssignedApps = new List<int> { 5, 6 } },
            new User { ID = 9, ManagerID = 2, Name = "Damian", AssignedApps = new List<int>() },
            new User { ID = 10, ManagerID = 2, Name = "Paweł", AssignedApps = new List<int>() },
            new User { ID = 11, ManagerID = 99, Name = "Steven", AssignedApps = new List<int>() }
        };

        foreach (var user in users)
        {
            _users[user.ID] = user;
        }

}

    public List<string> GetAppGrantors(int appId)
    {
        return _users.Values
            .Where(u => u.AssignedApps.Contains(appId))
            .Select(u => u.Name)
            .ToList();
    }


    public bool RequestAccess(int userId, int appId)
    {
        if (!_users.ContainsKey(userId))
            throw new ArgumentException("User not found");

        var user = _users[userId];

        if (user.OwnedApps.Contains(appId))
        {
            Console.WriteLine($"\nUser {user.Name} already owns {_applications.First(a => a.AppId == appId).AppName}");
            return false;
        }

        var appGrantors = GetAppGrantors(appId);


        if (appGrantors.Count == 0)
        {
            Console.WriteLine($"\nNo one can grant access to {_applications.First(a => a.AppId == appId).AppName}");
            return false;
        }

        bool isSpecialUser = user.ManagerID == 0 || user.ManagerID == 99;


        Console.WriteLine($"\nWorkflow for {user.Name} requesting {_applications.First(a => a.AppId == appId).AppName}:");
        bool managerApproved = true;


        if (!isSpecialUser)
        {
            var managerName = _users.ContainsKey(user.ManagerID)
                ? _users[user.ManagerID].Name
                : "Unknown Manager";

            Console.WriteLine($"1. Requires approval from manager: {managerName}");
            Console.Write("\nManager approval (y/n): ");
            managerApproved = Console.ReadLine()?.ToLower() == "y";
        }
        else
        {
            Console.WriteLine("No manager approval required - special user.");
        }


        Console.WriteLine($"2. Requires approval from one of the grantors: {string.Join(", ", appGrantors)}");
        Console.Write("App grantor approval (y/n): ");
        bool appGrantorApproved = Console.ReadLine()?.ToLower() == "y";

        if (managerApproved && appGrantorApproved)
        {
            user.OwnedApps.Add(appId);
            return true;
        }

        return false;
    }


    public void DisplayAvailableApplications()
    {
        Console.WriteLine("\nAvailable Applications:");
        foreach (var app in _applications)
        {
            Console.WriteLine($"- {app.AppId}: {app.AppName}");
        }
    }

    public void DisplayAllUsers()
    {
        Console.WriteLine("\nAvailable Users:");
        foreach (var user in _users.Values)
        {
            Console.WriteLine($"- {user.ID}: {user.Name}");
        }
    }

    public void DisplayUserApps(int userId)
    {
        if (!_users.ContainsKey(userId))
            throw new ArgumentException("User not found");

        var user = _users[userId];
        Console.WriteLine($"\nApplications assigned to {user.Name}:");
        foreach (var appId in user.AssignedApps)
        {
            var app = _applications.First(a => a.AppId == appId);
            Console.WriteLine($"- {app.AppName}");
        }
    }


    public void DisplayUserOwnedApps(int userId) // to dodane zamiast assigned bo było rozwalone
    {
        if (!_users.ContainsKey(userId))
            throw new ArgumentException("User not found");

        var user = _users[userId];
        Console.WriteLine($"\nApplications owned by {user.Name}:");

        if (user.OwnedApps.Count == 0)
        {
            Console.WriteLine("No apps owned.");
            return; // to kiedy nie ma apek
        }

        foreach (var appId in user.OwnedApps)
        {
            var app = _applications.First(a => a.AppId == appId);
            Console.WriteLine($"- {app.AppName}");
        }
    }

}

public class Program
{
    public static void Main()
    {
        var workflow = new ApprovalWorkflow();

        while (true)
        {
            try
            {
                workflow.DisplayAllUsers();
                Console.Write("\nSelect User ID (or 0 to exit): ");
                int userId = int.Parse(Console.ReadLine());

                if (userId == 0) break;

                workflow.DisplayAvailableApplications();
                Console.Write("\nSelect Application ID: ");
                int appId = int.Parse(Console.ReadLine());

                bool accessGranted = workflow.RequestAccess(userId, appId);
                Console.WriteLine(accessGranted ? "\nAccess granted!" : "\nAccess denied.");

                if (accessGranted)
                    workflow.DisplayUserOwnedApps(userId); // tu funkcja żeby pokazać owned apps

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}

