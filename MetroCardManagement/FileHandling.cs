using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("MetroCardManagement"))
            {
                System.Console.WriteLine("Creating Folder");
                Directory.CreateDirectory("MetroCardManagement");
            }
            if(!File.Exists("MetroCardManagement/UserDetails.csv"))
            {
                System.Console.WriteLine("Creating File");
                File.Create("MetroCardManagement/UserDetails.csv").Close();
            }
            if(!File.Exists("MetroCardManagement/TravelDetails.csv"))
            {
                System.Console.WriteLine("Creating File");
                File.Create("MetroCardManagement/TravelDetails.csv").Close();
            }
             if(!File.Exists("MetroCardManagement/TicketFairDetails.csv"))
            {
                System.Console.WriteLine("Creating File");
                File.Create("MetroCardManagement/TicketFairDetails.csv").Close();
            }
        }
        public static void WriteCSV()
        {
            string [] user=new string[Operation.userDetailsList.Count];
            for(int i=0;i<Operation.userDetailsList.Count;i++)
            {
                user[i]=Operation.userDetailsList[i].CardNumber+","+Operation.userDetailsList[i].UserName+","+Operation.userDetailsList[i].PhoneNumber+","+Operation.userDetailsList[i].Balance;
            }
            File.WriteAllLines("MetroCardManagement/UserDetails.csv",user);

            string [] travel=new string[Operation.travelDetailsList.Count];
            for(int i=0;i<Operation.travelDetailsList.Count;i++)
            {
                travel[i]=Operation.travelDetailsList[i].TravelID+","+Operation.travelDetailsList[i].CardNumber+","+Operation.travelDetailsList[i].FromLocation+","+Operation.travelDetailsList[i].ToLocation+","+Operation.travelDetailsList[i].Date.ToString("dd/MM/yyyy")+","+Operation.travelDetailsList[i].TravelCost;
            }
            File.WriteAllLines("MetroCardManagement/TravelDetails.csv",travel);
 
            string [] ticket=new string[Operation.ticketFairDetailsList.Count];
            for(int i=0;i<Operation.ticketFairDetailsList.Count;i++)
            {
                ticket[i]=Operation.ticketFairDetailsList[i].TicketID+","+Operation.ticketFairDetailsList[i].FromLocation+","+Operation.ticketFairDetailsList[i].ToLocation+","+Operation.ticketFairDetailsList[i].TicketPrice;
            }
            File.WriteAllLines("MetroCardManagement/TicketFairDetails.csv",ticket);
            
        }
        public static void ReadCSV()
        {
            string[] users=File.ReadAllLines("MetroCardManagement/UserDetails.csv");
            foreach(string user in users)
            {
               UserDetails user1=new UserDetails(user);
               Operation.userDetailsList.Add(user1);
            }
            string[] travels=File.ReadAllLines("MetroCardManagement/TravelDetails.csv");
            foreach(string travel in travels)
            {
               TravelDetails travel1=new TravelDetails(travel);
               Operation.travelDetailsList.Add(travel1);
            }
            string[] tickets=File.ReadAllLines("MetroCardManagement/TicketFairDetails.csv");
            foreach(string ticket in tickets)
            {
               TicketFairDetails ticket1=new TicketFairDetails(ticket);
               Operation.ticketFairDetailsList.Add(ticket1);
            }
            
        }
    }
}