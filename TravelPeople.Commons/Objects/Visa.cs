using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPeople.Commons.Objects
{
    public class Visa
    {

        public int visaID
        { 
            get; 

            set; 
        }

        [Required(ErrorMessage = "Visa Number is required.")]
        [StringLength(25)]
        [UIHint("TextBox")]
        [DisplayName("Visa Number")]
        public string VisaNumber
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Country is required.")]
        [UIHint("SelectCountry")]
        [DisplayName("Country")]
        public string Country
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Expiry Date is required.")]
        [UIHint("TextDate")]
        [DisplayName("Expiry Date")]
        public DateTime ExpiryDate
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Length Days is required.")]
        [UIHint("TextBox")]
        [DisplayName("Length Days")]
        public int LengthDays
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Visa Type is required.")]
        [UIHint("SelectVisaType")]
        [DisplayName("Visa Type")]
        public string VisaType
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Entry Type is required.")]
        [UIHint("SelectEntyType")]
        [DisplayName("Entry Type")]
        public string EntryType
        {
            get;

            set;
        }

        [Required(ErrorMessage = "Date Issued is required.")]
        [UIHint("TextDate")]
        [DisplayName("Date Issued")]
        public DateTime DateIssued
        {
            get;

            set;
        }


        public string PassportNumber
        {
            get;

            set;
        }

        public int travelerID
        {
            get;

            set;
        }

    }
}
