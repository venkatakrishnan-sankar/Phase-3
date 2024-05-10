using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public interface IBalance
    {
        public double WalletBalance { get;}
    
        public void WalletRecharge(double rechargeAmount); 
        public void DeductAmount(double deductAmount);      
        
    }
}