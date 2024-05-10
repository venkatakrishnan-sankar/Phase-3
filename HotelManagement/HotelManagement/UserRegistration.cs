using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public class UserRegistration:PersonalDetails,IWalletManager
    {
         
    
        private double _balance;
        private static int s_userID=1000;
        public string UserID { get; }
        public double  WalletBalance { get; set; }

        public UserRegistration(string userName,long mobileNumber,long aadharNumber,string address,FoodType foodType,Gender gender,double walletBalance):base(userName,mobileNumber,aadharNumber,address,foodType,gender)
        {
           s_userID++;
           UserID="SF"+s_userID;
           WalletBalance=walletBalance;
        }
       public void WalletRecharge(double rechargeAmount)
        {
           WalletBalance+=rechargeAmount;
        }
        public void DeductBalance(double userAmount)
        {
            WalletBalance-=userAmount;
        }
    
    }
}