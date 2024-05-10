using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("CafeteriaCardManagement"))
            {
                System.Console.WriteLine("Creating Folder");
                Directory.CreateDirectory("CafeteriaCardManagement");
            }
            if (!File.Exists("CafeteriaCardManagement/UserDetails.csv"))
            {
                System.Console.WriteLine("Creating File ");
                File.Create("CafeteriaCardManagement/UserDetails.csv").Close();
            }
            if (!File.Exists("CafeteriaCardManagement/FoodDetails.csv"))
            {
                System.Console.WriteLine("Creating File ");
                File.Create("CafeteriaCardManagement/FoodDetails.csv").Close();
            }
            if (!File.Exists("CafeteriaCardManagement/CartItem.csv"))
            {
                System.Console.WriteLine("Creating File ");
                File.Create("CafeteriaCardManagement/CartItem.csv").Close();
            }
             if(!File.Exists("CafeteriaCardManagement/OrderDetails.csv"))
           {
              System.Console.WriteLine("Creating File ");
              File.Create("CafeteriaCardManagement/OrderDetails.csv").Close();
           }
        }
        public static void WriteCSV()
        {
            string[] users=new string [Operation.userDetailsList.Count];
            for(int i=0;i<Operation.userDetailsList.Count;i++)
            {
                users[i]=Operation.userDetailsList[i].UserID+","+Operation.userDetailsList[i].Name+","+Operation.userDetailsList[i].FatherName+","+Operation.userDetailsList[i].MobileNumber+","+Operation.userDetailsList[i].MailID+","+Operation.userDetailsList[i].Gender+","+Operation.userDetailsList[i].WorkStationNumber+","+Operation.userDetailsList[i].WalletBalance;
            }
            File.WriteAllLines("CafeteriaCardManagement/UserDetails.csv",users);
            string [] food=new string[Operation.foodDetailsList.Count];
            for(int i=0;i<Operation.foodDetailsList.Count;i++)
            {
                food[i]=Operation.foodDetailsList[i].FoodID+","+Operation.foodDetailsList[i].FoodName+","+Operation.foodDetailsList[i].FoodPrice+","+Operation.foodDetailsList[i].AvailableQuantity;
            }
            File.WriteAllLines("CafeteriaCardManagement/FoodDetails.csv",food);
            string[] cartItem= new string[Operation.cartItemList.Count];
            for(int i=0;i<Operation.cartItemList.Count;i++)
            {
                cartItem[i]=Operation.cartItemList[i].ItemID+","+Operation.cartItemList[i].OrderID+","+Operation.cartItemList[i].FoodID+","+Operation.cartItemList[i].OrderPrice+","+Operation.cartItemList[i].OrderQuantity;
            }
            File.WriteAllLines("CafeteriaCardManagement/CartItem.csv",cartItem);

            string[] orders=new string[Operation.orderDetailsList.Count];
            for(int i=0;i<Operation.orderDetailsList.Count;i++)
            {
                orders[i]=Operation.orderDetailsList[i].OrderID+","+Operation.orderDetailsList[i].UserID+","+Operation.orderDetailsList[i].OrderDate.ToString("dd/MM/yyyy")+","+Operation.orderDetailsList[i].TotalPrice+","+Operation.orderDetailsList[i].OrderStatus;
            }
            File.WriteAllLines("CafeteriaCardManagement/OrderDetails.csv",orders);
        }
        public static void ReadCSV()
        {
            string [] users=File.ReadAllLines("CafeteriaCardManagement/UserDetails.csv");
            foreach(string user in users)
            {
                UserDetails user1=new UserDetails(user);
                Operation.userDetailsList.Add(user1);

            }
            string [] foods=File.ReadAllLines("CafeteriaCardManagement/FoodDetails.csv");
            foreach(string food in foods)
            {
                FoodDetails food1=new FoodDetails(food);
                Operation.foodDetailsList.Add(food1);

            }
            string [] carts=File.ReadAllLines("CafeteriaCardManagement/CartItem.csv");
            foreach(string cart in carts)
            {
                CartItem cart1=new CartItem(cart);
                Operation.cartItemList.Add(cart1);
            }
             string [] orders=File.ReadAllLines("CafeteriaCardManagement/OrderDetails.csv");
            foreach(string order in orders)
            {
                OrderDetails order1=new OrderDetails(order);
                Operation.orderDetailsList.Add(order1);
            }
        }

    }
}