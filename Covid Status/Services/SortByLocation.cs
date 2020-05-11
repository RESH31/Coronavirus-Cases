using Covid_Status.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Covid_Status.Services
{
    public class SortByLocation : IComparer<Data>
    {
      
            public int Compare(Data x, Data y)
            {
                if (x.Location == null || y.Location == null)
                {
                    return 0;
                }

                // "CompareTo()" method 
                return x.Location.CompareTo(y.Location);

            }
        
    }
}