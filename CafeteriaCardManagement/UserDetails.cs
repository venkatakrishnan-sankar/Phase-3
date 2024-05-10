using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement 
{
    public class UserDetails:PersonalDetails,IBalance

  
    {
        private static int s_userID=1000;
        private double _balance;
        public string UserID { get; set; }
        public string WorkStationNumber { get; set; }
        public double WalletBalance { get{return _balance;}}
        public UserDetails(string name,string fatherName,long mobileNumber,string mailID,Gender gender,string workStationNumber,double walletBalance)
        :base(name,fatherName,gender,mobileNumber,mailID)
        {
            s_userID++;
            UserID="SF"+s_userID;
            WorkStationNumber=workStationNumber;
            _balance=walletBalance;

        }
         public UserDetails(string user):base()
        
        {
            string[] values=user.Split(",");
            UserID=values[0];
           s_userID=int.Parse(values[0].Remove(0,2));
            Name=values[1];
            FatherName=values[2];
            MobileNumber=long.Parse(values[3]);
            MailID=values[4];
            Gender=Enum.Parse<Gender>(values[5]);
            WorkStationNumber=values[6];
            _balance=double.Parse(values[7]);
            
        }
        public void WalletRecharge(double rechargeAmount)
        {
            _balance+=rechargeAmount;
        } 
        public void DeductAmount(double deductAmount)
        {
            _balance-=deductAmount;
        }  
        
    
    }

}
