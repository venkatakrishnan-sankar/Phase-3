using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public enum FoodType{Veg,NonVeg}
    public enum Gender{Male,Female,Transgender}
    public class PersonalDetails
    {
        public string UserName { get; set; }
        public long  MobilNumber { get; set; }
        public long AadharNumber { get; set; }
        public string Address { get; set; }
        public FoodType FoodType { get; set; }
        public Gender Gender { get; set; }

        public PersonalDetails(string userName,long mobileNumber,long aadharNumber,string address,FoodType foodType,Gender gender)
        {
            UserName=userName;
            MobilNumber=mobileNumber;
            AadharNumber=aadharNumber;
            Address=address;
            FoodType=foodType;
            Gender=gender;
        }
    }
}