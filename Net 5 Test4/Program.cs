using System;
using System.Reflection.Metadata.Ecma335;
using static System.Console;
namespace Net_5_Test4
{
    public class Program
    {
        static void Main(string[] args)
        {
            Kawasaki motor = new Kawasaki("ZX6R", "green", 2020, 85000, 280, 0.6);
            
            //Honda motor = new Honda("cbr650r", "red", 2019, 90000, 250);
            //Kawasaki motor2 = new Kawasaki("ZX6R", "green", 2020, 161000, 280,0.6);

            string priceType = GetPriceState(motor);
            WriteLine($"Gerçekten {priceType}");

            decimal price = GetPriceWithTax(motor);
            WriteLine($"Motor Son Fiyatı {price}");

            //string priceType2 = GetPriceState(motor2);
            //WriteLine($"Gerçekten {priceType2}");

            Honda honda=null;
            Kawasaki kawasaki = new Kawasaki("ZX6R", "green", 2020, 85000, null, 0.6);

            Motor vehcile = honda ?? kawasaki;
            WriteLine("Vehcile: "+ vehcile);
            int? maxSpeed = vehcile is Kawasaki? ((Kawasaki)vehcile).maxSpeed ?? 0 : null; // nullable value type
            WriteLine("Vehcile Max Speed: " + maxSpeed);
        }
        public record Motor(string Model, string Color, int Year, decimal Price)
        {
            public string Color { get; set; }
        }

        public record Honda(string Model, string Color, int Year, decimal Price, int? maxSpeed) : Motor(Model, Color, Year, Price);

        public record Kawasaki(string Model, string Color, int Year, decimal Price, int? maxSpeed, double perLiterCost) : Honda(Model, Color, Year, Price, maxSpeed);

        public static string GetPriceState(Motor motor) =>
            motor switch
            {
                Honda h when h.Price < 30000 => "Ucuz Honda",
                Honda h when h.Price > 30000 & h.Price < 100000 => "Pahalı Honda",
                Kawasaki k when k.Price > 100000 => "Kawasaki hep Pahalı",
                /*Honda h when h.Year switch
                {
                    > 2019 => "Muazzam Motor",
                    >= 2018 and < 2020 => "Keşke benim olsa!",
                    < 2018 => "Boşver Alma",
                    _ => "Yok"
                },*/
                Honda or Kawasaki => "Honda veya Kawasaki çok pahalı",

                _ => throw new ArgumentException("Bilinen bir motor değil", nameof(motor))
            };
        public static decimal GetPriceWithTax(Motor motor) =>
            motor.Year switch
            {
                > 2019 => motor.Price * Convert.ToDecimal(1.2),
                >= 2018 and < 2020 => motor.Price * Convert.ToDecimal(1.1),
                < 2018 => motor.Price * Convert.ToDecimal(1.3),
                //_ => motor.Price
            };

        public static decimal GetIfPriceWithTax(Motor motor)
        {
            if (motor.Year > 2019)
                return motor.Price * Convert.ToDecimal(1.2);
            else if (motor.Year >= 2018 && motor.Year < 2020)
                return motor.Price * Convert.ToDecimal(1.1);
            else if (motor.Year < 2018)
                return motor.Price * Convert.ToDecimal(1.3);
            else
                return motor.Price;
        }
    }

    public abstract class Person
    {
        public abstract Person GetJob();
    } 

    public class Developer : Person
    {
        public override Developer GetJob() { return new Developer(); }
    }
}