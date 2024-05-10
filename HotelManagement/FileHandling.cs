using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HotelManagement
{
    public class FileHandling
    {
        public static void CreateCSV()
        {
            if(!Directory.Exists("HotelManagement"))
            {
               System.Console.WriteLine("Creating Folder");
               Directory.CreateDirectory("HotelManagement");
            }
            if(!File.Exists("HotelManagement/UserRegistration"))
            {
                System.Console.WriteLine("Creating File");
                File.Create("HotelManagement/UserRegistration").Close();
            }
             if(!File.Exists("HotelManagement/RoomSelection"))
            {
                System.Console.WriteLine("Creating File");
                File.Create("HotelManagement/RoomSelection").Close();
            }
            if(!File.Exists("HotelManagement/RoomDetails"))
            {
                System.Console.WriteLine("Creating File");
                File.Create("HotelManagement/RoomDetails").Close();
            }
            if(!File.Exists("HotelManagement/BookingDetails"))
            {
                System.Console.WriteLine("Creating File");
                File.Create("HotelManagement/BookingDetails").Close();
            }
        }
        public static void WriteCSV()
        {
             string[] users=new string[Operation.userRegistrationList.Count];
             for(int i=0;i<Operation.userRegistrationList.Count;i++)
             {
                users[i]=Operation.userRegistrationList[i].UserID+","+Operation.userRegistrationList[i].UserName+","+Operation.userRegistrationList[i].MobilNumber+","+Operation.userRegistrationList[i].AadharNumber+","+Operation.userRegistrationList[i].Address+","+Operation.userRegistrationList[i].FoodType+","+Operation.userRegistrationList[i].Gender+","+Operation.userRegistrationList[i].WalletBalance;
             }
             File.WriteAllLines("HotelManagement/UserRegistration",users);

             string[] RoomSelections=new string[Operation.roomSelectionList.Count];
             for (int i=0;i<Operation.roomSelectionList.Count;i++)
             {
                RoomSelections[i]=Operation.roomSelectionList[i].SelectionID+","+Operation.roomSelectionList[i].BookingID+","+Operation.roomSelectionList[i].StayingDateFrom+","+Operation.roomSelectionList[i].StayingDateTo+","+Operation.roomSelectionList[i].Price+","+Operation.roomSelectionList[i].NumberOfDays+","+Operation.roomSelectionList[i].BookingStatus;
             }
             File.WriteAllLines("HotelManagement/RoomSelection",RoomSelections);

             string [] rooms=new string[Operation.roomDetailsList.Count];
             for (int i=0;i<Operation.roomDetailsList.Count;i++)
             {
                rooms[i]=Operation.roomDetailsList[i].RoomID+","+Operation.roomDetailsList[i].RoomType+","+Operation.roomDetailsList[i].NumberOfBeds+","+Operation.roomDetailsList[i].PricePerDay;
             }

             File.WriteAllLines("HotelManagement/RoomDetails",rooms);

             string[] Bookings=new string[Operation.bookingDetailsList.Count];
             for(int i=0;i<Operation.bookingDetailsList.Count;i++)
             {
                Bookings[i]=Operation.bookingDetailsList[i].BookingID+","+Operation.bookingDetailsList[i].UserID+","+Operation.bookingDetailsList[i].TotalPrice+","+Operation.bookingDetailsList[i].DateOfBooking+","+Operation.bookingDetailsList[i].BookingStatus;
             }
             File.WriteAllLines("HotelManagement/BookingDetails",Bookings);
        }
        
    }
}