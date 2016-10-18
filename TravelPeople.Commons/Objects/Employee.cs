using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPeople.Commons.Interfaces;

namespace TravelPeople.Commons.Objects
{
    public class Employee : IEmployee
    {
        public int UserID { get; set; }
        
        [Required(ErrorMessage = "Company is required.")]
        [UIHint("SelectCompany")]
        [DisplayName("Company")]
        public int companyID
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("Last Name")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("First Name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Position is required.")]
        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("Position")]
        public string position { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("Full Address")]
        public string fullAddress { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(50)]
        [UIHint("SelectCountry")]
        [DisplayName("Country")]
        public string country { get; set; }

        [Required(ErrorMessage = "Birthday is required.")]
        [UIHint("TextDate")]
        [DisplayName("Birthday")]
        public DateTime dob { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        [UIHint("SelectGender")]
        [DisplayName("Gender")]
        public int gender { get; set; }

        public string FullName()
        {
            return lastName + ", " + firstName;
        }
    }
}
