using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public static class Operation
    {
        public static CustomList<UserDetails> userDetailsList=new CustomList<UserDetails>();
        public static CustomList<CartItem> cartItemList=new CustomList<CartItem>();
        public static CustomList<FoodDetails> foodDetailsList=new CustomList<FoodDetails>();
        public static CustomList<OrderDetails>orderDetailsList=new CustomList<OrderDetails>();
        static UserDetails currentLoginUser;
        public static void AddDefaultData()
        {
            UserDetails user1=new UserDetails("Ravichandran","Ettapparajan",8857777575,"ravi@gmail.com",Gender.Male,"WS101",400);
            UserDetails user2=new UserDetails("Baskaran","Sethurajan",9577747744,"baskaran@gmail.com",Gender.Male,"WS105",500);
            userDetailsList.Add(user1);
            userDetailsList.Add(user2);
            FoodDetails food1=new FoodDetails("Coffee",20,100);
            FoodDetails food2=new FoodDetails("Tea",15,100);
            FoodDetails food3=new FoodDetails("Biscuit",10,100);
            FoodDetails food4=new FoodDetails("Juice",50,100);
            FoodDetails food5= new FoodDetails("Puff",40,100);
            FoodDetails food6=new FoodDetails("Milk",10,100);
            FoodDetails food7=new FoodDetails("Popcorn",20,20);
            foodDetailsList.Add(food1);
            foodDetailsList.Add(food2);
            foodDetailsList.Add(food3);
            foodDetailsList.Add(food4);
            foodDetailsList.Add(food5);
            foodDetailsList.Add(food6);
            foodDetailsList.Add(food7);
            OrderDetails order1=new OrderDetails("SF1001",new DateTime(2022,06,15),70,OrderStatus.Ordered);
            OrderDetails order2= new OrderDetails("SF1002",new DateTime(2022,06,15),100,OrderStatus.Ordered);
            orderDetailsList.Add(order1);
            orderDetailsList.Add(order2);
            CartItem cartItem1=new CartItem("OID1001","FID101",20,1);
            CartItem cartItem2=new CartItem("OID1001","FID103",10,1);
            CartItem cartItem3=new CartItem("OID1001","FID105",40,1);
            CartItem cartItem4=new CartItem("OID1002","FID103",10,1);
            CartItem cartItem5=new CartItem("OID1002","FID104",50,1);
            CartItem cartItem6=new CartItem("OID1002","FID105",40,1);
            cartItemList.Add(cartItem1);
            cartItemList.Add(cartItem2);
            cartItemList.Add(cartItem3);
            cartItemList.Add(cartItem4);
            cartItemList.Add(cartItem5);
            cartItemList.Add(cartItem6);

           /*foreach(UserDetails user in userDetailsList)
            {
                System.Console.WriteLine($"{user.UserID} | {user.Name} | {user.FatherName} | {user.MobileNumber} | {user.MailID} | {user.Gender} | {user.WorkStationNumber} | {user.WalletBalance}");
            }
            foreach(FoodDetails food in foodDetailsList)
            {
                System.Console.WriteLine($"{food.FoodID} | {food.FoodName} | {food.FoodPrice} | {food.AvailableQuantity}");
            }
            foreach(OrderDetails order in orderDetailsList)
            {
                System.Console.WriteLine($"{order.OrderID} | {order.UserID} | {order.OrderDate} | {order.TotalPrice} | {order.OrderStatus}");
            }
            foreach(CartItem cartItem in cartItemList)
            {
                System.Console.WriteLine($"{cartItem.ItemID} | {cartItem.OrderID} | {cartItem.FoodID} | {cartItem.OrderPrice} | {cartItem.OrderQuantity}");
            }
            */

        }
        public static void MainMenue()
        {
            bool flag=true;
            do{
            System.Console.WriteLine("Enter the value 1.User Registration 2.Login 3.Exit");
            int mainMenue=int.Parse(Console.ReadLine());
            switch(mainMenue){
                case 1:{
                    UserRegistration();
                    break;
                }
                case 2:{
                    Login();
                    break;
                }
                case 3:{
                    flag=false;
                    break;
                }
            }
            
            }while(flag);

        }
        public static void UserRegistration()
        {
           System.Console.WriteLine("Enter Your Name: ");
           string name=Console.ReadLine();
           System.Console.WriteLine("Enter your FatherName:");
           string fatherName=Console.ReadLine();
           System.Console.WriteLine("Enter your mobile number:");
           long mobileNumber=long.Parse(Console.ReadLine());
           System.Console.WriteLine("Enter the mailID");
           string mailID=Console.ReadLine();
           System.Console.WriteLine("Enter your Gender");
           Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
           System.Console.WriteLine("Enter your Work station Number");
           string workStationNumber=Console.ReadLine();
           System.Console.WriteLine("Enter your WalletBalance");
           double walletBalance=double.Parse(Console.ReadLine());
           UserDetails user=new UserDetails(name,fatherName,mobileNumber,mailID,gender,workStationNumber,walletBalance);
           userDetailsList.Add(user);
           System.Console.WriteLine($"You are Successfully registered.. and your UserID is {user.UserID}");

           
        }
        public static void Login()
        {
          System.Console.WriteLine("Enter your UserID");
          string loginID=Console.ReadLine().ToUpper();
          
          
        currentLoginUser=BinarySearch.BinarySearchess(loginID);
          //  string values=Convert.ToString(position);
            bool flag=true;
           
                if(currentLoginUser!=null)
                {
                    flag=false;
                System.Console.WriteLine("Login Successfully..");
                 flag=false;   
            
                SubMenue();
    
                }
            
          if(flag)
          {
            System.Console.WriteLine("Invalid userID");
          }
        }
        public static void SubMenue()
        {
            bool flag=true;
           do{
            System.Console.WriteLine("Enter the value 1.Show My Profile 2.Food Order 3.Modify Order 4.Cancel Order 5.Order History 6.Wallet Recharge 7.Show WalletBalance 8.Exit");
            int subMenue=int.Parse(Console.ReadLine());
            switch(subMenue)
            {
                case 1:{
                    ShowMyProfile();
                    break;
                }
                case 2:{
                    FoodOrder();
                    break;
                }
                case 3:{
                    ModifyOrder();
                    break;
                }
                case 4:{
                    CancelOrder();
                    break;
                }
                case 5:{
                    OrderHistory();
                    break;
                }
                case 6:{
                    WalletRecharge();
                    break;
                }
                case 7:{
                    ShowWalletBalance();
                    break;
                }
                case 8:{
                    flag=false;
                    break;
                }
            }
           }while(flag);
        }
        public static void ShowMyProfile()
        {
            foreach(UserDetails user in userDetailsList)
            {
                if(user.UserID==currentLoginUser.UserID)
                {
                     System.Console.WriteLine($"{user.UserID} | {user.Name} | {user.FatherName} | {user.MobileNumber} | {user.MailID} | {user.Gender} | {user.WorkStationNumber} | {user.WalletBalance}");
                }
            }
        }
        public static void FoodOrder()
        {
            //1.	Create a temporary local carItemtList.
            CustomList<CartItem> localCarts = new CustomList<CartItem>();
            //2.	Create an Order object with current UserID, Order date as current DateTime, total price as 0, Order status as “Initiated”.
            OrderDetails order = new OrderDetails(currentLoginUser.UserID,DateTime.Now,0,OrderStatus.Initiated);
           // 3.	Ask the user to pick a product using FoodID, quantity required and calculate price of food.
           double totalPrice=0;
           string option="";
           do{

           
           foreach(FoodDetails food in foodDetailsList)
            {
                System.Console.WriteLine($"{food.FoodID} | {food.FoodName} | {food.FoodPrice} | {food.AvailableQuantity}");
            }
            System.Console.WriteLine("Enter the FoodID you want:");
            string foodID=Console.ReadLine().ToUpper();
            System.Console.WriteLine("Enter the Quantity: ");
            int quantity=int.Parse(Console.ReadLine());
            bool flag=true;
            double price=0;
            foreach(FoodDetails food1 in foodDetailsList)
            {
                if(food1.FoodID==foodID)
                {
                     flag=false;
                    if(food1.AvailableQuantity>=quantity){
                   // 4.	If the food and quantity available, reduce the quantity from the food object’s “AvailableQuantity” then create CartItems object using the available data.
                    price=food1.FoodPrice*quantity;
                    totalPrice+=price;
                    food1.AvailableQuantity-=quantity;
                   // 5.	Add that object it to local CartItemsList to add it to cart wish list.
                    CartItem item=new CartItem(order.OrderID,foodID,price,quantity);
                    localCarts.Add(item);
                    }
                    else{
                        System.Console.WriteLine("Quantity not available");
                    }
                }
            }
            
            if(flag)
            {
                System.Console.WriteLine("Invalid FoodID");
            }
            //6.	Ask the user whether he want to pick another product. 
            System.Console.WriteLine("Do you want to pick another product: yes/no");
            option=Console.ReadLine().ToLower();
            
            }while(option=="yes");
            //9.	If He says No then, 
            // 10.	Ask the user whether he confirm the wish list to purchase. 
            //If he says “No” then traverse the local CartItemList and get the Items one by one and reverse the quantity to the FoodItem’s objects in the foodList.
           
           
            System.Console.WriteLine("Do you wish to purchase the product in wish list: ");
            string choice=Console.ReadLine().ToLower();
            if(choice=="yes")
            {
                bool temp=true;
                do{
                    
                
                // 11.	If he says “Yes” then, Calculate the total price of the food items selected using the local CartItemList information and check the balance from the user details whether it has sufficient balance to purchase.
                // 12.	If he has enough balance, then deduct the respective amount from the user’s balance. 
               if(totalPrice<=currentLoginUser.WalletBalance)
               {
                temp=false;
                //13.	Append the local CartItemList to global CartItemList.
                   cartItemList.AddRange(localCarts);
                   //14.	Modify Order object created at step 1’s total price as total OrderPrice and OrderStatus as “Ordered”. 
                   order.OrderStatus=OrderStatus.Ordered;
                   currentLoginUser.DeductAmount(totalPrice);
                   order.TotalPrice=totalPrice;
                   orderDetailsList.Add(order);
                   System.Console.WriteLine("Order placed successFully "+order.OrderID);

               }
              // 17.	If he doesn’t have enough balance show “In sufficient balance to purchase.” Ask him “Are you willing to recharge.”
               else{
                 System.Console.WriteLine("Insufficient balance to purchase");
                 System.Console.WriteLine("Are you willing to recharge.yes/no");
                 string choice1=Console.ReadLine().ToLower();
                 if(choice1=="yes")
                 {
                    temp=true;
                    System.Console.WriteLine("Enter the amount to recharge");
                    double amount=double.Parse(Console.ReadLine());
                    currentLoginUser.WalletRecharge(amount);
                    System.Console.WriteLine("Your current Wallet balance: "+currentLoginUser.WalletBalance);
                 }
                 else{
                    temp=false;
                    // 18. If he says “No” then show “Exiting without Order due to insufficient balance”. Then need to return the localCartList items to foodItemsList.
                  foreach(CartItem item in localCarts)
                   {
                    foreach(FoodDetails food in foodDetailsList)
                    {
                        if(item.FoodID==food.FoodID)
                        {
                            food.AvailableQuantity+=item.OrderQuantity;
                            break;
                        }
                    }
                 }
                }
               }
             }while(temp);
            }
            else{
                foreach(CartItem item in localCarts)
                {
                    foreach(FoodDetails food in foodDetailsList)
                    {
                        if(item.FoodID==food.FoodID)
                        {
                            food.AvailableQuantity+=item.OrderQuantity;
                            break;
                        }
                    }
                }
            }
        }
        public static void ModifyOrder()
        {
            //1.	Show the Order details of current logged in user to pick an Order detail by using OrderID and whose status is “Ordered”.
            bool anotherFlag=true;
            foreach(OrderDetails order1 in orderDetailsList)
            {
                if(currentLoginUser.UserID==order1.UserID && order1.OrderStatus==OrderStatus.Ordered)
                {
                    anotherFlag=false;
                System.Console.WriteLine($"{order1.OrderID} | {order1.UserID} | {order1.OrderDate.ToString("dd/MM/yyyy")} | {order1.TotalPrice} | {order1.OrderStatus}");
                }
            }
             if(anotherFlag)
                  {
                    System.Console.WriteLine("Invalid order ID");
                  }
            System.Console.WriteLine("Enter the orderID to modify");
            string userOrderID=Console.ReadLine().ToUpper();
                 // Check whether the order details is present. If yes then,
                 //2.	Show list of Cart Item details and ask the user to pick an Item id.
            foreach(OrderDetails order in orderDetailsList)
            {
                if(order.OrderID==userOrderID && order.OrderStatus==OrderStatus.Ordered)
                {
                  foreach(CartItem cartItem in cartItemList)
                  {
                    if(cartItem.OrderID==userOrderID)
                    {
                    System.Console.WriteLine($"{cartItem.ItemID} | {cartItem.OrderID} | {cartItem.FoodID} | {cartItem.OrderPrice} | {cartItem.OrderQuantity}");
                    }
                  }
                  //3.	Ensure the ItemID is available  Calculate the Item price and update in the OrderPrice.
                   System.Console.WriteLine("Enter the ItemID");
                   string userItemId=Console.ReadLine().ToUpper();
                   bool flag=true;
                       foreach(CartItem cart in cartItemList)
                       {
                         if(cart.ItemID==userItemId )
                         {
                            flag=false;
                            //ask the user to enter the new quantity of the food.
                            System.Console.WriteLine("Enter the new Quantity of the food");
                            int userEnterQuantity=int.Parse(Console.ReadLine());
                            foreach(FoodDetails food in foodDetailsList)
                            {
                                if(food.FoodID==cart.FoodID )
                                {
                                    if(userEnterQuantity<=food.AvailableQuantity)
                                    {
                                        int finalQuantityCheck=userEnterQuantity-cart.OrderQuantity;
                                        if(finalQuantityCheck==0)
                                        {
                                            System.Console.WriteLine("Same quantity is entered");
                                        }
                                        else if(finalQuantityCheck<0)
                                        {
                                            // reduce item count
                                             cart.OrderQuantity+=finalQuantityCheck;
                                             //Calculate returnAmount
                                             double returnAmount=-finalQuantityCheck*food.FoodPrice;
                                             //recharge to user
                                             currentLoginUser.WalletRecharge(returnAmount);
                                             order.TotalPrice-=returnAmount;
                                             // Increse Food item stock count
                                             food.AvailableQuantity+=-finalQuantityCheck;
                                             System.Console.WriteLine("order Mofied Successfully..");
                                        }
                                        else{
                                            //Calculate subtracting price
                                             double returnAmount=finalQuantityCheck*food.FoodPrice;
                                            // increase item count
                                            if(currentLoginUser.WalletBalance>=returnAmount)
                                            {
                                             cart.OrderQuantity+=finalQuantityCheck;
                                             order.TotalPrice+=returnAmount;
                                             //deduct from user
                                             currentLoginUser.DeductAmount(returnAmount);
                                             // decrease food item in stock count
                                             food.AvailableQuantity-=finalQuantityCheck;
                                             System.Console.WriteLine("order Mofied Successfully..");
                                            }

                                        }
                                         //Calculate the Item price and update in the OrderPrice.
                                           
                                               // 4.	Calculate the total price of Items and update in Order details entry. 
                                              
                                              // 5.	Show Order modified successfully.
                                             
       
                                    }
                                    else{
                                        System.Console.WriteLine("your entered quantity is not available..");
                                    }
                                }
                            }
                         }
                         
                       }
                       if(flag)
                       {
                        System.Console.WriteLine("Invalid ItemID");
                       }
               }
            }      
           

        }
        public static void CancelOrder()
        {
            //1.Show the Order details of the current user who’s Order status is “Ordered”.
           

            bool anotherFlag=true;
        foreach(OrderDetails order in orderDetailsList)
        {
            if(currentLoginUser.UserID==order.UserID && order.OrderStatus==OrderStatus.Ordered)
            {
                anotherFlag=false;
               System.Console.WriteLine($"{order.OrderID} | {order.UserID} | {order.OrderDate} | {order.TotalPrice} | {order.OrderStatus}");
        
            }
        }
        if(anotherFlag)
        {
            System.Console.WriteLine("No order Placed");
        }
        //2.	Ask the user to pick an OrderID to cancel.
        System.Console.WriteLine("Enter the orderID to cancel..");
        string userOrderID=Console.ReadLine().ToUpper();
        bool flag=false;
           //3.	Check the OrderID is valid. If not, then show “Invalid OrderID”.
            foreach(OrderDetails order in orderDetailsList)
            {
                if(userOrderID==order.OrderID)
                {
                      flag=false;
                if(currentLoginUser.UserID==order.UserID && order.OrderStatus==OrderStatus.Ordered)
                {
                   //4.	If valid, then Return the Order total amount to current user. 
          
                     currentLoginUser.WalletRecharge(order.TotalPrice);
                     //5.Return product orderQuantity to Foodtem list’s FoodQuantity. 
                     foreach(CartItem cart in cartItemList)
                     {
                        if(cart.OrderID==order.OrderID)
                        {
                            foreach(FoodDetails food in foodDetailsList)
                            {
                                if(cart.FoodID==food.FoodID)
                                {
                                    food.AvailableQuantity+=cart.OrderQuantity;
                                    break;
                                }
                            }
                        }
                     }
                     //6.Change the OrderStatus as Cancelled.
                     order.OrderStatus=OrderStatus.Cancelled;
                     //7.Show “Order cancelled successfully” and product returned to cart.
                     System.Console.WriteLine("order cancelled successfully");
                }
                }
            }
             
        
        if (flag){
            System.Console.WriteLine("Invalid Order ID");
        }
        }
        public static void OrderHistory()
        {
           foreach(OrderDetails order1 in orderDetailsList)
            {
                if(currentLoginUser.UserID==order1.UserID)
                {
                System.Console.WriteLine($"{order1.OrderID} | {order1.UserID} | {order1.OrderDate.ToString("dd/MM/yyyy")} | {order1.TotalPrice} | {order1.OrderStatus}");
                }
            }
        }
        public static void WalletRecharge()
        {
            System.Console.WriteLine("Do you want to recharge");
            string option=Console.ReadLine();
            if(option=="yes")
            {
               System.Console.WriteLine("Enter the recharge amount");
               double userEnterAmount=double.Parse(Console.ReadLine());
               if(userEnterAmount>0)
               {
                currentLoginUser.WalletRecharge(userEnterAmount);
                System.Console.WriteLine($"your wallet balace is {currentLoginUser.WalletBalance}");
                }
               else{
                System.Console.WriteLine("You entered the negative amount.Please enter the positive amount");
                }
            }
            else if(option=="no")
            {
                System.Console.WriteLine("Thank you");
            }
            else{
                System.Console.WriteLine("Invalid Input");
            }

        }
        public static void ShowWalletBalance()
        {
            System.Console.WriteLine($"your wallet balace is {currentLoginUser.WalletBalance}");
        }
        
    }
}