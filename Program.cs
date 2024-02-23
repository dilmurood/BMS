class Program
{
    public static List<Person> users = new List<Person>();

    static void Main()
    {
        Person p1 = new Person("Dilmurod", "Adam", "+555555555", "Tashkent, Uzbeksitan", "AC1731845", 21);
        Person p2 = new Person("Don", "Pon", "+7777777", "Tashkent, Uzbeksitan", "AC17318455", 55);

        Account account = new(5000.0M, "savings");
        Account account2 = new(6000.0M, "credit");
        Account account3 = new(1000.0M, "debt");
        Account account4 = new(50_000.0M, "savings");
        Account account5 = new(500_000.0M, "credit");
        Account account6 = new(50.0M, "for fun");
        //=============================================================
        p1.accounts.Add(account);
        p1.accounts.Add(account2);
        p1.accounts.Add(account3);

        p2.accounts.Add(account4);
        p2.accounts.Add(account5);
        p2.accounts.Add(account6);
        //=============================================================
        users.Add(p1);
        users.Add(p2);

        Console.WriteLine("Welcome to Bank Management System!");
        byte input;
        Console.WriteLine("Choose an option below:");
        Console.WriteLine("1-Login.");
        Console.WriteLine("2-Register.");
        int a = Convert.ToInt32(Console.ReadLine());
        if (a == 2)
        {
            RegisterUser();
        }
        Console.WriteLine("Please, enter your citizenship ID To log In your account: ");
        string id = Console.ReadLine();
        Console.WriteLine("searching......");
        Thread.Sleep(1000);
        Person person;
        
        if (SearchUserById(id, out person) && person is not null)
        {
            while (true)
            {
                Console.WriteLine("1 - Create new account.");
                Console.WriteLine("2 - Update profile details details.");
                Console.WriteLine("3 - Make a transaction.");
                Console.WriteLine("4 - Check the account balance.");
                Console.WriteLine("5 - Remove an account of a customer.");
                Console.WriteLine("6 - Show user's list of accounts.");
                Console.WriteLine("0 - Exit");
                input = Convert.ToByte(Console.ReadLine());
                if (input == 0)
                    break;
                else if (input == 1)
                    CreateAccount(person);
                else if (input == 2)
                    UpdatePersonalDetails(person);
                else if (input == 3)
                    MakeTransactions(person);
                else if (input == 4)
                    CheckBalance(person);
                else if (input == 5)
                {
                    Console.WriteLine("=================================================================================================");
                    RemoveAnAccountOfACustomer(person);
                }
                else if (input == 6)
                    ShowAccountsList(person);
                else
                    Console.WriteLine("Wrong input, try again!");
                          
            }
        }
    }
    static void RegisterUser()
    {
        Console.WriteLine("Please enter your first name: ");
        string firstName = Console.ReadLine();
        Console.WriteLine("Please enter your last name: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Please enter your phone number: ");
        string phoneNumber = Console.ReadLine();
        Console.WriteLine("Please enter your address: ");
        string address = Console.ReadLine();
        Console.WriteLine("Please enter your citizenship id: ");
        string citizenshipId = Console.ReadLine();
        Console.WriteLine("Please enter your age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Person person = new(firstName, lastName, phoneNumber, address, citizenshipId, age);
        users.Add(person);
        CreateAccount(person);
    }
    static bool SearchUserById(string id, out Person person)
    {
        foreach(var user in users)
        {
            if (user.CitizenshipId == id)
            {
                Console.WriteLine("User is found................\n" + user.ToString());
                person = user;
                return true;
            }
        }
        person = null;
        Console.WriteLine("User is not found................");
        Console.ReadKey();
        return false;
    }
    static void MakeTransactions(Person person)
    {
        Account? account = SearchAccount(person);
        if (account is not null)
        {
            Console.WriteLine("What do you want to do: ");
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("1 - Withdraw money.");
                Console.WriteLine("2 - Deposit money.");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                {
                    Console.WriteLine("YOUR BALANCE: " + account.Balance.ToString("0.00") + "$.");
                    Console.WriteLine("Enter withdraw amount");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());
                    flag = !account.Withdraw(amount);
                }
                else if (input == 2)
                {
                    Console.WriteLine("Enter deposit amount");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());
                    flag = !account.Deposit(amount);
                }
            }
            return;
        }
        Console.WriteLine("This account is not found.");
    }
    static void UpdatePersonalDetails(Person person)
    {
        int input;
        while (person != null)
        {
            Console.WriteLine(person.ToString());
            Console.WriteLine("1 - change first name.");
            Console.WriteLine("2 - change last name.");
            Console.WriteLine("3 - change address.");
            Console.WriteLine("4 - change phoneNumber.");
            Console.WriteLine("0 - Exit.");
            input = Convert.ToInt32(Console.ReadLine());
            if (input == 1)
            {
                Console.WriteLine($"Old first name - {person.FirstName} Enter new First name: ");
                string? firstName = Console.ReadLine();
                person.FirstName = firstName;
                Console.WriteLine($"First name change to {person.FirstName} successfully");
            }
            else if (input == 2)
            {
                Console.WriteLine($"Old last name - {person.LastName} Enter new Last name: ");
                string? lastName = Console.ReadLine();
                person.LastName = lastName;
                Console.WriteLine($"Last name change to {person.LastName} successfully");

            }
            else if (input == 3)
            {
                Console.WriteLine($"Old address - {person.Address} Enter new address: ");
                string? address = Console.ReadLine();
                person.Address = address;
                Console.WriteLine($"address change to {person.Address} successfully");
            }
            else if (input == 4)
            {
                Console.WriteLine($"Old Phone number - {person.PhoneNumber} Enter new phone number: ");
                string? phoneNumber = Console.ReadLine();
                person.PhoneNumber = phoneNumber;
                Console.WriteLine($"phone number change to {person.PhoneNumber} successfully");
            }
            else if (input == 0)
                return;
            else
                Console.WriteLine("Invalid input try again...");

            Console.WriteLine("You want to change anything else...");
        }

        Console.WriteLine("ID is not found...");
    }
    static Account SearchAccount(Person person)
    {
        Console.WriteLine("Enter your Account id: ");
        int accountId = Convert.ToInt32(Console.ReadLine());
        foreach (var account in person.accounts)
        {
            if (account.AccountId.Equals(accountId))
            {
                Console.WriteLine($"Found account {account.AccountId}");
                return account;
            }
        }
        Console.WriteLine("Sorry, such account id does not exist.");
        return null;
    }
    static void RemoveAnAccountOfACustomer(Person person)
    {
        if (users.Count > 0)
        {
            Account? account = SearchAccount(person);
            if (account is null)
                return;

            if(account.Balance > 0)
            {
                Console.WriteLine(account.Balance + " will automaticlly be withdrawn...");
                account.Withdraw(account.Balance);
            }

            Console.WriteLine("This account is removed from your list accounts.");
            person.accounts.Remove(account);
            Console.WriteLine("Remaining accounts: ");
            ShowAccountsList(person);
            return;
        }

        Console.WriteLine("There is No customers To search for...........");
    }
    static void ShowCustomersList()
    {
        Console.WriteLine("=============================================");
        foreach (var item in users)
        {
            Console.WriteLine(item.ToString());
            Console.WriteLine("=============================================");
        }
    }
    static void ShowAccountsList(Person person)
    {
        Console.WriteLine("=============================================");
        int i = 0;
        foreach (var item in person.accounts)
        {
            i++;
            Console.WriteLine(i + " - " + item.ToString());
            Console.WriteLine("=============================================");
        }
    }
    static void CreateAccount(Person person)
    {
        decimal initialBalance;
        Console.WriteLine("Please, enter your initial balance amount:");
        initialBalance = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Enter the purpose of account");
        string purpose = Console.ReadLine();
        if (initialBalance < 100)
        {
            Console.WriteLine("Sorry you cannot create account with balance less than 100$.");
            return;
        }
        Account account = new(initialBalance, purpose);
        person.accounts.Add(account);
        Console.WriteLine("Account created successfully........\n" + person.ToString() + account.ToString());
        Console.WriteLine("Please, do not forget your account id: " + account.AccountId);
    }
    static void CheckBalance(Person person)
    {
        Account? account = SearchAccount(person);
        if (account is not null)
        {
            int accountId = account.AccountId;
            foreach (var a in person.accounts)
            {
                if (a.AccountId.Equals(accountId))
                {
                    Console.WriteLine("========================================================");
                    Console.WriteLine("Your balance: " + a.Balance);
                    Console.WriteLine("========================================================");
                    break;
                }
            }
        }
    }
}
