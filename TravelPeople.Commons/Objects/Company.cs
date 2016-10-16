using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TravelPeople.Commons.Objects
{
    public class Company
    {

        public int companyID
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(124)]
        [UIHint("TextBox")]
        [DisplayName("Name")]
        public string companyName
        {
            get;

            set;
        }

        [StringLength(100)]
        [UIHint("TextBox")]
        [DisplayName("Other Name")]
        public string otherName
        {
            get;

            set;
        }

        [StringLength(250)]
        [UIHint("TextArea")]
        [DisplayName("Address")]
        public string address
        {
            get;

            set;
        }

        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("City")]
        public string city
        {
            get;
            
            set;
        }

        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("State / Province")]
        public string stateProvince
        {
            get;

            set;
        }

        [StringLength(15)]
        [UIHint("TextBox")]
        [DisplayName("Zip Code")]
        public string zipPostal
        {
            get;

            set;
        }

        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("Street")]
        public string street
        {
            get;

            set;
        }

        [AllowHtml]
        [Required(ErrorMessage = "Link is required.")]
        [UIHint("TextBox")]
        [DisplayName("Link / URL")]
        public string webSite
        {
            get;

            set;
        }

    }
}
