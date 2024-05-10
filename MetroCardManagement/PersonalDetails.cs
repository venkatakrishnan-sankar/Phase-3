using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class PersonalDetails
    {
        public string UserName { get; set; }
        public long PhoneNumber { get; set; }
        public PersonalDetails(string userName,long phoneNumber)
        {
          UserName=userName;
          PhoneNumber=phoneNumber;
        }
        public PersonalDetails()
        {
          
        }
                
        
    }
}