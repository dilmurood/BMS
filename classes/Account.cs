public class Account :  IComparable<Account>
{
    private decimal balance;
    private static int nextId = 1;
    public int AccountId { get; private set; }
    public decimal Balance 
    { 
        get{return balance;} set{balance = value;}
    }

    private DateTime createdDate;
    public Person person;
    public Account(Person person, decimal initialBalance)
    {
        balance = initialBalance;
        createdDate = DateTime.Now;
        AccountId = nextId++;
        this.person = person;
        //Console.WriteLine(ToString());
    }
    public void Deposit(decimal amount)
    {
        if(amount < 0)
            Console.WriteLine("You cannot deposit negative amount of money");
        else
        {
            balance += amount;
            Console.WriteLine("Money is successfully deposited... \nUPDATED BALANCE : " + balance);
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > balance)
            Console.WriteLine("Not enough money try lower amount.");
        else if (amount < 0)
            Console.WriteLine("You cannot withdraw negative amount of money.");
        else 
        {
            balance -= amount;
            Console.WriteLine("Money is successfully withdrawn... remaining balance : " + balance);
        }
    }

    public override string ToString()
    {
        return $" {person} \ncreated date: {createdDate}";
    }
    public int CompareTo(Account? other)
    {
        return AccountId.CompareTo(other?.AccountId);
    }
}
