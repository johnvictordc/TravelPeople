using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Utils
{
    public static class Constants
    {

        public static List<String> VISA_TYPES = new List<String>()
        {
            "Immigrant",
            "Nonimmigrant"
        };

        public static List<String> ENTRY_TYPES = new List<String>()
        {
            "Single",
            "Multiple"
        };

        public static Dictionary<int, String> MODULES = new Dictionary<int, String>()
        {
            {1, "Employees"},
            {2, "Companies"},
            {3, "Vendors"},
            {4, "Approvers"},
            {5, "Stakeholders"},
            {6, "Contacts"},
            {7, "Travelers"}
        };

        public static Dictionary<int, String> SIGN_CODE_CATEGORIES = new Dictionary<int, String>()
        {
            {1, "Abacus"},
            {2, "Amadeus"},
            {3, "Galileo"},
            {4, "Cebu Pacific"},
            {5, "GTA / Others"},
        };

        public static Dictionary<int, String> PHONE_CATEGORIES = new Dictionary<int, String>()
        {
            {1, "Business"},
            {2, "Home"},
            {3, "Mobile"},
            {4, "Fax / Others"},
        };

        public static Dictionary<int, String> GENDERS = new Dictionary<int, String>()
        {
            {0, "Female"},
            {1, "Male"}
        };

        public static List<String> TITLES = new List<String>()
        {
            "Mr.",
            "Ms.",
            "Mrs."
        };

        public static List<String> MARITAL_STATUS = new List<String>()
        {
            "SINGLE",
            "MARRIED",
            "WIDOWED"
        };

        public static List<String> COUNTRIES_NATIONALITIES = new List<String>()
        {
            "PH",
        };

    }
}
 