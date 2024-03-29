public class Person
{
    private int age;
    public string CitizenshipId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public int Age { 
        get { return age;} 
        set 
        { 
            if (age < 0) 
            {
                Console.WriteLine("Age cannot be negative...........");
                return;
            }else if(age < 18)
            {
                Console.WriteLine("Age is not old enough.......");
                return;
            }else
                age = value;
        } 
    }

    public List<Account> accounts = new List<Account>();
    public Person(string firstName, string lastName, string phoneNumber, string address, string citizenshipId, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Address = address;
        CitizenshipId = citizenshipId;
        this.age = age;
    }
  
    public override string ToString()
        => $"\nMr/Ms {FirstName} {LastName} \nContact mumber {PhoneNumber},  \nage: {Age}  \naddress: {Address}";
  
}