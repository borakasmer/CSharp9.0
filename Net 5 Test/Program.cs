
using static System.Console;

Motor honda = new()
{
    Model = "CBR650R",
    Color = "red",
    Year = 2020,
    Price = 90000
};

var blackHonda = honda with { Color = "Black" };
var colorHonda = honda with { Color = "red" };

//blackHonda.Model = "CBR1000RR";
//blackHonda.Color = "Dark Black";

WriteMotor(blackHonda);

WriteLine($"Referance Honda&Black Equals:{ReferenceEquals(honda, blackHonda)}");
WriteLine($"Equals Color&Honda :{Equals(colorHonda, honda)}");
WriteLine($"Equals Black&Honda:{Equals(honda, blackHonda)}");

static void WriteMotor(Motor motor)
{
    WriteLine($"1-){motor.Model}\n2-){motor.Color}\n3-){motor.Year}\n4-){motor.Price}");
}

WriteLine("Demo Has Ended!");
record Motor
{
    public string Model { get; init; }
    public string Color { get; set; }
    public int Year { get; init; }
    public decimal Price { get; init; }
}

//public class Student
//{
//    public Student(string _name, string _surname)
//    {
//        Name = _name;
//        Surname = _surname;
//    }
//    public string Name { get; set; }
//    public string Surname { get; set; }
//}




