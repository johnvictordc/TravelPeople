using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Interfaces
{
    public interface ITraveler
    {
        long travelID { get; set; }

        long companyID { get; set; }

        string LastName { get; set; }

        string FirstName { get; set; }

        string MiddleName { get; set; }

        int Gender { get; set; }

        string Street1 { get; set; }

        string Street2 { get; set; }

        string City { get; set; }

        string ProvinceState { get; set; }

        string Country { get; set; }

        string ZipCode { get; set; }

        DateTime DOB { get; set; }

        string MaritalStatus { get; set; }

        string Nationality { get; set; }

        string JobTitle { get; set; }

        string OtherInfo { get; set; }

        Boolean VIP { get; set; }

        string MobilePhone { get; set; }

        string HomePhone { get; set; }

        string Email { get; set; }

        string OfficePhone { get; set; }

        string OfficeMobile { get; set; }

        string OfficeFax { get; set; }

        string OfficeEmail { get; set; }

        string ManagerName { get; set; }

        string ManagerEmail { get; set; }


        
    }
}
