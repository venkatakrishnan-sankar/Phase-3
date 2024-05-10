using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement
{
    public class Search
    {
        public static UserRegistration BinarySearch(string searchElement)
        {
            CustomList<UserRegistration>userRegistrationList=Operation.userRegistrationList;
            int left=0;
            int right=Operation.userRegistrationList.Count-1;
            while(left<=right)
            {
                int middle=left+(right-left)/2;
                int result=string.Compare(userRegistrationList[middle].UserID,searchElement);
                if(userRegistrationList[middle].UserID==searchElement)
                {
                    return userRegistrationList[middle];
                }
                else if(result<0)
                {
                    left=middle+1;
                }
                else{
                    right= middle-1;
                }
            }
            return null;
        }
    }
}