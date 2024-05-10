using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace HotelManagement
{
    public static class Operation
    {
       public static CustomList<UserRegistration> userRegistrationList = new CustomList<UserRegistration>();
        public static CustomList<RoomSelection> roomSelectionList = new CustomList<RoomSelection>();
       public  static List<RoomDetails> roomDetailsList = new List<RoomDetails>();
        public static List<BookingDetails> bookingDetailsList = new List<BookingDetails>();
        static UserRegistration currentLoginUser;
        public static void AddDefaultData()
        {
            UserRegistration user1 = new UserRegistration("Ravichandran", 995875777, 347777378383, "Chennai", FoodType.Veg, Gender.Male, 5000);
            UserRegistration user2 = new UserRegistration("Baskaran", 448844848, 474777477477, "Chennai", FoodType.NonVeg, Gender.Male, 6000);
            userRegistrationList.Add(user1);
            userRegistrationList.Add(user2);
            RoomSelection roomSelection1 = new RoomSelection("BID101", "RID101", new DateTime(2022, 11, 11, 06, 00, 00), new DateTime(2022, 11, 12, 2, 00, 00), 750, 1.5, BookingStatus.Booked);
            RoomSelection roomSelection2 = new RoomSelection("BID101", "RID102", new DateTime(2022, 11, 11, 10, 00, 00), new DateTime(2022, 11, 12, 9, 00, 00), 700, 1, BookingStatus.Booked);
            RoomSelection roomSelection3 = new RoomSelection("BID102", "RID103", new DateTime(2022, 11, 12, 9, 00, 00), new DateTime(2022, 11, 13, 9, 00, 00), 500, 1, BookingStatus.Cancelled);
            RoomSelection roomSelection4 = new RoomSelection("BID102", "RID106", new DateTime(2022, 11, 12, 6, 00, 00), new DateTime(2022, 11, 13, 12, 30, 00), 1500, 1.5, BookingStatus.Cancelled);
            roomSelectionList.Add(roomSelection1);
            roomSelectionList.Add(roomSelection2);
            roomSelectionList.Add(roomSelection3);
            roomSelectionList.Add(roomSelection4);
            RoomDetails room1 = new RoomDetails(RoomType.Standard, 2, 500);
            RoomDetails room2 = new RoomDetails(RoomType.Standard, 4, 700);
            RoomDetails room3 = new RoomDetails(RoomType.Standard, 2, 500);
            RoomDetails room4 = new RoomDetails(RoomType.Standard, 2, 500);
            RoomDetails room5 = new RoomDetails(RoomType.Standard, 2, 500);
            RoomDetails room6 = new RoomDetails(RoomType.Delux, 2, 1000);
            RoomDetails room7 = new RoomDetails(RoomType.Delux, 2, 1000);
            RoomDetails room8 = new RoomDetails(RoomType.Delux, 4, 1400);
            RoomDetails room9 = new RoomDetails(RoomType.Delux, 4, 1400);
            RoomDetails room10 = new RoomDetails(RoomType.Suit, 2, 2000);
            RoomDetails room11 = new RoomDetails(RoomType.Suit, 2, 2000);
            RoomDetails room12 = new RoomDetails(RoomType.Suit, 2, 2000);
            RoomDetails room13 = new RoomDetails(RoomType.Suit, 4, 2500);
            roomDetailsList.Add(room1);
            roomDetailsList.Add(room2);
            roomDetailsList.Add(room3);
            roomDetailsList.Add(room4);
            roomDetailsList.Add(room5);
            roomDetailsList.Add(room6);
            roomDetailsList.Add(room7);
            roomDetailsList.Add(room8);
            roomDetailsList.Add(room9);
            roomDetailsList.Add(room10);
            roomDetailsList.Add(room11);
            roomDetailsList.Add(room12);
            roomDetailsList.Add(room13);
            BookingDetails booking1 = new BookingDetails("SF1001", 1450, new DateTime(2022, 11, 10), BookingStatus.Booked);
            BookingDetails booking2 = new BookingDetails("SF1002", 2000, new DateTime(2022, 11, 10), BookingStatus.Cancelled);
            bookingDetailsList.Add(booking1);
            bookingDetailsList.Add(booking2);

            /* foreach(UserRegistration user in userRegistrationList)
             {
                 System.Console.WriteLine($"{user.UserID} | {user.UserName} | {user.MobilNumber} | {user.AadharNumber} | {user.Address} | {user.FoodType} | {user.Gender} | {user.WalletBalance}");

             }
             foreach (RoomSelection room in roomSelectionList)
             {
                 System.Console.WriteLine($"{room.SelectionID} | {room.BookingID} | {room.RoomID} | {room.StayingDateFrom} | {room.StayingDateTo} | {room.Price} | {room.NumberOfDays} | {room.BookingStatus}");
             }
             foreach(RoomDetails roomDetail in roomDetailsList)
             {
                System.Console.WriteLine($"{roomDetail.RoomID} | {roomDetail.RoomType} | {roomDetail.NumberOfBeds} | {roomDetail.PricePerDay}");
             }
             foreach(BookingDetails booking in bookingDetailsList)
             {
                 System.Console.WriteLine($"{booking.BookingID} | {booking.UserID}| {booking.TotalPrice} | {booking.DateOfBooking} | {booking.BookingStatus}");
             }
             */
        }
        public static void MainMenue()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("Enter the value 1.UserRegistration 2.UserLogin 3. Exit");
                int mainMenue = int.Parse(Console.ReadLine());
                switch (mainMenue)
                {
                    case 1:
                        {
                            UserRegistration();
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
        public static void UserRegistration()
        {
            System.Console.WriteLine("Enter the Name: ");
            string userName = Console.ReadLine();
            System.Console.WriteLine("Enter your mobile Number");
            long mobileNumber = long.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter the Aadhar Number ");
            long aadharNumber = long.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter your address");
            string address = Console.ReadLine();
            System.Console.WriteLine("Enter the food Type veg NonVeg");
            FoodType foodType = Enum.Parse<FoodType>(Console.ReadLine(), true);
            System.Console.WriteLine("Enter your Gender");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            System.Console.WriteLine("Enter your Wallet Balance");
            double walletBalance = double.Parse(Console.ReadLine());
            UserRegistration user = new UserRegistration(userName, mobileNumber, aadharNumber, address, foodType, gender, walletBalance);
            userRegistrationList.Add(user);
            System.Console.WriteLine($"you are sucessfully registerd and your UserID is {user.UserID}");


        }
        public static void Login()
        {

            System.Console.WriteLine("Enter the loginID");
            string userLoginID = Console.ReadLine().ToUpper();
            currentLoginUser=Search.BinarySearch(userLoginID);
            
                if (currentLoginUser!=null)
                {
                    System.Console.WriteLine("Login successfully..");
                    
                    SubMenue();
                    
                }
                else{
                    System.Console.WriteLine("Invalid LoginID");
                }
            

        }
        public static void SubMenue()
        {
            bool flag = true;
            do
            {
                System.Console.WriteLine("Enter the value 1. View Customer Profile 2.Book Room 3.Modify Booking 4.Cancel Booking 5.Booking History 6.Wallet Recharge 7.show walletBalance 8.Exit");
                int subMenue = int.Parse(Console.ReadLine());
                switch (subMenue)
                {
                    case 1:
                        {
                            ViewCustomerProfile();
                            break;
                        }
                    case 2:
                        {
                            BookRoom();
                            break;
                        }
                    case 3:
                        {
                            ModifyBooking();
                            break;
                        }
                    case 4:
                        {
                            CancelBooking();
                            break;
                        }
                    case 5:
                        {
                            BookingHistory();
                            break;
                        }
                    case 6:
                        {
                            WalletRecharge();
                            break;
                        }
                    case 7:
                        {
                            ShowWalletBalance();
                            break;
                        }
                    case 8:
                        {
                            flag = false;
                            break;
                        }
                }
            } while (flag);
        }
        public static void ViewCustomerProfile()
        {
            foreach (UserRegistration user in userRegistrationList)
            {
                if (currentLoginUser.UserID == user.UserID)
                {
                    System.Console.WriteLine($"{user.UserID} | {user.UserName} | {user.MobilNumber} | {user.AadharNumber} | {user.Address} | {user.FoodType} | {user.Gender} | {user.WalletBalance}");
                }
            }

        }
        public static void BookRoom()
        {
            BookingDetails booking = new BookingDetails(currentLoginUser.UserID, 0, DateTime.Now, BookingStatus.Initiated);
            CustomList<RoomSelection> localRoomSelectionList = new CustomList<RoomSelection>();
            //3.	Need to show the list of available room types by traversing the Room Details list.
            string option="";
            double totalPrice=0;
            do{

            foreach (RoomDetails roomDetail in roomDetailsList)
            {
                System.Console.WriteLine($"{roomDetail.RoomID} | {roomDetail.RoomType} | {roomDetail.NumberOfBeds} | {roomDetail.PricePerDay}");
            }
            //  4.	Need to ask the user to enter DateFrom (Date and Time) and DateTo (Date and Time), RoomID & no. Of Days of booking.
            System.Console.WriteLine("Enter the Date From");
            DateTime userDateFrom = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            System.Console.WriteLine("Enter the Date To");
            DateTime userDateTo = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            System.Console.WriteLine("Enter the RoomID");
            string userRoomID = Console.ReadLine();
            System.Console.WriteLine("Enter the number of days Booking");
            double userNumberOfDays = double.Parse(Console.ReadLine());
            
            // 5.	Based on the data need to check the room is already booked or not by traversing room selection list. If it is not booked means Create Room Selection object and add it to local room selection list.
            foreach (RoomDetails room in roomDetailsList)
            {

                if (userRoomID == room.RoomID)
                {
                    foreach (RoomSelection roomSelection in roomSelectionList)
                    {
                        if (roomSelection.StayingDateTo<userDateTo&&roomSelection.BookingStatus != BookingStatus.Booked)
                        {
                             double Price = userNumberOfDays * room.PricePerDay;
                            totalPrice+=roomSelection.Price;
                            RoomSelection roomSelection1 = new(booking.BookingID, userRoomID, userDateFrom, userDateTo, Price, userNumberOfDays, BookingStatus.Initiated);
                            localRoomSelectionList.Add(roomSelection1);
                        }
                    }
                }
            }
            //6.	Ask the user whether he want to book another room. If “yes” means repeat step 3 to 5 to create new selection object and add it to local list.
            System.Console.WriteLine("You want to book another Room");
            option=Console.ReadLine();
            
            }while(option=="yes");
            
               bool flag=true;
               //7.	If user says “No” means calculate the total rent amount of that selected rooms modify the booking object details and status as booked. 
              do{

             
              if(totalPrice<currentLoginUser.WalletBalance)
              {
                flag=false;
                //8.	Check the user has enough balance. If he has enough balance Add the local temp room selection to global list. Add the booking object to booking list. And show rooms successfully booked Your booking ID – BID101.
                roomSelectionList.AddRange(localRoomSelectionList);
                booking.BookingStatus=BookingStatus.Booked;
                booking.TotalPrice=totalPrice;
                System.Console.WriteLine("Room successfully booked..and booking ID is"+booking.BookingID);
              }
              else{
                System.Console.WriteLine("Insufficient balance Are you willing to recharge..");
                string  choice=Console.ReadLine();
               
                if(choice=="yes")
                {
                    flag=true;
                    System.Console.WriteLine($"The Totalamount  is {totalPrice}");
                    System.Console.WriteLine("Enter the amount to recharge");
                    double userRechargeAmount=double.Parse(Console.ReadLine());
                    currentLoginUser.WalletRecharge(userRechargeAmount);

                }
                else{
                    flag=false;
                   System.Console.WriteLine("Exiting without Booking..");
                }
              }
           }while(flag);
              
              
            
        }
        public static void ModifyBooking()
        {
         
            foreach (BookingDetails booking in bookingDetailsList)
            {
                if (currentLoginUser.UserID == booking.UserID && booking.BookingStatus==BookingStatus.Booked)
                {
                
                    System.Console.WriteLine($"{booking.BookingID} | {booking.UserID}| {booking.TotalPrice} | {booking.DateOfBooking} | {booking.BookingStatus}");
                }

            }  
            System.Console.WriteLine("Enter the bookingId to cancel..");
            string userBookingID=Console.ReadLine();
            foreach(BookingDetails booking in bookingDetailsList)
            {
                if(booking.BookingID==userBookingID)
                {
                    foreach(RoomSelection roomSelection in roomSelectionList)
                    {
                        if(roomSelection.BookingID==booking.BookingID && booking.BookingStatus==BookingStatus.Booked)
                        {
                            System.Console.WriteLine($"{roomSelection.SelectionID} | {roomSelection.BookingID} | {roomSelection.RoomID} | {roomSelection.StayingDateFrom} | {roomSelection.StayingDateTo} | {roomSelection.Price} | {roomSelection.NumberOfDays} | {roomSelection.BookingStatus}");

                        }
                    }
                    System.Console.WriteLine("Enter the Selection you want to modify");
                    string userSelectionID=Console.ReadLine().ToUpper();
                    foreach(RoomSelection roomSelection1 in roomSelectionList)
                    {
                        if(userSelectionID==roomSelection1.SelectionID && currentLoginUser.UserID==booking.UserID && roomSelection1.BookingID==booking.BookingID)
                        {
                           System.Console.WriteLine("select the option 1.Cncel Selected Room 2. Add new Room");
                           int userChoice=int.Parse(Console.ReadLine());
                        }
                    }
                }
            }  

        }
        public static void CancelBooking()
        {
           foreach(BookingDetails booking in bookingDetailsList)
             {
                if(booking.BookingStatus==BookingStatus.Booked  && currentLoginUser.UserID==booking.UserID)
                {
                 System.Console.WriteLine($"{booking.BookingID} | {booking.UserID}| {booking.TotalPrice} | {booking.DateOfBooking} | {booking.BookingStatus}");
               }
             }
             System.Console.WriteLine("Enter the booking Id to cancel...");
             string userBookingID=Console.ReadLine();
             foreach(RoomSelection room in roomSelectionList)
             {
                if(userBookingID==room.BookingID)
                {
                    System.Console.WriteLine($"{room.SelectionID} | {room.BookingID} | {room.RoomID} | {room.StayingDateFrom} | {room.StayingDateTo} | {room.Price} | {room.NumberOfDays} | {room.BookingStatus}");
                }
             }
             System.Console.WriteLine("Enter selctionID to cancel");
             string userSelectionID=Console.ReadLine();
             bool flag=true;
             foreach(BookingDetails booking in bookingDetailsList)
             {
                if(userBookingID==booking.BookingID)
                {
                      flag=false;
                    booking.BookingStatus=BookingStatus.Cancelled;
                    currentLoginUser.WalletBalance+=booking.TotalPrice;
                    foreach(RoomSelection roomSelection in roomSelectionList)
                    {
                        if(roomSelection.BookingID==booking.BookingID )
                        {
                          
                            if(userSelectionID==roomSelection.SelectionID)
                            {

                            roomSelection.BookingStatus=BookingStatus.Cancelled;
                            }
                        }
                    }
                }
             }
             if(flag)
             {
                System.Console.WriteLine("Invalid BookingID");
             }
        }
        public static void BookingHistory()
        {
            bool flag = true;
            foreach (BookingDetails booking in bookingDetailsList)
            {
                if (currentLoginUser.UserID == booking.UserID)
                {
                    flag = false;
                    System.Console.WriteLine($"{booking.BookingID} | {booking.UserID}| {booking.TotalPrice} | {booking.DateOfBooking} | {booking.BookingStatus}");
                }
            }
            System.Console.WriteLine("Enter the BookingID");
            string userBookingID=Console.ReadLine().ToUpper();
            foreach(RoomSelection room in roomSelectionList)
            {
                if(room.BookingID==userBookingID)
                {
                   System.Console.WriteLine($"{room.SelectionID} | {room.BookingID} | {room.RoomID} | {room.StayingDateFrom} | {room.StayingDateTo} | {room.Price} | {room.NumberOfDays} | {room.BookingStatus}"); 
                }
            }
           if (flag)
            {
                System.Console.WriteLine("No History");
            }
        }
        public static void WalletRecharge()
        {
            System.Console.WriteLine("Do you want to recharge..");
            string option = Console.ReadLine();
            if (option == "yes")
            {
                System.Console.WriteLine("Enter the amount");
                double rechargeAmount = double.Parse(Console.ReadLine());
                if (rechargeAmount > 0)
                {
                    currentLoginUser.WalletRecharge(rechargeAmount);
                }
                else
                {
                    System.Console.WriteLine("Enter the Positive amount");
                }
            }
            else
            {
                System.Console.WriteLine("Thank You");
            }
        }
        public static void ShowWalletBalance()
        {
            System.Console.WriteLine($"Your current Balance is {currentLoginUser.WalletBalance}");
        }
    }
}