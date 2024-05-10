using System;
namespace HotelManagement;
class Program{
    public static void Main(string[] args)
    {
        FileHandling.CreateCSV();
        Operation.AddDefaultData();
        Operation.MainMenue();
        FileHandling.WriteCSV();
    }
}