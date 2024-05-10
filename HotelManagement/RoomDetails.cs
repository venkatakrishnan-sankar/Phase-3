using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public enum RoomType{Standard,Delux,Suit}
    public class RoomDetails
    {
        private static int s_roomID=100;
        public string RoomID { get;  }
        public RoomType RoomType { get; set; }
        public int NumberOfBeds { get; set; }
        public double PricePerDay { get; set; }
        public RoomDetails(RoomType roomType,int numberOfBeds,double pricePerDay)
         {
            s_roomID++;
            RoomID="RID"+s_roomID;
            NumberOfBeds=numberOfBeds;
            PricePerDay=pricePerDay;
         }
    }
}