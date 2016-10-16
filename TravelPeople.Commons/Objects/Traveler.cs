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
    public class Traveler : ITraveler
    {

        public Passport passport { get; set; }

        public IEnumerable<Visa> visas { get; set; }

        public int travelID
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Company is required.")]
        [UIHint("SelectCompany")]
        [DisplayName("Company")]
        public int companyID
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("Last Name")]
        public string LastName
        {
            get;

            set;
        }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("First Name")]
        public string FirstName
        {
            get;

            set;
        }

        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("Middle Name")]
        public string MiddleName
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Title is required.")]
        [UIHint("SelectTitle")]
        [DisplayName("Title")]
        public string Title
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Gender is required.")]
        [UIHint("SelectGender")]
        [DisplayName("Gender")]
        public int Gender
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Street 1 is required.")]
        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("Street 1")]
        public string Street1
        {
            get;

            set;
        }

        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("Street 2")]
        public string Street2
        {
            get;

            set;
        }

        [Required(ErrorMessage = "City is required.")]
        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("City")]
        public string City
        {
            get;

            set;
        }

        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("Province / State")]
        public string ProvinceState
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(50)]
        [UIHint("SelectCountry")]
        [DisplayName("Country")]
        public string Country
        {
            get;

            set;
        }

        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("Zip Code")]
        public string ZipCode
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Birthday is required.")]
        [UIHint("TextDate")]
        [DisplayName("Birthday")]
        public DateTime DOB
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Marital Status is required.")]
        [StringLength(50)]
        [UIHint("SelectMaritalStatus")]
        [DisplayName("Marital Status")]
        public string MaritalStatus
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Nationality is required.")]
        [StringLength(50)]
        [UIHint("SelectCountry")]
        [DisplayName("Nationality")]
        public string Nationality
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Job Title is required.")]
        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("Job Title")]
        public string JobTitle
        {
            get;

            set;
        }

        [StringLength(120)]
        [UIHint("TextArea")]
        [DisplayName("Other Information")]
        public string OtherInfo
        {
            get;

            set;
        }

        [UIHint("CheckBox")]
        [DisplayName("VIP")]
        public bool VIP
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Mobile Phone is required.")]
        [StringLength(25)]
        [UIHint("TextBox")]
        [DisplayName("Mobile Phone")]
        public string MobilePhone
        {
            get;

            set;
        }

        [StringLength(25)]
        [UIHint("TextBox")]
        [DisplayName("Home Phone")]
        public string HomePhone
        {
            get;

            set;
        }

        [StringLength(255)]
        [UIHint("TextBox")]
        [DisplayName("Email")]
        public string Email
        {
            get;

            set;
        }

        [StringLength(25)]
        [UIHint("TextBox")]
        [DisplayName("Office Phone")]
        public string OfficePhone
        {
            get;

            set;
        }

        [StringLength(25)]
        [UIHint("TextBox")]
        [DisplayName("Office Mobile")]
        public string OfficeMobile
        {
            get;

            set;
        }

        [StringLength(25)]
        [UIHint("TextBox")]
        [DisplayName("Office Fax")]
        public string OfficeFax
        {
            get;

            set;
        }

        [StringLength(255)]
        [UIHint("TextBox")]
        [DisplayName("Office Email")]
        public string OfficeEmail
        {
            get;

            set;
        }

        [StringLength(50)]
        [UIHint("TextBox")]
        [DisplayName("Manager Name")]
        public string ManagerName
        {
            get;

            set;
        }

        [StringLength(255)]
        [UIHint("TextBox")]
        [DisplayName("Manager Email")]
        public string ManagerEmail
        {
            get;

            set;
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

    }
}
