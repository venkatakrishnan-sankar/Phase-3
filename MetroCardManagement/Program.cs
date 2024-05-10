using System;
namespace MetroCardManagement;
class Program{
    public static void Main(string[] args)
    {
       FileHandling.Create();
       //Operation.AddDefaultData();
       FileHandling.ReadCSV();
       Operation.MainMenue();
       FileHandling.WriteCSV();
    }
}