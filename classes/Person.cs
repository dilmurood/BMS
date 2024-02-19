public class Person
{
    private int age;
    public string FirstName { get; set; }
    public string LastName { get; set; }
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
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public Person(string firstName, string lastName, string phoneNumber, string address, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Address = address;
        this.age = age;
    }
    public override string ToString()
    {
        return $"\nMr/Ms {FirstName} {LastName} \nContact mumber {PhoneNumber},  \nage: {Age}  \naddress: {Address}";
    }
}