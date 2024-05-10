using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public static class Operation
    {
        public static CustomList<UserDetails> userDetailsList = new CustomList<UserDetails>();
        public static CustomList<TravelDetails> travelDetailsList = new CustomList<TravelDetails>();
        public static CustomList<TicketFairDetails> ticketFairDetailsList = new CustomList<TicketFairDetails>();
        static UserDetails currentLoginUser;
        public static void AddDefaultData()
        {
            UserDetails user1 = new UserDetails("Ravi", 9848812345, 1000);
            UserDetails user2 = new UserDetails("Baskaran", 9948854321, 1000);
            userDetailsList.Add(user1);
            userDetailsList.Add(user2);
            TravelDetails travel1 = new TravelDetails("CMRL1001", "Airport", "Egmore", new DateTime(2023, 10, 10), 55);
            TravelDetails travel2 = new TravelDetails("CMRL1001", "Egmore", "Koyambedu", new DateTime(2023, 10, 10), 32);
            TravelDetails travel3 = new TravelDetails("CMRL1002", "Alandur", "Koyambedu", new DateTime(2023, 11, 10), 25);
            TravelDetails travel4 = new TravelDetails("CMRL1002", "Egmore", "Thirumangalam", new DateTime(2023, 11, 10), 25);
            travelDetailsList.Add(travel1);
            travelDetailsList.Add(travel2);
            travelDetailsList.Add(travel3);
            travelDetailsList.Add(travel4);
            TicketFairDetails ticket1 = new TicketFairDetails("Airport", "Egmore", 55);
            TicketFairDetails ticket2 = new TicketFairDetails("Airport", "Koyambedu", 25);
            TicketFairDetails ticket3 = new TicketFairDetails("Alandur", "Koyambedu", 25);
            TicketFairDetails ticket4 = new TicketFairDetails("Koyambedu", "Egmore", 32);
            TicketFairDetails ticket5 = new TicketFairDetails("Vadapalani", "Egmore", 45);
            TicketFairDetails ticket6 = new TicketFairDetails("Arumbakkam", "Egmore", 25);
            TicketFairDetails ticket7 = new TicketFairDetails("Vadapalani", "Koyambedu", 25);
            TicketFairDetails ticket8 = new TicketFairDetails("Vadapalani", "Koyambedu", 25);
            ticketFairDetailsList.Add(ticket1);
            ticketFairDetailsList.Add(ticket2);
            ticketFairDetailsList.Add(ticket3);
            ticketFairDetailsList.Add(ticket4);
            ticketFairDetailsList.Add(ticket5);
            ticketFairDetailsList.Add(ticket6);
            ticketFairDetailsList.Add(ticket7);
            ticketFairDetailsList.Add(ticket8);
            /*   foreach(UserDetails user in userDetailsList)
               {
                   System.Console.WriteLine($"{user.CardNumber} | {user.UserName} | {user.PhoneNumber} | {user.Balance}");

               }
               foreach(TravelDetails travel in travelDetailsList)
               {
                   System.Console.WriteLine($"{travel.TravelID} | {travel.CardNumber} | {travel.FromLocation} | {travel.ToLocation} | {travel.Date} | {travel.TravelCost}");
               }
               foreach(TicketFairDetails ticket in ticketFairDetailsList)
               {
                   System.Console.WriteLine($"{ticket.TicketID} | {ticket.FromLocation} | {ticket.ToLocation} | {ticket.TicketPrice}");
               }
               */
        }
        public static void MainMenue()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("Enter the value 1. New UserRegistration 2. Login User 3.Exit");
                int mainMenue = int.Parse(Console.ReadLine());
                switch (mainMenue)
                {
                    case 1:
                        {
                            NewUserRegistration();
                            break;
                        }
                    case 2:
                        {
                            Login();
                            break;
                        }
                    case 3:
                        {
                            flag = false;
                            break;
                        }
                }
            } while (flag);
        }
        public static void NewUserRegistration()
        {
            System.Console.WriteLine("Enter the userName");
            string userName = Console.ReadLine();
            System.Console.WriteLine("Enter the Phone Number");
            long phoneNumber = long.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter the balance");
            double balance = double.Parse(Console.ReadLine());
            UserDetails user = new UserDetails(userName, phoneNumber, balance);
            userDetailsList.Add(user);
            System.Console.WriteLine($"You are Regisered Successfully.. and you CardNumber is {user.CardNumber}");
        }
        public static void Login()
        {
            System.Console.WriteLine("Enter you CardNumber");
            string loginId = Console.ReadLine().ToUpper();
            currentLoginUser = BinarySearch.BinarySearches(loginId);
            bool flag = true;

            if (currentLoginUser != null)
            {
                flag = false;
                System.Console.WriteLine("Login successfully..");
                SubMenue();

            }

            if (flag)
            {
                System.Console.WriteLine("Invalid CarD number");
            }
        }
        public static void SubMenue()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("Enter the value 1.Balance check 2. Recharge 3.View Travel History 4.Travel 5.Exit");
                int subMenue = int.Parse(Console.ReadLine());
                switch (subMenue)
                {
                    case 1:
                        {
                            BalanceCheck();
                            break;
                        }
                    case 2:
                        {
                            Recharge();
                            break;
                        }
                    case 3:
                        {
                            ViewTravelHistory();
                            break;
                        }
                    case 4:
                        {
                            Travel();
                            break;
                        }
                    case 5:
                        {
                            flag = false;
                            break;
                        }
                }
            } while (flag);
        }
        public static void BalanceCheck()
        {
            foreach (UserDetails user in userDetailsList)
            {
                if (currentLoginUser.CardNumber == user.CardNumber)
                {
                    System.Console.WriteLine($"Your Balace is {user.Balance}");
                }
            }
        }
        public static void Recharge()
        {
            System.Console.WriteLine("Enter the amount to recharge..");
            double userRechargeAmount = double.Parse(Console.ReadLine());
            if (userRechargeAmount > 0)
            {
                foreach (UserDetails user in userDetailsList)
                {
                    if (user.CardNumber == currentLoginUser.CardNumber)
                    {
                        currentLoginUser.WalletRecharge(userRechargeAmount);
                        System.Console.WriteLine($"Your current Balance is : {currentLoginUser.Balance}");
                    }
                }
            }
            else
            {
                System.Console.WriteLine("Enter the Postive Amount..");
            }
        }
        public static void ViewTravelHistory()
        {
            bool flag = true;
            foreach (TravelDetails travel in travelDetailsList)
            {

                if (travel.CardNumber == currentLoginUser.CardNumber)
                {
                    flag = false;
                    System.Console.WriteLine($"{travel.TravelID} | {travel.CardNumber} | {travel.FromLocation} | {travel.ToLocation} | {travel.Date.ToString("dd/MM/yyyy")} | {travel.TravelCost}");
                }
            }
            if (flag)
            {
                System.Console.WriteLine("There is no travel History");
            }
        }
        public static void Travel()
        {
            //1.	Show the Ticket fair details where the user wishes to travel by getting TicketID.
            foreach (TicketFairDetails ticket in ticketFairDetailsList)
            {
                System.Console.WriteLine($"{ticket.TicketID} | {ticket.FromLocation} | {ticket.ToLocation} | {ticket.TicketPrice}");
            }
            System.Console.WriteLine("Enter TicketID you want to travel..");
            string userTicketID = Console.ReadLine().ToUpper();
            bool flag = true;
            foreach (TicketFairDetails ticket in ticketFairDetailsList)
            {
                //2.	Check the ticketID is valid. Else show “Invalid user id”.
                if (ticket.TicketID == userTicketID)
                {
                    flag = false;
                    //3.	IF ticket is valid then, Check the balance from the user object whether it has sufficient balance to travel.
                    if (currentLoginUser.Balance >= ticket.TicketPrice)
                    {
                        //4.	If “Yes” deduct the respective amount from the balance and add the travel details like Card number, From and ToLocation, Travel Date, Travel cost, Travel ID (auto generation) in his travel history.
                        currentLoginUser.DeductBalance(ticket.TicketPrice);
                        TravelDetails travel = new TravelDetails(currentLoginUser.CardNumber, ticket.FromLocation, ticket.ToLocation, DateTime.Now, ticket.TicketPrice);
                        travelDetailsList.Add(travel);
                        System.Console.WriteLine("Travel ticket booked Successfully");
                    }
                    else
                    {
                        // 5.	If “No” ask him to recharge and go to the “Existing User Service” menu.
                        System.Console.WriteLine("Insufficient Balance please  recharge");
                    }
                }
            }
            if (flag)
            {
                System.Console.WriteLine("Invalid TicketID");
            }

        }
    }
}