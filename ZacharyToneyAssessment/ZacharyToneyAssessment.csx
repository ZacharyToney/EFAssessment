using System;
using System.Collections.Generic;
using System.Text;

//Part 1
//1
int a = 5;
bool b = true;
string c = "Zach";
double d = 0.8d;
decimal e = 1.25m;

//2
string sentence(string c, int a)
{
    return $"{c} has been coding for about {a} years.";
}
//3
Console.WriteLine(sentence(c,a));
//4
var closefriends =
    new[]
    {
        "Blake",
        "Zach",
        "Sam",
        "Rachel",
        "Jacob"
    };
//5
foreach (string element in closefriends)
{
    Console.WriteLine(element);
}
//Part two
//1
public enum Gender
{
    Unknown,
    Male,
    Female
}

//1
public class Customer
{
    //2
    public Customer(string name, Gender gender, string product)
    {
        Name = name;
        Gender = gender;
        Product = product;
    }

    public string Name { get; set; }
    public Gender Gender { get; set; }
    public string Product { get; set; }
    
    //3
    public void thankyou()
    {
        Console.WriteLine($"Thanks {Name} for purchasing {Product} today! Hope to see you here again soon!");
    }
    //4
    public void SendSaleNotice(DateTime saleTime)
    {
        Console.WriteLine($"Hello {Name}, we just wanted to let you know we have a sale coming up on {saleTime:yyyy-MM-dd}.");
    }
    public void SendSaleNotice(string product, DateTime saleTime)
    {
        Console.WriteLine($"Hello {Name}, we just wanted to let you know we have a sale on {Product} coming up on {saleTime:yyyy-MM-dd}.");
    }
    //9
    public virtual void PrintCustomerInfo()
    {
        Console.WriteLine($"{Name} - {Gender} - {Product}.");
    }
}

//5
public sealed class InactiveCustomer
    : Customer
{
    //10
    public enum Reasons
    {
        Unknown,
        Irate,
        Moved,
        Unintereseted
    }
    //6
    public InactiveCustomer(string name, Gender gender, string product, int monthsInactive)
        : base(name, gender, product)
    {
        MonthsInactive = monthsInactive;
    }
    public int MonthsInactive {get; set;}
    //7
    public void SendRetargetMessage()
    {
        var message =
            new StringBuilder($"Thanks for shopping with us, {Name}. ")
                .Append($"We saw that you purchased {Product} from us {MonthsInactive} months ago. ")
                .Append("We'd like to know if you'd like to take a look at some of our current deals.")
                .ToString();
                Console.WriteLine(message);
    }
    //11
    public Reasons whyleft { get; set; }
    //12
    public override void PrintCustomerInfo()
    {
        Console.WriteLine($"{Name} - {Gender} - {Product} - {whyleft}");
    }

}
//8
var Zach = new Customer("Zach", Gender.Male, "Nexus 5x");

Zach.thankyou();
Zach.SendSaleNotice(DateTime.Parse("2016-08-01"));
Zach.SendSaleNotice("Nexus 5x", DateTime.Parse("2016-08-01"));
Zach.PrintCustomerInfo();

var Rachel = new InactiveCustomer("Rachel", Gender.Female, "iPhone",6);

Rachel.thankyou();
Rachel.SendRetargetMessage();
Rachel.PrintCustomerInfo();