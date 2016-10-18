using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Interfaces
{
    public interface IEmployee
    {
    	int companyID { get; set; }
    	
        int UserID { get; set; }

        string lastName { get; set; }

        string firstName { get; set; }

        string position { get; set; }

        string fullAddress { get; set; }

        string country { get; set; }

        DateTime dob { get; set; }

        int gender { get; set; }
    }
}
