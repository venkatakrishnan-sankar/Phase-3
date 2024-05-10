using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public interface IBalance
    {
        public double Balance { get; set; }
        void WalletRecharge(double rechargeAmount);
        void DeductBalance(double userAmount);
        
        
        
    }
}