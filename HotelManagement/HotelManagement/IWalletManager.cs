using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public interface IWalletManager
    {
        public double WalletBalance { get;set;}
        void WalletRecharge(double rechargeAmount);
        void DeductBalance(double userAmount);
    }
}