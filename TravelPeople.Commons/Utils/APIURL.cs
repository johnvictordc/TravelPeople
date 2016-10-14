using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Utils
{
    public static class APIURL
    {

        public static string CONTENT_ALL = "api/content/getcontents";

        public static string CONTENT_SINGLE = "api/content/getsingle";

        public static string CONTENT_CREATE = "api/content/create";

        public static string CONTENT_UPDATE = "api/content/update";

        public static string CONTENT_DELETE = "api/content/delete";

        public static string COMPANY_ALL = "api/company/getall";

        public static string COMPANY_SINGLE = "api/company/getsingle";

        public static string COMPANY_LIST_BY_ID = "api/company/getlistbyids";

        public static string COMPANY_CREATE = "api/company/create";

        public static string COMPANY_UPDATE = "api/company/update";

        public static string COMPANY_DELETE = "api/company/delete";
        
        public static string COMPANY_BATCH_DELETE = "api/company/batchdelete";

        public static string COMPANY_SEARCH = "api/company/search";

        public static string TRAVELER_ALL = "api/travelers/getall";

        public static string TRAVELER_SINGLE = "api/travelers/getsingle";

        public static string TRAVELER_CREATE = "api/travelers/create";

        public static string TRAVELER_UPDATE = "api/travelers/update";

        public static string TRAVELER_DELETE = "api/travelers/delete";

    }
}
