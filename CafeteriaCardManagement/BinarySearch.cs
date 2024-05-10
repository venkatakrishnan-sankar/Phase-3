using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public class BinarySearch
    {
      public static UserDetails BinarySearchess(string searchElement)
        {
            CustomList<UserDetails> userDetailsList=Operation.userDetailsList;
            int left=0;int right=Operation.userDetailsList.Count-1;
        
            while(left<=right)
            {
                int middle=left+((right-left)/2);
                
              int result=string.Compare(userDetailsList[middle].UserID,searchElement);
                if(result==0)
                {
                    return userDetailsList[middle];

                }
                else if(result<0)
                {
                    left=middle+1;
                }
                else{
                    right=middle-1;
                }
            }
            return null;
                    
       }
    }
}