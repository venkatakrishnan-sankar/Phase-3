using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class CartItem
    {
        private static int s_itemID=100;
        public string ItemID { get; }
        public string OrderID { get; set; }
        public string FoodID { get; set; }
        public double OrderPrice { get; set; }
        public int OrderQuantity { get; set; }

        public CartItem(string orderID,string foodID,double orderPrice,int orderQuantity)
        {
            s_itemID++;
            ItemID="ITID"+s_itemID;
            OrderID=orderID;
            FoodID=foodID;
            OrderPrice=orderPrice;
            OrderQuantity=orderQuantity;
            
        }
         public CartItem(string cart)
        {
            string[] values=cart.Split(",");
            ItemID=values[0];
            s_itemID=int.Parse(values[0].Remove(0,4));
            OrderID=values[1];
            FoodID=values[2];
            OrderPrice=double.Parse(values[3]);
            OrderQuantity=int.Parse(values[4]);
            
        }
        
        
        
        
        
        
        
        
        
        
    }
}