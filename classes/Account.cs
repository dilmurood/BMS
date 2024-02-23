public class Account
{
    private decimal balance;
    private static int nextId = 1;
    public int AccountId { get; private set; }
    public decimal Balance 
    { 
        get{return balance;} set{balance = value;}
    }
    private DateTime createdDate;
    public string purpose;

    //Composition prefered over inheritence
    public Account(decimal initialBalance, string purpose)
    {
        balance = initialBalance;
        this.purpose = purpose;
        createdDate = DateTime.Now;
        AccountId = 1000 + nextId++;
    }
    public bool Deposit(decimal amount)
    {
        if(amount < 0)
            Console.WriteLine("You cannot deposit negative amount of money");
        else
        {
            balance += amount;
            Console.WriteLine("Money is successfully deposited... \nUPDATED BALANCE : " + balance);
            return true;
        }

        return false;
    }

    public bool Withdraw(decimal amount)
    {
        if (amount > balance)
            Console.WriteLine("Not enough money try lower amount.");
        else if (amount < 0)
            Console.WriteLine("You cannot withdraw negative amount of money.");
        else 
        {
            balance -= amount;
            Console.WriteLine("Money is successfully withdrawn... \nremaining balance : " + balance);
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"created date: {createdDate} \nBalance: {balance} \npurpse: {purpose}";
    }
}
