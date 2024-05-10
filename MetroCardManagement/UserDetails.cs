using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class UserDetails:PersonalDetails,IBalance
    {
        private static int s_cardNumber=1000;
        public string CardNumber { get; }
        public double Balance { get; set; }
        public UserDetails(string userName,long phoneNumber,double balance):base(userName,phoneNumber)
        {
           s_cardNumber++;
           CardNumber="CMRL"+s_cardNumber;
           Balance=balance;
        }
        public UserDetails(string users):base()
        {
            string[] values=users.Split(",");
            CardNumber=values[0];
           s_cardNumber=int.Parse(values[0].Remove(0,4));
           UserName=values[1];
           PhoneNumber=long.Parse(values[2]);
           Balance=double.Parse(values[3]);
           
        }
        public void WalletRecharge(double rechargeAmount)
        {
            Balance+=rechargeAmount;
        }
        public void DeductBalance(double userAmount)
        {
           Balance-=userAmount;
        }
        
        
        
        
    }
}