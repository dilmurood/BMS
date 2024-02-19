// See https://aka.ms/new-console-template for more information
class Program
{
    public static List<Account> customers = new List<Account>();
    static void Main()
    {
        //populate the bank with cutomers
        Account account = new(new Person("Dilmurod", "Adam", "+555555555", "Tashkent, Uzbeksitan", 21), 5000.0M);
        Account account7 = new(new Person("Dilmurod", "Smith", "+111111111", "Tashkent, Uzbeksitan", 21), 5000.0M);
        Account account2 = new(new Person("Don", "Pon", "+7777777", "Tashkent, Uzbeksitan", 21), 6000.0M);
        Account account3 = new(new Person("Mania", "Fania", "+55856966", "Tashkent, Uzbeksitan", 21), 1000.0M);
        Account account4 = new(new Person("Killey", "Milley", "+9999999999", "Tashkent, Uzbeksitan", 21), 50_000.0M);
        Account account5 = new(new Person("Alex", "Malex", "+2111111121", "Tashkent, Uzbeksitan", 21), 500_000.0M);
        Account account6 = new(new Person("Dima", "Tima", "+000000000000", "Tashkent, Uzbeksitan", 31), 50.0M);

        customers.Add(account);
        customers.Add(account2);
        customers.Add(account3);
        customers.Add(account4);
        customers.Add(account5);
        customers.Add(account6);
        customers.Add(account7);

        Console.WriteLine("Welcome to Bank Management System!");
        short input;
        while (true)
        {
            Console.WriteLine("1 - Create new account.");
            Console.WriteLine("2 - Update account details.");
            Console.WriteLine("3 - Make a transaction.");
            Console.WriteLine("4 - Check the account balance.");
            Console.WriteLine("5 - Remove an account of a customer.");
            Console.WriteLine("6 - Show customer list.");
            Console.WriteLine("0 - Exit");
            input = Convert.ToInt16(Console.ReadLine());
            if (input == 0)
                break;
            else if (input == 1)
            {
                CreateAccount();
            }
            else if (input == 2)
            {
                UpdatePersonalDetails();
            }
            else if (input == 3)
            {
                MakeTransactions();
            }
            else if (input == 4)
            {
                CheckBalance();
            }
            else if (input == 5)
            {
                RemoveAnAccountOfACustomer();
            }
            else if (input == 6)
            {
                ShowCustomersList();
            }
            else
            {
                Console.WriteLine("Wrong input, try again!");
            }
        }
    }

    private static void MakeTransactions()
    {
        Account? account = SearchAccount();
        if (account is not null)
        {

            Console.WriteLine("We found you. What do you want to do: ");
            Console.WriteLine("1 - Withdraw money.");
            Console.WriteLine("2 - Deposit money.");
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 1)
            {
                Console.WriteLine("YOUR BALANCE: " + account.Balance + "$.");
                Console.WriteLine("Enter withdraw amount");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                account.Withdraw(amount);
                return;
            }
            else if (input == 2)
            {
                Console.WriteLine("Enter deposit amount");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                account.Deposit(amount);
                return;
            }

        }
        Console.WriteLine("This account is not found.");
    }

    static void UpdatePersonalDetails()
    {
        int input;
        Account? account = SearchAccount();
        while (account != null)
        {
            Console.WriteLine("1 - change first name.");
            Console.WriteLine("2 - change last name.");
            Console.WriteLine("4 - change address.");
            Console.WriteLine("5 - change phoneNumber.");
            Console.WriteLine("0 - Exit.");
            input = Convert.ToInt32(Console.ReadLine());
            if (input == 1)
            {
                Console.WriteLine($"Old first name - {account.person.FirstName} Enter new First name: ");
                string? firstName = Console.ReadLine();
                account.person.FirstName = firstName;
                Console.WriteLine($"First name change to {account.person.FirstName} successfully");
            }
            else if (input == 2)
            {
                Console.WriteLine($"Old last name - {account.person.LastName} Enter new Last name: ");
                string? lastName = Console.ReadLine();
                account.person.LastName = lastName;
                Console.WriteLine($"Last name change to {account.person.LastName} successfully");

            }
            else if (input == 4)
            {
                Console.WriteLine($"Old address - {account.person.Address} Enter new address: ");
                string? address = Console.ReadLine();
                account.person.Address = address;
                Console.WriteLine($"address change to {account.person.Address} successfully");
            }
            else if (input == 5)
            {
                Console.WriteLine($"Old Phone number - {account.person.PhoneNumber} Enter new phone number: ");
                string? phoneNumber = Console.ReadLine();
                account.person.PhoneNumber = phoneNumber;
                Console.WriteLine($"phone number change to {account.person.PhoneNumber} successfully");
            }
            else if (input == 0)
                return;
            else
                Console.WriteLine("Invalid input try again...");

            Console.WriteLine("You want to change anything else...");
        }

        Console.WriteLine("ID is not found...");
    }
    static Account? SearchAccount()
    {
        Console.WriteLine("Enter your Account id: ");
        int accountId = Convert.ToInt32(Console.ReadLine());
        foreach (var account in customers)
        {
            if (account.AccountId.Equals(accountId))
            {
                Console.WriteLine($"Found account {account.AccountId} " +
                $"\nbelonging to {account}.");
                return account;
            }
        }
        Console.WriteLine("Sorry, such account id does not exist.");
        return null;
    }

    static void RemoveAnAccountOfACustomer()
    {
        if (customers.Count > 0)
        {
            Account? account1 = SearchAccount();
            if (account1 is null)
                return;

            int accountId = account1.AccountId;
            foreach (var account in customers)
            {
                if (account.AccountId == accountId)
                {
                    Console.WriteLine(account.ToString() + $"\n{accountId} is successfully removed.......");
                    account1 = account;
                    break;
                }
            }

            if (account1 is not null)
            {
                customers.Remove(account1);
                return;
            }
        }
        Console.WriteLine("No customers left...........");
    }

    static void ShowCustomersList()
    {
        Console.WriteLine("=============================================");
        foreach (var item in customers)
        {
            Console.WriteLine(item.ToString());
            Console.WriteLine("=============================================");
        }
    }

    static void CreateAccount()
    {
        string? firstName, lastName, address, phoneNumber;
        int age;
        decimal initialBalance;
        Console.WriteLine("Please, enter your first name:");
        firstName = Console.ReadLine();
        Console.WriteLine("Please, enter your last name:");
        lastName = Console.ReadLine();
        Console.WriteLine("Please, enter your full address:");
        address = Console.ReadLine();
        Console.WriteLine("Please, enter your phoneNumber:");
        phoneNumber = Console.ReadLine();
        Console.WriteLine("Please, enter your age:");
        age = Convert.ToInt32(Console.ReadLine());
        if (age < 18)
            Console.WriteLine("Sorry, you are not old enough...");
        else
        {
            Console.WriteLine("Please, enter your initial balance amount:");
            initialBalance = Convert.ToDecimal(Console.ReadLine());
            if (initialBalance < 100)
            {
                Console.WriteLine("Sorry you cannot create account with balance less than 100$.");
                return;
            }

            Account account = new(new Person(firstName, lastName, phoneNumber, address, age), initialBalance);
            Console.WriteLine("Account created successfully.. " + account.ToString());
            customers.Add(account);
        }
    }

    static void CheckBalance()
    {
        Account? account = SearchAccount();
        if (account is not null)
        {
            int accountId = account.AccountId;
            foreach (var a in customers)
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
