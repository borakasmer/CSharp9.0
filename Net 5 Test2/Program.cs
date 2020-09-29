
using static System.Console;

Student person = new("Bora", "Kasmer", 34);

WriteLine($"Person:\n1-)Name:{person.Name}\n2-)Surname:{person.Surname}\n3-)No:{person.No}");

var bora = new Student("Bora", "Kasmer", 1923);
var (name, surname, no) = bora;
WriteLine($"Student:\n1-)Name:{name}\n2-)Surname:{surname}\n3-)No:{no}");


//public record Student(string Name, string Surname, int No);

public record Student(string name, string surname, int no)
{
    public string Name => name;
    public string Surname => surname;
    public int No => no;
}

public record Car
{
    public string Name { get; init; }
    public int Year { get; init; }

    public Car(string name, int year)
      => (Name, Year) = (name, year);

    public void Deconstruct(out string name, out int year)
      => (name, year) = (Name, Year);
}


