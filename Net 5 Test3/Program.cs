using System;
using System.Collections.Generic;

namespace Net_5_Test3
{
    class Program
    {
        static void Main(string[] args)
        {

            Motor honda = new() { Model = "CBR650R", Color = "red", Year = 2020, Price = 90000 };
            //honda.Model = "CBR1000RRR"; //HATA 
            honda.Color = "Dark Black"; //DOĞRU
            honda.motorList.Add(new() { Model = "CBR650R", Color = "black", Year = 2019, Price = 57000 });
        }
    }
    public class Motor
    {
        public string Model { get; init; }
        public string Color { get; set; }
        public int Year { get; init; }
        public decimal Price { get; init; }

        public List<Motor> motorList = new();
    }
}
